using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dangnhap
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            if((txtten.Text=="")||(txtmatkhau.Text==""))
            {
                MessageBox.Show("Vui lòng nhập thông tin", "Thông báo");
            }
            else
            {
                if((txtten.Text=="hao")&&(txtmatkhau.Text=="123456"))
                {
                    MessageBox.Show("Bạn đăng nhập thành công <3", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Bạn đăng nhập không thành công", "Thông báo");
                }
            }
        }
    }
}
