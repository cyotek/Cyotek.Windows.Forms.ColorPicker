# Cyotek.Windows.Forms.ColorPickers Control Collection

[![Build status][cibadge]][ci] [![NuGet][nugetbadge]][nuget]

The **Cyotek.Windows.Forms.ColorPickers** library contains a
series of custom controls and utility classes for Windows Forms
applications that work with colours. Controls are available to
allow colour selection via a HSL `ColorWheel`, a `ColorGrid`
with many customisation options, a `ColorEditor` for entering
colours via RGB or HSL, and a `ScreenColorPicker` for capturing
colours from running applications.

Color palettes can be loaded and saved in a number of different
formats, including Adobe PhotoShop Color Swatch files, JASC
Palettes, Gimp Palettes and more (see Color Palettes and
External Palette Files below).

For more information on these controls, see the [articles tagged
with `colorpicker`][blogtag] at cyotek.com.

## Getting the library

The easiest way of obtaining the library is via [NuGet][nuget].

> `Install-Package Cyotek.Windows.Forms.ColorPicker`

If you don't use NuGet, pre-compiled binaries can be obtained
from the [GitHub Releases page][ghrel].

Of course, you can always grab [the source][ghsrc] and build it
yourself!

## Controls

There are three primary controls (`ColorGrid`, `ColorWheel` and
`ColorEditor`), along with 5 utility controls
(`ScreenColorPicker`, `RgbaColorSlider`, `HueColorSlider`,
`LightnessColorSlider` and `SaturationColorSlider`), a
management component (`ColorEditorManager`) and one dialog
(`ColorPickerDialog`). Combined together, these provide a decent
array of tools for colour selection.

### ColorGrid Control

![ColorGrid control demonstration][colorgridscreen]

This control displays a grid of colours, and supports both a
primary palette, and a custom colour palette. Several properties
are available for configuring the appearing of the control, and
there are behaviour options too, such as built in editing of
colours and support for automatically adding new colours not in
the primary palette.

### ColorWheel Control

![ColorWheel control demonstration][colorwheelscreen]

This control displays a radial wheel of RGB colours and allows
selection from any point in the wheel. The `ShowAngleArrow`,
`ShowCenterLines` and `ShowSaturationRing` properties can be
used to display useful adornments, while the `Lightness` and
`Alpha` properties can be used to compose the final colour while
not being directly editable on the wheel.

The `SecondaryColors` and `SecondarySelectionSize` properties
allow you to display additional colours on the wheel, for
example for showing relationships.

### ColorSlider Controls

![ColorSlider controls demonstration][colorsliderscreen]

A bunch of controls (inheriting from a single base) that allow
selection of values via a colourful bar. Similar to the
`TrackBar` control you have a few options for specifying the
drag handle's position and bar orientation. You can also
customise the fill and outline colour, or replace it completely
with a custom image.

### ColorEditor Control

![ColorEditor control demonstration][coloreditorscreen]

This control allows the editing of a RGB or HSL colour via a
standard interface. You can also enter colours via 6 or 8
character hexadecimal notation, or choose from named web and
system colors.

Use of the alpha channel can be configured via the
`ShowAlphaChannel` and `PreserveAlphaChannel` properties. The
`ShowHex`, `ShowHsl` and `ShowRgb` properties can be used to
show or hide groups of editors.

### ScreenColorPicker Control

![ScreenColorPicker control demonstration][screenpickerscreen]

This control allows the user to pick a colour from any pixel
displayed on the screen. The user can either trigger the
operation by clicking and dragging the control, or it can be
done programmatically via the `CaptureMouse` method, allowing
selections to be triggered via other actions, for example a hot
key. The `Zoom` property can be used set the grid size of the
preview.

### ColorPickerDialog Form

![ColorPickerDialog form demonstration][colordialogscreen]

This form puts together the previous controls in a ready to use
dialog.

Custom colours are supported via the `CustomColors` property,
and users can also load or save external palette files into
these. You can use the `ShowLoad` and `ShowSave` properties to
enable or disable this, and the `CustomColorsLoading` and
`CustomColorsSaving`events to override the built-in behaviour
and provide your own logic.

### ColorEditorManager

![ColorEditorManager compnent demonstration][coloreditormanagerscreen]

This is a non-GUI component that you can drop onto a form, and
bind to other controls in this library. When the `Color`
property of one control changes, it is reflected in the others
without having to lift a finger. Useful if you're creating
composite displays from multiple controls.

## Color Palettes and External Palette Files

The `ColorGrid` control has `Colors` and `CustomColors`
properties which return a `ColorCollection`. These two
properties make it easier as a developer to keep separate a
primary palette whilst having the flexibility of custom colours,
although it does complicate the control's internal logic a bit!
The grid will automatically populate custom colours if you try
and set the control's `Color` to a value not currently defined.

As well as manually populating `ColorCollection` instances, you
can also load in external palette files. The following palette
formats are supported:

* Adobe Color Table (*.act)
* Adobe PhotoShop Color Swatch (*.aco)
* GIMP (*.gpl)
* Deluxe Paint (*.bbm; *.lbm) [read only]
* JASC (*.pal)
* Paint.NET (*.txt)
* Raw RGB Triplets (*.pal)

With the exception of the ILBM image format, all other formats
can be exported as well as imported.

Additional palette serializers can be easily created by adding a
class which implements `IPaletteSerializer`. The
`ColorPickerDialog` (or any custom code using
`PaletteSerializer` static methods) will automatically detect
and make available custom palettes via reflection.

## Keyboard Support

All GUI components, with the exception of the
`ScreenColorPicker` include full keyboard/focus support. Many
controls support `SmallChange` and `LargeChange` properties
which influence how navigation keys are processed. Although in
the case of the `ColorWheel` it's not really a bonus... but
that's what the `ColorEditor` control is best suited for!

## Requirements

.NET Framework 3.5 or later.

Pre-built binaries are available via a signed [NuGet
package][nuget] containing the following targets.

* .NET 3.5
* .NET 4.0
* .NET 4.5.2
* .NET 4.6.2
* .NET 4.7.2
* .NET 4.8
* .NET 5.0

## Contributing to this code

Contributions accepted!

* Found a problem? [Raise an issue][ghissue]
* Want to improve the code? [Make a pull request][ghpull]

Alternatively, if you make use of this software and it saves you
some time, donations are welcome.

[![PayPal Donation][paypalimg]][paypal]

[![By Me a Coffee Donation][bmacimg]][bmac]

## Known Issues

* XML documentation comments are incomplete

## Related Reading

* [Reading Photoshop Color Swatch (aco) files using C#]
* [Writing Photoshop Color Swatch (aco) files using C#]
* [Loading the color palette from a BBM/LBM image file using C#]
* [Hosting a ColorGrid control in a ToolStrip]

## Acknowledgements

* Inspiration (and some code!) was taken from [Color Picker with
  Color Wheel and Eye Dropper]
* The icon used by the demonstration is from the [Crystal
  Project Icons]
* The eye dropper png graphic is from the [Momentum Glossy
  Icons]
* [DawnBringer 16 color palette]
* [DawnBringer 32 color palette]
* The Atari 800 XL color palette by [Space Monster Games]
* [Arne Palette v20]

[Color Picker with Color Wheel and Eye Dropper]: http://www.codeproject.com/Articles/21965/Color-Picker-with-Color-Wheel-and-Eye-Dropper
[Crystal Project Icons]: http://www.iconfinder.com/icondetails/17937/128/color_color_scheme_icons_renk_icon
[Momentum Glossy Icons]: http://www.iconfinder.com/icondetails/84569/32/eyedropper_icon
[DawnBringer 16 color palette]: http://www.pixeljoint.com/forum/forum_posts.asp?TID=12795
[DawnBringer 32 color palette]: http://www.pixeljoint.com/forum/forum_posts.asp?TID=16247
[Space Monster Games]: http://www.spacemonsters.co.uk/2011/10/the-atari-colour-palette/
[Arne Palette v20]: http://androidarts.com/palette/16pal.htm

[Reading Photoshop Color Swatch (aco) files using C#]: http://cyotek.com/blog/reading-photoshop-color-swatch-aco-files-using-csharp
[Writing Photoshop Color Swatch (aco) files using C#]: http://cyotek.com/blog/writing-photoshop-color-swatch-aco-files-using-csharp
[Loading the color palette from a BBM/LBM image file using C#]: http://cyotek.com/blog/loading-the-color-palette-from-a-bbm-lbm-image-file-using-csharp
[Hosting a ColorGrid control in a ToolStrip]: http://www.cyotek.com/blog/hosting-a-colorgrid-control-in-a-toolstrip

[blogtag]: http://www.cyotek.com/blog/tag/colorpicker
[colorgridscreen]: res/cp-colorgridcontrol.png
[colorwheelscreen]: res/cp-colorwheelcontrol.png
[colorsliderscreen]: res/cp-colorslidercontrols.png
[coloreditorscreen]: res/cp-coloreditorcontrol.png
[screenpickerscreen]: res/cp-screencolorpickercontrol.png
[colordialogscreen]: res/cp-colorpickerdialog.png
[coloreditormanagerscreen]: res/cp-coloreditormanager.gif

[nuget]: https://www.nuget.org/packages/Cyotek.Windows.Forms.ColorPicker/
[nugetbadge]: https://img.shields.io/nuget/vpre/Cyotek.Windows.Forms.ColorPicker

[ci]: https://ci.appveyor.com/project/cyotek/cyotek-windows-forms-colorpicker
[cibadge]: https://img.shields.io/appveyor/build/cyotek/cyotek-windows-forms-colorpicker

[ghissue]: https://github.com/cyotek/Cyotek.Windows.Forms.ColorPicker/issues
[ghpull]: https://github.com/cyotek/Cyotek.Windows.Forms.ColorPicker/pulls
[ghrel]: https://github.com/cyotek/Cyotek.Windows.Forms.ColorPicker/releases
[ghsrc]: https://github.com/cyotek/Cyotek.Windows.Forms.ColorPicker

[paypal]: https://www.paypal.me/cyotek
[paypalimg]: https://static.cyotek.com/assets/images/donate.gif
[bmac]: https://www.buymeacoffee.com/cyotek
[bmacimg]: https://static.cyotek.com/assets/images/bmac.png
