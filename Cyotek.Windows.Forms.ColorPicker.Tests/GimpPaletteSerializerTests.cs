using System.IO;
using NUnit.Framework;

// Cyotek Color Picker controls library
// Copyright © 2013 Cyotek. All Rights Reserved.
// http://cyotek.com/blog/tag/colorpicker

// If you use this code in your applications, donations or attribution are welcome

namespace Cyotek.Windows.Forms.ColorPicker.Tests
{
  /// <summary>
  /// Tests for the <see cref="GimpPaletteSerializer"/> class.
  /// </summary>
  [TestFixture]
  public class GimpPaletteSerializerTests : TestBase
  {
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
        actual = target.Deserialize(stream);

      // assert
      CollectionAssert.AreEqual(expected, actual);
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
        actual = new GimpPaletteSerializer().Deserialize(read);

      // assert
      CollectionAssert.AreEqual(expected, actual);
    }
  }
}
