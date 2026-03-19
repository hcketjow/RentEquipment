namespace RentEquipment;

public class Projector : Equipment {
    public string MatrixType { get; }
    public string Led { get; }

    public Projector(int uniqueIdent, string name, string brand, string matrixType, string led)
        : base(uniqueIdent, name, brand)
    {
        MatrixType = matrixType;
        Led = led;
    }

    public override string ToString(){
        return base.ToString() + $" Matrix: {MatrixType}, LED: {Led}";
    }
}
