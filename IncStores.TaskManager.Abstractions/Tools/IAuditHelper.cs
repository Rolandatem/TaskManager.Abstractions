using System;
using System.Threading.Tasks;

namespace IncStores.TaskManager.Tools
{
    public interface IAuditHelper
    {
        Task AddAuditAsync(string message, string initiator, string groupKey = null, DateTime? auditDateTime = null, object additionalAuditData = null);
    }
}
