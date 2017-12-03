using System;
using System.Drawing;
using System.IO;

// Cyotek Color Picker controls library
// Copyright © 2013-2017 Cyotek Ltd.
// http://cyotek.com/blog/tag/colorpicker

// Licensed under the MIT License. See license.txt for the full text.

// If you use this code in your applications, donations or attribution are welcome

namespace Cyotek.Windows.Forms.ColorPicker.Tests
{
  /// <summary>
  /// Base class for unit tests
  /// </summary>
  public abstract class TestBase
  {
    #region Properties

    /// <summary>
    /// Gets the path where testing resources are located.
    /// </summary>
    /// <value>The data path.</value>
    protected string DataPath
    {
      get { return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data"); }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Creates the DB16 palette.
    /// </summary>
    /// <remarks>http://www.pixeljoint.com/forum/forum_posts.asp?TID=12795</remarks>
    /// <param name="pad">if set to <c>true</c> the palette is padded with black to fill 256 entries.</param>
    protected ColorCollection CreateDawnBringer16Palette(bool pad)
    {
      ColorCollection results;

      results = new ColorCollection();

      results.Add(Color.FromArgb(20, 12, 28));
      results.Add(Color.FromArgb(68, 36, 52));
      results.Add(Color.FromArgb(48, 52, 109));
      results.Add(Color.FromArgb(78, 74, 78));
      results.Add(Color.FromArgb(133, 76, 48));
      results.Add(Color.FromArgb(52, 101, 36));
      results.Add(Color.FromArgb(208, 70, 72));
      results.Add(Color.FromArgb(117, 113, 97));
      results.Add(Color.FromArgb(89, 125, 206));
      results.Add(Color.FromArgb(210, 125, 44));
      results.Add(Color.FromArgb(133, 149, 161));
      results.Add(Color.FromArgb(109, 170, 44));
      results.Add(Color.FromArgb(210, 170, 153));
      results.Add(Color.FromArgb(109, 194, 202));
      results.Add(Color.FromArgb(218, 212, 94));
      results.Add(Color.FromArgb(222, 238, 214));

      if (pad)
      {
        while (results.Count < 256)
        {
          results.Add(Color.FromArgb(0, 0, 0));
        }
      }

      return results;
    }

    /// <summary>
    /// Creates the DB32 palette.
    /// </summary>
    /// <remarks>http://www.pixeljoint.com/forum/forum_posts.asp?TID=16247</remarks>
    /// <param name="pad">if set to <c>true</c> the palette is padded with black to fill 256 entries.</param>
    protected ColorCollection CreateDawnBringer32Palette(bool pad)
    {
      ColorCollection results;

      results = new ColorCollection();

      results.Add(Color.FromArgb(0, 0, 0));
      results.Add(Color.FromArgb(34, 32, 52));
      results.Add(Color.FromArgb(69, 40, 60));
      results.Add(Color.FromArgb(102, 57, 49));
      results.Add(Color.FromArgb(143, 86, 59));
      results.Add(Color.FromArgb(223, 113, 38));
      results.Add(Color.FromArgb(217, 160, 102));
      results.Add(Color.FromArgb(238, 195, 154));
      results.Add(Color.FromArgb(251, 242, 54));
      results.Add(Color.FromArgb(153, 229, 80));
      results.Add(Color.FromArgb(106, 190, 48));
      results.Add(Color.FromArgb(55, 148, 110));
      results.Add(Color.FromArgb(75, 105, 47));
      results.Add(Color.FromArgb(82, 75, 36));
      results.Add(Color.FromArgb(50, 60, 57));
      results.Add(Color.FromArgb(63, 63, 116));
      results.Add(Color.FromArgb(48, 96, 130));
      results.Add(Color.FromArgb(91, 110, 225));
      results.Add(Color.FromArgb(99, 155, 255));
      results.Add(Color.FromArgb(95, 205, 228));
      results.Add(Color.FromArgb(203, 219, 252));
      results.Add(Color.FromArgb(255, 255, 255));
      results.Add(Color.FromArgb(155, 173, 183));
      results.Add(Color.FromArgb(132, 126, 135));
      results.Add(Color.FromArgb(105, 106, 106));
      results.Add(Color.FromArgb(89, 86, 82));
      results.Add(Color.FromArgb(118, 66, 138));
      results.Add(Color.FromArgb(172, 50, 50));
      results.Add(Color.FromArgb(217, 87, 99));
      results.Add(Color.FromArgb(215, 123, 186));
      results.Add(Color.FromArgb(143, 151, 74));
      results.Add(Color.FromArgb(138, 111, 48));

      if (pad)
      {
        while (results.Count < 256)
        {
          results.Add(Color.FromArgb(0, 0, 0));
        }
      }

      return results;
    }

    #endregion
  }
}
