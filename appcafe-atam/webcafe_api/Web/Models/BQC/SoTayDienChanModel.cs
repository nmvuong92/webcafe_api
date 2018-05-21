using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.BQC
{
    public class SoTayGroupModel
    {
        public int GroupId { get; set; }
        public string TenGroup { get; set; }
    }
    public class SoTayDienChanModel
    {
        public int Id { get; set; }
        public int DanhMucId { get; set; }
        public string Ten { get; set; }
        public int SL { get; set; }
        public DanhMucSoTayDienChanModel DanhMucSoTayDienChanModel { get; set; }

        public int GroupId { get; set; }
        public SoTayGroupModel SoTayGroupModel { get; set; }

        public SoTayDienChanModel()
        {
            
        }
        public SoTayDienChanModel(int id, string ten, int sl = 1, SoTayGroupModel group = null)
        {
            this.Id = id;
            this.Ten = ten;
            this.SL = sl;
            if (group != null)
            {
                this.GroupId = group.GroupId;
                this.SoTayGroupModel = group;
            }
            else
            {
                this.GroupId = -1;
                this.SoTayGroupModel = new SoTayGroupModel()
                {
                    GroupId = -1,
                    TenGroup = "---"
                };
            }
        }

        public SoTayDienChanModel(string ten, int id, SoTayGroupModel group = null, int sl = 1)
        {
            this.Id = id;
            this.Ten = ten;
            this.SL = sl;
            if (group != null)
            {
                this.GroupId = group.GroupId;
                this.SoTayGroupModel = group;
            }
        }



        public static List<SoTayDienChanModel> getThuongDung(int danhmucid)
        {
            List<SoTayDienChanModel> arr = new List<SoTayDienChanModel>();
            arr.Add(new SoTayDienChanModel(1, "1. Bộ thăng"));
            arr.Add(new SoTayDienChanModel(2, "2. Bộ giáng"));
            arr.Add(new SoTayDienChanModel(3, "3. Bộ điều hòa (âm dương)"));
            arr.Add(new SoTayDienChanModel(4, "4. Bộ thuỷ hoả ký tế"));
            arr.Add(new SoTayDienChanModel(5, "5. Bộ bổ âm huyết"));
            arr.Add(new SoTayDienChanModel(6, "6. Trừ đàm thấp thủy"));
            arr.Add(new SoTayDienChanModel(7, "7. Tiêu viêm độc, tiêu bướu (2)", 2));
            arr.Add(new SoTayDienChanModel(8, "8. Tan máu bầm"));
            arr.Add(new SoTayDienChanModel(9, "9. Tứ đại huyệt"));
            arr.Add(new SoTayDienChanModel(10, "10. Phác đồ nội tiết tố"));
            arr.Add(new SoTayDienChanModel(11, "11. Phác đồ tạng phủ"));
            arr.Add(new SoTayDienChanModel(12, "12. Phác đồ suy nhược thần kinh"));
            arr.Add(new SoTayDienChanModel(13, "13. Phác đồ chỉnh nội tạng"));
            arr.ForEach(e =>
            {
                e.DanhMucId = danhmucid;
            });
            return arr;
        }
        public static List<SoTayDienChanModel> getVungCoQuan(int danhmucid)
        {
            List<SoTayDienChanModel> arr = new List<SoTayDienChanModel>();

            int groupid = 0;

            SoTayGroupModel title = new SoTayGroupModel()
            {
                GroupId = ++groupid,
                TenGroup = "ĐẦU"
            };
            arr.Add(new SoTayDienChanModel("1. Đỉnh đầu", 21, title));
            arr.Add(new SoTayDienChanModel("2. Nửa bên đầu", 22, title));
            arr.Add(new SoTayDienChanModel("3. Sau đầu gáy", 23, title));
            arr.Add(new SoTayDienChanModel("4. Trán", 24, title));
            arr.Add(new SoTayDienChanModel("5. Toàn đầu", 25, title));
            arr.Add(new SoTayDienChanModel("6. Tai", 26, title));
            arr.Add(new SoTayDienChanModel("7. Gờ mày", 27, title));
            arr.Add(new SoTayDienChanModel("8. Niệm mạc", 28, title));
            arr.Add(new SoTayDienChanModel("9. Não - thần kinh", 29, title));

            title = new SoTayGroupModel()
            {
                GroupId = ++groupid,
                TenGroup = "CƠ QUAN SINH DỤC"
            };

            arr.Add(new SoTayDienChanModel("10. Dương vật", 30, title));
            arr.Add(new SoTayDienChanModel("11. Dịch hoàn", 31, title));
            arr.Add(new SoTayDienChanModel("12. Âm hộ, âm đạo", 32, title));
            arr.Add(new SoTayDienChanModel("13. Tử cung", 33, title));
            arr.Add(new SoTayDienChanModel("14. Buồng trứng", 34, title));
            arr.Add(new SoTayDienChanModel("15. HẬU MÔN", 35, title));

            title = new SoTayGroupModel()
            {
                GroupId = ++groupid,
                TenGroup = "NỘI TẠNG"
            };

            arr.Add(new SoTayDienChanModel("16. Tim Tâm - (Tâm bào)", 36, title));
            arr.Add(new SoTayDienChanModel("17. Gan (Can)", 37, title));
            arr.Add(new SoTayDienChanModel("18. Mật (Đởm)", 38, title));
            arr.Add(new SoTayDienChanModel("19. Lá lách (Tỳ)", 39, title));
            arr.Add(new SoTayDienChanModel("20. Tụy tạng (Tỳ)", 40, title));
            arr.Add(new SoTayDienChanModel("21. Bao tử (Vị)", 41, title));
            arr.Add(new SoTayDienChanModel("22. Ruột non (Tiểu trường)", 42, title));
            arr.Add(new SoTayDienChanModel("23. Ruột già  (Đại trường)", 43, title));
            arr.Add(new SoTayDienChanModel("24. Ruột thừa", 44, title));
            arr.Add(new SoTayDienChanModel("25. Tiền liệt tuyến ", 45, title));
            arr.Add(new SoTayDienChanModel("26. phổi (phế)", 46, title));
            arr.Add(new SoTayDienChanModel("27. Thận ", 47, title));
            arr.Add(new SoTayDienChanModel("28. Bọng đái", 48, title));

            title = new SoTayGroupModel()
            {
                GroupId = ++groupid,
                TenGroup = "TUYẾN NỘI TIẾT"
            };

            arr.Add(new SoTayDienChanModel("29. Vùng dưới đồi", 49, title));
            arr.Add(new SoTayDienChanModel("30. Tuyến tùng", 50, title));
            arr.Add(new SoTayDienChanModel("31. Tuyến yên", 51, title));
            arr.Add(new SoTayDienChanModel("32. Tuyến giáp", 52, title));
            arr.Add(new SoTayDienChanModel("33. Tuyến cận giáp", 53, title));
            arr.Add(new SoTayDienChanModel("34. Tuyến ức", 5400000, title));
            arr.Add(new SoTayDienChanModel("35. Tuyến thượng thận", 54, title));
            arr.Add(new SoTayDienChanModel("36. Tuyến tụy", 55, title));
            arr.Add(new SoTayDienChanModel("37. Buồng trứng", 56, title));
            arr.Add(new SoTayDienChanModel("38. Tinh hoàn", 57, title));


            title = new SoTayGroupModel()
            {
                GroupId = ++groupid,
                TenGroup = "TRÊN MẶT"
            };
            arr.Add(new SoTayDienChanModel("39. Mắt ", 58, title));
            arr.Add(new SoTayDienChanModel("40. Mũi ", 59, title));
            arr.Add(new SoTayDienChanModel("41. Môi, miệng ", 60, title));
            arr.Add(new SoTayDienChanModel("42. Cổ ", 61, title));
            arr.Add(new SoTayDienChanModel("43. Họng ", 62, title));
            arr.Add(new SoTayDienChanModel("44. Lưỡi ", 63, title));
            arr.Add(new SoTayDienChanModel("45. Răng ", 64, title));
            arr.Add(new SoTayDienChanModel("46. Mặt ", 65, title));

            title = new SoTayGroupModel()
            {
                GroupId = ++groupid,
                TenGroup = "VAI–TAY"
            };
            arr.Add(new SoTayDienChanModel("47. Bả vai", 66, title));
            arr.Add(new SoTayDienChanModel("48. Khớp vai", 67, title));
            arr.Add(new SoTayDienChanModel("49. Cánh tay trên", 68, title));
            arr.Add(new SoTayDienChanModel("50. Khuỷu tay", 69, title));
            arr.Add(new SoTayDienChanModel("51. Cổ tay", 70, title));
            arr.Add(new SoTayDienChanModel("52. Bàn tay", 71, title));
            arr.Add(new SoTayDienChanModel("53. Các khớp ngón tay", 72, title));
            arr.Add(new SoTayDienChanModel("54. Ngón tay cái", 73, title));
            arr.Add(new SoTayDienChanModel("55. Ngón tay trỏ", 74, title));
            arr.Add(new SoTayDienChanModel("56. Ngón tay giữa", 75, title));
            arr.Add(new SoTayDienChanModel("57. Ngón tay áp út", 76, title));
            arr.Add(new SoTayDienChanModel("58. Ngón tay út", 77, title));

            title = new SoTayGroupModel()
            {
                GroupId = ++groupid,
                TenGroup = "MÔNG–ĐÙI–CHÂN"
            };
            arr.Add(new SoTayDienChanModel("59. Mông", 78, title));
            arr.Add(new SoTayDienChanModel("60. Háng", 79, title));
            arr.Add(new SoTayDienChanModel("61. Đùi", 80, title));
            arr.Add(new SoTayDienChanModel("62. Khoeo (nhượng)", 81, title));
            arr.Add(new SoTayDienChanModel("63. Đầu gối", 82, title));
            arr.Add(new SoTayDienChanModel("64. Cẳng chân", 83, title));
            arr.Add(new SoTayDienChanModel("65. Cổ chân", 84, title));
            arr.Add(new SoTayDienChanModel("66. Bàn chân", 85, title));
            arr.Add(new SoTayDienChanModel("67. Gót chân", 86, title));
            arr.Add(new SoTayDienChanModel("68. Ngón chân cái", 87, title));
            arr.Add(new SoTayDienChanModel("69. Ngón chân trỏ", 88, title));
            arr.Add(new SoTayDienChanModel("70. Ngón chân giữa", 89, title));
            arr.Add(new SoTayDienChanModel("71. Ngón chân áp út", 90, title));
            arr.Add(new SoTayDienChanModel("72. Ngón chân út", 91, title));


            title = new SoTayGroupModel()
            {
                GroupId = ++groupid,
                TenGroup = "NGỰC–LƯNG–BỤNG"
            };
            arr.Add(new SoTayDienChanModel("73. Ngực", 92, title));
            arr.Add(new SoTayDienChanModel("74. Vú", 93, title));
            arr.Add(new SoTayDienChanModel("75. Cột sống lưng", 94, title));
            arr.Add(new SoTayDienChanModel("76. Thắt lưng", 95, title));
            arr.Add(new SoTayDienChanModel("77. Giữa hai bả vai", 96, title));
            arr.Add(new SoTayDienChanModel("78. Quanh rốn (bụng)", 97, title));
            arr.Add(new SoTayDienChanModel("79. Trên rốn", 98, title));


            arr.ForEach(e =>
            {
                e.DanhMucId = danhmucid;
            });
            return arr;
        }

        public static List<SoTayDienChanModel> getTacDung(int danhmucid)
        {
            List<SoTayDienChanModel> arr = new List<SoTayDienChanModel>();
            arr.Add(new SoTayDienChanModel("1. Hạ huyết áp", 99));
            arr.Add(new SoTayDienChanModel("2. Tăng huyết áp", 100));
            arr.Add(new SoTayDienChanModel("3. Giáng khí (đánh từ trên xuống)", 101));
            arr.Add(new SoTayDienChanModel("4. Thăng khí (đánh từ dưới lên)", 102));
            arr.Add(new SoTayDienChanModel("5. Làm mát ( hạ nhiệt) (đánh từ trên xuống)", 103));
            arr.Add(new SoTayDienChanModel("6. Làm ấm (đánh từ dưới lên)", 104));
            arr.Add(new SoTayDienChanModel("7. Lợi tiểu", 105));
            arr.Add(new SoTayDienChanModel("8. Cầm tiểu", 106));
            arr.Add(new SoTayDienChanModel("9. Nhuận trường", 107));
            arr.Add(new SoTayDienChanModel("10. Giảm tiết dịch", 108));
            arr.Add(new SoTayDienChanModel("11. Tăng tiết dịch", 109));
            arr.Add(new SoTayDienChanModel("12. Tiêu viêm, tiêu độc", 110));
            arr.Add(new SoTayDienChanModel("13. Tiêu bướu, khối u", 111));
            arr.Add(new SoTayDienChanModel("14. Tiêu đàm, long đàm", 112));
            arr.Add(new SoTayDienChanModel("15. Tiêu mỡ", 113));
            arr.Add(new SoTayDienChanModel("16. Tiêu hơi, thông khí", 114));
            arr.Add(new SoTayDienChanModel("17. Giải độc", 115));
            arr.Add(new SoTayDienChanModel("18. Cầm máu", 116));
            arr.Add(new SoTayDienChanModel("19. Chống co cơ (điều chỉnh)", 117));
            arr.Add(new SoTayDienChanModel("20. Ổn định thần kinh", 118));
            arr.Add(new SoTayDienChanModel("21. Tăng lực", 119));
            arr.Add(new SoTayDienChanModel("22. Tăng sức đề kháng", 120));
            arr.Add(new SoTayDienChanModel("23. Tăng cường tính miễn nhiễm", 121));
            arr.Add(new SoTayDienChanModel("24. Bồi bổ & thông hành khí huyết", 122));

            arr.ForEach(e =>
            {
                e.DanhMucId = danhmucid;
            });
            return arr;
        }

        public static List<SoTayDienChanModel> getTrieuChungCamGiac(int danhmucid)
        {
            List<SoTayDienChanModel> arr = new List<SoTayDienChanModel>();
            arr.Add(new SoTayDienChanModel("1. Đau", 123));
            arr.Add(new SoTayDienChanModel("2. Nhức", 124));
            arr.Add(new SoTayDienChanModel("3. Tức lói", 125));
            arr.Add(new SoTayDienChanModel("4. Ngứa", 126));
            arr.Add(new SoTayDienChanModel("5. Rát, xót xa", 127));
            arr.Add(new SoTayDienChanModel("6. Nhột", 128));
            arr.Add(new SoTayDienChanModel("7. Tê, mất cảm giác", 129));
            arr.Add(new SoTayDienChanModel("8. Chóng mặt", 130));
            arr.Add(new SoTayDienChanModel("9. Nghẽn, nghẹt", 131));
            arr.Add(new SoTayDienChanModel("10. Co giật", 132));
            arr.Add(new SoTayDienChanModel("11. Run rẩy", 133));
            arr.Add(new SoTayDienChanModel("12. Lờ lờ, mệt mỏi", 134));
            arr.Add(new SoTayDienChanModel("13. Nóng", 135));
            arr.Add(new SoTayDienChanModel("14. Lạnh", 136));
            arr.ForEach(e =>
            {
                e.DanhMucId = danhmucid;
            });
            return arr;
        }

        public static List<SoTayDienChanModel> getCTDCDacHieu(int danhmucid)
        {
            List<SoTayDienChanModel> arr = new List<SoTayDienChanModel>();

            arr.Add(new SoTayDienChanModel("1. Nhức mỏi toàn thân (nhất là 2 bắp chân) 130", 137));
            arr.Add(new SoTayDienChanModel("2. Nhức mắt đỏ", 138));
            arr.Add(new SoTayDienChanModel("3. Ớn lạnh ", 139));
            arr.Add(new SoTayDienChanModel("4. Chân tay co duỗi khó khăn ", 140));
            arr.Add(new SoTayDienChanModel("5. Vả (xì ke) ", 141));
            arr.Add(new SoTayDienChanModel("6. Sổ mũi kinh niên ", 142));
            arr.Add(new SoTayDienChanModel("7. Nhức răng ", 143));
            arr.Add(new SoTayDienChanModel("8. Xuất tinh sớm", 144));
            arr.Add(new SoTayDienChanModel("9. Nhức đầu như búa bổ", 145));
            arr.Add(new SoTayDienChanModel("10. Đau bụng sau khi tắm", 146));
            arr.Add(new SoTayDienChanModel("11. Mắt mờ ", 147));
            arr.Add(new SoTayDienChanModel("12. Mỏi gối, mệt", 148));
            arr.Add(new SoTayDienChanModel("13. Cơn suyễn ", 149));
            arr.Add(new SoTayDienChanModel("14. Cơn đau bao tử ", 150));
            arr.Add(new SoTayDienChanModel("15. Mệt tim ", 151));
            arr.Add(new SoTayDienChanModel("16. Nhọt cổ tay", 152));
            arr.Add(new SoTayDienChanModel("17. Mồ hôi tay", 153));
            arr.Add(new SoTayDienChanModel("18. Eczema tay chân", 154));
            arr.Add(new SoTayDienChanModel("19. Sôi ruột", 155));
            arr.Add(new SoTayDienChanModel("20. Nhức chân ", 156));
            arr.Add(new SoTayDienChanModel("21. Trĩ ", 157));
            arr.Add(new SoTayDienChanModel("21. Trĩ ", 157));
            arr.Add(new SoTayDienChanModel("23. Bại xụi ", 159));
            arr.Add(new SoTayDienChanModel("24. Nhức vai do phổi ", 160));
            arr.Add(new SoTayDienChanModel("25. Bao tử kinh niên nặng ", 161));
            arr.Add(new SoTayDienChanModel("26. Nhức góc trán ", 162));
            arr.Add(new SoTayDienChanModel("27. Nhức cánh tay ", 163));
            arr.Add(new SoTayDienChanModel("28. Tức hông sườn ", 164));
            arr.Add(new SoTayDienChanModel("29. Vẹo cổ ", 165));
            arr.Add(new SoTayDienChanModel("30. Nhức chân muốn xụi ", 166));
            arr.Add(new SoTayDienChanModel("31. Tiêu chảy ", 167));
            arr.Add(new SoTayDienChanModel("32. Nhức đầu ", 168));
            arr.Add(new SoTayDienChanModel("33. Eczema", 169));
            arr.Add(new SoTayDienChanModel("34. Giáng khí bao tử", 170));
            arr.Add(new SoTayDienChanModel("35. Tiểu nhiều, tiểu gấp, khó cầm tiểu", 171));

            arr.ForEach(e =>
            {
                e.DanhMucId = danhmucid;
            });

            return arr;
        }

        public static List<SoTayDienChanModel> getPhacDoDacHieu(int danhmucid)
        {
            List<SoTayDienChanModel> arr = new List<SoTayDienChanModel>();

            int groupid = 0;
            SoTayGroupModel title = new SoTayGroupModel()
            {
                GroupId = ++groupid,
                TenGroup = "BỆNH TOÀN THÂN"
            };
            arr.Add(new SoTayDienChanModel("1. Suy nhược cơ thể (2)", 172, title, 2));
            arr.Add(new SoTayDienChanModel("2. Cảm nóng (ấn + dán cao) (2)", 173, title, 2));
            arr.Add(new SoTayDienChanModel("3. Cảm lạnh (đánh dầu cù là + dán cao) (2)", 174, title, 2));
            arr.Add(new SoTayDienChanModel("4. Sổ mũi (3)", 175, title, 3));
            
            
            title = new SoTayGroupModel()
            {
                GroupId = ++groupid,
                TenGroup = "BỆNH THẦN KINH"
            };
            arr.Add(new SoTayDienChanModel("5. Tai biến mạch máu não", 176, title));
            arr.Add(new SoTayDienChanModel("6. Suy nhược thần kinh  (2)", 177, title, 2));
            arr.Add(new SoTayDienChanModel("7. Hay quên kém trí nhớ (dán cao) (2)", 178, title, 2));
            arr.Add(new SoTayDienChanModel("8. Mất ngủ (dán cao) (7)", 179, title, 7));
            arr.Add(new SoTayDienChanModel("9. Hau giật bắn người khi ngủ", 180, title));

     
            title = new SoTayGroupModel()
            {
                GroupId = ++groupid,
                TenGroup ="ĐAU NHỨC"
            };
            arr.Add(new SoTayDienChanModel("10. Đau nhức toàn thân", 181, title));
            arr.Add(new SoTayDienChanModel("11. Đau thần kinh tam thoa (2)", 182, title, 2));

            arr.Add(new SoTayDienChanModel("12. -Nhức đầu: Nhức đầu một bên (day ấn)", 18311111, title));
            arr.Add(new SoTayDienChanModel("13. -Nhức đầu: Nhức đỉnh đầu (2)", 18322222, title, 2));
            arr.Add(new SoTayDienChanModel("14. -Nhức đầu: Nhức trán", 18333333, title));
            arr.Add(new SoTayDienChanModel("15. -Nhức đầu: Nhức mỏi cổ, gáy, vai (3)", 18344444, title, 3));
            arr.Add(new SoTayDienChanModel("16. -Nhức đầu: Vẹo cổ ", 18355555, title));

            arr.Add(new SoTayDienChanModel("17. -Đau bụng: Kiết lỵ", 18411111, title));
            arr.Add(new SoTayDienChanModel("18. -Đau bụng: Tiêu chảy", 18422222, title));
            arr.Add(new SoTayDienChanModel("19. -Đau bụng: Sên lãi", 18433333, title));
            arr.Add(new SoTayDienChanModel("20. -Đau bụng: Đau cứng cơ thân bụng", 18444444, title));

            arr.Add(new SoTayDienChanModel("21. Nhức răng (3)", 185, title, 3));
            arr.Add(new SoTayDienChanModel("22. -Đau lưng: Đau cơ lưng:", 18611111, title));
            arr.Add(new SoTayDienChanModel("23. -Đau lưng: Đau cột sống thắt lưng", 18622222, title));
            arr.Add(new SoTayDienChanModel("24. -Đau lưng: Đau lưng vùng thận (3)", 18633333, title, 3));

            arr.Add(new SoTayDienChanModel("25. Đau cứng cổ gáy (5)", 187, title, 5));

            arr.Add(new SoTayDienChanModel("26. - Đau cột sống: Cột sống cổ", 18811111, title));
            arr.Add(new SoTayDienChanModel("27. - Đau cột sống: Cột sống lưng", 18822222, title));
            arr.Add(new SoTayDienChanModel("28. - Đau cột sống: Cột sống cùng-cụt:", 18833333, title));

            arr.Add(new SoTayDienChanModel("29. Đau thần kinh liên sườn", 189, title));
            arr.Add(new SoTayDienChanModel("30. -Đau vai: Đau bả vai", 19011111, title));
            arr.Add(new SoTayDienChanModel("31. -Đau vai: Đau khớp vai (2)", 19022222, title, 2));

            arr.Add(new SoTayDienChanModel("32. Đau cánh tay", 191, title));
            arr.Add(new SoTayDienChanModel("33. Đau khuỷu tay", 192, title));
            arr.Add(new SoTayDienChanModel("34. Đau cẳng tay", 193, title));
            arr.Add(new SoTayDienChanModel("35. Đau cổ tay", 194, title));
            arr.Add(new SoTayDienChanModel("36. Đau 5 ngón tay", 195, title));
            arr.Add(new SoTayDienChanModel("37. Đau khớp háng", 196, title));
            arr.Add(new SoTayDienChanModel("38. Đau mông – Đau thần kinh tọa (3)", 197, title, 3));
            arr.Add(new SoTayDienChanModel("39. Đau khớp gối – thấp khớp gối (5)", 198, title, 5));
            arr.Add(new SoTayDienChanModel("40. Đau khoeo chân", 199, title));

            arr.Add(new SoTayDienChanModel("41. - Đau cổ chân", 20011111, title));
            arr.Add(new SoTayDienChanModel("42. - Đau cổ chân: Bong gân cổ chân", 20022222, title));

            arr.Add(new SoTayDienChanModel("43. Đau gót chân", 201, title));

            
            title = new SoTayGroupModel()
            {
                GroupId = ++groupid,
                TenGroup = "BỆNH HÔ HẤP"
            };
            arr.Add(new SoTayDienChanModel("44. Ho khan (3)", 202, title, 3));
            arr.Add(new SoTayDienChanModel("45. Ho có đàm (3)", 203, title, 3));

            arr.Add(new SoTayDienChanModel("46. -Suyễn:  Suyễn hàn (5)", 20411111, title, 5));
            arr.Add(new SoTayDienChanModel("47. -Suyễn: Suyễn nhiệt", 20422222, title));

           
            title = new SoTayGroupModel()
            {
                GroupId = ++groupid,
                TenGroup =  "BỆNH TUẦN HOÀN"
            };
            arr.Add(new SoTayDienChanModel("48. Mệt do tim", 205, title));
            arr.Add(new SoTayDienChanModel("49. Tức ngực – khó thở - nhói tim (3)", 206, title, 3));
            arr.Add(new SoTayDienChanModel("50. Tim đập chậm (2)", 207, title, 2));
            arr.Add(new SoTayDienChanModel("51. Tim đập nhanh", 208, title));
            arr.Add(new SoTayDienChanModel("52. Huyết áp thấp (3)", 209, title, 3));
            arr.Add(new SoTayDienChanModel("53. Huyết áp cao (3)", 210, title, 3));

         
            title = new SoTayGroupModel()
            {
                GroupId = ++groupid,
                TenGroup = "BỆNH TIÊU HÓA"
            };
            arr.Add(new SoTayDienChanModel("54. Kém ăn (2)", 211, title, 2));
            arr.Add(new SoTayDienChanModel("55. Ói mửa", 212, title));
            arr.Add(new SoTayDienChanModel("56. Nấc", 213, title));
            arr.Add(new SoTayDienChanModel("57. Đau dạ dày (3)", 214, title, 3));
            arr.Add(new SoTayDienChanModel("58. Bón (2)", 215, title, 2));
            arr.Add(new SoTayDienChanModel("59. Tiêu chảy", 216, title));

          
            title = new SoTayGroupModel()
            {
                GroupId = ++groupid,
                TenGroup ="BỆNH TIẾT NIỆU + SINH DỤC"
            };
            arr.Add(new SoTayDienChanModel("60. Tiểu gắt (4)", 217, title, 4));
            arr.Add(new SoTayDienChanModel("61. Tiểu ít (2)", 218, title, 2));
            arr.Add(new SoTayDienChanModel("62. Tiểu nhiều", 219, title));
            arr.Add(new SoTayDienChanModel("63. Tiểu đêm (2)", 220, title, 2));
            arr.Add(new SoTayDienChanModel("64. Tiểu đường", 221, title));
            arr.Add(new SoTayDienChanModel("65. Đái dầm", 222, title));
            arr.Add(new SoTayDienChanModel("66. Di mộng tinh (3)", 223, title, 3));
            arr.Add(new SoTayDienChanModel("67. Liệt dương (4)", 224, title, 4));
            arr.Add(new SoTayDienChanModel("68. Lãnh cảm (4)", 225, title, 4));
            arr.Add(new SoTayDienChanModel("69. Đau bụng kinh (2)", 226, title, 2));
            arr.Add(new SoTayDienChanModel("70. Viêm cổ tử cung (2)", 227, title, 2));
            arr.Add(new SoTayDienChanModel("71. Kinh nguyệt không đều (2)", 228, title, 2));
            arr.Add(new SoTayDienChanModel("72. Trễ kinh (2)", 229, title, 2));
            arr.Add(new SoTayDienChanModel("73. Rong kinh (4)", 230, title, 4));
            arr.Add(new SoTayDienChanModel("74. Bạch đái (Huyết trắng) (5)", 231, title, 5));
            arr.Add(new SoTayDienChanModel("75. Sa tử cung (3)", 232, title, 3));
            arr.Add(new SoTayDienChanModel("77. Hiếm muộn (2)", 234, title, 2));
            arr.Add(new SoTayDienChanModel("78. Suy nhược sinh dục (yếu sinh lý)", 235, title));
            arr.Add(new SoTayDienChanModel("79. Bướu buồng trứng", 236, title));

        
            title = new SoTayGroupModel()
            {
                GroupId = ++groupid,
                TenGroup ="BỆNH NGOÀI DA"
            };
            arr.Add(new SoTayDienChanModel("80. Ngứa (2)", 237, title, 2));
            arr.Add(new SoTayDienChanModel("81. Mề đay (2)", 238, title, 2));
            arr.Add(new SoTayDienChanModel("82. Vẩy nến (2)", 239, title, 2));
            arr.Add(new SoTayDienChanModel("83. Mụt cóc", 240, title, 2));
            arr.Add(new SoTayDienChanModel("84. Giời ăn", 241, title));
            arr.Add(new SoTayDienChanModel("85. Chàm lác (2)", 242, title, 2));
            arr.Add(new SoTayDienChanModel("86. Mặt nám", 243, title));
            arr.Add(new SoTayDienChanModel("87. Mặt mụn", 244, title));
            arr.Add(new SoTayDienChanModel("88. Mồ hôi tay chân (3)", 245, title, 3));

          
            title = new SoTayGroupModel()
            {
                GroupId = ++groupid,
                TenGroup = "BỆNH TAI - MẮT – MŨI"
            };
            arr.Add(new SoTayDienChanModel("89. - Bệnh mắt: Thị lực kém (2)", 24611111, title, 2));
            arr.Add(new SoTayDienChanModel("90. - Bệnh mắt: Mộng thịt", 24622222, title));
            arr.Add(new SoTayDienChanModel("91. - Bệnh mắt: Tăng nhãn áp", 24633333, title));
            arr.Add(new SoTayDienChanModel("92. - Bệnh mắt: Chảy nước mắt sống", 24644444, title));
            arr.Add(new SoTayDienChanModel("93. - Bệnh mắt: Đau mắt cấp tính (2)", 24655555, title, 2));

            arr.Add(new SoTayDienChanModel("94. - Bệnh tai: Ù tai", 24711111, title));
            arr.Add(new SoTayDienChanModel("95. - Bệnh tai: Điếc tai", 24722222, title));
            arr.Add(new SoTayDienChanModel("96. - Bệnh tai: Viêm tai giữa (2)", 24733333, title, 2));

            arr.Add(new SoTayDienChanModel("97. - Bệnh mũi: Viêm mũi dị ứng (5)", 24811111, title, 5));
            arr.Add(new SoTayDienChanModel("98. - Bệnh mũi: Viêm xoang (dán cao) (3)", 24822222, title, 3));

           
            title = new SoTayGroupModel()
            {
                GroupId = ++groupid,
                TenGroup ="BỆNH HỌNG"
            };
            arr.Add(new SoTayDienChanModel("99. Viêm amidan, viêm họng", 249, title));
            arr.Add(new SoTayDienChanModel("100. Khan tiếng", 250, title));
            arr.Add(new SoTayDienChanModel("101. Nghẹt họng", 251, title));
            arr.Add(new SoTayDienChanModel("102. Bướu cổ (2)", 252, title, 2));

          
            title = new SoTayGroupModel()
            {
                GroupId = ++groupid,
                TenGroup = "LINH TINH"
            };
            arr.Add(new SoTayDienChanModel("103. Các khối u (không có mủ)", 253, title));
            arr.Add(new SoTayDienChanModel("104. Viêm gan mạn tính (giai đoạn đầu) (2)", 254, title, 2));
            arr.Add(new SoTayDienChanModel("105. Liệt mặt (2)", 255, title, 2));
            arr.Add(new SoTayDienChanModel("106. Chảy máu (do đứt tay chân, xuất huyết…)", 256, title));
            arr.Add(new SoTayDienChanModel("107. Mắc cổ (xương, vật lạ…)", 257, title));
            arr.Add(new SoTayDienChanModel("108. Rắn, rít, ong bọ cạp cắn chích (2)", 258, title, 2));
            arr.Add(new SoTayDienChanModel("109. Phỏng (nước sôi, lửa)", 259, title));
            arr.Add(new SoTayDienChanModel("110. Sưng vú, tắc tia sữa", 260, title));
            arr.Add(new SoTayDienChanModel("111. Vọp bẻ (2)", 261, title, 2));
            arr.Add(new SoTayDienChanModel("112. Quai bị", 262, title));
            arr.Add(new SoTayDienChanModel("113. Mụt lẹo", 263, title));
            arr.Add(new SoTayDienChanModel("114. Lở lưỡi", 264, title));
            arr.Add(new SoTayDienChanModel("115. Ói mửa khi có thai", 265, title));
            arr.Add(new SoTayDienChanModel("116. Ghiền thuốc lá, ma túy, rượu", 266, title));

            arr.ForEach(e =>
            {
                e.DanhMucId = danhmucid;
            });

            return arr;
        }
    }

    public class DanhMucSoTayDienChanModel
    {
        public int Id { get; set; }
        public string TenDanhMuc { get; set; }
        public bool Lock { get; set; }
        public List<SoTayDienChanModel> SoTayDienChanModels { get; set; }
    }
}