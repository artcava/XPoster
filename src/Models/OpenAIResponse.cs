using System.Collections.Generic;

namespace XPoster.Models;

// Handle OpenAI response to deserialize  
public class OpenAIResponse
{
    public Choice[] choices { get; set; }
}

public class Choice
{
    public Message message { get; set; }
}

public class Message
{
    public string content { get; set; }
}

public class OpenAIImageResponse
{
    public List<ImageData> data { get; set; }
}

public class ImageData
{
    public string url { get; set; }
}

