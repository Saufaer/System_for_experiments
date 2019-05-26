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

    public class TaskConf
    {
        protected List<Item> items;
        public string Name { get; set; }
        public string Comment { get; set; }

        public static string XMLConfiguration = "XML";

        public TaskConf()
        {
            items = new List<Item>();
            Name = "";
        }

        public List<Item> GetItems()
        {
            return items;
        }

        public void Add(XElement element)
        {
            Item item = new Item();
            item.XMLElement = element;
            item.config = this;
            items.Add(item);
        }

        public void Add(Item item)
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
