using BeautyMakers.Domain.Enums;

namespace BeautyMakers.Services.DTOs.Users;
public class UserForResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public Gender Gender { get; set; }
    public string UserImg { get; set; }
}
