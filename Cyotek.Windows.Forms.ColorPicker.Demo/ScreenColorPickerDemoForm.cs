using System;

namespace Cyotek.Windows.Forms.ColorPicker.Demo
{
  // Cyotek Color Picker controls library
  // Copyright © 2013-2017 Cyotek Ltd.
  // http://cyotek.com/blog/tag/colorpicker

  // Licensed under the MIT License. See license.txt for the full text.

  // If you use this code in your applications, donations or attribution are welcome

  internal partial class ScreenColorPickerDemoForm : BaseForm
  {
    #region Constructors

    public ScreenColorPickerDemoForm()
    {
      this.InitializeComponent();
    }

    #endregion

    #region Methods

    private void closeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void screenColorPicker1_ColorChanged(object sender, EventArgs e)
    {
      optionsSplitContainer.Panel2.BackColor = screenColorPicker1.Color;
    }

    #endregion

    private void releaseButton_Click(object sender, EventArgs e)
    {
      screenColorPicker1.ReleaseMouse();
    }

    private void captureButton_Click(object sender, EventArgs e)
    {
      screenColorPicker1.CaptureMouse();
    }
  }
}
