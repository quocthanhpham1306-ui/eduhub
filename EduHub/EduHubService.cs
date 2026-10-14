
namespace EduHub;

public class EduHubService
{
    private readonly List<TeamMembership> _memberships = new();
    private readonly List<Registration> _registrations = new();
    private readonly List<CheckIn> _checkIns = new();

    // US-01: Tuyển thủ gửi yêu cầu gia nhập đội
    public TeamMembership JoinTeam(Player player, Team team)
    {
        bool alreadyRequested = _memberships.Any(m =>
            m.PlayerId == player.Id &&
            (m.Status == MembershipStatus.Pending ||
             m.Status == MembershipStatus.Approved));

        if (alreadyRequested)
            throw new InvalidOperationException(
                "Tuyển thủ đã có yêu cầu đang chờ hoặc đã thuộc một đội.");

        var membership = TeamMembership.Create(player, team);
        _memberships.Add(membership);
        return membership;
    }

    // US-06: CEO duyệt yêu cầu gia nhập
    public void ApproveMembership(TeamMembership membership)
    {
        bool alreadyInAnotherTeam = _memberships.Any(m =>
            m.PlayerId == membership.PlayerId &&
            m.Id != membership.Id &&
            m.Status == MembershipStatus.Approved);

        if (alreadyInAnotherTeam)
            throw new InvalidOperationException(
                "Tuyển thủ đã thuộc một đội tuyển khác.");

        membership.Approve();
    }

    public void RejectMembership(TeamMembership membership)
    {
        membership.Reject();
    }

    // US-06: CEO ngừng một thành viên
    public void RemoveMember(TeamMembership membership)
    {
        membership.RemoveFromTeam();
    }

    // US-02: Đăng ký giải đấu, kiểm tra sức chứa
    public Registration RegisterTournament(
        Player player,
        Tournament tournament)
    {
        bool duplicate = _registrations.Any(r =>
            r.PlayerId == player.Id &&
            r.TournamentId == tournament.Id &&
            r.Status != RegistrationStatus.Cancelled);

        if (duplicate)
            throw new InvalidOperationException(
                "Tuyển thủ đã đăng ký giải đấu này.");

        int occupied = _registrations.Count(r =>
            r.TournamentId == tournament.Id &&
            r.Status != RegistrationStatus.Cancelled);

        if (occupied >= tournament.Capacity)
            throw new InvalidOperationException(
                "Giải đấu đã hết chỗ.");

        var registration = Registration.Create(player, tournament);
        _registrations.Add(registration);
        return registration;
    }

    // US-03: Check-in phiếu đã được xác nhận
    public CheckIn CheckInTournament(Registration registration)
    {
        if (!_registrations.Contains(registration))
            throw new InvalidOperationException(
                "Phiếu đăng ký không tồn tại trong hệ thống.");

        bool checkedIn = _checkIns.Any(c =>
            c.RegistrationId == registration.Id);

        if (checkedIn)
            throw new InvalidOperationException(
                "Phiếu đăng ký đã check-in.");

        var checkIn = CheckIn.Create(registration);
        _checkIns.Add(checkIn);
        return checkIn;
    }

    // US-05: Báo cáo số liệu
    public int CountTeamMembers(Team team)
    {
        return _memberships.Count(m =>
            m.TeamId == team.Id &&
            m.Status == MembershipStatus.Approved);
    }

    public int CountTournamentRegistrations(Tournament tournament)
    {
        return _registrations.Count(r =>
            r.TournamentId == tournament.Id &&
            r.Status != RegistrationStatus.Cancelled);
    }

    public int CountTournamentCheckIns(Tournament tournament)
    {
        var confirmedRegistrationIds = _registrations
            .Where(r => r.TournamentId == tournament.Id)
            .Select(r => r.Id)
            .ToHashSet();

        return _checkIns.Count(c =>
            confirmedRegistrationIds.Contains(c.RegistrationId));
    }

    public IReadOnlyList<TeamMembership> MembershipHistory =>
        _memberships.AsReadOnly();
}

