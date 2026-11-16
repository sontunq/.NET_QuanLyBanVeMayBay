using System;
using System.Data;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportAppServer.ClientDoc;
using CrystalDecisions.ReportAppServer.DataDefModel;
using CrystalDecisions.ReportAppServer.ReportDefModel;
using RasFont = CrystalDecisions.ReportAppServer.ReportDefModel.Font;
using Section = CrystalDecisions.ReportAppServer.ReportDefModel.Section;
using Border = CrystalDecisions.ReportAppServer.ReportDefModel.Border;
using TextObject = CrystalDecisions.ReportAppServer.ReportDefModel.TextObject;
using FieldObject = CrystalDecisions.ReportAppServer.ReportDefModel.FieldObject;
using ReportDefinition = CrystalDecisions.ReportAppServer.ReportDefModel.ReportDefinition;
using ObjectFormat = CrystalDecisions.ReportAppServer.ReportDefModel.ObjectFormat;
using ReportDocument = CrystalDecisions.CrystalReports.Engine.ReportDocument;
using DataSet = System.Data.DataSet;
using CrystalDecisions.ReportAppServer.Controllers;

namespace BaoCao
{
    /// <summary>
    /// Sinh các mẫu báo cáo .rpt bằng code (Crystal ReportAppServer API), từ mẫu trắng CrystalReport.rpt.
    /// Chạy:  BaoCao.exe --tao-mau "đường dẫn mẫu trắng" "thư mục lưu"
    /// Kết quả (rptHoaDon.rpt, rptDoanhThu.rpt) mở được bằng trình thiết kế Crystal trong Visual Studio để chỉnh tiếp.
    /// Đơn vị đo: twip (1 cm ≈ 567 twip).
    /// </summary>
    public static class MauBaoCao
    {
        private const int Trai = 0;          // lề trái nội dung
        private const int Rong = 10500;      // bề rộng nội dung
        private const string FontChu = "Arial";

        // Màu theo COLORREF (0x00BBGGRR)
        private static uint Mau(int r, int g, int b) => (uint)(r | (g << 8) | (b << 16));
        private static readonly uint MauChinh = Mau(14, 74, 92);
        private static readonly uint MauNhat = Mau(230, 240, 243);
        private static readonly uint MauChuPhu = Mau(90, 100, 110);
        private static readonly uint MauTrang = Mau(255, 255, 255);

        public static void TaoTatCa(string mauTrang, string thuMuc)
        {
            Directory.CreateDirectory(thuMuc);
            TaoHoaDon(mauTrang, thuMuc);
            TaoDoanhThu(mauTrang, thuMuc);
        }

        // =========================================================
        // Hóa đơn đặt vé
        // =========================================================
        private static void TaoHoaDon(string mauTrang, string thuMuc)
        {
            using (var rpt = new ReportDocument())
            {
                rpt.Load(mauTrang);
                ISCDReportClientDocument doc = rpt.ReportClientDocument;
                ThemNguon(doc, CauTrucDuLieu.BangHoaDon);
                string b = CauTrucDuLieu.BangHoaDon;

                // ---- Đầu báo cáo: tiêu đề + thông tin đơn
                Section dau = Muc(doc, "RH");
                ChuCao(doc, dau, 1900);
                Chu(doc, dau, "HÓA ĐƠN ĐẶT VÉ MÁY BAY", Trai, 0, Rong, 450, 16, true, MauChinh, CrAlignmentEnum.crAlignmentHorizontalCenter);
                Chu(doc, dau, "Hệ thống quản lý bán vé máy bay tại quầy", Trai, 450, Rong, 280, 9, false, MauChuPhu, CrAlignmentEnum.crAlignmentHorizontalCenter);

                int y = 900, nhan = 1500, gt = 3600;
                NhanVaTruong(doc, dau, b, "Mã đơn:", "MaDon", Trai, y, nhan, gt);
                NhanVaTruong(doc, dau, b, "Ngày đặt:", "NgayDat", 5400, y, nhan - 300, gt - 300);
                y += 300;
                NhanVaTruong(doc, dau, b, "Khách liên hệ:", "KhachLienHe", Trai, y, nhan, gt);
                NhanVaTruong(doc, dau, b, "Điện thoại:", "SoDienThoai", 5400, y, nhan - 300, gt - 300);
                y += 300;
                NhanVaTruong(doc, dau, b, "Nhân viên:", "NhanVien", Trai, y, nhan, gt);
                NhanVaTruong(doc, dau, b, "Trạng thái:", "TrangThaiDon", 5400, y, nhan - 300, gt - 300);

                // ---- Đầu trang: tiêu đề cột
                var cot = new (string ten, string truong, int rong, bool phai)[]
                {
                    ("Mã vé", "MaVe", 750, false), ("Hành khách", "HanhKhach", 2150, false), ("Tuyến", "Tuyen", 1150, false),
                    ("Khởi hành", "KhoiHanh", 1550, false), ("Ghế", "SoGhe", 600, false), ("Hạng vé", "HangVe", 1400, false),
                    ("Giá gốc", "GiaGoc", 1150, true), ("Giảm", "Giam", 550, true), ("Thành tiền", "GiaThucTra", 1200, true)
                };
                Section dauTrang = Muc(doc, "PH");
                ChuCao(doc, dauTrang, 380);
                int x = Trai;
                foreach (var c in cot)
                {
                    Chu(doc, dauTrang, c.ten, x, 40, c.rong, 300, 9, true, MauTrang,
                        c.phai ? CrAlignmentEnum.crAlignmentRight : CrAlignmentEnum.crAlignmentLeft, nen: MauChinh);
                    x += c.rong;
                }

                // ---- Chi tiết: mỗi dòng một vé
                Section ct = Muc(doc, "D");
                ChuCao(doc, ct, 320);
                x = Trai;
                foreach (var c in cot)
                {
                    Truong(doc, ct, b, c.truong, x, 30, c.rong, 260, 9, false,
                        c.phai ? CrAlignmentEnum.crAlignmentRight : CrAlignmentEnum.crAlignmentLeft, gachDuoi: true);
                    x += c.rong;
                }

                // ---- Cuối báo cáo: tổng tiền
                Section cuoi = Muc(doc, "RF");
                ChuCao(doc, cuoi, 1900);
                int xn = 6000, rn = 2300, xg = 8300, rg = 2200;
                y = 200;
                NhanVaTruong(doc, cuoi, b, "Tiền vé:", "TongTienVe", xn, y, rn, rg, phai: true);
                y += 300;
                NhanVaTruong(doc, cuoi, b, "Dịch vụ đi kèm:", "TongTienDichVu", xn, y, rn, rg, phai: true);
                y += 300;
                NhanVaTruong(doc, cuoi, b, "Đã giảm (trong giá vé):", "GiamKhuyenMai", xn, y, rn, rg, phai: true);
                y += 330;
                Chu(doc, cuoi, "TỔNG THANH TOÁN:", xn, y, rn, 320, 11, true, MauChinh, CrAlignmentEnum.crAlignmentLeft, nen: MauNhat);
                Truong(doc, cuoi, b, "TongThanhToan", xg, y, rg, 320, 11, true, CrAlignmentEnum.crAlignmentRight, MauChinh, MauNhat);
                y += 380;
                NhanVaTruong(doc, cuoi, b, "Đã thu:", "DaThu", xn, y, rn, rg, phai: true);
                Chu(doc, cuoi, "Cảm ơn quý khách đã sử dụng dịch vụ!", Trai, 400, 5500, 300, 9, false, MauChuPhu, CrAlignmentEnum.crAlignmentLeft, nghieng: true);

                // ---- Cuối trang: ngày in
                Section ctrang = Muc(doc, "PF");
                ChuCao(doc, ctrang, 350);
                NhanVaTruong(doc, ctrang, b, "Ngày in:", "NgayIn", Trai, 50, 900, 2500, co: 8);

                Luu(doc, thuMuc, "rptHoaDon.rpt");
            }
        }

        // =========================================================
        // Báo cáo doanh thu theo tháng
        // =========================================================
        private static void TaoDoanhThu(string mauTrang, string thuMuc)
        {
            using (var rpt = new ReportDocument())
            {
                rpt.Load(mauTrang);
                ISCDReportClientDocument doc = rpt.ReportClientDocument;
                ThemNguon(doc, CauTrucDuLieu.BangDoanhThu);
                string b = CauTrucDuLieu.BangDoanhThu;

                Section dau = Muc(doc, "RH");
                ChuCao(doc, dau, 1050);
                Chu(doc, dau, "BÁO CÁO DOANH THU THEO THÁNG", Trai, 0, Rong, 450, 16, true, MauChinh, CrAlignmentEnum.crAlignmentHorizontalCenter);
                Chu(doc, dau, "Doanh thu thuần = tiền đã thu − tiền đã hoàn cho khách", Trai, 450, Rong, 280, 9, false, MauChuPhu, CrAlignmentEnum.crAlignmentHorizontalCenter);

                var cot = new (string ten, string truong, int rong, bool phai)[]
                {
                    ("Tháng", "Thang", 2300, false), ("Số đơn", "SoDon", 1300, true), ("Tiền thu", "TienThu", 2300, true),
                    ("Tiền hoàn", "TienHoan", 2300, true), ("Doanh thu thuần", "DoanhThu", 2300, true)
                };
                Section dauTrang = Muc(doc, "PH");
                ChuCao(doc, dauTrang, 380);
                int x = Trai;
                foreach (var c in cot)
                {
                    Chu(doc, dauTrang, c.ten, x, 40, c.rong, 300, 9, true, MauTrang,
                        c.phai ? CrAlignmentEnum.crAlignmentRight : CrAlignmentEnum.crAlignmentLeft, nen: MauChinh);
                    x += c.rong;
                }

                Section ct = Muc(doc, "D");
                ChuCao(doc, ct, 320);
                x = Trai;
                foreach (var c in cot)
                {
                    Truong(doc, ct, b, c.truong, x, 30, c.rong, 260, 9, false,
                        c.phai ? CrAlignmentEnum.crAlignmentRight : CrAlignmentEnum.crAlignmentLeft, gachDuoi: true);
                    x += c.rong;
                }

                // Dòng tổng cộng
                Section cuoi = Muc(doc, "RF");
                ChuCao(doc, cuoi, 500);
                string[] tong = { null, "TongSoDon", "TongTienThu", "TongTienHoan", "TongDoanhThu" };
                x = Trai;
                for (int i = 0; i < cot.Length; i++)
                {
                    if (tong[i] == null)
                        Chu(doc, cuoi, "TỔNG CỘNG", x, 80, cot[i].rong, 320, 10, true, MauChinh, CrAlignmentEnum.crAlignmentLeft, nen: MauNhat);
                    else
                        Truong(doc, cuoi, b, tong[i], x, 80, cot[i].rong, 320, 10, true, CrAlignmentEnum.crAlignmentRight, MauChinh, MauNhat);
                    x += cot[i].rong;
                }

                Section ctrang = Muc(doc, "PF");
                ChuCao(doc, ctrang, 350);
                NhanVaTruong(doc, ctrang, b, "Ngày in:", "NgayIn", Trai, 50, 900, 2500, co: 8);

                Luu(doc, thuMuc, "rptDoanhThu.rpt");
            }
        }

        // =========================================================
        // Hàm hỗ trợ
        // =========================================================
        private static void ThemNguon(ISCDReportClientDocument doc, string tenBang)
        {
            var ds = new DataSet("dsBaoCao");
            ds.Tables.Add(CauTrucDuLieu.TaoBang(tenBang));
            // DataSet của .NET phải chuyển sang dạng Crystal hiểu được trước khi gắn vào báo cáo
            doc.DatabaseController.AddDataSource(CrystalDecisions.ReportAppServer.DataSetConversion.DataSetConverter.Convert(ds));
        }

        /// <summary>Lấy section đầu tiên của một vùng: RH, PH, D, RF, PF.</summary>
        private static Section Muc(ISCDReportClientDocument doc, string vung)
        {
            ReportDefinition def = doc.ReportDefController.ReportDefinition;
            ISCRArea a;
            switch (vung)
            {
                case "RH": a = def.ReportHeaderArea; break;
                case "PH": a = def.PageHeaderArea; break;
                case "D": a = def.DetailArea; break;
                case "RF": a = def.ReportFooterArea; break;
                default: a = def.PageFooterArea; break;
            }
            return a.Sections[0];
        }

        private static void ChuCao(ISCDReportClientDocument doc, Section s, int cao) =>
            doc.ReportDefController.ReportSectionController.SetProperty(s, CrReportSectionPropertyEnum.crReportSectionPropertyHeight, cao);

        private static FontColor TaoFont(int co, bool dam, uint mau, bool nghieng = false) =>
            new FontColor
            {
                Font = new RasFont { Name = FontChu, Size = co, Bold = dam, Italic = nghieng },
                Color = mau
            };

        private static Border TaoVien(uint? nen, bool gachDuoi)
        {
            var v = new Border
            {
                LeftLineStyle = CrLineStyleEnum.crLineStyleNoLine,
                RightLineStyle = CrLineStyleEnum.crLineStyleNoLine,
                TopLineStyle = CrLineStyleEnum.crLineStyleNoLine,
                BottomLineStyle = gachDuoi ? CrLineStyleEnum.crLineStyleDotted : CrLineStyleEnum.crLineStyleNoLine,
                BorderColor = Mau(200, 210, 215)
            };
            if (nen != null) v.BackgroundColor = nen.Value;
            return v;
        }

        private static void Chu(ISCDReportClientDocument doc, Section s, string noiDung, int x, int y, int rong, int cao,
                                int co, bool dam, uint mau, CrAlignmentEnum canLe, uint? nen = null, bool nghieng = false)
        {
            // Crystal lấy font ở cấp đoạn văn / phần chữ, nên phải gán FontColor ở cả hai cấp
            var phan = new ParagraphTextElement
            {
                Kind = CrParagraphElementKindEnum.crParagraphElementKindText,
                Text = noiDung,
                FontColor = TaoFont(co, dam, mau, nghieng)
            };
            var doan = new Paragraph { Alignment = canLe, ParagraphElements = new ParagraphElements(), FontColor = TaoFont(co, dam, mau, nghieng) };
            doan.ParagraphElements.Add(phan);
            var t = new TextObject
            {
                Left = x, Top = y, Width = rong, Height = cao,
                FontColor = TaoFont(co, dam, mau, nghieng),
                Paragraphs = new Paragraphs(),
                Border = TaoVien(nen, false)
            };
            t.Paragraphs.Add(doan);
            doc.ReportDefController.ReportObjectController.Add(t, s, -1);
        }

        private static void Truong(ISCDReportClientDocument doc, Section s, string bang, string truong, int x, int y, int rong, int cao,
                                   int co, bool dam, CrAlignmentEnum canLe, uint? mau = null, uint? nen = null, bool gachDuoi = false)
        {
            ISCRTable t = doc.Database.Tables.FindTableByAlias(bang);
            int i = t.DataFields.Find(truong, CrFieldDisplayNameTypeEnum.crFieldDisplayNameName,
                                      CrystalDecisions.ReportAppServer.DataDefModel.CeLocale.ceLocaleUserDefault);
            ISCRField f = t.DataFields[i];
            var fo = new FieldObject
            {
                DataSourceName = f.FormulaForm,
                FieldValueType = f.Type,
                Left = x, Top = y, Width = rong, Height = cao,
                FontColor = TaoFont(co, dam, mau ?? Mau(30, 35, 40)),
                Format = new ObjectFormat { HorizontalAlignment = canLe, EnableCanGrow = true },
                Border = TaoVien(nen, gachDuoi)
            };
            doc.ReportDefController.ReportObjectController.Add(fo, s, -1);
        }

        private static void NhanVaTruong(ISCDReportClientDocument doc, Section s, string bang, string nhan, string truong,
                                         int x, int y, int rongNhan, int rongGT, int co = 10, bool phai = false)
        {
            Chu(doc, s, nhan, x, y, rongNhan, 280, co, false, MauChuPhu, CrAlignmentEnum.crAlignmentLeft);
            Truong(doc, s, bang, truong, x + rongNhan, y, rongGT, 280, co, true,
                   phai ? CrAlignmentEnum.crAlignmentRight : CrAlignmentEnum.crAlignmentLeft);
        }

        private static void Luu(ISCDReportClientDocument doc, string thuMuc, string ten)
        {
            object thuMucObj = Path.GetFullPath(thuMuc);
            doc.SaveAs(ten, ref thuMucObj, (int)CdReportClientDocumentSaveAsOptionsEnum.cdReportClientDocumentSaveAsOverwriteExisting);
            Console.WriteLine("Đã tạo " + Path.Combine(thuMuc, ten));
        }
    }
}
