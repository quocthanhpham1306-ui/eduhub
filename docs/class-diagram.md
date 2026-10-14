# Class Diagram – EduHub

Sơ đồ mô tả 7 lớp miền nghiệp vụ và các quan hệ giữa chúng.

```mermaid
classDiagram
    class Player {
        -Guid Id
        -string FullName
        -string Email
        +Create(fullName, email) Player
    }

    class Club {
        -Guid Id
        -string Name
        +Create(name) Club
    }

    class Team {
        -Guid Id
        -string Name
        -Guid ClubId
        +Create(name, club) Team
    }

    class TeamMembership {
        -Guid Id
        -Guid PlayerId
        -Guid TeamId
        -MembershipStatus Status
        -DateTime RequestedAt
        -DateTime DecidedAt
        -DateTime LeftAt
        +Create(player, team) TeamMembership
        +Approve() void
        +Reject() void
        +RemoveFromTeam() void
    }

    class Tournament {
        -Guid Id
        -string Name
        -Guid ClubId
        -int Capacity
        +Create(name, club, capacity) Tournament
    }

    class Registration {
        -Guid Id
        -Guid PlayerId
        -Guid TournamentId
        -RegistrationStatus Status
        +Create(player, tournament) Registration
        +Confirm() void
        +Cancel() void
    }

    class CheckIn {
        -Guid Id
        -Guid RegistrationId
        -DateTime CheckedInAt
        +Create(registration) CheckIn
    }

    class MembershipStatus {
        <<enumeration>>
        Pending
        Approved
        Rejected
        Left
    }

    class RegistrationStatus {
        <<enumeration>>
        Pending
        Confirmed
        Cancelled
    }

    Club "1" --> "0..*" Team : owns
    Club "1" --> "0..*" Tournament : organizes
    Player "1" --> "0..*" TeamMembership : requests
    Team "1" --> "0..*" TeamMembership : records
    Player "1" --> "0..*" Registration : registers
    Tournament "1" --> "0..*" Registration : accepts
    Registration "1" --> "0..1" CheckIn : has
    TeamMembership --> MembershipStatus : status
    Registration --> RegistrationStatus : status
```

## Giải thích

- `Club` quản lý các đội tuyển `Team` và giải đấu `Tournament`.
- `TeamMembership` lưu yêu cầu gia nhập, trạng thái duyệt và lịch sử rời đội.
- `Registration` lưu phiếu đăng ký giải đấu; `CheckIn` ghi nhận thời điểm tham dự.
- Các trường `ClubId`, `PlayerId`, `TeamId`, `TournamentId` và `RegistrationId` thể hiện các khóa tham chiếu giữa những lớp liên quan.
- Các thuộc tính được đóng gói bằng `private set`; đối tượng được khởi tạo thông qua phương thức `Create()` để kiểm tra dữ liệu đầu vào.
