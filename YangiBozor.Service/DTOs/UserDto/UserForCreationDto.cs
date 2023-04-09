using YangiBozor.Domain.Enums;

namespace YangiBozor.Service.DTOs.UserDto;

public class UserForCreationDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; } = UserRole.user;
}
