
using EduHub;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("========================================");
Console.WriteLine("   EDUHUB - QUAN LY DOI TUYEN VA GIAI DAU");
Console.WriteLine("========================================");

// 1. Khoi tao cau lac bo, doi tuyen va tuyen thu
Club club = Club.Create("EduHub Esports");
Team team = Team.Create("EduHub Warriors", club);

Player player1 = Player.Create("Nguyen Van An", "an@example.com");
Player player2 = Player.Create("Tran Thi Binh", "binh@example.com");
Player player3 = Player.Create("Le Van Cuong", "cuong@example.com");

EduHubService service = new EduHubService();

Console.WriteLine($"\nCau lac bo: {club.Name}");
Console.WriteLine($"Doi tuyen: {team.Name}");

// 2. US-01: Gui yeu cau gia nhap doi
Console.WriteLine("\n--- US-01: THAM GIA DOI TUYEN ---");

TeamMembership membership1 = service.JoinTeam(player1, team);
Console.WriteLine($"{player1.FullName}: {membership1.Status}");

service.ApproveMembership(membership1);
Console.WriteLine($"CEO duyet: {membership1.Status}");

TeamMembership membership2 = service.JoinTeam(player2, team);
service.RejectMembership(membership2);
Console.WriteLine($"CEO tu choi {player2.FullName}: {membership2.Status}");

// 3. US-04: Quan ly tao giai dau
Console.WriteLine("\n--- US-04: TAO GIAI DAU ---");

Tournament tournament = Tournament.Create(
    "Giai dau Lien Quan noi bo",
    club,
    2);

Console.WriteLine($"Ten giai: {tournament.Name}");
Console.WriteLine($"ClubID: {tournament.ClubId}");
Console.WriteLine($"Suc chua: {tournament.Capacity}");

// 4. US-02: Dang ky giai dau
Console.WriteLine("\n--- US-02: DANG KY GIAI DAU ---");

Registration registration1 =
    service.RegisterTournament(player1, tournament);

Console.WriteLine($"{player1.FullName}: {registration1.Status}");
registration1.Confirm();
Console.WriteLine($"Xac nhan phieu: {registration1.Status}");

Registration registration2 =
    service.RegisterTournament(player2, tournament);

Console.WriteLine($"{player2.FullName}: {registration2.Status}");

// Thu dang ky vuot suc chua
try
{
    service.RegisterTournament(player3, tournament);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Dang ky {player3.FullName}: TU CHOI - {ex.Message}");
}

// 5. US-03: Check-in giai dau
Console.WriteLine("\n--- US-03: CHECK-IN ---");

CheckIn checkIn1 = service.CheckInTournament(registration1);
Console.WriteLine(
    $"{player1.FullName} check-in thanh cong luc {checkIn1.CheckedInAt:HH:mm:ss}");

try
{
    service.CheckInTournament(registration2);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Check-in khi Pending: TU CHOI - {ex.Message}");
}

// Xac nhan phieu thu hai roi check-in
registration2.Confirm();
CheckIn checkIn2 = service.CheckInTournament(registration2);

Console.WriteLine(
    $"{player2.FullName} check-in sau khi Confirmed luc {checkIn2.CheckedInAt:HH:mm:ss}");

// 6. US-05: Bao cao thong ke
Console.WriteLine("\n--- US-05: BAO CAO THONG KE ---");

Console.WriteLine(
    $"So thanh vien hien tai: {service.CountTeamMembers(team)}");

Console.WriteLine(
    $"So phieu dang ky chua huy: {service.CountTournamentRegistrations(tournament)}");

Console.WriteLine(
    $"So nguoi da check-in: {service.CountTournamentCheckIns(tournament)}");

// 7. US-06: CEO ngung thanh vien va luu lich su
Console.WriteLine("\n--- US-06: QUAN LY THANH VIEN ---");

service.RemoveMember(membership1);

Console.WriteLine(
    $"CEO ngung {player1.FullName}: {membership1.Status}");

Console.WriteLine(
    $"Lich su thanh vien duoc luu: {service.MembershipHistory.Count} ban ghi");

Console.WriteLine("\n========================================");
Console.WriteLine("DEMO HOAN TAT");
Console.WriteLine("========================================");
