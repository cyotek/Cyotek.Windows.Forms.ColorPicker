using System.IO;
using NUnit.Framework;

namespace Cyotek.Windows.Forms.ColorPicker.Tests
{
  [TestFixture]
  public class GimpPaletteReaderTests : TestBase
  {
    [Test]
    public void ReadPaletteTest()
    {
      // arrange
      IPaletteReader target;
      string fileName;
      ColorCollection expected;
      ColorCollection actual;

      fileName = Path.Combine(this.DataPath, "db32.gpl");

      target = new GimpPaletteReader();

      expected = this.CreateDawnbringer32Palette(false);

      // act
      actual = target.ReadPalette(fileName);

      // assert
      CollectionAssert.AreEqual(expected, actual);
      Assert.IsNull(target.FileName);
    }

    [Test]
    public void ReadPaletteViaPropertyTest()
    {
      // arrange
      IPaletteReader target;
      string fileName;
      ColorCollection expected;
      ColorCollection actual;

      fileName = Path.Combine(this.DataPath, "db16.gpl");

      target = new GimpPaletteReader();
      target.FileName = fileName;

      expected = this.CreateDawnbringer16Palette(false);

      // act
      actual = target.ReadPalette();

      // assert
      CollectionAssert.AreEqual(expected, actual);
      Assert.AreEqual(fileName, target.FileName);
    }
  }
}
