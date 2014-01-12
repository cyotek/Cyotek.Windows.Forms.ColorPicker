using FluentAssertions;
using NUnit.Framework;

// Cyotek Color Picker controls library
// Copyright © 2013-2014 Cyotek.
// http://cyotek.com/blog/tag/colorpicker

// Licensed under the MIT License. See colorpicker-license.txt for the full text.

// If you use this code in your applications, donations or attribution are welcome

namespace Cyotek.Windows.Forms.ColorPicker.Tests
{
  [TestFixture]
  internal class PaletteSerializerTests : TestBase
  {
    [Test]
    public void DefaultOpenFilterTest()
    {
      // arrange
      string expected;
      string actual;

      expected = "All Supported Palettes (*.gpl;*.bbm;*.lbm;*.pal;*.txt)|*.gpl;*.bbm;*.lbm;*.pal;*.txt|GIMP Palette Files (*.gpl)|*.gpl|Interleaved Bitmap Palette Files (*.bbm;*.lbm)|*.bbm;*.lbm|JASC Palette Files (*.pal)|*.pal|Paint.NET Palette Files (*.txt)|*.txt|All Files (*.*)|*.*";

      // act
      actual = PaletteSerializer.DefaultOpenFilter;

      // assert
      actual.Should().Be(expected);
    }

    [Test]
    public void DefaultSaveFilterTest()
    {
      // arrange
      string expected;
      string actual;

      expected = "GIMP Palette Files (*.gpl)|*.gpl|JASC Palette Files (*.pal)|*.pal|Paint.NET Palette Files (*.txt)|*.txt";

      // act
      actual = PaletteSerializer.DefaultSaveFilter;

      // assert
      actual.Should().Be(expected);
    }
  }
}
