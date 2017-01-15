using System;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms.ColorPicker.Demo
{
  // Cyotek Color Picker controls library
  // Copyright © 2013-2015 Cyotek Ltd.
  // http://cyotek.com/blog/tag/colorpicker

  // Licensed under the MIT License. See license.txt for the full text.

  // If you use this code in your applications, donations or attribution are welcome

  internal partial class MainForm : AboutDialog
  {
    #region Constructors

    public MainForm()
    {
      this.InitializeComponent();
    }

    #endregion

    #region Methods

    protected override void OnLoad(EventArgs e)
    {
      TabPage demoPage;

      base.OnLoad(e);

      demoPage = new TabPage
                 {
                   UseVisualStyleBackColor = true,
                   Padding = new Padding(9),
                   Text = "Demonstrations"
                 };

      groupBox1.Dock = DockStyle.Fill;
      demoPage.Controls.Add(groupBox1);

      this.TabControl.TabPages.Insert(0, demoPage);
      this.TabControl.SelectedTab = demoPage;

      this.Text = "Cyotek ColorPicker Controls for Windows Forms";
    }

    private void aboutButton_Click(object sender, EventArgs e)
    {
      using (Form dialog = new AboutDialog())
      {
        dialog.ShowDialog(this);
      }
    }

    private void colorEditorDemoButton_Click(object sender, EventArgs e)
    {
      this.ShowDemo<ColorEditorDemoForm>();
    }

    private void colorEditorManagerDemoButton_Click(object sender, EventArgs e)
    {
      this.ShowDemo<ColorEditorManagerDemoForm>();
    }

    private void colorGridDemoButton_Click(object sender, EventArgs e)
    {
      this.ShowDemo<ColorGridDemoForm>();
    }

    private void colorPickerFormDemoButton_Click(object sender, EventArgs e)
    {
      this.ShowDemo<ColorPickerDialogDemoForm>();
    }

    private void colorSliderDemoButton_Click(object sender, EventArgs e)
    {
      this.ShowDemo<ColorSliderDemonstrationForm>();
    }

    private void colorWheelDemoButton_Click(object sender, EventArgs e)
    {
      this.ShowDemo<ColorWheelDemoForm>();
    }

    private void exitButton_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void screenColorPickerDemoButton_Click(object sender, EventArgs e)
    {
      this.ShowDemo<ScreenColorPickerDemoForm>();
    }

    private void ShowDemo<T>() where T : Form, new()
    {
      Cursor.Current = Cursors.WaitCursor;

      using (Form form = new T())
      {
        form.ShowDialog(this);
      }
    }

    private void toolstripDemoButton_Click(object sender, EventArgs e)
    {
      this.ShowDemo<ToolStripHostDemoForm>();
    }

    #endregion
  }
}
