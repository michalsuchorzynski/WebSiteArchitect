using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSiteArchitect.WebModel.Base
{
    public class WebPage
    {
        private List<IWebControl> _controls;

        public List<IWebControl> Controls
        {
            get
            {
                return _controls;
            }
            set
            {
                _controls = value;
            }
        }
        public WebPage()
        {
            Controls = new List<IWebControl>();
        }
    }
}
