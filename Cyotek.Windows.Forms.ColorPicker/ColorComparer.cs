using System.Drawing;

namespace Cyotek.Windows.Forms
{
  // Cyotek Color Picker controls library
  // Copyright © 2013 Cyotek. All Rights Reserved.
  // http://cyotek.com/blog/tag/colorpicker

  // If you use this code in your applications, donations or attribution are welcome

  /// <summary>
  /// Provides access to color comparision operations.
  /// </summary>
  public static class ColorComparer
  {
    #region Class Members

    /// <summary>
    /// Ccompares two colors by brightness and returns an indication of their relative sort order.
    /// </summary>
    /// <param name="x">A color to compare to y.</param>
    /// <param name="y">A color to compare to x.</param>
    public static int Brightness(Color x, Color y)
    {
      float v1;
      float v2;
      int result;

      v1 = x.GetBrightness();
      v2 = y.GetBrightness();

      if (v1 < v2)
        result = -1;
      else if (v1 > v2)
        result = 1;
      else
        result = 0;

      return result;
    }

    /// <summary>
    /// Ccompares two colors by hue and returns an indication of their relative sort order.
    /// </summary>
    /// <param name="x">A color to compare to y.</param>
    /// <param name="y">A color to compare to x.</param>
    public static int Hue(Color x, Color y)
    {
      float v1;
      float v2;
      int result;

      v1 = x.GetHue();
      v2 = y.GetHue();

      if (v1 < v2)
        result = -1;
      else if (v1 > v2)
        result = 1;
      else
        result = 0;

      return result;
    }

    /// <summary>
    /// Ccompares two colors by value and returns an indication of their relative sort order.
    /// </summary>
    /// <param name="x">A color to compare to y.</param>
    /// <param name="y">A color to compare to x.</param>
    public static int Value(Color x, Color y)
    {
      int v1;
      int v2;
      int result;

      v1 = x.R << 16 | x.G << 8 | x.B;
      v2 = y.R << 16 | y.G << 8 | y.B;

      if (v1 > v2)
        result = -1;
      else if (v1 < v2)
        result = 1;
      else
        result = 0;

      return result;
    }

    #endregion
  }
}
