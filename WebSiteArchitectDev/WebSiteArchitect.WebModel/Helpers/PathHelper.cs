using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WebSiteArchitect.WebModel.Helpers
{
    public class PathHelper
    {
        public string Root { get; set; }
        public string Folder { get; set;}
        public string Item { get; set; }
        public string Path { get; set; }
        public int Type { get; set; }

        public PathHelper(TreeViewItem item)
        {
            if(item.Parent != null && item.Parent is TreeViewItem && (item.Parent as TreeViewItem).Parent != null && (item.Parent as TreeViewItem).Parent is TreeViewItem)
            {
                Root = ((item.Parent as TreeViewItem).Parent as TreeViewItem).Header.ToString();
                Folder = (item.Parent as TreeViewItem).Header.ToString();
                Item = (item as TreeViewItem).Header.ToString();
                Type = 0;
            } 
            else if (item.Parent != null && item.Parent is TreeViewItem)
            {
                Item = string.Empty;
                Root = (item.Parent as TreeViewItem).Header.ToString();
                Folder = (item as TreeViewItem).Header.ToString();
                Type = 1;
            }
            else
            {
                Item = string.Empty;
                Folder = string.Empty;
                Root = (item as TreeViewItem).Header.ToString();
                Type = 2;
            }
            Path = Root + "/" + Folder + "/" + Item;
            if (Path.EndsWith("//"))
            {
                Path = Path.Substring(0, Path.Length - 2);
            }
            else if (Path.EndsWith("/"))
            {
                Path = Path.Substring(0, Path.Length - 1);

            }
        }
        
    }
}
