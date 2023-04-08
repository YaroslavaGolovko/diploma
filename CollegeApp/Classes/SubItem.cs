using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CollegeApp.Classes
{
    public class SubItem
    {
        public SubItem(string name, UserControl screen = null,int type=0)
        {
            Name = name;
            Screen = screen;
            Type = type;
        }
        public SubItem(string name, int type)
        {
            Name = name;
            Type = type;
        }
        public string Name { get; private set; }
        public UserControl Screen { get; private set; }
        public int Type { get; set; }
    }
}
