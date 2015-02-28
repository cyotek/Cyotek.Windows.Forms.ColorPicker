using System.Drawing;
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
  /// Tests for the <see cref="AdobePhotoshopColorSwatchSerializer"/> class.
  /// </summary>
  [TestFixture]
  public class AdobePhotoshopColorSwatchSerializerTest : TestBase
  {
    #region Tests

    [Test]
    public void CanReadTest()
    {
      // arrange
      IPaletteSerializer target;
      bool actual;

      target = new AdobePhotoshopColorSwatchSerializer();

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

      target = new AdobePhotoshopColorSwatchSerializer();

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

      fileName = Path.Combine(this.DataPath, "db32.aco");

      target = new AdobePhotoshopColorSwatchSerializer();

      expected = this.CreateDawnBringer32Palette(false);

      // act
      using (Stream stream = File.OpenRead(fileName))
      {
        actual = target.Deserialize(stream);
      }

      // assert
      actual.Should().Equal(expected);
    }

    [Test]
    public void GetSerializerTest()
    {
      // arrange
      IPaletteSerializer actual;
      string workFileName;

      workFileName = Path.GetTempFileName();
      File.Copy(Path.Combine(this.DataPath, "db32.aco"), workFileName, true);

      // act
      actual = PaletteSerializer.GetSerializer(workFileName);
      File.Delete(workFileName);

      // assert
      actual.Should().BeOfType<AdobePhotoshopColorSwatchSerializer>();
    }

    [Test]
    public void SerializeGrayscaleTest()
    {
      // arrange
      AdobePhotoshopColorSwatchSerializer target;
      ColorCollection expected;
      ColorCollection actual;
      MemoryStream write;

      target = new AdobePhotoshopColorSwatchSerializer();

      expected = ColorCollection.LoadPalette(Path.Combine(this.DataPath, "grayscale.pal"));
      write = new MemoryStream();

      // act
      target.Serialize(write, expected, AdobePhotoshopColorSwatchColorSpace.Grayscale);

      using (MemoryStream read = new MemoryStream(write.ToArray()))
      {
        actual = new AdobePhotoshopColorSwatchSerializer().Deserialize(read);
      }

      // assert
      // TODO: The grayscale color space suffers the same problem as HSB - see that test for more details
      actual.Count.Should().Be(expected.Count);
      for (int i = 0; i < actual.Count; i++)
      {
        Color actualColor;
        Color expectedColor;

        actualColor = actual[i];
        expectedColor = expected[i];

        ((int)actualColor.R).Should().BeInRange(expectedColor.R - 1, expectedColor.R + 1);
        ((int)actualColor.G).Should().BeInRange(expectedColor.G - 1, expectedColor.G + 1);
        ((int)actualColor.B).Should().BeInRange(expectedColor.B - 1, expectedColor.B + 1);
      }
    }

    [Test]
    public void SerializeHslTest()
    {
      // arrange
      AdobePhotoshopColorSwatchSerializer target;
      ColorCollection expected;
      ColorCollection actual;
      MemoryStream write;

      target = new AdobePhotoshopColorSwatchSerializer();

      expected = this.CreateDawnBringer32Palette(false);
      write = new MemoryStream();

      // act
      target.Serialize(write, expected, AdobePhotoshopColorSwatchColorSpace.Hsb);

      using (MemoryStream read = new MemoryStream(write.ToArray()))
      {
        actual = new AdobePhotoshopColorSwatchSerializer().Deserialize(read);
      }

      // assert
      // TODO: Source HSL values are comprised of floating point numbers but the Adobe
      // file specification only allows whole numbers. This is causing a loss of precision
      // when converting to RGB with a +/- 1 difference. Might be a problem, might not be...
      // the intended use case is for RGB palettes only but may need to revisit this
      actual.Count.Should().Be(expected.Count);
      for (int i = 0; i < actual.Count; i++)
      {
        Color actualColor;
        Color expectedColor;

        actualColor = actual[i];
        expectedColor = expected[i];

        ((int)actualColor.R).Should().BeInRange(expectedColor.R - 1, expectedColor.R + 1);
        ((int)actualColor.G).Should().BeInRange(expectedColor.G - 1, expectedColor.G + 1);
        ((int)actualColor.B).Should().BeInRange(expectedColor.B - 1, expectedColor.B + 1);
      }
    }

    [Test]
    public void SerializeTest()
    {
      // arrange
      IPaletteSerializer target;
      ColorCollection expected;
      ColorCollection actual;
      MemoryStream write;

      target = new AdobePhotoshopColorSwatchSerializer();

      expected = this.CreateDawnBringer32Palette(false);
      write = new MemoryStream();

      // act
      target.Serialize(write, expected);

      using (MemoryStream read = new MemoryStream(write.ToArray()))
      {
        actual = new AdobePhotoshopColorSwatchSerializer().Deserialize(read);
      }

      // assert
      CollectionAssert.AreEqual(expected, actual);
    }

    #endregion
  }
}
