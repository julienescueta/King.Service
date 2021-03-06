﻿namespace King.Service
{
    using King.Service.Timing;

    /// <summary>
    /// Recurring Runner
    /// </summary>
    public class RecurringRunner : RecurringTask
    {
        #region Members
        /// <summary>
        /// Backoff Runs
        /// </summary>
        protected readonly IRuns run = null;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="run">Run</param>
        /// <param name="strategy">Timing Strategy</param>
        public RecurringRunner(IRuns run)
            : base(BaseTimes.MinimumTiming, run.MinimumPeriodInSeconds)
        {
            this.run = run;

            base.ServiceName = string.Format("{0}+{1}", this.GetType(), this.run.GetType());
        }
        #endregion

        #region Methods
        /// <summary>
        /// Run
        /// </summary>
        public override void Run()
        {
            this.run.Run().Wait();
        }
        #endregion
    }
}