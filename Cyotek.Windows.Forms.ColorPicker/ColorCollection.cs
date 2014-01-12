using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Cyotek.Windows.Forms
{
  // Cyotek Color Picker controls library
  // Copyright © 2013-2014 Cyotek.
  // http://cyotek.com/blog/tag/colorpicker

  // Licensed under the MIT License. See colorpicker-license.txt for the full text.

  // If you use this code in your applications, donations or attribution are welcome

  /// <summary>
  /// Represents a collection of colors
  /// </summary>
  /// <remarks>
  /// 	<para>ColorCollection allows duplicate elements.</para>
  /// 	<para>Elements in this collection can be accessed using an integer index. Indexes in this collection are zero-based.</para>
  /// </remarks>
  public class ColorCollection : Collection<Color>, ICloneable
  {
    #region Instance Fields

    private readonly object _lock = new object();

    private IDictionary<Color, int> _indexedLookup;

    #endregion

    #region Public Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="ColorCollection"/> class.
    /// </summary>
    public ColorCollection()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ColorCollection"/> class that contains elements copied from the specified collection.
    /// </summary>
    /// <param name="collection">The collection whose elements are copied to the new collection.</param>
    public ColorCollection(IEnumerable<Color> collection)
      : this()
    {
      this.AddRange(collection);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ColorCollection"/> class that contains elements copied from the specified collection.
    /// </summary>
    /// <param name="collection">The collection whose elements are copied to the new collection.</param>
    public ColorCollection(IEnumerable<int> collection)
      : this()
    {
      this.AddRange(collection.Select(Color.FromArgb));
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ColorCollection"/> class that contains elements copied from the specified collection.
    /// </summary>
    /// <param name="collection">The collection whose elements are copied to the new collection.</param>
    public ColorCollection(System.Drawing.Imaging.ColorPalette collection)
      : this()
    {
      this.AddRange(collection.Entries);
    }

    #endregion

    #region Events

    /// <summary>
    /// Occurs when elements in the collection are added, removed or modified.
    /// </summary>
    public event EventHandler<ColorCollectionEventArgs> CollectionChanged;

    #endregion

    #region Class Members

    /// <summary>
    /// Creates a new instance of the <see cref="ColorCollection" /> class that contains elements loaded from the specified file.
    /// </summary>
    /// <param name="fileName">Name of the file to load.</param>
    /// <exception cref="System.ArgumentNullException">Thrown if the <c>fileName</c> argument is not specified.</exception>
    /// <exception cref="System.IO.FileNotFoundException">Thrown if the file specified by <c>fileName</c> cannot be found.</exception>
    /// <exception cref="System.ArgumentException">Thrown if no <see cref="IPaletteSerializer"/> is available for the file specified by <c>fileName</c>.</exception>
    public static ColorCollection LoadPalette(string fileName)
    {
      IPaletteSerializer serializer;

      if (string.IsNullOrEmpty(fileName))
        throw new ArgumentNullException("fileName");

      if (!File.Exists(fileName))
        throw new FileNotFoundException(string.Format("Cannot find file '{0}'", fileName), fileName);

      serializer = PaletteSerializer.GetSerializer(fileName);
      if (serializer == null)
        throw new ArgumentException(string.Format("Cannot find a palette serializer for '{0}'", fileName), "fileName");

      using (FileStream file = File.OpenRead(fileName))
        return serializer.Deserialize(file);
    }

    #endregion

    #region Overridden Methods

    /// <summary>
    /// Removes all elements from the <see cref="T:System.Collections.ObjectModel.Collection`1" />.
    /// </summary>
    protected override void ClearItems()
    {
      base.ClearItems();

      this.OnCollectionChanged(new ColorCollectionEventArgs(-1, Color.Empty));
    }

    /// <summary>
    /// Inserts an element into the <see cref="T:System.Collections.ObjectModel.Collection`1" /> at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index at which <paramref name="item" /> should be inserted.</param>
    /// <param name="item">The object to insert.</param>
    protected override void InsertItem(int index, Color item)
    {
      base.InsertItem(index, item);

      this.OnCollectionChanged(new ColorCollectionEventArgs(index, item));
    }

    /// <summary>
    /// Removes the element at the specified index of the <see cref="T:System.Collections.ObjectModel.Collection`1" />.
    /// </summary>
    /// <param name="index">The zero-based index of the element to remove.</param>
    protected override void RemoveItem(int index)
    {
      Color color;

      color = this[index];

      base.RemoveItem(index);

      this.OnCollectionChanged(new ColorCollectionEventArgs(index, color));
    }

    /// <summary>
    /// Replaces the element at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index of the element to replace.</param>
    /// <param name="item">The new value for the element at the specified index.</param>
    protected override void SetItem(int index, Color item)
    {
      base.SetItem(index, item);

      this.OnCollectionChanged(new ColorCollectionEventArgs(index, item));
    }

    #endregion

    #region Public Members

    /// <summary>Adds the elements of the specified collection to the end of the <see cref="ColorCollection"/>.</summary>
    /// <param name="colors">The collection whose elements should be added to the end of the <see cref="ColorCollection"/>.</param>
    public void AddRange(IEnumerable<Color> colors)
    {
      foreach (Color color in colors)
        this.Add(color);
    }

    /// <summary>
    /// Creates a new object that is a copy of the current instance.
    /// </summary>
    /// <returns>A new object that is a copy of this instance.</returns>
    public virtual ColorCollection Clone()
    {
      return new ColorCollection(this);
    }

    /// <summary>
    /// Searches for the specified object and returns the zero-based index of the first occurrence within the entire <see cref="ColorCollection"/>.
    /// </summary>
    /// <param name="item">The <see cref="Color"/> to locate in the <see cref="ColorCollection"/>.</param>
    /// <returns>The zero-based index of the first occurrence of <c>item</c> within the entire <see cref="ColorCollection"/>, if found; otherwise, –1.</returns>
    public int Find(Color item)
    {
      int result;

      if (_indexedLookup == null)
        this.BuildIndexedLookup();

      if (!_indexedLookup.TryGetValue(item, out result))
        result = -1;

      return result;
    }

    /// <summary>
    /// Searches for the specified object and returns the zero-based index of the first occurrence within the entire <see cref="ColorCollection" />.
    /// </summary>
    /// <param name="item">The <see cref="Color"/> to locate in the <see cref="ColorCollection" />.</param>
    /// <param name="ignoreAlphaChannel">If set to <c>true</c> only the red, green and blue channels of items in the <see cref="ColorCollection"/> will be compared.</param>
    /// <returns>The zero-based index of the first occurrence of <c>item</c> within the entire <see cref="ColorCollection" />, if found; otherwise, –1.</returns>
    public int Find(Color item, bool ignoreAlphaChannel)
    {
      int result;

      if (!ignoreAlphaChannel)
        result = this.Find(item);
      else
      {
        // TODO: This is much much slower than the lookup based fine

        result = -1;

        for (int i = 0; i < this.Count; i++)
        {
          Color original;

          original = this[i];
          if (original.R == item.R && original.G == item.G && original.B == item.B)
          {
            result = i;
            break;
          }
        }
      }

      return result;
    }

    /// <summary>
    /// Searches for the specified object and returns the zero-based index of the first occurrence within the entire <see cref="ColorCollection"/>.
    /// </summary>
    /// <param name="item">The ARGB color to locate in the <see cref="ColorCollection"/>.</param>
    /// <returns>The zero-based index of the first occurrence of <c>item</c> within the entire <see cref="ColorCollection"/>, if found; otherwise, –1.</returns>
    public int Find(int item)
    {
      return this.Find(Color.FromArgb(item));
    }

    /// <summary>
    /// Populates this <see cref="ColorCollection"/> with items loaded from the specified file.
    /// </summary>
    /// <param name="fileName">Name of the file to load.</param>
    /// <exception cref="System.ArgumentNullException">Thrown if the <c>fileName</c> argument is not specified.</exception>
    /// <exception cref="System.IO.FileNotFoundException">Thrown if the file specified by <c>fileName</c> cannot be found.</exception>
    /// <exception cref="System.ArgumentException">Thrown if no <see cref="IPaletteSerializer"/> is available for the file specified by <c>fileName</c>.</exception>
    public void Load(string fileName)
    {
      ColorCollection palette;

      palette = LoadPalette(fileName);

      this.Clear();
      this.AddRange(palette);
    }

    /// <summary>
    /// Saves the contents of this <see cref="ColorCollection"/> into the specified file.
    /// </summary>
    /// <param name="fileName">Name of the file to save.</param>
    /// <exception cref="System.ArgumentNullException">Thrown if the <c>fileName</c> argument is not specified.</exception>
    /// <exception cref="System.ArgumentException">Thrown if no <see cref="IPaletteSerializer"/> is available for the file specified by <c>fileName</c>.</exception>
    public void Save(string fileName)
    {
      IPaletteSerializer serializer;

      if (string.IsNullOrEmpty(fileName))
        throw new ArgumentNullException("fileName");

      serializer = PaletteSerializer.GetSerializer(fileName);
      if (serializer == null)
        throw new ArgumentException(string.Format("Cannot find a palette serializer for '{0}'", fileName), "fileName");

      using (FileStream file = File.OpenWrite(fileName))
        serializer.Serialize(file, this);
    }

    /// <summary>
    /// Sorts the elements in the entire %ColorCollection% using the specified order.
    /// </summary>
    /// <param name="sortOrder">The sort order.</param>
    /// <exception cref="System.ArgumentException">Thrown when an invalid sort order is specified</exception>
    public void Sort(ColorCollectionSortOrder sortOrder)
    {
      Comparison<Color> sortDelegate;
      List<Color> orderedItems;

      // HACK: This is a bit nasty

      switch (sortOrder)
      {
        case ColorCollectionSortOrder.Brightness:
          sortDelegate = ColorComparer.Brightness;
          break;
        case ColorCollectionSortOrder.Hue:
          sortDelegate = ColorComparer.Hue;
          break;
        case ColorCollectionSortOrder.Value:
          sortDelegate = ColorComparer.Value;
          break;
        default:
          throw new ArgumentException("Invalid sort order", "sortOrder");
      }

      orderedItems = new List<Color>(this);
      orderedItems.Sort(sortDelegate);
      this.ClearItems();
      this.AddRange(orderedItems);
    }

    #endregion

    #region Protected Members

    /// <summary>
    /// Raises the <see cref="CollectionChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnCollectionChanged(ColorCollectionEventArgs e)
    {
      EventHandler<ColorCollectionEventArgs> handler;

      _indexedLookup = null; // reset the internal lookup

      handler = this.CollectionChanged;

      if (handler != null)
        handler(this, e);
    }

    #endregion

    #region Private Members

    /// <summary>
    /// Builds an indexed lookup for quick searching.
    /// </summary>
    private void BuildIndexedLookup()
    {
      lock (_lock)
      {
        _indexedLookup = new Dictionary<Color, int>();

        for (int i = 0; i < this.Count; i++)
        {
          Color color;

          color = this[i];

          if (!_indexedLookup.ContainsKey(color))
            _indexedLookup.Add(color, i);
        }
      }
    }

    #endregion

    #region ICloneable Members

    /// <summary>
    /// Creates a new object that is a copy of the current instance.
    /// </summary>
    /// <returns>A new object that is a copy of this instance.</returns>
    object ICloneable.Clone()
    {
      return this.Clone();
    }

    #endregion
  }
}
