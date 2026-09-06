using XPoster.Workflows.Models;

namespace XPoster.Tests.Workflows.Models;

public class WorkflowContextTests
{
    [Fact]
    public void SlotKey_IsSetCorrectly()
    {
        var ctx = new WorkflowContext { SlotKey = "TestSlot" };
        Assert.Equal("TestSlot", ctx.SlotKey);
    }

    [Fact]
    public void SetData_AndGetData_RoundTrip()
    {
        var ctx = new WorkflowContext { SlotKey = "S" };
        ctx.SetData("key1", "hello");
        Assert.Equal("hello", ctx.GetData<string>("key1"));
    }

    [Fact]
    public void GetData_ThrowsOnMissingKey()
    {
        var ctx = new WorkflowContext { SlotKey = "S" };
        Assert.Throws<KeyNotFoundException>(() => ctx.GetData<string>("missing"));
    }

    [Fact]
    public void GetData_ThrowsOnTypeMismatch()
    {
        var ctx = new WorkflowContext { SlotKey = "S" };
        ctx.SetData("key1", 42);
        Assert.Throws<KeyNotFoundException>(() => ctx.GetData<string>("key1"));
    }

    [Fact]
    public void TryGetData_ReturnsTrue_WhenKeyExists()
    {
        var ctx = new WorkflowContext { SlotKey = "S" };
        ctx.SetData("k", 123);
        Assert.True(ctx.TryGetData<int>("k", out var val));
        Assert.Equal(123, val);
    }

    [Fact]
    public void TryGetData_ReturnsFalse_WhenKeyMissing()
    {
        var ctx = new WorkflowContext { SlotKey = "S" };
        Assert.False(ctx.TryGetData<int>("nope", out var val));
        Assert.Equal(0, val);
    }

    [Fact]
    public void TryGetData_ReturnsFalse_OnTypeMismatch()
    {
        var ctx = new WorkflowContext { SlotKey = "S" };
        ctx.SetData("k", "text");
        Assert.False(ctx.TryGetData<int>("k", out _));
    }

    [Fact]
    public void HasData_ReturnsTrue_WhenKeyExists()
    {
        var ctx = new WorkflowContext { SlotKey = "S" };
        ctx.SetData("x", 1);
        Assert.True(ctx.HasData("x"));
    }

    [Fact]
    public void HasData_ReturnsFalse_WhenKeyMissing()
    {
        var ctx = new WorkflowContext { SlotKey = "S" };
        Assert.False(ctx.HasData("x"));
    }

    [Fact]
    public void SetData_OverwritesExistingValue()
    {
        var ctx = new WorkflowContext { SlotKey = "S" };
        ctx.SetData("k", "first");
        ctx.SetData("k", "second");
        Assert.Equal("second", ctx.GetData<string>("k"));
    }

    [Fact]
    public void ConcurrentSetData_DoesNotThrow()
    {
        var ctx = new WorkflowContext { SlotKey = "S" };
        var exceptions = new List<Exception>();

        Parallel.For(0, 1000, i =>
        {
            try
            {
                ctx.SetData($"key-{i}", i);
            }
            catch (Exception ex)
            {
                lock (exceptions) exceptions.Add(ex);
            }
        });

        Assert.Empty(exceptions);
        Assert.Equal(1000, ctx.GetData<int>("key-999") + 1);
    }

    [Fact]
    public void ConcurrentReadWrite_DoesNotThrow()
    {
        var ctx = new WorkflowContext { SlotKey = "S" };
        ctx.SetData("shared", 0);
        var exceptions = new List<Exception>();

        Parallel.For(0, 500, i =>
        {
            try
            {
                ctx.SetData("shared", i);
                _ = ctx.TryGetData<int>("shared", out _);
            }
            catch (Exception ex)
            {
                lock (exceptions) exceptions.Add(ex);
            }
        });

        Assert.Empty(exceptions);
    }
}
