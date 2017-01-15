using System;
using System.IO;

// Cyotek Color Picker controls library
// Copyright © 2013-2015 Cyotek Ltd.
// http://cyotek.com/blog/tag/colorpicker

// Licensed under the MIT License. See license.txt for the full text.

// If you use this code in your applications, donations or attribution are welcome

namespace Cyotek.Windows.Forms.ColorPicker.Tests
{
  internal class FakeSerializer : PaletteSerializer
  {
    #region Properties

    public override string DefaultExtension
    {
      get { throw new NotImplementedException(); }
    }

    public override string Name
    {
      get { throw new NotImplementedException(); }
    }

    #endregion

    #region Methods

    public override bool CanReadFrom(Stream stream)
    {
      throw new NotImplementedException();
    }

    public override ColorCollection Deserialize(Stream stream)
    {
      throw new NotImplementedException();
    }

    public new int ReadInt16(Stream stream)
    {
      return base.ReadInt16(stream);
    }

    public new int ReadInt32(Stream stream)
    {
      return base.ReadInt32(stream);
    }

    public new string ReadString(Stream stream, int length)
    {
      return base.ReadString(stream, length);
    }

    public override void Serialize(Stream stream, ColorCollection palette)
    {
      throw new NotImplementedException();
    }

    public new void WriteInt16(Stream stream, short value)
    {
      base.WriteInt16(stream, value);
    }

    public new void WriteInt32(Stream stream, int value)
    {
      base.WriteInt32(stream, value);
    }

    #endregion
  }
}
