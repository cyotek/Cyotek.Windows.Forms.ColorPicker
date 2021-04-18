using System.IO;
using FluentAssertions;
using NUnit.Framework;

// Cyotek Color Picker controls library
// Copyright © 2013-2017 Cyotek Ltd.
// http://cyotek.com/blog/tag/colorpicker

// Licensed under the MIT License. See license.txt for the full text.

// If you use this code in your applications, donations or attribution are welcome

namespace Cyotek.Windows.Forms.ColorPicker.Tests
{
  /// <summary>
  /// Tests for the <see cref="JascPaletteSerializer"/> class.
  /// </summary>
  [TestFixture]
  public class JascPaletteSerializerTests : TestBase
  {
    #region  Tests

    [Test]
    public void CanReadTest()
    {
      // arrange
      IPaletteSerializer target;
      bool actual;

      target = new JascPaletteSerializer();

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

      target = new JascPaletteSerializer();

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

      fileName = Path.Combine(this.DataPath, "db32.pal");

      target = new JascPaletteSerializer();

      expected = this.CreateDawnBringer32Palette(true);

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
      File.Copy(Path.Combine(this.DataPath, "db32.pal"), workFileName, true);

      // act
      actual = PaletteSerializer.GetSerializer(workFileName);
      File.Delete(workFileName);

      // assert
      actual.Should().BeOfType<JascPaletteSerializer>();
    }

    [Test]
    public void SerializeTest()
    {
      // arrange
      IPaletteSerializer target;
      ColorCollection expected;
      ColorCollection actual;
      MemoryStream write;

      target = new JascPaletteSerializer();

      expected = this.CreateDawnBringer32Palette(false);
      write = new MemoryStream();

      // act
      target.Serialize(write, expected);

      using (MemoryStream read = new MemoryStream(write.ToArray()))
      {
        actual = new JascPaletteSerializer().Deserialize(read);
      }

      // assert
      CollectionAssert.AreEqual(expected, actual);
    }

    #endregion
  }
}
