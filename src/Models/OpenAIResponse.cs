namespace XPoster.Models;

// Handle OpenAI response to deserialize  
public class OpenAIResponse
{
    public required Choice[] choices { get; set; }
}

public class Choice
{
    public required Message message { get; set; }
}

public class Message
{
    public required string content { get; set; }
}

public class OpenAIImageResponse
{
    public required List<ImageData> data { get; set; }
}

public class ImageData
{
    public required string url { get; set; }
}

