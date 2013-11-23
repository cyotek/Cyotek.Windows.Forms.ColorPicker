using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Cyotek.Windows.Forms
{
  /// <summary>
  /// Serializes and deserializes color palettes into and from other documents.
  /// </summary>
  public abstract class PaletteSerializer : IPaletteSerializer
  {
    #region Constants

    private static string _defaultOpenFilter;

    private static string _defaultSaveFileter;

    #endregion

    #region Class Properties

    public static string DefaultOpenFilter
    {
      get
      {
        if (string.IsNullOrEmpty(_defaultOpenFilter))
          CreateFilters();

        return _defaultOpenFilter;
      }
    }

    public static string DefaultSaveFilter
    {
      get
      {
        if (string.IsNullOrEmpty(_defaultSaveFileter))
          CreateFilters();

        return _defaultSaveFileter;
      }
    }

    private static List<IPaletteSerializer> SerializerCache { get; set; }

    #endregion

    #region Class Members

    public static IPaletteSerializer GetSerializer(string fileName)
    {
      IPaletteSerializer result;
      string fileExtension;

      if (string.IsNullOrEmpty(fileName))
        throw new ArgumentNullException("fileName");

      if (SerializerCache == null)
        LoadSerializers();

      fileExtension = Path.GetExtension(fileName);
      result = null;

      // ReSharper disable AssignNullToNotNullAttribute
      foreach (IPaletteSerializer serializer in SerializerCache.Where(serializer => !(string.IsNullOrEmpty(serializer.DefaultExtension))))
        // ReSharper restore AssignNullToNotNullAttribute
      {
        string extension;

        extension = serializer.DefaultExtension;
        if (extension[0] != '.')
          extension = extension.Insert(0, ".");

        if (string.Equals(fileExtension, extension, StringComparison.InvariantCultureIgnoreCase))
        {
          result = serializer;
          break;
        }
      }

      return result;
    }

    private static void CreateFilters()
    {
      StringBuilder sb;
      List<string> extensions;

      sb = new StringBuilder();
      extensions = new List<string>();

      if (SerializerCache == null)
        LoadSerializers();

      // ReSharper disable AssignNullToNotNullAttribute
      foreach (IPaletteSerializer serializer in SerializerCache.Where(serializer => !(string.IsNullOrEmpty(serializer.DefaultExtension) || extensions.Contains(serializer.DefaultExtension))).OrderBy(serializer => serializer.Name))
        // ReSharper restore AssignNullToNotNullAttribute
      {
        string extension;

        extension = serializer.DefaultExtension;
        if (extension[0] != '.')
          extension = extension.Insert(0, ".");
        extension = extension.Insert(0, "*");

        extensions.Add(extension);

        if (sb.Length != 0)
          sb.Append("|");
        sb.AppendFormat("{0} Files ({1})|{1}", serializer.Name, extension);
      }

      _defaultOpenFilter = string.Format("All Supported Palettes ({0})|{0}|{1}|All Files (*.*)|*.*", string.Join(";", extensions.ToArray()), sb);
      _defaultSaveFileter = sb.ToString();
    }

    private static IEnumerable<Type> GetLoadableTypes(Assembly assembly)
    {
      try
      {
        return assembly.GetTypes();
      }
      catch (ReflectionTypeLoadException ex)
      {
        return ex.Types.Where(x => x != null);
      }
    }

    private static void LoadSerializers()
    {
      if (SerializerCache == null)
        SerializerCache = new List<IPaletteSerializer>();
      else
        SerializerCache.Clear();

      foreach (Type type in AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => GetLoadableTypes(assembly).Where(type => !type.IsAbstract && type.IsPublic && typeof(IPaletteSerializer).IsAssignableFrom(type))))
      {
        try
        {
          SerializerCache.Add((IPaletteSerializer)Activator.CreateInstance(type));
        }
          // ReSharper disable EmptyGeneralCatchClause
        catch
          // ReSharper restore EmptyGeneralCatchClause
        {
          // ignore errors
        }
      }
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the default extension for files generated with this palette format.
    /// </summary>
    /// <value>The default extension for files generated with this palette format.</value>
    [Browsable(false)]
    public abstract string DefaultExtension { get; }

    /// <summary>
    /// Gets a descriptive name of the palette format
    /// </summary>
    /// <value>The descriptive name of the palette format.</value>
    [Browsable(false)]
    public abstract string Name { get; }

    #endregion

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

    /// <summary>
    /// Gets a descriptive name of the palette format
    /// </summary>
    /// <value>The descriptive name of the palette format.</value>
    string IPaletteSerializer.Name
    {
      get { return this.Name; }
    }

    /// <summary>
    /// Gets the default extension for files generated with this palette format.
    /// </summary>
    /// <value>The default extension for files generated with this palette format.</value>
    string IPaletteSerializer.DefaultExtension
    {
      get { return this.DefaultExtension; }
    }

    #endregion
  }
}
