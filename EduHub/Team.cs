
namespace EduHub;

public class Team
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public Guid ClubId { get; private set; }

    private Team(Guid id, string name, Guid clubId)
    {
        Id = id;
        Name = name;
        ClubId = clubId;
    }

    public static Team Create(string name, Club club)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Tên đội tuyển không được để trống.");

        if (club == null)
            throw new ArgumentNullException(nameof(club),
                "Đội tuyển phải thuộc một câu lạc bộ.");

        return new Team(Guid.NewGuid(), name.Trim(), club.Id);
    }
}

