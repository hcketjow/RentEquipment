namespace RentEquipment;

public abstract class User
{
    private int UniqueIdent { get; }
    private string Name { get; }
    private string Surname { get; }

    protected User(int uniqueIdent, string name, string surname) {
        UniqueIdent = uniqueIdent;
        Name = name;
        Surname = surname;
    }
    
    public abstract int MaxActiveRents { get; }
}
