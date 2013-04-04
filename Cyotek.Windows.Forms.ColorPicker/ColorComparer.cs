using System.Drawing;

namespace Cyotek.Windows.Forms
{
  // Cyotek Color Picker controls library
  // Copyright © 2013 Cyotek. All Rights Reserved.
  // http://cyotek.com/blog/tag/colorpicker

  // If you use this code in your applications, donations or attribution is welcome

  public static class ColorComparer
  {
    #region Class Members

    public static int Brightness(Color c1, Color c2)
    {
      float h1 = c1.GetBrightness();
      float h2 = c2.GetBrightness();
      if (h1 < h2)
        return -1;
      if (h1 > h2)
        return 1;
      return 0;
    }

    public static int Hue(Color c1, Color c2)
    {
      float h1 = c1.GetHue();
      float h2 = c2.GetHue();
      if (h1 < h2)
        return -1;
      if (h1 > h2)
        return 1;
      return 0;
    }

    public static int Value(Color c1, Color c2)
    {
      int color1 = c1.R << 16 | c1.G << 8 | c1.B;
      int color2 = c2.R << 16 | c2.G << 8 | c2.B;
      if (color1 > color2)
        return -1;
      if (color1 < color2)
        return 1;
      return 0;
    }

    #endregion
  }
}
