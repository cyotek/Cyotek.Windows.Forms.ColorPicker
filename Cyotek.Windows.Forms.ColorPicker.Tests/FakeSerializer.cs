using System;
using System.IO;

namespace Cyotek.Windows.Forms.ColorPicker.Tests
{
  internal class FakeSerializer : PaletteSerializer
  {
    #region Overridden Properties

    public override string DefaultExtension
    {
      get { throw new NotImplementedException(); }
    }

    public override string Name
    {
      get { throw new NotImplementedException(); }
    }

    #endregion

    #region Overridden Methods

    public override bool CanReadFrom(Stream stream)
    {
      throw new NotImplementedException();
    }

    public override ColorCollection Deserialize(Stream stream)
    {
      throw new NotImplementedException();
    }

    public override void Serialize(Stream stream, ColorCollection palette)
    {
      throw new NotImplementedException();
    }

    #endregion

    #region Public Members

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
