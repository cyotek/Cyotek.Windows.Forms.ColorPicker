using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Cyotek.Windows.Forms.ColorPicker.Demo;

namespace Cyotek.Windows.Forms.Demo
{
  // Cyotek Color Picker controls library
  // Copyright © 2013-2014 Cyotek.
  // http://cyotek.com/blog/tag/colorpicker

  // Licensed under the MIT License. See colorpicker-license.txt for the full text.

  // If you use this code in your applications, donations or attribution are welcome

  internal partial class AboutDialog : BaseForm
  {
    #region Public Constructors

    public AboutDialog()
    {
      this.InitializeComponent();
    }

    #endregion

    #region Class Members

    internal static void ShowAboutDialog()
    {
      using (Form dialog = new AboutDialog())
        dialog.ShowDialog();
    }

    #endregion

    #region Overridden Methods

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      if (!this.DesignMode)
      {
        FileVersionInfo info;
        Assembly assembly;
        string title;

        assembly = typeof(ColorPickerDialog).Assembly;
        info = FileVersionInfo.GetVersionInfo(assembly.Location);
        title = info.ProductName;

        this.Text = string.Format("About {0}", title);
        nameLabel.Text = title;
        versionLabel.Text = string.Format("Version {0}", info.FileVersion);
        copyrightLabel.Text = info.LegalCopyright;

        this.AddReadme("changelog.md");
        this.AddReadme("readme.md");
        //this.AddReadme("acknowledgements.md");
        this.AddReadme("colorpicker-license.txt");
      }
    }

    #endregion

    #region Protected Properties

    protected TabControl TabControl
    {
      get { return docsTabControl; }
    }

    #endregion

    #region Private Members

    private void AddReadme(string fileName)
    {
      TabPage page;
      TextBox textBox;
      string fullPath;
      string text;

      fullPath = Path.GetFullPath(Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"), fileName));
      text = File.Exists(fullPath) ? File.ReadAllText(fullPath) : string.Format("Cannot find file '{0}'", fullPath);

      if (text.IndexOf('\n') != -1 && text.IndexOf('\r') == -1)
        text = text.Replace("\n", "\r\n");

      page = new TabPage
      {
        UseVisualStyleBackColor = true,
        Padding = new Padding(9),
        ToolTipText = fullPath,
        Text = fileName
      };

      textBox = new TextBox
      {
        ReadOnly = true,
        Multiline = true,
        WordWrap = true,
        ScrollBars = ScrollBars.Vertical,
        Dock = DockStyle.Fill,
        Text = text
      };

      page.Controls.Add(textBox);

      docsTabControl.TabPages.Add(page);
    }

    #endregion

    #region Event Handlers

    private void closeButton_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void footerGroupBox_Paint(object sender, PaintEventArgs e)
    {
      e.Graphics.DrawLine(SystemPens.ControlDark, 0, 0, footerGroupBox.Width, 0);
      e.Graphics.DrawLine(SystemPens.ControlLightLight, 0, 1, footerGroupBox.Width, 1);
    }

    private void webLinkLabel_Click(object sender, EventArgs e)
    {
      try
      {
        Process.Start(((Control)sender).Text);
      }
      catch (Exception ex)
      {
        MessageBox.Show(string.Format("Unable to start the specified URI.\n\n{0}", ex.Message), Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    #endregion
  }
}
