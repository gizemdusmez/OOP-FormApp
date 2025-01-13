namespace FlappyBird
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Score = new System.Windows.Forms.Label();
            this.gametimer = new System.Windows.Forms.Timer(this.components);
            this.pipeup = new System.Windows.Forms.PictureBox();
            this.bird = new System.Windows.Forms.PictureBox();
            this.pipedown = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pipeup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bird)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pipedown)).BeginInit();
            this.SuspendLayout();
            // 
            // Score
            // 
            this.Score.AutoSize = true;
            this.Score.Location = new System.Drawing.Point(63, 56);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(70, 25);
            this.Score.TabIndex = 5;
            this.Score.Text = "label1";
            this.Score.Click += new System.EventHandler(this.Score_Click);
            // 
            // gametimer
            // 
            this.gametimer.Enabled = true;
            this.gametimer.Interval = 20;
            this.gametimer.Tick += new System.EventHandler(this.GameTimerEvent);
            // 
            // pipeup
            // 
            this.pipeup.BackColor = System.Drawing.Color.Transparent;
            this.pipeup.Image = global::FlappyBird.Properties.Resources.toppipe;
            this.pipeup.Location = new System.Drawing.Point(615, 2);
            this.pipeup.Name = "pipeup";
            this.pipeup.Size = new System.Drawing.Size(164, 384);
            this.pipeup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pipeup.TabIndex = 4;
            this.pipeup.TabStop = false;
            // 
            // bird
            // 
            this.bird.BackColor = System.Drawing.Color.Transparent;
            this.bird.Image = global::FlappyBird.Properties.Resources.flappybird;
            this.bird.Location = new System.Drawing.Point(87, 481);
            this.bird.Name = "bird";
            this.bird.Size = new System.Drawing.Size(102, 84);
            this.bird.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bird.TabIndex = 3;
            this.bird.TabStop = false;
            // 
            // pipedown
            // 
            this.pipedown.BackColor = System.Drawing.Color.Transparent;
            this.pipedown.Image = global::FlappyBird.Properties.Resources.bottompipe;
            this.pipedown.Location = new System.Drawing.Point(557, 648);
            this.pipedown.Name = "pipedown";
            this.pipedown.Size = new System.Drawing.Size(170, 381);
            this.pipedown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pipedown.TabIndex = 2;
            this.pipedown.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::FlappyBird.Properties.Resources.flappybirdbg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(856, 1041);
            this.Controls.Add(this.Score);
            this.Controls.Add(this.pipeup);
            this.Controls.Add(this.bird);
            this.Controls.Add(this.pipedown);
            this.Name = "Form1";
            this.Text = "Flapp Bird Game";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gamekeydown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gamekeyup);
            ((System.ComponentModel.ISupportInitialize)(this.pipeup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bird)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pipedown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pipedown;
        private System.Windows.Forms.PictureBox bird;
        private System.Windows.Forms.PictureBox pipeup;
        private System.Windows.Forms.Label Score;
        private System.Windows.Forms.Timer gametimer;
    }
}

