using YangiBozor.Domain.Comons;
using YangiBozor.Domain.Enums;

namespace YangiBozor.Domain.Entities;

public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set;  }
    public string Phone { get; set;  }
    public string UserName { get; set;  }
    public string Password { get; set; }
    public UserRole Role { get; set; }

}
