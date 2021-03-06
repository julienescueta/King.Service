﻿namespace King.Service.Data.Model
{
    using Microsoft.WindowsAzure.Storage.Table;
    using System;

    /// <summary>
    /// Scheduled Task Entry
    /// </summary>
    public class ScheduledTaskEntry : TableEntity
    {
        #region Properties
        /// <summary>
        /// Identifier
        /// </summary>
        public virtual Guid? Identifier
        {
            get
            {
                return string.IsNullOrEmpty(this.RowKey) ? (Guid?)null : Guid.Parse(this.RowKey);
            }
            set
            {
                this.RowKey = null == value ? null : value.ToString();
            }
        }

        /// <summary>
        /// Start Time
        /// </summary>
        public virtual DateTime StartTime
        {
            get;
            set;
        }

        /// <summary>
        /// Completion Time
        /// </summary>
        public virtual DateTime? CompletionTime
        {
            get;
            set;
        }

        /// <summary>
        /// the Service Name
        /// </summary>
        public virtual string ServiceName
        {
            get;
            set;
        }

        /// <summary>
        /// Successful
        /// </summary>
        public virtual bool Successful
        {
            get;
            set;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Generate the partition key
        /// Format: {type}-{year}-{month}
        /// </summary>
        /// <param name="type">Backup data type</param>
        /// <returns>Partition key</returns>
        public static string GenerateLogsPartitionKey(string serviceName)
        {
            const string format = "{0}-{1:yyyy}-{1:MM}";
            return string.Format(format, serviceName, DateTime.UtcNow);
        }
        #endregion
    }
}