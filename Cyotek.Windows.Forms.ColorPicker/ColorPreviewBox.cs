// Cyotek Color Picker Controls Library
// http://cyotek.com/blog/tag/colorpicker

// Copyright (c) 2013-2021 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.cyotek.com/contribute

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms
{
  [DefaultProperty("Color")]
  [DefaultEvent("ColorChanged")]
  internal class ColorPreviewBox : Control
  {
    #region Private Fields

    private static readonly object _eventColorChanged = new object();

    private static readonly object _eventGridColorAlternateChanged = new object();

    private static readonly object _eventGridColorChanged = new object();

    private Color _color;

    private Color _gridColor;

    private Color _gridColorAlternate;

    private Bitmap _gridTile;

    private Brush _texture;

    #endregion Private Fields

    #region Public Constructors

    public ColorPreviewBox()
    {
      this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
      this.SetStyle(ControlStyles.Selectable, false);
      this.TabStop = false;

      _color = Color.Empty;
      _gridColor = Color.Gainsboro;
      _gridColorAlternate = Color.White;

      this.InitializeGridTile();
    }

    #endregion Public Constructors

    #region Public Events

    [Category("Property Changed")]
    public event EventHandler ColorChanged
    {
      add => this.Events.AddHandler(_eventColorChanged, value);
      remove => this.Events.RemoveHandler(_eventColorChanged, value);
    }

    [Category("Property Changed")]
    public event EventHandler GridColorAlternateChanged
    {
      add => this.Events.AddHandler(_eventGridColorAlternateChanged, value);
      remove => this.Events.RemoveHandler(_eventGridColorAlternateChanged, value);
    }

    [Category("Property Changed")]
    public event EventHandler GridColorChanged
    {
      add => this.Events.AddHandler(_eventGridColorChanged, value);
      remove => this.Events.RemoveHandler(_eventGridColorChanged, value);
    }

    #endregion Public Events

    #region Public Properties

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Image BackgroundImage
    {
      get => base.BackgroundImage;
      set => base.BackgroundImage = value;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override ImageLayout BackgroundImageLayout
    {
      get => base.BackgroundImageLayout;
      set => base.BackgroundImageLayout = value;
    }

    [Category("Appearance")]
    [DefaultValue(typeof(Color), "Empty")]
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

    [Category("Appearance")]
    [DefaultValue(typeof(Color), "Gainsboro")]
    public virtual Color GridColor
    {
      get => _gridColor;
      set
      {
        if (this.GridColor != value)
        {
          _gridColor = value;

          this.OnGridColorChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(typeof(Color), "White")]
    public virtual Color GridColorAlternate
    {
      get => _gridColorAlternate;
      set
      {
        if (this.GridColorAlternate != value)
        {
          _gridColorAlternate = value;

          this.OnGridColorAlternateChanged(EventArgs.Empty);
        }
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override RightToLeft RightToLeft
    {
      get => base.RightToLeft;
      set => base.RightToLeft = value;
    }

    #endregion Public Properties

    #region Protected Methods

    /// <summary>
    /// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.Control"/> and its child controls and optionally releases the managed resources.
    /// </summary>
    /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources. </param>
    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (_texture != null)
        {
          _texture.Dispose();
          _texture = null;
        }

        if (_gridTile != null)
        {
          _gridTile.Dispose();
          _gridTile = null;
        }
      }

      base.Dispose(disposing);
    }

    /// <summary>
    /// Draws the specified text within the specified bounds using the specified device context, font, color, back color, and formatting instructions.
    /// </summary>
    /// <param name="graphics">The device context in which to draw the text.</param>
    /// <param name="text">The text to draw.</param>
    /// <param name="font">The <see cref="Font"/> to apply to the drawn text.</param>
    /// <param name="foreColor">The <see cref="Color"/> to apply to the text.</param>
    /// <param name="backColor">The <see cref="Color"/> to apply to the area represented by <c>bounds</c>.</param>
    /// <param name="textAlign">The <see cref="ContentAlignment"/> to apply to the text.</param>
    /// <param name="bounds">The <see cref="Rectangle"/> that represents the bounds of the text.</param>
    /// <param name="padding">Padding to apply around the text</param>
    protected virtual void DrawLabel(Graphics graphics, string text, Font font, Color foreColor, Color backColor, ContentAlignment textAlign, Rectangle bounds, Padding padding)
    {
      TextFormatFlags flags;

      flags = TextFormatFlags.NoPrefix | TextFormatFlags.WordEllipsis | TextFormatFlags.WordBreak | TextFormatFlags.NoPadding;

      switch (textAlign)
      {
        case ContentAlignment.TopLeft:
        case ContentAlignment.MiddleLeft:
        case ContentAlignment.BottomLeft:
          flags |= TextFormatFlags.Left;
          break;

        case ContentAlignment.TopRight:
        case ContentAlignment.MiddleRight:
        case ContentAlignment.BottomRight:
          flags |= TextFormatFlags.Right;
          break;

        default:
          flags |= TextFormatFlags.HorizontalCenter;
          break;
      }

      switch (textAlign)
      {
        case ContentAlignment.TopCenter:
        case ContentAlignment.TopLeft:
        case ContentAlignment.TopRight:
          flags |= TextFormatFlags.Top;
          break;

        case ContentAlignment.BottomCenter:
        case ContentAlignment.BottomLeft:
        case ContentAlignment.BottomRight:
          flags |= TextFormatFlags.Bottom;
          break;

        default:
          flags |= TextFormatFlags.VerticalCenter;
          break;
      }

      if (padding.Horizontal != 0 || padding.Vertical != 0)
      {
        Size size;
        int x;
        int y;
        int width;
        int height;

        size = TextRenderer.MeasureText(graphics, text, font, bounds.Size, flags);
        width = size.Width;
        height = size.Height;

        switch (textAlign)
        {
          case ContentAlignment.TopLeft:
            x = bounds.Left + padding.Left;
            y = bounds.Top + padding.Top;
            break;

          case ContentAlignment.TopCenter:
            x = bounds.Left + padding.Left + ((bounds.Width - width) / 2 - padding.Right);
            y = bounds.Top + padding.Top;
            break;

          case ContentAlignment.TopRight:
            x = bounds.Right - (padding.Right + width);
            y = bounds.Top + padding.Top;
            break;

          case ContentAlignment.MiddleLeft:
            x = bounds.Left + padding.Left;
            y = bounds.Top + padding.Top + (bounds.Height - height) / 2;
            break;

          case ContentAlignment.MiddleCenter:
            x = bounds.Left + padding.Left + ((bounds.Width - width) / 2 - padding.Right);
            y = bounds.Top + padding.Top + (bounds.Height - height) / 2;
            break;

          case ContentAlignment.MiddleRight:
            x = bounds.Right - (padding.Right + width);
            y = bounds.Top + padding.Top + (bounds.Height - height) / 2;
            break;

          case ContentAlignment.BottomLeft:
            x = bounds.Left + padding.Left;
            y = bounds.Bottom - (padding.Bottom + height);
            break;

          case ContentAlignment.BottomCenter:
            x = bounds.Left + padding.Left + ((bounds.Width - width) / 2 - padding.Right);
            y = bounds.Bottom - (padding.Bottom + height);
            break;

          case ContentAlignment.BottomRight:
            x = bounds.Right - (padding.Right + width);
            y = bounds.Bottom - (padding.Bottom + height);
            break;

          default:
            throw new ArgumentOutOfRangeException(nameof(textAlign));
        }

        if (backColor != Color.Empty && backColor.A > 0)
        {
          using (Brush brush = new SolidBrush(backColor))
          {
            graphics.FillRectangle(brush, x - padding.Left, y - padding.Top, width + padding.Horizontal, height + padding.Vertical);
          }
        }

        bounds = new Rectangle(x, y, width, height);

        //bounds = new Rectangle(bounds.Left + padding.Left, bounds.Top + padding.Top, bounds.Width - padding.Horizontal, bounds.Height - padding.Vertical);
      }

      TextRenderer.DrawText(graphics, text, font, bounds, foreColor, backColor, flags);
    }

    /// <summary>
    /// Raises the <see cref="ColorChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnColorChanged(EventArgs e)
    {
      EventHandler handler;

      this.Invalidate();

      handler = (EventHandler)this.Events[_eventColorChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="GridColorAlternateChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnGridColorAlternateChanged(EventArgs e)
    {
      EventHandler handler;

      this.InitializeGridTile();

      handler = (EventHandler)this.Events[_eventGridColorAlternateChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="GridColorChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnGridColorChanged(EventArgs e)
    {
      EventHandler handler;

      this.InitializeGridTile();

      handler = (EventHandler)this.Events[_eventGridColorChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.Paint"/> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains the event data. </param>
    protected override void OnPaint(PaintEventArgs e)
    {
      Rectangle rectangle;
      Rectangle innerRectangle;

      base.OnPaint(e);

      rectangle = this.ClientRectangle;
      innerRectangle = Rectangle.Inflate(rectangle, -2, -2);

      e.Graphics.Clear(this.BackColor);

      if (_texture != null)
      {
        e.Graphics.FillRectangle(_texture, innerRectangle);
      }

      if (!_color.IsEmpty && _color.A > 0)
      {
        using (Brush brush = new SolidBrush(_color))
        {
          e.Graphics.FillRectangle(brush, innerRectangle);
        }
      }

      if (!string.IsNullOrEmpty(this.Text))
      {
        this.DrawLabel(e.Graphics, this.Text, this.Font, SystemColors.HighlightText, SystemColors.Highlight, ContentAlignment.BottomRight, innerRectangle, new Padding(2));
      }

      ControlPaint.DrawBorder3D(e.Graphics, rectangle, Border3DStyle.Sunken);
    }

    protected override void OnTextChanged(EventArgs e)
    {
      base.OnTextChanged(e);

      this.Invalidate();
    }

    #endregion Protected Methods

    #region Private Methods

    /// <summary>
    ///   Initializes the grid tile.
    /// </summary>
    private void InitializeGridTile()
    {
      if (_texture != null)
      {
        _texture.Dispose();
      }

      if (_gridTile != null)
      {
        _gridTile.Dispose();
      }

      _gridTile = ResourceManager.CreateCheckerBoxTile(4, _gridColor, _gridColorAlternate);
      _texture = new TextureBrush(_gridTile, System.Drawing.Drawing2D.WrapMode.Tile);

      this.Invalidate();
    }

    #endregion Private Methods
  }
}
