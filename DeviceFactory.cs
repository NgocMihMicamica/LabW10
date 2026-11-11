namespace SmartHomeMini;

// Lop Factory de tao thiet bi theo ten loai
public static class DeviceFactory
{
    public static IDevice Create(string type, string name)
    {
        // Bug 1: So sanh chuoi truc tiep, khong Trim va khong ToLowerInvariant
        // Neu truyen "Light", "FAN" hoac co khoang trang se khong khop
        if (type == "light")
        {
            return new SmartLight(name);
        }
        else if (type == "fan")
        {
            return new SmartFan(name);
        }
        else if (type == "door")
        {
            return new SmartDoor(name);
        }

        // Bug 2: Tra ve null thay vi phat sinh ArgumentException theo de bai
        // TODO: can kiem tra lai xem co can ArgumentException khong
        return null!;
    }
}
