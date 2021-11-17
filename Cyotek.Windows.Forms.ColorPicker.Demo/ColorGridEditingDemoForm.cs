// Cyotek Color Picker Controls Library
// http://cyotek.com/blog/tag/colorpicker

// Copyright (c) 2021 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.cyotek.com/contribute

using Cyotek.Demo.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms.ColorPicker.Demo
{
  internal partial class ColorGridEditingDemoForm : BaseForm
  {
    #region Public Constructors

    public ColorGridEditingDemoForm()
    {
      this.InitializeComponent();
    }

    #endregion Public Constructors

    #region Protected Methods

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      editModeComboBox.SelectedIndex = (int)ColorEditingMode.CustomOnly;
    }

    #endregion Protected Methods

    #region Private Methods

    private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void ColorGrid_ColorChanged(object sender, EventArgs e)
    {
      eventsListBox.AddEvent((Control)sender, nameof(ColorGrid.ColorChanged));
    }

    private void ColorGrid_ColorIndexChanged(object sender, EventArgs e)
    {
      eventsListBox.AddEvent((Control)sender, nameof(ColorGrid.ColorIndexChanged));
    }

    private void ColorGrid_EditingColor(object sender, EditColorCancelEventArgs e)
    {
      eventsListBox.AddEvent((Control)sender, nameof(ColorGrid.EditingColor), new Dictionary<string, object> { { nameof(EditColorCancelEventArgs.Color), e.Color }, { nameof(EditColorCancelEventArgs.ColorIndex), e.ColorIndex }, { nameof(EditColorCancelEventArgs.Cancel), e.Cancel } });
    }

    private void EditModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      colorGrid.EditMode = (ColorEditingMode)editModeComboBox.SelectedIndex;
    }

    #endregion Private Methods
  }
}
