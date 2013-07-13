using System;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms.ColorPicker.Demo
{
  // Cyotek Color Picker controls library
  // Copyright © 2013 Cyotek. All Rights Reserved.
  // http://cyotek.com/blog/tag/colorpicker

  // If you use this code in your applications, donations or attribution are welcome

  internal partial class MainForm : BaseForm
  {
    #region Constructors

    public MainForm()
    {
      InitializeComponent();
    }

    #endregion

    #region Event Handlers

    private void aboutButton_Click(object sender, EventArgs e)
    {
      using (Form dialog = new AboutDialog())
        dialog.ShowDialog(this);
    }

    private void colorEditorDemoButton_Click(object sender, EventArgs e)
    {
      using (Form dialog = new ColorEditorDemoForm())
        dialog.ShowDialog(this);
    }

    private void colorEditorManagerDemoButton_Click(object sender, EventArgs e)
    {
      using (Form dialog = new ColorEditorManagerDemoForm())
        dialog.ShowDialog(this);
    }

    private void colorGridDemoButton_Click(object sender, EventArgs e)
    {
      using (Form dialog = new ColorGridDemoForm())
        dialog.ShowDialog(this);
    }

    private void colorPickerFormDemoButton_Click(object sender, EventArgs e)
    {
      using (Form dialog = new ColorPickerDialogDemoForm())
        dialog.ShowDialog(this);
    }

    private void colorSliderDemoButton_Click(object sender, EventArgs e)
    {
      using (Form dialog = new ColorSliderDemonstrationForm())
        dialog.ShowDialog(this);
    }

    private void colorWheelDemoButton_Click(object sender, EventArgs e)
    {
      using (Form dialog = new ColorWheelDemoForm())
        dialog.ShowDialog(this);
    }

    private void exitButton_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void screenColorPickerDemoButton_Click(object sender, EventArgs e)
    {
      using (Form dialog = new ScreenColorPickerDemoForm())
        dialog.ShowDialog(this);
    }

    #endregion
  }
}
