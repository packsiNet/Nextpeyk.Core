namespace ApplicationLayer.Dto.Identity;

public class ChangePasswordDto
{
    public string CurrentPassword { get; set; }

    public string NewPassword { get; set; }
}