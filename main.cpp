/////////////////////////////////////////////////////////////////////////////
//                                                                         //
//             LOBACHEVSKY STATE UNIVERSITY OF NIZHNY NOVGOROD             //
//                                                                         //
//                       Copyright (c) 2015 by UNN.                        //
//                          All Rights Reserved.                           //
//                                                                         //
//  File:      Main.cpp                                                    //
//                                                                         //
//  Purpose:   Console version of ExaMin system                            //
//                                                                         //
//  Author(s): Sysoyev A., Barkalov K.                                     //
//                                                                         //
/////////////////////////////////////////////////////////////////////////////
#include "solver.h"
#include "ConfigReader.h"
#ifdef USE_PLOTTER
#include "isolinesPlotter.h"
#endif
// ------------------------------------------------------------------------------------------------

int main(int argc, char* argv[])
{
    if (argc == 2)//examin.exe <configuration>.xml
    {
			//Edit argc and argv as config file
			XMLConfigReader(argc, argv);
    }
    //Run classic

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
