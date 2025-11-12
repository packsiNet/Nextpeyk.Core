namespace ApplicationLayer.Dto.Fleets;

public class AddFleetInputDto
{
    public string UserName { get; set; }

    public string Password { get; set; }

    public string RePassword { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string Description { get; set; }

    public virtual bool IsActive { get; set; }

    public string PhoneNumber { get; set; }

    public string NationalCode { get; set; }

    public int FleetTypeId { get; set; }

    public string Plaque { get; set; }

    public string DrivingLicense { get; set; }
}