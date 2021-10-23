// Cyotek Color Picker Controls Library
// http://cyotek.com/blog/tag/colorpicker

// Copyright (c) 2013-2021 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.cyotek.com/contribute

using Cyotek.Demo.Windows.Forms;
using System;
using System.Drawing;

namespace Cyotek.Windows.Forms.ColorPicker.Demo
{
  internal partial class ColorEditorManagerDemoForm : BaseForm
  {
    #region Public Constructors

    public ColorEditorManagerDemoForm()
    {
      this.InitializeComponent();
    }

    #endregion Public Constructors

    #region Protected Methods

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      colorEditorManager.Color = Color.SeaGreen;
    }

    #endregion Protected Methods

    #region Private Methods

    private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void ColorEditorManager_ColorChanged(object sender, EventArgs e)
    {
      previewPanel.Color = colorEditorManager.Color;
    }

    #endregion Private Methods
  }
}
