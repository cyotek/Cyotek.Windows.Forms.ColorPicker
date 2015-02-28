using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms.ColorPicker.Demo
{
  // Cyotek Color Picker controls library
  // Copyright © 2013-2015 Cyotek Ltd.
  // http://cyotek.com/blog/tag/colorpicker

  // Licensed under the MIT License. See license.txt for the full text.

  // If you use this code in your applications, donations or attribution are welcome

  internal partial class ColorPickerDialogDemoForm : BaseForm
  {
    #region Instance Fields


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

      colorPreviewPanel.Color = Color.SeaGreen;
    }

    #endregion

    #region Event Handlers

    private void browseColorButton_Click(object sender, EventArgs e)
    {
      using (ColorPickerDialog dialog = new ColorPickerDialog())
      {
        dialog.Color = colorPreviewPanel.Color;
        dialog.ShowAlphaChannel = showAlphaChannelCheckBox.Checked;

        dialog.PreviewColorChanged += this.DialogColorChangedHandler;

        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
          colorPreviewPanel.Color = dialog.Color;
        }

        dialog.PreviewColorChanged -= this.DialogColorChangedHandler;
      }
    }

    private void DialogColorChangedHandler(object sender, EventArgs e)
    {
      dialogColorPreviewPanel.Color = ((ColorPickerDialog)sender).Color;
    }

    private void closeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    #endregion
  }
}
