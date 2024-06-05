using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhackAMole
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        int locationNum = 0;
        int locationNumBomb = 0;
        int max = 0;
        int score = 0;
        int misses = 0;
        bool kho = false;
        bool isHit;
        public Form1()
        {
            InitializeComponent();
            timer1.Stop();
            //ẩn chuột và các nút ở menu đầu game
            bomb.Visible = false;
            Mole.Visible = false;
            btnStop.Visible = false;
        }

        private void gotMole(object sender, EventArgs e)
        {
            // cập nhận điểm hiện tại và điểm max đạt được
            score++;
            if (score > max) max++; 
            Mole.Image = Properties.Resources.dead; //hiển thị ảnh con chuột bị đập 
            isHit = true; // đánh trúng chuột
            Mole.Enabled = false; // Vô hiệu hóa chuột
        }
        private void gotBomb(object sender, EventArgs e)
        {
            bomb.Image = Properties.Resources.dead2; // Hiển thị hình ảnh của quả mìn nổ
            bomb.Enabled = false; //Vô hiệu hóa quả mìn
            timer1.Stop(); // Dừng game 
            MessageBox.Show("Game Over"); 
            NewGame.Visible = true; // Hiện nút bấm chơi lại
            bomb.Visible = false;
            Mole.Visible = false;
            btnStop.Visible = false;
            lblDoKho.Visible = true;
            Thuong.Visible = true;
            Kho.Visible = true;
        }
        private void moveMole()
        {
            isHit = false; // chưa đập được chuột 
            Mole.Enabled = true; // 
            Mole.Image = Properties.Resources.alive;
            Mole.BackColor = System.Drawing.Color.Transparent;
            locationNum = rnd.Next(1, 7);
            switch (locationNum)
            {
                case 1:
                    Mole.Left = 32;
                    Mole.Top = 177;
                    break;
                case 2:
                    Mole.Left = 181;
                    Mole.Top = 151;
                    break;
                case 3:
                    Mole.Left = 316;
                    Mole.Top = 182;
                    break;
                case 4:
                    Mole.Left = 25;
                    Mole.Top = 286;
                    break;
                case 5:
                    Mole.Left = 181;
                    Mole.Top = 272;
                    break;
                case 6:
                    Mole.Left = 326;
                    Mole.Top = 286;
                    break;
                default:
                    break;
            }
            if (kho == true)
            {
                bomb.Enabled = true;
                bomb.Image = Properties.Resources.alive1;
                locationNumBomb = rnd.Next(1, 7);
                while (locationNum == locationNumBomb) locationNumBomb = rnd.Next(1, 7);
                switch (locationNumBomb)
                {
                    case 1:
                        bomb.Left = 32;
                        bomb.Top = 177;
                        break;
                    case 2:
                        bomb.Left = 181;
                        bomb.Top = 151;
                        break;
                    case 3:
                        bomb.Left = 316;
                        bomb.Top = 182;
                        break;
                    case 4:
                        bomb.Left = 25;
                        bomb.Top = 286;
                        break;
                    case 5:
                        bomb.Left = 181;
                        bomb.Top = 272;
                        break;
                    case 6:
                        bomb.Left = 326;
                        bomb.Top = 286;
                        break;
                    default:
                        break;
                }
            }

        }
        private void moveMole(object sender, EventArgs e)
        {
            // hiển thị điểm
            lblHit.Text = "Score: " + score;
            lblMiss.Text = "Miss: " + misses;
            lblMax.Text = "Max: " + max;
            // tăng độ khó khi đạt được nhiều điểm
            if (score > 10) timer1.Interval = 900;
            if (score > 20) timer1.Interval = 800;
            if (score > 35) timer1.Interval = 700;
            if (score > 45) timer1.Interval = 600;

            // đếm số lần đập hụt và tính thua khi hụt quá 3 lần
            if (isHit == false)
            {
                misses++;
            }
            if (misses > 3)
            {
                timer1.Stop();
                Mole.Enabled = false;
                NewGame.Visible = true;
                bomb.Visible = false;
                Mole.Visible = false;
                btnStop.Visible = false;
                lblDoKho.Visible = true;
                Thuong.Visible = true;
                Kho.Visible = true;
                MessageBox.Show("Game Over");
            }
            moveMole(); 
        }

        private void ChoiLai(object sender, EventArgs e)
        {
            score = 0;
            misses = 0;
            moveMole();
            timer1.Start();
            timer1.Interval = 1000;
            NewGame.Visible = false;
            bomb.Visible = true;
            Mole.Visible = true;
            btnStop.Visible = true;
            lblDoKho.Visible = false;
            Thuong.Visible = false;
            Kho.Visible = false;
        }

        private void doKhoThuong(object sender, EventArgs e)
        {
            score = 0;
            misses = 0;
            // chọn độ khó thấp, ẩn các nút dư thừa
            btnStop.Visible = true; // hiển thị nút tạm dừng
            Thuong.Visible = false;
            Kho.Visible = false;
            lblDoKho.Visible = false;
            NewGame.Visible=false;
            bomb.Visible = false;
            Mole.Visible = true;
            timer1.Start();
        }

        private void doKhoCao(object sender, EventArgs e)
        {
            score = 0;
            misses = 0;
            // chọn độ khó cao ẩn các nút dư thừa
            btnStop.Visible = true; // hiển thị nút tạm dừng
            kho = true;
            Thuong.Visible = false;
            Kho.Visible = false;
            lblDoKho.Visible = false;
            NewGame.Visible = false;
            bomb.Visible = true;
            Mole.Visible = true;
            timer1.Start();

        }

        bool isTimerRunning = false;
        private void stop(object sender, EventArgs e) // hàm tạm dừng trò game
        {
            if (isTimerRunning)
            {
                timer1.Stop();
                isTimerRunning = false;
                Thuong.Visible = true;
                Kho.Visible = true;
                lblDoKho.Visible = true;
            }
            else
            {
                timer1.Start();
                isTimerRunning = true;
                Thuong.Visible = false;
                Kho.Visible = false;
                lblDoKho.Visible = false;
            }
        }
    }
}
