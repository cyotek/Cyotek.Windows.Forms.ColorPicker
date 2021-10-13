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
  /// <summary>
  /// Represents a control for selecting the saturation of a color
  /// </summary>
  public class SaturationColorSlider : ColorSlider
  {
    #region Private Fields

    private static readonly object _eventColorChanged = new object();

    private Brush _cellBackgroundBrush;

    private Color _color;

    #endregion Private Fields

    #region Public Constructors

    public SaturationColorSlider()
    {
      this.BarStyle = ColorBarStyle.TwoColor;
      this.Color = Color.Black;
    }

    #endregion Public Constructors

    #region Public Events

    [Category("Property Changed")]
    public event EventHandler ColorChanged
    {
      add { this.Events.AddHandler(_eventColorChanged, value); }
      remove { this.Events.RemoveHandler(_eventColorChanged, value); }
    }

    #endregion Public Events

    #region Public Properties

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override ColorBarStyle BarStyle
    {
      get { return base.BarStyle; }
      set { base.BarStyle = value; }
    }

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

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Color Color1
    {
      get { return base.Color1; }
      set { base.Color1 = value; }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Color Color2
    {
      get { return base.Color2; }
      set { base.Color2 = value; }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Color Color3
    {
      get { return base.Color3; }
      set { base.Color3 = value; }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override float Maximum
    {
      get { return base.Maximum; }
      set { base.Maximum = value; }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override float Minimum
    {
      get { return base.Minimum; }
      set { base.Minimum = value; }
    }

    public override float Value
    {
      get { return base.Value; }
      set { base.Value = (int)value; }
    }

    #endregion Public Properties

    #region Protected Methods

    protected virtual void CreateScale()
    {
      HslColor color;

      color = new HslColor(this.Color);

      color.S = 0;
      this.Color1 = color.ToRgbColor();

      color.S = 1;
      this.Color2 = color.ToRgbColor();
    }

    protected virtual Brush CreateTransparencyBrush()
    {
      return new TextureBrush(ResourceManager.CellBackground, WrapMode.Tile);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (_cellBackgroundBrush != null)
        {
          _cellBackgroundBrush.Dispose();
        }
      }

      base.Dispose(disposing);
    }

    /// <summary>
    /// Raises the <see cref="ColorChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnColorChanged(EventArgs e)
    {
      EventHandler handler;

      this.CreateScale();
      this.Invalidate();

      handler = (EventHandler)this.Events[_eventColorChanged];

      handler?.Invoke(this, e);
    }

    protected override void PaintBar(PaintEventArgs e)
    {
      if (this.Color.A != 255)
      {
        if (_cellBackgroundBrush == null)
        {
          _cellBackgroundBrush = this.CreateTransparencyBrush();
        }

        e.Graphics.FillRectangle(_cellBackgroundBrush, this.BarBounds);
      }

      base.PaintBar(e);
    }

    #endregion Protected Methods
  }
}
