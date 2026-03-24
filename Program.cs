namespace RentEquipment;

public class Program {
    public static void Main() {
        var rentalManagement = new RentalManagement();
        var student = new Student(rentalManagement.GenerateUserId(), "Anna", "Nowak");
        var employee = new Employee(rentalManagement.GenerateUserId(), "Jan", "Kowalski");
        rentalManagement.AddUser(student);
        rentalManagement.AddUser(employee);
        var laptop1 = new Laptop(rentalManagement.GenerateEquipmentId(),"Dell Latitude",
            "Dell", "16 GB","1920x1080");

        var laptop2 = new Laptop(rentalManagement.GenerateEquipmentId(),"Lenovo ThinkPad","Lenovo",
            "8 GB", "1920x1080");

        var camera = new Camera(rentalManagement.GenerateEquipmentId(),
            "Canon EOS R10", "Canon", "Zoom", "RF");

        var projector = new Projector( rentalManagement.GenerateEquipmentId(), "Epson EB-X49",
            "Epson", "3LCD", "Lamp");
        rentalManagement.AddEquipment(laptop1);
        rentalManagement.AddEquipment(laptop2);
        rentalManagement.AddEquipment(camera);
        rentalManagement.AddEquipment(projector);

        Console.WriteLine("Sprzęty: ");
        foreach (var equipment in rentalManagement.GetEquipment())
            Console.WriteLine(equipment);

        Console.WriteLine("\n Dostępny sprzęt: ");
        foreach (var equipment in rentalManagement.GetAvailableEquipment())
            Console.WriteLine(equipment);

        Console.WriteLine("\n Wypożyczenie: ");
        rentalManagement.BorrowEquipment(student.UniqueIdent, laptop1.UniqueIdent, 7);
        Console.WriteLine($"{student.Name} wypożyczył {laptop1.Name}");

        Console.WriteLine("\n Wypożyczanie niedostępnego sprzętu: ");
        try{
            rentalManagement.BorrowEquipment(employee.UniqueIdent, laptop1.UniqueIdent, 5);
        }catch (Exception ex) {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("\n Przekroczenie limitu studenta: ");
        try {
            rentalManagement.BorrowEquipment(student.UniqueIdent, camera.UniqueIdent, 3);
            Console.WriteLine($"{student.Name} wypożyczył {camera.Name}");
            rentalManagement.BorrowEquipment(student.UniqueIdent, projector.UniqueIdent, 2);
            Console.WriteLine($"{student.Name} wypożyczył {projector.Name}");
            rentalManagement.BorrowEquipment(student.UniqueIdent, laptop2.UniqueIdent, 1);
            Console.WriteLine($"{student.Name} wypożyczył {laptop2.Name}");
        } catch (Exception ex){
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("\n Wypożyczenia sprzętu dla studenta: ");
        foreach (var rent in rentalManagement.GetActiveRentsForUser(student.UniqueIdent))
            Console.WriteLine(rent);
        Console.WriteLine("\n Zwrot w terminie: ");
        decimal penalty1 = rentalManagement.ReturnEquipment(laptop1.UniqueIdent, DateTime.Now.AddDays(6));
        Console.WriteLine($"Zwrot sprzętu: {laptop1.Name}, kara: {penalty1} zł");

        Console.WriteLine("\n Wypożyczenie i zwrot po terminie: ");
        rentalManagement.BorrowEquipment(employee.UniqueIdent, laptop2.UniqueIdent, 2);
        Console.WriteLine($"{employee.Name} wypożyczył {laptop2.Name}");

        decimal penalty2 = rentalManagement.ReturnEquipment(laptop2.UniqueIdent, DateTime.Now.AddDays(5));
        Console.WriteLine($"Zwrot sprzętu: {laptop2.Name}, kara: {penalty2} zł");

        Console.WriteLine("\n Oznaczenie sprzętu jako niedostępnego: ");
        try {
            rentalManagement.MarkEquipmentAsUnavailable(projector.UniqueIdent);
            Console.WriteLine($"{projector.Name} oznaczono jako niedostępny.");
        }
        catch (Exception ex) {
            Console.WriteLine($"Błąd: {ex.Message}");
        }

        Console.WriteLine("\n Zaległe wypożyczenia");
        foreach (var rent in rentalManagement.GetOverdueRents())
            Console.WriteLine(rent);

        Console.WriteLine("\n Podsumowanie: ");
        Console.WriteLine(rentalManagement.GenerateReport());
    }
}
