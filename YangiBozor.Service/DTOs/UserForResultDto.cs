namespace YangiBozor.Service.DTOs;

public class UserForResultDto : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string UserName { get; set; }
    public UserRole Role { get; set; }
}
