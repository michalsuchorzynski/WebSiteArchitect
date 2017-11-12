using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSiteArchitect.WebModel.Base
{
    public class WebSite
    {
        private List<WebPage> _pages;
        private WebMenu _menu;

        public List<WebPage> Pages
        {
            get
            {
                return _pages;
            }
            set
            {
                _pages = value;
            }
        }
        public WebMenu Menu
        {
            get
            {
                return _menu;
            }
            set
            {
                _menu = value;
            }
        }

        public WebSite()
        {

        }
    }

}
