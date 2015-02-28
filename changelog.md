# Change Log

## 1.0.5.0
* Added a new demonstration which shows how to host a `ColorGrid` control in a `ToolStrip`. More details on this can be found on [cyotek.com](http://www.cyotek.com/blog/hosting-a-colorgrid-control-in-a-toolstrip).
* Added new `PreviewColorChanged` event to the `ColorPickerDialog`
* Added new `PaintColor` protected methods to the `ColorWheel` control allowing additional hotspots to be painted
* Added new constructor to the `ColorCollection` to copy the contents of another `ColorCollection`
* The `ColorGrid` control now to defaults to creating 16 custom colours instead of 32
* Fixed an issue where the `ColorGrid` control wasn't rendering the custom colours group correctly (regression from previous version). Thanks to [Michael Schwarz](https://github.com/xwcg) for pointing out the offending line of code
* Fixed an issue where the `ColorPickerDialog` displayed non-opaque colours when the `ShowAlphaChannel` property was `false`
* Fixed an issue where the `ColorEditor` control would allow you to enter an 8 character hex color and thus set an alpha channel even if the `ShowAlphaChannel` property was `false`

## 1.0.4.1
### Bug Fixes
* Fixed an issue where `GimpPaletteSerializer.Deserialize` could get itself stuck in an infinite loop if a GPL file was formatted a certain way
* `GimpPaletteSerializer.Serialize` now uses `ASCII` encoding instead of `UTF-8`, fixing a problem where palette files couldn't be opened in Inkscape.

## 1.0.4.0
### Changes and new features
* Added new `AdobePhotoShopColorSwatchSerializer` serializer for reading and writing Adobe PhotoShop colour swatches (both version 1 and version 2)
* You can now set the `Columns` property of a `ColorGrid` control to `0`, which will then internally calculate columns based on the size of the control, the cell size, and the spacing. A new read-only `ActualColumns` property has been added which will allow you to get the real number of columns if required. The `AutoSize` behaviour has been changed so that only the vertical height of the control is adjusted when `Columns` is zero
* **Save Palette** button in the `ColorPickerDialog` now obtains the serializer to use based on the selected filter index, allowing correct saving if multiple serializers use the same extension.
* Added `CanReadFrom` method to `IPaletteSerializer`.
* `PaletteSerializer.GetSerializer` now makes use of the above new method to access the relevant serializer rather than just matching extensions. This means if you have two serializers that support different .pal formatted files, these can now be loaded successfully, instead of one loading and one failing.
* Added new `RawPaletteSerializer` which reads and writes palettes that are simply RGB triplets in byte form
* Added new `ShowAlphaChannel` property to `ColorEditor` and `ColorPickerDialog`. This property allows the alpha channel editing controls to be hidden, for when working with 8-bit colours.
* The rendering of the selected cell in a `ColorGrid` control who's `SelectedCellStyle` is `Zoomed` now uses `Padding.Left` and `Padding.Top` to determine the size of the zoom box, avoiding massive boxes the larger the `CellSize` gets.
* Added a new standard 256 colour palette. You can use this in the `ColorGrid` by setting the `Palette` property to `ColorPalette.Standard256` or obtain the array of colours by calling `ColorPalettes.StandardPalette`
* `ColorGrid` and `RgbaColorSlider` controls now only create transparency brushes when required. A new virtual method `SupportsTransparentBackColor` allows inheritors to create their own brushes if required.
* Added `EditingColor` event to `ColorGrid`, allowing the edit colour action to be cancelled, or replaced with a custom editor
* Added `CurrentCell` property and `GetCellOffset` methods to the `ColorGrid`.
* `ColorCollection` now implements `IEquatable`
* Added more tests
* Added new `Navigate` method to `ColorGrid` for easier moving within the cells of the grid

### Bug Fixes
* The `ColorGrid` control now tries to be smarter with painting, and only paints cells that intersect with the clip rectangle. In addition, where possible only individual cells are invalidated rather than the entire control.
* Corrected invalid error messages from the **Save Palette** button in the `ColorPickerDialog`.
* **Load Palette** and **Save Palette** buttons in the `ColorPickerDialog` now check the `CanRead` and `CanWrite` properties of the serializer.
* Double clicking with any button other than the left in `ColorGrid` control no longer attempts to initiate colour editing
* Setting the `Color` property of the `ColorGrid` control to `Color.Empty` no longer treats the value as a valid colour
* The `ColorGrid` control no longer defines custom colour regions when the `ShowCustomColors` property was `false`. This manifested in hover and selection effects working if you moved your mouse over the bottom of a resized grid.
* Clicking "white space" areas of a `ColorWheel` control will no longer incorrectly set the colour to the closest matching point on the wheel itself. However, starting to select a colour within the wheel and then moving outside the bounds will continue to select the closest match as usual.
* Fixed a crash that occurred when creating controls that inherited from `ColorGrid` or `RgbaColorSlider`
* When the `AutoAddColors` and `ShowCustomColors` properties are `false`, unmatched colours will no longer be silently added to the `ColorGrid` custom palette unexpectedly. This also resolves various crashes after the colour regions fix above was applied.
* The `ColorWheel` control now makes use of `ButtonRenderer.DrawParentBackground` to draw itself, to avoid ugly blocks of solid colours when hosted in containers such as the `TabControl`
* The `ColorEditorManager` control's `ColorChanged` event has now been marked as the default event, so when you double click the component in the designer, a code window now correctly opens.
* If the underlying entry in a `ColorCollection` bound to a `ColorGrid` control was modified, and this particular entry was the selected colour, the `ColorGrid` would not keep its `Color` property in sync and would clear the selected index.
* Attempting to set the `Columns` property to less than zero now throws an `ArgumentOutOfRange` exception rather than setting it, then crashing later on
* Double clicking a colour in the grid of the `ColorPickerDialog` no longer opens another copy of the `ColorPickerDialog` 
* Fixed problems in the `ColorGrid` with keyboard navigation and initial focus if no valid colour index was set.
* The `ColorCollection.Find` method now correctly works when adding named colours (e.g. `Color.CornflowerBlue`) to the collection, but searching by ARGB value (e.g. `Color.FromArgb(100, 149, 237)`)
* Fixed an issue where if the internal dictionary lookup in `ColorCollection` class had been created and the collection was then updated, in some cases the lookup wasn't correctly modified.

## 1.0.3.0
### Changes and new features
* Added `Find` method to `ColorCollection`
* Replaced `ColorComparer.Brightness` with version derived from [here](http://stackoverflow.com/a/13558570/148962)
* Added new `InterleavedBitmapPaletteSerializer` class, that allows palettes to be loaded from  ILBM (IFF Interleaved Bitmap) format files (LBM images or BBM palettes). *Note:* Writing is not [yet supported](http://cyotek.com/blog/loading-the-color-palette-from-a-bbm-lbm-image-file-using-csharp).
* Added `CanRead` and `CanWrite` properties to `IPaletteSerializer` to indicate input/output support.
* The `PaletteSerializer.DefaultOpenFilter` and `PaletteSerializer.DefaultSaveFilter` make use of the above properties when building filters
* Added the ability for multiple extensions to be supplied.
* The colours displayed in the drop down list component of the `ColorEditor` now only load when the drop down is opened, or the **Up**, **Down**, **Page Up** or **Page Down** keys are pressed
* Reworked the `ColorEditor` control to work nicer with RGB colours. Previously, the `Color` property was a wrapper around the `HslColor` property, meaning if you set it to a named colour such as `Color.Red`, the name was lost, and the hex/name editor didn't show the name. Now it keeps track of both colours, so if you set it to a named value, you can see (and get) the named value back.
* Reworked the `ColorEditorManager` component to also store separate copies of the RGB/HSL colours instead of loosing named colour information
* Experimented with making the `hex/named colour` field in the `ColorEditor` control slightly wider than the other controls. Looks a touch odd now that all fields aren't a uniform width, but does make it much easier to read that the selected colour is `LightGoldenRodYellow`!

### Bug Fixes
* Setting the `SelectionSize` property of the `ColorWheel` didn't resize the wheel as it was supposed to
* When the orientation of a `ColorSlider` (or derived control) was `Vertical`, the colour bar was drawn in the reverse order of the scale.
* Changing the `Value` of the `LightnessColorSlider` control now correctly updates the `Color` property of that control, in turn making the `ColorEditorManager` change the luminosity of linked controls. Also setting the `Color` of the `LightnessColorSlider` now correctly updates the `Value`. This now means you can bind a `ColorWheel` to a `LightnessColorSlider` for full control over the brightness of a colour, which is not possible to do with the wheel alone.

## 1.0.2.3
### Changes and new features
* Added static `LoadPalette` and instance `Load` methods to `ColorCollection`
* Added `Save` method to `ColorCollection`
* Added new constructor to `ColorCollection` that accepts a `System.Drawing.Imaging.ColorPalette` class.
* Added new `AutoFit` property to the `ColorGrid`. When set, the `CellSize` property is automatically calculated based on the size of the control, and its contents. You can't combine `AutoFit` with `AutoSize`.
* `ColorCollection` is now clone-able

### Bug Fixes
* Removed unnecessary `UpdateStyles` calls.
* Fixed a problem if a window was opened by pressing `Enter`, and a `ColorGrid` was the first focusable control on the new window, the pop-up colour editing dialog would be activated, regardless of the `ColorGrid`'s editing settings 

## 1.0.2.2
### Changes and new features
* Added `Name` and `DefaultExtension` properties to `IPaletteSerializer`
* Added new static properties `DefaultOpenFilter` and `DefaultSaveFilter`, and static method `GetSerializer` to `PaletteSerializer`. These allow the use of reflection for easily providing palette load and save functionality automatically based on loaded assemblies.
* Added the `SupportsTransparentBackColor` control style to `ColorGrid`
* Added system colours to the `ColorEditor` named colour drop down
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
* The `ColorEditor` now supports selecting of named colours as the hex editor is now a drop down list. As well as being able to select named colours from the list, you can now also type names directly into the hex editor and they will be processed accordingly.
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
