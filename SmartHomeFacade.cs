namespace SmartHomeMini;

// Facade cung cap cac thao tac muc cao cho nhieu thiet bi
public class SmartHomeFacade
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
        // Bug 1: Quen khoa cua khi di ngu (door.Lock())
        fan.TurnOff();
        light.TurnOn();

        // Bug 2: Fix cung 30% thay vi doc tu HomeConfiguration.Instance.NightLightLevel
        Console.WriteLine("Night light level: 30%");
        // TODO: can lay muc sang ban dem tu cau hinh chung
    }
}
