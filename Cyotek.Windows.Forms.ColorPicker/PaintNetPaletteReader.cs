using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Cyotek.Windows.Forms
{
  // Cyotek Color Picker controls library
  // Copyright © 2013 Cyotek. All Rights Reserved.
  // http://cyotek.com/blog/tag/colorpicker

  // If you use this code in your applications, donations or attribution is welcome

  public class PaintNetPaletteReader : IPaletteReader
  {
    #region Constructors

    public PaintNetPaletteReader()
    { }

    public PaintNetPaletteReader(string fileName)
      : this()
    {
      this.FileName = fileName;
    }

    #endregion

    #region Properties

    public string FileName { get; set; }

    #endregion

    #region Members

    public ColorCollection ReadPalette()
    {
      ColorCollection results;

      if (string.IsNullOrEmpty(this.FileName))
        throw new InvalidOperationException("No filename specified.");

      if (!File.Exists(this.FileName))
        throw new FileNotFoundException(string.Format("Cannot find file '{0}'", this.FileName), this.FileName);

      results = new ColorCollection();

      foreach (string line in File.ReadAllLines(this.FileName).Where(line => !string.IsNullOrEmpty(line) && !line.StartsWith(";") && line.Length == 8))
      {
        int a;
        int r;
        int g;
        int b;

        a = int.Parse(line.Substring(0, 2), NumberStyles.HexNumber);
        r = int.Parse(line.Substring(2, 2), NumberStyles.HexNumber);
        g = int.Parse(line.Substring(4, 2), NumberStyles.HexNumber);
        b = int.Parse(line.Substring(6, 2), NumberStyles.HexNumber);

        results.Add(Color.FromArgb(a, r, g, b));
      }

      return results;
    }

    #endregion
  }
}
