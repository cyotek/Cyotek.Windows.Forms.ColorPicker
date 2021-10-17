// Cyotek Color Picker Controls Library
// http://cyotek.com/blog/tag/colorpicker

// Copyright © 2013-2021 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.cyotek.com/contribute

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms
{
  [DefaultProperty("Color")]
  [DefaultEvent("ColorChanged")]
  public class ColorWheel : Control, IColorEditor
  {
    #region Private Fields

    private static readonly object _eventAlphaChanged = new object();

    private static readonly object _eventColorChanged = new object();

    private static readonly object _eventColorStepChanged = new object();

    private static readonly object _eventDisplayLightnessChanged = new object();

    private static readonly object _eventHslColorChanged = new object();

    private static readonly object _eventLargeChangeChanged = new object();

    private static readonly object _eventLightnessChanged = new object();

    private static readonly object _eventLineColorChanged = new object();

    private static readonly object _eventSelectionSizeChanged = new object();

    private static readonly object _eventShowCenterLinesChanged = new object();

    private static readonly object _eventShowSaturationRingChanged = new object();

    private static readonly object _eventSmallChangeChanged = new object();

    private double _alpha;

    private Brush _brush;

    private PointF _centerPoint;

    private Color _color;

    private Color[] _colors;

    private int _colorStep;

    private bool _displayLightness;

    private HslColor _hslColor;

    private bool _isDragging;

    private int _largeChange;

    private double _lightness;

    private Color _lineColor;

    private Pen _linePen;

    private bool _lockUpdates;

    private PointF[] _points;

    private float _radius;

    private Image _selectionGlyph;

    private int _selectionSize;

    private bool _showCenterLines;

    private bool _showSaturationRing;

    private int _smallChange;

    private int _updateCount;

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="ColorWheel"/> class.
    /// </summary>
    public ColorWheel()
    {
      this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.Selectable | ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, true);
      _color = Color.Black;
      _hslColor = new HslColor(_color)
      {
        L = 0.5
      };
      _colorStep = 4;
      _selectionSize = 10;
      _smallChange = 1;
      _largeChange = 5;
      _lightness = 0.5;
      _alpha = 1;
      _lineColor = Color.Black;

      this.CreateLinePen();
    }

    #endregion Public Constructors

    #region Public Events

    /// <summary>
    /// Occurs when the Alpha property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler AlphaChanged
    {
      add => this.Events.AddHandler(_eventAlphaChanged, value);
      remove => this.Events.RemoveHandler(_eventAlphaChanged, value);
    }

    [Category("Property Changed")]
    public event EventHandler ColorChanged
    {
      add => this.Events.AddHandler(_eventColorChanged, value);
      remove => this.Events.RemoveHandler(_eventColorChanged, value);
    }

    [Category("Property Changed")]
    public event EventHandler ColorStepChanged
    {
      add => this.Events.AddHandler(_eventColorStepChanged, value);
      remove => this.Events.RemoveHandler(_eventColorStepChanged, value);
    }

    /// <summary>
    /// Occurs when the DisplayLightness property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler DisplayLightnessChanged
    {
      add => this.Events.AddHandler(_eventDisplayLightnessChanged, value);
      remove => this.Events.RemoveHandler(_eventDisplayLightnessChanged, value);
    }

    [Category("Property Changed")]
    public event EventHandler HslColorChanged
    {
      add => this.Events.AddHandler(_eventHslColorChanged, value);
      remove => this.Events.RemoveHandler(_eventHslColorChanged, value);
    }

    [Category("Property Changed")]
    public event EventHandler LargeChangeChanged
    {
      add => this.Events.AddHandler(_eventLargeChangeChanged, value);
      remove => this.Events.RemoveHandler(_eventLargeChangeChanged, value);
    }

    /// <summary>
    /// Occurs when the Lightness property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler LightnessChanged
    {
      add => this.Events.AddHandler(_eventLightnessChanged, value);
      remove => this.Events.RemoveHandler(_eventLightnessChanged, value);
    }

    /// <summary>
    /// Occurs when the LineColor property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler LineColorChanged
    {
      add => this.Events.AddHandler(_eventLineColorChanged, value);
      remove => this.Events.RemoveHandler(_eventLineColorChanged, value);
    }

    [Category("Property Changed")]
    public event EventHandler SelectionSizeChanged
    {
      add => this.Events.AddHandler(_eventSelectionSizeChanged, value);
      remove => this.Events.RemoveHandler(_eventSelectionSizeChanged, value);
    }

    /// <summary>
    /// Occurs when the ShowCenterLines property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler ShowCenterLinesChanged
    {
      add => this.Events.AddHandler(_eventShowCenterLinesChanged, value);
      remove => this.Events.RemoveHandler(_eventShowCenterLinesChanged, value);
    }

    /// <summary>
    /// Occurs when the ShowSaturationRing property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler ShowSaturationRingChanged
    {
      add => this.Events.AddHandler(_eventShowSaturationRingChanged, value);
      remove => this.Events.RemoveHandler(_eventShowSaturationRingChanged, value);
    }

    [Category("Property Changed")]
    public event EventHandler SmallChangeChanged
    {
      add => this.Events.AddHandler(_eventSmallChangeChanged, value);
      remove => this.Events.RemoveHandler(_eventSmallChangeChanged, value);
    }

    #endregion Public Events

    #region Public Properties

    [Category("Behavior")]
    [DefaultValue(1)]
    public double Alpha
    {
      get => _alpha;
      set
      {
        if (Math.Abs(_alpha - value) > double.Epsilon)
        {
          _alpha = value;

          this.OnAlphaChanged(EventArgs.Empty);
        }
      }
    }

    /// <summary>
    /// Gets or sets the component color.
    /// </summary>
    /// <value>The component color.</value>
    [Category("Appearance")]
    [DefaultValue(typeof(Color), "Black")]
    public virtual Color Color
    {
      get => _color;
      set
      {
        if (_color != value)
        {
          _color = value;

          this.OnColorChanged(EventArgs.Empty);
        }
      }
    }

    /// <summary>
    /// Gets or sets the increment for rendering the color wheel.
    /// </summary>
    /// <value>The color step.</value>
    /// <exception cref="System.ArgumentOutOfRangeException">Value must be between 1 and 359</exception>
    [Category("Appearance")]
    [DefaultValue(4)]
    public virtual int ColorStep
    {
      get => _colorStep;
      set
      {
        if (value < 1 || value > 359)
        {
          throw new ArgumentOutOfRangeException(nameof(value), value, "Value must be between 1 and 359");
        }

        if (_colorStep != value)
        {
          _colorStep = value;

          this.OnColorStepChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(false)]
    public bool DisplayLightness
    {
      get => _displayLightness;
      set
      {
        if (_displayLightness != value)
        {
          _displayLightness = value;

          this.OnDisplayLightnessChanged(EventArgs.Empty);
        }
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Font Font
    {
      get => base.Font;
      set => base.Font = value;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Color ForeColor
    {
      get => base.ForeColor;
      set => base.ForeColor = value;
    }

    /// <summary>
    /// Gets or sets the component color.
    /// </summary>
    /// <value>The component color.</value>
    [Category("Appearance")]
    [DefaultValue(typeof(HslColor), "0, 0, 0")]
    [Browsable(false) /* disable editing until I write a proper type convertor */]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual HslColor HslColor
    {
      get => _hslColor;
      set
      {
        if (_hslColor != value)
        {
          _hslColor = value;

          this.OnHslColorChanged(EventArgs.Empty);
        }
      }
    }

    /// <summary>
    /// Gets or sets a value to be added to or subtracted from the <see cref="Color"/> property when the wheel selection is moved a large distance.
    /// </summary>
    /// <value>A numeric value. The default value is 5.</value>
    [Category("Behavior")]
    [DefaultValue(5)]
    public virtual int LargeChange
    {
      get => _largeChange;
      set
      {
        if (_largeChange != value)
        {
          _largeChange = value;

          this.OnLargeChangeChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Behavior")]
    [DefaultValue(0.5)]
    public double Lightness
    {
      get => _lightness;
      set
      {
        if (Math.Abs(_lightness - value) > double.Epsilon)
        {
          _lightness = value;

          this.OnLightnessChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(typeof(Color), "Black")]
    public Color LineColor
    {
      get => _lineColor;
      set
      {
        if (_lineColor != value)
        {
          _lineColor = value;

          this.CreateLinePen();

          this.OnLineColorChanged(EventArgs.Empty);
        }
      }
    }

    /// <summary>
    /// Gets or sets the size of the selection handle.
    /// </summary>
    /// <value>The size of the selection handle.</value>
    [Category("Appearance")]
    [DefaultValue(10)]
    public virtual int SelectionSize
    {
      get => _selectionSize;
      set
      {
        if (_selectionSize != value)
        {
          _selectionSize = value;

          this.OnSelectionSizeChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(false)]
    public bool ShowCenterLines
    {
      get => _showCenterLines;
      set
      {
        if (_showCenterLines != value)
        {
          _showCenterLines = value;

          this.CreateLinePen();

          this.OnShowCenterLinesChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(false)]
    public bool ShowSaturationRing
    {
      get => _showSaturationRing;
      set
      {
        if (_showSaturationRing != value)
        {
          _showSaturationRing = value;

          this.OnShowSaturationRingChanged(EventArgs.Empty);
        }
      }
    }

    /// <summary>
    /// Gets or sets a value to be added to or subtracted from the <see cref="Color"/> property when the wheel selection is moved a small distance.
    /// </summary>
    /// <value>A numeric value. The default value is 1.</value>
    [Category("Behavior")]
    [DefaultValue(1)]
    public virtual int SmallChange
    {
      get => _smallChange;
      set
      {
        if (_smallChange != value)
        {
          _smallChange = value;

          this.OnSmallChangeChanged(EventArgs.Empty);
        }
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override string Text
    {
      get => base.Text;
      set => base.Text = value;
    }

    #endregion Public Properties

    #region Protected Properties

    /// <summary>
    ///   Gets a value indicating whether painting of the control is allowed.
    /// </summary>
    /// <value>
    ///   <c>true</c> if painting of the control is allowed; otherwise, <c>false</c>.
    /// </value>
    protected virtual bool AllowPainting => _updateCount == 0;

    [Obsolete("Do not use. This property will be removed in a future update.")]
    protected Color[] Colors
    {
      get => _colors;
      set => _colors = value;
    }

    [Obsolete("Do not use. This property will be removed in a future update.")]
    protected bool LockUpdates
    {
      get => _lockUpdates;
      set => _lockUpdates = value;
    }

    [Obsolete("Do not use. This property will be removed in a future update.")]
    protected PointF[] Points
    {
      get => _points;
      set => _points = value;
    }

    [Obsolete("Do not use. This property will be removed in a future update.")]
    protected Image SelectionGlyph
    {
      get => _selectionGlyph;
      set => _selectionGlyph = value;
    }

    #endregion Protected Properties

    #region Public Methods

    /// <summary>
    ///   Disables any redrawing of the image box
    /// </summary>
    public virtual void BeginUpdate()
    {
      _updateCount++;
    }

    /// <summary>
    ///   Enables the redrawing of the image box
    /// </summary>
    public virtual void EndUpdate()
    {
      if (_updateCount > 0)
      {
        _updateCount--;
      }

      if (this.AllowPainting)
      {
        this.Invalidate();
      }
    }

    #endregion Public Methods

    #region Protected Methods

    /// <summary>
    /// Calculates wheel attributes.
    /// </summary>
    protected virtual void CalculateWheel()
    {
      int count;
      PointF[] points;
      Color[] colors;
      Size size;
      double angle;

      count = 360 / _colorStep;
      points = new PointF[count];
      colors = new Color[count];
      size = this.ClientSize;
      angle = 0;

      // Only define the points if the control is above a minimum size, otherwise if it's too small, you get an "out of memory" exceptions (of all things) when creating the brush
      if (size.Width > 16 && size.Height > 16)
      {
        int w;
        int h;
        double l;

        w = size.Width;
        h = size.Height;
        l = _displayLightness
          ? _lightness
          : 0.5;

        _centerPoint = new PointF(w / 2.0F, h / 2.0F);
        _radius = this.GetRadius(_centerPoint);

        for (int i = 0; i < count; i++)
        {
          double angleR;
          PointF location;

          angleR = angle * (Math.PI / 180);
          location = this.GetColorLocation(angleR, _radius);

          points[i] = location;
          colors[i] = new HslColor(angle, 1, l).ToRgbColor();

          angle += _colorStep;
        }
      }

      _points = points;
      _colors = colors;
    }

    /// <summary>
    /// Creates the gradient brush used to paint the wheel.
    /// </summary>
    protected virtual Brush CreateGradientBrush()
    {
      Brush result;

      if (_points.Length != 0 && _points.Length == _colors.Length)
      {
        result = new PathGradientBrush(_points, WrapMode.Clamp)
        {
          CenterPoint = _centerPoint,
          CenterColor = Color.White,
          SurroundColors = _colors
        };
      }
      else
      {
        result = null;
      }

      return result;
    }

    /// <summary>
    /// Creates the selection glyph.
    /// </summary>
    protected virtual Image CreateSelectionGlyph() => null;

    /// <summary>
    /// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.Control" /> and its child controls and optionally releases the managed resources.
    /// </summary>
    /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        _linePen?.Dispose();
        _linePen = null;

        this.DisposeOfWheelBrush();
        this.DisposeOfSelectionGlyph();
      }

      base.Dispose(disposing);
    }

    /// <summary>
    /// Gets the point within the wheel representing the source color.
    /// </summary>
    /// <param name="color">The color.</param>
    protected PointF GetColorLocation(Color color)
    {
      return this.GetColorLocation(new HslColor(color));
    }

    /// <summary>
    /// Gets the point within the wheel representing the source color.
    /// </summary>
    /// <param name="color">The color.</param>
    protected virtual PointF GetColorLocation(HslColor color)
    {
      double angle;
      double radius;

      angle = color.H * Math.PI / 180;
      radius = _radius * color.S;

      return this.GetColorLocation(angle, radius);
    }

    protected PointF GetColorLocation(double angleR, double radius)
    {
      Padding padding;
      double x;
      double y;

      padding = this.Padding;
      x = padding.Left + _centerPoint.X + Math.Cos(angleR) * radius;
      y = padding.Top + _centerPoint.Y - Math.Sin(angleR) * radius;

      return new PointF((float)x, (float)y);
    }

    protected float GetRadius(PointF centerPoint)
    {
      Padding padding;

      padding = this.Padding;

      return Math.Min(centerPoint.X, centerPoint.Y) - (Math.Max(padding.Horizontal, padding.Vertical) + _selectionSize / 2);
    }

    /// <summary>
    /// Determines whether the specified key is a regular input key or a special key that requires preprocessing.
    /// </summary>
    /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys" /> values.</param>
    /// <returns>true if the specified key is a regular input key; otherwise, false.</returns>
    protected override bool IsInputKey(Keys keyData)
    {
      bool result;

      if ((keyData & Keys.Left) == Keys.Left || (keyData & Keys.Up) == Keys.Up || (keyData & Keys.Down) == Keys.Down || (keyData & Keys.Right) == Keys.Right || (keyData & Keys.PageUp) == Keys.PageUp || (keyData & Keys.PageDown) == Keys.PageDown)
      {
        result = true;
      }
      else
      {
        result = base.IsInputKey(keyData);
      }

      return result;
    }

    /// <summary>
    /// Determines whether the specified point is within the bounds of the color wheel.
    /// </summary>
    /// <param name="point">The point.</param>
    /// <returns><c>true</c> if the specified point is within the bounds of the color wheel; otherwise, <c>false</c>.</returns>
    protected bool IsPointInWheel(Point point)
    {
      PointF normalized;

      // http://my.safaribooksonline.com/book/programming/csharp/9780672331985/graphics-with-windows-forms-and-gdiplus/ch17lev1sec21

      normalized = new PointF(point.X - _centerPoint.X, point.Y - _centerPoint.Y);

      return normalized.X * normalized.X + normalized.Y * normalized.Y <= _radius * _radius;
    }

    /// <summary>
    /// Raises the <see cref="AlphaChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnAlphaChanged(EventArgs e)
    {
      EventHandler handler;

      handler = (EventHandler)this.Events[_eventAlphaChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ColorChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnColorChanged(EventArgs e)
    {
      EventHandler handler;

      if (!_lockUpdates)
      {
        this.HslColor = new HslColor(_color);
      }

      this.Refresh();

      handler = (EventHandler)this.Events[_eventColorChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ColorStepChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnColorStepChanged(EventArgs e)
    {
      EventHandler handler;

      this.RefreshWheel();

      handler = (EventHandler)this.Events[_eventColorStepChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="DisplayLightnessChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnDisplayLightnessChanged(EventArgs e)
    {
      EventHandler handler;

      this.RefreshWheel();

      handler = (EventHandler)this.Events[_eventDisplayLightnessChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.GotFocus" /> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
    protected override void OnGotFocus(EventArgs e)
    {
      base.OnGotFocus(e);

      this.Invalidate();
    }

    /// <summary>
    /// Raises the <see cref="HslColorChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnHslColorChanged(EventArgs e)
    {
      EventHandler handler;

      if (!_lockUpdates)
      {
        this.SetRgbColor(_hslColor);
      }

      this.Invalidate();

      handler = (EventHandler)this.Events[_eventHslColorChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.KeyDown" /> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs" /> that contains the event data.</param>
    protected override void OnKeyDown(KeyEventArgs e)
    {
      HslColor color;
      double hue;
      int step;

      color = _hslColor;
      hue = color.H;

      step = e.Shift ? _largeChange : _smallChange;

      switch (e.KeyCode)
      {
        case Keys.Right:
        case Keys.Up:
          hue += step;
          break;

        case Keys.Left:
        case Keys.Down:
          hue -= step;
          break;

        case Keys.PageUp:
          hue += _largeChange;
          break;

        case Keys.PageDown:
          hue -= _largeChange;
          break;
      }

      if (hue >= 360)
      {
        hue = 0;
      }

      if (hue < 0)
      {
        hue = 359;
      }

      if (Math.Abs(hue - color.H) > double.Epsilon)
      {
        color.H = hue;

        // As the Color and HslColor properties update each other, need to temporarily disable this and manually set both
        // otherwise the wheel "sticks" due to imprecise conversion from RGB to HSL
        _lockUpdates = true;
        this.SetRgbColor(color);
        this.HslColor = color;
        _lockUpdates = false;

        e.Handled = true;
      }

      base.OnKeyDown(e);
    }

    /// <summary>
    /// Raises the <see cref="LargeChangeChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnLargeChangeChanged(EventArgs e)
    {
      EventHandler handler;

      handler = (EventHandler)this.Events[_eventLargeChangeChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="LightnessChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnLightnessChanged(EventArgs e)
    {
      EventHandler handler;

      if (_displayLightness)
      {
        this.RefreshWheel();
      }

      handler = (EventHandler)this.Events[_eventLightnessChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="LineColorChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnLineColorChanged(EventArgs e)
    {
      EventHandler handler;

      this.Invalidate();

      handler = (EventHandler)this.Events[_eventLineColorChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.LostFocus" /> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
    protected override void OnLostFocus(EventArgs e)
    {
      base.OnLostFocus(e);

      this.Invalidate();
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
    protected override void OnMouseDown(MouseEventArgs e)
    {
      base.OnMouseDown(e);

      if (!this.Focused && this.TabStop)
      {
        this.Focus();
      }

      if (e.Button == MouseButtons.Left && this.IsPointInWheel(e.Location))
      {
        _isDragging = true;
        this.SetColor(e.Location);
      }
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);

      if (_isDragging)
      {
        this.SetColor(e.Location);
      }
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp"/> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event data. </param>
    protected override void OnMouseUp(MouseEventArgs e)
    {
      base.OnMouseUp(e);

      _isDragging = false;
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.PaddingChanged" /> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.EventArgs" /> that contains the event data.</param>
    protected override void OnPaddingChanged(EventArgs e)
    {
      base.OnPaddingChanged(e);

      this.RefreshWheel();
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      if (this.AllowPainting)
      {
        Control parent;

        this.OnPaintBackground(e); // HACK: Easiest way of supporting things like BackgroundImage, BackgroundImageLayout etc

        // if the parent is using a transparent color, it's likely to be something like a TabPage in a tab control
        // so we'll draw the parent background instead, to avoid having an ugly solid color
        parent = this.Parent;
        if (this.BackgroundImage == null && parent != null && (this.BackColor == parent.BackColor || parent.BackColor.A != 255))
        {
          ButtonRenderer.DrawParentBackground(e.Graphics, this.DisplayRectangle, this);
        }

        if (_brush != null)
        {
          e.Graphics.FillPie(_brush, this.ClientRectangle, 0, 360);
        }

        // HACK: smooth out the edge of the wheel.
        // https://github.com/cyotek/Cyotek.Windows.Forms.ColorPicker/issues/1 - the linked source doesn't do this hack yet draws with a smoother edge
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        using (Pen pen = new Pen(this.BackColor, 2))
        {
          e.Graphics.DrawEllipse(pen, new RectangleF(_centerPoint.X - _radius, _centerPoint.Y - _radius, _radius * 2, _radius * 2));
        }

        if (!_color.IsEmpty)
        {
          this.PaintSaturationRing(e);
          this.PaintCenterLine(e);
          this.PaintCurrentColor(e);
        }
      }
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);

      this.RefreshWheel();
    }

    /// <summary>
    /// Raises the <see cref="SelectionSizeChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnSelectionSizeChanged(EventArgs e)
    {
      EventHandler handler;

      this.DisposeOfSelectionGlyph();

      this.RefreshWheel();

      handler = (EventHandler)this.Events[_eventSelectionSizeChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ShowCenterLinesChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnShowCenterLinesChanged(EventArgs e)
    {
      EventHandler handler;

      this.Invalidate();

      handler = (EventHandler)this.Events[_eventShowCenterLinesChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ShowSaturationRingChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnShowSaturationRingChanged(EventArgs e)
    {
      EventHandler handler;

      this.Invalidate();

      handler = (EventHandler)this.Events[_eventShowSaturationRingChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="SmallChangeChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnSmallChangeChanged(EventArgs e)
    {
      EventHandler handler;

      handler = (EventHandler)this.Events[_eventSmallChangeChanged];

      handler?.Invoke(this, e);
    }

    protected void PaintColor(PaintEventArgs e, HslColor color)
    {
      this.PaintColor(e, color, false);
    }

    protected virtual void PaintColor(PaintEventArgs e, HslColor color, bool includeFocus)
    {
      PointF location;

      location = this.GetColorLocation(color);

      if (!float.IsNaN(location.X) && !float.IsNaN(location.Y))
      {
        int x;
        int y;

        x = (int)location.X - _selectionSize / 2;
        y = (int)location.Y - _selectionSize / 2;

        if (_selectionGlyph == null)
        {
          using (Brush brush = new SolidBrush(_hslColor.ToRgbColor()))
          {
            e.Graphics.FillEllipse(brush, x, y, _selectionSize, _selectionSize);
          }

          e.Graphics.DrawEllipse(_linePen, x, y, _selectionSize, _selectionSize);
        }
        else
        {
          e.Graphics.DrawImage(_selectionGlyph, x, y);
        }

        if (this.Focused && includeFocus)
        {
          NativeMethods.DrawFocusRectangle(e.Graphics, new Rectangle(x - 2, y - 2, _selectionSize + 5, _selectionSize + 5));
        }
      }
    }

    protected virtual void PaintCurrentColor(PaintEventArgs e)
    {
      this.PaintColor(e, _hslColor, true);
    }

    protected virtual void SetColor(Point point)
    {
      double dx;
      double dy;
      double angle;
      double distance;
      double saturation;
      Padding padding;
      HslColor newColor;

      padding = this.Padding;
      dx = Math.Abs(point.X - _centerPoint.X - padding.Left);
      dy = Math.Abs(point.Y - _centerPoint.Y - padding.Top);
      angle = Math.Atan(dy / dx) / Math.PI * 180;
      distance = Math.Pow(Math.Pow(dx, 2) + Math.Pow(dy, 2), 0.5);
      saturation = distance / _radius;

      if (point.X < _centerPoint.X)
      {
        angle = 180 - angle;
      }

      if (point.Y > _centerPoint.Y)
      {
        angle = 360 - angle;
      }

      newColor = new HslColor(angle, saturation, _lightness);

      if (_hslColor != newColor)
      {
        _lockUpdates = true;
        this.HslColor = newColor;
        this.SetRgbColor(_hslColor);
        _lockUpdates = false;
      }
    }

    #endregion Protected Methods

    #region Private Methods

    private void CreateLinePen()
    {
      _linePen?.Dispose();

      _linePen = new Pen(_lineColor);
    }

    private void DisposeOfSelectionGlyph()
    {
      if (_selectionGlyph != null)
      {
        _selectionGlyph.Dispose();
        _selectionGlyph = null;
      }
    }

    private void DisposeOfWheelBrush()
    {
      if (_brush != null)
      {
        _brush.Dispose();
        _brush = null;
      }
    }

    private void PaintCenterLine(PaintEventArgs e, HslColor color)
    {
      e.Graphics.DrawLine(_linePen, _centerPoint, this.GetColorLocation(color));
    }

    private void PaintCenterLine(PaintEventArgs e)
    {
      if (_showCenterLines)
      {
        this.PaintCenterLine(e, _hslColor);
      }
    }

    private void PaintSaturationRing(PaintEventArgs e)
    {
      if (_showSaturationRing)
      {
        float radius;

        radius = (float)(_radius * _hslColor.S);

        using (Pen pen = new Pen(new HslColor(0, 0, _hslColor.S).ToRgbColor()))
        {
          e.Graphics.DrawEllipse(pen, new RectangleF(_centerPoint.X - radius, _centerPoint.Y - radius, radius * 2, radius * 2));
        }
      }
    }

    /// <summary>
    /// Refreshes the wheel attributes and then repaints the control
    /// </summary>
    private void RefreshWheel()
    {
      this.CalculateWheel();

      this.DisposeOfWheelBrush();
      _brush = this.CreateGradientBrush();

      if (_selectionGlyph == null)
      {
        _selectionGlyph = this.CreateSelectionGlyph();
      }

      this.Invalidate();
    }

    private void SetRgbColor(HslColor hslColor)
    {
      this.Color = hslColor.ToRgbColor(Convert.ToInt32(_alpha * 255));
    }

    #endregion Private Methods
  }
}
