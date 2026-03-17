namespace RentEquipment;

public class Laptop : Equipment
{
    private string RamAmount { get; }
    private string ScreenResolution { get; }

    public Laptop(int uniqueIdent, string name, string brand, string ramAmount, string screenResolution)
        : base(uniqueIdent, name, brand)
    {
        RamAmount = ramAmount;
        ScreenResolution = screenResolution;
    }
}
