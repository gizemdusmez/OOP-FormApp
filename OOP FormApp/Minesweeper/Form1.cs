using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjektProgram
{
    public partial class Form1 : Form
    {
        //Variabler, vektorer
        int Antbomber, width, height, X_start = 20, Y_start = 60;
        public Button[,] knappPlan;
        public Label[,] labelPlan;
        Label label4 = new Label();

        bool markeraBomber = false;
        bool Win = false;
        int Antbombertext;
       


        public Form1()
        {
            InitializeComponent();
            
        }

        //??
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        //??
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Hanterar vänsterklick på rutorna
        public void vänsterKlick(object sender, System.EventArgs e)
        {
            Button knappKlick = sender as Button;

            if (markeraBomber)
            {
                if (knappKlick.Text == "X")
                {
                    knappKlick.Text = "";
                    Antbombertext++;
                }
                else
                {
                    knappKlick.Text = "X";
                    Antbombertext--;
                }
            }
            if (markeraBomber == false && knappKlick.Text != "X")
            {
                knappKlick.Visible = false;

                if (!timer1.Enabled)
                    timer1.Enabled = true;

                //Ful kod, kollar efter klickets position och jämför med knapparnas position, sätter sen de till x,y
                int x = 0;
                int y = 0;

                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        if ((knappKlick.Location.X == knappPlan[i, j].Location.X && knappKlick.Location.Y == knappPlan[i, j].Location.Y))
                        {
                            x = i;
                            y = j;
                        }
                    }
                }

                //Använder x och y från ovan för att kolla om det är en bomb där spelaren klickat
                if (labelPlan[x, y].Text == "*")
                {
                    timer1.Enabled = false;
                    for (int i = 0; i < width; i++)
                    {
                        for (int j = 0; j < height; j++)
                        {
                            knappPlan[i, j].Visible = false;

                        }
                    }
                    button1.Text = (":(");
                }
                rensaTomma();
            }
        }


        //Om en ruta har 0 bomber runt tar den bort rutorna runt, fungerar inte så bra som den hade kunnat
        public void rensaTomma()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (labelPlan[i, j].Text == " " && !knappPlan[i, j].Visible)
                    {
                        rensaTommaHjälp(i, j);
                    }
                }
            }
        }
        //Gör metoden ovan lättare att titta på
        public void rensaTommaHjälp(int x, int y)
        {
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (i + x < width && j + y < height && i + x >= 0 && j + y >= 0)
                    {
                        if (labelPlan[i + x, j + y].Text != "X")
                        {
                            knappPlan[x + i, y + j].Visible = false;

                        }
                    }
                }
            }
        }

        //Öppnar ett nytt fönster för att välja svårighetsgrad
        private void newGameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 Starta = new Form2();
            Starta.Show();
        }

        //Metod för att hantera svårighetsgraden som valts
        public void startGame(int diff)
        {
            label4.Visible = false;
            Win = false;
            rensaPlan();

            if (diff == 1)
            {
                width = 10;
                height = 10;
                Antbomber = 15;
            }
            if (diff == 2)
            {
                width = 20;
                height = 20;
                Antbomber = 75;
            }
            if (diff == 3)
            {
                width = 40;
                height = 20;
                Antbomber = 145;
            }
            //Fixar fönsterstorlek
            Width = (X_start + 9) * 2 + width * 22;
            Height = Y_start * 2 + height * 22;

            skapaPlan();
        }
        //Mallen för alla labels
        public Label skapaLabels(int x, int y)
        {
            Label label = new Label();
            Controls.AddRange(new System.Windows.Forms.Control[] { label, });
            label.Size = new System.Drawing.Size(22, 22);
            label.Location = new System.Drawing.Point(x, y);
            label.Text = " ";

            label.TextAlign = ContentAlignment.TopCenter;
            label.AutoSize = false;
            label.Font = new Font("Times new Roman", 18f);

            return label;
        }

        //Mallen för alla knappar
        public Button skapaKnappar(int x, int y)
        {
            Button knapp = new Button();
            Controls.AddRange(new System.Windows.Forms.Control[] { knapp, });
            knapp.Size = new System.Drawing.Size(22, 22);
            knapp.Location = new System.Drawing.Point(x, y);

            knapp.Click += new System.EventHandler(vänsterKlick);

            return knapp;
        }


        //Denna metod skapar alla labels, knappar, bomber och allt sådant
        public void skapaPlan()
        {
            Random random = new Random();


            Antbombertext = Antbomber;
            label1.Text = ("Time: 0");
            label2.Text = ("Bombs: " + Antbombertext.ToString());
            button1.Text = (":)");

            knappPlan = new Button[width, height];
            labelPlan = new Label[width, height];
            tid = 0;

            button1.Location = new System.Drawing.Point((Width / 2) - 22, 0);
            button2.Location = new System.Drawing.Point((Width / 2) + 25, 0);

            //Fixar knappar och labels
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    knappPlan[i, j] = skapaKnappar(X_start + 22 * i, Y_start + 22 * j);
                    labelPlan[i, j] = skapaLabels(X_start + 22 * i, Y_start + 22 * j);
                }
            }

            //Fixar bomber
            for (int i = 0; i < Antbomber; i++)
            {
                int bombX = random.Next(0, width);
                int bombY = random.Next(0, height);

                if (labelPlan[bombX, bombY].Text == "*")
                {
                    i--;
                }
                if (labelPlan[bombX, bombY].Text != "*")
                {
                    labelPlan[bombX, bombY].Text = "*";
                }
            }

            räknaBomber(width, height);
        }

        public int minorRunt = 0;

        //Kollar hur många bomber som finns runt varje ruta
        public void räknaBomber(int x, int y)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (labelPlan[i, j].Text != "*")
                    {
                        räknaBombHjälp(i, j);
                        if (minorRunt > 0)
                        {
                            labelPlan[i, j].Text = minorRunt.ToString();
                        }
                        minorRunt = 0;
                    }
                }
            }
        }

        //Mer för att räkna bomber, blev för mycket kod på ett ställe
        public void räknaBombHjälp(int x, int y)
        {
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (i + x < width && j + y < height && i + x >= 0 && j + y >= 0)
                    {
                        if (labelPlan[x + i, y + j].Text == "*")
                        {
                            minorRunt++;
                        }
                    }
                }
            }
        }
        private int tid = 0;

        //Håller tid
        private void timer1_Tick(object sender, EventArgs e)
        {
            int antal = 0;
            tid++;
            label1.Text = ("Time: " + tid.ToString());
            label2.Text = ("Bombs: " + Antbombertext.ToString());

            if (Antbombertext == 0)
            {
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        if (knappPlan[i, j].Text != "*" && !knappPlan[i, j].Visible)
                        {
                            antal++;
                        }
                    }
                }

            }

            if (Antbombertext == 0 && (antal == (width * height) - Antbomber))
            {
                Win = true;
                timer1.Enabled = false;
            }

            if (Win)
            {
                Controls.AddRange(new System.Windows.Forms.Control[] { label4, });
                label4.Location = new System.Drawing.Point(Width / 2 - 50, Height / 2-20);
                label4.Text = "You won!!";

                rensaPlan();
                label4.Show();
            }
        }

        //skräp
        private void label2_Click(object sender, EventArgs e)
        {

        }

        //skräp
        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Restartknappen ":)"
        private void button1_Click(object sender, EventArgs e)
        {
            Win = false;
            label4.Visible = false;
            timer1.Enabled = false;
            rensaPlan();
            skapaPlan();

        }

        //Tar bort alla rutor
        public void rensaPlan()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Controls.Remove(knappPlan[i, j]);
                    Controls.Remove(labelPlan[i, j]);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (markeraBomber == false)
                markeraBomber = true;
            else
                markeraBomber = false;
        }
    }
}
