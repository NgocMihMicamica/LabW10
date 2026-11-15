namespace SmartHomeMini;

// Da sua o v3: 
// 1. Them tu khoa 'sealed' de ngan chan ke thua, tranh viec lop con pha vo co che Singleton.
// 2. Ap dung Lazy<HomeConfiguration> de dam bao thread-safe (an toan luong) va khoi tao luoi (lazy initialization).
// 3. Constructor dat private de client ben ngoai khong the tu tien goi 'new'.
public sealed class HomeConfiguration
{
    // Bien static Lazy khoi tao the hien khi can thiet va dam bao luong an toan mac dinh
    private static readonly Lazy<HomeConfiguration> lazy =
        new(() => new HomeConfiguration());

    // Property Instance tra ve the hien duy nhat thong qua lazy.Value
    public static HomeConfiguration Instance => lazy.Value;

    // Cac thuoc tinh cau hinh dung chung cho toan bo he thong
    public string HomeName { get; set; } = "My Home";
    public int NightLightLevel { get; set; } = 30;

    // Constructor private de khong the new truc tiep tu ben ngoai
    private HomeConfiguration()
    {
    }
}
