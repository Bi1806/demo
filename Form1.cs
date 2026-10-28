using demo3.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace demo3


{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dgvSinhVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        private void LoadData()
        {
            using (var db = new QLSinhVienContext())
            {
                dgvSinhVien.DataSource = db.SinhViens
                    .Select(s => new
                    {
                        s.MaSv,
                        s.HoTen,
                        s.NgaySinh,
                        s.GioiTinh,
                        s.DiaChi,
                        s.MaKhoa
                    })
                    .ToList();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
