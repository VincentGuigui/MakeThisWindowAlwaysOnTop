using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeThisWindowAlwaysOnTop
{
    public class Windows : BindingSource
    {
        List<Window> items = new List<Window>();
        public Windows():base()
        {
            this.DataSource = items;
        }
    }

    public class Window
    {
        [NotifyParentProperty(true)]
        public IntPtr Handle { get; set; }
        [NotifyParentProperty(true)]
        public String Title { get; set; }
        [NotifyParentProperty(true)]
        public Boolean TopMost { get; set; }

        public override string ToString()
        {
            return Title + (TopMost ? " ▲" : "");
        }
    }

}
