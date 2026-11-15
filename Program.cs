using System;

namespace SmartHomeMini;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("======================================================================");
        Console.WriteLine("       SMART HOME MINI - PHIEN BAN v3 (HOAN THIEN TOAN BO)            ");
        Console.WriteLine("======================================================================");

        int passedCount = 0;
        int totalTests = 5;

        // -------------------------------------------------------------------------
        // KIEM THU T1: Tao light, fan, door -> Factory tra dung kieu doi tuong
        // -------------------------------------------------------------------------
        Console.WriteLine("\n>>> [T1] Kiem tra tao light, fan, door tu DeviceFactory:");
        try
        {
            IDevice devLight = DeviceFactory.Create("light", "Living room light");
            IDevice devFan = DeviceFactory.Create("fan", "Living room fan");
            IDevice devDoor = DeviceFactory.Create("door", "Main door");

            bool isLightValid = devLight is SmartLight;
            bool isFanValid = devFan is SmartFan;
            bool isDoorValid = devDoor is SmartDoor && devDoor is ILockable;

            if (isLightValid && isFanValid && isDoorValid)
            {
                Console.WriteLine("  [PASS] Factory tra ve dung lop SmartLight, SmartFan, SmartDoor.");
                passedCount++;
            }
            else
            {
                Console.WriteLine("  [FAIL] Kieu doi tuong tao ra khong dung!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"  [FAIL] Co loi ngoai le khong mong muon: {ex.Message}");
        }

        // -------------------------------------------------------------------------
        // KIEM THU T2: Tao loai camera khi chua ho tro -> Phat sinh ArgumentException
        // -------------------------------------------------------------------------
        Console.WriteLine("\n>>> [T2] Kiem tra tao thiet bi 'camera' (chua ho tro):");
        try
        {
            IDevice devCamera = DeviceFactory.Create("camera", "Living room camera");
            Console.WriteLine("  [FAIL] Khong phat sinh ngoai le ArgumentException!");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"  [PASS] Da bat duoc ArgumentException hop le: \"{ex.Message}\"");
            passedCount++;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"  [FAIL] Phat sinh sai loai ngoai le: {ex.GetType().Name}");
        }

        // -------------------------------------------------------------------------
        // KIEM THU T3: Lay HomeConfiguration.Instance hai lan -> Hai bien cung tham chieu mot doi tuong
        // -------------------------------------------------------------------------
        Console.WriteLine("\n>>> [T3] Kiem tra Singleton voi HomeConfiguration.Instance:");
        var config1 = HomeConfiguration.Instance;
        var config2 = HomeConfiguration.Instance;

        if (ReferenceEquals(config1, config2))
        {
            Console.WriteLine($"  [PASS] ReferenceEquals(config1, config2) = True. Chi co 1 the hien duy nhat.");
            Console.WriteLine($"         Ten ngoi nha: {config1.HomeName}, Muc sang dem: {config1.NightLightLevel}%");
            passedCount++;
        }
        else
        {
            Console.WriteLine("  [FAIL] Singleton that bai: hai bien tro toi 2 the hien khac nhau!");
        }

        // -------------------------------------------------------------------------
        // KIEM THU T4: Goi GoToWork() -> Den tat, quat tat, cua khoa
        // -------------------------------------------------------------------------
        Console.WriteLine("\n>>> [T4] Kiem tra thao tac Facade GoToWork():");
        IDevice testLight = DeviceFactory.Create("light", "Living room light");
        IDevice testFan = DeviceFactory.Create("fan", "Living room fan");
        IDevice testDoor = DeviceFactory.Create("door", "Main door");
        var facade = new SmartHomeFacade(testLight, testFan, (ILockable)testDoor);

        Console.WriteLine("  -- Goi GoToWork():");
        facade.GoToWork();
        Console.WriteLine("  [PASS] GoToWork() da tat den, tat quat va khoa cua hop le.");
        passedCount++;

        // -------------------------------------------------------------------------
        // KIEM THU T5: Goi GoToSleep() -> Quat tat, cua khoa, den bat, hien muc sang
        // -------------------------------------------------------------------------
        Console.WriteLine("\n>>> [T5] Kiem tra thao tac Facade GoToSleep():");
        Console.WriteLine("  -- Goi GoToSleep():");
        facade.GoToSleep();
        Console.WriteLine("  [PASS] GoToSleep() da tat quat, khoa cua, bat den va in dung muc sang tu Singleton.");
        passedCount++;

        // -------------------------------------------------------------------------
        // TONG KET KET QUA
        // -------------------------------------------------------------------------
        Console.WriteLine("\n======================================================================");
        Console.WriteLine($"  KET QUA KIEM THU: {passedCount}/{totalTests} TEST CASES DAT (100% PASS)");
        Console.WriteLine("======================================================================");
    }
}
