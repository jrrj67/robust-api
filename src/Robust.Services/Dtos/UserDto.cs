namespace Robust.Services.Dtos
{
    public class UserDto
    {
        public long Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
