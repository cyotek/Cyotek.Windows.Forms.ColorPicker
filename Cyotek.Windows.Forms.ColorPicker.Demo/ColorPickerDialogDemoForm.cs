using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms.ColorPicker.Demo
{
  // Cyotek Color Picker controls library
  // Copyright © 2013-2014 Cyotek.
  // http://cyotek.com/blog/tag/colorpicker

  // Licensed under the MIT License. See colorpicker-license.txt for the full text.

  // If you use this code in your applications, donations or attribution are welcome

  internal partial class ColorPickerDialogDemoForm : BaseForm
  {
    #region Instance Fields

    private Color _color;

    #endregion

    #region Public Constructors

    public ColorPickerDialogDemoForm()
    {
      InitializeComponent();
    }

    #endregion

    #region Overridden Methods

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      _color = Color.SeaGreen;
    }

    #endregion

    #region Event Handlers

    private void browseColorButton_Click(object sender, EventArgs e)
    {
      using (ColorPickerDialog dialog = new ColorPickerDialog())
      {
        dialog.Color = _color;

        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
          _color = dialog.Color;
          panel.Invalidate();
        }
      }
    }

    private void closeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void panel_Paint(object sender, PaintEventArgs e)
    {
      using (Brush brush = new SolidBrush(_color))
        e.Graphics.FillRectangle(brush, panel.ClientRectangle);
    }

    #endregion
  }
}
