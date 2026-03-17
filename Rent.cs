namespace RentEquipment;

public class Rent {
    public User User { get; }
    public Equipment Equipment { get; }
    public DateTime RentDate { get; }
    public DateTime ReturnDate { get; }
    public DateTime? ActualReturnDate { get; private set; }
    public decimal RentPenalty { get; private set; }
    public bool IsActive => ActualReturnDate == null;

    public Rent(User user, Equipment equipment, DateTime rentDate, DateTime returnDate)
    {
        User = user;
        Equipment = equipment;
        RentDate = rentDate;
        ReturnDate = returnDate;
    }

    public void ReturnEquipment(DateTime actualReturnDate, decimal rentPenalty) {
        ActualReturnDate = actualReturnDate;
        RentPenalty = rentPenalty;
    }
}
