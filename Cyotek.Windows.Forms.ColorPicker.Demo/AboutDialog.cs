using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms.ColorPicker.Demo
{
  // Cyotek Color Picker controls library
  // Copyright © 2013 Cyotek. All Rights Reserved.
  // http://cyotek.com/blog/tag/colorpicker

  // If you use this code in your applications, donations or attribution is welcome

  internal partial class AboutDialog : BaseForm
  {
    #region Constructors

    public AboutDialog()
    {
      FileVersionInfo info;
      Assembly assembly;
      string title;

      this.InitializeComponent();

      assembly = typeof(ColorGrid).Assembly;
      info = FileVersionInfo.GetVersionInfo(assembly.Location);
      title = info.ProductName;

      this.Text = string.Format("About {0}", title);
      nameLabel.Text = title;
      versionLabel.Text = string.Format("Version {0}", info.FileVersion);
      copyrightLabel.Text = info.LegalCopyright;
    }

    #endregion

    #region Event Handlers

    private void closeButton_Click(object sender, EventArgs e)
    {
      this.Close();
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
