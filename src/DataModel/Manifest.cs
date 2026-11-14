namespace DataModel;

public class Manifest<T>
{
    public required string Version { get; set; }
    public required List<T> List { get; set; }
}
