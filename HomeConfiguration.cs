namespace SmartHomeMini;

// Cau hinh chung cho ngoi nha
// Bug 1: Quen tu khoa sealed
// Bug 2: Constructor van de public (ben ngoai van tu new duoc)
public class HomeConfiguration
{
    // Bug 3: Singleton kieu co dien, chua Thread-Safe va chua dung Lazy<T> nhu de yeu cau
    private static HomeConfiguration? instance;

    public static HomeConfiguration Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new HomeConfiguration();
            }
            return instance;
        }
    }

    public string HomeName { get; set; } = "My Home";
    public int NightLightLevel { get; set; } = 30;

    // TODO: Constructor nen de private khong? De public tam de test
    public HomeConfiguration()
    {
    }
}
