using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSiteArchitect.WebModel.Enums;

namespace WebSiteArchitect.WebModel.Base
{
    public class WebControl : IWebControl
    {
        private string _id;
        private string _name;
        private WebControlTypeEnum _type;
        private string _value;
        private string _className;
        private List<WebControl> _childrenControls;

#region Property
        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public WebControlTypeEnum Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }
        public string ClassName
        {
            get
            {
                return _className;
            }
            set
            {
                _className = value;
            }
        }
        public List<WebControl> ChildrenControls
        {
            get
            {
                return _childrenControls;
            }
            set
            {
                if(_childrenControls == null)
                {
                    _childrenControls = new List<WebControl>();
                    _childrenControls = value;
                    return;
                }
                _childrenControls = value;
            }
        }
        #endregion
        public WebControl()
        {

        }
        public WebControl(string id, string name, WebControlTypeEnum type, string value, string className)
        {
            this.Id = id;
            this.Name = name;
            this.Type = type;
            this.Value = value;
            this.ClassName = className;
        }

        public WebControl(string id, string name, WebControlTypeEnum type, string value, string className, List<WebControl> childrenControls)
        {
            this.Id = id;
            this.Name = name;
            this.Type = type;
            this.Value = value;
            this.ClassName = className;
            this._childrenControls = childrenControls;
        }
        public WebControl(WebControlTypeEnum type)
        {
            this.Type = type;
        }

    }
}
