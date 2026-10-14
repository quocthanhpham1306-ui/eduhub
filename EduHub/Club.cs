
namespace EduHub;

public class Club
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    private Club(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public static Club Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Tên câu lạc bộ không được để trống.");

        return new Club(Guid.NewGuid(), name.Trim());
    }
}

