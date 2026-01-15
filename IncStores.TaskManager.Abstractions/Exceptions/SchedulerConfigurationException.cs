using System;

namespace IncStores.TaskManager.Exceptions
{
    /// <summary>
    /// Exception used when the configuration of a scheduled task is incorrect.
    /// </summary>
    public class SchedulerConfigurationException : Exception
    {
        public SchedulerConfigurationException() { }
        public SchedulerConfigurationException(string exceptionMessage)
            : base(exceptionMessage) { }
    }
}
