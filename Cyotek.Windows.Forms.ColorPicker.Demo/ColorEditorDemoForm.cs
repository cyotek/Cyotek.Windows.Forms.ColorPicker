using System;
using System.Drawing;

namespace Cyotek.Windows.Forms.ColorPicker.Demo
{
  // Cyotek Color Picker controls library
  // Copyright © 2013-2017 Cyotek Ltd.
  // http://cyotek.com/blog/tag/colorpicker

  // Licensed under the MIT License. See license.txt for the full text.

  // If you use this code in your applications, donations or attribution are welcome

  internal partial class ColorEditorDemoForm : BaseForm
  {
    #region Constructors

    public ColorEditorDemoForm()
    {
      this.InitializeComponent();
    }

    #endregion

    #region Methods

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      colorEditor.Color = Color.SeaGreen;
    }

    private void closeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void colorEditor_ColorChanged(object sender, EventArgs e)
    {
      optionsSplitContainer.Panel2.BackColor = colorEditor.Color;
    }

    #endregion
  }
}
