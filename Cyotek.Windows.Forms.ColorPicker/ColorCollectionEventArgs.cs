using System;
using System.Drawing;

namespace Cyotek.Windows.Forms
{
  // Cyotek Color Picker controls library
  // Copyright © 2013 Cyotek. All Rights Reserved.
  // http://cyotek.com/blog/tag/colorpicker

  // If you use this code in your applications, donations or attribution is welcome

  /// <summary>Provides data for the <see cref="ColorCollection.CollectionChanged"/> event of a <see cref="ColorCollection"/> instance.</summary>
  public class ColorCollectionEventArgs : EventArgs
  {
    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="ColorCollectionEventArgs"/> class for the specified color.
    /// </summary>
    /// <param name="index">The color index that the event is responding to.</param>
    /// <param name="color">The %Color% that the event is responding to.</param>
    public ColorCollectionEventArgs(int index, Color color)
    {
      this.Index = index;
      this.Color = color;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ColorCollectionEventArgs"/> class.
    /// </summary>
    protected ColorCollectionEventArgs()
    { }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the color that raised the event.
    /// </summary>
    /// <value>The color that raised the event.</value>
    public Color Color { get; protected set; }

    /// <summary>
    /// Gets the color index that raised the event.
    /// </summary>
    /// <value>The color index that raised the event.</value>
    public int Index { get; protected set; }

    #endregion
  }
}
