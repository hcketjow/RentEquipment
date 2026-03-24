namespace RentEquipment;

public class Rent {
    public User User { get; }
    public Equipment Equipment { get; }
    public DateTime RentDate { get; }
    public DateTime PlannedReturnDate { get; }
    public DateTime? ActualReturnDate { get; private set; }
    public decimal RentPenalty { get; private set; }
    public bool IsActive => ActualReturnDate == null;
    public bool WasReturnedOnTime => ActualReturnDate.HasValue && ActualReturnDate.Value.Date <= PlannedReturnDate.Date;

    public Rent(User user, Equipment equipment, DateTime rentDate, DateTime plannedReturnDate)
    {
        User = user;
        Equipment = equipment;
        RentDate = rentDate;
        PlannedReturnDate = plannedReturnDate;
    }

    public void ReturnEquipment(DateTime actualReturnDate, decimal rentPenalty){
        if (ActualReturnDate != null)
            throw new InvalidOperationException("Sprzęt został już zwrócony.");
        ActualReturnDate = actualReturnDate;
        RentPenalty = rentPenalty;
    }

    public override string ToString(){
        string returnInfo = ActualReturnDate.HasValue ? $"zwrócono: {ActualReturnDate:yyyy-MM-dd}" : "nie zwrócono";
        return $"{User.Name} {User.Surname} -> {Equipment.Name}, od {RentDate:yyyy-MM-dd} do {PlannedReturnDate:yyyy-MM-dd}, {returnInfo}, kara: {RentPenalty}";
    }
}
