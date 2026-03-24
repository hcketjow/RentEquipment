namespace RentEquipment;

public class Employee : User
{
    public Employee(int uniqueIdent, string name, string surname)
        : base(uniqueIdent, name, surname)
    {}

    public override int MaxActiveRents => 5;
    public override string UserType => "Employee";
}
