namespace RentEquipment;

public abstract class User
{
    public int UniqueIdent { get; }
    public string Name { get; }
    public string Surname { get; }

    protected User(int uniqueIdent, string name, string surname) {
        UniqueIdent = uniqueIdent;
        Name = name;
        Surname = surname;
    }
    
    public abstract int MaxActiveRents { get; }
    public abstract string UserType { get; }

    public override string ToString(){
        return $"{UniqueIdent}: {Name} {Surname}";
    }
}
