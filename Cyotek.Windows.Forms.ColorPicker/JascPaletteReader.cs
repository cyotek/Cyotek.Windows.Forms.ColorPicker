using System;
using System.Drawing;
using System.IO;

namespace Cyotek.Windows.Forms
{
  // Cyotek Color Picker controls library
  // Copyright © 2013 Cyotek. All Rights Reserved.
  // http://cyotek.com/blog/tag/colorpicker

  // If you use this code in your applications, donations or attribution is welcome

  public class JascPaletteReader : IPaletteReader
  {
    #region Constructors

    public JascPaletteReader()
    { }

    public JascPaletteReader(string fileName)
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
      return this.ReadPalette(this.FileName);
    }

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
    public ColorCollection ReadPalette(string fileName)
    {
      ColorCollection results;

      if (string.IsNullOrEmpty(fileName))
        throw new ArgumentNullException("fileName");

      if (!File.Exists(fileName))
        throw new FileNotFoundException(string.Format("Cannot find file '{0}'", fileName), fileName);

      results = new ColorCollection();

      using (TextReader reader = new StreamReader(fileName))
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
          parts = !string.IsNullOrEmpty(data) ? data.Split(new[]
          {
            ' ', '\t'
          }, StringSplitOptions.RemoveEmptyEntries) : new string[0];

          if (!int.TryParse(parts[0], out r) || !int.TryParse(parts[1], out g) || !int.TryParse(parts[2], out b))
            throw new InvalidDataException(string.Format("Invalid palette contents found with data '{0}'", data));

          results.Add(Color.FromArgb(r, g, b));
        }
      }

      return results;
    }

    #endregion
  }
}
