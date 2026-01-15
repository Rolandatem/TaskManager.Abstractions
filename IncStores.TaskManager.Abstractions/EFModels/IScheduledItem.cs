using System;

namespace IncStores.TaskManager.EFModels
{
    public interface IScheduledItem
    {
        int ID { get; set; }
        string ScheduleName { get; set; }
        int TaskRecipeTypeId { get; set; }
        string TaskRecipeData { get; set; }
        DateTime? LastRanTime { get; set; }
        bool IsReady { get; }
    }
}
