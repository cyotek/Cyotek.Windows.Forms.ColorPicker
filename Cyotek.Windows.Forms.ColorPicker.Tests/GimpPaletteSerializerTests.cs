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
  /// <summary>
  /// Tests for the <see cref="GimpPaletteSerializer"/> class.
  /// </summary>
  [TestFixture]
  public class GimpPaletteSerializerTests : TestBase
  {
    #region  Tests

    [Test]
    public void CanReadTest()
    {
      // arrange
      IPaletteSerializer target;
      bool actual;

      target = new GimpPaletteSerializer();

      // act
      actual = target.CanRead;

      // assert
      actual.Should().BeTrue();
    }

    [Test]
    public void CanWriteTest()
    {
      // arrange
      IPaletteSerializer target;
      bool actual;

      target = new GimpPaletteSerializer();

      // act
      actual = target.CanWrite;

      // assert
      actual.Should().BeTrue();
    }

    [Test]
    public void DeserializeTest()
    {
      // arrange
      IPaletteSerializer target;
      string fileName;
      ColorCollection expected;
      ColorCollection actual;

      fileName = Path.Combine(this.DataPath, "db32.gpl");

      target = new GimpPaletteSerializer();

      expected = this.CreateDawnBringer32Palette(false);

      // act
      using (Stream stream = File.OpenRead(fileName))
      {
        actual = target.Deserialize(stream);
      }

      // assert
      CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    [Timeout(1000)]
    public void DeserializeWithCommentsTest()
    {
      // arrange
      IPaletteSerializer target;
      string fileName;
      ColorCollection expected;
      ColorCollection actual;

      fileName = Path.Combine(this.DataPath, "db16-comments.gpl");

      target = new GimpPaletteSerializer();

      expected = this.CreateDawnBringer16Palette(false);

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
      File.Copy(Path.Combine(this.DataPath, "db32.gpl"), workFileName, true);

      // act
      actual = PaletteSerializer.GetSerializer(workFileName);
      File.Delete(workFileName);

      // assert
      actual.Should().BeOfType<GimpPaletteSerializer>();
    }

    [Test]
    public void SerializeTest()
    {
      // arrange
      IPaletteSerializer target;
      ColorCollection expected;
      ColorCollection actual;
      MemoryStream write;

      target = new GimpPaletteSerializer();

      expected = this.CreateDawnBringer32Palette(false);
      write = new MemoryStream();

      // act
      target.Serialize(write, expected);

      using (MemoryStream read = new MemoryStream(write.ToArray()))
      {
        actual = new GimpPaletteSerializer().Deserialize(read);
      }

      // assert
      CollectionAssert.AreEqual(expected, actual);
    }

    #endregion
  }
}
