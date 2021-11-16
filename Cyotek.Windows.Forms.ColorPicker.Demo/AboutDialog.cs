// Cyotek Color Picker Controls Library
// http://cyotek.com/blog/tag/colorpicker

// Copyright © 2013-2021 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.cyotek.com/contribute

using CommonMark;
using Cyotek.Demo.Windows.Forms;
using Cyotek.Windows.Forms.ColorPicker.Demo.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using TheArtOfDev.HtmlRenderer.WinForms;

namespace Cyotek.Windows.Forms.ColorPicker.Demo
{
  internal partial class AboutDialog : BaseForm
  {
    #region Public Constructors

    public AboutDialog()
    {
      this.InitializeComponent();
    }

    #endregion Public Constructors

    #region Protected Properties

    protected TabControl TabControl => docsTabControl;

    #endregion Protected Properties

    #region Internal Methods

    internal static void ShowAboutDialog()
    {
      using (Form dialog = new AboutDialog())
      {
        dialog.ShowDialog();
      }
    }

    #endregion Internal Methods

    #region Protected Methods

    protected override void OnFontChanged(EventArgs e)
    {
      base.OnFontChanged(e);

      this.SetBoldFonts();
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      if (!this.DesignMode)
      {
        FileVersionInfo info;
        Assembly assembly;
        string title;

        assembly = typeof(ColorGrid).Assembly;
        info = FileVersionInfo.GetVersionInfo(assembly.Location);
        title = info.ProductName;

        this.Text = string.Format("About {0}", title);
        nameLabel.Text = title;
        versionLabel.Text = string.Format("Version {0}", ((AssemblyInformationalVersionAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyInformationalVersionAttribute))).InformationalVersion);
        copyrightLabel.Text = info.LegalCopyright;

        this.AddReadme("CHANGELOG.md");
        this.AddReadme("README.md");
        this.AddReadme("LICENSE.txt");

        this.LoadDocumentForTab(docsTabControl.SelectedTab);

        this.SetBoldFonts();
      }
    }

    #endregion Protected Methods

    #region Private Methods

    private void AddReadme(string fileName)
    {
      docsTabControl.TabPages.Add(new TabPage
      {
        UseVisualStyleBackColor = true,
        Padding = new Padding(9),
        ToolTipText = this.GetFullReadmePath(fileName),
        Text = this.GetFileLabel(fileName),
        Tag = fileName
      });
    }

    private void CloseButton_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void DocsTabControl_Selecting(object sender, TabControlCancelEventArgs e)
    {
      this.LoadDocumentForTab(e.TabPage);
    }

    private void FooterGroupBox_Paint(object sender, PaintEventArgs e)
    {
      e.Graphics.DrawLine(SystemPens.ControlDark, 0, 0, footerGroupBox.Width, 0);
      e.Graphics.DrawLine(SystemPens.ControlLightLight, 0, 1, footerGroupBox.Width, 1);
    }

    private string GetFileLabel(string fileName) => CultureInfo.CurrentUICulture.TextInfo.ToTitleCase(Path.GetFileNameWithoutExtension(fileName).ToLower());

    private string GetFullReadmePath(string fileName) => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "docs", fileName);

    private void HtmlPanelImageLoadHandler(object sender, TheArtOfDev.HtmlRenderer.Core.Entities.HtmlImageLoadEventArgs e)
    {
      if (e.Src.StartsWith("https://img.shields.io/", StringComparison.OrdinalIgnoreCase))
      {
        e.Callback("https://raster.shields.io/" + e.Src.Substring(23) + ".png");
      }
      else if (e.Src.StartsWith("res/", StringComparison.OrdinalIgnoreCase))
      {
        e.Callback(this.GetFullReadmePath(e.Src.Substring(4)));
      }
    }

    private void LoadDocumentForTab(TabPage page)
    {
      if (page != null && page.Controls.Count == 0 && page.Tag != null)
      {
        HtmlPanel documentView;
        string fullPath;
        string text;

        Cursor.Current = Cursors.WaitCursor;

        fullPath = this.GetFullReadmePath(page.Tag.ToString());
        text = File.Exists(fullPath)
          ? File.ReadAllText(fullPath)
          : string.Format("Cannot find file '{0}'", fullPath);

        documentView = new HtmlPanel
        {
          Dock = DockStyle.Fill,
          BaseStylesheet = Resources.CSS,
          Text = "<html><body>" + CommonMarkConverter.Convert(text) + "</body></html>" // HACK: HTML panel screws up rendering if a <body> tag isn't present
        };
        documentView.ImageLoad += this.HtmlPanelImageLoadHandler;

        page.Controls.Add(documentView);

        Cursor.Current = Cursors.Default;
      }
    }

    private void SetBoldFonts()
    {
      Font boldFont;

      boldFont = new Font(this.Font, FontStyle.Bold);
      nameLabel.Font = boldFont;
      versionLabel.Font = boldFont;
    }

    private void WebLinkLabel_Click(object sender, EventArgs e)
    {
      try
      {
        Process.Start(((Control)sender).Text);
      }
      catch (Exception ex)
      {
        MessageBox.Show(string.Format("Unable to start the specified URI.\n\n{0}", ex.Message), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    #endregion Private Methods
  }
}
