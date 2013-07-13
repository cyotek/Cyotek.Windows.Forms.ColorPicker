using System.IO;

namespace Cyotek.Windows.Forms
{
  /// <summary>
  /// Serializes and deserializes color palettes into and from other documents.
  /// </summary>
  public abstract class PaletteSerializer : IPaletteSerializer
  {
    #region Members

    /// <summary>
    /// Deserializes the <see cref="ColorCollection" /> contained by the specified <see cref="Stream" />.
    /// </summary>
    /// <param name="stream">The <see cref="Stream" /> that contains the palette to deserialize.</param>
    /// <returns>The <see cref="ColorCollection" /> being deserialized..</returns>
    public abstract ColorCollection Deserialize(Stream stream);

    /// <summary>
    /// Deserializes the <see cref="ColorCollection" /> contained by the specified <see cref="Stream" />.
    /// </summary>
    /// <param name="fileName">The name of the file that the palette will be read from.</param>
    /// <returns>The <see cref="ColorCollection" /> being deserialized.</returns>
    public ColorCollection Deserialize(string fileName)
    {
      if (!File.Exists(fileName))
        throw new FileNotFoundException(string.Format("Cannot find file '{0}'", fileName), fileName);

      using (Stream stream = File.OpenRead(fileName))
        return this.Deserialize(stream);
    }

    /// <summary>
    /// Serializes the specified <see cref="ColorCollection" /> and writes the palette to a file using the specified <see cref="Stream"/>.
    /// </summary>
    /// <param name="stream">The <see cref="Stream" /> used to write the palette.</param>
    /// <param name="palette">The <see cref="ColorCollection" /> to serialize.</param>
    public abstract void Serialize(Stream stream, ColorCollection palette);

    /// <summary>
    /// Serializes the specified <see cref="ColorCollection" /> and writes the palette to a file using the specified <see cref="Stream"/>.
    /// </summary>
    /// <param name="fileName">The name of the file where the palette will be written to.</param>
    /// <param name="palette">The <see cref="ColorCollection" /> to serialize.</param>
    public void Serialize(string fileName, ColorCollection palette)
    {
      using (Stream stream = File.Create(fileName))
        this.Serialize(stream, palette);
    }

    #endregion

    #region IPaletteSerializer Members

    /// <summary>
    /// Serializes the specified <see cref="ColorCollection" /> and writes the palette to a file using the specified Stream.
    /// </summary>
    /// <param name="stream">The <see cref="Stream" /> used to write the palette.</param>
    /// <param name="palette">The <see cref="ColorCollection" /> to serialize.</param>
    void IPaletteSerializer.Serialize(Stream stream, ColorCollection palette)
    {
      this.Serialize(stream, palette);
    }

    /// <summary>
    /// Deserializes the <see cref="ColorCollection" /> contained by the specified <see cref="Stream" />.
    /// </summary>
    /// <param name="stream">The <see cref="Stream" /> that contains the palette to deserialize.</param>
    /// <returns>The <see cref="ColorCollection" /> being deserialized..</returns>
    ColorCollection IPaletteSerializer.Deserialize(Stream stream)
    {
      return this.Deserialize(stream);
    }

    #endregion
  }
}
