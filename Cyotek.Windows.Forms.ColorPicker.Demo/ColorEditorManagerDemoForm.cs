using System;
using System.Drawing;

namespace Cyotek.Windows.Forms.ColorPicker.Demo
{
  // Cyotek Color Picker controls library
  // Copyright © 2013 Cyotek. All Rights Reserved.
  // http://cyotek.com/blog/tag/colorpicker

  // If you use this code in your applications, donations or attribution is welcome

  internal partial class ColorEditorManagerDemoForm : BaseForm
  {
    #region Constructors

    public ColorEditorManagerDemoForm()
    {
      InitializeComponent();
    }

    #endregion

    #region Overridden Members

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      colorEditorManager.Color = Color.SeaGreen;
    }

    #endregion

    #region Event Handlers

    private void closeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void colorEditorManager_ColorChanged(object sender, EventArgs e)
    {
      previewPanel.BackColor = colorEditorManager.Color;
    }

    #endregion
  }
}
