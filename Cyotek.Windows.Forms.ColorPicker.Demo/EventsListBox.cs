using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms.ColorPicker.Demo
{
  // Cyotek Color Picker controls library
  // Copyright © 2013-2014 Cyotek.
  // http://cyotek.com/blog/tag/colorpicker

  // Licensed under the MIT License. See colorpicker-license.txt for the full text.

  // If you use this code in your applications, donations or attribution are welcome

  internal class EventsListBox : ListBox
  {
    #region Public Members

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
            eventData.Append(", ");
        }
      }
      eventData.Append(")");

      this.Items.Add(eventData.ToString());
      this.TopIndex = this.Items.Count - (this.ClientSize.Height / this.ItemHeight);
    }

    #endregion
  }
}
