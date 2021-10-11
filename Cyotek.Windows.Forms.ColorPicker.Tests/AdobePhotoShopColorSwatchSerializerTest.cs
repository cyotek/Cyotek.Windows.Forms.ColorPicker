// Cyotek Color Picker Controls Library
// http://cyotek.com/blog/tag/colorpicker

// Copyright © 2013-2021 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.cyotek.com/contribute

using System.Drawing;
using System.IO;
using NUnit.Framework;

namespace Cyotek.Windows.Forms.ColorPicker.Tests
{
  /// <summary>
  /// Tests for the <see cref="AdobePhotoshopColorSwatchSerializer"/> class.
  /// </summary>
  [TestFixture]
  public class AdobePhotoshopColorSwatchSerializerTest : TestBase
  {
    #region  Tests

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
      Assert.IsTrue(actual);
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
      Assert.IsTrue(actual);
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
      Assert.AreEqual(expected, actual);
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
      Assert.IsInstanceOf<AdobePhotoshopColorSwatchSerializer>(actual);
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
      this.AssertNear(expected, actual);
    }

    private void AssertNear(ColorCollection expected, ColorCollection actual)
    {
      Assert.AreEqual(expected.Count, actual.Count);

      for (int i = 0; i < actual.Count; i++)
      {
        this.AssertNear(expected[i], actual[i]);
      }
    }

    private void AssertNear(Color expected, Color actual)
    {
      Assert.That(actual.R, Is.EqualTo(expected.R).Within(1));
      Assert.That(actual.G, Is.EqualTo(expected.G).Within(1));
      Assert.That(actual.B, Is.EqualTo(expected.B).Within(1));
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
      this.AssertNear(expected, actual);
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
