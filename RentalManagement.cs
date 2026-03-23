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

    public decimal ReturnEqupment(int EquipmentId, DateTime ActualReturnDate){
        var rent =  _rents.FirstOrDefault(r => r.User.UniqueIdent == EquipmentId && r.IsActive);
        if (rent == null)
            throw new Exception("Nie znaleziono aktywnego wypożyczenia dla tego sprzętu.");
        decimal penalty = CalculatePenalty(rent.PlannedReturnDate, ActualReturnDate);
        rent.ReturnEquipment(ActualReturnDate, penalty);
        rent.Equipment.MarkAsAvailable();
        return penalty;
    }

    public void MarkEquipmentAsUnavailable(int equipmentId){
        var equipment = _equipment.FirstOrDefault(e => e.UniqueIdent == equipmentId);
        if (equipment == null)
            throw new Exception("Nie znaleziono sprzętu");
        if(equipment.Status == EquipmentStatus.Rented)
            throw new Exception("Nie można oznaczyć wypożyczonego sprzętu jako niedostępnego.");
        equipment.MarkAsAvailable();
    }

    public List<Rent> GetActiveRentsForUser(int userId){
        return _rents.Where(r => r.User.UniqueIdent == userId && r.IsActive).ToList();
    }

    public List<Rent> GetOverdueRents(){
        return _rents.Where(r => r.IsActive && r.PlannedReturnDate.Date < DateTime.Now.Date).ToList();
    }

    public string GenerateReport(){
        return $"Raport systemu:\n" + $"Użytkownicy: {_users.Count}\n" + $"Sprzęt razem: {_equipment.Count}\n" +
               $"Dostępny: {_equipment.Count(e => e.Status == EquipmentStatus.Available)}\n" +
               $"Wypożyczony: {_equipment.Count(e => e.Status == EquipmentStatus.Rented)}\n" +
               $"Niedostępny: {_equipment.Count(e => e.Status == EquipmentStatus.Unavailable)}\n" +
               $"Aktywne wypożyczenia: {_rents.Count(r => r.IsActive)}\n" + $"Przeterminowane: {GetOverdueRents().Count}";
    }
    
    private decimal CalculatePenalty(DateTime plannedReturnDate, DateTime actualReturnDate){
        int lateDays = (actualReturnDate.Date - plannedReturnDate.Date).Days;
        if (lateDays <= 0)
            return 0;
        return lateDays * 10;
    }
}
