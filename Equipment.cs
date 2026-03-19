namespace RentEquipment;

public abstract class Equipment {
    public int UniqueIdent { get; }
    public string Name { get; }
    public EquipmentStatus Status { get; private set; }
    public string Brand { get; }

    protected Equipment(int uniqueIdent, string name, string brand)
    {
        UniqueIdent = uniqueIdent;
        Name = name;
        Brand = brand;
        Status = EquipmentStatus.Available;
    }

    public void MarkAsRented() => Status = EquipmentStatus.Rented;
    public void MarkAsAvailable() => Status = EquipmentStatus.Available;
    public void MarkAsUnavaliable() => Status = EquipmentStatus.Unavailable;

    public override string ToString(){
        return $"{UniqueIdent}: {Name} ({Brand}) [{Status}]";
    }
}
