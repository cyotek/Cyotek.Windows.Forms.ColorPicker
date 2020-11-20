using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Design;

namespace bhwidgets
{
    public partial class ScreenColorPickerDemoWidget : UserControl
    {
        Color thecolor;
        [EditorAttribute(typeof(ColorPickerEditor), typeof(UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible | DesignerSerializationVisibility.Content)]
        public Color TranspColor
        {
            get { return thecolor; }
            set { thecolor = value; }
        }

        public ScreenColorPickerDemoWidget()
        {
            InitializeComponent();
        }
    }
}
