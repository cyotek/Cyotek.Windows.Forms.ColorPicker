// Cyotek Color Picker Controls Library
// http://cyotek.com/blog/tag/colorpicker

// Copyright (c) 2013-2021 Cyotek Ltd.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this code useful?
// https://www.cyotek.com/contribute

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms.Demo
{
  internal sealed class EventsListBox : ListBox
  {
    #region Public Constructors

    public EventsListBox()
    {
      base.IntegralHeight = false;
    }

    #endregion Public Constructors

    #region Public Properties

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new bool IntegralHeight
    {
      get => base.IntegralHeight;
      set => base.IntegralHeight = value;
    }

    #endregion Public Properties

    #region Public Methods

    public void AddEvent(Control sender, string eventName)
    {
      this.AddEvent(sender, eventName, null);
    }

    public void AddEvent(Control sender, string eventName, IDictionary<string, object> values)
    {
      StringBuilder eventData;

      eventData = new StringBuilder();

      eventData.Append(DateTime.Now.ToLongTimeString());
      eventData.Append("\t");
      eventData.Append(sender.Name);
      eventData.Append(".");
      eventData.Append(eventName);
      eventData.Append(" (");
      if (values != null)
      {
        for (int i = 0; i < values.Count; i++)
        {
          eventData.AppendFormat("{0} = {1}", values.Keys.ElementAt(i), values.Values.ElementAt(i));

          if (i < values.Count - 1)
          {
            eventData.Append(", ");
          }
        }
      }
      eventData.Append(")");

      this.Items.Add(eventData.ToString());
      this.TopIndex = this.Items.Count - this.ClientSize.Height / this.ItemHeight;
    }

    #endregion Public Methods
  }
}
