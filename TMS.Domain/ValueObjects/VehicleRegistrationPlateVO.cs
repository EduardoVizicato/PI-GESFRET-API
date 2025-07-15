namespace TMS.Domain.ValueObjects;

public class VehicleRegistrationPlateVO
{
    public VehicleRegistrationPlateVO(string registrationPlate)
    {
        if (!IsValidFormat(registrationPlate))
            throw new ArgumentException("The format is invalid", nameof(registrationPlate));
        RegistrationPlate = registrationPlate;
    }
    
    public string RegistrationPlate { get; set; }
    
    public static bool IsValidFormat(string sanitizedPlate)
    {
        return !string.IsNullOrWhiteSpace(sanitizedPlate) &&
               sanitizedPlate.Length == 7;
    }
}