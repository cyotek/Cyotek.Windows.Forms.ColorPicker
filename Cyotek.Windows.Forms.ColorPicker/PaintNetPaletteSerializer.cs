using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;

namespace Cyotek.Windows.Forms
{
  // Cyotek Color Picker controls library
  // Copyright © 2013 Cyotek. All Rights Reserved.
  // http://cyotek.com/blog/tag/colorpicker

  // If you use this code in your applications, donations or attribution are welcome

  /// <summary>
  /// Serializes and deserializes color palettes into and from the Paint.NET palette format.
  /// </summary>
  public class PaintNetPaletteSerializer : PaletteSerializer
  {
    #region Overridden Properties

    /// <summary>
    /// Gets the default extension for files generated with this palette format.
    /// </summary>
    /// <value>The default extension for files generated with this palette format.</value>
    public override string DefaultExtension
    {
      get { return ".txt"; }
    }

    /// <summary>
    /// Gets a descriptive name of the palette format
    /// </summary>
    /// <value>The descriptive name of the palette format.</value>
    public override string Name
    {
      get { return "Paint.NET Palette"; }
    }

    #endregion

    #region Overridden Members

    /// <summary>
    /// Deserializes the <see cref="ColorCollection" /> contained by the specified <see cref="Stream" />.
    /// </summary>
    /// <param name="stream">The <see cref="Stream" /> that contains the palette to deserialize.</param>
    /// <returns>The <see cref="ColorCollection" /> being deserialized..</returns>
    public override ColorCollection Deserialize(Stream stream)
    {
      ColorCollection results;

      if (stream == null)
        throw new ArgumentNullException("stream");

      results = new ColorCollection();

      using (StreamReader reader = new StreamReader(stream))
      {
        while (!reader.EndOfStream)
        {
          string line;

          line = reader.ReadLine();
          if (!string.IsNullOrEmpty(line) && !line.StartsWith(";") && line.Length == 8)
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
        }
      }

      return results;
    }

    /// <summary>
    /// Serializes the specified <see cref="ColorCollection" /> and writes the palette to a file using the specified <see cref="Stream" />.
    /// </summary>
    /// <param name="stream">The <see cref="Stream" /> used to write the palette.</param>
    /// <param name="palette">The <see cref="ColorCollection" /> to serialize.</param>
    public override void Serialize(Stream stream, ColorCollection palette)
    {
      if (stream == null)
        throw new ArgumentNullException("stream");

      if (palette == null)
        throw new ArgumentNullException("palette");

      // TODO: Not writing 96 colors, but the entire contents of the palette, wether that's less than 96 or more

      using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
      {
        writer.WriteLine(@"; Paint.NET Palette File
; Lines that start with a semicolon are comments
; Colors are written as 8-digit hexadecimal numbers: aarrggbb
; For example, this would specify green: FF00FF00
; The alpha ('aa') value specifies how transparent a color is. FF is fully opaque, 00 is fully transparent.
; A palette must consist of ninety six (96) colors. If there are less than this, the remaining color
; slots will be set to white (FFFFFFFF). If there are more, then the remaining colors will be ignored.");
        foreach (Color color in palette)
          writer.WriteLine("{0:X2}{1:X2}{2:X2}{3:X2}", color.A, color.R, color.G, color.B);
      }
    }

    #endregion
  }
}
