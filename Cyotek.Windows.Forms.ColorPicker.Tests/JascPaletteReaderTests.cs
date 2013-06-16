using System.IO;
using NUnit.Framework;

namespace Cyotek.Windows.Forms.ColorPicker.Tests
{
  [TestFixture]
  public class JascPaletteReaderTests : TestBase
  {
    [Test]
    public void ReadPaletteTest()
    {
      // arrange
      IPaletteReader target;
      string fileName;
      ColorCollection expected;
      ColorCollection actual;

      fileName = Path.Combine(this.DataPath, "db32.pal");

      target = new JascPaletteReader();

      expected = this.CreateDawnbringer32Palette(true);

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

      fileName = Path.Combine(this.DataPath, "db16.pal");

      target = new JascPaletteReader();
      target.FileName = fileName;

      expected = this.CreateDawnbringer16Palette(true);

      // act
      actual = target.ReadPalette();

      // assert
      CollectionAssert.AreEqual(expected, actual);
      Assert.AreEqual(fileName, target.FileName);
    }
  }
}
