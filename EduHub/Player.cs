
namespace EduHub;

public class Player
{
    public Guid Id { get; private set; }
    public string FullName { get; private set; }
    public string Email { get; private set; }

    private Player(Guid id, string fullName, string email)
    {
        Id = id;
        FullName = fullName;
        Email = email;
    }

    public static Player Create(string fullName, string email)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("Tên tuyển thủ không được để trống.");

        if (string.IsNullOrWhiteSpace(email) ||
            !email.Contains('@'))
            throw new ArgumentException("Email không hợp lệ.");

        return new Player(
            Guid.NewGuid(),
            fullName.Trim(),
            email.Trim());
    }
}

