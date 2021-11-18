// Cyotek Color Picker controls library
// Copyright © 2013-2021 Cyotek Ltd.
// http://cyotek.com/blog/tag/colorpicker

// Licensed under the MIT License. See license.txt for the full text.

// If you use this code in your applications, donations or attribution are welcome

using Cyotek.Windows.Forms.ToolStripControllerHosts;
using System;

namespace Cyotek.Windows.Forms.Demo
{
  internal partial class ToolStripHostDemoForm : DemonstrationBaseForm
  {
    #region Public Constructors

    public ToolStripHostDemoForm()
    {
      this.InitializeComponent();
    }

    #endregion Public Constructors

    #region Protected Methods

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Form.Load"/> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data. </param>
    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      textToolStripColorPickerButton.Color = previewLabel.ForeColor;
      backgroundToolStripColorPickerSplitButton.Color = previewLabel.BackColor;

      propertyGrid.SelectedObject = textToolStripColorPickerButton.Host;
    }

    #endregion Protected Methods

    #region Private Methods

    private void BackgroundToolStripColorPickerSplitButton_ColorChanged(object sender, EventArgs e)
    {
      previewLabel.BackColor = ((ToolStripColorPickerSplitButton)sender).Color;
    }

    private void BlogLinkLabel_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
    {
      AboutDialog.OpenUrl("https://www.cyotek.com/blog/hosting-a-colorgrid-control-in-a-toolstrip");
    }

    private void TextToolStripColorPickerButton_ColorChanged(object sender, EventArgs e)
    {
      previewLabel.ForeColor = ((ToolStripColorPickerSplitButton)sender).Color;
    }

    #endregion Private Methods
  }
}
