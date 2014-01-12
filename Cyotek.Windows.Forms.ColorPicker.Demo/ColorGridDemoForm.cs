using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Cyotek.Windows.Forms.ColorPicker.Demo
{
  // Cyotek Color Picker controls library
  // Copyright © 2013-2014 Cyotek.
  // http://cyotek.com/blog/tag/colorpicker

  // Licensed under the MIT License. See colorpicker-license.txt for the full text.

  // If you use this code in your applications, donations or attribution are welcome

  internal partial class ColorGridDemoForm : BaseForm
  {
    #region Public Constructors

    public ColorGridDemoForm()
    {
      InitializeComponent();
    }

    #endregion

    #region Overridden Methods

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      colorGrid.Color = Color.SeaGreen;
    }

    #endregion

    #region Event Handlers

    private void addCustomColorsButton_Click(object sender, EventArgs e)
    {
      colorGrid.CustomColors = ColorPalettes.QbColors;
    }

    private void addNewColorButton_Click(object sender, EventArgs e)
    {
      int r;
      int g;
      int b;
      int a;
      Random random;

      random = new Random();
      r = random.Next(0, 254);
      g = random.Next(0, 254);
      b = random.Next(0, 254);
      a = random.Next(0, 254);

      colorGrid.Color = Color.FromArgb(a, r, g, b);
    }

    private void closeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void colorGrid_ColorChanged(object sender, EventArgs e)
    {
      optionsSplitContainer.Panel2.BackColor = colorGrid.Color;

      colorToolStripStatusLabel.Text = string.Format("{0}, {1}, {2}", colorGrid.Color.R, colorGrid.Color.G, colorGrid.Color.B);
    }

    private void grayScaleButton_Click(object sender, EventArgs e)
    {
      colorGrid.Colors = new ColorCollection(Enumerable.Range(0, 254).Select(i => Color.FromArgb(i, i, i)));
    }

    private void hexagonPaletteButton_Click(object sender, EventArgs e)
    {
      // NOTE: Predefined palettes can now be set via the Palette property
      colorGrid.Colors = ColorPalettes.HexagonPalette;
    }

    private void jascPaletteFileButton_Click(object sender, EventArgs e)
    {
      colorGrid.Colors = new JascPaletteSerializer().Deserialize(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"palettes\Hex256.pal"));
    }

    private void loadGimpPaletteButton_Click(object sender, EventArgs e)
    {
      colorGrid.Colors = new GimpPaletteSerializer().Deserialize(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"palettes\db32.gpl"));
    }

    private void office2010Button_Click(object sender, EventArgs e)
    {
      // NOTE: Predefined palettes can now be set via the Palette property (this does not affect other properties such as Columns below though!)
      colorGrid.Colors = ColorPalettes.Office2010Standard;
      colorGrid.Columns = 10;
    }

    private void paintNetPaletteButton_Click(object sender, EventArgs e)
    {
      // NOTE: Predefined palettes can now be set via the Palette property
      colorGrid.Colors = ColorPalettes.PaintPalette;
    }

    private void paintNetPaletteFileButton_Click(object sender, EventArgs e)
    {
      colorGrid.Colors = new PaintNetPaletteSerializer().Deserialize(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"palettes\PaintNet.txt"));
    }

    private void resetCustomColorsButton_Click(object sender, EventArgs e)
    {
      colorGrid.CustomColors = new ColorCollection(Enumerable.Repeat(Color.White, 32));
    }

    private void shadesOfBlueButton_Click(object sender, EventArgs e)
    {
      colorGrid.Colors = new ColorCollection(Enumerable.Range(0, 254).Select(i => Color.FromArgb(0, 0, i)));
    }

    private void shadesOfGreenButton_Click(object sender, EventArgs e)
    {
      colorGrid.Colors = new ColorCollection(Enumerable.Range(0, 254).Select(i => Color.FromArgb(0, i, 0)));
    }

    private void shadesOfRedButton_Click(object sender, EventArgs e)
    {
      colorGrid.Colors = new ColorCollection(Enumerable.Range(0, 254).Select(i => Color.FromArgb(i, 0, 0)));
    }

    private void standardColorsButton_Click(object sender, EventArgs e)
    {
      // NOTE: Predefined palettes can now be set via the Palette property
      colorGrid.Colors = ColorPalettes.NamedColors;
    }

    #endregion
  }
}
