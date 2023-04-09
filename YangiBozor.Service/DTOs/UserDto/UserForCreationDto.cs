using System.ComponentModel.DataAnnotations;
using YangiBozor.Domain.Comons;
using YangiBozor.Domain.Enums;

namespace YangiBozor.Service.DTOs.UserDto;

public class UserForCreationDto : Auditable
{
    public string ProfilePictureUrl { get; set; }
    [Required(ErrorMessage = "First Name is required")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Last Name is required")]
    public string LastName { get; set; }
    [Required(ErrorMessage = "PhoneNumber is required")]
    public string Phone { get; set; }
    [StringLength(50, MinimumLength =3, ErrorMessage ="UserName should be between 3-50 characteristics!")]
    public string UserName { get; set; }
    
    public string Password { get; set; }
    public UserRole Role { get; set; } = UserRole.user;
}
