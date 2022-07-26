namespace SampleEFCorePlus.Models;

public class Bar {
    public int Id { get; set; }
    public FooBar FooBar { get; set; } = null!;
}