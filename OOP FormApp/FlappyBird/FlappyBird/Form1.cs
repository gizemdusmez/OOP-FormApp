using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        int pipespeed = 5;   // Boruların hareket hızı
        int gravity = 7;     // Kuşun yer çekimi etkisi
        int score = 0;       // Skor sayacı

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true; // BgrdImage kullandığımdan resmi hızlı yüklemesini için
        }

        private void Score_Click(object sender, EventArgs e)
        {
            
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            // Kuşun sürekli aşağıya çekilmesini sağla 
            bird.Top += gravity;

            // Boruları sola kaydır 
            pipedown.Left -= pipespeed;
            pipeup.Left -= pipespeed;

            // Skoru güncelle
            Score.Text = $"Score: {score}";

            // Borular ekrandan çıkınca skor artır ve boruları yeniden başlat
            if (pipedown.Left < -150)
            {
                pipedown.Left = 800;
                score++;
            }
            if (pipeup.Left < -100)
            {
                pipeup.Left = 950;
                score++;
            }

            // Kuş borulara veya oyun sınırlarına çarparsa oyunu bitir
            if (bird.Bounds.IntersectsWith(pipedown.Bounds) || bird.Bounds.IntersectsWith(pipeup.Bounds) || bird.Top < 0 || bird.Bottom > ClientSize.Height)
            {
                endgame();
            }
        }

        private void gamekeydown(object sender, KeyEventArgs e)
        {
            // Space tuşuna basıldığında kuşu yukarı hareket ettir
            if (e.KeyCode == Keys.Space)
            {
                gravity = -7;
            }
        }

        private void gamekeyup(object sender, KeyEventArgs e)
        {
            // Space tuşu bırakıldığında yer çekimi etkisini yeniden başlat
            if (e.KeyCode == Keys.Space)
            {
                gravity = 7;
            }
        }

        private void endgame()
        {
            // Oyunu durdur ve Game Over mesajı göster
            gametimer.Stop();
            Score.Text += " - Game Over!";
        }
    }
}

