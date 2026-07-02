namespace XPoster.Contracts;
/// <summary>
/// Represents the status of a container in the state store.
/// </summary>
public enum ContainerStatus 
{ 
    /// <summary>
    /// The container is pending and has not yet been published or failed.
    /// </summary>
    Pending, 
    /// <summary>
    /// The container has been successfully published.
    /// </summary>
    Published, 
    /// <summary>
    /// The container has failed processing.
    /// </summary>
    Failed 
}