using DataStructures.Queue;
using Xunit.Abstractions;

namespace Tests.Queue;

public class OrderProcessingTest
{
    private readonly ITestOutputHelper _output;

    public OrderProcessingTest(ITestOutputHelper output) => 
        _output = output;

    [Fact]
    public async Task Test()
    {
        var queue = new Queue<string>();
        var placer = new OrderPlacer(queue, _output.WriteLine, 
            () => { Thread.Sleep(1);});
        var orderPlacingTask = placer.PlaceOrdersAsync(new[]
        {
            "Pizza", 
            "Samosa", 
            "Pasta", 
            "Biryani", 
            "Burger"
        });
        
        var server = new OrderServer(queue, _output.WriteLine, 
            () => { Thread.Sleep(2); });
        var orderServingTask = server.ServeAsync();
        
        await orderPlacingTask;
        await orderServingTask;
        
        Assert.Empty(queue);
    }
}