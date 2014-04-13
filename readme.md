# Cyotek.Windows.Forms.ColorPickers

The Cyotek.Windows.Forms.ColorPickers library contains a series of custom controls and utility classes for Windows Forms applications that work with colours. Controls are available to allow colour selection via a HSL `ColorWheel`, a `ColorGrid` with many customisation options, a `ColorEditor` for entering colours via RGB or HSL, and a `ScreenColorPicker` for capturing colours from running applications.

Color palettes can be loaded and saved in a number of different formats, including Adobe PhotoShop Color Swatch files, JASC Palettes, Gimp Palettes and more.

For more information on these controls, see the [articles tagged with colorpicker](http://cyotek.com/blog/tag/colorpicker) at cyotek.com.

## ColorGrid Control

![ColorGrid control demonstration](http://static.cyotek.com/files/articleimages/cp-colorgridcontrol.png)

This control displays a grid of colours, and supports both a primary palette, and a custom colour palette. Several properties are available for configuring the appearing of the control, and there are behaviour options too, such as built in editing of colours and support for automatically adding new colours not in the primary palette.

## ColorWheel Control

![ColorWheel control demonstration](http://static.cyotek.com/files/articleimages/cp-colorwheelcontrol.png)

This control displays a radial wheel of colours and allows selection from any point in the wheel. Not much in the way of customisation for this control!

## ColorSlider Controls

![ColorSlider controls demonstration](http://static.cyotek.com/files/articleimages/cp-colorslidercontrols.png)

A bunch of controls (inheriting from a single base) that allow selection of values via a colourful bar. Similar to the `TrackBar` control you have a few options for specifying the drag handle's position and bar orientation.

## ColorEditor Control

![ColorEditor control demonstration](http://static.cyotek.com/files/articleimages/cp-coloreditorcontrol.png)

This control allows the editing of a RGB or HSL colour via a standard interface.

## ScreenColorPicker Control

![ScreenColorPicker control demonstration](http://static.cyotek.com/files/articleimages/cp-screencolorpickercontrol.png)

This control allows the user to pick a colour from any pixel displayed on the screen. 

## ColorPickerDialog Form

![ColorPickerDialog form demonstration](http://static.cyotek.com/files/articleimages/cp-colorpickerdialog.png)

This form puts together the previous controls in a ready to use dialog.

## ColorEditorManager

This is a non-GUI component that you can drop onto a form, and bind to other controls in this library. When the `Color` property of one control changes, it is reflected in the others without having to lift a finger. Useful if you're creating composite displays from multiple controls.

## Color Palettes

The `ColorGrid` control has `Colors` and `CustomColors` properties which return a `ColorCollection`. These two properties make it easier as a developer to keep separate a primary palette whilst having the flexibility of custom colours, although it does complicate the control's internal logic a bit! The grid will automatically populate custom colours if you try and set the control's `Color` to a value not currently defined.

As well as manually populating `ColorCollection` instances, you can also load in external palette files. The following palette formats a supported:

* Adobe PhotoShop Color Swatch (*.aco)
* GIMP (*.gpl)
* Deluxe Paint (*.bbm; *.lbm) [read only]
* JASC (*.pal)
* Paint.NET (*.txt)
* Raw RGB Triplets (*.pal)

With the exception of the ILBM image format, all other formats can be exported as well as imported.

## Keyboard Support

All GUI components, with the exception of the `ScreenColorPicker` include full keyboard/focus support. Many controls support `SmallChange` and `LargeChange` properties which influence how navigation keys are processed. Although in the case of the `ColorWheel` it's not really a bonus... but that's what the `ColorEditor` control is best suited for!

## Related Reading

* [Reading Photoshop Color Swatch (aco) files using C#](http://cyotek.com/blog/reading-photoshop-color-swatch-aco-files-using-csharp)
* [Writing Photoshop Color Swatch (aco) files using C#](http://cyotek.com/blog/writing-photoshop-color-swatch-aco-files-using-csharp)
* [Loading the color palette from a BBM/LBM image file using C#](http://cyotek.com/blog/loading-the-color-palette-from-a-bbm-lbm-image-file-using-csharp)

## Known Issues

* XML documentation comments are incomplete

