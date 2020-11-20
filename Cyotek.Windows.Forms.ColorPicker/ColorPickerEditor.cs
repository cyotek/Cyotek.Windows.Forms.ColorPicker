using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace bhwidgets
{
    class ColorPickerEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            // Attempts to obtain an IWindowsFormsEditorService.
            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (edSvc == null)
            {
                return null;
            }

            Cyotek.Windows.Forms.ScreenColorPicker scp = new Cyotek.Windows.Forms.ScreenColorPicker(edSvc);
            scp.Size = new System.Drawing.Size(100, 100);
            scp.Dock = System.Windows.Forms.DockStyle.Fill;
            edSvc.DropDownControl(scp);

            // If OK was not pressed, return the original value
            return scp.Color;
        }
    }
}
