using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSiteArchitect.WebModel.Helpers
{
    public class UpdatePageRequest
    {
        private int _id;
        private string _xamlSchema;
        private string _controls;
                        
        public string Controls
        {
            get { return _controls; }
            set { _controls = value; }
        }

        public string XamlSchema
        {
            get { return _xamlSchema; }
            set { _xamlSchema = value; }
        }


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

    }
}
