
namespace EduHub;

public enum MembershipStatus
{
    Pending,
    Approved,
    Rejected,
    Left
}

public class TeamMembership
{
    public Guid Id { get; private set; }
    public Guid PlayerId { get; private set; }
    public Guid TeamId { get; private set; }
    public MembershipStatus Status { get; private set; }
    public DateTime RequestedAt { get; private set; }
    public DateTime? DecidedAt { get; private set; }
    public DateTime? LeftAt { get; private set; }

    private TeamMembership(Guid playerId, Guid teamId)
    {
        Id = Guid.NewGuid();
        PlayerId = playerId;
        TeamId = teamId;
        Status = MembershipStatus.Pending;
        RequestedAt = DateTime.Now;
    }

    public static TeamMembership Create(Player player, Team team)
    {
        if (player == null)
            throw new ArgumentNullException(nameof(player));

        if (team == null)
            throw new ArgumentNullException(nameof(team));

        return new TeamMembership(player.Id, team.Id);
    }

    public void Approve()
    {
        if (Status != MembershipStatus.Pending)
            throw new InvalidOperationException(
                "Chỉ yêu cầu Pending mới được duyệt.");

        Status = MembershipStatus.Approved;
        DecidedAt = DateTime.Now;
    }

    public void Reject()
    {
        if (Status != MembershipStatus.Pending)
            throw new InvalidOperationException(
                "Chỉ yêu cầu Pending mới được từ chối.");

        Status = MembershipStatus.Rejected;
        DecidedAt = DateTime.Now;
    }

    public void RemoveFromTeam()
    {
        if (Status != MembershipStatus.Approved)
            throw new InvalidOperationException(
                "Chỉ thành viên đã được duyệt mới có thể rời đội.");

        Status = MembershipStatus.Left;
        LeftAt = DateTime.Now;
    }
}

