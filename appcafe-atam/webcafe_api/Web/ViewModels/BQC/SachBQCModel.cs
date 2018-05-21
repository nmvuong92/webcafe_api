using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.ViewModels.BQC
{
    public class SachBQCModel
    {
        public int Id { get; set; }
        public string TenSach { get; set; }

        public string PDF { get; set; }
        public string Lite { get; set; }

        public static List<SachBQCModel> layds()
        {
            int id = 1;
            string vip_path = "/content/bqc-pdf/";
            string lite_path = "/content/bqc-pdf/lite/pdf/";
            
            return new List<SachBQCModel>
            {
                new SachBQCModel()
                {
                    Id=++id,
                    TenSach =  "1. Diện chẩn liệu pháp!",
                    PDF = vip_path+"dien_chan_lieu_phap.pdf",
                    Lite = lite_path+"dien_chan_lieu_phap.pdf"
                },
                 new SachBQCModel()
                {
                    Id=++id,
                    TenSach =  "2. Diện chẩn liệu pháp 1993 (thực hành)",
                    PDF = vip_path+"bai_giang_dien_chan_lieu_phap_1993.pdf",
                    Lite = lite_path+"bai_giang_dien_chan_lieu_phap_1993.pdf"

                },
                 new SachBQCModel()
                {
                    Id=++id,
                    TenSach =    "3. Ẩm thực dưỡng sinh",
                    PDF = vip_path+"am_thuc_duong_sinh.pdf",
                    Lite = lite_path+"am_thuc_duong_sinh.pdf"
                },
                 new SachBQCModel()
                {
                     Id=++id,
                    TenSach =  "4. Sách thực hành",
                    PDF = vip_path+"sach_thuc_hanh.pdf",
                    Lite =  lite_path+"sach_thuc_hanh.pdf",
                },
                 new SachBQCModel()
                {
                   Id=++id,
                    TenSach =  "5. Ký yếu 35 năm",
                    PDF = vip_path+"ky_yeu_35_nam.pdf",
                    Lite = lite_path+"ky_yeu_35_nam.pdf",
                }
            };
        }

        public static SachBQCModel LayById(int id)
        {
            return layds().FirstOrDefault(f => f.Id == id);
        }
    }
}