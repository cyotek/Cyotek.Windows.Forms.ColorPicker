using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Cyotek.Windows.Forms.ColorPicker.Demo.Properties;

namespace Cyotek.Windows.Forms.ColorPicker.Demo
{
  // Cyotek Color Picker controls library
  // Copyright © 2013-2017 Cyotek Ltd.
  // http://cyotek.com/blog/tag/colorpicker

  // Licensed under the MIT License. See license.txt for the full text.

  // If you use this code in your applications, donations or attribution are welcome

  internal class ColorPreviewBox : Control
  {
    #region Fields

    private Color _color;

    #endregion

    #region Constructors

    public ColorPreviewBox()
    {
      this.Color = Color.Empty;
    }

    #endregion

    #region Events

    /// <summary>
    /// Occurs when the Color property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler ColorChanged;

    #endregion

    #region Properties

    [Category("Appearance")]
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

    #endregion

    #region Methods

    /// <summary>
    /// Raises the <see cref="ColorChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnColorChanged(EventArgs e)
    {
      EventHandler handler;

      this.Invalidate();

      handler = this.ColorChanged;

      if (handler != null)
      {
        handler(this, e);
      }
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.Paint"/> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains the event data. </param>
    protected override void OnPaint(PaintEventArgs e)
    {
      Rectangle drawArea;

      base.OnPaint(e);

      drawArea = Rectangle.Inflate(this.ClientRectangle, -2, -2);

      ControlPaint.DrawBorder3D(e.Graphics, this.ClientRectangle, Border3DStyle.Sunken);

      if (this.Color.A != 255)
      {
        using (TextureBrush brush = new TextureBrush(Resources.cellbackground))
        {
          e.Graphics.FillRectangle(brush, drawArea);
        }
      }

      using (Brush brush = new SolidBrush(this.Color))
      {
        e.Graphics.FillRectangle(brush, drawArea);
      }
    }

    #endregion
  }
}
