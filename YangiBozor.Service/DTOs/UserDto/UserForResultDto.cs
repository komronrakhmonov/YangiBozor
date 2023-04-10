using YangiBozor.Domain.Comons;
using YangiBozor.Domain.Enums;

namespace YangiBozor.Service.DTOs.UserDto;

public class UserForResultDto : Auditable
{
    public string ProfilePhotoUrl { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string UserName { get; set; }
    public UserRole Role { get; set; }
}
