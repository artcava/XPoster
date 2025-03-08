namespace XPoster.MessageAbstraction;

public interface IGeneration
{
    public string GenerateMessage();
    public bool SendIt { get; }
    public string Name { get; }
}
