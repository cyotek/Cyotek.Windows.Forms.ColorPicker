// Cyotek Color Picker Controls Library
// http://cyotek.com/blog/tag/colorpicker

// Copyright (c) 2021 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.cyotek.com/contribute

using NUnit.Framework;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms.ColorPicker.Tests
{
  [TestFixture]
  public class ColorGridTests
  {
    #region Public Properties

    public static IEnumerable<TestCaseData> NavigateOriginTestCaseSource
    {
      get
      {
        yield return new TestCaseData(15, 0, 0, NavigationOrigin.Current, 15).SetName("{m}None");
        yield return new TestCaseData(0, -1, 0, NavigationOrigin.Current, 0).SetName("{m}LeftBoundary");
        yield return new TestCaseData(0, 0, -1, NavigationOrigin.Current, 0).SetName("{m}UpBoundary");
        yield return new TestCaseData(15, -1, 0, NavigationOrigin.Current, 14).SetName("{m}Left");
        yield return new TestCaseData(15, 1, 0, NavigationOrigin.Current, 16).SetName("{m}Right");
        yield return new TestCaseData(15, 0, -1, NavigationOrigin.Current, 5).SetName("{m}Up");
        yield return new TestCaseData(15, 0, 1, NavigationOrigin.Current, 25).SetName("{m}Down");
        yield return new TestCaseData(69, 0, 1, NavigationOrigin.Current, 78).SetName("{m}DownToPartialRow");
        yield return new TestCaseData(88, 0, -1, NavigationOrigin.Current, 78).SetName("{m}UpToPartialRow");
        yield return new TestCaseData(15, -1, 0, NavigationOrigin.Begin, 0).SetName("{m}LeftStart");
        yield return new TestCaseData(15, 1, 0, NavigationOrigin.Begin, 1).SetName("{m}RightStart");
        yield return new TestCaseData(15, 0, -1, NavigationOrigin.Begin, 0).SetName("{m}UpStart");
        yield return new TestCaseData(15, 0, 1, NavigationOrigin.Begin, 10).SetName("{m}DownStart");
        yield return new TestCaseData(15, -1, 0, NavigationOrigin.End, 97).SetName("{m}LeftEnd");
        yield return new TestCaseData(15, 1, 0, NavigationOrigin.End, 97).SetName("{m}RightEnd");
        yield return new TestCaseData(15, 0, -1, NavigationOrigin.End, 88).SetName("{m}UpEnd");
        yield return new TestCaseData(15, 0, 1, NavigationOrigin.End, 97).SetName("{m}DownEnd");
      }
    }

    public static IEnumerable<TestCaseData> NavigateTestCaseSource
    {
      get
      {
        yield return new TestCaseData(15, ColorGridNavigationMode.None, 15).SetName("{m}None");
        yield return new TestCaseData(0, ColorGridNavigationMode.Previous, 0).SetName("{m}LeftBoundary");
        yield return new TestCaseData(0, ColorGridNavigationMode.PreviousRow, 0).SetName("{m}UpBoundary");
        yield return new TestCaseData(15, ColorGridNavigationMode.Previous, 14).SetName("{m}Left");
        yield return new TestCaseData(15, ColorGridNavigationMode.Next, 16).SetName("{m}Right");
        yield return new TestCaseData(15, ColorGridNavigationMode.PreviousRow, 5).SetName("{m}Up");
        yield return new TestCaseData(15, ColorGridNavigationMode.NextRow, 25).SetName("{m}Down");
        yield return new TestCaseData(69, ColorGridNavigationMode.NextRow, 78).SetName("{m}DownToPartialRow");
        yield return new TestCaseData(88, ColorGridNavigationMode.PreviousRow, 78).SetName("{m}UpToPartialRow");
        yield return new TestCaseData(0, ColorGridNavigationMode.Previous, 0).SetName("{m}LeftStart");
        yield return new TestCaseData(0, ColorGridNavigationMode.Next, 1).SetName("{m}RightStart");
        yield return new TestCaseData(0, ColorGridNavigationMode.PreviousRow, 0).SetName("{m}UpStart");
        yield return new TestCaseData(0, ColorGridNavigationMode.NextRow, 10).SetName("{m}DownStart");
        yield return new TestCaseData(97, ColorGridNavigationMode.Previous, 96).SetName("{m}LeftEnd");
        yield return new TestCaseData(97, ColorGridNavigationMode.NextRow, 97).SetName("{m}RightEnd");
        yield return new TestCaseData(97, ColorGridNavigationMode.PreviousRow, 88).SetName("{m}UpEnd");
        yield return new TestCaseData(97, ColorGridNavigationMode.NextRow, 97).SetName("{m}DownEnd");
        yield return new TestCaseData(69, ColorGridNavigationMode.NextRow, 78).SetName("{m}DownToStaggeredPrimary");
        yield return new TestCaseData(70, ColorGridNavigationMode.NextRow, 79).SetName("{m}DownStartStaggeredPrimary");
        yield return new TestCaseData(78, ColorGridNavigationMode.NextRow, 87).SetName("{m}DownEndStaggeredPrimary");
        yield return new TestCaseData(78, ColorGridNavigationMode.PreviousRow, 68).SetName("{m}UpEndStaggeredPrimary");
        yield return new TestCaseData(88, ColorGridNavigationMode.NextRow, 97).SetName("{m}DownToStaggeredSecondary");
        yield return new TestCaseData(88, ColorGridNavigationMode.PreviousRow, 78).SetName("{m}UpToStaggeredPrimary");
        yield return new TestCaseData(97, ColorGridNavigationMode.PreviousRow, 87).SetName("{m}UpEndStaggeredPrimary");
      }
    }

    #endregion Public Properties

    #region Public Methods

    [Test]
    [TestCaseSource(nameof(NavigateOriginTestCaseSource))]
    public void NavigateOriginTestCases(int index, int c, int r, NavigationOrigin origin, int expected)
    {
      // arrange
      ColorGrid target;
      int actual;

      target = this.CreateGrid();
      target.ColorIndex = index;

      // act
      target.Navigate(c, r, origin);

      // assert
      actual = target.ColorIndex;
      Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(nameof(NavigateTestCaseSource))]
    public void NavigateTestCases(int index, ColorGridNavigationMode mode, int expected)
    {
      // arrange
      ColorGrid target;
      int actual;

      target = this.CreateGrid();
      target.ColorIndex = index;

      // act
      target.Navigate(mode);

      // assert
      actual = target.ColorIndex;
      Assert.AreEqual(expected, actual);
    }

    #endregion Public Methods

    #region Private Methods

    private ColorGrid CreateGrid() => new ColorGrid
    {
      AutoAddColors = false,
      Size = new Size(100, 100),
      Padding = Padding.Empty,
      Spacing = Size.Empty,
      Columns = 10,
      Colors = new ColorCollection(Enumerable.Repeat(Color.White, 79)),
      CustomColors = new ColorCollection(Enumerable.Repeat(Color.White, 19)),
      Color = Color.White
    };

    #endregion Private Methods
  }
}
