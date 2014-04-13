using System.IO;
using FluentAssertions;
using NUnit.Framework;

// Cyotek Color Picker controls library
// Copyright © 2013-2014 Cyotek.
// http://cyotek.com/blog/tag/colorpicker

// Licensed under the MIT License. See colorpicker-license.txt for the full text.

// If you use this code in your applications, donations or attribution are welcome

namespace Cyotek.Windows.Forms.ColorPicker.Tests
{
  /// <summary>
  /// Tests for the <see cref="PaintNetPaletteSerializer"/> class.
  /// </summary>
  [TestFixture]
  public class PaintNetPaletteSerializerTests : TestBase
  {
    #region Tests

    [Test]
    public void CanReadTest()
    {
      // arrange
      IPaletteSerializer target;
      bool actual;

      target = new PaintNetPaletteSerializer();

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

      target = new PaintNetPaletteSerializer();

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

      fileName = Path.Combine(this.DataPath, "PaintNet.txt");

      target = new PaintNetPaletteSerializer();

      expected = ColorPalettes.PaintPalette;

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
      File.Copy(Path.Combine(this.DataPath, "PaintNet.txt"), workFileName, true);

      // act
      actual = PaletteSerializer.GetSerializer(workFileName);
      File.Delete(workFileName);

      // assert
      actual.Should().BeOfType<PaintNetPaletteSerializer>();
    }

    [Test]
    public void SerializeTest()
    {
      // arrange
      IPaletteSerializer target;
      ColorCollection expected;
      ColorCollection actual;
      MemoryStream write;

      target = new PaintNetPaletteSerializer();

      expected = this.CreateDawnBringer32Palette(false);
      write = new MemoryStream();

      // act
      target.Serialize(write, expected);

      using (MemoryStream read = new MemoryStream(write.ToArray()))
      {
        actual = new PaintNetPaletteSerializer().Deserialize(read);
      }

      // assert
      CollectionAssert.AreEqual(expected, actual);
    }

    #endregion
  }
}
