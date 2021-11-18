// Cyotek Color Picker Controls Library
// http://cyotek.com/blog/tag/colorpicker

// Copyright (c) 2013-2021 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.cyotek.com/contribute

using System;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms.Demo
{
  internal partial class MainForm : AboutDialog
  {
    #region Public Constructors

    public MainForm()
    {
      this.InitializeComponent();
    }

    #endregion Public Constructors

    #region Protected Methods

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

      demoGroupBox.Dock = DockStyle.Fill;
      demoPage.Controls.Add(demoGroupBox);

      this.TabControl.TabPages.Insert(0, demoPage);
      this.TabControl.SelectedTab = demoPage;

      this.Text = Application.ProductName;
    }

    #endregion Protected Methods

    #region Private Methods

    private void ColorEditorDemoButton_Click(object sender, EventArgs e)
    {
      this.ShowDemo<ColorEditorDemoForm>();
    }

    private void ColorEditorManagerDemoButton_Click(object sender, EventArgs e)
    {
      this.ShowDemo<ColorEditorManagerDemoForm>();
    }

    private void ColorGridDemoButton_Click(object sender, EventArgs e)
    {
      this.ShowDemo<ColorGridDemoForm>();
    }

    private void colorGridEditingDemoButton_Click(object sender, EventArgs e)
    {
      this.ShowDemo<ColorGridEditingDemoForm>();
    }

    private void ColorPickerFormDemoButton_Click(object sender, EventArgs e)
    {
      this.ShowDemo<ColorPickerDialogDemoForm>();
    }

    private void ColorSliderDemoButton_Click(object sender, EventArgs e)
    {
      this.ShowDemo<ColorSliderDemonstrationForm>();
    }

    private void ColorWheelDemoButton_Click(object sender, EventArgs e)
    {
      this.ShowDemo<ColorWheelDemoForm>();
    }

    private void ExternalPaletteFilesDemoButton_Click(object sender, EventArgs e)
    {
      this.ShowDemo<ExternalPalettesDemoForm>();
    }

    private void ScreenColorPickerDemoButton_Click(object sender, EventArgs e)
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

    private void ToolstripDemoButton_Click(object sender, EventArgs e)
    {
      this.ShowDemo<ToolStripHostDemoForm>();
    }

    #endregion Private Methods
  }
}
