using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
#if USEEXTERNALCYOTEKLIBS
using HslColor = Cyotek.Drawing.HslColor;
#endif

namespace Cyotek.Windows.Forms
{
  // Cyotek Color Picker controls library
  // Copyright © 2013 Cyotek. All Rights Reserved.
  // http://cyotek.com/blog/tag/colorpicker

  // If you use this code in your applications, donations or attribution is welcome

  [DefaultProperty("Color")]
  [DefaultEvent("ColorChanged")]
  public class ColorWheel : Control, IColorEditor
  {
    #region Instance Fields

    private Brush _brush;

    private PointF _centerPoint;

    private Color _color;

    private int _colorStep;

    private HslColor _hslColor;

    private int _largeChange;

    private int _selectionSize;

    private int _smallChange;

    private int _updateCount;

    #endregion

    #region Constructors

    public ColorWheel()
    {
      this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.Selectable | ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, true);
      this.UpdateStyles();
      this.Color = Color.Black;
      this.ColorStep = 4;
      this.SelectionSize = 10;
      this.SmallChange = 1;
      this.LargeChange = 5;
      this.SelectionGlyph = this.CreateSelectionGlyph();
    }

    #endregion

    #region Events

    /// <summary>
    /// Occurs when the Color property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler ColorChanged;

    /// <summary>
    /// Occurs when the ColorStep property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler ColorStepChanged;

    /// <summary>
    /// Occurs when the HslColor property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler HslColorChanged;

    /// <summary>
    /// Occurs when the LargeChange property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler LargeChangeChanged;

    /// <summary>
    /// Occurs when the SelectionSize property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler SelectionSizeChanged;

    /// <summary>
    /// Occurs when the SmallChange property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler SmallChangeChanged;

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
      if (disposing)
      {
        if (_brush != null)
          _brush.Dispose();

        if (this.SelectionGlyph != null)
          this.SelectionGlyph.Dispose();
      }

      base.Dispose(disposing);
    }

    protected override bool IsInputKey(Keys keyData)
    {
      bool result;

      if ((keyData & Keys.Left) == Keys.Left || (keyData & Keys.Up) == Keys.Up || (keyData & Keys.Down) == Keys.Down || (keyData & Keys.Right) == Keys.Right || (keyData & Keys.PageUp) == Keys.PageUp || (keyData & Keys.PageDown) == Keys.PageDown)
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
      HslColor color;
      double hue;
      int step;

      color = this.HslColor;
      hue = color.H;

      step = e.Shift ? this.LargeChange : this.SmallChange;

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
          hue += this.LargeChange;
          break;
        case Keys.PageDown:
          hue -= this.LargeChange;
          break;
      }

      if (hue >= 360)
        hue = 0;
      if (hue < 0)
        hue = 359;

      if (hue != color.H)
      {
        color.H = hue;

        // As the Color and HslColor properties update each other, need to temporarily disable this and manually set both
        // otherwise the wheel "sticks" due to imprecise conversion from RGB to HSL
        this.LockUpdates = true;
        this.Color = color.ToRgbColor();
        this.HslColor = color;
        this.LockUpdates = false;

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
        this.SetColor(e.Location);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);

      if (e.Button == MouseButtons.Left)
        this.SetColor(e.Location);
    }

    protected override void OnPaddingChanged(EventArgs e)
    {
      base.OnPaddingChanged(e);

      this.RefreshWheel();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      if (this.AllowPainting)
      {
        base.OnPaintBackground(e); // HACK: Easiest way of supporting things like BackgroundImage, BackgroundImageLayout etc

        if (_brush != null)
          e.Graphics.FillPie(_brush, this.ClientRectangle, 0, 360);

        this.PaintCurrentColor(e);
      }
    }

    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);

      this.RefreshWheel();
    }

    #endregion

    #region Properties

    [Category("Appearance")]
    [DefaultValue(typeof(Color), "Black")]
    public virtual Color Color
    {
      get { return _color; }
      set
      {
        if (this.Color != value)
        {
          _color = value;

          this.OnColorChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(4)]
    public virtual int ColorStep
    {
      get { return _colorStep; }
      set
      {
        if (value < 1 || value > 359)
          throw new IndexOutOfRangeException("Value must be between 1 and 359");

        if (this.ColorStep != value)
        {
          _colorStep = value;

          this.OnColorStepChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(typeof(HslColor), "0, 0, 0")]
    [Browsable(false) /* disable editing until I write a proper type convertor */]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual HslColor HslColor
    {
      get { return _hslColor; }
      set
      {
        if (this.HslColor != value)
        {
          _hslColor = value;

          this.OnHslColorChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Behavior")]
    [DefaultValue(5)]
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

    [Category("Appearance")]
    [DefaultValue(10)]
    public virtual int SelectionSize
    {
      get { return _selectionSize; }
      set
      {
        if (this.SelectionSize != value)
        {
          _selectionSize = value;

          this.OnSelectionSizeChanged(EventArgs.Empty);
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

    /// <summary>
    ///   Gets a value indicating whether painting of the control is allowed.
    /// </summary>
    /// <value>
    ///   <c>true</c> if painting of the control is allowed; otherwise, <c>false</c>.
    /// </value>
    protected virtual bool AllowPainting
    {
      get { return _updateCount == 0; }
    }

    protected Color[] Colors { get; set; }

    protected bool LockUpdates { get; set; }

    protected PointF[] Points { get; set; }

    protected Image SelectionGlyph { get; set; }

    #endregion

    #region Members

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
        _updateCount--;

      if (this.AllowPainting)
        this.Invalidate();
    }

    protected virtual void CalculateWheel()
    {
      List<PointF> points;
      List<Color> colors;

      points = new List<PointF>();
      colors = new List<Color>();

      // Only define the points if the control is above a minimum size, otherwise if it's too small, you get an "out of memory" exceptions (of all things) when creating the brush
      if (this.ClientSize.Width > 16 && this.ClientSize.Height > 16)
      {
        double radius;
        int w;
        int h;

        w = this.ClientSize.Width;
        h = this.ClientSize.Height;

        _centerPoint = new PointF(w / 2.0F, h / 2.0F);
        radius = this.GetRadius(_centerPoint);

        for (double angle = 0; angle < 360; angle += this.ColorStep)
        {
          double angleR;
          PointF location;

          angleR = angle * (Math.PI / 180);
          location = this.GetColorLocation(angleR, radius);

          points.Add(location);
          colors.Add(new HslColor(angle, 1, 0.5).ToRgbColor());
        }
      }

      this.Points = points.ToArray();
      this.Colors = colors.ToArray();
    }

    protected virtual Brush CreateGradientBrush()
    {
      Brush result;

      if (this.Points.Length != 0 && this.Points.Length == this.Colors.Length)
      {
        result = new PathGradientBrush(this.Points, WrapMode.Clamp)
        {
          CenterPoint = _centerPoint,
          CenterColor = Color.White,
          SurroundColors = this.Colors
        };
      }
      else
        result = null;

      return result;
    }

    protected virtual Image CreateSelectionGlyph()
    {
      Image image;
      int halfSize;

      halfSize = this.SelectionSize / 2;
      image = new Bitmap(this.SelectionSize + 1, this.SelectionSize + 1, PixelFormat.Format32bppArgb);

      using (Graphics g = Graphics.FromImage(image))
      {
        Point[] diamondOuter;

        diamondOuter = new[]
        {
          new Point(halfSize, 0), new Point(this.SelectionSize, halfSize), new Point(halfSize, this.SelectionSize), new Point(0, halfSize)
        };

        g.FillPolygon(SystemBrushes.Control, diamondOuter);
        g.DrawPolygon(SystemPens.ControlDark, diamondOuter);

        using (Pen pen = new Pen(Color.FromArgb(128, SystemColors.ControlDark)))
        {
          g.DrawLine(pen, halfSize, 1, this.SelectionSize - 1, halfSize);
          g.DrawLine(pen, halfSize, 2, this.SelectionSize - 2, halfSize);
          g.DrawLine(pen, halfSize, this.SelectionSize - 1, this.SelectionSize - 2, halfSize + 1);
          g.DrawLine(pen, halfSize, this.SelectionSize - 2, this.SelectionSize - 3, halfSize + 1);
        }

        using (Pen pen = new Pen(Color.FromArgb(196, SystemColors.ControlLightLight)))
          g.DrawLine(pen, halfSize, this.SelectionSize - 1, 1, halfSize);

        g.DrawLine(SystemPens.ControlLightLight, 1, halfSize, halfSize, 1);
      }

      return image;
    }

    protected PointF GetColorLocation(Color color)
    {
      return this.GetColorLocation(new HslColor(color));
    }

    protected virtual PointF GetColorLocation(HslColor color)
    {
      double angleR = color.H * Math.PI / 180;
      double radius = this.GetRadius(_centerPoint);
      radius *= color.S;

      return this.GetColorLocation(angleR, radius);
    }

    protected PointF GetColorLocation(double angleR, double radius)
    {
      double x;
      double y;

      x = this.Padding.Left + _centerPoint.X + Math.Cos(angleR) * radius;
      y = this.Padding.Top + _centerPoint.Y - Math.Sin(angleR) * radius;

      return new PointF((float)x, (float)y);
    }

    protected float GetRadius(PointF centerPoint)
    {
      return Math.Min(centerPoint.X, centerPoint.Y) - (Math.Max(this.Padding.Horizontal, this.Padding.Vertical) + (this.SelectionSize / 2));
    }

    /// <summary>
    /// Raises the <see cref="ColorChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnColorChanged(EventArgs e)
    {
      EventHandler handler;

      if (!this.LockUpdates)
        this.HslColor = new HslColor(this.Color);
      this.Refresh();

      handler = this.ColorChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ColorStepChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnColorStepChanged(EventArgs e)
    {
      EventHandler handler;

      this.RefreshWheel();

      handler = this.ColorStepChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="HslColorChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnHslColorChanged(EventArgs e)
    {
      EventHandler handler;

      if (!this.LockUpdates)
        this.Color = this.HslColor.ToRgbColor();
      this.Invalidate();

      handler = this.HslColorChanged;

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
    /// Raises the <see cref="SelectionSizeChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnSelectionSizeChanged(EventArgs e)
    {
      EventHandler handler;

      if (this.SelectionGlyph != null)
        this.SelectionGlyph.Dispose();

      this.SelectionGlyph = this.CreateSelectionGlyph();
      this.Invalidate();

      handler = this.SelectionSizeChanged;

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

    protected virtual void PaintCurrentColor(PaintEventArgs e)
    {
      if (!this.Color.IsEmpty)
      {
        PointF location;

        location = this.GetColorLocation(this.HslColor);

        if (!float.IsNaN(location.X) && !float.IsNaN(location.Y))
        {
          int x;
          int y;

          x = (int)location.X - (this.SelectionSize / 2);
          y = (int)location.Y - (this.SelectionSize / 2);

          if (this.SelectionGlyph == null)
            e.Graphics.DrawRectangle(Pens.Black, x, y, this.SelectionSize, this.SelectionSize);
          else
            e.Graphics.DrawImage(this.SelectionGlyph, x, y);

          if (this.Focused)
            ControlPaint.DrawFocusRectangle(e.Graphics, new Rectangle(x - 1, y - 1, this.SelectionSize + 2, this.SelectionSize + 2));
        }
      }
    }

    protected virtual void SetColor(Point point)
    {
      double radius;
      double dx;
      double dy;
      double angle;
      double distance;
      double saturation;

      radius = this.GetRadius(_centerPoint);
      dx = Math.Abs(point.X - _centerPoint.X - this.Padding.Left);
      dy = Math.Abs(point.Y - _centerPoint.Y - this.Padding.Top);
      angle = Math.Atan(dy / dx) / Math.PI * 180;
      distance = Math.Pow((Math.Pow(dx, 2) + (Math.Pow(dy, 2))), 0.5);
      saturation = distance / radius;

      if (distance < 6)
        saturation = 0; // snap to center

      if (point.X < _centerPoint.X)
        angle = 180 - angle;
      if (point.Y > _centerPoint.Y)
        angle = 360 - angle;

      this.LockUpdates = true;
      this.HslColor = new HslColor(angle, saturation, 0.5);
      this.Color = this.HslColor.ToRgbColor();
      this.LockUpdates = false;
    }

    private void RefreshWheel()
    {
      if (_brush != null)
        _brush.Dispose();

      this.CalculateWheel();
      _brush = this.CreateGradientBrush();
      this.Invalidate();
    }

    #endregion
  }
}
