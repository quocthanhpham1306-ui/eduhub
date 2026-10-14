
namespace EduHub;

public class CheckIn
{
    public Guid Id { get; private set; }
    public Guid RegistrationId { get; private set; }
    public DateTime CheckedInAt { get; private set; }

    private CheckIn(
        Guid id,
        Guid registrationId,
        DateTime checkedInAt)
    {
        Id = id;
        RegistrationId = registrationId;
        CheckedInAt = checkedInAt;
    }

    public static CheckIn Create(Registration registration)
    {
        if (registration == null)
            throw new ArgumentNullException(nameof(registration));

        if (registration.Status != RegistrationStatus.Confirmed)
            throw new InvalidOperationException(
                "Chỉ phiếu Confirmed mới được check-in.");

        return new CheckIn(
            Guid.NewGuid(),
            registration.Id,
            DateTime.Now);
    }
}

