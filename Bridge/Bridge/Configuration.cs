using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Windows.Forms;
using System.CodeDom.Compiler;
using System.IO;

namespace Bridge
{
    //public class SetConfig
    //{
    //    public List<ConfigItem> list { get; set; }
    //    public List<List<object>> set { get; set; }

    //    public string GetVal(int i, ConfigItem item)
    //    {
    //        string result = "";
    //        for (int j = 0; j < list.Count; j++)
    //        {
    //            if (list[j].Name == item.Name)
    //            {
    //                result = set[i][j].ToString();
    //                break;
    //            }
    //        }
    //        return result;
    //    }
    //}

    public class Configuration
    {
        protected List<ConfigItem> items;
        public string Name { get; set; }
        public string Comment { get; set; }

        public static string XMLConfiguration = "XML";

        public Configuration()
        {
            items = new List<ConfigItem>();
            Name = "";
        }

        public List<ConfigItem> GetItems()
        {
            return items;
        }

        public void Add(XElement element)
        {
            ConfigItem item = new ConfigItem();
            item.XMLElement = element;
            item.config = this;
            items.Add(item);
        }

        public void Add(ConfigItem item)
        {
            bool f = false;
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Name == item.Name)
                {
                    f = true;
                }
            }
            if (f == false)
            {
                item.config = this;
                items.Add(item);
            }
        }

  
    }
}
