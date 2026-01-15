using System.Threading;
using System.Threading.Tasks;

namespace IncStores.TaskManager.TaskServices
{
    public interface ITaskManagerService
    {
        Task StartServiceAsync(CancellationToken stoppingToken);
        Task StopServiceAsync(CancellationToken stoppingToken);
    }
}
