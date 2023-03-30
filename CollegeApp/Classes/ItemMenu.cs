using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CollegeApp.Classes
{
    public class ItemMenu
    {
        public ItemMenu(string header, List<SubItem> subItems, PackIconKind icon,int type)
        {
            Header = header;
            SubItems = subItems;
            Icon = icon;
            Type = type;
        }

        public ItemMenu(string header, UserControl screen, PackIconKind icon,int type)
        {
            Header = header;
            Screen = screen;
            Icon = icon;
            Type = type;
        }

        public string Header { get; private set; }
        public PackIconKind Icon { get; private set; }
        public List<SubItem> SubItems { get; private set; }
        public UserControl Screen { get; private set; }

        public int Type { get; set; }
    }
}
