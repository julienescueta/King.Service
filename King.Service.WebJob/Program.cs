﻿namespace King.Service.WebJob
{
    using System.Threading;
    using Worker;

    // To learn more about Microsoft Azure WebJobs, please see http://go.microsoft.com/fwlink/?LinkID=401557
    public class Program
    {
        public static void Main()
        {
            var manager = new RoleTaskManager<Configuration>(new Factory());
            var config = new Configuration()
            {
                ConnectionString = "UseDevelopmentStorage=true;",
                TableName = "table",
                QueueName = "queue",
                ContainerName = "container",
            };

            if (manager.OnStart(config))
            {
                manager.Run();

                while (true)
                {
                    Thread.Sleep(10000);
                }
            }
        }
    }
}