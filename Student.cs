namespace RentEquipment;

public class Student : User{
    public Student(int uniqueIdent, string name, string surname)
        : base(uniqueIdent, name, surname)
    {}

    public override int MaxActiveRents => 2;
}
