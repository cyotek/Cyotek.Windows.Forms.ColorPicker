# Change Log

## 1.0.3.0
### Changes and new features
* Added `Find` method to `ColorCollection`
* Replaced `ColorComparer.Brightness` with version derived from [here](http://stackoverflow.com/a/13558570/148962)
* Added new `InterleavedBitmapPaletteSerializer` class, that allows palettes to be loaded from  ILBM (IFF Interleaved Bitmap) format files (LBM images or BBM palettes). *Note:* Writing is not [yet supported](http://cyotek.com/blog/loading-the-color-palette-from-a-bbm-lbm-image-file-using-csharp).
* Added `CanRead` and `CanWrite` properties to `IPaletteSerializer` to indicate input/output support.
* The `PaletteSerializer.DefaultOpenFilter` and `PaletteSerializer.DefaultSaveFilter` make use of the above properties when building filters
* Added the ability for multiple extensions to be supplied.
* The colors displayed in the drop down list component of the `ColorEditor` now only load when the drop down is opened, or the **Up**, **Down**, **Page Up** or **Page Down** keys are pressed
* Reworked the `ColorEditor` control to work nicer with RGB colors. Previously, the `Color` property was a wrapper around the `HslColor` property, meaning if you set it to a named color such as `Color.Red`, the name was lost, and the hex/name editor didn't show the name. Now it keeps track of both colors, so if you set it to a named value, you can see (and get) the named value back.
* Reworked the `ColorEditorManager` component to also store seperate copies of the RGB/HSL colors intead of loosing named color information
* Experimented with making the `hex/named color` field in the `ColorEditor` control slightly wider than the other controls. Looks a touch odd now that all fields aren't a uniform width, but does make it much easier to read that the selected color is `LightGoldenRodYellow`!

### Bug Fixes
* Setting the `SelectionSize` property of the `ColorWheel` didn't resize the wheel as it was supposed to
* When the orientation of a `ColorSlider` (or derived control) was `Vertical`, the color bar was drawn in the reverse order of the scale.
* Changing the `Value` of the `LightnessColorSlider` control now correctly updates the `Color` property of that control, in turn making the `ColorEditorManager` change the luminosity of linked controls. Also setting the `Color` of the `LightnessColorSlider` now correctly updates the `Value`. This now means you can bind a `ColorWheel` to a `LightnessColorSlider` for full control over the brightness of a color, which is not possible to do with the wheel alone.

## 1.0.2.3
### Changes and new features
* Added static `LoadPalette` and instance `Load` methods to `ColorCollection`
* Added `Save` method to `ColorCollection`
* Added new constructor to `ColorCollection` that accepts a `System.Drawing.Imaging.ColorPalette` class.
* Added new `AutoFit` property to the `ColorGrid`. When set, the `CellSize` property is automatically calculated based on the size of the control, and its contents. You can't combine `AutoFit` with `AutoSize`.
* `ColorCollection` is now cloneable

### Bug Fixes
* Removed unnecessary `UpdateStyles` calls.
* Fixed a problem if a window was opened by pressing `Enter`, and a `ColorGrid` was the first focusable control on the new window, the popup color editing dialog would be activated, regardless of the `ColorGrid`'s editing settings 

## 1.0.2.2
### Changes and new features
* Added `Name` and `DefaultExtension` properties to `IPaletteSerializer`
* Added new static properties `DefaultOpenFilter` and `DefaultSaveFilter`, and static method `GetSerializer` to `PaletteSerializer`. These allow the use of reflection for easily providing palette load and save functionality automatically based on loaded assemblies.
* Added the `SupportsTransparentBackColor` control style to `ColorGrid`
* Added system colors to the `ColorEditor` named color dropdown
* Added a new `DoubleSoft` cell border style to the `ColorGrid`

### Bug fixes
* Setting the `Spacing` or `CellSize` properties of the `ColorGrid` control didn't recalculate the layout
* `ColorEditor` now uses `TextRenderer.DrawText` instead of `Graphics.DrawString` so all text is rendered consistently.

## 1.0.2.1
### Changes and new features
* Added new constructor to the `ColorCollection` class that accepts an `IEnumerable<int>`
* `ColorCollection` now implements `IClonable`
* Added dotted outline to design time `ColorGrid` control

### Bug fixes
* Fixed invalid default value for the `EditMode` property of a `ColorGrid`
* Fixed `AutoSize` property of `ColorGrid` control not being persisted

## 1.0.2.0
> *Note: Several of the updates in this version are breaking changes due to renaming of classes and enum values. Some more changes to your code will be required to use the new Color Picker API.*

### Changes and new features
* `IPaletteReader` replaced with `IPaletteSerializer`
* `JascPaletteReader` replaced with `JascPaletteSerializer`
* `GimpPaletteReader` replaced with `GimpPaletteSerializer`
* `PaintNetPaletteReader` replaced with `PaintNetPaletteSerializer`
* The values of the `ColorEditingMode` enum have been renamed to make more sense.
* The `ColorEditor` now supports selecting of named colors as the hex editor is now a dropdown list. As well as being able to select named colors from the list, you can now also type names directly into the hex editor and they will be processed accordingly.
* The `ColorPickerDialog` now can load and save palette files
* Palette support has been reworked to allow the saving of palettes as well as loading. Unfortunately due to the initial names of these classes this is a breaking change.
* Added a bit more documentation

### Bug fixes
* Corrected some grammatical errors in existing documentation and headers

## 1.0.1.0
> *Note: Several of the updates in this version are breaking changes due to renaming of classes and enum values. Some more changes to your code will be required to use the new Color Picker API.*

### Changes and new features
* Added `GimpPaletteReader` for reading palette files created by Gimp
* Added `ReadPalette(fileName)` overload to `IPaletteReader`
* Renamed `Jasc10PaletteReader` to `JascPaletteReader`
* Reworked Jasc palette import to match how Gimp is doing it
* Added a testing project. Currently this just tests the different palette readers are importing data correctly.

## 1.0.0.0
* Initial Release
