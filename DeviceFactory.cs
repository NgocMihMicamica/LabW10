namespace SmartHomeMini;

// Lop Factory da duoc sua o phien ban v2
public static class DeviceFactory
{
    public static IDevice Create(string type, string name)
    {
        // Da sua: kiem tra null hoac khoang trang de tranh loi
        if (string.IsNullOrWhiteSpace(type))
        {
            throw new ArgumentException("Loai thiet bi khong duoc de trong!");
        }

        // Da sua: dung Trim() va ToLowerInvariant() de khong phan biet hoa thuong va bo khoang trang thua
        // Chuyen sang dung switch expression ngan gon theo C#
        return type.Trim().ToLowerInvariant() switch
        {
            "light" => new SmartLight(name),
            "fan" => new SmartFan(name),
            "door" => new SmartDoor(name),
            // Da sua: khong return null nua ma nem ArgumentException dung theo de bai
            _ => throw new ArgumentException($"Unsupported device type: {type}")
        };
    }
}
