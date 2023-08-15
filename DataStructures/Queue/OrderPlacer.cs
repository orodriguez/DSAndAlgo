using System.Net.Security;

namespace DataStructures.Queue;

public class OrderPlacer
{
    private readonly Action<string> _log;
    private readonly Queue<string> _queue;
    private readonly Action _sleep;

    public OrderPlacer(Queue<string> queue, Action<string> log, Action sleep)
    {
        _queue = queue;
        _log = log;
        _sleep = sleep;
    }

    public Task PlaceOrdersAsync(IEnumerable<string> orders) => Task.Run(() =>
    {
        _log("Placing order");
        foreach (var order in orders)
        {
            _sleep();
            _log($"Placing order: {order}");
            _queue.Enqueue(order);
        }
    });
}