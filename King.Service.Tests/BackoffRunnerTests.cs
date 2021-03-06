﻿namespace King.Service.Tests
{
    using NSubstitute;
    using NUnit.Framework;
    using System;
    using System.Threading.Tasks;

    [TestFixture]
    public class BackoffRunnerTests
    {
        [Test]
        public void Constructor()
        {
            var runs = Substitute.For<IDynamicRuns>();
            runs.MinimumPeriodInSeconds.Returns(1);
            runs.MaximumPeriodInSeconds.Returns(100);

            new BackoffRunner(runs);

            var min = runs.Received().MinimumPeriodInSeconds;
            var max = runs.Received().MaximumPeriodInSeconds;
        }

        [Test]
        public void IsBackoffTask()
        {
            var runs = Substitute.For<IDynamicRuns>();
            runs.MinimumPeriodInSeconds.Returns(1);
            runs.MaximumPeriodInSeconds.Returns(100);

            Assert.IsNotNull(new BackoffRunner(runs) as BackoffTask);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void ConstructorRunsNull()
        {
            new BackoffRunner(null);
        }

        [Test]
        public void Run()
        {
            var runs = Substitute.For<IDynamicRuns>();
            runs.MinimumPeriodInSeconds.Returns(1);
            runs.MaximumPeriodInSeconds.Returns(100);
            runs.Run().Returns(Task.FromResult(false));

            var task = new BackoffRunner(runs);
            task.Run();

            var min = runs.Received().MinimumPeriodInSeconds;
            var max = runs.Received().MaximumPeriodInSeconds;
            runs.Received().Run();
        }
    }
}
