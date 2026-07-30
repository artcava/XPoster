using XPoster.Models;
using XPoster.Services;

namespace XPoster.Tests.Services;

/// <summary>
/// Unit tests for <see cref="AiServiceHelper.BuildChatPayload"/>.
/// Verifies prompt interpolation, label substitution, and payload field forwarding.
/// </summary>
public class AiServiceHelperChatPayloadTests
{
    // -------------------------------------------------------------------------
    // Helpers
    // -------------------------------------------------------------------------

    private static PromptRequest BuildRequest(
        string systemTemplate,
        string userTemplate,
        string? inputTextLabel = null,
        int maxOutputLength = 100,
        int maxTokenBudget = 500,
        double temperature = 0.7)
    {
        return new PromptRequest
        {
            SystemPromptTemplate = systemTemplate,
            UserPromptTemplate = userTemplate,
            InputTextLabel = inputTextLabel,
            MaxOutputLength = maxOutputLength,
            MaxTokenBudget = maxTokenBudget,
            Temperature = temperature,
            InputText = string.Empty
        };
    }

    private static string GetRole(object message)
    {
        var prop = message.GetType().GetProperty("role")!;
        return (string)prop.GetValue(message)!;
    }

    private static string GetContent(object message)
    {
        var prop = message.GetType().GetProperty("content")!;
        return (string)prop.GetValue(message)!;
    }

    private static T GetField<T>(object obj, string name)
    {
        var prop = obj.GetType().GetProperty(name)!;
        return (T)prop.GetValue(obj)!;
    }

    // -------------------------------------------------------------------------
    // model forwarding
    // -------------------------------------------------------------------------

    [Fact]
    public void BuildChatPayload_ForwardsModelName()
    {
        var request = BuildRequest("System", "User {Text}");

        var payload = AiServiceHelper.BuildChatPayload("hello", request, "test-model");

        Assert.Equal("test-model", GetField<string>(payload, "model"));
    }

    // -------------------------------------------------------------------------
    // max_tokens and temperature forwarding
    // -------------------------------------------------------------------------

    [Fact]
    public void BuildChatPayload_ForwardsMaxTokenBudget()
    {
        var request = BuildRequest("System", "User {Text}", maxTokenBudget: 1024);

        var payload = AiServiceHelper.BuildChatPayload("hello", request, "m");

        Assert.Equal(1024, GetField<int>(payload, "max_tokens"));
    }

    [Fact]
    public void BuildChatPayload_ForwardsTemperature()
    {
        var request = BuildRequest("System", "User {Text}", temperature: 0.3);

        var payload = AiServiceHelper.BuildChatPayload("hello", request, "m");

        Assert.Equal(0.3, GetField<double>(payload, "temperature"));
    }

    // -------------------------------------------------------------------------
    // System message — {MaxChars} interpolation
    // -------------------------------------------------------------------------

    [Fact]
    public void BuildChatPayload_InterpolatesMaxCharsInSystemMessage()
    {
        var request = BuildRequest("Keep under {MaxChars} chars.", "User {Text}", maxOutputLength: 280);

        var payload = AiServiceHelper.BuildChatPayload("hello", request, "m");
        var messages = GetField<object[]>(payload, "messages");

        Assert.Equal("system", GetRole(messages[0]));
        Assert.Equal("Keep under 280 chars.", GetContent(messages[0]));
    }

    [Fact]
    public void BuildChatPayload_SystemMessage_NoPlaceholder_IsUnchanged()
    {
        var request = BuildRequest("Plain system prompt.", "User {Text}");

        var payload = AiServiceHelper.BuildChatPayload("hello", request, "m");
        var messages = GetField<object[]>(payload, "messages");

        Assert.Equal("Plain system prompt.", GetContent(messages[0]));
    }

    // -------------------------------------------------------------------------
    // User message — custom label and {Text} fallback
    // -------------------------------------------------------------------------

    [Fact]
    public void BuildChatPayload_SubstitutesCustomLabelInUserMessage()
    {
        var request = BuildRequest("System", "Summarise: {Body}", inputTextLabel: "{Body}");

        var payload = AiServiceHelper.BuildChatPayload("some article", request, "m");
        var messages = GetField<object[]>(payload, "messages");

        Assert.Equal("user", GetRole(messages[1]));
        Assert.Equal("Summarise: some article", GetContent(messages[1]));
    }

    [Fact]
    public void BuildChatPayload_WhenInputTextLabelIsNull_FallsBackToTextPlaceholder()
    {
        var request = BuildRequest("System", "Rewrite: {Text}", inputTextLabel: null);

        var payload = AiServiceHelper.BuildChatPayload("original", request, "m");
        var messages = GetField<object[]>(payload, "messages");

        Assert.Equal("user", GetRole(messages[1]));
        Assert.Equal("Rewrite: original", GetContent(messages[1]));
    }

    // -------------------------------------------------------------------------
    // messages array shape
    // -------------------------------------------------------------------------

    [Fact]
    public void BuildChatPayload_MessagesContainsTwoEntries()
    {
        var request = BuildRequest("System", "User {Text}");

        var payload = AiServiceHelper.BuildChatPayload("hello", request, "m");
        var messages = GetField<object[]>(payload, "messages");

        Assert.Equal(2, messages.Length);
    }

    [Fact]
    public void BuildChatPayload_FirstMessageRoleIsSystem()
    {
        var request = BuildRequest("System", "User {Text}");

        var payload = AiServiceHelper.BuildChatPayload("hello", request, "m");
        var messages = GetField<object[]>(payload, "messages");

        Assert.Equal("system", GetRole(messages[0]));
    }

    [Fact]
    public void BuildChatPayload_SecondMessageRoleIsUser()
    {
        var request = BuildRequest("System", "User {Text}");

        var payload = AiServiceHelper.BuildChatPayload("hello", request, "m");
        var messages = GetField<object[]>(payload, "messages");

        Assert.Equal("user", GetRole(messages[1]));
    }
}
