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
            logger.Trace("Logger Created");
            MathSolver solver = new MathSolver();
            solver.DoComplexTimeTakingCalculation();
            Console.ReadLine();
        }
    }

    public class MathSolver
    {
        private Logger logger;

        /// <summary>
        /// Simple Constructor
        /// </summary>
        public MathSolver()
        {
            logger = LogManager.GetCurrentClassLogger();
            logger.Trace("Constructor Called");
        }

        public void DoComplexTimeTakingCalculation()
        {
            logger.Trace("DoComplexTimeTakingCalculation Called");
            try
            {
                logger.Info("Starting Processing Data");
                Thread.Sleep(3000);
                int a = Int32.Parse("W");
            }
            catch (Exception ex)
            {
                logger.Error("An Exception Occured: " + ex.Message);
                //do something :)
            }
            logger.Trace("DoComplexTimeTakingCalculation Ended");
        }
    }
}
