using System.IO;
using NUnit.Framework;

namespace Cyotek.Windows.Forms.ColorPicker.Tests
{
  [TestFixture]
  public class PaintNetPaletteReaderTests : TestBase
  {
    [Test]
    public void ReadPaletteTest()
    {
      // arrange
      IPaletteReader target;
      string fileName;
      ColorCollection expected;
      ColorCollection actual;

      fileName = Path.Combine(this.DataPath, "PaintNet.txt");

      target = new PaintNetPaletteReader();

      expected = ColorPalettes.PaintPalette;

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

      fileName = Path.Combine(this.DataPath, "PaintNet.txt");

      target = new PaintNetPaletteReader();
      target.FileName = fileName;

      expected = ColorPalettes.PaintPalette;

      // act
      actual = target.ReadPalette();

      // assert
      CollectionAssert.AreEqual(expected, actual);
      Assert.AreEqual(fileName, target.FileName);
    }
  }
}
