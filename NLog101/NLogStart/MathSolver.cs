using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NLog;

namespace NLogStart
{
    /// <summary>
    /// Sample Math Solver Class
    /// </summary>
    public class MathSolver : IMathSolver
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
