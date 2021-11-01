using System.Threading.Tasks;

namespace queue.connector.Interfaces
{
    public interface IMessageConnector<T>
    {
        Task AddMessageAsync(T qmessage);
    }
}
