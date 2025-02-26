# SaiGameC4
## 🚀Start 19/2/2025:
Hành trình học c4 trên kênh sai game\
📚 💡 🎯 🛠 🚀 🌅 🔄 🏆 🗂 🔖 📝 👉 ♦
___
### 💡Seri có E0 -> E94:
- E0 -> E19: các vấn đề cơ bản
- Do đã xong **C3** 👉 start: _**E20**_ trở đi
___
## 🌅Ngày 19/2: E20 -> E28
- Cách lấy model: **Mixamo** + animation(lúc chọn thì tích "In Place")
- Material cơ bản
- Setup đường đi enemy
- Navmesh cơ bản
## 🌅Ngày 20/2: E29 -> E39
- E29:
	- 🔖CheckMoving: sau dùng observer thay cho fixedupdate
	- 🔖E32: tìm quái gần nhất, sau dùng observer
- 💡Fact:
	- Static class:
		- script "Const" dùng static hay bỏ static thì khi gọi Const.IsMoving như nhau?
		- 👉 class static: không kế thừa hay kéo được vào inspector
	- LookAt và LookRotation:
		- LookAt → Khi bạn muốn đối tượng quay ngay lập tức.
		- LookRotation + RotateTowards → Khi bạn muốn đối tượng xoay dần dần về hướng mục tiêu.
- 💡Fact:
	- khi bấm chuột phải trong **scene** thì có thể dùng phím **A W S D** để di chuyển
	- khi bấm chuột phải + lăn chuột 👉 chỉnh tốc độ zoom của A W S D
- 🛠BUgg: Lỗi logic trong **if**
	- trước giờ: biết **if** truyền vào true hoặc false
		- vd: bool, ==,..
	- Nhưng nếu truyền thế này: _**collider.transform.parent = enemyCtrl.transform**_ thì nó cũng không báo lỗi luôn
	- 👉 vì toán tử _"="_ trả về giá trị vừa gán trức là enemyCtrl.transform,mà trong C# bất kỳ đối tượng nào khác **null** đều được coi là **true** trong điều kiện **if**
	- 👉 từ đó: vật thể nào mang **collider** va chạm với nó có thể sẽ thành con của nó =))
		- và tất nhiên nó sẽ đi theo vật thể luôn
	- [🔗**Link bugg**](https://youtu.be/07MBMTH6MPU).
## 🌅Ngày 22/2: E40 -> E49
- Generic class cơ bản
- E43: truyền nhận damage
	- cơ chế hoạt động giống như observer, nhưng thay vì gọi như observer thì tạo hàm public gọi trực tiếp
	- Một cách làm khác ngoài cách interface 

- E44: Open/Closed Principle (chữ O trong solid) và Liskov Substitution Principle(chữ L trong solid)
	- thằng *DamageSender*: chỉ chịu trách nhiệm gửi damage
	- thằng con *BulletDamageSender*: kế thừa từ thằng *DamageSender*, còn việc biến mất khi va chạm thì tự khai báo
	- 👉 *BulletDamageSender* mở rộng *DamageSender* mà không cần sửa code lớp cha
	- 👉 *BulletDamageSender* có thể sử dụng thay thế *DamageSender* mà không làm thay đổi hành vi chương trình
- E48:
	- 🔖EnemySpawning: phần remove enemy khỏi list sau khi chết, note lại sau sửa vì không cần gọi trong fixedupdate
	- 🔖cái phần remove xác enemy khi đã chết khỏi list - note lại sau tối ưu
## 🌅Ngày 23/2: E50 -> E57
- Cái lỗi raycast ở tower mãi k biết sửa kiễu gì ?:D??
## 🌅Ngày 24/2: E58 -> E60
- Rig animation cơ bản:
- Thuộc tính weight để xem IK có được chỉnh sửa hayp không
## 🌅Ngày 25/2: E59 ->E60:
- ở script: PlayerAiming có hàm RotateToPosition thì tắt cái Rotation On Camera ở VThirdPersonController đi
## 🌅Ngày 26/2: E61 ->:
- Trong game, player bắn: đạn bay theo hướng crossHair(playerShoot)
	- 🛠Nhưng xảy ra 1 lỗi đó là: có 1 vị trí mà nó bay ra 2 đường đạn? tại sao?
		- CrossHair: lấy vị trí chuột, cập nhật bằng Update()
		- Bắn đạn cũng để Update() -> dẫn tới chưa cập nhật xong CrossHair, viên đạn đã bắn ra
		- 👉 Bắn đạn để LateUpdate(): _LateUpdate chạy sau khi Update đã hoàn thành_
		- 👉 Đảm bảo lấy vị trí -> mới bắn
- một chút về Pool không quên:
	- GetName(): cái nằm ở mấy script Ctrl: như bulletCtrl, Fire1Ctrl,Fire2Ctrl
		- 👉 để khi obj despawn -> đưa vào list -> khi dùng -> xóa khỏi list
	- GetByName(): duyệt list chứa prefabs để bắn ra
		- 👉 Chỉ để trả về đúng Prefab để spawn ra thay vì gọi prefabs[0],... Đại loại gọi chính nó luôn
- 📚 E65 **Inventory**: một chút đỡ rối
	- Inventory:
		- InventoryManager: quản lí list InventoryCtrl
		- InventoryCtrl: quản lí add item, là lớp cha định nghĩa chung các Inventory
			- InventoryMonies: kế thừa từ InventoryCtrl, định nghĩa enum của nó:Monies
			- InventoryItems: kế thừa từ InventoryCtrl, định nghĩa enum: Items
		- InventoryCodeName: là enum: Monies, Items,...
	- Item:
		- ItemInventory: quản lí ItemProfileSO và số lượng item
		- ItemCode: là enum: gold, wand, iron,....
		- ItemProfileSO: quản lí ItemCode, tên item, có gộp chung được không(vd: quặng, vũ khí)
- E67:
	- Update Observer, những thứ như update text,.. => chuyển thành observer hết
