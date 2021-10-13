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
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms
{
  /// <summary>
  /// Represents a control that allows the selection of a color by dragging the mouse across the desktop
  /// </summary>
  [DefaultProperty("Color")]
  [DefaultEvent("ColorChanged")]
  public class ScreenColorPicker : Control, IColorEditor
  {
    #region Private Fields

    private static readonly object _eventColorChanged = new object();

    private static readonly object _eventGridColorChanged = new object();

    private static readonly object _eventImageChanged = new object();

    private static readonly object _eventShowGridChanged = new object();

    private static readonly object _eventShowTextWithSnapshotChanged = new object();

    private static readonly object _eventZoomChanged = new object();

    private Color _color;

    private Cursor _eyedropperCursor;

    private Color _gridColor;

    private bool _hasSnapshot;

    private Image _image;

    private bool _isCapturing;

    private Point _lastUpdate;

    private bool _showGrid;

    private bool _showTextWithSnapshot;

    private Bitmap _snapshotImage;

    private int _zoom;

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="ScreenColorPicker"/> class.
    /// </summary>
    public ScreenColorPicker()
    {
      this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
      this.SetStyle(ControlStyles.Selectable | ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, false);
      _zoom = 8;
      _color = Color.Empty;
      _showTextWithSnapshot = false;
      this.TabStop = false;
      this.TabIndex = 0;
      _showGrid = true;
      _gridColor = SystemColors.ControlDark;
    }

    #endregion Public Constructors

    #region Public Events

    [Category("Property Changed")]
    public event EventHandler ColorChanged
    {
      add { this.Events.AddHandler(_eventColorChanged, value); }
      remove { this.Events.RemoveHandler(_eventColorChanged, value); }
    }

    [Category("Property Changed")]
    public event EventHandler GridColorChanged
    {
      add { this.Events.AddHandler(_eventGridColorChanged, value); }
      remove { this.Events.RemoveHandler(_eventGridColorChanged, value); }
    }

    [Category("Property Changed")]
    public event EventHandler ImageChanged
    {
      add { this.Events.AddHandler(_eventImageChanged, value); }
      remove { this.Events.RemoveHandler(_eventImageChanged, value); }
    }

    [Category("Property Changed")]
    public event EventHandler ShowGridChanged
    {
      add { this.Events.AddHandler(_eventShowGridChanged, value); }
      remove { this.Events.RemoveHandler(_eventShowGridChanged, value); }
    }

    [Category("Property Changed")]
    public event EventHandler ShowTextWithSnapshotChanged
    {
      add { this.Events.AddHandler(_eventShowTextWithSnapshotChanged, value); }
      remove { this.Events.RemoveHandler(_eventShowTextWithSnapshotChanged, value); }
    }

    [Category("Property Changed")]
    public event EventHandler ZoomChanged
    {
      add { this.Events.AddHandler(_eventZoomChanged, value); }
      remove { this.Events.RemoveHandler(_eventZoomChanged, value); }
    }

    #endregion Public Events

    #region Public Properties

    /// <summary>
    /// Gets or sets the component color.
    /// </summary>
    /// <value>The component color.</value>
    [Category("Behavior")]
    [DefaultValue(typeof(Color), "Empty")]
    public virtual Color Color
    {
      get { return _color; }
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
    /// Gets or sets the color of the grid.
    /// </summary>
    /// <value>The color of the grid.</value>
    [Category("Appearance")]
    [DefaultValue(typeof(Color), "ControlDark")]
    public virtual Color GridColor
    {
      get { return _gridColor; }
      set
      {
        if (_gridColor != value)
        {
          _gridColor = value;

          this.OnGridColorChanged(EventArgs.Empty);
        }
      }
    }

    /// <summary>
    /// Returns if a snapshot image is available
    /// </summary>
    /// <value><c>true</c> if a snapshot image is available; otherwise, <c>false</c>.</value>
    [Browsable(false)]
    public bool HasSnapshot
    {
      get => _hasSnapshot;
      protected set => _hasSnapshot = value;
    }

    /// <summary>
    /// Gets or sets the image.
    /// </summary>
    /// <value>The image.</value>
    [Category("Appearance")]
    [DefaultValue(typeof(Image), null)]
    public virtual Image Image
    {
      get { return _image; }
      set
      {
        if (_image != value)
        {
          _image = value;

          this.OnImageChanged(EventArgs.Empty);
        }
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether a pixel grid is displayed.
    /// </summary>
    /// <value><c>true</c> if a pixel grid is displayed; otherwise, <c>false</c>.</value>
    [Category("Appearance")]
    [DefaultValue(true)]
    public virtual bool ShowGrid
    {
      get { return _showGrid; }
      set
      {
        if (_showGrid != value)
        {
          _showGrid = value;

          this.OnShowGridChanged(EventArgs.Empty);
        }
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether text should be shown when a snapshot is present.
    /// </summary>
    /// <value><c>true</c> if text is to be shown when a snapshot is present; otherwise, <c>false</c> to only show text when no snapshot is available.</value>
    [Category("Appearance")]
    [DefaultValue(false)]
    public virtual bool ShowTextWithSnapshot
    {
      get { return _showTextWithSnapshot; }
      set
      {
        if (_showTextWithSnapshot != value)
        {
          _showTextWithSnapshot = value;

          this.OnShowTextWithSnapshotChanged(EventArgs.Empty);
        }
      }
    }

    /// <summary>
    /// Gets or sets the tab order of the control within its container.
    /// </summary>
    /// <value>The index of the tab.</value>
    /// <returns>The index value of the control within the set of controls within its container. The controls in the container are included in the tab order.</returns>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [DefaultValue(0)]
    public new int TabIndex
    {
      get { return base.TabIndex; }
      set { base.TabIndex = value; }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the user can give the focus to this control using the TAB key.
    /// </summary>
    /// <value><c>true</c> if [tab stop]; otherwise, <c>false</c>.</value>
    /// <returns>true if the user can give the focus to the control using the TAB key; otherwise, false. The default is true.Note:This property will always return true for an instance of the <see cref="T:System.Windows.Forms.Form" /> class.</returns>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [DefaultValue(false)]
    public new bool TabStop
    {
      get { return base.TabStop; }
      set { base.TabStop = value; }
    }

    /// <summary>
    /// Gets or sets the zoom level of the snapshot image.
    /// </summary>
    /// <value>The zoom level.</value>
    [Category("Appearance")]
    [DefaultValue(8)]
    public virtual int Zoom
    {
      get { return _zoom; }
      set
      {
        if (_zoom != value)
        {
          _zoom = value;

          this.OnZoomChanged(EventArgs.Empty);
        }
      }
    }

    #endregion Public Properties

    #region Protected Properties

    /// <summary>
    /// Gets or sets a value indicating snapshot capture is in progress.
    /// </summary>
    /// <value><c>true</c> if snapshot capture is in progress; otherwise, <c>false</c>.</value>
    protected bool IsCapturing
    {
      get => _isCapturing;
      set => _isCapturing = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether redraw operations should occur.
    /// </summary>
    /// <value><c>true</c> if redraw operations should occur; otherwise, <c>false</c>.</value>
    protected bool LockUpdates { get; set; }

    /// <summary>
    /// Gets or sets the snapshot image.
    /// </summary>
    /// <value>The snapshot image.</value>
    [Obsolete("Setter will be removed in a future update.")]
    protected Bitmap SnapshotImage
    {
      get => _snapshotImage;
      set => _snapshotImage = value;
    }

    #endregion Protected Properties

    #region Public Methods

    public void CaptureMouse()
    {
      ScreenColorPickerHooks.Capture(this);
    }

    public void ReleaseMouse()
    {
      ScreenColorPickerHooks.Release();
    }

    #endregion Public Methods

    #region Internal Methods

    internal void MarkAsCapturing()
    {
      if (_eyedropperCursor == null)
      {
        _eyedropperCursor = ResourceManager.EyeDropper;
      }

      Cursor.Current = _eyedropperCursor;
      _isCapturing = true;
      this.Invalidate();
    }

    internal void MarkAsReleased()
    {
      Cursor.Current = Cursors.Default;
      _isCapturing = false;
      this.Invalidate();
      _lastUpdate = Point.Empty;
    }

    internal void RequestUpdate()
    {
      this.UpdateSnapshot();
    }

    internal void UpdateColor()
    {
      Point center;

      // update the active color
      center = this.GetCenterPoint();
      this.Color = _snapshotImage.GetPixel(center.X, center.Y);
    }

    #endregion Internal Methods

    #region Protected Methods

    /// <summary>
    /// Creates the snapshot image.
    /// </summary>
    protected virtual void CreateSnapshotImage()
    {
      Size size;

      if (_snapshotImage != null)
      {
        _snapshotImage.Dispose();
        _snapshotImage = null;
      }

      size = this.GetSnapshotSize();
      if (!size.IsEmpty)
      {
        _snapshotImage = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb);
        this.Invalidate();
      }
    }

    /// <summary>
    /// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.Control" /> and its child controls and optionally releases the managed resources.
    /// </summary>
    /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        _eyedropperCursor?.Dispose();
        _snapshotImage?.Dispose();
      }

      this.ReleaseMouse();

      base.Dispose(disposing);
    }

    /// <summary>
    /// Gets the center point based on the current zoom level.
    /// </summary>
    protected virtual Point GetCenterPoint()
    {
      Size size;
      int x;
      int y;

      size = this.ClientSize;
      x = size.Width / _zoom / 2;
      y = size.Height / _zoom / 2;

      return new Point(x, y);
    }

    /// <summary>
    /// Gets the size of the snapshot.
    /// </summary>
    protected virtual Size GetSnapshotSize()
    {
      Size size;
      int snapshotWidth;
      int snapshotHeight;

      size = this.ClientSize;
      snapshotWidth = (int)Math.Ceiling(size.Width / (double)_zoom);
      snapshotHeight = (int)Math.Ceiling(size.Height / (double)_zoom);

      return snapshotHeight > 0 && snapshotWidth > 0
        ? new Size(snapshotWidth, snapshotHeight)
        : Size.Empty;
    }

    /// <summary>
    /// Raises the <see cref="ColorChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnColorChanged(EventArgs e)
    {
      EventHandler handler;

      handler = (EventHandler)this.Events[_eventColorChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.FontChanged" /> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
    protected override void OnFontChanged(EventArgs e)
    {
      base.OnFontChanged(e);

      this.Invalidate();
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.ForeColorChanged" /> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
    protected override void OnForeColorChanged(EventArgs e)
    {
      base.OnForeColorChanged(e);

      this.Invalidate();
    }

    /// <summary>
    /// Raises the <see cref="GridColorChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnGridColorChanged(EventArgs e)
    {
      EventHandler handler;

      this.Invalidate();

      handler = (EventHandler)this.Events[_eventGridColorChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ImageChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnImageChanged(EventArgs e)
    {
      EventHandler handler;

      this.Invalidate();

      handler = (EventHandler)this.Events[_eventImageChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
    protected override void OnMouseDown(MouseEventArgs e)
    {
      base.OnMouseDown(e);

      if (e.Button == MouseButtons.Left && !_isCapturing)
      {
        this.MarkAsCapturing();
      }
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);

      // Only process mousemove if we aren't using the hook version
      if (_isCapturing && this.Capture)
      {
        this.UpdateSnapshot();
        this.UpdateColor();
      }
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
    protected override void OnMouseUp(MouseEventArgs e)
    {
      base.OnMouseUp(e);

      if (_isCapturing)
      {
        this.MarkAsReleased();
      }
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      this.OnPaintBackground(e); // HACK: Easiest way of supporting things like BackgroundImage, BackgroundImageLayout etc

      // draw the current snapshot, if present
      if (_snapshotImage != null)
      {
        e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
        e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

        e.Graphics.DrawImage(_snapshotImage, new Rectangle(0, 0, _snapshotImage.Width * _zoom, _snapshotImage.Height * _zoom), new Rectangle(Point.Empty, _snapshotImage.Size), GraphicsUnit.Pixel);
      }

      this.PaintAdornments(e);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);

      this.CreateSnapshotImage();
    }

    /// <summary>
    /// Raises the <see cref="ShowGridChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnShowGridChanged(EventArgs e)
    {
      EventHandler handler;

      this.Invalidate();

      handler = (EventHandler)this.Events[_eventShowGridChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ShowTextWithSnapshotChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnShowTextWithSnapshotChanged(EventArgs e)
    {
      EventHandler handler;

      this.Invalidate();

      handler = (EventHandler)this.Events[_eventShowTextWithSnapshotChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.TextChanged" /> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
    protected override void OnTextChanged(EventArgs e)
    {
      base.OnTextChanged(e);

      this.Invalidate();
    }

    /// <summary>
    /// Raises the <see cref="ZoomChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnZoomChanged(EventArgs e)
    {
      EventHandler handler;

      this.CreateSnapshotImage();

      handler = (EventHandler)this.Events[_eventZoomChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Paints adornments onto the control.
    /// </summary>
    /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
    protected virtual void PaintAdornments(PaintEventArgs e)
    {
      Rectangle client;

      client = this.ClientRectangle;

      // grid
      if (_showGrid)
      {
        this.PaintGrid(e);
      }

      // center marker
      if (_hasSnapshot)
      {
        this.PaintCenterMarker(e);
      }

      // image
      if (_image != null && (!_hasSnapshot || _showTextWithSnapshot))
      {
        e.Graphics.DrawImage(_image, (client.Width - _image.Size.Width) / 2, (client.Height - _image.Size.Height) / 2);
      }

      // draw text
      if (!string.IsNullOrEmpty(this.Text) && (!_hasSnapshot || _showTextWithSnapshot))
      {
        TextRenderer.DrawText(e.Graphics, this.Text, this.Font, client, this.ForeColor, this.BackColor, TextFormatFlags.ExpandTabs | TextFormatFlags.NoPrefix | TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter | TextFormatFlags.WordBreak | TextFormatFlags.WordEllipsis);
      }
    }

    /// <summary>
    /// Paints the center marker.
    /// </summary>
    /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
    protected virtual void PaintCenterMarker(PaintEventArgs e)
    {
      Point center;

      center = this.GetCenterPoint();

      PaintHelper.DrawInvertedRect(e.Graphics, (center.X * _zoom) - 1, (center.Y * _zoom) - 1, _zoom + 3, _zoom + 3);
    }

    /// <summary>
    /// Paints the pixel grid.
    /// </summary>
    /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
    protected virtual void PaintGrid(PaintEventArgs e)
    {
      Rectangle viewport;
      int pixelSize;

      pixelSize = _zoom;
      viewport = this.ClientRectangle;

      using (Pen pen = new Pen(_gridColor)
      {
        DashStyle = DashStyle.Dot
      })
      {
        for (int x = viewport.Left + 1; x < viewport.Right; x += pixelSize)
        {
          e.Graphics.DrawLine(pen, x, viewport.Top, x, viewport.Bottom);
        }

        for (int y = viewport.Top + 1; y < viewport.Bottom; y += pixelSize)
        {
          e.Graphics.DrawLine(pen, viewport.Left, y, viewport.Right, y);
        }

        e.Graphics.DrawRectangle(pen, viewport);
      }
    }

    /// <summary>
    /// Updates the snapshot.
    /// </summary>
    protected virtual void UpdateSnapshot()
    {
      Point cursor;

      cursor = Control.MousePosition;
      cursor.X -= _snapshotImage.Width / 2;
      cursor.Y -= _snapshotImage.Height / 2;

      if (_lastUpdate != cursor)
      {
        _lastUpdate = cursor;

        using (Graphics graphics = Graphics.FromImage(_snapshotImage))
        {
          // clear the image first, in case the mouse is near the borders of the screen so there isn't enough copy content to fill the area
          graphics.Clear(Color.Empty);

          // copy the image from the screen
          graphics.CopyFromScreen(cursor, Point.Empty, _snapshotImage.Size);

          // force a redraw
          _hasSnapshot = true;
          this.Refresh(); // just calling Invalidate isn't enough as the display will lag
        }
      }
    }

    #endregion Protected Methods
  }
}
