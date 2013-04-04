using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms
{
  // Cyotek Color Picker controls library
  // Copyright © 2013 Cyotek. All Rights Reserved.
  // http://cyotek.com/blog/tag/colorpicker

  // If you use this code in your applications, donations or attribution is welcome

  public partial class ColorPickerDialog : Form
  {
    #region Constructors

    public ColorPickerDialog()
    {
      this.InitializeComponent();
      this.Font = SystemFonts.DialogFont;
    }

    #endregion

    #region Properties

    public Color Color
    {
      get { return colorEditorManager.Color; }
      set { colorEditorManager.Color = value; }
    }

    #endregion

    #region Event Handlers

    private void cancelButton_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private void colorEditorManager_ColorChanged(object sender, EventArgs e)
    {
      previewPanel.BackColor = colorEditorManager.Color;
    }

    private void okButton_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    #endregion
  }
}
