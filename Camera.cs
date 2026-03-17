namespace RentEquipment;

public class Camera : Equipment {
    private string CameraLensType { get; }
    private string CameraLensSystem { get; }

    public Camera(int uniqueIdent, string name, string brand, string cameraLensType, string cameraLensSystem)
        : base(uniqueIdent, name, brand)
    {
        CameraLensType = cameraLensType;
        CameraLensSystem = cameraLensSystem;
    }
}
