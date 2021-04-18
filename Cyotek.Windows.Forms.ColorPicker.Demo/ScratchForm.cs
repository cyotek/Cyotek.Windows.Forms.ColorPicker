using System;
using System.IO;
using System.Windows.Forms;

// Cyotek Color Picker controls library
// Copyright © 2013-2017 Cyotek Ltd.
// http://cyotek.com/blog/tag/colorpicker

// Licensed under the MIT License. See license.txt for the full text.

// If you use this code in your applications, donations or attribution are welcome

namespace Cyotek.Windows.Forms.ColorPicker.Demo
{
  public partial class ScratchForm : Form
  {
    #region Constructors

    public ScratchForm()
    {
      this.InitializeComponent();
    }

    #endregion

    #region Methods

    private void ScratchForm_Load(object sender, EventArgs e)
    {
      string fileName;
      ColorCollection source;
      ColorCollection destination;
      AdobePhotoshopColorSwatchSerializer serializer;

      fileName = Path.GetTempFileName();
      //source = ColorCollection.LoadPalette(Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "palettes"), "grayscale.pal"));
      source = ColorCollection.LoadPalette(Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "palettes"), "db32.gpl"));
      serializer = new AdobePhotoshopColorSwatchSerializer();

      using (Stream stream = File.Create(fileName))
      {
        serializer.Serialize(stream, source, AdobePhotoshopColorSwatchColorSpace.Hsb);
        //serializer.Serialize(stream, source, AdobePhotoShopColorSwatchColorSpace.Grayscale);
      }

      destination = ColorCollection.LoadPalette(fileName);

      colorGrid1.Colors = source;
      colorGrid2.Colors = destination;

      File.Delete(fileName);
    }

    #endregion
  }
}
