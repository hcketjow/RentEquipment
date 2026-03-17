namespace RentEquipment;

public class Projector : Equipment {
    private string MatrixType { get; }
    private string Led { get; }

    public Projector(int uniqueIdent, string name, string brand, string matrixType, string led)
        : base(uniqueIdent, name, brand)
    {
        MatrixType = matrixType;
        Led = led;
    }
}
