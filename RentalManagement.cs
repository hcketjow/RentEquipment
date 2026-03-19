namespace RentEquipment;

public class RentalManagement
{
    private List<User> _users = new();
    private List<Equipment> _equipment = new();
    private List<Rent> _rents = new();

    private int _nextUserId = 1;
    private int _nextEquipmentId = 1;

    public int GenerateUserId() => _nextUserId++;
    public int GenerateEquipmentId() => _nextEquipmentId++;

    public void AddUser(User user) => _users.Add(user);
    public void AddEquipment(Equipment equipment) => _equipment.Add(equipment);
    public List<Equipment> GetEquipment() => _equipment;
    public List<Equipment> GetAvailableEquipment() => _equipment.Where(e => e.Status == EquipmentStatus.Available).ToList();

    public void BorrowEquipment(int userId, int equipmentId, int days)
    {
        var user = _users.FirstOrDefault(u => u.UniqueIdent == userId);
        var equipment = _equipment.FirstOrDefault(e => e.UniqueIdent == equipmentId);
        if (user == null || equipment == null)
            throw new Exception("Nie znaleziono użytkownika lub sprzętu.");
        if (equipment.Status != EquipmentStatus.Available)
            throw new Exception("Sprzęt jest niedostępny.");
        int activeUserRents = _rents.Count(r => r.User.UniqueIdent == userId && r.IsActive);
        if (activeUserRents >= user.MaxActiveRents)
            throw new Exception("Użytkownik przekroczył limit wypożyczeń.");
        equipment.MarkAsRented();
        var rent = new Rent(user, equipment, DateTime.Now, DateTime.Now.AddDays(days));
        _rents.Add(rent);
    }

    public decimal ReturnEqupment(User user, Equipment equipment){
        return 20;
    }

    public void QuickReportStatement(User user) {
        Console.Write("Equipment for user: " + user.Name + ", are: " + GetAvailableEquipment());
    }
}
