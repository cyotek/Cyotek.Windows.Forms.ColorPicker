# Change Log

## 1.0.2.0
* **BREAKING CHANGE:** `IPaletteReader` replaced with `IPaletteSerializer`
* **BREAKING CHANGE:** `JascPaletteReader` replaced with `JascPaletteSerializer`
* **BREAKING CHANGE:** `GimpPaletteReader` replaced with `GimpPaletteSerializer`
* **BREAKING CHANGE:** `PaintNetPaletteReader` replaced with `PaintNetPaletteSerializer`
* **BREAKING CHANGE:** The values of the `ColorEditingMode` enum have been renamed to make more sense.
* The `ColorEditor` now supports selecting of named colors as the hex editor is now a dropdown list. As well as being able to select named colors from the list, you can now also type names directly into the hex editor and they will be processed accordingly.
* The `ColorPickerDialog` now can load and save palette files
* Palette support has been reworked to allow the saving of palettes as well as loading. Unfortunately due to the initial names of these classes this is a breaking change.
* Added a bit more documentation
* Corrected some grammatical errors in existing documentation and headers

## 1.0.1.0
* Added `GimpPaletteReader` for reading palette files created by Gimp
* Added `ReadPalette(fileName)` overload to `IPaletteReader`
* Renamed `Jasc10PaletteReader` to `JascPaletteReader`
* Reworked Jasc palette import to match how Gimp is doing it
* Added a testing project. Currently this just tests the different palette readers are importing data correctly.

## 1.0.0.0
* Initial Release