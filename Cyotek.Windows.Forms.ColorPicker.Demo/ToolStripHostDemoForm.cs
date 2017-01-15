using System;

// Cyotek Color Picker controls library
// Copyright © 2013-2015 Cyotek Ltd.
// http://cyotek.com/blog/tag/colorpicker

// Licensed under the MIT License. See license.txt for the full text.

// If you use this code in your applications, donations or attribution are welcome

namespace Cyotek.Windows.Forms.ColorPicker.Demo
{
  internal partial class ToolStripHostDemoForm : BaseForm
  {
    #region Constructors

    public ToolStripHostDemoForm()
    {
      this.InitializeComponent();
    }

    #endregion

    #region Methods

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

    private void backgroundToolStripColorPickerSplitButton_ColorChanged(object sender, EventArgs e)
    {
      previewLabel.BackColor = backgroundToolStripColorPickerSplitButton.Color;
    }

    private void closeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void textToolStripColorPickerButton_ColorChanged(object sender, EventArgs e)
    {
      previewLabel.ForeColor = textToolStripColorPickerButton.Color;
    }

    #endregion
  }
}
