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

namespace Cyotek.Windows.Forms.Demo
{
  internal partial class ColorSliderDemonstrationForm : DemonstrationBaseForm
  {
    #region Private Fields

    private ColorSlider[] _sliderControls;

    #endregion Private Fields

    #region Public Constructors

    public ColorSliderDemonstrationForm()
    {
      this.InitializeComponent();
    }

    #endregion Public Constructors

    #region Protected Methods

    protected override void OnLoad(EventArgs e)
    {
      _sliderControls = new ColorSlider[]
      {
        redRgbColorSlider,
        greenRgbColorSlider,
        blueRgbColorSlider,
        alphaColorSlider,
        hueColorSlider,
        saturationColorSlider,
        lightnessColorSlider,
        verticalColorSlider,
        verticalLeftColorSlider,
        verticalRightColorSlider,
        horizontalColorSlider,
        horizontalTopColorSlider,
        horizontalBottomColorSlider
      };

      base.OnLoad(e);
    }

    #endregion Protected Methods

    #region Private Methods

    private void BackgroundFillToolStripColorPickerSplitButton_ColorChanged(object sender, EventArgs e)
    {
      tableLayoutPanel.BackColor = backgroundFillToolStripColorPickerSplitButton.Color;
    }

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
      verticalColorSlider.Color = color;
      verticalLeftColorSlider.Color = color;
      verticalRightColorSlider.Color = color;
      horizontalColorSlider.Color = color;
      horizontalTopColorSlider.Color = color;
      horizontalBottomColorSlider.Color = color;

      propertyGrid.Refresh();
    }

    private void GotFocusHandler(object sender, EventArgs e)
    {
      propertyGrid.SelectedObject = sender;
    }

    private bool IsValidSize(int v)
    {
      return v >= 3 && v <= 16;
    }

    private void NubColorToolStripColorPickerSplitButton_ColorChanged(object sender, EventArgs e)
    {
      this.UpdateSliders((s, a) => s.NubColor = a, nubColorToolStripColorPickerSplitButton.Color);
    }

    private void NubOutlineColorToolStripColorPickerSplitButton_ColorChanged(object sender, EventArgs e)
    {
      this.UpdateSliders((s, a) => s.NubOutlineColor = a, nubOutlineColorToolStripColorPickerSplitButton.Color);
    }

    private void NubWidthToolStripTextBox_TextChanged(object sender, EventArgs e)
    {
      if (int.TryParse(nubWidthToolStripTextBox.Text, out int w)
          && int.TryParse(nubHeightToolStripTextBox.Text, out int h)
          && this.IsValidSize(w)
          && this.IsValidSize(h))
      {
        this.UpdateSliders((s, a) => s.NubSize = a, new Size(w, h));
      }
    }

    private void ShowValueDividerToolStripButton_CheckedChanged(object sender, EventArgs e)
    {
      this.UpdateSliders((s, a) => s.ShowValueDivider = a, showValueDividerToolStripButton.Checked);
    }

    private void UpdateSliders<T>(Action<ColorSlider, T> action, T value)
    {
      for (int i = 0; i < _sliderControls.Length; i++)
      {
        action(_sliderControls[i], value);
      }

      propertyGrid.Refresh();
    }

    private void ValueChangedHandler(object sender, EventArgs e)
    {
      eventsListBox.AddEvent((Control)sender, "ValueChanged", new Dictionary<string, object>
                                                              {
                                                                {
                                                                  "Value", ((ColorSlider)sender).Value
                                                                }
                                                              });

      propertyGrid.Refresh();
    }

    #endregion Private Methods
  }
}
