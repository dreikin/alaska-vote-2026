namespace DataModel;

// NB: This is a utility class, not meant to be persisted.
public class Manifest<T>
{
    public required string Version { get; set; }
    public required List<T> List { get; set; }

    public Manifest<T> ShallowCopy()
    {
        return (Manifest<T>)MemberwiseClone();
    }
}
