namespace XPoster.Abstraction;
public class Message
{
    internal string Firm => "\n\n#XPoster #AI";
    public string Content { get; set; }
    public byte[] Image { get; set; }
}
