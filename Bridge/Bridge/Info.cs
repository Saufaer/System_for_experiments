using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class Info
    {
        public string[] ParameterArr;
        public string[] ValidValuesArr;
        public string[] DefaultValuesArr;
        public string[] DescriptionArr;
        public Info()
        {
            ParameterArr = new string[9]
     {
"-NumPoints",
"-StepPrintMessages",
"-TypeMethod",
"-TypeCalculation",
"-TypeProcess",
"-NumThread",
"-SizeInBlock",
"-IsPrintFile",
"-Dimension"
     };
            ValidValuesArr = new string[9]
            {
">0",
">0",
"перечисление ETypeMethod \r\n или число от 0 до 8",
"перечисление ETypeCalculation \r\n или число от 0 до 2",
"перечисление ETypeProcess \r\n или значение от 0 до 2",
">0",
">0",
"0|1 или false|true",
">0"
            };
            DefaultValuesArr = new string[9] {
"1",
"1000",
"StandartMethod",
"OMP",
"SynchronousProces",
"1",
"32",
"false",
"берется из задачи"
        };
            DescriptionArr = new string[9] {
   " число точек испытания, порождаемых \r\n методом за одну итерацию",
   " через сколько итераций печатать \r\n в консоли сообщение о текущем количестве итераций",
   " тип используемого метода",
   " тип вычислительного ресурса,\r\n используемого для проведения испытаний",
   " тип процесса",
   " число используемых потоков",
   " размер CUDA блока",
   " печатать отчет в файл",
   " размерность исходной задачи"
   };
        }
    }
}
