using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using WebapiQLBanHoa.Repository;
namespace WebapiQLBanHoa.Controllers
{
    public class XulyController : ApiController
    {
    [Route("api/XulyController/LayThongTinKH")]
     [HttpGet]
     public IHttpActionResult LayLoaiHoa()
    {
      DataTable tb = Database.Read_Table("laythongtinkh");
      if (tb != null && tb.Rows.Count > 0)
        return Ok(tb);
      else
        return NotFound();
    }

    [Route("api/XulyController/ThemKhachHang")]
    [HttpPost]
    public IHttpActionResult ThemKH(string TenKH, string SDT)
    {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("TenKH", TenKH);
            param.Add("SDTKH", SDT);
            int kq = int.Parse(Database.Exec_Command("ThemKhachHang", param).ToString());
            if (kq > 0)
                return Ok(kq);
            else
                return NotFound();
    }

        [Route("api/XulyController/laythongtinkm")]
        [HttpGet]
        public IHttpActionResult LayThongTinKM()
        {
            DataTable tb = Database.Read_Table("laythongtinkm");
            if (tb != null && tb.Rows.Count > 0)
                return Ok(tb);
            else
                return NotFound();
        }

        [Route("api/XulyController/ThemKhuyenMai")]
        [HttpGet]
        public IHttpActionResult ThemKhuyenMai(string TenKM)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("tenkm", TenKM);
            int kq = int.Parse(Database.Exec_Command("Them_Khuyen_Mai", param).ToString());
            if (kq > 0)
                return Ok(kq);
            else
                return NotFound();
        }

        [Route("api/XulyController/ThemKhuyenMai1")]
        [HttpGet]
        public IHttpActionResult ThemKhuyenMai1(string TenKM, string ChitietKM, string SoTien)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();

            param.Add("tenkm", TenKM);
            param.Add("chiTietkm", ChitietKM);
            param.Add("sotien", SoTien);

            int kq = int.Parse(Database.Exec_Command("Them_Khuyen_Mai_Nh", param).ToString());
            if (kq > 0)
                return Ok(kq);
            else
                return NotFound();
        }

        [Route("api/XulyController/LayKMTheoMaKM")]
        [HttpGet]
        public IHttpActionResult LayKMTheoMaKM(int MaKM)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("makm", MaKM);
            DataTable tb = Database.Read_Table("Laykmtheomakm", param);
            if (tb != null && tb.Rows.Count > 0)
                return Ok(tb);
            else
                return NotFound();
        }



        [Route("api/XulyController/XoaKM")]
        [HttpGet]
        public IHttpActionResult XoaKM(int MaKM)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("makm", MaKM);
            int kq = int.Parse(Database.Exec_Command("XoaKM", param).ToString());
            if (kq > 0)
                return Ok(kq);
            else
                return NotFound();
        }

        [Route("api/XulyController/CapNhatKM")]
        [HttpGet]
        public IHttpActionResult CapNhatKM(int MaKM, string TenKM, string ChitietKM, string SoTien)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();

            param.Add("makm", MaKM);
            param.Add("tenkm", TenKM);
            param.Add("chiTietkm", ChitietKM);
            param.Add("sotien", SoTien);

            int kq = int.Parse(Database.Exec_Command("CapNhatKM", param).ToString());
            if (kq > 0)
                return Ok(kq);
            else
                return NotFound();
        }

        [Route("api/XulyController/laythongtindm")]
        [HttpGet]
        public IHttpActionResult LayThongTinDM()
        {
            DataTable tb = Database.Read_Table("laythongtindm");
            if (tb != null && tb.Rows.Count > 0)
                return Ok(tb);
            else
                return NotFound();
        }

        [Route("api/XulyController/LaySPtheoDMuc")]
        [HttpGet]
        public IHttpActionResult LaySPtheoDMuc(int MaDM)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("madm", MaDM);
            DataTable tb = Database.Read_Table("LaySPtheoDMuc", param);
            if (tb != null && tb.Rows.Count > 0)
                return Ok(tb);
            else
                return NotFound();
        }

        [Route("api/XulyController/CapNhatSanPham")]
        [HttpGet]
        public IHttpActionResult CapNhatSanPham(int MaSP, string TenSP, string GiaSP, string SL)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();

            param.Add("masp", MaSP);
            param.Add("tensp", TenSP);
            param.Add("giasp", GiaSP);
            param.Add("sl", SL);

            int kq = int.Parse(Database.Exec_Command("CapNhatSanPham", param).ToString());
            if (kq > 0)
                return Ok(kq);
            else
                return NotFound();
        }

        [Route("api/XulyController/LayThongTinDH")]
        [HttpGet]
        public IHttpActionResult LayThongTinDH()
        {
            DataTable tb = Database.Read_Table("LayThongTinDonHang");
            if (tb != null && tb.Rows.Count > 0)
                return Ok(tb);
            else
                return NotFound();
        }

        [Route("api/XulyController/ThemDonHang")]
        [HttpGet]
        public IHttpActionResult ThemDonHang(int MaKH)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();

            param.Add("maKH", MaKH);
            int kq = int.Parse(Database.Exec_Command("ThemDonHang", param).ToString());
            if (kq > 0)
                return Ok(kq);
            else
                return NotFound();
        }

        [Route("api/XulyController/LayDSSanPham")]
        [HttpGet]
        public IHttpActionResult LayDSSanPham()
        {
            DataTable tb = Database.Read_Table("LayDSSanPham");
            if (tb != null && tb.Rows.Count > 0)
                return Ok(tb);
            else
                return NotFound();
        }

        [Route("api/XulyController/ThemCTDH")]
        [HttpGet]
        public IHttpActionResult ThemCTDH(int MaDH, int MaSP)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();

            param.Add("maDH", MaDH);
            param.Add("maSP", MaSP);

            int kq = int.Parse(Database.Exec_Command("ThemCTDH", param).ToString());
            if (kq > 0)
                return Ok(kq);
            else
                return NotFound();
        }

        [Route("api/XulyController/LayDonHangMoi")]
        [HttpGet]
        public IHttpActionResult LayDonHangMoi()
        {
            DataTable tb = Database.Read_Table("LayDonHangMoi");
            if (tb != null && tb.Rows.Count > 0)
                return Ok(tb);
            else
                return NotFound();
        }

        [Route("api/XulyController/CapNhatTienKMDonHang")]
        [HttpGet]
        public IHttpActionResult CapNhatTienKMDonHang(int TienKM, int MaDH)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("tienkm", TienKM);
            param.Add("madh", MaDH);
            

            int kq = int.Parse(Database.Exec_Command("CapNhatTienKM", param).ToString());
            if (kq > 0)
                return Ok(kq);
            else
                return NotFound();
        }

        [Route("api/XulyController/CapNhatTinhTrangDH")]
        [HttpGet]
        public IHttpActionResult CapNhatTinhTrangDH(int MaDH)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            
            param.Add("madh", MaDH);


            int kq = int.Parse(Database.Exec_Command("CapNhatTinhTrangGiaoHang", param).ToString());
            if (kq > 0)
                return Ok(kq);
            else
                return NotFound();
        }

        [Route("api/XulyController/LayDoanhThu")]
        [HttpGet]
        public IHttpActionResult LayDoanhThu()
        {
            DataTable tb = Database.Read_Table("LayDoanhThuVaSLDHDG");
            if (tb != null && tb.Rows.Count > 0)
                return Ok(tb);
            else
                return NotFound();
        }

        [Route("api/XulyController/CapNhatKhachHang")]
        [HttpGet]
        public IHttpActionResult CapNhatKhachHang(int MaKH, string TenKH, string SDTKH)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();



            param.Add("maKH", MaKH);
            param.Add("tenKH", TenKH);
            param.Add("sdtKH", SDTKH);



            int kq = int.Parse(Database.Exec_Command("CapNhatKhachHang", param).ToString());
            if (kq > 0)
                return Ok(kq);
            else
                return NotFound();
        }

        [Route("api/XulyController/XoaKhachHang")]
        [HttpGet]
        public IHttpActionResult XoaKhachHang(int MaKH)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("maKH", MaKH);
            int kq = int.Parse(Database.Exec_Command("XoaKhachHang", param).ToString());
            if (kq > 0)
                return Ok(kq);
            else
                return NotFound();
        }


    }
}
