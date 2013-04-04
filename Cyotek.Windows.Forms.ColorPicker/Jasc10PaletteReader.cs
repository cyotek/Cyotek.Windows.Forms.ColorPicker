using System;
using System.Drawing;
using System.IO;

namespace Cyotek.Windows.Forms
{
  // Cyotek Color Picker controls library
  // Copyright © 2013 Cyotek. All Rights Reserved.
  // http://cyotek.com/blog/tag/colorpicker

  // If you use this code in your applications, donations or attribution is welcome

  public class Jasc10PaletteReader : IPaletteReader
  {
    #region Constructors

    public Jasc10PaletteReader()
    { }

    public Jasc10PaletteReader(string fileName)
      : this()
    {
      this.FileName = fileName;
    }

    #endregion

    #region Properties

    public string FileName { get; set; }

    #endregion

    #region Members

    /// <summary>
    /// Reads the palette.
    /// </summary>
    /// <returns>ColorCollection.</returns>
    /// <exception cref="System.InvalidOperationException">No filename specified.</exception>
    /// <exception cref="System.IO.FileNotFoundException"></exception>
    /// <exception cref="System.IO.InvalidDataException">
    /// Invalid palette file
    /// or
    /// </exception>
    public ColorCollection ReadPalette()
    {
      ColorCollection results;

      if (string.IsNullOrEmpty(this.FileName))
        throw new InvalidOperationException("No filename specified.");

      if (!File.Exists(this.FileName))
        throw new FileNotFoundException(string.Format("Cannot find file '{0}'", this.FileName), this.FileName);

      results = new ColorCollection();

      using (TextReader reader = new StreamReader(this.FileName))
      {
        string header;
        string version;
        int colorCount;

        // check signature
        header = reader.ReadLine();
        version = reader.ReadLine();

        if (header != "JASC-PAL" || version != "0100")
          throw new InvalidDataException("Invalid palette file");

        colorCount = Convert.ToInt32(reader.ReadLine());
        for (int i = 0; i < colorCount; i++)
        {
          int r;
          int g;
          int b;
          string data;
          string[] parts;

          data = reader.ReadLine();
          parts = !string.IsNullOrEmpty(data) ? data.Split(' ') : new string[0];

          if (parts.Length != 3)
            throw new InvalidDataException(string.Format("Invalid palette contents found at index {0}", i));

          r = Convert.ToInt32(parts[0]);
          g = Convert.ToInt32(parts[1]);
          b = Convert.ToInt32(parts[2]);

          results.Add(Color.FromArgb(r, g, b));
        }
      }

      return results;
    }

    #endregion
  }
}
