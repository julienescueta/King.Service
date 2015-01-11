﻿namespace King.Service
{
    using King.Service.Timing;

    /// <summary>
    /// Adaptive Runner
    /// </summary>
    public class AdaptiveRunner : AdaptiveTask
    {
        #region Members
        /// <summary>
        /// Dynamic Runs
        /// </summary>
        protected readonly IDynamicRuns run = null;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="run">Run</param>
        /// <param name="strategy">Timing Strategy</param>
        public AdaptiveRunner(IDynamicRuns run, Strategy strategy = Strategy.Exponential)
            : base(run.MinimumPeriodInSeconds, run.MaximumPeriodInSeconds, strategy)
        {
            this.run = run;

            base.ServiceName = string.Format("{0}+{1}", this.GetType(), this.run.GetType());
        }
        #endregion

        #region Methods
        /// <summary>
        /// Run
        /// </summary>
        /// <param name="workWasDone">Work Was Done</param>
        public override void Run(out bool workWasDone)
        {
            workWasDone = this.run.Run().Result;
        }
        #endregion
    }
}