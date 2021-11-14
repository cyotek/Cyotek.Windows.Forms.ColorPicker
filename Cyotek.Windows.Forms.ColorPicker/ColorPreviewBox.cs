// Cyotek Color Picker Controls Library
// http://cyotek.com/blog/tag/colorpicker

// Copyright (c) 2013-2021 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.cyotek.com/contribute

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms
{
  internal sealed class ColorPreviewBox : Control
  {
    #region Private Fields

    private Color _color;

    #endregion Private Fields

    #region Public Constructors

    public ColorPreviewBox()
    {
      this.SetStyle(ControlStyles.Selectable, false);
      this.DoubleBuffered = true;
      base.TabStop = false;

      _color = Color.Empty;
    }

    #endregion Public Constructors

    #region Public Properties

    [Category("Appearance")]
    [DefaultValue(typeof(Color), "Empty")]
    public Color Color
    {
      get => _color;
      set
      {
        if (_color != value)
        {
          _color = value;

          this.Invalidate();
        }
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new int TabIndex
    {
      get => base.TabIndex;
      set => base.TabIndex = value;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new bool TabStop
    {
      get => base.TabStop;
      set => base.TabStop = value;
    }

    #endregion Public Properties

    #region Protected Methods

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.Paint"/> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains the event data. </param>
    protected override void OnPaint(PaintEventArgs e)
    {
      Rectangle drawArea;

      base.OnPaint(e);

      drawArea = this.ClientRectangle;

      ControlPaint.DrawBorder3D(e.Graphics, drawArea, Border3DStyle.Sunken);

      drawArea.Inflate(-2, -2);

      if (_color.A != 255)
      {
        using (TextureBrush brush = new TextureBrush(ResourceManager.CellBackground, WrapMode.Tile))
        {
          e.Graphics.FillRectangle(brush, drawArea);
        }
      }

      using (Brush brush = new SolidBrush(_color))
      {
        e.Graphics.FillRectangle(brush, drawArea);
      }
    }

    #endregion Protected Methods
  }
}
