namespace SmartHomeMini;

public class SmartDoor : IDevice, ILockable
{
    private readonly string name;

    public SmartDoor(string name)
    {
        this.name = name;
    }

    public void TurnOn()
    {
        Console.WriteLine($"{name}: OPEN");
    }

    public void TurnOff()
    {
        Console.WriteLine($"{name}: CLOSED");
    }

    public void Lock()
    {
        Console.WriteLine($"{name}: LOCKED");
    }

    public void Unlock()
    {
        Console.WriteLine($"{name}: UNLOCKED");
    }
}
