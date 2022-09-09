// Cyotek Color Picker Controls Library
// http://cyotek.com/blog/tag/colorpicker

// Copyright © 2013-2021 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.cyotek.com/contribute

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Cyotek.Windows.Forms.HslColorTests
{
  /// <summary>
  /// Tests for the <see cref="HslColor"/> class
  /// </summary>
  [TestFixture]
  public class HslColorTests
  {
    #region  Tests

    [Test]
    public void CheckThatAll32BitRGBValuesCanDoRoundTripToHSL()
    {
      var all32bitRGB = Enumerable.Range(0, 0xFFFFFF).ToList();
      Parallel.ForEach(all32bitRGB, rgbInt =>
      {
        check_individual_color(Color.FromArgb(0xFF, rgbInt % 0xFF, (rgbInt % 0x00FF) >> 8, (rgbInt % 0xFF0000) >> 16));
      });
    }

    [Test]
    public void SpecificProblemRGBValueCanHaveRoundTrip()
    {
      check_individual_color(Color.FromArgb(0xFF, 0xEC, 0xFF, 0xEC));
    }
    #endregion

    private void check_individual_color(Color originalColor)
    {
      HslColor inHsl = originalColor;
      Color roundTrip = inHsl.ToRgbColor();
      Assert.AreEqual(originalColor, roundTrip);
    }
  }
}
