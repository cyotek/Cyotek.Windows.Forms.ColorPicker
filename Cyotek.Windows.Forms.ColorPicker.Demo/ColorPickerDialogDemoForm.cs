// Cyotek Color Picker Controls Library
// http://cyotek.com/blog/tag/colorpicker

// Copyright (c) 2013-2021 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.cyotek.com/contribute

using Cyotek.Demo.Windows.Forms;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms.ColorPicker.Demo
{
  internal partial class ColorPickerDialogDemoForm : BaseForm
  {
    #region Public Constructors

    public ColorPickerDialogDemoForm()
    {
      this.InitializeComponent();
    }

    #endregion Public Constructors

    #region Protected Methods

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      colorPreviewPanel.Color = Color.CornflowerBlue;
    }

    #endregion Protected Methods

    #region Private Methods

    private void BrowseColorButton_Click(object sender, EventArgs e)
    {
      using (ColorPickerDialog dialog = new ColorPickerDialog
      {
        Color = colorPreviewPanel.Color,
        ShowAlphaChannel = showAlphaChannelCheckBox.Checked,
        PreserveAlphaChannel = preserveAlphaChannelCheckBox.Checked,
        ShowLoad = showLoadCheckBox.Checked,
        ShowSave = showSaveCheckBox.Checked
      })
      {
        //dialog.CustomColorsLoading += this.DialogCustomColorsLoadingHandler;
        dialog.PreviewColorChanged += this.DialogColorChangedHandler;

        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
          colorPreviewPanel.Color = dialog.Color;
        }

        dialog.PreviewColorChanged -= this.DialogColorChangedHandler;
      }
    }

    private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void DialogColorChangedHandler(object sender, EventArgs e)
    {
      dialogColorPreviewPanel.Color = ((ColorPickerDialog)sender).Color;
    }

    private void DialogCustomColorsLoadingHandler(object sender, CancelEventArgs e)
    {
      ((ColorPickerDialog)sender).CustomColors = ColorPalettes.Office2010Standard;
    }

    #endregion Private Methods
  }
}
