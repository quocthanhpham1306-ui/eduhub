
namespace EduHub;

public enum RegistrationStatus
{
    Pending,
    Confirmed,
    Cancelled
}

public class Registration
{
    public Guid Id { get; private set; }
    public Guid PlayerId { get; private set; }
    public Guid TournamentId { get; private set; }
    public RegistrationStatus Status { get; private set; }

    private Registration(Guid id, Guid playerId, Guid tournamentId)
    {
        Id = id;
        PlayerId = playerId;
        TournamentId = tournamentId;
        Status = RegistrationStatus.Pending;
    }

    public static Registration Create(Player player, Tournament tournament)
    {
        if (player == null)
            throw new ArgumentNullException(nameof(player));

        if (tournament == null)
            throw new ArgumentNullException(nameof(tournament));

        return new Registration(
            Guid.NewGuid(),
            player.Id,
            tournament.Id);
    }

    public void Confirm()
    {
        if (Status != RegistrationStatus.Pending)
            throw new InvalidOperationException(
                "Chỉ phiếu Pending mới được xác nhận.");

        Status = RegistrationStatus.Confirmed;
    }

    public void Cancel()
    {
        if (Status == RegistrationStatus.Cancelled)
            throw new InvalidOperationException(
                "Phiếu đăng ký đã bị hủy.");

        Status = RegistrationStatus.Cancelled;
    }
}

