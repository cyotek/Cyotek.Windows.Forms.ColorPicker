using System;
using System.Drawing;

namespace Cyotek.Windows.Forms.ColorPicker.Demo
{
  // Cyotek Color Picker controls library
  // Copyright © 2013-2014 Cyotek.
  // http://cyotek.com/blog/tag/colorpicker

  // Licensed under the MIT License. See colorpicker-license.txt for the full text.

  // If you use this code in your applications, donations or attribution are welcome

  internal partial class ColorWheelDemoForm : BaseForm
  {
    #region Public Constructors

    public ColorWheelDemoForm()
    {
      InitializeComponent();
    }

    #endregion

    #region Overridden Methods

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      colorWheel.Color = Color.SeaGreen;
    }

    #endregion

    #region Event Handlers

    private void closeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void colorWheel_ColorChanged(object sender, EventArgs e)
    {
      optionsSplitContainer.Panel2.BackColor = colorWheel.Color;
    }

    #endregion
  }
}
