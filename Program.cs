using System;

namespace SmartHomeMini;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("==================================================");
        Console.WriteLine("  SMART HOME MINI - PHIEN BAN v1 (DRAFT / BUGGY) ");
        Console.WriteLine("==================================================");

        // 1. Thu tao thiet bi qua Factory
        Console.WriteLine("\n[1] Thu tao thiet bi qua Factory:");
        IDevice light = DeviceFactory.Create("light", "Living room light");
        IDevice fan = DeviceFactory.Create("fan", "Living room fan");
        IDevice door = DeviceFactory.Create("door", "Main door");

        light.TurnOn();
        fan.TurnOff();
        if (door is ILockable lockableDoor)
        {
            lockableDoor.Lock();
        }

        // 2. Thu tao loai thiet bi khong hop le (camera)
        Console.WriteLine("\n[2] Thu tao camera (chua ho tro):");
        IDevice camera = DeviceFactory.Create("camera", "Living room camera");
        if (camera == null)
        {
            Console.WriteLine("Ket qua: camera tra ve null (Bug: le ra phai nem ArgumentException theo de bai)");
        }

        // 3. Thu kich hoat cac che do qua Facade
        Console.WriteLine("\n[3] Kich hoat che do GoToWork qua Facade:");
        var facade = new SmartHomeFacade(light, fan, (ILockable)door);
        facade.GoToWork();

        Console.WriteLine("\n[4] Kich hoat che do GoToSleep qua Facade:");
        facade.GoToSleep();
        Console.WriteLine("(Bug: GoToSleep quen khoa cua va muc sang dang bi fix cung 30%)");

        // 4. Test Singleton
        Console.WriteLine("\n[5] Kiem tra Singleton:");
        var c1 = HomeConfiguration.Instance;
        var c2 = HomeConfiguration.Instance;
        Console.WriteLine($"c1 giong c2: {ReferenceEquals(c1, c2)}");

        // Constructor van de public nen ngoai van new duoc
        var c3 = new HomeConfiguration();
        Console.WriteLine($"c3 (new truc tiep) giong c1: {ReferenceEquals(c1, c3)} (Bug: mat tinh doc quyen Singleton)");
    }
}
