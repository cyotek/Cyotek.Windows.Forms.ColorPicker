using FluentAssertions;
using NUnit.Framework;

namespace Cyotek.Windows.Forms.ColorPicker.Tests
{
  [TestFixture]
  internal class PaletteSerializerTests : TestBase
  {
    [Test]
    public void DefaultOpenFilterTest()
    {
      // arrange
      string expected;
      string actual;

      expected = "All Supported Palettes (*.gpl;*.pal;*.txt)|*.gpl;*.pal;*.txt|GIMP Palette Files (*.gpl)|*.gpl|JASC Palette Files (*.pal)|*.pal|Paint.NET Palette Files (*.txt)|*.txt|All Files (*.*)|*.*";

      // act
      actual = PaletteSerializer.DefaultOpenFilter;

      // assert
      actual.Should().Be(expected);
    }

    [Test]
    public void DefaultSaveFilterTest()
    {
      // arrange
      string expected;
      string actual;

      expected = "GIMP Palette Files (*.gpl)|*.gpl|JASC Palette Files (*.pal)|*.pal|Paint.NET Palette Files (*.txt)|*.txt";

      // act
      actual = PaletteSerializer.DefaultSaveFilter;

      // assert
      actual.Should().Be(expected);
    }
  }
}
