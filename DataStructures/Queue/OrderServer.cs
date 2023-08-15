namespace DataStructures.Queue;

public class OrderServer
{
    private readonly Queue<string> _queue;
    private readonly Action<string> _log;
    private readonly Action _sleep;
    public OrderServer(Queue<string> queue, Action<string> log, Action sleep)
    {
        _queue = queue;
        _log = log;
        _sleep = sleep;
    }

    public Task ServeAsync() => Task.Run(() =>
    {
        _log($"Serving {_queue.Count} Orders");
        _sleep();
        while (_queue.Count > 0)
        {
            _sleep();
            var order = _queue.Dequeue();
            _log($"Serving order: {order}");
        }
    });
}