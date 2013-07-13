using System.IO;

namespace Cyotek.Windows.Forms
{
  // Cyotek Color Picker controls library
  // Copyright © 2013 Cyotek. All Rights Reserved.
  // http://cyotek.com/blog/tag/colorpicker

  // If you use this code in your applications, donations or attribution are welcome

  /// <summary>
  /// Serializes and deserializes color palettes into and from other documents.
  /// </summary>
  public interface IPaletteSerializer
  {
    #region Members

    /// <summary>
    /// Deserializes the <see cref="ColorCollection"/> contained by the specified <see cref="Stream"/>.
    /// </summary>
    /// <param name="stream">The <see cref="Stream"/> that contains the palette to deserialize.</param>
    /// <returns>The <see cref="ColorCollection"/> being deserialized.</returns>
    ColorCollection Deserialize(Stream stream);

    /// <summary>
    /// Serializes the specified <see cref="ColorCollection"/> and writes the palette to a file using the specified <see cref="Stream"/>.
    /// </summary>
    /// <param name="stream">The <see cref="Stream"/> used to write the palette.</param>
    /// <param name="palette">The <see cref="ColorCollection"/> to serialize.</param>
    void Serialize(Stream stream, ColorCollection palette);

    #endregion
  }
}
