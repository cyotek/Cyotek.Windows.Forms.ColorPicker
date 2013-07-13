using System;
using System.Drawing;

namespace Cyotek.Windows.Forms.ColorPicker.Demo
{
  // Cyotek Color Picker controls library
  // Copyright © 2013 Cyotek. All Rights Reserved.
  // http://cyotek.com/blog/tag/colorpicker

  // If you use this code in your applications, donations or attribution are welcome

  internal partial class ColorEditorDemoForm : BaseForm
  {
    #region Constructors

    public ColorEditorDemoForm()
    {
      InitializeComponent();
    }

    #endregion

    #region Overridden Members

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      colorEditor.Color = Color.SeaGreen;
    }

    #endregion

    #region Event Handlers

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
