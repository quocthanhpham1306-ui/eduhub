
namespace EduHub;

public class Tournament
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public Guid ClubId { get; private set; }
    public int Capacity { get; private set; }

    private Tournament(
        Guid id,
        string name,
        Guid clubId,
        int capacity)
    {
        Id = id;
        Name = name;
        ClubId = clubId;
        Capacity = capacity;
    }

    public static Tournament Create(
        string name,
        Club club,
        int capacity)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException(
                "Tên giải đấu không được để trống.");

        if (club == null)
            throw new ArgumentNullException(nameof(club));

        if (capacity <= 0)
            throw new ArgumentException(
                "Sức chứa phải lớn hơn 0.");

        return new Tournament(
            Guid.NewGuid(),
            name.Trim(),
            club.Id,
            capacity);
    }
}

