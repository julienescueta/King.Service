﻿namespace Worker
{
    using King.Azure.BackgroundWorker;
    using System.Diagnostics;

    public class CoordinatedTask : CoordinatedManager
    {
        public CoordinatedTask()
            : base("UseDevelopmentStorage=true", 10)
        {
        }

        public override void Run()
        {
            //Task that you want to do
        }
    }
}