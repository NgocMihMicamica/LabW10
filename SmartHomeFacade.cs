namespace SmartHomeMini;

// Lop Facade da duoc sua o phien ban v2
public sealed class SmartHomeFacade
{
    private readonly IDevice light;
    private readonly IDevice fan;
    private readonly ILockable door;

    public SmartHomeFacade(IDevice light, IDevice fan, ILockable door)
    {
        this.light = light;
        this.fan = fan;
        this.door = door;
    }

    public void GoToWork()
    {
        light.TurnOff();
        fan.TurnOff();
        door.Lock();
    }

    public void GoToSleep()
    {
        fan.TurnOff();

        // Da sua: da bo sung khoa cua khi di ngu theo dung yeu cau
        door.Lock();

        light.TurnOn();

        // Da sua: lay gia tri NightLightLevel truc tiep tu HomeConfiguration.Instance thay vi fix cung
        int level = HomeConfiguration.Instance.NightLightLevel;
        Console.WriteLine($"Night light level: {level}%");
    }
}
