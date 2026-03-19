namespace RentEquipment;

public class Laptop : Equipment
{
    public string RamAmount { get; }
    public string ScreenResolution { get; }

    public Laptop(int uniqueIdent, string name, string brand, string ramAmount, string screenResolution)
        : base(uniqueIdent, name, brand)
    {
        RamAmount = ramAmount;
        ScreenResolution = screenResolution;
    }

    public override string ToString(){
        return base.ToString() + $" RAM: {RamAmount}, Resolution: {ScreenResolution}";
    }
}
