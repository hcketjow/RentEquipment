namespace RentEquipment;

public class Rent {
    private DateTime RentDate;
    private DateTime ReturnDate;
    private DateTime ActualReturnDate;
    private double RentPrice;
    private double RentPenalty;

    public Rent(
        DateTime rentDate, 
        DateTime returnDate,
        DateTime actualReturnDate,
        double rentPrice, 
        double rentPenalty
    ) {
        RentDate = rentDate;
        ReturnDate = returnDate;
        ActualReturnDate = actualReturnDate;
        RentPrice = rentPrice;
        RentPenalty = rentPenalty;
    }
}
