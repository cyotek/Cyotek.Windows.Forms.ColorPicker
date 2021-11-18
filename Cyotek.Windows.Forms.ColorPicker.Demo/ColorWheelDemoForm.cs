// Cyotek Color Picker Controls Library
// http://cyotek.com/blog/tag/colorpicker

// Copyright (c) 2013-2021 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.cyotek.com/contribute

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms.Demo
{
  internal partial class ColorWheelDemoForm : DemonstrationBaseForm
  {
    #region Private Fields

    private readonly Random _random;

    private Button _lastButton;

    #endregion Private Fields

    #region Public Constructors

    public ColorWheelDemoForm()
    {
      this.InitializeComponent();

      _random = new Random(20211116);
    }

    #endregion Public Constructors

    #region Internal Methods

    internal static HslColor ChangeHue(HslColor color, double increment)
    {
      HslColor copy;
      double value;

      copy = new HslColor(color);
      value = copy.H + increment;

      if (increment > 0 && value > 359)
      {
        value -= 360;
      }
      else if (increment < 0 && value < 0)
      {
        value += 360;
      }

      copy.H = value;

      return copy;
    }

    #endregion Internal Methods

    #region Protected Methods

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      colorWheel.Color = Color.MediumTurquoise;
    }

    #endregion Protected Methods

    #region Private Methods

    private void AnalogousButton_Click(object sender, EventArgs e)
    {
      _lastButton = (Button)sender;

      colorWheel.SecondaryColors = new[]
      {
        ColorWheelDemoForm.ChangeHue(colorWheel.HslColor, -30),
        ColorWheelDemoForm.ChangeHue(colorWheel.HslColor, 30)
      };
    }

    private void ColorWheel_ColorChanged(object sender, EventArgs e)
    {
      colorPreviewBox.Color = colorWheel.Color;

      propertyGrid.Refresh();

      if (automaticSecondaryCheckBox.Checked && _lastButton != null)
      {
        _lastButton.PerformClick();
      }
    }

    private void NoneButton_Click(object sender, EventArgs e)
    {
      colorWheel.SecondaryColors = null;
      _lastButton = null;
    }

    private void RandomButton_Click(object sender, EventArgs e)
    {
      HslColor[] colors;
      int count;

      _lastButton = null;

      count = 5;
      colors = new HslColor[count];

      for (int i = 0; i < count; i++)
      {
        double h;
        double s;

        h = _random.Next(0, 360);
        s = _random.NextDouble();

        colors[i] = new HslColor(h, s, 0.5);
      }

      colorWheel.SecondaryColors = colors;
    }

    private void TetradicButton_Click(object sender, EventArgs e)
    {
      _lastButton = (Button)sender;

      colorWheel.SecondaryColors = new[]
      {
        ColorWheelDemoForm.ChangeHue(colorWheel.HslColor, -60),
        ColorWheelDemoForm.ChangeHue(colorWheel.HslColor, -180),
        ColorWheelDemoForm.ChangeHue(colorWheel.HslColor, -240)
      };
    }

    #endregion Private Methods
  }
}
