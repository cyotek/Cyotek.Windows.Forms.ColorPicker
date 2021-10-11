// Cyotek Color Picker Controls Library
// http://cyotek.com/blog/tag/colorpicker

// Copyright © 2013-2021 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.cyotek.com/contribute

// The sample image and palette used by this test class is by MindChamber works.
// http://opengameart.org/content/background-art

using System;
using System.IO;
using NUnit.Framework;

namespace Cyotek.Windows.Forms.ColorPicker.Tests
{
  /// <summary>
  /// Tests for the <see cref="InterleavedBitmapPaletteSerializer"/> class.
  /// </summary>
  [TestFixture]
  public class InterleavedBitmapPaletteSerializerTests : TestBase
  {
    #region  Tests

    [Test]
    public void CanReadTest()
    {
      // arrange
      IPaletteSerializer target;
      bool actual;

      target = new InterleavedBitmapPaletteSerializer();

      // act
      actual = target.CanRead;

      // assert
      Assert.IsTrue(actual);
    }

    [Test]
    public void CanWriteTest()
    {
      // arrange
      IPaletteSerializer target;
      bool actual;

      target = new InterleavedBitmapPaletteSerializer();

      // act
      actual = target.CanWrite;

      // assert
      Assert.IsFalse(actual);
    }

    [Test]
    public void DeserializeTest()
    {
      // arrange
      IPaletteSerializer target;
      string fileName;
      ColorCollection expected;
      ColorCollection actual;

      fileName = Path.Combine(this.DataPath, "background.lbm");

      target = new InterleavedBitmapPaletteSerializer();

      expected = new JascPaletteSerializer().Deserialize(Path.Combine(this.DataPath, "background.pal"));

      // act
      using (Stream stream = File.OpenRead(fileName))
      {
        actual = target.Deserialize(stream);
      }

      // assert
      CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void GetSerializerTest()
    {
      // arrange
      IPaletteSerializer actual;
      string workFileName;

      workFileName = Path.GetTempFileName();
      File.Copy(Path.Combine(this.DataPath, "background.lbm"), workFileName, true);

      // act
      actual = PaletteSerializer.GetSerializer(workFileName);
      File.Delete(workFileName);

      // assert
      Assert.IsInstanceOf<InterleavedBitmapPaletteSerializer>(actual);
    }

    [Test]
    public void SerializeTest()
    {
      // arrange
      IPaletteSerializer target;
      ColorCollection expected;
      MemoryStream write;

      target = new InterleavedBitmapPaletteSerializer();

      expected = this.CreateDawnBringer32Palette(false);
      write = new MemoryStream();

      // act & assert
      Assert.Throws<NotSupportedException>(() => target.Serialize(write, expected));
    }

    #endregion
  }
}
