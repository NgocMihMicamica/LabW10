using System;

namespace SmartHomeMini;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("==================================================");
        Console.WriteLine("  SMART HOME MINI - PHIEN BAN v2 (FIXED 1 PHAN)   ");
        Console.WriteLine("==================================================");

        // 1. Test Factory da sua: ho tro chu hoa thuong va khoang trang
        Console.WriteLine("\n[1] Test Factory (thu voi chu hoa va khoang trang):");
        IDevice light = DeviceFactory.Create("  Light  ", "Living room light");
        IDevice fan = DeviceFactory.Create("FAN", "Living room fan");
        IDevice door = DeviceFactory.Create("door", "Main door");

        light.TurnOn();
        fan.TurnOff();
        if (door is ILockable lockableDoor)
        {
            lockableDoor.Lock();
        }

        // 2. Test Factory voi loai khong hop le (kiem tra xem da nem ArgumentException chua)
        Console.WriteLine("\n[2] Test ngoai le khi tao thiet bi 'camera':");
        try
        {
            IDevice camera = DeviceFactory.Create("camera", "Security Camera");
            Console.WriteLine("Loi: le ra phai nem ArgumentException!");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"[THANH CONG] Da bat duoc ArgumentException: {ex.Message}");
        }

        // 3. Test Facade GoToWork va GoToSleep da sua
        Console.WriteLine("\n[3] Test Facade: GoToWork");
        var facade = new SmartHomeFacade(light, fan, (ILockable)door);
        facade.GoToWork();

        Console.WriteLine("\n[4] Test Facade: GoToSleep (da them khoa cua va doc NightLightLevel tu config)");
        facade.GoToSleep();

        // 4. Singleton (van con sot loi chua sua o file HomeConfiguration.cs!)
        Console.WriteLine("\n[5] Kiem tra Singleton (chua sua HomeConfiguration):");
        var c1 = HomeConfiguration.Instance;
        var c2 = HomeConfiguration.Instance;
        Console.WriteLine($"c1 giong c2: {ReferenceEquals(c1, c2)}");
        Console.WriteLine("WARNING: HomeConfiguration van de constructor public va chua dung Lazy<T> theo de bai!");
    }
}
