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
    public class ConfigItem
    {

        protected string name;
        protected string value;
        protected XElement xmlElement;

       // public static int Size = 14;

        //public Type MyType { get; set; }
        //public string LeftValue { get; set; }
        //public string RightValue { get; set; }
        //public string Step { get; set; }
        //public List<string> Values { get; set; }
        //public ConfigItemType ConfigType { get; set; }
        //public Panel ItemPanel { get; set; }
        //public TextBox ItemFrom { get; set; }
        //public TextBox ItemTo { get; set; }
        //public TextBox ItemStep { get; set; }
        //public TextBox ItemArray { get; set; }
        //public TextBox ItemValue { get; set; }

        //public ComboBox ItemConfigType { get; set; }

        public Configuration config { get; set; }

        //public List<string> mas { get; set; }

        //public bool IsIncludedConsole { get; set; }

        //protected void DetermineType(string val)
        //{
        //    double z = 0;
        //    if (Double.TryParse(val, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out z))
        //    {
        //        MyType = z.GetType();
        //        if (ItemConfigType != null)
        //        {
        //            ItemConfigType.Items.Clear();
        //            ItemConfigType.Items.AddRange(ConfigItemType.configItemDoubleList);
        //        }
        //    }
        //    else
        //    {
        //        MyType = val.GetType();
        //        if (ItemConfigType != null)
        //        {
        //            ItemConfigType.Items.Clear();
        //            ItemConfigType.Items.AddRange(ConfigItemType.configItemStringList);
        //        }
        //    }
        //}

        public ConfigItem()
        {
            name = "";
            value = "";
            //MyType = "".GetType();
            //LeftValue = "";
            //RightValue = "";
            //Step = "";
            //Values = new List<string>();
            //ConfigType = ConfigItemType.Value.Clone();
            xmlElement = null;

            //mas = null;

            //IsIncludedConsole = true;

            //ClearPanel();
        }

        //public static string GetAllowableFileName(string name)
        //{
        //    return name.Replace('\\', '_').Replace('/', '_').Replace(':', '_').Replace('*', '_').Replace('?', '_').Replace('\"', '_').Replace('<', '_').Replace('>', '_').Replace('|', '_');
        //}

        //public void Calculation(List<ConfigItem> all)
        //{

        //    //iValue = 0;
        //    //iArray = 1;
        //    //iCalculation = 2;
        //    //iXML = 3;
        //    //iConnectedArray = 4;
        //    //iValuesEnumeration = 5;
        //    //iConnectedValuesEnumeration = 6;
        //    mas = null;
        //    if ((ConfigType == ConfigItemType.Value) || (ConfigType == ConfigItemType.EXEFile))
        //    {
        //        mas = new List<string>(1);
        //        mas.Add(Value);
        //    }
        //    else if ((ConfigType == ConfigItemType.Array) || (ConfigType == ConfigItemType.ConnectedArray))
        //    {
        //        mas = new List<string>(Values.Count);
        //        for (int i = 0; i < Values.Count; i++)
        //            mas.Add(Values[i]);
        //    }
        //    else if (ConfigType == ConfigItemType.XML)
        //    {
        //        mas = new List<string>(1);
        //        mas.Add(Values[0]);
        //    }
        //    else if ((ConfigType == ConfigItemType.File) || (ConfigType == ConfigItemType.Folder))
        //    {
        //        mas = new List<string>(1);
        //        List<ConfigItem> param = new List<ConfigItem>();
        //        if (Value == "all")
        //        {
        //            //param = all;
        //            for (int i = 0; i < all.Count; i++)
        //            {
        //                if ((all[i].ConfigType != ConfigItemType.XML) &&
        //                    (all[i].ConfigType != ConfigItemType.File) &&
        //                    (all[i].ConfigType != ConfigItemType.EXEFile) &&
        //                    (all[i].ConfigType != ConfigItemType.Folder))
        //                {
        //                    param.Add(all[i]);
        //                }
        //            }
        //        }
        //        else if (Value == "")
        //        {
        //            mas.Add(Values[0]);
        //            return;
        //        }
        //        else
        //            param = Configuration.DetermineCalculationConnected(Value, all);

        //        SetConfig set = Configuration.CreateSet(param);
        //        for (int i = 0; i < set.set.Count; i++)
        //        {
        //            string res = "";
        //            if (ConfigType == ConfigItemType.Folder)
        //            {
        //                res += Values[0] + "_";
        //            }

        //            for (int j = 0; j < set.set[i].Count; j++)
        //            {
        //                //if (set.list[j].Name != "Исполняемый файл")
        //                res += set.set[i][j].ToString() + "_";
        //            }
        //            res = GetAllowableFileName(res);
        //            if (ConfigType == ConfigItemType.File)
        //            {
        //                res += Values[0];
        //            }
        //            mas.Add(res);
        //        }

        //    }
        //    else if (ConfigType == ConfigItemType.Calculation)
        //    {
        //        mas = new List<string>(1);

        //        List<ConfigItem> param = Configuration.DetermineCalculationConnected(Value, config.GetItems());   //связанные с текущим

        //        string funcParam = " ";
        //        string tf = "";
        //        for (int k = 0; k < param.Count; k++)
        //        {
        //            if (param[k].MyType == typeof(double))
        //                tf = "double";
        //            else
        //                tf = "string";

        //            funcParam += tf + " " + param[k].Name;
        //            if (k != (param.Count - 1))
        //                funcParam += ", ";
        //            else
        //                funcParam += " ";
        //        }

        //        CodeDomProvider csharp = Microsoft.CSharp.CSharpCodeProvider.CreateProvider("CSharp");
        //        CompilerParameters cp = new CompilerParameters();
        //        cp.GenerateExecutable = false;
        //        cp.GenerateInMemory = true;
        //        cp.IncludeDebugInformation = false;
        //        cp.ReferencedAssemblies.Add("System.dll");

        //        if (MyType == typeof(double))
        //            tf = "double";
        //        else
        //            tf = "string";

        //        string source =

        //        "using System; " +
        //        "class С {" +
        //            "public " + "string" + " f( " + funcParam + " ) { return ( " + Value + " ).ToString(System.Globalization.CultureInfo.InvariantCulture) ;}" +
        //            "public double sin(double x) {return Math.Sin(x);}" +
        //            "public double cos(double x) {return Math.Cos(x);}" +
        //            "public double qrt(double x) {return x * x;}" +
        //            "public double sqrt(double x) {return Math.Sqrt(x);}" +
        //            "public double exp(double x) {return Math.Exp(x);}" +
        //            "public double ln(double x) {return Math.Log(x);}" +
        //            "public double log(double x) {return Math.Log10(x);}" +
        //            "public double tan(double x) {return Math.Tan(x);}" +
        //            "static double E = Math.E;" +
        //            "static double PI = Math.PI;" +
        //        "}"
        //        ;

        //        SetConfig set = Configuration.CreateSet(param);

        //        CompilerResults res = csharp.CompileAssemblyFromSource(cp, source.Split('\n'));
        //        object obj = res.CompiledAssembly.CreateInstance("С");

        //        for (int i = 0; i < set.set.Count; i++)
        //        {
        //            object[] p = new object[param.Count];

        //            for (int k = 0; k < param.Count; k++)
        //            {
        //                if (param[k].MyType == typeof(double))
        //                {
        //                    p[k] = Convert.ToDouble(set.set[i][k]);
        //                }
        //                else
        //                {
        //                    p[k] = Convert.ToString(set.set[i][k]);
        //                }
        //            }

        //            object y = obj.GetType().GetMethod("f").Invoke(obj, p);

        //            if (MyType == typeof(double))
        //            {
        //                //tf = "double";
        //                double d = Convert.ToDouble(y);
        //                mas.Add(d.ToString(System.Globalization.CultureInfo.InvariantCulture));
        //            }
        //            else
        //            {
        //                mas.Add(Convert.ToString(y));
        //            }

        //        }
        //    }
        //    else if ((ConfigType == ConfigItemType.ValuesEnumeration) || (ConfigType == ConfigItemType.ConnectedValuesEnumeration))
        //    {
        //        double l = 0;
        //        double r = 0;
        //        double s = 0;

        //        if ((Double.TryParse(LeftValue, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out l)) &&
        //            (Double.TryParse(RightValue, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out r)) &&
        //            (Double.TryParse(Step, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out s)))
        //        {

        //            //List<double> md = new List<double>();
        //            mas = new List<string>();
        //            for (double i = l; i <= r; i += s)
        //            {
        //                mas.Add(i.ToString(System.Globalization.CultureInfo.InvariantCulture));
        //                //md.Add(i);
        //            }

        //        }
        //        else
        //        {
        //            mas = new List<string>(1);
        //            mas.Add(Value);
        //        }
        //    }

        //}

        //public string PrintItem()
        //{
        //    string result = "";

        //    result += "name\n";
        //    result += name + "\n";
        //    result += "value\n";
        //    result += value + "\n";
        //    result += "LeftValue\n";
        //    result += LeftValue + "\n";
        //    result += "RightValue\n";
        //    result += RightValue + "\n";
        //    result += "Step\n";
        //    result += Step + "\n";
        //    result += "Values\n";
        //    result += PrintArray() + "\n";
        //    result += "ConfigType\n";
        //    result += ConfigType.CurrentSItemType + "\n";

        //    return result;
        //}

        //public void LoadItem(string[] text, ref int j)
        //{
        //    j++;
        //    Name = text[j];
        //    j++;
        //    j++;
        //    Value = text[j];
        //    j++;
        //    j++;
        //    LeftValue = text[j];
        //    j++;
        //    j++;
        //    RightValue = text[j];
        //    j++;
        //    j++;
        //    Step = text[j];
        //    j++;
        //    j++;
        //    SetArray(text[j]);
        //    j++;
        //    j++;
        //    ConfigType.CurrentSItemType = text[j];
        //    j++;
        //}


        public string Name
        {
            get
            {
                return name;
            }
            //set
            //{
            //    name = value;
            //    if (xmlElement != null)
            //    {
            //        xmlElement.Name = value;
            //    }
            //}
        }

        public string Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
                //DetermineType(value);
                if (xmlElement != null)
                {
                    xmlElement.Value = value;
                }
            }
        }



        public XElement XMLElement
        {
            get
            {
                return xmlElement;
            }
            set
            {
                xmlElement = value;
                name = xmlElement.Name.ToString();
                Value = xmlElement.Value;
            }
        }

        //public void ClearPanel()
        //{
        //    ItemPanel = null;

        //    ItemFrom = null;
        //    ItemTo = null;
        //    ItemStep = null;
        //    ItemArray = null;
        //    ItemValue = null;

        //    ItemConfigType = null;
        //}

        //public void SetArray(string p)
        //{
        //    string[] s = p.Split(new char[] { ';' });
        //    Values.Clear();
        //    Values.AddRange(s);
        //}

        //public string PrintArray()
        //{
        //    string result = "";
        //    if (Values.Count > 0)
        //    {
        //        for (int i = 0; i < Values.Count - 1; i++)
        //        {
        //            result += Values[i] + ";";
        //        }
        //        result += Values[Values.Count - 1];
        //    }
        //    return result;
        //}

        //public void Clear()
        //{
        //    ClearPanel();
        //    name = "";
        //    value = "";
        //    MyType = "".GetType();
        //    LeftValue = "";
        //    RightValue = "";
        //    Step = "";
        //    Values.Clear();
        //    ConfigType = ConfigItemType.Value.Clone();
        //    xmlElement = null;
        //}



    }
}


