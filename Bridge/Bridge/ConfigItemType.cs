using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bridge
{
//    public class ConfigItemType
//    {
//        public static int Count = 10;

//        public static int iValue = 0;
//        public static int iArray = 1;
//        public static int iCalculation = 2;
//        public static int iXML = 3;
//        public static int iFile = 4;
//        public static int iEXEFile = 5;
//        public static int iFolder = 6;
//        public static int iConnectedArray = 7;
//        public static int iConnectedValuesEnumeration = 8;
//        public static int iValuesEnumeration = 9;


//        public static string sValue = "Value";
//        public static string sArray = "Array";
//        public static string sCalculation = "Calculation";
//        public static string sXML = "XML";
//        public static string sFile = "File";
//        public static string sEXEFile = "EXEFile";
//        public static string sFolder = "Folde";
//        public static string sConnectedArray = "ConnectedArray";
//        public static string sConnectedValuesEnumeration = "ConnectedValuesEnumeration";
//        public static string sValuesEnumeration = "ValuesEnumeration";


//        public static string[] sConfigTypes;
//        public static ConfigItemType[] ConfigTypes;

//        public static object[] configItemDoubleList;
//        public static object[] configItemStringList;

//        protected int currentItemType;
//        protected string currentSItemType;

//        public static ConfigItemType Value;
//        public static ConfigItemType Array;
//        public static ConfigItemType Calculation;
//        public static ConfigItemType XML;
//        public static ConfigItemType File;
//        public static ConfigItemType EXEFile;
//        public static ConfigItemType Folder;
//        public static ConfigItemType ConnectedArray;
//        public static ConfigItemType ValuesEnumeration;
//        public static ConfigItemType ConnectedValuesEnumeration;

//        static ConfigItemType()
//        {
//            sConfigTypes = new string[] { sValue, sArray, sCalculation, sXML, sFile, sEXEFile, sFolder, sConnectedArray, sConnectedValuesEnumeration, sValuesEnumeration };
//            configItemDoubleList = new object[] { sValue, sArray, sCalculation, sXML, sFile, sEXEFile, sFolder, sConnectedArray, sConnectedValuesEnumeration, sValuesEnumeration };
//            configItemStringList = new object[] { sValue, sArray, sCalculation, sXML, sFile, sEXEFile, sFolder, sConnectedArray, sConnectedValuesEnumeration };


//            Value = new ConfigItemType();
//            Value.CurrentItemType = iValue;

//            Array = new ConfigItemType();
//            Array.CurrentItemType = iArray;

//            Calculation = new ConfigItemType();
//            Calculation.CurrentItemType = iCalculation;

//            XML = new ConfigItemType();
//            XML.CurrentItemType = iXML;

//            File = new ConfigItemType();
//            File.CurrentItemType = iFile;

//            EXEFile = new ConfigItemType();
//            EXEFile.CurrentItemType = iEXEFile;

//            Folder = new ConfigItemType();
//            Folder.CurrentItemType = iFolder;

//            ConnectedArray = new ConfigItemType();
//            ConnectedArray.CurrentItemType = iConnectedArray;

//            ValuesEnumeration = new ConfigItemType();
//            ValuesEnumeration.CurrentItemType = iValuesEnumeration;

//            ConnectedValuesEnumeration = new ConfigItemType();
//            ConnectedValuesEnumeration.CurrentItemType = iConnectedValuesEnumeration;

//            ConfigTypes = new ConfigItemType[] { Value, Array, Calculation, XML, File, EXEFile, Folder, ConnectedArray, ConnectedValuesEnumeration, ValuesEnumeration };
//        }

//        public ConfigItemType()
//        {
//            currentItemType = iValue;
//            currentSItemType = sConfigTypes[iValue];
//        }

//        public ConfigItemType Clone()
//        {
//            ConfigItemType result = new ConfigItemType();
//            result.currentItemType = currentItemType;
//            result.currentSItemType = currentSItemType;
//            return result;
//        }

//        public int CurrentItemType
//        {
//            get
//            {
//                return currentItemType;
//            }
//            set
//            {
//                currentItemType = value;
//                currentSItemType = sConfigTypes[value];
//            }
//        }
//        public string CurrentSItemType
//        {
//            get
//            {
//                return currentSItemType;
//            }
//            set
//            {

//                currentSItemType = value;
//                for (int i = 0; i < Count; i++)
//                    if (sConfigTypes[i] == currentSItemType)
//                    {
//                        currentItemType = i;
//                        break;
//                    }
//            }
//        }


//        public static bool operator ==(ConfigItemType a, ConfigItemType b)
//        {
//            return a.currentItemType == b.currentItemType;
//        }

//        public static bool operator !=(ConfigItemType a, ConfigItemType b)
//        {
//            return a.currentItemType != b.currentItemType;
//        }
//    }
}
