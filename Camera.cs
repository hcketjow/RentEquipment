namespace RentEquipment;

public class Camera : Equipment {
    public string CameraLensType { get; }
    public string CameraLensSystem { get; }

    public Camera(int uniqueIdent, string name, string brand, string cameraLensType, string cameraLensSystem)
        : base(uniqueIdent, name, brand)
    {
        CameraLensType = cameraLensType;
        CameraLensSystem = cameraLensSystem;
    }

    public override string ToString() {
        return base.ToString() + $" LensType: {CameraLensType}, LensSystem: {CameraLensSystem}";
    }
}
