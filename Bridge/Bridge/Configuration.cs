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
    public class SetConfig
    {
        public List<ConfigItem> list { get; set; }
        public List<List<object>> set { get; set; }

        public string GetVal(int i, ConfigItem item)
        {
            string result = "";
            for (int j = 0; j < list.Count; j++)
            {
                if (list[j].Name == item.Name)
                {
                    result = set[i][j].ToString();
                    break;
                }
            }
            return result;
        }
    }

    public class Configuration
    {
        protected List<ConfigItem> items;
        public string Name { get; set; }
        public string Comment { get; set; }
       // public ConfigItem ItemName { get; set; }

      //  public static string ConsoleConfiguration = "con";
        public static string XMLConfiguration = "XML";

        public Configuration()
        {
            items = new List<ConfigItem>();
            Name = "";
        }

        //        public static List<ConfigItem> DetermineCalculationConnected(string value, List<ConfigItem> curItems)
        //        {
        //            string[] text = value.Split(new char[] { ' ' });

        //            List<ConfigItem> param = new List<ConfigItem>();

        //            for (int i = 0; i < text.Length; i++)
        //            {
        //                for (int j = 0; j < curItems.Count; j++)
        //                {
        //                    if (text[i] == curItems[j].Name)
        //                    {
        //                        bool f = false;
        //                        for (int k = 0; k < param.Count; k++)
        //                        {
        //                            if (param[k].Name == curItems[j].Name)
        //                            {
        //                                f = true;
        //                                break;
        //                            }
        //                        }

        //                        if (f == false)
        //                        {
        //                            param.Add(curItems[j]);
        //                        }
        //                        break;
        //                    }
        //                }
        //            }

        //            return param;
        //        }

        //        public static List<List<int>> DetermineConnected(List<ConfigItem> itemList)
        //        {
        //            //если i-ый связан с j-ым то i-ый не изменяетя, изменение j-ого равносильно ведет изменение i-ого
        //            // у j-ого в списке номера тех которые нужно изменить(связанные с ним)
        //            List<List<int>> result = new List<List<int>>(itemList.Count);
        //            for (int i = 0; i < itemList.Count; i++)
        //            {
        //                result.Add(new List<int>());
        //            }

        //            for (int i = 0; i < itemList.Count; i++)
        //            {
        //                if ((itemList[i].ConfigType == ConfigItemType.ConnectedArray) || (itemList[i].ConfigType == ConfigItemType.ConnectedValuesEnumeration))
        //                {
        //                    for (int j = 0; j < itemList.Count; j++)
        //                    {
        //                        if (itemList[i].Value == itemList[j].Name)
        //                        {
        //                            result[j].Add(i);
        //                            break;
        //                        }
        //                    }
        //                }
        //                else if (itemList[i].ConfigType == ConfigItemType.Calculation)
        //                {
        //                    List<ConfigItem> con = DetermineCalculationConnected(itemList[i].Value, itemList);
        //                    for (int q = 0; q < con.Count; q++)
        //                    {
        //                        for (int w = 0; w < itemList.Count; w++)
        //                        {
        //                            if (con[q].Name == itemList[w].Name)
        //                            {
        //                                result[w].Add(i);
        //                                break;
        //                            }
        //                        }
        //                    }
        //                }
        //                else if ((itemList[i].ConfigType == ConfigItemType.File) || (itemList[i].ConfigType == ConfigItemType.Folder))
        //                {
        //                    List<ConfigItem> con = new List<ConfigItem>();
        //                    if (itemList[i].Value == "all")
        //                    {
        //                        //param = all;
        //                        for (int v = 0; v < itemList.Count; v++)
        //                        {
        //                            if ((itemList[v].ConfigType != ConfigItemType.XML) &&
        //                                (itemList[v].ConfigType != ConfigItemType.File) &&
        //                                (itemList[v].ConfigType != ConfigItemType.Folder))
        //                            {
        //                                con.Add(itemList[v]);
        //                            }
        //                        }
        //                        for (int q = 0; q < con.Count; q++)
        //                        {
        //                            for (int w = 0; w < itemList.Count; w++)
        //                            {
        //                                if (con[q].Name == itemList[w].Name)
        //                                {
        //                                    result[w].Add(i);
        //                                    break;
        //                                }
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        con = Configuration.DetermineCalculationConnected(itemList[i].Value, itemList);
        //                        for (int q = 0; q < con.Count; q++)
        //                        {
        //                            for (int w = 0; w < itemList.Count; w++)
        //                            {
        //                                if (con[q].Name == itemList[w].Name)
        //                                {
        //                                    result[w].Add(i);
        //                                    break;
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }



        //            return result;
        //        }

        //        public static SetConfig CreateSet(List<ConfigItem> itemList)
        //        {

        //            if (itemList.Count > 0)
        //            {
        //                SetConfig result = new SetConfig();

        //                result.list = itemList;
        //                int[] im = new int[itemList.Count];

        //                for (int i = 0; i < itemList.Count; i++)
        //                {
        //                    itemList[i].Calculation(itemList);
        //                    im[i] = 0;
        //                }

        //                result.set = new List<List<object>>();

        //                List<List<int>> connected = DetermineConnected(itemList);


        //                bool isNotEnd = true;
        //                while (isNotEnd)//(im[0] < itemList[0].mas.Count)
        //                {
        //                    List<object> line = new List<object>(itemList.Count);

        //                    for (int i = 0; i < itemList.Count; i++)
        //                    {
        //                        line.Add(itemList[i].mas[im[i]]);
        //                    }


        //                    int t = 1;
        //                    while ((itemList.Count - t) >= 0)//(t <= itemList.Count)
        //                    {
        //                        if ((itemList[itemList.Count - t].ConfigType != ConfigItemType.ConnectedArray) &&
        //                            (itemList[itemList.Count - t].ConfigType != ConfigItemType.ConnectedValuesEnumeration) &&
        //                            (itemList[itemList.Count - t].ConfigType != ConfigItemType.File) &&
        //                            (itemList[itemList.Count - t].ConfigType != ConfigItemType.Folder) &&
        //                            (itemList[itemList.Count - t].ConfigType != ConfigItemType.XML) &&
        //                            (itemList[itemList.Count - t].ConfigType != ConfigItemType.EXEFile) &&
        //                            (itemList[itemList.Count - t].ConfigType != ConfigItemType.Calculation))
        //                        {
        //                            im[itemList.Count - t]++;
        //                            for (int j = 0; j < connected[itemList.Count - t].Count; j++)
        //                            {
        //                                im[connected[itemList.Count - t][j]]++;
        //                            }
        //                            break;
        //                        }
        //                        else
        //                        {
        //                            t++;
        //                        }

        //                    }



        //                    result.set.Add(line);

        //                    IncrementIndex(im, itemList, connected);

        //                    t = 0;
        //                    while (t < itemList.Count)
        //                    {
        //                        if ((itemList[t].ConfigType != ConfigItemType.ConnectedArray) &&
        //                            (itemList[t].ConfigType != ConfigItemType.ConnectedValuesEnumeration) &&
        //                            (itemList[t].ConfigType != ConfigItemType.File) &&
        //                            (itemList[t].ConfigType != ConfigItemType.Folder) &&
        //                            (itemList[t].ConfigType != ConfigItemType.XML) &&
        //                            (itemList[t].ConfigType != ConfigItemType.EXEFile) &&
        //                            (itemList[t].ConfigType != ConfigItemType.Calculation))
        //                        {
        //                            isNotEnd = (im[t] < itemList[t].mas.Count);
        //                            break;
        //                        }
        //                        else
        //                        {
        //                            t++;
        //                        }

        //                    }

        //                }

        //                return result;
        //            }
        //            else
        //                return null;
        //        }

        //        public static void IncrementIndex(int[] im, List<ConfigItem> itemList, List<List<int>> connected)
        //        {

        //            int r = 0;
        //            while (r < itemList.Count)
        //            {
        //                if ((itemList[r].ConfigType != ConfigItemType.ConnectedArray) &&
        //                    (itemList[r].ConfigType != ConfigItemType.ConnectedValuesEnumeration) &&
        //                    (itemList[r].ConfigType != ConfigItemType.File) &&
        //                    (itemList[r].ConfigType != ConfigItemType.Folder) &&
        //                    (itemList[r].ConfigType != ConfigItemType.XML) &&
        //                    (itemList[r].ConfigType != ConfigItemType.EXEFile) &&
        //                    (itemList[r].ConfigType != ConfigItemType.Calculation))
        //                {
        //                    //isNotEnd = (im[t] < itemList[t].mas.Count);
        //                    break;
        //                }
        //                else
        //                {
        //                    r++;
        //                }

        //            }
        //            r++;
        //            for (int i = itemList.Count - 1; i >= r; i--)
        //            {
        //                if (im[i] == itemList[i].mas.Count)
        //                {
        //                    if ((itemList[i].ConfigType != ConfigItemType.ConnectedArray) &&
        //                            (itemList[i].ConfigType != ConfigItemType.ConnectedValuesEnumeration) &&
        //                            (itemList[i].ConfigType != ConfigItemType.File) &&
        //                            (itemList[i].ConfigType != ConfigItemType.Folder) &&
        //                            (itemList[i].ConfigType != ConfigItemType.XML) &&
        //                            (itemList[i].ConfigType != ConfigItemType.EXEFile) &&
        //                            (itemList[i].ConfigType != ConfigItemType.Calculation))
        //                    {
        //                        im[i] = 0;
        //                        for (int j = 0; j < connected[i].Count; j++)
        //                        {
        //                            if (im[connected[i][j]] != itemList[connected[i][j]].mas.Count)
        //                                im[connected[i][j]]--;
        //                        }

        //                        int t = 1;
        //                        while (t >= 0)//(t <= itemList.Count)
        //                        {
        //                            if ((itemList[i - t].ConfigType != ConfigItemType.ConnectedArray) &&
        //                                (itemList[i - t].ConfigType != ConfigItemType.ConnectedValuesEnumeration) &&
        //                                (itemList[i - t].ConfigType != ConfigItemType.File) &&
        //                                (itemList[i - t].ConfigType != ConfigItemType.Folder) &&
        //                                (itemList[i - t].ConfigType != ConfigItemType.XML) &&
        //                                (itemList[i - t].ConfigType != ConfigItemType.EXEFile) &&
        //                                (itemList[i - t].ConfigType != ConfigItemType.Calculation))
        //                            {
        //                                im[i - t]++;
        //                                for (int j = 0; j < connected[i - t].Count; j++)
        //                                {
        //                                    im[connected[i - t][j]]++;
        //                                }
        //                                break;
        //                            }
        //                            else
        //                            {
        //                                t++;
        //                            }

        //                        }
        //                    }
        //                }
        //            }

        //            for (int i = itemList.Count - 1; i >= 1; i--)
        //            {
        //                if ((itemList[i].ConfigType == ConfigItemType.ConnectedArray) ||
        //                            (itemList[i].ConfigType == ConfigItemType.ConnectedValuesEnumeration) ||
        //                            (itemList[i].ConfigType == ConfigItemType.File) ||
        //                            (itemList[i].ConfigType == ConfigItemType.Folder) ||
        //                            (itemList[i].ConfigType == ConfigItemType.XML) ||
        //                            (itemList[i].ConfigType == ConfigItemType.EXEFile) ||
        //                            (itemList[i].ConfigType == ConfigItemType.Calculation))
        //                {
        //                    if (im[i] >= itemList[i].mas.Count)
        //                    {
        //                        im[i] = 0;
        //                    }
        //                }
        //            }
        //        }

        //        public string PrintConfiguration(string com)
        //        {
        //            string result = "";

        //            result += Name + "\n";
        //            result += items.Count.ToString() + "\n";
        //            result += com + "\n";
        //            for (int i = 0; i < items.Count; i++)
        //            {
        //                result += items[i].PrintItem();
        //            }

        //            return result;
        //        }

        //        public void LoadConfig(string[] text, ref int j)
        //        {
        //            Name = text[j];
        //            j++;
        //            int count = 0;
        //            if (int.TryParse(text[j], System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out count))
        //            {
        //                j++;
        //                Comment = text[j];
        //                j++;

        //                for (int i = 0; i < count; i++)
        //                {
        //                    ConfigItem item = new ConfigItem();
        //                    item.LoadItem(text, ref j);
        //                    item.config = this;
        //                    items.Add(item);

        //                }

        //            }
        //            else
        //            {
        //                j++;
        //                Comment = text[j];
        //                j++;
        //            }

        //        }


        //        public void Clear()
        //        {
        //            for (int i = 0; i < items.Count; i++)
        //                items[i].Clear();
        //            items.Clear();
        //            Name = "";
        //        }

        public List<ConfigItem> GetItems()
        {
            return items;
        }

        //        public void Add(string name, string val)
        //        {
        //            ConfigItem item = new ConfigItem();
        //            item.Name = name;
        //            item.Value = val;
        //            item.config = this;
        //            items.Add(item);
        //        }

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

        //        public static string GetFileNameParam(ConfigItem item, object l)
        //        {
        //            string result = "";
        //            if ((item.ConfigType == ConfigItemType.XML) || (item.ConfigType == ConfigItemType.File))
        //                result += Path.GetFileNameWithoutExtension(l.ToString()) + "_";
        //            else
        //                result += l.ToString() + "_";
        //            return result;
        //        }

        //        public static string CreateFileName(ConfigItem configItem, List<object> list, List<ConfigItem> itemList)
        //        {
        //            string result = configItem.Name;

        //            List<ConfigItem> param = DetermineCalculationConnected(configItem.Value, itemList);

        //            for (int j = 0; j < itemList.Count; j++)
        //            {
        //                for (int i = 0; i < param.Count; i++)
        //                {
        //                    if (param[i].Name == itemList[j].Name)
        //                    {
        //                        result += GetFileNameParam(itemList[j], list[j]) + "_";
        //                    }
        //                }
        //            }
        //            result += ".txt";
        //            return result;
        //        }

        //        public ConfigItem GetItems(string p)
        //        {
        //            for (int i = 0; i < items.Count; i++)
        //            {
        //                if (p == items[i].Name)
        //                {
        //                    return items[i];
        //                }
        //            }
        //            return null;
        //        }
    }
}
