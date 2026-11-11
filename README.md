# Smart Home Mini - Bài Thực Hành 10 (Bản Nháp v1)

## 1. Giới thiệu
Ứng dụng điều khiển nhà thông minh đơn giản với 3 loại thiết bị: Đèn (SmartLight), Quạt (SmartFan), Cửa (SmartDoor).
Bài làm sử dụng 3 Design Pattern:
- **Factory**: Tạo thiết bị
- **Singleton**: Lưu cấu hình chung
- **Facade**: Gom các thao tác GoToWork, GoToSleep

## 2. Tình trạng hiện tại (v1)
- Code mới xong phần khung ban đầu.
- Một số chỗ đang bị lỗi hoặc chưa chuẩn:
  - DeviceFactory chưa xử lý chuỗi hoa thường, khi nhập sai loại đang trả về `null` thay vì quăng lỗi `ArgumentException`.
  - SmartHomeFacade: hàm `GoToSleep()` chưa gọi khóa cửa `door.Lock()`, mức sáng đang fix cứng 30%.
  - HomeConfiguration: chưa private constructor, chưa dùng `Lazy<T>`.
  - Chưa viết test case T1 - T5 đầy đủ.

## 3. Các việc cần làm tiếp theo (TODO)
- [ ] Sửa lại DeviceFactory dùng switch-case và ném lỗi.
- [ ] Bổ sung khóa cửa trong Facade và đọc từ cấu hình.
- [ ] Tối ưu Singleton theo chuẩn thread-safe.
- [ ] Hoàn thành sơ đồ UML và trả lời câu hỏi lý thuyết.
