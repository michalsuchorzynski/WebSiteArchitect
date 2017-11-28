using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Windows.Markup;
using System.Windows.Controls;
using System.Xml;
using WebSiteArchitect.WebModel.Base;

namespace WebSiteArchitect.WebModel
{
    public static class Settings
    {
        public static string ConvertToJson(WebContent page)
        {
            var resultJson = JsonConvert.SerializeObject(page, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            return resultJson;
        }
        public static WebContent ConvertFromJson(string json)
        {
            return JsonConvert.DeserializeObject<WebContent>(json, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
        }
        public static string XamlToSring(StackPanel xaml)
        {            
            return XamlWriter.Save(xaml);
        }
        public static StackPanel StringToXaml(string xaml)
        {
            StringReader stringReader = new StringReader(xaml);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            return (StackPanel)XamlReader.Load(xmlReader);
        }
        public static string GetCustomDescription(object objEnum)
        {
            var fi = objEnum.GetType().GetField(objEnum.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : objEnum.ToString();
        }
        public static string Description(this Enum value)
        {
            return GetCustomDescription(value);
        }

    }
}
