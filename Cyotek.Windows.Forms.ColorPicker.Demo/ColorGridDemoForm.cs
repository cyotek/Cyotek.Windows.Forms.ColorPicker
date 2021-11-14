// Cyotek Color Picker Controls Library
// http://cyotek.com/blog/tag/colorpicker

// Copyright (c) 2013-2021 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.cyotek.com/contribute

using Cyotek.Demo.Windows.Forms;
using System;
using System.Drawing;
using System.Linq;

namespace Cyotek.Windows.Forms.ColorPicker.Demo
{
  internal partial class ColorGridDemoForm : BaseForm
  {
    #region Private Fields

    private readonly Random _random;

    #endregion Private Fields

    #region Public Constructors

    public ColorGridDemoForm()
    {
      this.InitializeComponent();

      _random = new Random(20211114);
    }

    #endregion Public Constructors

    #region Private Methods

    private void AddCustomColorsButton_Click(object sender, EventArgs e)
    {
      colorGrid.CustomColors = ColorPalettes.QbColors;
    }

    private void AddNewColorButton_Click(object sender, EventArgs e)
    {
      int r;
      int g;
      int b;
      int a;

      r = _random.Next(0, 256);
      g = _random.Next(0, 256);
      b = _random.Next(0, 256);
      a = _random.Next(0, 256);

      colorGrid.Color = Color.FromArgb(a, r, g, b);
    }

    private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void ColorGrid_ColorChanged(object sender, EventArgs e)
    {
      optionsSplitContainer.Panel2.BackColor = colorGrid.Color;

      colorToolStripStatusLabel.Text = string.Format("{0}, {1}, {2}", colorGrid.Color.R, colorGrid.Color.G, colorGrid.Color.B);

      propertyGrid.Refresh();
    }

    private void ColorGrid_ColorIndexChanged(object sender, EventArgs e)
    {
      colorIndexToolStripStatusLabel.Text = colorGrid.ColorIndex.ToString();
    }

    private void GrayScaleButton_Click(object sender, EventArgs e)
    {
      colorGrid.Colors = this.MakeShades(i => Color.FromArgb(i, i, i));
    }

    private void HexagonPaletteButton_Click(object sender, EventArgs e)
    {
      // NOTE: Predefined palettes can now be set via the Palette property
      colorGrid.Colors = ColorPalettes.HexagonPalette;
    }

    private ColorCollection MakeShades(Func<int, Color> createColor)
    {
      ColorCollection colors;

      colors = new ColorCollection();

      for (int i = 0; i < 256; i++)
      {
        colors.Add(createColor(i));
      }

      return colors;
    }

    private void Office2010Button_Click(object sender, EventArgs e)
    {
      // NOTE: Predefined palettes can now be set via the Palette property (this does not affect other properties such as Columns below though!)
      colorGrid.Colors = ColorPalettes.Office2010Standard;
      colorGrid.Columns = 10;
    }

    private void PaintNetPaletteButton_Click(object sender, EventArgs e)
    {
      // NOTE: Predefined palettes can now be set via the Palette property
      colorGrid.Colors = ColorPalettes.PaintPalette;
      colorGrid.Columns = 16;
    }

    private void ResetCustomColorsButton_Click(object sender, EventArgs e)
    {
      colorGrid.CustomColors.Clear();
    }

    private void ShadesOfBlueButton_Click(object sender, EventArgs e)
    {
      colorGrid.Colors = this.MakeShades(i => Color.FromArgb(0, 0, i));
    }

    private void ShadesOfGreenButton_Click(object sender, EventArgs e)
    {
      colorGrid.Colors = this.MakeShades(i => Color.FromArgb(0, i, 0));
    }

    private void ShadesOfRedButton_Click(object sender, EventArgs e)
    {
      colorGrid.Colors = this.MakeShades(i => Color.FromArgb(i, 0, 0));
    }

    private void StandardColorsButton_Click(object sender, EventArgs e)
    {
      colorGrid.Colors = ColorPalettes.NamedColors;
    }

    private void Vga256ColorsButton_Click(object sender, EventArgs e)
    {
      colorGrid.Colors = ColorPalettes.StandardPalette;
    }

    private void WebSafeColorsButton_Click(object sender, EventArgs e)
    {
      colorGrid.Colors = ColorPalettes.WebSafe;
    }

    #endregion Private Methods

    private void AlphaRangeButton_Click(object sender, EventArgs e)
    {
      colorGrid.Colors = this.MakeShades(i => Color.FromArgb(i, Color.Goldenrod));
    }
  }
}
