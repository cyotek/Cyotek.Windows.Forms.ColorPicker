# Change Log

## 1.0.1.0
* Added `GimpPaletteReader` for reading palette files created by Gimp
* Added `ReadPalette(fileName)` overload to `IPaletteReader`
* Renamed `Jasc10PaletteReader` to `JascPaletteReader`
* Reworked Jasc palette import to match how Gimp is doing it
* Added a testing project. Currently this just tests the different palette readers are importing data correctly.

## 1.0.0.0
* Initial Release