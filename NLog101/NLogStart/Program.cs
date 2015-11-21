using System;
using System.Threading;
using NLog;

namespace NLogStart
{
    class Program
    {
        private static Logger logger;
        static void Main(string[] args)
        {
            logger = LogManager.GetCurrentClassLogger();
            DependencyFactory.RegisterDependency<IMathSolver, MathSolver>();
            logger.Trace("Logger Created");

            IMathSolver solver = DependencyFactory.Resolve<IMathSolver>();
            solver.DoComplexTimeTakingCalculation();
            Console.ReadLine();
        }
    }

    
}
