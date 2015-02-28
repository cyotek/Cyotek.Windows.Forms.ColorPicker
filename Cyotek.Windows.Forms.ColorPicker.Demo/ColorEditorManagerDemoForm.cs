using System;
using System.Drawing;

namespace Cyotek.Windows.Forms.ColorPicker.Demo
{
  // Cyotek Color Picker controls library
  // Copyright © 2013-2015 Cyotek Ltd.
  // http://cyotek.com/blog/tag/colorpicker

  // Licensed under the MIT License. See license.txt for the full text.

  // If you use this code in your applications, donations or attribution are welcome

  internal partial class ColorEditorManagerDemoForm : BaseForm
  {
    #region Public Constructors

    public ColorEditorManagerDemoForm()
    {
      InitializeComponent();
    }

    #endregion

    #region Overridden Methods

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
