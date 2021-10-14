// Cyotek Color Picker Controls Library
// http://cyotek.com/blog/tag/colorpicker

// Copyright (c) 2013-2021 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.cyotek.com/contribute

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms.ColorPicker.Demo
{
  internal partial class ScreenColorPickerDemoForm : BaseForm
  {
    #region Public Constructors

    public ScreenColorPickerDemoForm()
    {
      this.InitializeComponent();
    }

    #endregion Public Constructors

    #region Private Methods

    private void CaptureButton_Click(object sender, EventArgs e)
    {
      screenColorPicker.CaptureMouse();
    }

    private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void ReleaseButton_Click(object sender, EventArgs e)
    {
      screenColorPicker.ReleaseMouse();
    }

    private void ScreenColorPicker_ColorChanged(object sender, EventArgs e)
    {
      colorPreviewBox.Color = screenColorPicker.Color;
    }

    private void ScreenColorPicker_Selected(object sender, EventArgs e)
    {
      eventsListBox.AddEvent((Control)sender, nameof(ScreenColorPicker.Selected));
    }

    private void ScreenColorPicker_Selecting(object sender, CancelEventArgs e)
    {
      eventsListBox.AddEvent((Control)sender, nameof(ScreenColorPicker.Selecting), new Dictionary<string, object>
      {
        { nameof(CancelEventArgs.Cancel) ,e.Cancel }
      });
    }

    #endregion Private Methods
  }
}
