
using BeautyMakers.Domain.Enums;

namespace BeautyMakers.Services.DTOs.Users;
public class UserForUpdateDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public Gender Gender { get; set; }
}
