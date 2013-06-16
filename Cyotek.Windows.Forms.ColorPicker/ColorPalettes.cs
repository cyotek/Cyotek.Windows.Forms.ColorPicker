using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;

#if USEEXTERNALCYOTEKLIBS
using Cyotek.Drawing;
#endif

namespace Cyotek.Windows.Forms
{
  // Cyotek Color Picker controls library
  // Copyright © 2013 Cyotek. All Rights Reserved.
  // http://cyotek.com/blog/tag/colorpicker

  // If you use this code in your applications, donations or attribution is welcome

  public static class ColorPalettes
  {
    #region Class Properties

    public static ColorCollection HexagonPalette
    {
      get
      {
        return new ColorCollection(new[]
        {
          Color.FromArgb(0, 48, 96), Color.FromArgb(47, 96, 144), Color.FromArgb(47, 96, 192), Color.FromArgb(0, 48, 144), Color.FromArgb(0, 0, 144), Color.FromArgb(0, 0, 207), Color.FromArgb(0, 0, 96), Color.FromArgb(0, 96, 96), Color.FromArgb(0, 96, 144), Color.FromArgb(0, 151, 192), Color.FromArgb(0, 103, 207), Color.FromArgb(0, 48, 207), Color.FromArgb(0, 0, 255), Color.FromArgb(48, 48, 255), Color.FromArgb(48, 48, 144), Color.FromArgb(96, 152, 144), Color.FromArgb(0, 152, 159), Color.FromArgb(48, 200, 207), Color.FromArgb(0, 200, 255), Color.FromArgb(0, 152, 255), Color.FromArgb(0, 103, 255), Color.FromArgb(48, 103, 255), Color.FromArgb(48, 48, 192), Color.FromArgb(96, 103, 144), Color.FromArgb(48, 152, 96), Color.FromArgb(0, 200, 144), Color.FromArgb(0, 200, 192), Color.FromArgb(0, 255, 255), Color.FromArgb(48, 200, 255), Color.FromArgb(48, 151, 255), Color.FromArgb(96, 151, 255), Color.FromArgb(96, 96, 255), Color.FromArgb(95, 0, 255), Color.FromArgb(96, 0, 192), Color.FromArgb(48, 151, 48), Color.FromArgb(0, 200, 96), Color.FromArgb(0, 255, 144), Color.FromArgb(96, 255, 207), Color.FromArgb(96, 255, 255), Color.FromArgb(96, 200, 255), Color.FromArgb(144, 200, 255), Color.FromArgb(144, 151, 255), Color.FromArgb(144, 103, 255), Color.FromArgb(144, 48, 255), Color.FromArgb(144, 0, 255), Color.FromArgb(0, 96, 0), Color.FromArgb(0, 200, 0), Color.FromArgb(0, 255, 0), Color.FromArgb(96, 255, 144), Color.FromArgb(144, 255, 192), Color.FromArgb(207, 255, 255), Color.FromArgb(192, 200, 255), Color.FromArgb(192, 151, 255), Color.FromArgb(192, 96, 255), Color.FromArgb(192, 48, 255), Color.FromArgb(192, 0, 255), Color.FromArgb(144, 0, 192), Color.FromArgb(0, 48, 0), Color.FromArgb(0, 152, 48), Color.FromArgb(47, 200, 47), Color.FromArgb(96, 255, 96), Color.FromArgb(144, 255, 144), Color.FromArgb(207, 255, 207), Color.FromArgb(255, 255, 255), Color.FromArgb(255, 200, 255), Color.FromArgb(255, 151, 255), Color.FromArgb(255, 104, 255), Color.FromArgb(255, 0, 255), Color.FromArgb(207, 0, 207), Color.FromArgb(96, 0, 96), Color.FromArgb(47, 96, 0), Color.FromArgb(0, 152, 0), Color.FromArgb(96, 255, 48), Color.FromArgb(144, 255, 96), Color.FromArgb(192, 255, 144), Color.FromArgb(255, 255, 207), Color.FromArgb(255, 200, 207), Color.FromArgb(255, 151, 207), Color.FromArgb(255, 96, 192), Color.FromArgb(255, 48, 207), Color.FromArgb(207, 0, 144), Color.FromArgb(144, 47, 144), Color.FromArgb(48, 48, 0), Color.FromArgb(96, 151, 0), Color.FromArgb(144, 255, 47), Color.FromArgb(207, 255, 96), Color.FromArgb(255, 255, 144), Color.FromArgb(255, 200, 144), Color.FromArgb(255, 152, 96), Color.FromArgb(255, 96, 144), Color.FromArgb(255, 48, 144), Color.FromArgb(207, 48, 144), Color.FromArgb(144, 0, 144), Color.FromArgb(96, 96, 47), Color.FromArgb(144, 200, 0), Color.FromArgb(192, 255, 57), Color.FromArgb(255, 255, 96), Color.FromArgb(255, 200, 96), Color.FromArgb(255, 152, 96), Color.FromArgb(255, 96, 96), Color.FromArgb(255, 0, 96), Color.FromArgb(207, 103, 144), Color.FromArgb(144, 48, 96), Color.FromArgb(144, 151, 96), Color.FromArgb(192, 200, 0), Color.FromArgb(255, 255, 0), Color.FromArgb(255, 200, 0), Color.FromArgb(255, 151, 47), Color.FromArgb(255, 103, 0), Color.FromArgb(255, 96, 96), Color.FromArgb(192, 0, 95), Color.FromArgb(96, 0, 47), Color.FromArgb(159, 103, 48), Color.FromArgb(207, 151, 0), Color.FromArgb(255, 151, 0), Color.FromArgb(192, 96, 0), Color.FromArgb(255, 48, 0), Color.FromArgb(255, 0, 0), Color.FromArgb(192, 0, 0), Color.FromArgb(144, 0, 47), Color.FromArgb(96, 48, 0), Color.FromArgb(144, 96, 0), Color.FromArgb(192, 48, 0), Color.FromArgb(144, 48, 0), Color.FromArgb(144, 0, 0), Color.FromArgb(127, 0, 0), Color.FromArgb(144, 48, 48), Color.White, Color.Black, Color.FromArgb(207, 200, 207), Color.FromArgb(144, 151, 144), Color.FromArgb(96, 103, 96), Color.FromArgb(192, 192, 192), Color.FromArgb(127, 127, 127), Color.FromArgb(48, 48, 48),
        });
      }
    }

    public static ColorCollection NamedColors
    {
      get
      {
        List<Color> results;

        results = new List<Color>();

        foreach (PropertyInfo property in typeof(Color).GetProperties(BindingFlags.Public | BindingFlags.Static).Where(property => property.PropertyType == typeof(Color)))
        {
          Color color;

          color = (Color)property.GetValue(typeof(Color), null);
          if (!color.IsEmpty)
            results.Add(color);
        }

        results.Sort(ColorComparer.Brightness);

        return new ColorCollection(results);
      }
    }

    public static ColorCollection Office2010Standard
    {
      get
      {
        return ScaledPalette(new[]
        {
          Color.FromArgb(255, 255, 255), Color.FromArgb(0, 0, 0), Color.FromArgb(238, 236, 255), Color.FromArgb(31, 73, 125), Color.FromArgb(79, 129, 189), Color.FromArgb(192, 80, 77), Color.FromArgb(155, 187, 89), Color.FromArgb(128, 100, 162), Color.FromArgb(75, 172, 198), Color.FromArgb(247, 150, 70)
        });
      }
    }

    public static ColorCollection PaintPalette
    {
      get
      {
        return new ColorCollection(new[]
        {
          Color.FromArgb(0, 0, 0), Color.FromArgb(64, 64, 64), Color.FromArgb(255, 0, 0), Color.FromArgb(255, 106, 0), Color.FromArgb(255, 216, 0), Color.FromArgb(182, 255, 0), Color.FromArgb(76, 255, 0), Color.FromArgb(0, 255, 33), Color.FromArgb(0, 255, 144), Color.FromArgb(0, 255, 255), Color.FromArgb(0, 148, 255), Color.FromArgb(0, 38, 255), Color.FromArgb(72, 0, 255), Color.FromArgb(178, 0, 255), Color.FromArgb(255, 0, 220), Color.FromArgb(255, 0, 110), Color.FromArgb(255, 255, 255), Color.FromArgb(128, 128, 128), Color.FromArgb(127, 0, 0), Color.FromArgb(127, 51, 0), Color.FromArgb(127, 106, 0), Color.FromArgb(91, 127, 0), Color.FromArgb(38, 127, 0), Color.FromArgb(0, 127, 14), Color.FromArgb(0, 127, 70), Color.FromArgb(0, 127, 127), Color.FromArgb(0, 74, 127), Color.FromArgb(0, 19, 127), Color.FromArgb(33, 0, 127), Color.FromArgb(87, 0, 127), Color.FromArgb(127, 0, 110), Color.FromArgb(127, 0, 55), Color.FromArgb(160, 160, 160), Color.FromArgb(48, 48, 48), Color.FromArgb(255, 127, 127), Color.FromArgb(255, 178, 127), Color.FromArgb(255, 233, 127), Color.FromArgb(218, 255, 127), Color.FromArgb(165, 255, 127), Color.FromArgb(127, 255, 142), Color.FromArgb(127, 255, 197), Color.FromArgb(127, 255, 255), Color.FromArgb(127, 201, 255), Color.FromArgb(127, 146, 255), Color.FromArgb(161, 127, 255), Color.FromArgb(214, 127, 255), Color.FromArgb(255, 127, 237), Color.FromArgb(255, 127, 182), Color.FromArgb(192, 192, 192), Color.FromArgb(96, 96, 96), Color.FromArgb(127, 63, 63), Color.FromArgb(127, 89, 63), Color.FromArgb(127, 116, 63), Color.FromArgb(109, 127, 63), Color.FromArgb(82, 127, 63), Color.FromArgb(63, 127, 71), Color.FromArgb(63, 127, 98), Color.FromArgb(63, 127, 127), Color.FromArgb(63, 100, 127), Color.FromArgb(63, 73, 127), Color.FromArgb(80, 63, 127), Color.FromArgb(107, 63, 127), Color.FromArgb(127, 63, 118), Color.FromArgb(127, 63, 91), Color.FromArgb(128, 0, 0, 0), Color.FromArgb(128, 64, 64, 64), Color.FromArgb(128, 255, 0, 0), Color.FromArgb(128, 255, 106, 0), Color.FromArgb(128, 255, 216, 0), Color.FromArgb(128, 182, 255, 0), Color.FromArgb(128, 76, 255, 0), Color.FromArgb(128, 0, 255, 33), Color.FromArgb(128, 0, 255, 144), Color.FromArgb(128, 0, 255, 255), Color.FromArgb(128, 0, 148, 255), Color.FromArgb(128, 0, 38, 255), Color.FromArgb(128, 72, 0, 255), Color.FromArgb(128, 178, 0, 255), Color.FromArgb(128, 255, 0, 220), Color.FromArgb(128, 255, 0, 110), Color.FromArgb(128, 255, 255, 255), Color.FromArgb(128, 128, 128, 128), Color.FromArgb(128, 127, 0, 0), Color.FromArgb(128, 127, 51, 0), Color.FromArgb(128, 127, 106, 0), Color.FromArgb(128, 91, 127, 0), Color.FromArgb(128, 38, 127, 0), Color.FromArgb(128, 0, 127, 14), Color.FromArgb(128, 0, 127, 70), Color.FromArgb(128, 0, 127, 127), Color.FromArgb(128, 0, 74, 127), Color.FromArgb(128, 0, 19, 127), Color.FromArgb(128, 33, 0, 127), Color.FromArgb(128, 87, 0, 127), Color.FromArgb(128, 127, 0, 110), Color.FromArgb(128, 127, 0, 55)
        });
      }
    }

    public static ColorCollection QbColors
    {
      get
      {
        return new ColorCollection(new[]
        {
          Color.FromArgb(0, 0, 0), Color.FromArgb(128, 0, 0), Color.FromArgb(0, 128, 0), Color.FromArgb(128, 128, 0), Color.FromArgb(0, 0, 128), Color.FromArgb(128, 0, 128), Color.FromArgb(0, 128, 128), Color.FromArgb(192, 192, 192), Color.FromArgb(128, 128, 128), Color.FromArgb(255, 0, 0), Color.FromArgb(0, 255, 0), Color.FromArgb(255, 255, 0), Color.FromArgb(0, 0, 255), Color.FromArgb(255, 0, 255), Color.FromArgb(0, 255, 255), Color.FromArgb(255, 255, 255)
        });
      }
    }

    #endregion

    #region Class Members

    public static ColorCollection GetPalette(ColorPalette palette)
    {
      ColorCollection result;

      switch (palette)
      {
        case ColorPalette.Named:
          result = NamedColors;
          break;
        case ColorPalette.Office2010:
          result = Office2010Standard;
          break;
        case ColorPalette.Paint:
          result = PaintPalette;
          break;
        case ColorPalette.Standard:
          result = QbColors;
          break;
        case ColorPalette.None:
          result = new ColorCollection();
          break;
        default:
          throw new ArgumentException("Invalid palette", "palette");
      }

      return result;
    }

    public static ColorCollection ScaledPalette(IEnumerable<Color> topRow)
    {
      ColorCollection results;

      results = new ColorCollection();

      topRow = topRow.ToArray();
      results.AddRange(topRow);

      for (int i = 5; i >= 0; i--)
      {
        foreach (Color color in topRow)
        {
          HslColor hsl;

          hsl = new HslColor(color);
          hsl.L = (5 + i + (16 * i)) / 100D;

          results.Add(hsl.ToRgbColor());
        }
      }

      return results;
    }

    #endregion
  }
}
