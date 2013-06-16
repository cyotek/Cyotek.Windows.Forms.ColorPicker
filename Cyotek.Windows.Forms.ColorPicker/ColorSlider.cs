#if USEEXTERNALCYOTEKLIBS
using Cyotek.Win32;
#else
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using NativeConstants = Cyotek.Windows.Forms.NativeMethods;

#endif

namespace Cyotek.Windows.Forms
{
  // Cyotek Color Picker controls library
  // Copyright © 2013 Cyotek. All Rights Reserved.
  // http://cyotek.com/blog/tag/colorpicker

  // If you use this code in your applications, donations or attribution is welcome

  [DefaultValue("Value")]
  [DefaultEvent("ValueChanged")]
  [ToolboxItem(false)]
  public class ColorSlider : Control
  {
    #region Instance Fields

    private Rectangle _barBounds;

    private Padding _barPadding;

    private ColorBarStyle _barStyle;

    private Color _color1;

    private Color _color2;

    private Color _color3;

    private ColorCollection _customColors;

    private int _largeChange;

    private float _maximum;

    private float _minimum;

    private Color _nubColor;

    private Size _nubSize;

    private ColorSliderNubStyle _nubStyle;

    private Orientation _orientation;

    private bool _showValueDivider;

    private int _smallChange;

    private float _value;

    #endregion

    #region Constructors

    public ColorSlider()
    {
      this.SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.Selectable, true);
      this.UpdateStyles();
      this.Orientation = Orientation.Horizontal;
      this.Color1 = Color.Black;
      this.Color2 = Color.FromArgb(127, 127, 127);
      this.Color3 = Color.White;
      this.Minimum = 0;
      this.Maximum = 100;
      this.NubStyle = ColorSliderNubStyle.BottomRight;
      this.NubSize = new Size(8, 8);
      this.NubColor = Color.Black;
      this.SmallChange = 1;
      this.LargeChange = 10;
    }

    #endregion

    #region Events

    /// <summary>
    /// Occurs when the BarBounds property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler BarBoundsChanged;

    /// <summary>
    /// Occurs when the BarPadding property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler BarPaddingChanged;

    /// <summary>
    /// Occurs when the Style property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler BarStyleChanged;

    /// <summary>
    /// Occurs when the Color1 property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler Color1Changed;

    /// <summary>
    /// Occurs when the Color2 property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler Color2Changed;

    /// <summary>
    /// Occurs when the Color3 property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler Color3Changed;

    /// <summary>
    /// Occurs when the CustomColors property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler CustomColorsChanged;

    /// <summary>
    /// Occurs when the LargeChange property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler LargeChangeChanged;

    /// <summary>
    /// Occurs when the Maximum property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler MaximumChanged;

    /// <summary>
    /// Occurs when the Minimum property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler MinimumChanged;

    /// <summary>
    /// Occurs when the NubColor property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler NubColorChanged;

    /// <summary>
    /// Occurs when the NubSize property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler NubSizeChanged;

    /// <summary>
    /// Occurs when the NubStyle property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler NubStyleChanged;

    /// <summary>
    /// Occurs when the Orientation property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler OrientationChanged;

    /// <summary>
    /// Occurs when the ShowValueDivider property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler ShowValueDividerChanged;

    /// <summary>
    /// Occurs when the SliderStyle property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler SliderStyleChanged;

    /// <summary>
    /// Occurs when the SmallChange property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler SmallChangeChanged;

    /// <summary>
    /// Occurs when the Percent property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler ValueChanged;

    #endregion

    #region Overridden Properties

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Font Font
    {
      get { return base.Font; }
      set { base.Font = value; }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Color ForeColor
    {
      get { return base.ForeColor; }
      set { base.ForeColor = value; }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override string Text
    {
      get { return base.Text; }
      set { base.Text = value; }
    }

    #endregion

    #region Overridden Members

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.SelectionGlyph != null)
        this.SelectionGlyph.Dispose();

      base.Dispose(disposing);
    }

    protected override bool IsInputKey(Keys keyData)
    {
      bool result;

      if ((keyData & Keys.Left) == Keys.Left || (keyData & Keys.Up) == Keys.Up || (keyData & Keys.Down) == Keys.Down || (keyData & Keys.Right) == Keys.Right || (keyData & Keys.PageUp) == Keys.PageUp || (keyData & Keys.PageDown) == Keys.PageDown || (keyData & Keys.Home) == Keys.Home || (keyData & Keys.End) == Keys.End)
        result = true;
      else
        result = base.IsInputKey(keyData);

      return result;
    }

    protected override void OnGotFocus(EventArgs e)
    {
      base.OnGotFocus(e);

      this.Invalidate();
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
      int step;
      float value;

      step = e.Shift ? this.LargeChange : this.SmallChange;
      value = this.Value;

      switch (e.KeyCode)
      {
        case Keys.Right:
        case Keys.Down:
          value += step;
          break;
        case Keys.Left:
        case Keys.Up:
          value -= step;
          break;
        case Keys.PageDown:
          value += this.LargeChange;
          break;
        case Keys.PageUp:
          value -= this.LargeChange;
          break;
        case Keys.Home:
          value = this.Minimum;
          break;
        case Keys.End:
          value = this.Maximum;
          break;
      }

      if (value < this.Minimum)
        value = this.Minimum;

      if (value > this.Maximum)
        value = this.Maximum;

      if (value != this.Value)
      {
        this.Value = value;

        e.Handled = true;
      }

      base.OnKeyDown(e);
    }

    protected override void OnLostFocus(EventArgs e)
    {
      base.OnLostFocus(e);

      this.Invalidate();
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      base.OnMouseDown(e);

      if (!this.Focused && this.TabStop)
        this.Focus();

      if (e.Button == MouseButtons.Left)
        PointToValue(e.Location);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);

      if (e.Button == MouseButtons.Left)
        PointToValue(e.Location);
    }

    protected override void OnPaddingChanged(EventArgs e)
    {
      base.OnPaddingChanged(e);

      this.DefineBar();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      this.PaintBar(e);
      this.PaintAdornments(e);
    }

    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);

      this.DefineBar();
    }

    #endregion

    #region Properties

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual Rectangle BarBounds
    {
      get { return _barBounds; }
      protected set
      {
        if (this.BarBounds != value)
        {
          _barBounds = value;

          this.OnBarBoundsChanged(EventArgs.Empty);
        }
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual Padding BarPadding
    {
      get { return _barPadding; }
      protected set
      {
        if (this.BarPadding != value)
        {
          _barPadding = value;

          this.OnBarPaddingChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(typeof(ColorBarStyle), "TwoColor")]
    public virtual ColorBarStyle BarStyle
    {
      get { return _barStyle; }
      set
      {
        if (this.BarStyle != value)
        {
          _barStyle = value;

          this.OnBarStyleChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(typeof(Color), "Black")]
    public virtual Color Color1
    {
      get { return _color1; }
      set
      {
        if (this.Color1 != value)
        {
          _color1 = value;

          this.OnColor1Changed(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(typeof(Color), "127, 127, 127")]
    public virtual Color Color2
    {
      get { return _color2; }
      set
      {
        if (this.Color2 != value)
        {
          _color2 = value;

          this.OnColor2Changed(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(typeof(Color), "White")]
    public virtual Color Color3
    {
      get { return _color3; }
      set
      {
        if (this.Color3 != value)
        {
          _color3 = value;

          this.OnColor3Changed(EventArgs.Empty);
        }
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual ColorCollection CustomColors
    {
      get { return _customColors; }
      set
      {
        if (this.CustomColors != value)
        {
          _customColors = value;

          this.OnCustomColorsChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Behavior")]
    [DefaultValue(10)]
    public virtual int LargeChange
    {
      get { return _largeChange; }
      set
      {
        if (this.LargeChange != value)
        {
          _largeChange = value;

          this.OnLargeChangeChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Behavior")]
    [DefaultValue(100F)]
    public virtual float Maximum
    {
      get { return _maximum; }
      set
      {
        // ReSharper disable CompareOfFloatsByEqualityOperator
        if (this.Maximum != value)
          // ReSharper restore CompareOfFloatsByEqualityOperator
        {
          _maximum = value;

          this.OnMaximumChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Behavior")]
    [DefaultValue(0F)]
    public virtual float Minimum
    {
      get { return _minimum; }
      set
      {
        // ReSharper disable CompareOfFloatsByEqualityOperator
        if (this.Minimum != value)
          // ReSharper restore CompareOfFloatsByEqualityOperator
        {
          _minimum = value;

          this.OnMinimumChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(typeof(Color), "Black")]
    public virtual Color NubColor
    {
      get { return _nubColor; }
      set
      {
        if (this.NubColor != value)
        {
          _nubColor = value;

          this.OnNubColorChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(typeof(Size), "8, 8")]
    public virtual Size NubSize
    {
      get { return _nubSize; }
      set
      {
        if (this.NubSize != value)
        {
          _nubSize = value;

          this.OnNubSizeChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(typeof(ColorSliderNubStyle), "BottomRight")]
    public virtual ColorSliderNubStyle NubStyle
    {
      get { return _nubStyle; }
      set
      {
        if (this.NubStyle != value)
        {
          _nubStyle = value;

          this.OnNubStyleChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(typeof(Orientation), "Horizontal")]
    public virtual Orientation Orientation
    {
      get { return _orientation; }
      set
      {
        if (this.Orientation != value)
        {
          _orientation = value;

          this.OnOrientationChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(false)]
    public virtual bool ShowValueDivider
    {
      get { return _showValueDivider; }
      set
      {
        if (this.ShowValueDivider != value)
        {
          _showValueDivider = value;

          this.OnShowValueDividerChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Behavior")]
    [DefaultValue(1)]
    public virtual int SmallChange
    {
      get { return _smallChange; }
      set
      {
        if (this.SmallChange != value)
        {
          _smallChange = value;

          this.OnSmallChangeChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(0F)]
    public virtual float Value
    {
      get { return _value; }
      set
      {
        if (value < this.Minimum)
          value = this.Minimum;
        if (value > this.Maximum)
          value = this.Maximum;

        // ReSharper disable CompareOfFloatsByEqualityOperator
        if (this.Value != value)
          // ReSharper restore CompareOfFloatsByEqualityOperator
        {
          _value = value;

          this.OnValueChanged(EventArgs.Empty);
        }
      }
    }

    protected Image SelectionGlyph { get; set; }

    #endregion

    #region Members

    protected virtual Image CreateNubGlyph()
    {
      Image image;

      image = new Bitmap(this.NubSize.Width + 1, this.NubSize.Height + 1, PixelFormat.Format32bppArgb);

      using (Graphics g = Graphics.FromImage(image))
      {
        Point[] outer;
        Point firstCorner;
        Point lastCorner;
        Point tipCorner;

        if (this.NubStyle == ColorSliderNubStyle.BottomRight)
        {
          lastCorner = new Point(this.NubSize.Width, this.NubSize.Height);

          if (this.Orientation == Orientation.Horizontal)
          {
            firstCorner = new Point(0, this.NubSize.Height);
            tipCorner = new Point(this.NubSize.Width / 2, 0);
          }
          else
          {
            firstCorner = new Point(this.NubSize.Width, 0);
            tipCorner = new Point(0, this.NubSize.Height / 2);
          }
        }
        else
        {
          firstCorner = Point.Empty;

          if (this.Orientation == Orientation.Horizontal)
          {
            lastCorner = new Point(this.NubSize.Width, 0);
            tipCorner = new Point(this.NubSize.Width / 2, this.NubSize.Height);
          }
          else
          {
            lastCorner = new Point(0, this.NubSize.Height);
            tipCorner = new Point(this.NubSize.Width, this.NubSize.Height / 2);
          }
        }

        // draw the shape
        outer = new[]
        {
          firstCorner, lastCorner, tipCorner
        };

        // TODO: Add 3D edging similar to the mousewheel's diamond

        g.SmoothingMode = SmoothingMode.AntiAlias;

        using (Brush brush = new SolidBrush(this.NubColor))
          g.FillPolygon(brush, outer);
      }

      return image;
    }

    protected virtual void DefineBar()
    {
      if (this.SelectionGlyph != null)
        this.SelectionGlyph.Dispose();

      this.BarPadding = this.GetBarPadding();
      this.BarBounds = this.GetBarBounds();
      this.SelectionGlyph = this.NubStyle != ColorSliderNubStyle.None ? this.CreateNubGlyph() : null;
    }

    protected virtual Rectangle GetBarBounds()
    {
      Rectangle clientRectangle;
      Padding padding;

      clientRectangle = this.ClientRectangle;
      padding = this.BarPadding + this.Padding;

      return new Rectangle(clientRectangle.Left + padding.Left, clientRectangle.Top + padding.Top, clientRectangle.Width - padding.Horizontal, clientRectangle.Height - padding.Vertical);
    }

    protected virtual Padding GetBarPadding()
    {
      int left;
      int top;
      int right;
      int bottom;

      left = 0;
      top = 0;
      right = 0;
      bottom = 0;

      switch (this.NubStyle)
      {
        case ColorSliderNubStyle.BottomRight:
          if (this.Orientation == Orientation.Horizontal)
          {
            bottom = this.NubSize.Height + 1;
            left = (this.NubSize.Width / 2) + 1;
            right = left;
          }
          else
          {
            right = this.NubSize.Width + 1;
            top = (this.NubSize.Height / 2) + 1;
            bottom = top;
          }
          break;
        case ColorSliderNubStyle.TopLeft:
          if (this.Orientation == Orientation.Horizontal)
          {
            top = this.NubSize.Height + 1;
            left = (this.NubSize.Width / 2) + 1;
            right = left;
          }
          else
          {
            left = this.NubSize.Width + 1;
            top = (this.NubSize.Height / 2) + 1;
            bottom = top;
          }
          break;
      }

      return new Padding(left, top, right, bottom);
    }

    /// <summary>
    /// Raises the <see cref="BarBoundsChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnBarBoundsChanged(EventArgs e)
    {
      EventHandler handler;

      handler = this.BarBoundsChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="BarPaddingChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnBarPaddingChanged(EventArgs e)
    {
      EventHandler handler;

      this.Invalidate();

      handler = this.BarPaddingChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="BarStyleChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnBarStyleChanged(EventArgs e)
    {
      EventHandler handler;

      this.Invalidate();

      handler = this.BarStyleChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="Color1Changed" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnColor1Changed(EventArgs e)
    {
      EventHandler handler;

      this.Invalidate();

      handler = this.Color1Changed;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="Color2Changed" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnColor2Changed(EventArgs e)
    {
      EventHandler handler;

      this.Invalidate();

      handler = this.Color2Changed;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="Color3Changed" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnColor3Changed(EventArgs e)
    {
      EventHandler handler;

      this.Invalidate();

      handler = this.Color3Changed;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="CustomColorsChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnCustomColorsChanged(EventArgs e)
    {
      EventHandler handler;

      this.Invalidate();

      handler = this.CustomColorsChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="LargeChangeChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnLargeChangeChanged(EventArgs e)
    {
      EventHandler handler;

      handler = this.LargeChangeChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="MaximumChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnMaximumChanged(EventArgs e)
    {
      EventHandler handler;

      handler = this.MaximumChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="MinimumChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnMinimumChanged(EventArgs e)
    {
      EventHandler handler;

      this.Invalidate();

      handler = this.MinimumChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="NubColorChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnNubColorChanged(EventArgs e)
    {
      EventHandler handler;

      this.Invalidate();

      handler = this.NubColorChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="NubSizeChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnNubSizeChanged(EventArgs e)
    {
      EventHandler handler;

      this.DefineBar();
      this.Invalidate();

      handler = this.NubSizeChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="NubStyleChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnNubStyleChanged(EventArgs e)
    {
      EventHandler handler;

      this.DefineBar();
      this.Invalidate();

      handler = this.NubStyleChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="OrientationChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnOrientationChanged(EventArgs e)
    {
      EventHandler handler;

      this.DefineBar();
      this.Invalidate();

      handler = this.OrientationChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ShowValueDividerChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnShowValueDividerChanged(EventArgs e)
    {
      EventHandler handler;

      this.Invalidate();

      handler = this.ShowValueDividerChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="SliderStyleChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnSliderStyleChanged(EventArgs e)
    {
      EventHandler handler;

      this.DefineBar();
      this.Invalidate();

      handler = this.SliderStyleChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="SmallChangeChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnSmallChangeChanged(EventArgs e)
    {
      EventHandler handler;

      handler = this.SmallChangeChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ValueChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnValueChanged(EventArgs e)
    {
      EventHandler handler;

      this.Refresh();

      handler = this.ValueChanged;

      if (handler != null)
        handler(this, e);
    }

    protected virtual void PaintAdornments(PaintEventArgs e)
    {
      Point point;

      point = this.ValueToPoint(this.Value);

      // divider
      if (this.ShowValueDivider)
      {
        Point start;
        Point end;
        IntPtr hdc;

        if (this.Orientation == Orientation.Horizontal)
        {
          start = new Point(point.X, this.BarBounds.Top);
          end = new Point(point.X, this.BarBounds.Bottom);
        }
        else
        {
          start = new Point(this.BarBounds.Left, point.Y);
          end = new Point(this.BarBounds.Right, point.Y);
        }

        // draw a XOR'd line using Win32 API as this functionality isn't part of .NET
        hdc = e.Graphics.GetHdc();
        NativeMethods.SetROP2(hdc, NativeConstants.R2_NOT);
        NativeMethods.MoveToEx(hdc, start.X, start.Y, IntPtr.Zero);
        NativeMethods.LineTo(hdc, end.X, end.Y);
        e.Graphics.ReleaseHdc(hdc);
      }

      // drag nub
      if (this.NubStyle != ColorSliderNubStyle.None && this.SelectionGlyph != null)
      {
        int x;
        int y;

        if (this.Orientation == Orientation.Horizontal)
        {
          x = point.X - this.NubSize.Width / 2;
          if (this.NubStyle == ColorSliderNubStyle.BottomRight)
            y = this.BarBounds.Bottom;
          else
            y = this.BarBounds.Top - this.NubSize.Height;
        }
        else
        {
          y = point.Y - this.NubSize.Height / 2;
          if (this.NubStyle == ColorSliderNubStyle.BottomRight)
            x = this.BarBounds.Right;
          else
            x = this.BarBounds.Left - this.NubSize.Width;
        }

        e.Graphics.DrawImage(this.SelectionGlyph, x, y);
      }

      // focus
      if (this.Focused)
        ControlPaint.DrawFocusRectangle(e.Graphics, Rectangle.Inflate(this.BarBounds, -2, -2));
    }

    protected virtual void PaintBar(PaintEventArgs e)
    {
      float angle;

      angle = (this.Orientation == Orientation.Horizontal) ? 0 : 270;

      if (this.BarBounds.Height > 0 && this.BarBounds.Width > 0)
      {
        ColorBlend blend;

        // HACK: Inflating the brush rectangle by 1 seems to get rid of a odd issue where the last color is drawn on the first pixel

        blend = new ColorBlend();
        using (LinearGradientBrush brush = new LinearGradientBrush(Rectangle.Inflate(this.BarBounds, 1, 1), Color.Empty, Color.Empty, angle, false))
        {
          switch (this.BarStyle)
          {
            case ColorBarStyle.TwoColor:
              blend.Colors = new[]
              {
                this.Color1, this.Color2
              };
              blend.Positions = new[]
              {
                0F, 1F
              };
              break;
            case ColorBarStyle.ThreeColor:
              blend.Colors = new[]
              {
                this.Color1, this.Color2, this.Color3
              };
              blend.Positions = new[]
              {
                0, 0.5F, 1
              };
              break;
            case ColorBarStyle.Custom:
              if (this.CustomColors != null && this.CustomColors.Count > 0)
              {
                blend.Colors = this.CustomColors.ToArray();
                blend.Positions = Enumerable.Range(0, this.CustomColors.Count).Select(i => i == 0 ? 0 : i == this.CustomColors.Count - 1 ? 1 : (float)(1.0D / this.CustomColors.Count) * i).ToArray();
              }
              else
              {
                blend.Colors = new[]
                {
                  this.Color1, this.Color2
                };
                blend.Positions = new[]
                {
                  0F, 1F
                };
              }
              break;
          }

          brush.InterpolationColors = blend;
          e.Graphics.FillRectangle(brush, this.BarBounds);
        }
      }
    }

    protected virtual void PointToValue(Point location)
    {
      float value;

      location.X += this.ClientRectangle.X - this.BarBounds.X;
      location.Y += this.ClientRectangle.Y - this.BarBounds.Y;

      switch (this.Orientation)
      {
        case Orientation.Horizontal:
          value = this.Minimum + (location.X / (float)this.BarBounds.Width * (this.Minimum + this.Maximum));
          break;
        default:
          value = this.Minimum + (location.Y / (float)this.BarBounds.Height * (this.Minimum + this.Maximum));
          break;
      }

      if (value < this.Minimum)
        value = this.Minimum;

      if (value > this.Maximum)
        value = this.Maximum;

      this.Value = value;
    }

    protected virtual Point ValueToPoint(float value)
    {
      double x;
      double y;
      Padding padding;

      padding = this.BarPadding + this.Padding;
      x = 0;
      y = 0;

      switch (this.Orientation)
      {
        case Orientation.Horizontal:
          x = (this.BarBounds.Width / this.Maximum) * value;
          break;
        default:
          y = (this.BarBounds.Height / this.Maximum) * value;
          break;
      }

      return new Point((int)x + padding.Left, (int)y + padding.Top);
    }

    #endregion
  }
}
