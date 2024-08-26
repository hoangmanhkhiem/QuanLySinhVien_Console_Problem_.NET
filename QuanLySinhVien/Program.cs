using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Bài 1_1: Tạo ứng dụng trên Console như sau
//-	Xây dựng lớp sinh viên quản lý Họ tên, Ngày sinh, Điểm thi môn Lập trình, Cơ sở dữ liệu, Thiết kế web.
//-	Xây dựng lớp danh sách gồm N sinh viên
//-	Đưa ra số lượng sinh viên được làm khoá luận tốt nghiệp; Số lượng sinh viên làm chuyên đề tốt nghiệp với các điều kiện:
// Làm khoá luận nếu điểm Trung bình >= 8 và không môn nào dưới 5; Làm chuyên đề tốt nghiệp nếu Không có môn nào dưới 5


namespace QuanLySinhVien
{
    class SinhVien
    {
        private string hoTen;
        private DateTime ngaySinh;
        private double diemLT;
        private double diemCSDL;
        private double diemThietKeWeb;

        public SinhVien()
        {
            hoTen = "";
            ngaySinh = DateTime.Now;
            diemLT = 0;
            diemCSDL = 0;
            diemThietKeWeb = 0;
        }

        public SinhVien(string hoTen, DateTime ngaySinh, double diemLT, double diemCSDL, double diemThietKeWeb)
        {
            this.hoTen = hoTen;
            this.ngaySinh = ngaySinh;
            this.diemLT = diemLT;
            this.diemCSDL = diemCSDL;
            this.diemThietKeWeb = diemThietKeWeb;
        }

        public double TinhDiemTrungBinh()
        {
            return (diemLT + diemCSDL + diemThietKeWeb) / 3;
        }

        public bool LaSinhVienLamKhoaLuan()
        {
            return TinhDiemTrungBinh() >= 8 && diemLT >= 5 && diemCSDL >= 5 && diemThietKeWeb >= 5;
        }

        public bool LaSinhVienLamChuyenDe()
        {
            return diemLT >= 5 && diemCSDL >= 5 && diemThietKeWeb >= 5;
        }
    }
    class DanhSachSinhVien
    {
        private List<SinhVien> dsSinhVien;

        public DanhSachSinhVien()
        {
            dsSinhVien = new List<SinhVien>();
        }

        public void ThemSinhVien(SinhVien sv)
        {
            dsSinhVien.Add(sv);
        }

        public void NhapSinhVien()
        {
            string hoTen;
            DateTime ngaySinh;
            double diemLT;
            double diemCSDL;
            double diemThietKeWeb;
            nhaplai:
            try
            {
                Console.Write("Nhap ho ten: ");
                hoTen = Console.ReadLine();
                Console.Write("Nhap ngay sinh: ");
                ngaySinh = DateTime.Parse(Console.ReadLine());
                if (ngaySinh > DateTime.Now)
                {
                    throw new Exception("Ngay sinh khong hop le");
                }
                Console.Write("Nhap diem LT: ");
                diemLT = double.Parse(Console.ReadLine());
                if (diemLT < 0 || diemLT > 10)
                {
                    throw new Exception("Diem khong hop le");
                }
                Console.Write("Nhap diem CSDL: ");
                diemCSDL = double.Parse(Console.ReadLine());
                if (diemCSDL < 0 || diemCSDL > 10)
                {
                    throw new Exception("Diem khong hop le");
                }
                Console.Write("Nhap diem Thiet ke web: ");
                diemThietKeWeb = double.Parse(Console.ReadLine());
                if (diemThietKeWeb < 0 || diemThietKeWeb > 10)
                {
                    throw new Exception("Diem khong hop le");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto nhaplai;
            }
           
            SinhVien sv = new SinhVien(hoTen, ngaySinh, diemLT, diemCSDL, diemThietKeWeb);
            ThemSinhVien(sv);
        }

        public int SoLuongSinhVienLamKhoaLuan()
        {
            int count = 0;
            foreach (SinhVien sv in dsSinhVien)
            {
                if (sv.LaSinhVienLamKhoaLuan())
                {
                    count++;
                }
            }
            return count;
        }

        public int SoLuongSinhVienLamChuyenDe()
        {
            int count = 0;
            foreach (SinhVien sv in dsSinhVien)
            {
                if (sv.LaSinhVienLamChuyenDe())
                {
                    count++;
                }
            }
            return count;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DanhSachSinhVien ds = new DanhSachSinhVien();
            int n;
            Console.Write("Nhap so luong sinh vien: ");
            n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhap sinh vien thu " + (i + 1));
                ds.NhapSinhVien();
            }
            Console.WriteLine("So luong sinh vien lam khoa luan: " + ds.SoLuongSinhVienLamKhoaLuan());
            Console.WriteLine("So luong sinh vien lam chuyen de: " + ds.SoLuongSinhVienLamChuyenDe());
            Console.ReadLine();
        }
    }

}
