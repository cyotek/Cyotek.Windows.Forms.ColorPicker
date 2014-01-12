using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Cyotek.Windows.Forms
{
  // Cyotek Color Picker controls library
  // Copyright © 2013-2014 Cyotek.
  // http://cyotek.com/blog/tag/colorpicker

  // Licensed under the MIT License. See colorpicker-license.txt for the full text.

  // If you use this code in your applications, donations or attribution are welcome

  /// <summary>
  /// Serializes and deserializes color palettes into and from other documents.
  /// </summary>
  public abstract class PaletteSerializer : IPaletteSerializer
  {
    #region Constants

    private static string _defaultOpenFilter;

    private static string _defaultSaveFileter;

    private static readonly List<IPaletteSerializer> _serializerCache;

    #endregion

    #region Static Constructors

    static PaletteSerializer()
    {
      _serializerCache = new List<IPaletteSerializer>();
    }

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

    #endregion

    #region Class Members

    public static IPaletteSerializer GetSerializer(string fileName)
    {
      IPaletteSerializer result;
      string fileExtension;

      if (string.IsNullOrEmpty(fileName))
        throw new ArgumentNullException("fileName");

      if (_serializerCache.Count == 0)
        LoadSerializers();

      fileExtension = Path.GetExtension(fileName);
      if (fileExtension.Length != 0 && fileExtension[0] == '.')
        fileExtension = fileExtension.Remove(0, 1);
      result = _serializerCache.FirstOrDefault(s => !string.IsNullOrEmpty(s.DefaultExtension) && s.DefaultExtension.Split(new[]
      {
        ';'
      }, StringSplitOptions.RemoveEmptyEntries).Contains(fileExtension, StringComparer.InvariantCultureIgnoreCase));

      return result;
    }

    private static void CreateFilters()
    {
      StringBuilder openFilter;
      StringBuilder saveFilter;
      List<string> openExtensions;

      openExtensions = new List<string>();
      openFilter = new StringBuilder();
      saveFilter = new StringBuilder();

      if (_serializerCache.Count == 0)
        LoadSerializers();

      foreach (IPaletteSerializer serializer in _serializerCache.Where(serializer => !(string.IsNullOrEmpty(serializer.DefaultExtension) || openExtensions.Contains(serializer.DefaultExtension))).OrderBy(serializer => serializer.Name))
      {
        StringBuilder extensionMask;
        string filter;

        extensionMask = new StringBuilder();

        foreach (string extension in serializer.DefaultExtension.Split(new[]
        {
          ';'
        }, StringSplitOptions.RemoveEmptyEntries))
        {
          string mask;

          mask = "*." + extension;

          if (!openExtensions.Contains(mask))
            openExtensions.Add(mask);

          if (extensionMask.Length != 0)
            extensionMask.Append(";");
          extensionMask.Append(mask);
        }

        filter = string.Format("{0} Files ({1})|{1}", serializer.Name, extensionMask);

        if (serializer.CanRead)
        {
          if (openFilter.Length != 0)
            openFilter.Append("|");
          openFilter.Append(filter);
        }

        if (serializer.CanWrite)
        {
          if (saveFilter.Length != 0)
            saveFilter.Append("|");
          saveFilter.Append(filter);
        }
      }

      if (openExtensions.Count != 0)
        openFilter.Insert(0, string.Format("All Supported Palettes ({0})|{0}|", string.Join(";", openExtensions.ToArray())));
      if (openFilter.Length != 0)
        openFilter.Append("|");
      openFilter.Append("All Files (*.*)|*.*");

      _defaultOpenFilter = openFilter.ToString();
      _defaultSaveFileter = saveFilter.ToString();
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
      _serializerCache.Clear();
      _defaultOpenFilter = null;
      _defaultSaveFileter = null;

      foreach (Type type in AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => GetLoadableTypes(assembly).Where(type => !type.IsAbstract && type.IsPublic && typeof(IPaletteSerializer).IsAssignableFrom(type))))
      {
        try
        {
          _serializerCache.Add((IPaletteSerializer)Activator.CreateInstance(type));
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

    #region Public Properties

    /// <summary>
    /// Gets a value indicating whether this serializer can be used to read palettes.
    /// </summary>
    /// <value><c>true</c> if palettes can be read using this serializer; otherwise, <c>false</c>.</value>
    [Browsable(false)]
    public virtual bool CanRead
    {
      get { return true; }
    }

    /// <summary>
    /// Gets a value indicating whether this serializer can be used to write palettes.
    /// </summary>
    /// <value><c>true</c> if palettes can be written using this serializer; otherwise, <c>false</c>.</value>
    [Browsable(false)]
    public virtual bool CanWrite
    {
      get { return true; }
    }

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

    #region Public Members

    /// <summary>
    /// Deserializes the <see cref="ColorCollection" /> contained by the specified <see cref="Stream" />.
    /// </summary>
    /// <param name="stream">The <see cref="Stream" /> that contains the palette to deserialize.</param>
    /// <returns>The <see cref="ColorCollection" /> being deserialized.</returns>
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
    /// <returns>The <see cref="ColorCollection" /> being deserialized.</returns>
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

    bool IPaletteSerializer.CanRead
    {
      get { return this.CanRead; }
    }

    bool IPaletteSerializer.CanWrite
    {
      get { return this.CanWrite; }
    }

    #endregion
  }
}
