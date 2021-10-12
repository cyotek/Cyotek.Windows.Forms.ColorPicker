// Cyotek Color Picker Controls Library
// http://cyotek.com/blog/tag/colorpicker

// Copyright © 2013-2021 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.cyotek.com/contribute

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms.ColorPicker.Demo
{
  internal partial class ColorSliderDemonstrationForm : BaseForm
  {
    #region Public Constructors

    public ColorSliderDemonstrationForm()
    {
      this.InitializeComponent();
    }

    #endregion Public Constructors

    #region Private Methods

    private void BackgroundToolStripColorPickerSplitButton_ColorChanged(object sender, EventArgs e)
    {
      Color color;

      color = backgroundToolStripColorPickerSplitButton.Color;

      redRgbColorSlider.Color = color;
      greenRgbColorSlider.Color = color;
      blueRgbColorSlider.Color = color;
      alphaColorSlider.Color = color;
      saturationColorSlider.Color = color;
      lightnessColorSlider.Color = color;

      propertyGrid.Refresh();
    }

    private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void GotFocusHandler(object sender, EventArgs e)
    {
      propertyGrid.SelectedObject = sender;
    }

    private void ValueChangedHandler(object sender, EventArgs e)
    {
      eventsListBox.AddEvent((Control)sender, "ValueChanged", new Dictionary<string, object>
                                                              {
                                                                {
                                                                  "Value", ((ColorSlider)sender).Value
                                                                }
                                                              });
    }

    #endregion Private Methods
  }
}
