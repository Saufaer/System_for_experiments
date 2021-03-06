﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    public class Info
    {
        public String[] ParameterArr;
        public String[] ValidValuesArr;
        public String[] DefaultValuesArr;
        public String[] DescriptionArr;
        public Info()
        {
            ParameterArr = new String[57]
     {
"-Separator",
"-HELP",
"-NumPoints",
"-StepPrintMessages",
"-TypeMethod",
"-TypeCalculation",
"-TypeProcess",
"-NumThread",
"-SizeInBlock",
"-IsPrintFile",
"-Dimension",
"-r",
"-rEps",
"-rs ",
"-Eps",
"-Comment",
"-Epsilon",
"-M",
"-m",
"-deviceCount",
"-MapType",
"-NumOfTaskLevels",
"-DimInTaskLevel",
"-ChildInProcLevel",
"-MapInLevel",
"-MapProcInLevel",
"-IsPlot",
"-IsCalculateNumPoint",
"-MaxNumOfPoints",
"-IsSetDevice",
"-deviceIndex",
"-ProcRank",
"-localVerificationType",
"-localMix",
"-localAlpha",
"-calculationsArray",
"-sepS",
"-rndS",
"-libPath",
"-libConfigPath",
"-stopCondition",
"-iterPointsSavePath",
"-printAdvancedInfo",
"-disablePrintParameters",
"-logFileNamePrefix",
"-TypeSolver",
"-DimInTask",
"-Lamda",
"-rLamda",
"-numberOfLamda",
"-isCriteriaScaling",
"-itrEps",
"-isLoadFirstPointFromFile",
"-FirstPointFilePath",
"-func_num",
"-GKLS_global_dist",
"-GKLS_global_radius"
     };
            ValidValuesArr = new String[57]
            {
"любая строка без пробелов, не может быть \".\" и \";\"",
"не имеет(без аргумента)",
">0",
">0",
"перечисление ETypeMethod \r\n или число от 0 до 8",
"перечисление ETypeCalculation \r\n или число от 0 до 2",
"перечисление ETypeProcess \r\n или значение от 0 до 2",
">0",
">0",
"0|1 или false|true",
">0",
">1",
">0",
"непустой массив из чисел > 1",
"непустой массив из чисел > 0",
"любая строка без пробелов",
">0",
">0",
">1",
">=-1",
"Перечисление EMapType или значение от 0 до 2",
"от 1 до 5",
"непустой массив из неотрицательных чисел",
"непустой массив из неотрицательных чисел",
"непустой массив из чисел > 0",
"непустой массив из чисел > 0",
"false|true",
"false|true",
"непустой массив из чисел > 0",
"0|1 или false|true",
">=0",
">=0",
"Перечисление ELocalMethodScheme или значение от 0 до 2",
">=0",
">0",
"непустой массив из чисел от -1 до 2",
"Перечисление ELocalMethodScheme или значение от 0 до 2",
"0|1 или false|true",
"любая строка без пробелов",
"любая строка без пробелов",
"Перечисление EStopCondition или значение от 0 до 4",
"любая строка без пробелов",
"false|true",
"false|true",
"любая строка без пробелов",
"Перечисление ETypeSolver или значение от 0 до 2",
"непустой массив из чисел > 0",
"вещественные числа",
"целые числа",
"целые числа",
"0|1 или false|true",
"целые числа",
"0|1 или false|true",
"любая строка без пробелов",
"от 1 до 100",
">0",
">0"
            };
            DefaultValuesArr = new String[57] {
"_",
" ",
"1",
"1000",
"StandartMethod",
"OMP",
"SynchronousProces",
"1",
"32",
"false",
"2",
"2.3",
"0.01",
"2.3_2.3_2.3_2.3",
"0.01_0.01_0.01_0.01",
"000",
"0.01",
"1",
"10",
"-1",
"mpBase",
"1",
"2_0_0_0",
"0_0_0_0",
"1_1_1_1",
"1_1_1_1",
"false",
"false",
"7000000_1000000_1000000_1000000",
"false",
"-1",
"0",
"None",
"0",
"15",
"-1_-1",
"Off",
"false",
"rastrigin.dll | ./librastrigin.so",
" ",
"Accuracy",
" ",
"false",
"false",
"examin_log",
"SingleSearch",
"0_0_0_0",
"-1",
"-1",
"50",
"false",
"0",
"false",
" ",
"1",
"0.9",
"0.33"
        };
            DescriptionArr = new String[57] {
"разделитель элементов массива",
"указывает, нужно ли выводить справку",
"число точек испытания, порождаемых \r\n методом за одну итерацию",
"через сколько итераций печатать \r\n в консоли сообщение \r\nо текущем количестве итераций",
"тип используемого метода",
"тип вычислительного ресурса,\r\n используемого для проведения испытаний",
"тип процесса",
"число используемых потоков",
"размер CUDA блока",
"печатать отчет в файл",
"размерность исходной задачи",
"надежность метода",
"eps-резервирование, используется в индексном методе",
"значение r для каждого из уровней дерева",
"значение Epsilon для каждого из уровней дерева процессов",
"комментарий к запуску",
"точность для критерия остановки,\r\n общее значение для всех \r\nуровней дерева процессов",
"начальная оценка константы Липшица",
"плотность построения развертки \r\n(точность 1/2^m по координате)",
"кол-во используемых ускорителей",
"тип развертки (сдвиговая, вращаемая)",
"число уровней в дереве задач,\r\nсовпадает с NumOfProcLevels",
"число размерностей на каждом\r\n уровне дерева задач .\r\nразмер: NumOfTaskLevels",
"число потомков у процессов \r\n на уровнях с 1 до NumOfTaskLevels – 1\r\n размер: NumOfProcLevels – 1\r\n уровень NumOfTaskLevels – процессы-листья",
"число разверток \r\nна каждом уровне дерева процессов\r\n размер: NumOfProcLevels",
"число процессов \r\nна каждом уровне дерева процессов,\r\n использующих множественную развертку\r\n размер - NumOfProcLevels\r\n последний уровень по разверткам не параллелится\r\n* число процессов обрабатывающие разные \r\n развертки на уровне (узле дерева распараллеливания)\r\n*если один корень то MapInLevel[0]*ProcNum=MapInLevel[0]\r\n*определяет число соседей",
"Рисует линии уровней\r\n для двумерной задачи, \r\n если указан -sip то также \r\nотображаются точки испытаний",
"Число испытаний \r\nза итерацию будет вычисляться  \r\n на каждой итерации \r\nв методе CalculateNumPoint()",
"максимальное число итераций\r\n для процессов на каждом уровне",
"назначать каждому процессу свое устройство (ускоритель)",
"Индекс используемого \r\nустройства (ускорителей),\r\n если -1 используется \r\nпервые deviceCount устройств",
"Номер MPI процесса,\r\n вычисляется автоматически (нельзя задать)",
"cпособ использования локального метода\r\n(только для синхронного типа процесса)",
"параметр смешивания в \r\nлокально-глобальном алгоритме,\r\n через какое число итераций \r\n используется локальное уточнение",
"степень локальной адаптации\r\n в локально-глобальном алгоритме",
"распределение типов вычислений по процессам",
"флаг сепарабельного поиска\r\n на первой итерации",
"флаг случайного поиска\r\n на первой итерации",
"путь к библиотеке с задачей",
"путь к конфигурации для задачи",
"тип критерия остановки",
"путь, по которому будут \r\nсохранены многомерные точки,\r\n поставленные методом \r\nкорневого процесса",
"флаг, включающий печать\r\n дополнительной статистики:\r\n оценки констант Гёльдера \r\nи значения функций в точке оптимума",
"флаг, выключающий печать\r\n параметров при запуске системы",
"префикс в имени лог-файла",
"тип способа решения задачи",
"размерности каждой \r\n из подзадач в режиме\r\n сепарабильного или\r\n сикуенсального поиска",
"параметры свертки(double)",
"параметры свертки(int)",
"количество коэффициентов свертки",
"нужно ли масштабирование\r\n значений критериев при свертке",
"число итераций до попадания в eps-окрестность",
"Загружать начальные точки из файла\r\n или распределять их равномерно \r\n(не поддерживается)",
"Путь откуда будут считаны начальные точки испытания",
"номер задачи из генератора GKLS",
"расстояние от параболоидного минимизатора",
"радиус глобального минимизатора"
   };
        }
    }
}
