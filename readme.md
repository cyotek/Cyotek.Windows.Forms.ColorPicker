# Cyotek.Windows.Forms.ColorPickers

Cyotek.Windows.Forms.ColorPickers is a series of custom controls for Windows Forms applications that allows you to select a color. Colors can be selected via a HSL `ColorWheel`, a `ColorGrid` with many customisation options, a `ColorEditor` for entering colors via RGB or HSL, and a `ScreenColorPicker` for capturing colors from running applications.

For more information on these controls, see the [articles tagged with colorpicker](http://cyotek.com/blog/tag/colorpicker) at cyotek.com.

### ColorGrid Control

![ColorGrid control demonstration](http://static.cyotek.com/files/articleimages/cp-colorgridcontrol.png)

This control displays a grid of colors, and supports both a primary palette, and a custom color palete. Several properties are available for configuring the appearing of the control, and there are behaviour options too, such as built in editing of colors and support for automatically adding new colors not in the primary palette.

### ColorWheel Control

![ColorWheel control demonstration](http://static.cyotek.com/files/articleimages/cp-colorwheelcontrol.png)

This control displays a radial wheel of colors and allows selection from any point in the wheel. Not much in the way of customisation for this control!

### ColorSlider Controls

![ColorSlider controls demonstration](http://static.cyotek.com/files/articleimages/cp-colorslidercontrols.png)

A bunch of controls (inheriting from a single base) that allow selection of values via a colourful bar. Similar to the `TrackBar` control you have a few options for specifying the drag handle's position and bar orientation.

### ColorEditor Control

![ColorEditor control demonstration](http://static.cyotek.com/files/articleimages/cp-coloreditorcontrol.png)

This control allows the editing of a RGB or HSL color via a standard interface.

### ScreenColorPicker Control

![ScreenColorPicker control demonstration](http://static.cyotek.com/files/articleimages/cp-screencolorpickercontrol.png)

This control allows the user to pick a color from any pixel displayed on the screen. 

### ColorPickerDialog Form

![ColorPickerDialog form demonstration](http://static.cyotek.com/files/articleimages/cp-colorpickerdialog.png)

This form puts together the previous controls in a ready to use dialog.

### ColorEditorManager

This is a non-GUI component that you can drop onto a form, and bind to other controls in this library. When the `Color` property of one control changes, it is reflected in the others without having to lift a finger. Useful if you're creating composite displays from multiple controls.

### Color Palettes

The `ColorGrid` control has `Colors` and `CustomColors` properties which return a `ColorCollection`. These two properties make it easier as a developer to keep separate a primary palette whilst having the flexibility of custom colors, although it does complicate the control's internal logic a bit! The grid will automatically populate custom colors if you try and set the control's `Color` to a value not currently defined.

As well as manually populating `ColorCollection` instances, you can also load in external palette files. Paint.NET and the age old JASC 1.0 formats are currently supported. 

### Keyboard Support

All GUI components, with the exception of the `ScreenColorPicker` include full keyboard/focus support. Many controls support `SmallChange` and `LargeChange` properties which influence how navigation keys are processed. Although in the case of the `ColorWheel` it's not really a bonus... but that's what the `ColorEditor` control is best suited for!

### Known Issues

* XML documentation comments are incompleted
* The `ColorEditorManager` control currently allows you to bind to the `LightnessColorSlider` control, but doesn't fully support it yet

### Acknowledgements
* Inspiration (and some code!) was taken from [Color Picker with Color Wheel and Eye Dropper](http://www.codeproject.com/Articles/21965/Color-Picker-with-Color-Wheel-and-Eye-Dropper)
* The icon used by the demonstration is from the [Crystal Project Icons](http://www.iconfinder.com/icondetails/17937/128/color_color_scheme_icons_renk_icon)
* The eye dropper png graphic is from the [Momentum Glossy Icons](http://www.iconfinder.com/icondetails/84569/32/eyedropper_icon)