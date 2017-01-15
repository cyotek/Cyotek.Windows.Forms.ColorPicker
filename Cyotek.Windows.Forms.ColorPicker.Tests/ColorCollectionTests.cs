using System;
using System.Drawing;
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
  /// Tests for the <see cref="ColorCollection"/> class
  /// </summary>
  [TestFixture]
  public class ColorCollectionTests : TestBase
  {
    #region  Tests

    [Test]
    public void CloneFromInterfaceTest()
    {
      // arrange
      ColorCollection target;
      ColorCollection expected;

      expected = this.CreateDawnBringer32Palette(false);

      // act
      target = (ColorCollection)((ICloneable)expected).Clone();

      // assert
      target.Should().Equal(expected);
    }

    [Test]
    public void CloneTest()
    {
      // arrange
      ColorCollection target;
      ColorCollection expected;

      expected = this.CreateDawnBringer32Palette(false);

      // act
      target = expected.Clone();

      // assert
      target.Should().Equal(expected);
    }

    [Test]
    public void EqualsNegativeTest()
    {
      // arrange
      ColorCollection target;
      ColorCollection other;
      bool actual;

      target = ColorPalettes.QbColors;
      other = ColorPalettes.QbColors;

      other[5] = Color.CornflowerBlue;

      // act
      actual = other == target;

      // assert
      actual.Should().BeFalse();
    }

    [Test]
    public void EqualsNullTest()
    {
      // arrange
      ColorCollection target;
      bool actual;

      target = new ColorCollection();

      // act
      actual = target.Equals(null);

      // assert
      actual.Should().BeFalse();
    }

    [Test]
    public void EqualsObjectTest()
    {
      // arrange
      ColorCollection target;
      object other;
      bool actual;

      target = new ColorCollection();
      other = target;

      // act
      actual = target.Equals(other);

      // assert
      actual.Should().BeTrue();
    }

    [Test]
    public void EqualsObjectWrongTypeTest()
    {
      // arrange
      ColorCollection target;
      object other;
      bool actual;

      target = new ColorCollection();
      other = 42;

      // act
      actual = target.Equals(other);

      // assert
      actual.Should().BeFalse();
    }

    [Test]
    public void EqualsSameContentsTest()
    {
      // arrange
      ColorCollection target;
      ColorCollection other;
      bool actual;

      target = ColorPalettes.QbColors;
      other = ColorPalettes.QbColors;

      // act
      actual = other == target;

      // assert
      actual.Should().BeTrue();
      ((object)other).Should().NotBeSameAs(target);
    }

    [Test]
    public void EqualsSameReferenceTest()
    {
      // arrange
      ColorCollection target;
      ColorCollection other;
      bool actual;

      target = new ColorCollection();
      other = target;

      // act
      actual = other == target;

      // assert
      actual.Should().BeTrue();
      ((object)other).Should().BeSameAs(target);
    }

    [Test]
    public void FindIgnoreAlphaNegativeTest()
    {
      // arrange
      ColorCollection target;
      int expected;
      int actual;

      target = new ColorCollection();
      target.Add(Color.Black);
      target.Add(Color.CornflowerBlue);
      target.Add(Color.Violet);
      expected = -1;

      // act
      actual = target.Find(Color.FromArgb(128, Color.CornflowerBlue), false);

      // assert
      actual.Should().Be(expected);
    }

    [Test]
    public void FindIgnoreAlphaTest()
    {
      // arrange
      ColorCollection target;
      int expected;
      int actual;

      target = new ColorCollection();
      target.Add(Color.Black);
      target.Add(Color.CornflowerBlue);
      target.Add(Color.Violet);
      expected = 1;

      // act
      actual = target.Find(Color.FromArgb(128, Color.CornflowerBlue), true);

      // assert
      actual.Should().Be(expected);
    }

    [Test]
    public void FindNegativeTest()
    {
      // arrange
      ColorCollection target;
      int expected;
      int actual;

      target = new ColorCollection();
      target.Add(Color.Black);
      target.Add(Color.CornflowerBlue);
      target.Add(Color.Violet);
      expected = -1;

      // act
      actual = target.Find(Color.Yellow);

      // assert
      actual.Should().Be(expected);
    }

    [Test]
    public void FindTest()
    {
      // arrange
      ColorCollection target;
      int expected;
      int actual;

      target = new ColorCollection();
      target.Add(Color.Black);
      target.Add(Color.CornflowerBlue);
      target.Add(Color.Violet);
      expected = 1;

      // act
      actual = target.Find(Color.FromArgb(100, 149, 237));

      // assert
      actual.Should().Be(expected);
    }

    #endregion
  }
}
