namespace SmartHomeMini;

public class SmartLight : IDevice
{
    private readonly string name;

    public SmartLight(string name)
    {
        this.name = name;
    }

    public void TurnOn()
    {
        Console.WriteLine($"{name}: ON");
    }

    public void TurnOff()
    {
        Console.WriteLine($"{name}: OFF");
    }
}
