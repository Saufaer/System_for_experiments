#include <string>
#include <fstream>
#include <iostream>
#include <vector>


#include "solver.h"
#ifdef USE_PLOTTER
#include "isolinesPlotter.h"
#endif
// ------------------------------------------------------------------------------------------------
int main(int argc, char* argv[])
{
    if (argc == 2)//examin.exe configuration.txt
    {
        //чтение conf всё с новой строки без пробелов
        std::string confFilename(argv[1]);
        std::ifstream source;
        source.open(confFilename);

        if (!source) return 1;
        std::vector<std::string> lines;
        std::string line = "";
        int num = 0;
        while (true) {
            if (source.eof()) break;
            std::getline(source, line);
            lines.push_back(line);
            num++;
        }
        source.close();

        const std::vector<std::string> v = lines;

        std::vector< char*> cStrings;
        int size = num;

        for (int i = 0; i < size; ++i)
        {
            char *cstr = new char[v[i].length() + 1];
            strcpy_s(cstr, v[i].length() + 1, v[i].c_str());

            cStrings.push_back(cstr);
        }
        argv = new char *[size + 1];
        for (int i = 0; i < size; ++i)
        {
            argv[i] = cStrings[i];
        }
        argc = size;//examin.exe + params in conf
        std::cout << "Argv Config:";

        for (int i = 0; i < size; ++i)
        {
            printf("%s ", argv[i]);
        }
        std::cout << std::endl << "Argc Params:" << argc;
    }//Run classic


    MPI_Init(&argc, &argv);
    TParameters parameters;
    parameters.Init(argc, argv, true);
    if (!parameters.IsStart())
    {
        print << "Need command-line arguments!";
        return 0;
    }
    //      
    TOutputMessage::Init(true, parameters.logFileNamePrefix, parameters.GetProcNum(),
        parameters.GetProcRank());
    TProblemManager manager;
    IProblem* problem = 0;
    if (InitProblem(manager, problem, parameters, argc, argv, 1))
    {
        print << "Error during problem initialization\n";
        return 0;
    }
    double optimumValue;
    if (problem->GetOptimumValue(optimumValue) == IProblem::UNDEFINED &&
        parameters.stopCondition == OptimumValue)
    {
        print << "Stop by reaching optimum value is unsupported by this problem\n";
        return 0;
    }
    double optimumPoint[MaxDim*MaxNumOfGlobMinima];
    int n;
    if (problem->GetOptimumPoint(optimumPoint) == IProblem::UNDEFINED &&
        problem->GetAllOptimumPoint(optimumPoint, n) == IProblem::UNDEFINED &&
        parameters.stopCondition == OptimumVicinity)
    {
        print << "Stop by reaching optimum vicinity is unsupported by this problem\n";
        return 0;
    }
    if (parameters.GetProcRank() == 0 && !parameters.disablePrintParameters)
        parameters.PrintParameters();
#ifdef WIN32
    unexpected_function prev, cur;
    cur = &Unexpected;
    prev = set_unexpected(cur);
    set_terminate(Terminate);
#endif
    // 
    TSolver solver(&parameters, problem);
    //  
    if (solver.Solve() != SYSTEM_OK)
        throw EXCEPTION("Error: solver.Solve crash!!!");
    if (parameters.IsPlot && parameters.GetProcRank() == 0)
    {
#ifdef USE_PLOTTER
        plot2dProblemIsolines(problem, parameters.GetPlotFileName(), parameters.iterPointsSavePath);
#else
        print << "Plotter is disabled in current configuration\n";
#endif
    }
    MPI_Finalize();

    return 0;
}
// - end of file ----------------------------------------------------------------------------------
