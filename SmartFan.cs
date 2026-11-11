namespace SmartHomeMini;

public class SmartFan : IDevice
{
    private readonly string name;

    public SmartFan(string name)
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
