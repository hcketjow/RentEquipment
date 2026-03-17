namespace RentEquipment;

public abstract class Equipment {
    private int UniqueIdent { get; }
    private string Name { get; }
    public EquipmentStatus Status { get; private set; }
    public string Brand { get; }

    protected Equipment(int uniqueIdent, string name, string brand)
    {
        UniqueIdent = uniqueIdent;
        Name = name;
        Brand = brand;
    }

    public void MarkAsRented() => Status = EquipmentStatus.Rented;
    public void MarkAsAvailable() => Status = EquipmentStatus.Available;
    public void MarkAsUnavaliable() => Status = EquipmentStatus.Unavailable;
}
