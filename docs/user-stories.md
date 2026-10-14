# User Stories – EduHub

## US-01 – Tuyển thủ gửi yêu cầu gia nhập đội

**Vai trò:** Tuyển thủ (Player)

**Mô tả:** Là một tuyển thủ, tôi muốn gửi yêu cầu gia nhập đội tuyển để có thể tham gia hoạt động cùng đội.

**Tiêu chí chấp nhận:**
1. Khi tuyển thủ chưa có yêu cầu đang chờ và chưa thuộc đội nào, hệ thống tạo yêu cầu với trạng thái `Pending`.
2. Khi tuyển thủ đã có yêu cầu đang chờ hoặc đã thuộc một đội, hệ thống từ chối yêu cầu mới.
3. Khi CEO duyệt yêu cầu, trạng thái chuyển thành `Approved`.
4. Khi CEO từ chối yêu cầu, trạng thái chuyển thành `Rejected`.

## US-02 – Tuyển thủ đăng ký giải đấu

**Vai trò:** Tuyển thủ (Player)

**Mô tả:** Là một tuyển thủ, tôi muốn đăng ký giải đấu nội bộ để có cơ hội tham gia thi đấu.

**Tiêu chí chấp nhận:**
1. Khi giải đấu còn chỗ và tuyển thủ chưa đăng ký giải đó, hệ thống tạo phiếu đăng ký có trạng thái `Pending`.
2. Khi giải đấu đã đủ sức chứa, hệ thống từ chối đăng ký và thông báo giải đấu đã hết chỗ.
3. Khi tuyển thủ đã có phiếu đăng ký chưa bị hủy cho cùng giải đấu, hệ thống từ chối đăng ký trùng.

## US-03 – Tuyển thủ check-in giải đấu

**Vai trò:** Tuyển thủ (Player)

**Mô tả:** Là một tuyển thủ, tôi muốn check-in để xác nhận tham dự giải đấu.

**Tiêu chí chấp nhận:**
1. Chỉ phiếu đăng ký có trạng thái `Confirmed` mới được check-in.
2. Phiếu có trạng thái `Pending` hoặc `Cancelled` không được check-in.
3. Một phiếu đăng ký chỉ được check-in một lần.

## US-04 – Quản lý tạo giải đấu

**Vai trò:** Quản lý (Manager)

**Mô tả:** Là một quản lý, tôi muốn tạo giải đấu thuộc câu lạc bộ để tổ chức thi đấu nội bộ.

**Tiêu chí chấp nhận:**
1. Tên giải đấu không được để trống.
2. Giải đấu phải thuộc một câu lạc bộ hợp lệ và lưu đúng `ClubID`.
3. Sức chứa giải đấu phải lớn hơn 0.

## US-05 – Quản lý xem báo cáo

**Vai trò:** Quản lý (Manager)

**Mô tả:** Là một quản lý, tôi muốn xem số liệu thành viên và tình hình tham gia giải đấu để theo dõi hoạt động.

**Tiêu chí chấp nhận:**
1. Hệ thống hiển thị số thành viên hiện đang được duyệt của mỗi đội.
2. Hệ thống hiển thị số phiếu đăng ký chưa bị hủy của giải đấu.
3. Hệ thống hiển thị số lượt check-in hợp lệ của giải đấu.

## US-06 – CEO quản lý thành viên đội tuyển

**Vai trò:** CEO

**Mô tả:** Là một CEO, tôi muốn duyệt yêu cầu gia nhập, từ chối yêu cầu và cho thành viên rời đội để quản lý nhân sự.

**Tiêu chí chấp nhận:**
1. CEO chỉ được duyệt hoặc từ chối yêu cầu đang ở trạng thái `Pending`.
2. Một tuyển thủ không được thuộc nhiều đội cùng lúc.
3. Khi CEO cho thành viên đã được duyệt rời đội, trạng thái chuyển thành `Left`.
4. Hệ thống giữ lại lịch sử yêu cầu, thời điểm xử lý và thời điểm rời đội nếu có.
