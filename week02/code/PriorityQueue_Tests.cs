using Microsoft.VisualStudio.TestTools.UnitTesting;
// Additional tests written 
[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add items with different priorities.
    // Expected Result: The item with the highest priority is returned.
    // Defect(s) Found: The queue failed to always return the highest priority item.
    public void TestPriorityQueue_HighestPriority()
    {
        var queue = new PriorityQueue();

        queue.Enqueue("A", 1);
        queue.Enqueue("B", 5);
        queue.Enqueue("C", 3);

        Assert.AreEqual("B", queue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add multiple items with the same highest priority.
    // Expected Result: Items with the same priority are removed using FIFO order.
    // Defect(s) Found: The queue returned the last matching item instead of the first.
    public void TestPriorityQueue_FIFOWithSamePriority()
    {
        var queue = new PriorityQueue();

        queue.Enqueue("A", 5);
        queue.Enqueue("B", 5);
        queue.Enqueue("C", 5);

        Assert.AreEqual("A", queue.Dequeue());
        Assert.AreEqual("B", queue.Dequeue());
        Assert.AreEqual("C", queue.Dequeue());
    }

    [TestMethod]
    // Scenario: Highest-priority item is the last item added.
    // Expected Result: The last item should be selected if it has the highest priority.
    // Defect(s) Found: The last element in the queue was not checked.
    public void TestPriorityQueue_LastItemHighestPriority()
    {
        var queue = new PriorityQueue();

        queue.Enqueue("A", 1);
        queue.Enqueue("B", 2);
        queue.Enqueue("C", 10);

        Assert.AreEqual("C", queue.Dequeue());
    }

    [TestMethod]
    // Scenario: Remove an item and verify it is actually removed.
    // Expected Result: After removing the only item, the queue should be empty.
    // Defect(s) Found: Dequeue returned the item but did not remove it from the queue.
    public void TestPriorityQueue_ItemRemoved()
    {
        var queue = new PriorityQueue();

        queue.Enqueue("A", 1);

        Assert.AreEqual("A", queue.Dequeue());

        Assert.ThrowsException<InvalidOperationException>(
            () => queue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: InvalidOperationException should be thrown with the correct message.
    // Defect(s) Found: None after fix.
    public void TestPriorityQueue_EmptyQueue()
    {
        var queue = new PriorityQueue();

        try
        {
            queue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception ex)
        {
            Assert.Fail(
                string.Format(
                    "Unexpected exception of type {0} caught: {1}",
                    ex.GetType(),
                    ex.Message));
        }
    }
}