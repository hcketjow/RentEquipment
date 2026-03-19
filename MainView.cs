namespace RentEquipment;

public class MainView {
    public static void Main()
    {
        Console.Write("Insert the unique equipment for the user: ");
        int uniqueIdent = Convert.ToInt32(Console.ReadLine());
        Console.Write("Set the name for the equipment: ");
        string name = Console.ReadLine();
        Console.Write("Set the brand for the equipment: ");
        string brand = Console.ReadLine();
        Console.Write("Set the cameraLensSystem for the equipment: ");
        string cameraLensSystem = Console.ReadLine();
        Console.Write("Set the cameraLensType for the equipment: ");
        string cameraLensType = Console.ReadLine();
        Equipment camera = new Camera(uniqueIdent, name, brand, cameraLensSystem, cameraLensType);
        Equipment laptop = new Laptop(uniqueIdent, name, brand, ramAmount: "Test", screenResolution: "200");
        Equipment projector = new Projector(uniqueIdent, name, brand, matrixType: "ULTEGRA", led: "none");
        camera.MarkAsAvailable();
        laptop.MarkAsAvailable();
        projector.MarkAsAvailable();
        Console.Write("Avaliable equipment: ");
        Console.WriteLine(camera);
        Console.WriteLine(laptop);
        Console.WriteLine(projector);
    }
}
