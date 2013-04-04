using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms
{
  // Cyotek Color Picker controls library
  // Copyright © 2013 Cyotek. All Rights Reserved.
  // http://cyotek.com/blog/tag/colorpicker

  // If you use this code in your applications, donations or attribution is welcome

  [DefaultProperty("Color")]
  [DefaultEvent("ColorChanged")]
  public class ScreenColorPicker : Control, IColorEditor
  {
    #region Instance Fields

    private Color _color;

    private Cursor _eyedropperCursor;

    private Color _gridColor;

    private Image _image;

    private bool _showGrid;

    private bool _showTextWithSnapshot;

    private int _zoom;

    #endregion

    #region Constructors

    public ScreenColorPicker()
    {
      this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
      this.SetStyle(ControlStyles.Selectable | ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, false);
      this.UpdateStyles();
      this.Zoom = 8;
      this.Color = Color.Empty;
      this.ShowTextWithSnapshot = false;
      this.TabStop = false;
      this.TabIndex = 0;
      this.ShowGrid = true;
      this.GridColor = SystemColors.ControlDark;
    }

    #endregion

    #region Events

    /// <summary>
    /// Occurs when the Color property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler ColorChanged;

    /// <summary>
    /// Occurs when the GridColor property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler GridColorChanged;

    /// <summary>
    /// Occurs when the Image property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler ImageChanged;

    /// <summary>
    /// Occurs when the ShowGrid property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler ShowGridChanged;

    /// <summary>
    /// Occurs when the ShowTextWithSnapshot property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler ShowTextWithSnapshotChanged;

    /// <summary>
    /// Occurs when the Zoom property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler ZoomChanged;

    #endregion

    #region Overridden Members

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (_eyedropperCursor != null)
          _eyedropperCursor.Dispose();

        if (SnapshotImage != null)
          SnapshotImage.Dispose();
      }

      base.Dispose(disposing);
    }

    protected override void OnFontChanged(EventArgs e)
    {
      base.OnFontChanged(e);

      this.Invalidate();
    }

    protected override void OnForeColorChanged(EventArgs e)
    {
      base.OnForeColorChanged(e);

      this.Invalidate();
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      base.OnMouseDown(e);

      if (e.Button == MouseButtons.Left && !this.IsCapturing)
      {
        if (_eyedropperCursor == null)
          // ReSharper disable AssignNullToNotNullAttribute
          _eyedropperCursor = new Cursor(this.GetType().Assembly.GetManifestResourceStream(string.Concat(this.GetType().Namespace, ".Resources.eyedropper.cur")));
        // ReSharper restore AssignNullToNotNullAttribute

        this.Cursor = _eyedropperCursor;
        this.IsCapturing = true;
        this.Invalidate();
      }
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);

      if (this.IsCapturing)
        this.UpdateSnapshot();
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
      base.OnMouseUp(e);

      if (this.IsCapturing)
      {
        this.Cursor = Cursors.Default;
        this.IsCapturing = false;
        this.Invalidate();
      }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      base.OnPaintBackground(e); // HACK: Easiest way of supporting things like BackgroundImage, BackgroundImageLayout etc

      // draw the current snapshot, if present
      if (this.SnapshotImage != null)
      {
        e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
        e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

        e.Graphics.DrawImage(this.SnapshotImage, new Rectangle(0, 0, this.SnapshotImage.Width * this.Zoom, this.SnapshotImage.Height * this.Zoom), new Rectangle(Point.Empty, this.SnapshotImage.Size), GraphicsUnit.Pixel);
      }

      this.PaintAdornments(e);
    }

    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);

      this.CreateSnapshotImage();
    }

    protected override void OnTextChanged(EventArgs e)
    {
      base.OnTextChanged(e);

      this.Invalidate();
    }

    #endregion

    #region Properties

    [Category("Behavior")]
    [DefaultValue(typeof(Color), "Empty")]
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
    [DefaultValue(typeof(Color), "ControlDark")]
    public virtual Color GridColor
    {
      get { return _gridColor; }
      set
      {
        if (this.GridColor != value)
        {
          _gridColor = value;

          this.OnGridColorChanged(EventArgs.Empty);
        }
      }
    }

    [Browsable(false)]
    public bool HasSnapshot { get; protected set; }

    [Category("Appearance")]
    [DefaultValue(typeof(Image), null)]
    public virtual Image Image
    {
      get { return _image; }
      set
      {
        if (this.Image != value)
        {
          _image = value;

          this.OnImageChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(true)]
    public virtual bool ShowGrid
    {
      get { return _showGrid; }
      set
      {
        if (this.ShowGrid != value)
        {
          _showGrid = value;

          this.OnShowGridChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(false)]
    public virtual bool ShowTextWithSnapshot
    {
      get { return _showTextWithSnapshot; }
      set
      {
        if (this.ShowTextWithSnapshot != value)
        {
          _showTextWithSnapshot = value;

          this.OnShowTextWithSnapshotChanged(EventArgs.Empty);
        }
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [DefaultValue(0)]
    public new int TabIndex
    {
      get { return base.TabIndex; }
      set { base.TabIndex = value; }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [DefaultValue(false)]
    public new bool TabStop
    {
      get { return base.TabStop; }
      set { base.TabStop = value; }
    }

    [Category("Appearance")]
    [DefaultValue(8)]
    public virtual int Zoom
    {
      get { return _zoom; }
      set
      {
        if (this.Zoom != value)
        {
          _zoom = value;

          this.OnZoomChanged(EventArgs.Empty);
        }
      }
    }

    protected bool IsCapturing { get; set; }

    protected bool LockUpdates { get; set; }

    protected Bitmap SnapshotImage { get; set; }

    #endregion

    #region Members

    protected virtual void CreateSnapshotImage()
    {
      Size size;

      if (this.SnapshotImage != null)
      {
        this.SnapshotImage.Dispose();
        this.SnapshotImage = null;
      }

      size = this.GetSnapshotSize();
      if (!size.IsEmpty)
      {
        this.SnapshotImage = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb);
        this.Invalidate();
      }
    }

    protected virtual Point GetCenterPoint()
    {
      int x;
      int y;

      x = (this.ClientSize.Width / this.Zoom) / 2;
      y = (this.ClientSize.Height / this.Zoom) / 2;

      return new Point(x, y);
    }

    protected virtual Size GetSnapshotSize()
    {
      int snapshotWidth;
      int snapshotHeight;

      snapshotWidth = (int)Math.Ceiling(this.ClientSize.Width / (double)this.Zoom);
      snapshotHeight = (int)Math.Ceiling(this.ClientSize.Height / (double)this.Zoom);

      return snapshotHeight != 0 && snapshotWidth != 0 ? new Size(snapshotWidth, snapshotHeight) : Size.Empty;
    }

    /// <summary>
    /// Raises the <see cref="ColorChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnColorChanged(EventArgs e)
    {
      EventHandler handler;

      handler = this.ColorChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="GridColorChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnGridColorChanged(EventArgs e)
    {
      EventHandler handler;

      this.Invalidate();

      handler = this.GridColorChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ImageChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnImageChanged(EventArgs e)
    {
      EventHandler handler;

      this.Invalidate();

      handler = this.ImageChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ShowGridChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnShowGridChanged(EventArgs e)
    {
      EventHandler handler;

      this.Invalidate();

      handler = this.ShowGridChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ShowTextWithSnapshotChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnShowTextWithSnapshotChanged(EventArgs e)
    {
      EventHandler handler;

      this.Invalidate();

      handler = this.ShowTextWithSnapshotChanged;

      if (handler != null)
        handler(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ZoomChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnZoomChanged(EventArgs e)
    {
      EventHandler handler;

      this.CreateSnapshotImage();

      handler = this.ZoomChanged;

      if (handler != null)
        handler(this, e);
    }

    protected virtual void PaintAdornments(PaintEventArgs e)
    {
      // grid
      if (this.ShowGrid)
        this.PaintGrid(e);

      // center marker
      if (this.HasSnapshot)
        this.PaintCenterMarker(e);

      // image
      if (this.Image != null && (!this.HasSnapshot || this.ShowTextWithSnapshot))
        e.Graphics.DrawImage(this.Image, (this.ClientSize.Width - this.Image.Size.Width) / 2, (this.ClientSize.Height - this.Image.Size.Height) / 2);

      // draw text
      if (!string.IsNullOrEmpty(this.Text) && (!this.HasSnapshot || this.ShowTextWithSnapshot))
        TextRenderer.DrawText(e.Graphics, this.Text, this.Font, this.ClientRectangle, this.ForeColor, this.BackColor, TextFormatFlags.ExpandTabs | TextFormatFlags.NoPrefix | TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter | TextFormatFlags.WordBreak | TextFormatFlags.WordEllipsis);
    }

    protected virtual void PaintCenterMarker(PaintEventArgs e)
    {
      Point center;

      center = this.GetCenterPoint();

      using (Pen pen = new Pen(this.ForeColor))
        e.Graphics.DrawRectangle(pen, center.X * this.Zoom, center.Y * this.Zoom, this.Zoom + 2, this.Zoom + 2);
    }

    protected virtual void PaintGrid(PaintEventArgs e)
    {
      Rectangle viewport;
      int pixelSize;

      pixelSize = this.Zoom;
      viewport = this.ClientRectangle;

      using (Pen pen = new Pen(this.GridColor)
      {
        DashStyle = DashStyle.Dot
      })
      {
        for (int x = viewport.Left + 1; x < viewport.Right; x += pixelSize)
          e.Graphics.DrawLine(pen, x, viewport.Top, x, viewport.Bottom);

        for (int y = viewport.Top + 1; y < viewport.Bottom; y += pixelSize)
          e.Graphics.DrawLine(pen, viewport.Left, y, viewport.Right, y);

        e.Graphics.DrawRectangle(pen, viewport);
      }
    }

    protected virtual void UpdateSnapshot()
    {
      Point cursor;

      cursor = MousePosition;
      cursor.X -= this.SnapshotImage.Width / 2;
      cursor.Y -= this.SnapshotImage.Height / 2;

      using (Graphics graphics = Graphics.FromImage(this.SnapshotImage))
      {
        Point center;

        // clear the image first, in case the mouse is near the borders of the screen so there isn't enough copy content to fill the area
        graphics.Clear(Color.Empty);

        // copy the image from the screen
        graphics.CopyFromScreen(cursor, Point.Empty, this.SnapshotImage.Size);

        // update the active color
        center = this.GetCenterPoint();
        this.Color = this.SnapshotImage.GetPixel(center.X, center.Y);

        // force a redraw
        this.HasSnapshot = true;
        this.Refresh(); // just calling Invalidate isn't enough as the display will lag
      }
    }

    #endregion
  }
}
