using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Cyotek.Windows.Forms
{
  // Cyotek Color Picker controls library
  // Copyright © 2013 Cyotek. All Rights Reserved.
  // http://cyotek.com/blog/tag/colorpicker

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
    #region Constructors

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

    public ColorCollection(IEnumerable<int> collection)
      : this()
    {
      this.AddRange(collection.Select(Color.FromArgb));
    }

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

    public static ColorCollection LoadPalette(string fileName)
    {
      IPaletteSerializer serializer;

      serializer = PaletteSerializer.GetSerializer(fileName);
      if (serializer == null)
        throw new ArgumentException(string.Format("Cannot find a palette serializer for '{0}'", fileName), "fileName");

      using (FileStream file = File.OpenRead(fileName))
        return serializer.Deserialize(file);
    }

    #endregion

    #region Overridden Members

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

    #region Members

    /// <summary>Adds the elements of the specified collection to the end of the <see cref="ColorCollection"/>.</summary>
    /// <param name="colors">The collection whose elements should be added to the end of the <see cref="ColorCollection"/>.</param>
    public void AddRange(IEnumerable<Color> colors)
    {
      foreach (Color color in colors)
        this.Add(color);
    }

    public virtual ColorCollection Clone()
    {
      return new ColorCollection(this);
    }

    public void Load(string fileName)
    {
      ColorCollection palette;

      palette = LoadPalette(fileName);

      this.Clear();
      this.AddRange(palette);
    }

    public void Save(string fileName)
    {
      IPaletteSerializer serializer;

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

    /// <summary>
    /// Raises the <see cref="CollectionChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnCollectionChanged(ColorCollectionEventArgs e)
    {
      EventHandler<ColorCollectionEventArgs> handler;

      handler = this.CollectionChanged;

      if (handler != null)
        handler(this, e);
    }

    #endregion

    #region ICloneable Members

    object ICloneable.Clone()
    {
      return this.Clone();
    }

    #endregion
  }
}
