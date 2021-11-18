// Cyotek Color Picker Controls Library
// http://cyotek.com/blog/tag/colorpicker

// Copyright (c) 2013-2021 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.cyotek.com/contribute

using System;
using System.Drawing;

namespace Cyotek.Windows.Forms.Demo
{
  internal partial class ColorGridDemoForm : DemonstrationBaseForm
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

    private void AlphaRangeButton_Click(object sender, EventArgs e)
    {
      colorGrid.Colors = this.MakeShades(i => Color.FromArgb(i, Color.Goldenrod));
    }

    private void ColorGrid_ColorChanged(object sender, EventArgs e)
    {
      colorPreviewBox.Color = colorGrid.Color;

      this.UpdatePreviewText();

      propertyGrid.Refresh();
    }

    private void ColorGrid_ColorIndexChanged(object sender, EventArgs e)
    {
      this.UpdatePreviewText();
    }

    private void GrayScaleButton_Click(object sender, EventArgs e)
    {
      colorGrid.Colors = this.MakeShades(i => Color.FromArgb(i, i, i));
    }

    private void HexagonPaletteButton_Click(object sender, EventArgs e)
    {
      // NOTE: Predefined palettes can also be set via the Palette property
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

    private void NamedColorsButton_Click(object sender, EventArgs e)
    {
      // NOTE: Predefined palettes can also be set via the Palette property, e.g
      // colorGrid.Palette = ColorPalette.Named
      colorGrid.Colors = ColorPalettes.NamedColors;
    }

    private void Office2010Button_Click(object sender, EventArgs e)
    {
      // NOTE: Predefined palettes can also be set via the Palette property, e.g
      // colorGrid.Palette = ColorPalette.Office2010
      colorGrid.Colors = ColorPalettes.Office2010Standard;
      colorGrid.Columns = 10;
    }

    private void PaintNetPaletteButton_Click(object sender, EventArgs e)
    {
      // NOTE: Predefined palettes can also be set via the Palette property, e.g
      // colorGrid.Palette = ColorPalette.Paint
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
      // NOTE: Predefined palettes can also be set via the Palette property, e.g
      // colorGrid.Palette = ColorPalette.Standard
      colorGrid.Colors = ColorPalettes.QbColors;
    }

    private void UpdatePreviewText()
    {
      colorPreviewBox.Text = string.Format("{0}, {1}, {2}\r\n{3}", colorGrid.Color.R, colorGrid.Color.G, colorGrid.Color.B, colorGrid.ColorIndex);
    }

    private void Vga256ColorsButton_Click(object sender, EventArgs e)
    {
      // NOTE: Predefined palettes can also be set via the Palette property, e.g
      // colorGrid.Palette = ColorPalette.Standard256
      colorGrid.Colors = ColorPalettes.StandardPalette;
    }

    private void WebSafeColorsButton_Click(object sender, EventArgs e)
    {
      // NOTE: Predefined palettes can also be set via the Palette property, e.g
      // colorGrid.Palette = ColorPalette.WebSafe
      colorGrid.Colors = ColorPalettes.WebSafe;
    }

    #endregion Private Methods
  }
}
