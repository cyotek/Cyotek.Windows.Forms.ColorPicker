# Change Log

## 1.0.2.3
### Changes and new features
* Added static `LoadPalette` and instance `Load` methods to `ColorCollection`
* Added `Save` method to `ColorCollection`
* Added new constructor to `ColorCollection` that accepts a `System.Drawing.Imaging.ColorPalette` class.
* Added new `AutoFit` property to the `ColorGrid`. When set, the `CellSize` property is automatically calculated based on the size of the control, and its contents. You can't combine `AutoFit` with `AutoSize`.
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