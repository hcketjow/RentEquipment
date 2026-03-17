namespace RentEquipment;

public class User
{
    private int UniqueIdent;
    private string Name;
    private string Surname;
    private enum UserType;

    public User(int uniqueIdent, string name, string surname) {
        UniqueIdent = uniqueIdent;
        Name = name;
        Surname = surname;
    }
}
