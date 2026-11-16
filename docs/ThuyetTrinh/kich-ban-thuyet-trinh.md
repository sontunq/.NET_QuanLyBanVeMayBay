# Kịch bản thuyết trình — Hệ thống quản lý bán vé máy bay

Đi kèm file `slide.html` (29 slide). Mở bằng Chrome/Edge, bấm **F** để toàn màn hình, **→ / Space** để chuyển slide.
Muốn mở thẳng một slide: thêm `#số` vào cuối đường dẫn, ví dụ `slide.html#17`.

| Phần | Người trình bày | Slide | Thời lượng gợi ý |
|---|---|---|---|
| Mở đầu, bài toán, kiến trúc, CSDL, phạm vi, use case | **Ngân** | 1 – 16 | ~13 phút |
| Bán vé, giá, thanh toán, hủy vé, hạng thành viên, vòng đời | **Suan** | 17 – 28 | ~15 phút |
| Kết, hỏi đáp | Cả hai | 29 | 5 – 10 phút |

> Mẹo chung: sơ đồ trình tự đọc **từ trên xuống**, mỗi mũi tên là một lời gọi. Khi nói, chỉ tay theo mũi tên chứ không đọc hết chữ trên slide.

---

## PHẦN 1 — NGÂN

### Slide 1 · Bìa (20 giây)
> Em chào thầy cô và các bạn. Nhóm em xin trình bày đồ án **Hệ thống quản lý bán vé máy bay tại quầy**, viết bằng C# WinForms và SQL Server. Phần đầu em là Ngân, trình bày bài toán, kiến trúc và cơ sở dữ liệu. Phần sau bạn Suan trình bày các quy trình nghiệp vụ.

### Slide 2 · Bài toán (1 phút)
> Bối cảnh là một quầy bán vé: khách đến, nhân viên tìm chuyến, chọn ghế, lập đơn và thu tiền; khi khách đổi ý thì hủy vé, hoàn tiền.
>
> Nếu làm thủ công sẽ gặp bốn vấn đề: hai quầy có thể bán trùng một ghế, tính giá dễ sai khi cộng nhiều ưu đãi, phí hủy tính tay khó đối chiếu, và không theo dõi được chi tiêu để xếp hạng khách.
>
> Hệ thống của nhóm giải quyết các vấn đề đó: sơ đồ ghế trực quan và chống bán trùng, một đơn chứa được nhiều vé, giá tính tự động với trần giảm 30%, ba phương thức thanh toán, và hủy vé tính phí theo thời gian.
>
> Người dùng là nhân viên quầy và quản trị viên. Khách hàng không dùng phần mềm, thông tin khách do nhân viên nhập.

### Slide 3 · Con số (40 giây)
> Nhìn nhanh quy mô: CSDL có **18 bảng, 7 view, 17 thủ tục, 1 trigger**, tất cả nằm trong **một file SQL duy nhất**. Ứng dụng có 10 màn hình, trong đó 3 màn hình chỉ quản trị viên thấy. Dữ liệu mẫu có 15 sân bay, 4 máy bay mỗi chiếc 56 ghế, 46 chuyến bay và 40 khách hàng để demo.

### Slide 4 · Cấu trúc thư mục (1 phút)
> Thư mục chia theo lớp: `GUI` là giao diện, `BLL` là nghiệp vụ, `DAL` là truy cập dữ liệu, `DTO` là các đối tượng truyền giữa các lớp. `Controls` chứa các control tự vẽ như sơ đồ ghế, thẻ chuyến bay, biểu đồ. `Database` chứa file SQL.
>
> Quy ước tên: `frm` là hộp thoại, `uc` là màn hình nằm trong khung chính; `sp_` là thủ tục, `V_` là view. Chương trình chạy từ `Program.cs`, mở màn đăng nhập, đăng nhập xong mở `frmMain`.

### Slide 5 · Kiến trúc 3 lớp (1 phút 30)
> Ứng dụng theo kiến trúc **3 lớp**, đọc sơ đồ từ trên xuống.
>
> **GUI** chỉ hiển thị và nhận thao tác, không viết SQL. **BLL** kiểm tra dữ liệu và quy tắc nghiệp vụ, nếu sai thì ném `LoiNghiepVu` để báo lỗi dễ hiểu. **DAL** gọi thủ tục SQL với tham số; lớp `DataProvider` có hàm `ChayTrongGiaoDich` để gom nhiều thủ tục vào **một giao dịch**.
>
> Nguyên tắc: mỗi lớp chỉ gọi lớp ngay dưới nó. Quy tắc quan trọng được kiểm tra **hai lần**: ở BLL để báo sớm cho người dùng, và trong thủ tục SQL để vẫn đúng khi nhiều quầy cùng thao tác.

### Slide 6 · Một thao tác qua 3 lớp (1 phút)
> Ví dụ thêm khách hàng. Giao diện gọi `KhachHangBLL.Luu`, BLL nhờ `KiemTraDuLieu` chuẩn hóa họ tên, số điện thoại, email, giấy tờ.
>
> Có hai loại lỗi. **Lỗi nghiệp vụ**, ví dụ email sai dạng, hoặc thủ tục SQL `THROW` mã từ 50000 trở lên, hiện hộp **cảnh báo** màu vàng với câu dễ hiểu. **Lỗi hệ thống**, ví dụ mất kết nối, hiện hộp **lỗi**. Với thao tác nhiều bước, bước nào lỗi thì hoàn tác toàn bộ.

### Slide 7 · 18 bảng, 6 nhóm (1 phút)
> 18 bảng chia 6 nhóm: danh mục, đội bay, khai thác, giao dịch, con người, kiểm soát.
>
> Có ba ý thiết kế đáng chú ý. Một: **ghế của máy bay** tách khỏi **ghế trên chuyến bay**, vì một máy bay bay nhiều chuyến, mỗi chuyến có trạng thái ghế riêng. Hai: **giá theo chuyến và hạng**, nên cùng hạng phổ thông nhưng mỗi chuyến một giá. Ba: **đơn** là một lần giao dịch, còn **vé** là một chỗ ngồi của một hành khách.

### Slide 8 · ERD tổng thể (1 phút 30)
> Đây là ERD tổng thể. Ký hiệu chân gà: hai gạch là "đúng một", vòng tròn là "có thể không có", chân gà là "nhiều".
>
> Trục chính là `DONDATVE → VE → VEDICHVU`, cùng `THANHTOAN` và `HUYVE`: đó là toàn bộ dòng tiền của một lần bán. Một đơn có **từ 1 đến nhiều vé**. Khuyến mãi gắn vào đơn nhưng có thể trống, vì khóa ngoại cho phép NULL. Mỗi vé có thể bị hủy **tối đa một lần**.

### Slide 9 · Phân tích ERD — giao dịch (1 phút 30)
> Em phân tích kỹ phần giao dịch, có 4 ý.
>
> Thứ nhất, bảng `VE` lưu **giá gốc và từng loại phần trăm giảm** tại thời điểm bán, giống "ảnh chụp" giá. Sau này đổi giá hay khách lên hạng, vé cũ vẫn giữ đúng số tiền đã bán.
>
> Thứ hai, bảng `KHACHHANG` đóng ba vai: khách liên hệ của đơn, hành khách của vé, và người giám hộ cho trẻ em.
>
> Thứ ba, `THANHTOAN` giống sổ thu chi: một đơn có nhiều dòng, gồm lần thu đầu, thu thêm khi mua dịch vụ, và dòng "Đã hoàn" khi hủy vé.
>
> Thứ tư, `HUYVE.MaVe` là `UNIQUE`, nên mỗi vé chỉ hủy một lần.

### Slide 10 · Ghế, giá, ràng buộc (1 phút 30)
> Ba bảng trung gian dùng **khóa chính ghép**: giá vé theo (chuyến, hạng), trạng thái ghế theo (chuyến, ghế), và dịch vụ của vé theo (vé, dịch vụ) — nên một dịch vụ chỉ xuất hiện một lần trên một vé.
>
> Bảng chuyến bay có hai khóa ngoại cùng trỏ vào bảng sân bay — điểm đi và điểm đến — kèm ràng buộc hai sân bay phải khác nhau.
>
> Điểm em muốn nhấn mạnh là **chỉ mục duy nhất có lọc** trên bảng vé. Chỉ mục thứ nhất đảm bảo một ghế trên một chuyến chỉ có một vé chưa hủy, nên **không thể bán trùng ghế** kể cả khi hai quầy bấm cùng lúc. Chỉ mục thứ hai đảm bảo **mỗi hành khách chỉ một ghế trên một chuyến**. Vé đã hủy không tính, nên ghế được bán lại.
>
> Ngoài ra có các CHECK: phần trăm giảm từ 0 đến 30, tiền không âm, trạng thái chỉ nhận giá trị trong danh sách, và cột thành tiền dịch vụ là cột tính tự động.

### Slide 11 · View và trigger (1 phút)
> Có 7 view, mỗi view gom các phép JOIN hay dùng: chi tiết chuyến bay để tìm chuyến, sơ đồ ghế, chi tiết vé, lịch sử giao dịch, và các view doanh thu cho báo cáo.
>
> Trigger `trg_GHINHATKY` gắn trên bảng tài khoản, chạy sau khi thêm, sửa hoặc xóa. Nó so sánh hai bảng ảo `inserted` và `deleted` để biết là thao tác gì, rồi tự ghi nhật ký. Các thao tác khác như đặt vé, thanh toán, hủy vé thì thủ tục tự ghi nhật ký.

### Slide 12 · 17 thủ tục (1 phút)
> 17 thủ tục chia nhóm. Nhóm quan trọng nhất là **đặt vé theo luồng mới**: tạo đơn, rồi thêm từng vé, rồi xác nhận đơn. Thủ tục `sp_DATVE` cũ chỉ cho tối đa 2 vé, nay vẫn giữ để tương thích nhưng ứng dụng không gọi nữa.
>
> Các thủ tục ghi dữ liệu đều theo một mẫu: mở giao dịch, khóa dòng cần sửa, kiểm tra quy tắc và `THROW` nếu sai, ghi dữ liệu và nhật ký, rồi `COMMIT`; lỗi thì `ROLLBACK`.

### Slide 13 · Quy tắc nhập liệu khách hàng (1 phút)
> Dữ liệu khách được kiểm tra và **chuẩn hóa** trước khi lưu. Họ tên chỉ gồm chữ cái, cho phép dấu nháy và gạch nối cho tên nước ngoài. CCCD đúng 12 số. Hộ chiếu 6 đến 9 ký tự có ít nhất một số. Giấy khai sinh chỉ dùng cho trẻ dưới 14 tuổi.
>
> Số điện thoại Việt Nam được lưu thống nhất dạng `+84`, số nước ngoài phải có mã quốc gia. Email lưu chữ thường.
>
> Ở mức CSDL, số giấy tờ là duy nhất. Khi đặt vé còn có quy tắc: hành khách dưới 16 tuổi tính tại ngày bay phải có người giám hộ từ 18 tuổi.

### Slide 14 · Phạm vi (1 phút)
> Bên trái là những gì hệ thống làm: quản lý chuyến bay và ghế, khách hàng và hạng thành viên, đặt **nhiều vé trong một đơn**, tự nhận khứ hồi, dịch vụ đi kèm thêm được **cả sau khi đã thanh toán**, ba phương thức thanh toán, hủy vé và báo cáo.
>
> Bên phải là những gì **không** làm: khách tự đặt online, kết nối cổng thanh toán thật — thẻ và chuyển khoản trong demo là mô phỏng —, check-in, đổi vé. Ưu đãi Tết đã ngừng áp dụng. Việc tự chuyển vé sang "Đã bay" và khóa ghế trên giao diện thì chưa làm.

### Slide 15 · Tác nhân, phân quyền (40 giây)
> Có hai tác nhân dùng phần mềm. Nhân viên dùng 7 màn hình nghiệp vụ. Quản trị viên có toàn bộ quyền của nhân viên, thêm 3 màn hình quản lý máy bay, tài khoản và nhật ký — ba nút này bị ẩn khi nhân viên đăng nhập.

### Slide 16 · Use case (1 phút)
> Sơ đồ use case tóm tắt chức năng. Đặt vé **include** tìm chuyến, vì luôn bắt đầu bằng tìm chuyến. Hủy vé **extend** tra cứu vé. Quản trị viên **kế thừa** toàn bộ use case của nhân viên.
>
> Tiếp theo, em mời bạn Suan trình bày chi tiết các quy trình nghiệp vụ.

---

## PHẦN 2 — SUAN

### Slide 17 · Bán vé — luồng nghiệp vụ (1 phút 30)
> Cảm ơn Ngân. Em bắt đầu với quy trình bán vé. Dòng trên là phần **chọn vé**: tìm chuyến, chọn ghế trống và hành khách; nếu hành khách dưới 16 tuổi thì chọn người giám hộ; rồi thêm vé vào giỏ. Muốn thêm vé thì quay lại — chọn hành khách khác hoặc chuyến khác, ví dụ chiều về.
>
> Dòng dưới là phần **chốt đơn**: chọn khách liên hệ, mã khuyến mãi, xem giá từng vé; hộp xác nhận liệt kê từng vé trước khi đặt; đặt xong đơn ở trạng thái "Chờ thanh toán".
>
> Điểm mới so với bản trước: **một đơn không giới hạn số vé**, nhưng **mỗi hành khách chỉ một ghế trên một chuyến**. Giỏ vé nằm ở giao diện, chỉ khi bấm "Đặt vé" mới ghi vào CSDL.

### Slide 18 · Bán vé — trình tự (2 phút)
> Đây là trình tự khi đặt vé. Khi thêm vé vào giỏ, BLL kiểm tra trùng ghế, trùng khách ngay. Sang bước 3, BLL gọi `sp_TINHTHUGIAVE` **cho từng vé** để hiện giá.
>
> Khi bấm Đặt vé, phần nền xanh là **một giao dịch duy nhất**: gọi `sp_TAODONNHIEUVE` để tạo đơn và kiểm tra khuyến mãi; với mỗi vé gọi `sp_THEMVEDON` — thủ tục này khóa đơn, kiểm tra ghế và tuổi, tính giá, chuyển ghế sang "Đã đặt", tính lại khứ hồi và tổng đơn; cuối cùng ghi nhật ký và `sp_XACNHANDON` trả kết quả.
>
> Vì sao phải gói trong một giao dịch? Nếu vé thứ ba lỗi, ví dụ ghế vừa bị quầy khác đặt, thì **cả đơn được hoàn tác**: không có đơn rác, không giữ ghế, không mất lượt khuyến mãi. Nhóm đã kiểm thử đúng tình huống này.

### Slide 19 · Quy tắc tính giá (2 phút)
> Công thức: **giá thực trả bằng giá gốc nhân (1 trừ tổng phần trăm giảm)**. Tổng giảm cộng dồn ba loại nhưng **không quá 30%**. Dịch vụ đi kèm không được giảm.
>
> Ba loại giảm: **hạng thành viên** của hành khách, từ 0 đến 15%; **khứ hồi** 10%, hệ thống tự nhận khi cùng một hành khách có vé tuyến ngược lại trong đơn, áp cho cả hai vé; và **mã khuyến mãi**. Riêng ưu đãi khách hàng mới chỉ dùng được khi **khách liên hệ chưa từng có đơn**.
>
> Ví dụ bên phải: vé 900 nghìn, khách hạng Vàng 10%, có vé chiều về 10%, dùng mã khách mới 3%, tổng 23%, trả 693 nghìn.
>
> Mã khuyến mãi có thể có mức giảm tối đa bằng tiền. Ví dụ vé thương gia 18 triệu, mã 3% tối đa 300 nghìn: 3% là 540 nghìn, vượt trần, nên hệ thống quy đổi 300 nghìn trên 18 triệu bằng 1,67% và lấy phần nguyên là 1%.

### Slide 20 · Tính giá — luồng và trình tự (1 phút)
> Sơ đồ trái là luồng tính: bốn nguồn — giá gốc, hạng, khứ hồi, khuyến mãi — cộng dồn, so với trần 30%, rồi ra giá thực trả.
>
> Sơ đồ phải: mỗi khi đổi mã khuyến mãi hoặc khách liên hệ, giao diện tính lại giá. Khi đặt thật, `sp_THEMVEDON` **tính lại từ CSDL**, không tin con số từ giao diện. Hai bên dùng cùng công thức, nên giá xem trước khớp giá lưu thật — kiểm thử đơn 5 vé đều ra 4.320.000 đồng.

### Slide 21 · Thanh toán — luồng (1 phút 30)
> Mở thanh toán, hệ thống từ chối nếu đơn đã hủy hoặc không còn gì phải thu. Có ba phương thức. **Tiền mặt**: nhập tiền khách đưa, đủ thì hiện tiền thối. **Chuyển khoản**: hiện mã VietQR có sẵn số tài khoản, số tiền và nội dung "DH" cộng mã đơn; nhân viên kiểm tra ngân hàng rồi tick đã nhận tiền. **Thẻ**: kiểm tra số thẻ bằng thuật toán Luhn, loại thẻ, tên chủ thẻ, hạn; chỉ lưu loại thẻ và 4 số cuối.
>
> Số tiền phải thu tính theo công thức ở khung vàng: tổng đơn trừ đi phần khách đã trả thực — tức đã thu, trừ đã hoàn, trừ phí hủy đã giữ. Phải thu đúng bằng số này, không thu một phần.

### Slide 22 · Thanh toán và thu thêm dịch vụ — trình tự (1 phút 30)
> Phần trên là thêm dịch vụ. Nhân viên **tick các dịch vụ trong checklist**; mỗi dịch vụ một lần cho một vé, dịch vụ vé đã có thì hiện "đã có". Tất cả dịch vụ được lưu chung một giao dịch. Đơn giá lấy từ CSDL.
>
> Nếu đơn **đã thanh toán**, hệ thống báo số tiền còn phải thu và hỏi thu ngay. Phần dưới là thanh toán: `sp_THANHTOANDON` khóa đơn, kiểm tra số tiền khớp, ghi thanh toán, chuyển đơn sang "Đã thanh toán", cộng chi tiêu cho từng hành khách và xét lại hạng.

### Slide 23 · Hủy vé — phí và tiền hoàn (2 phút)
> Phí hủy tính trên giá thực trả của vé, theo thời gian còn lại: từ 72 giờ trở lên 10%, từ 24 đến dưới 72 giờ 20%, dưới 24 giờ 30%. Không cho hủy nếu vé đã hủy, đã bay, chuyến đã khởi hành, hoặc hạng vé không cho hủy.
>
> Với đơn **đã thanh toán**, hệ thống tính phần khách **trả dư** nếu bỏ vé này ra khỏi đơn, rồi trừ phí; số còn lại là tiền hoàn. Cách tính này hoàn cả tiền dịch vụ của vé, và nếu đơn còn nợ tiền dịch vụ thì khoản nợ được trừ thẳng vào tiền hoàn.
>
> Với đơn **chưa thanh toán**: không phí, không hoàn; các vé còn lại được tính lại khứ hồi — hủy một chiều thì chiều kia mất 10%.
>
> Ví dụ đã kiểm thử ở dòng cuối: vé 810 nghìn cộng 700 nghìn dịch vụ, còn khoảng hai ngày rưỡi, phí 20% là 162 nghìn, hoàn 1.348.000 đồng.

### Slide 24 · Hủy vé — luồng (1 phút)
> Dòng trên: kiểm tra điều kiện, xem trước phí và nhập lý do, rồi rẽ hai nhánh — đơn chưa trả thì phí 0; đơn đã trả thì tính phí, ghi dòng "Đã hoàn", trừ chi tiêu và xét lại hạng.
>
> Dòng dưới: ghi phiếu hủy, xóa dịch vụ của vé, vé thành "Đã hủy", ghế thành "Trống" để bán lại, tính lại tổng đơn. Nếu mọi vé trong đơn đều đã hủy thì đơn thành "Đã hủy".

### Slide 25 · Hủy vé — trình tự (1 phút)
> Màn hủy vé lấy thông tin vé, báo sớm nếu không hủy được, rồi gọi BLL tính **phí xem trước**. BLL dùng **cùng công thức với thủ tục**, kể cả cách làm tròn, nên số trên màn hình khớp số thật. Khi xác nhận, `sp_HUYVE` khóa vé, kiểm tra lại, và thực hiện toàn bộ trong một giao dịch.

### Slide 26 · Hạng thành viên (1 phút 30)
> Hạng tính theo tổng chi tiêu, bằng tiền vé cộng dịch vụ đã thanh toán, trừ tiền đã hoàn. Năm hạng: Thành viên 0%, Bạc từ 20 triệu giảm 8%, Vàng từ 40 triệu giảm 10%, Bạch Kim từ 50 triệu giảm 12%, Kim Cương từ 100 triệu giảm 15%.
>
> Hạng được xét lại sau mỗi lần thanh toán và mỗi lần hủy vé có hoàn tiền.
>
> Nhóm cũng nêu thẳng một **hạn chế**: hạng có hiệu lực một năm tính từ giao dịch đầu tiên và hiện **chưa tự gia hạn**, nên sau một năm khách về hạng Thành viên dù vẫn mua vé. Đây là hướng cải tiến tiếp theo.

### Slide 27 · Vòng đời đơn, vé, ghế (1 phút 30)
> Đơn đặt vé: tạo ra ở "Chờ thanh toán"; thu đủ tiền thì "Đã thanh toán"; hủy hết vé thì "Đã hủy". Đơn đã thanh toán vẫn ở trạng thái đó khi thêm dịch vụ — chỉ phát sinh khoản cần thu thêm.
>
> Vé: "Đã đặt" sang "Đã hủy". Ghế trên chuyến: "Trống" sang "Đã đặt" khi đặt, về "Trống" khi hủy. Các trạng thái có dấu sao như vé "Đã bay" hay ghế "Khóa" có trong CSDL nhưng chưa có chức năng trên giao diện.

### Slide 28 · Vòng đời chuyến bay (1 phút)
> Chuyến bay tạo ra ở "Đang mở bán", hệ thống tự sinh bảng giá ba hạng và toàn bộ ghế trống. Nhân viên đổi trạng thái thủ công: đóng bán, mở lại, đã bay, hoặc hủy chuyến. Chỉ chuyến đang mở bán và chưa khởi hành mới bán được vé. Bảng bên phải là trạng thái của các đối tượng còn lại.

### Slide 29 · Kết (30 giây — Ngân hoặc Suan)
> Tóm lại, hệ thống theo kiến trúc 3 lớp, CSDL có 18 bảng, 7 view, 17 thủ tục và 1 trigger; đặt nhiều vé trong một giao dịch an toàn; giá tính tự động với trần 30%; và hoàn tiền đúng số khách đã trả. Nhóm em xin cảm ơn thầy cô và các bạn đã lắng nghe, và sẵn sàng demo trực tiếp hoặc trả lời câu hỏi.

---

## Gợi ý demo trực tiếp (nếu được yêu cầu, ~5 phút)

Đăng nhập `nv01` / `123456`.

1. **Đặt vé** → tìm HAN → DAD → chọn chuyến → thêm 2 hành khách khác nhau. Quay lại bước 1 chọn chuyến DAD → HAN cho một trong hai người → sang bước 3: ô "Vé khứ hồi" tự tick, chỉ 2 vé của người đó giảm 10%.
2. Thử chọn **cùng hành khách, cùng chuyến** lần nữa → hệ thống báo mỗi hành khách chỉ 1 ghế/chuyến.
3. Bấm Đặt vé → hộp xác nhận liệt kê từng vé → Đặt vé → **Thanh toán** tiền mặt.
4. **Đơn đặt vé** → chọn vé → **Thêm dịch vụ**: tick 2 dịch vụ → hệ thống hỏi thu thêm → thu.
5. **Hủy vé** một vé của đơn đó: xem trước phí và tiền hoàn (gồm dịch vụ) → xác nhận → số thực tế khớp.
6. Đăng nhập `admin` / `admin123` để cho thấy 3 menu quản trị và **Nhật ký** có các thao tác vừa làm.

> Lưu ý: ngày bay trong dữ liệu mẫu là ngày cố định (16/11 – 13/12/2026). Nếu demo vào ngày khác, kiểm tra trước còn chuyến chưa khởi hành.

---

## Câu hỏi có thể gặp

**Hỏi: Nếu hai quầy cùng đặt một ghế thì sao?**
Đáp: Chỉ mục duy nhất `UX_Ve_ChuyenBay_Ghe_Active` chỉ cho một vé chưa hủy trên mỗi (chuyến, ghế). Quầy đến sau nhận lỗi, và vì đặt vé chạy trong một giao dịch nên toàn bộ đơn của quầy đó được hoàn tác.

**Hỏi: Vì sao lưu phần trăm giảm trên từng vé mà không tính lại khi cần?**
Đáp: Để giữ đúng số tiền tại thời điểm bán. Giá vé, hạng thành viên, khuyến mãi đều có thể thay đổi sau đó.

**Hỏi: Vì sao vừa kiểm tra ở BLL vừa kiểm tra trong thủ tục?**
Đáp: BLL báo lỗi sớm và dễ hiểu khi nhân viên còn đang nhập. Thủ tục là chốt chặn cuối, đúng cả khi dữ liệu thay đổi giữa lúc xem và lúc ghi, hoặc nhiều người thao tác cùng lúc.

**Hỏi: Khứ hồi được nhận diện thế nào?**
Đáp: Trong cùng một đơn, cùng một hành khách có hai vé với sân bay đi và đến đảo ngược nhau. Hệ thống tự nhận, giảm 10% cho cả hai vé; người dùng không tự tick được.

**Hỏi: Đơn đã thanh toán mà thêm dịch vụ thì tiền tính thế nào?**
Đáp: Tổng đơn tăng thêm tiền dịch vụ. Số còn phải thu bằng tổng đơn trừ phần khách đã trả thực (đã thu − đã hoàn − phí hủy đã giữ). Nhân viên thu đúng phần chênh lệch đó qua màn thanh toán.

**Hỏi: Khách hủy vé khi đơn còn nợ tiền dịch vụ thì hoàn bao nhiêu?**
Đáp: Hệ thống tính phần khách trả dư nếu bỏ vé ra khỏi đơn, trừ phí hủy, nên khoản nợ tự được trừ vào tiền hoàn và sau khi hủy đơn không còn nợ.

**Hỏi: Ưu đãi khách hàng mới xét theo ai?**
Đáp: Theo **khách liên hệ** của đơn: khách liên hệ chưa từng có đơn nào thì được dùng. Khi xem giá và khi đặt thật đều xét cùng một người.

**Hỏi: Hạn chế lớn nhất hiện tại?**
Đáp: Hạng thành viên chưa tự gia hạn sau 1 năm; vé chưa tự chuyển "Đã bay"; chưa có màn khóa ghế; thanh toán thẻ và chuyển khoản là mô phỏng.
