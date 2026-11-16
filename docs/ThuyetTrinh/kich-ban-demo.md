# Kịch bản demo — Hệ thống quản lý bán vé máy bay

Thời lượng: **khoảng 10–12 phút**. Demo nối tiếp sau slide 29 (hoặc chen vào sau slide 28 nếu thầy cô muốn xem sớm).

| Vai | Người | Việc |
|---|---|---|
| Thao tác máy | **Suan** (phần bán vé) → **Ngân** (phần quản trị) | Cầm chuột, bấm theo kịch bản |
| Dẫn lời | Người không cầm chuột | Đọc lời thoại, chỉ lên màn hình |

> Đổi vai ở bước 7 (đăng nhập admin) để cả hai đều có phần nói và phần thao tác.

---

## 0. Chuẩn bị trước buổi (làm ở nhà và 10 phút trước giờ)

- [ ] **Dựng lại CSDL sạch** theo mục 1 của README (xóa `QuanLyBanVeMayBay2` rồi chạy lại file SQL), để số liệu đúng như lúc tập.
- [ ] **Kiểm tra ngày**: chuyến mẫu có ngày cố định 16/11 – 13/12/2026. Kịch bản dùng cặp chuyến **HAN → CXR (26/11, 15:00)** và **CXR → HAN (27/11, 06:00)**. Nếu demo sau 22/11 thì phí hủy không còn là 10% — đổi sang cặp chuyến còn xa hơn, ví dụ **HAN → HKG (12/12)** / **HKG → HAN (13/12)**.
- [ ] Mở sẵn ứng dụng ở màn hình đăng nhập, phóng to cửa sổ, tăng độ phóng màn hình chiếu nếu chữ nhỏ.
- [ ] Tắt thông báo Windows, Zalo, Messenger.
- [ ] Ghi sẵn ra giấy: tài khoản, số CCCD/SĐT mẫu bên dưới, số thẻ thử `4111 1111 1111 1111`.
- [ ] **Tập ít nhất một lần trọn vẹn** và ghi lại các con số thật hiện trên màn hình (giá, phí hủy, tiền hoàn) để khi nói không bị lúng túng.

**Dữ liệu dùng trong demo**

| Mục | Giá trị |
|---|---|
| Nhân viên | `nv01` / `123456` |
| Quản trị viên | `admin` / `admin123` |
| Khách mới tạo trong demo | Nguyễn Văn An · CCCD `079095001234` · SĐT `0912345678` · `nguyenvanan@gmail.com` · sinh 1995 |
| Hành khách thứ hai (có sẵn) | Lê Ngọc Trang · CCCD `048178000002` |
| Khuyến mãi | Ưu đãi khách hàng mới (3%, tối đa 300.000 đ) |

---

## Tóm tắt các bước

| # | Nội dung | Ý muốn thầy cô thấy | Thời gian |
|---|---|---|---|
| 1 | Đăng nhập, Tổng quan | Phân quyền, số liệu tổng quan | 1 phút |
| 2 | Thêm khách hàng mới | Kiểm tra dữ liệu nhập, chuẩn hóa SĐT | 1 phút 30 |
| 3 | Đặt vé: chọn chuyến, chọn ghế | Sơ đồ ghế, chặn trùng ghế | 2 phút |
| 4 | Vé chiều về, khứ hồi, xác nhận | Giá tự tính, khứ hồi tự nhận | 1 phút 30 |
| 5 | Thanh toán | 3 phương thức, tiền thối | 1 phút |
| 6 | Thêm dịch vụ, hủy vé | Thu thêm phần chênh, phí hủy theo giờ | 2 phút |
| 7 | Đăng nhập admin | Menu quản trị, nhật ký, báo cáo | 1 phút 30 |

---

## Bước 1 · Đăng nhập và Tổng quan (1 phút)

**Thao tác**
1. Nhập máy chủ `.` (hoặc `.\SQLEXPRESS`), tài khoản `nv01` / `123456` → Đăng nhập.
2. Dừng ở màn **Tổng quan**.

**Lời nói**
> Bây giờ nhóm em demo trực tiếp. Em đăng nhập bằng tài khoản nhân viên quầy.
>
> Thầy cô để ý thanh menu bên trái: nhân viên chỉ thấy nhóm **Nghiệp vụ** — tổng quan, đặt vé, đơn đặt vé, tra cứu và hủy vé, khách hàng, chuyến bay, báo cáo. Ba menu **Máy bay, Tài khoản, Nhật ký** bị ẩn vì chỉ quản trị viên mới có quyền. Lát nữa em sẽ đăng nhập admin để so sánh.
>
> Màn tổng quan cho nhân viên nhìn nhanh doanh thu, số vé đã bán, biểu đồ 12 tháng và các chuyến sắp bay. Các số này đọc từ view trong CSDL. Thầy cô nhớ giúp em con số doanh thu hiện tại, cuối demo mình sẽ quay lại xem nó thay đổi.

---

## Bước 2 · Thêm khách hàng mới (1 phút 30)

**Thao tác**
1. Menu **Khách hàng** → **+ Thêm khách**.
2. Nhập họ tên `Nguyễn Văn An`, chọn CCCD, **cố ý gõ sai** `07909500123` (11 số) → Lưu → hiện lỗi *"Số CCCD phải gồm đúng 12 chữ số."*
3. Sửa thành `079095001234`. **Cố ý gõ sai** SĐT `0123456789` → Lưu → hiện lỗi SĐT không hợp lệ.
4. Sửa SĐT thành `0912345678`, nhập email `NguyenVanAn@Gmail.com`, ngày sinh 1995 → Lưu.
5. Chỉ vào dòng vừa thêm trong danh sách.

**Lời nói**
> Khách đến quầy lần đầu thì nhân viên tạo hồ sơ. Em thử nhập sai để thầy cô thấy phần kiểm tra dữ liệu.
>
> CCCD thiếu một số — hệ thống báo phải đủ 12 chữ số. Số điện thoại đầu 01 không còn là đầu số di động Việt Nam — hệ thống cũng chặn.
>
> Nhập đúng thì lưu được. Thầy cô thấy số điện thoại được lưu thống nhất dạng **+84912345678**, email được chuyển về chữ thường. Làm vậy để tìm kiếm và chống trùng chính xác. Số giấy tờ là duy nhất, nên một CCCD không thể gắn cho hai khách.
>
> Khách mới có hạng **Thành viên**, giảm 0%, tổng chi tiêu bằng 0.

---

## Bước 3 · Đặt vé — chọn chuyến và chọn ghế (2 phút)

**Thao tác**
1. Menu **Đặt vé**. Điểm đi `HAN`, điểm đến `CXR`, ngày bay 26/11 → **Tìm chuyến bay** → chọn chuyến → **Tiếp tục: Chọn ghế**.
2. Trên sơ đồ ghế, chỉ chuột qua 3 khu: Thương gia (hàng 1–2), Phổ thông đặc biệt (3–4), Phổ thông (5–10). Chỉ vào vài ghế đã có người đặt (màu khác).
3. Bấm một ghế **Phổ thông** trống, ví dụ `6A`. Hành khách: chọn **Nguyễn Văn An**. Khách liên hệ: **Nguyễn Văn An**. → **Thêm vé vào đơn**.
4. Bấm ghế `6B`, hành khách: chọn **lại Nguyễn Văn An** → **Thêm vé vào đơn** → hiện cảnh báo *"mỗi hành khách chỉ 1 ghế trên một chuyến"*.
5. Đổi hành khách của ghế `6B` sang **Lê Ngọc Trang** → **Thêm vé vào đơn**.

**Lời nói**
> Khách muốn đi Hà Nội – Cam Ranh. Nhân viên chọn điểm đi, điểm đến, ngày bay. Hệ thống chỉ hiện những chuyến **đang mở bán** và **chưa khởi hành**.
>
> Đây là sơ đồ ghế, chia hạng theo hàng giống máy bay thật: Thương gia phía mũi bố trí 2-2, Phổ thông đặc biệt rồi đến Phổ thông bố trí 3-3. Ghế đã đặt hiện màu khác và không bấm được.
>
> Em chọn ghế 6A cho anh An. Giờ em thử lỗi hay gặp ở quầy: chọn tiếp ghế 6B nhưng vẫn cho anh An. Hệ thống chặn ngay — một hành khách không thể có hai ghế trên cùng một chuyến. Em đổi sang chị Trang thì thêm được.
>
> Nếu hành khách dưới 16 tuổi, ô **Người giám hộ** sẽ bắt buộc chọn một người từ 18 tuổi. Đơn tối đa 2 vé, nên nút thêm vé sẽ khóa khi đủ.

---

## Bước 4 · Vé chiều về, khứ hồi và xác nhận (1 phút 30)

> Đơn tối đa 2 vé. Để demo khứ hồi, bước này **xóa vé của chị Trang** và thêm vé chiều về cho anh An. Nếu muốn giữ chị Trang thì bỏ bước này, demo khứ hồi bằng lời trên slide 19.

**Thao tác**
1. Trong **Vé trong đơn**, chọn vé của Lê Ngọc Trang → **Xóa vé đã chọn**.
2. **Quay lại** bước 1 → bấm **⇄** để đảo chiều thành `CXR → HAN`, ngày 27/11 → Tìm → chọn chuyến → chọn ghế Phổ thông trống, hành khách **Nguyễn Văn An** → **Thêm vé vào đơn**.
3. **Mã khuyến mãi**: chọn **Ưu đãi khách hàng mới**.
4. **Tiếp tục: Xác nhận**. Chỉ vào ô **Vé khứ hồi (giảm 10%)** đã tự tick, khung **Giảm giá (tối đa 30%)**, **Tổng giá gốc**, **Tổng thanh toán**.
5. Bấm **Đặt vé** → hộp xác nhận liệt kê từng vé → **Đặt vé**.

**Lời nói**
> Anh An muốn mua luôn chiều về. Em quay lại bước 1, bấm nút đảo chiều, chọn chuyến Cam Ranh – Hà Nội ngày hôm sau.
>
> Sang bước xác nhận, thầy cô thấy ô **Vé khứ hồi** tự tick. Nhân viên không tự tick được ô này: hệ thống tự nhận khi cùng một hành khách có hai vé với tuyến đảo chiều nhau trong cùng đơn.
>
> Anh An là khách mới nên dùng được **ưu đãi khách hàng mới** 3%. Mỗi vé phổ thông giá gốc 900.000 đ, giảm 10% khứ hồi cộng 3% khuyến mãi là 13%, còn **783.000 đ** một vé. *(Nếu số trên màn hình khác, đọc theo màn hình.)* Các mức giảm cộng dồn nhưng không bao giờ quá 30%.
>
> Bấm đặt vé, hệ thống hỏi xác nhận lại từng vé. Khi xác nhận, cả đơn được ghi trong **một giao dịch**: nếu một vé lỗi, ví dụ ghế vừa bị quầy khác đặt mất, thì cả đơn được hoàn tác, không có chuyện đặt được nửa đơn.

---

## Bước 5 · Thanh toán (1 phút)

**Thao tác**
1. Sau khi đặt, màn **Thanh toán đơn** mở ra (nếu không, vào **Đơn đặt vé** → chọn đơn → **Thanh toán đơn**).
2. Bấm lần lượt 3 phương thức để cho thấy giao diện: **Chuyển khoản** (mã VietQR), **Thẻ**, rồi quay lại **Tiền mặt**.
3. Tiền mặt: gõ số nhỏ hơn tổng → hiện *"Còn thiếu…"*; gõ `2.000.000` → hiện **Tiền thối**.
4. **Xác nhận thanh toán**.

**Lời nói**
> Hệ thống hỗ trợ ba phương thức. Chuyển khoản thì tự sinh mã VietQR có sẵn số tài khoản, số tiền và nội dung là mã đơn, để nhân viên đối chiếu với tài khoản ngân hàng. Thẻ thì kiểm tra số thẻ theo thuật toán Luhn và hạn thẻ; hệ thống chỉ lưu 4 số cuối, không lưu số thẻ đầy đủ hay CVV. Hai phương thức này là mô phỏng, chưa nối cổng thanh toán thật.
>
> Em chọn tiền mặt. Khách đưa thiếu thì hệ thống báo còn thiếu bao nhiêu, đưa 2 triệu thì tính luôn tiền thối. Số tiền thu luôn bằng đúng tổng đơn, không thu một phần.
>
> Thanh toán xong, đơn chuyển sang **Đã thanh toán**, tổng chi tiêu của anh An được cộng thêm và hạng thành viên được xét lại tự động.

---

## Bước 6 · Thêm dịch vụ và hủy vé (2 phút)

**Thao tác**
1. Menu **Đơn đặt vé** → chọn đơn vừa tạo → chọn vé **HAN → CXR** → **+ Dịch vụ cho vé**.
2. Tick **Suất ăn tiêu chuẩn** (120.000) và **Nước uống** (40.000) → **Thêm** → hệ thống hỏi thu thêm → thu bằng tiền mặt.
3. Vẫn chọn vé đó → **Hủy vé**. Màn hủy hiện: còn bao nhiêu giờ trước giờ bay, giá thực trả, **Phí hủy dự kiến**, **Tiền hoàn dự kiến**.
4. Nhập lý do `Khách đổi kế hoạch` → **Hủy vé**. Chỉ vào số thực tế trong thông báo, so với số dự kiến.
5. Chỉ vào đơn: còn 1 vé, đơn vẫn **Đã thanh toán**.

**Lời nói**
> Khách mua thêm suất ăn và nước uống cho chiều đi. Dịch vụ tính riêng, không được giảm giá. Vì đơn đã thanh toán, hệ thống hỏi thu thêm, và chỉ thu đúng **phần chênh lệch** 160.000 đ, không bắt thanh toán lại cả đơn.
>
> Giờ khách báo hủy chiều đi. Phí hủy tính theo thời gian còn lại trước giờ bay: từ 72 giờ trở lên 10%, 24 đến 72 giờ 20%, dưới 24 giờ 30%. Chuyến này còn hơn 72 giờ nên phí 10% trên giá thực trả, tức khoảng 78.300 đ. Tiền hoàn gồm cả tiền dịch vụ khách đã trả cho vé này.
>
> Em xác nhận. Số thực tế khớp với số dự kiến. Ghế 6A được trả về trạng thái **Trống** và bán lại được ngay. Tổng chi tiêu của khách bị trừ phần đã hoàn. Đơn còn một vé nên vẫn giữ trạng thái đã thanh toán; nếu hủy hết thì đơn mới chuyển sang Đã hủy.

*(Tùy chọn, nếu còn thời gian: quay lại **Đặt vé**, mở chuyến HAN → CXR, chỉ cho thấy ghế 6A đã trống lại.)*

---

## Bước 7 · Quản trị viên (1 phút 30) — đổi người thao tác

**Thao tác**
1. **Đăng xuất** → đăng nhập `admin` / `admin123`.
2. Chỉ vào nhóm menu **Quản lý** vừa hiện ra.
3. **Máy bay**: chọn một máy bay, cho xem cấu hình số hàng theo hạng (không cần thêm mới nếu thiếu thời gian).
4. **Nhật ký**: chỉ vào các dòng mới nhất của `nv01`: Đặt vé, Thanh toán, Thêm dịch vụ, Hủy vé.
5. **Tổng quan** hoặc **Báo cáo**: chỉ vào doanh thu đã thay đổi so với bước 1.

**Lời nói**
> Em đăng nhập bằng tài khoản quản trị. Thầy cô thấy có thêm ba menu: Máy bay, Tài khoản, Nhật ký.
>
> Ở màn Máy bay, quản trị viên chỉ cần nhập số hàng cho từng hạng, hệ thống tự sinh ghế. Khi tạo chuyến bay, toàn bộ ghế được sao chép sang chuyến với trạng thái Trống, kèm bảng giá 3 hạng.
>
> Đây là nhật ký hoạt động. Mọi thao tác bạn Suan vừa làm đều được ghi lại: tạo đơn, thanh toán, thêm dịch vụ, hủy vé, kèm tài khoản thực hiện và thời gian. Quản lý dùng nhật ký để đối chiếu khi có sai lệch.
>
> Cuối cùng, doanh thu ở tổng quan đã thay đổi đúng bằng số tiền thu vào trừ tiền hoàn của đơn vừa rồi.
>
> Phần demo của nhóm em đến đây là hết. Nhóm em xin cảm ơn và sẵn sàng nhận câu hỏi.

---

## Nếu có sự cố

| Tình huống | Xử lý |
|---|---|
| Không kết nối được SQL Server | Thử `.\SQLEXPRESS` thay cho `.`; kiểm tra dịch vụ *SQL Server (…)* trong Services. Nói: "Em xin một phút kiểm tra kết nối." |
| Không tìm thấy chuyến | Ngày demo đã qua ngày bay mẫu → dùng cặp chuyến khác còn xa (xem mục 0). |
| Phí hủy không phải 10% | Chuyến còn dưới 72 giờ — nói luôn: "Chuyến này còn dưới 72 giờ nên hệ thống áp 20%, đúng quy tắc." Đây cũng là một cách demo tốt. |
| Không áp được ưu đãi khách hàng mới | Khách liên hệ đã từng có đơn (ví dụ đã tập với cùng khách mà chưa dựng lại CSDL). Bỏ qua khuyến mãi, chỉ demo khứ hồi. |
| Ứng dụng treo / báo lỗi lạ | Không sửa code tại chỗ. Chuyển sang slide 18–25 giải thích bằng sơ đồ, xin demo lại cuối buổi. |

## Câu hỏi thầy cô có thể yêu cầu làm thêm trên máy

- **"Thử đặt hai quầy cùng một ghế xem."** Mở 2 cửa sổ ứng dụng, cùng chọn một ghế; cửa sổ bấm Đặt vé sau sẽ báo lỗi và không tạo đơn. Giải thích: chỉ mục duy nhất `UX_Ve_ChuyenBay_Ghe_Active` cộng với giao dịch trong `sp_DATVE`.
- **"Thử khách dưới 16 tuổi."** Thêm khách sinh năm 2015 → khi đặt vé, ô người giám hộ bắt buộc; chọn chính khách đó làm giám hộ → bị chặn.
- **"Thanh toán bằng thẻ."** Dùng số `4111 1111 1111 1111`, hạn trong tương lai, CVV bất kỳ 3 số. Đổi một chữ số → thẻ không hợp lệ (Luhn).
