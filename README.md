# SaiGameC4

Hành trình học C4 trên kênh SaiGame (19/2/2025 - 3/3/2025)

## Tuần 1 (19/2 - 23/2)
- **3D Models**: Mixamo và animations
- **NavMesh**: Setup đường đi cho enemy
- **Enemy Targeting**: Tìm quái gần nhất
- **Static Class vs Instance**: Hiểu điểm khác biệt
- **LookAt vs LookRotation**: Xoay tức thời và xoay dần dần
- **Generic Class**: Áp dụng thực tế
- **Damage System**: Cơ chế gửi/nhận damage
- **SOLID Principles**: Open/Closed và Liskov Substitution

## Tuần 2 (24/2 - 3/3)
- **Animation Rigging**: Weight và IK cơ bản
- **Player Aiming**: Điều chỉnh crosshair và bắn đạn
- **Update Order**: Sử dụng LateUpdate để đảm bảo thứ tự thực thi
- **Pooling System**: GetName() và GetByName()
- **Inventory System**: InventoryManager, InventoryCtrl, ItemProfileSO
- **Observer Pattern**: Chuyển đổi các tác vụ update thành observer
- **Item Drop System**: Setup item properties theo nhu cầu
- **Level System**: Thiết kế cơ bản
- **Source Control**: Sử dụng Sourcetree và revertCommit

## Kiến trúc Code
- Observer thay thế cho FixedUpdate
- Inventory phân tách thành InventoryMonies và InventoryItems
- Đảm bảo thứ tự thực thi với Update và LateUpdate
- Tối ưu các hàm update bằng Observer Pattern