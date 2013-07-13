using System.IO;
using System.Text;
using NUnit.Framework;

// Cyotek Color Picker controls library
// Copyright © 2013 Cyotek. All Rights Reserved.
// http://cyotek.com/blog/tag/colorpicker

// If you use this code in your applications, donations or attribution are welcome

namespace Cyotek.Windows.Forms.ColorPicker.Tests
{
  /// <summary>
  /// Tests for the <see cref="PaintNetPaletteSerializer"/> class.
  /// </summary>
  [TestFixture]
  public class PaintNetPaletteSerializerTests : TestBase
  {
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

      target = new PaintNetPaletteSerializer();

      expected = this.CreateDawnBringer32Palette(false);
      write = new MemoryStream();

      // act
      target.Serialize(write, expected);

      string s = Encoding.UTF8.GetString(write.ToArray());

      using (MemoryStream read = new MemoryStream(write.ToArray()))
        actual = new PaintNetPaletteSerializer().Deserialize(read);

      // assert
      CollectionAssert.AreEqual(expected, actual);
    }
  }
}
