using System.IO;
using FluentAssertions;
using NUnit.Framework;

// Cyotek Color Picker controls library
// Copyright © 2013-2015 Cyotek Ltd.
// http://cyotek.com/blog/tag/colorpicker

// Licensed under the MIT License. See license.txt for the full text.

// If you use this code in your applications, donations or attribution are welcome

namespace Cyotek.Windows.Forms.ColorPicker.Tests
{
  [TestFixture]
  internal class PaletteSerializerTests : TestBase
  {
    #region Tests

    [Test]
    public void DefaultOpenFilterTest()
    {
      // arrange
      string expected;
      string actual;

      expected = "All Supported Palettes (*.aco;*.gpl;*.bbm;*.lbm;*.pal;*.txt)|*.aco;*.gpl;*.bbm;*.lbm;*.pal;*.txt|Adobe Photoshop Color Swatch Files (*.aco)|*.aco|GIMP Palette Files (*.gpl)|*.gpl|Interleaved Bitmap Palette Files (*.bbm;*.lbm)|*.bbm;*.lbm|JASC Palette Files (*.pal)|*.pal|Paint.NET Palette Files (*.txt)|*.txt|Raw Palette Files (*.pal)|*.pal|All Files (*.*)|*.*";

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

      expected = "Adobe Photoshop Color Swatch Files (*.aco)|*.aco|GIMP Palette Files (*.gpl)|*.gpl|JASC Palette Files (*.pal)|*.pal|Paint.NET Palette Files (*.txt)|*.txt|Raw Palette Files (*.pal)|*.pal";

      // act
      actual = PaletteSerializer.DefaultSaveFilter;

      // assert
      actual.Should().Be(expected);
    }

    [Test]
    public void ReadInt16Test()
    {
      // arrange
      int expected;
      int actual;
      MemoryStream stream;
      FakeSerializer target;

      stream = new MemoryStream(new byte[]
                                {
                                  123, 41
                                });
      target = new FakeSerializer();
      expected = 31529;

      // act
      actual = target.ReadInt16(stream);

      // assert
      expected.Should().Be(actual);
    }

    [Test]
    public void ReadInt32Test()
    {
      // arrange
      int expected;
      int actual;
      MemoryStream stream;
      FakeSerializer target;

      stream = new MemoryStream(new byte[]
                                {
                                  3, 181, 103, 132
                                });
      target = new FakeSerializer();
      expected = 62220164;

      // act
      actual = target.ReadInt32(stream);

      // assert
      expected.Should().Be(actual);
    }

    [Test]
    public void WriteInt16Test()
    {
      // arrange
      short value;
      byte[] expected;
      byte[] actual;
      FakeSerializer target;

      value = 31529;
      expected = new[]
                 {
                   (byte)123, (byte)41
                 };
      target = new FakeSerializer();

      // act
      using (MemoryStream stream = new MemoryStream())
      {
        target.WriteInt16(stream, value);
        actual = stream.ToArray();
      }

      // assert
      actual.Should().Equal(expected);
    }

    [Test]
    public void WriteInt32Test()
    {
      // arrange
      int value;
      byte[] expected;
      byte[] actual;
      FakeSerializer target;

      value = 62220164;
      expected = new[]
                 {
                   (byte)3, (byte)181, (byte)103, (byte)132
                 };
      target = new FakeSerializer();

      // act
      using (MemoryStream stream = new MemoryStream())
      {
        target.WriteInt32(stream, value);
        actual = stream.ToArray();
      }

      // assert
      actual.Should().Equal(expected);
    }

    #endregion
  }
}
