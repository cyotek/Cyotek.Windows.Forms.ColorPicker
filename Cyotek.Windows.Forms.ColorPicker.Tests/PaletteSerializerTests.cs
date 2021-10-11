// Cyotek Color Picker Controls Library
// http://cyotek.com/blog/tag/colorpicker

// Copyright © 2013-2021 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.cyotek.com/contribute

using System.IO;
using NUnit.Framework;

namespace Cyotek.Windows.Forms.ColorPicker.Tests
{
  [TestFixture]
  internal class PaletteSerializerTests : TestBase
  {
    #region  Tests

    [Test]
    public void DefaultOpenFilterTest()
    {
      // arrange
      string expected;
      string actual;

      expected = "All Supported Palettes (*.act;*.aco;*.gpl;*.bbm;*.lbm;*.pal;*.txt)|*.act;*.aco;*.gpl;*.bbm;*.lbm;*.pal;*.txt|Adobe Color Table Files (*.act)|*.act|Adobe Photoshop Color Swatch Files (*.aco)|*.aco|GIMP Palette Files (*.gpl)|*.gpl|Interleaved Bitmap Palette Files (*.bbm;*.lbm)|*.bbm;*.lbm|JASC Palette Files (*.pal)|*.pal|Paint.NET Palette Files (*.txt)|*.txt|Raw Palette Files (*.pal)|*.pal|All Files (*.*)|*.*";

      // act
      actual = PaletteSerializer.DefaultOpenFilter;

      // assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    public void DefaultSaveFilterTest()
    {
      // arrange
      string expected;
      string actual;

      expected = "Adobe Color Table Files (*.act)|*.act|Adobe Photoshop Color Swatch Files (*.aco)|*.aco|GIMP Palette Files (*.gpl)|*.gpl|JASC Palette Files (*.pal)|*.pal|Paint.NET Palette Files (*.txt)|*.txt|Raw Palette Files (*.pal)|*.pal";

      // act
      actual = PaletteSerializer.DefaultSaveFilter;

      // assert
      Assert.AreEqual(expected, actual);
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
                                  123,
                                  41
                                });
      target = new FakeSerializer();
      expected = 31529;

      // act
      actual = target.ReadInt16(stream);

      // assert
      Assert.AreEqual(expected, actual);
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
                                  3,
                                  181,
                                  103,
                                  132
                                });
      target = new FakeSerializer();
      expected = 62220164;

      // act
      actual = target.ReadInt32(stream);

      // assert
      Assert.AreEqual(expected, actual);
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
                   (byte)123,
                   (byte)41
                 };
      target = new FakeSerializer();

      // act
      using (MemoryStream stream = new MemoryStream())
      {
        target.WriteInt16(stream, value);
        actual = stream.ToArray();
      }

      // assert
      Assert.AreEqual(expected, actual);
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
                   (byte)3,
                   (byte)181,
                   (byte)103,
                   (byte)132
                 };
      target = new FakeSerializer();

      // act
      using (MemoryStream stream = new MemoryStream())
      {
        target.WriteInt32(stream, value);
        actual = stream.ToArray();
      }

      // assert
      Assert.AreEqual(expected, actual);
    }

    #endregion
  }
}
