using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WebSiteArchitect.WebModel.Base;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Windows.Markup;
using System.Windows.Controls;
using System.Xml;

namespace WebSiteArchitect.WebModel
{
    public static class Settings
    {
        public static string ConvertToJson(WebPage page, string destination)
        {
            var resultJson = JsonConvert.SerializeObject(page,new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            WriteJsonToFile(destination, resultJson);
            return resultJson;
        }
        public static WebPage ConvertFromJson(string input)
        {
            string json = ReadJsonFromFile(input);
            return JsonConvert.DeserializeObject<WebPage>(json, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto }); 
        } 
        public static void WriteJsonToFile(string destination, string json)
        {
            FileInfo fi = new FileInfo(destination);
            if (!fi.Exists)
            {
                fi.CreateText();
            }
            StreamWriter sw = new StreamWriter(fi.FullName);
            sw.WriteLine(json);
            sw.Close();
        }
        public static string ReadJsonFromFile(string source)
        {
            FileInfo fi = new FileInfo(source);
            if (!fi.Exists)
            {
                return null;
            }
            StreamReader sr = new StreamReader(source);
            return sr.ReadToEnd();
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
