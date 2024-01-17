namespace CPT230RPG2
{
    partial class Battle
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            btnRun = new Button();
            pbxVillain0 = new PictureBox();
            pbxHero0 = new PictureBox();
            pbxHero1 = new PictureBox();
            pbrHero1 = new ProgressBar();
            pbrHero0 = new ProgressBar();
            pbrVillain0 = new ProgressBar();
            lblHero0 = new Label();
            lblHeroHP0 = new Label();
            lblHero1 = new Label();
            lblHeroHP1 = new Label();
            lblVillain0 = new Label();
            lblVillain1 = new Label();
            pbrVillain1 = new ProgressBar();
            pbxVillain1 = new PictureBox();
            lblVillainHP1 = new Label();
            lblVillainHP0 = new Label();
            gbxTurnOption = new GroupBox();
            btnCure = new Button();
            btnTarget2 = new Button();
            btnTarget1 = new Button();
            btnAttck = new Button();
            ((System.ComponentModel.ISupportInitialize)pbxVillain0).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxHero0).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxHero1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxVillain1).BeginInit();
            gbxTurnOption.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(221, 231);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(478, 328);
            textBox1.TabIndex = 0;
            // 
            // btnRun
            // 
            btnRun.Location = new Point(415, 605);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(112, 34);
            btnRun.TabIndex = 1;
            btnRun.Text = "GO";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnRun_Click;
            // 
            // pbxVillain0
            // 
            pbxVillain0.Image = CPT230RPGWithClasses.Properties.Resources.Garland;
            pbxVillain0.Location = new Point(33, 135);
            pbxVillain0.Name = "pbxVillain0";
            pbxVillain0.Size = new Size(151, 139);
            pbxVillain0.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxVillain0.TabIndex = 2;
            pbxVillain0.TabStop = false;
            // 
            // pbxHero0
            // 
            pbxHero0.Image = CPT230RPGWithClasses.Properties.Resources.Thief;
            pbxHero0.Location = new Point(800, 183);
            pbxHero0.Name = "pbxHero0";
            pbxHero0.Size = new Size(77, 91);
            pbxHero0.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxHero0.TabIndex = 3;
            pbxHero0.TabStop = false;
            // 
            // pbxHero1
            // 
            pbxHero1.Image = CPT230RPGWithClasses.Properties.Resources.Thief;
            pbxHero1.Location = new Point(800, 388);
            pbxHero1.Name = "pbxHero1";
            pbxHero1.Size = new Size(77, 94);
            pbxHero1.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxHero1.TabIndex = 4;
            pbxHero1.TabStop = false;
            // 
            // pbrHero1
            // 
            pbrHero1.Location = new Point(727, 349);
            pbrHero1.Name = "pbrHero1";
            pbrHero1.Size = new Size(150, 34);
            pbrHero1.TabIndex = 5;
            // 
            // pbrHero0
            // 
            pbrHero0.Location = new Point(728, 141);
            pbrHero0.Name = "pbrHero0";
            pbrHero0.Size = new Size(150, 34);
            pbrHero0.TabIndex = 6;
            // 
            // pbrVillain0
            // 
            pbrVillain0.Location = new Point(34, 91);
            pbrVillain0.Name = "pbrVillain0";
            pbrVillain0.Size = new Size(150, 34);
            pbrVillain0.TabIndex = 7;
            pbrVillain0.Value = 100;
            // 
            // lblHero0
            // 
            lblHero0.AutoSize = true;
            lblHero0.Location = new Point(731, 81);
            lblHero0.Name = "lblHero0";
            lblHero0.Size = new Size(59, 25);
            lblHero0.TabIndex = 8;
            lblHero0.Text = "label1";
            // 
            // lblHeroHP0
            // 
            lblHeroHP0.AutoSize = true;
            lblHeroHP0.Location = new Point(732, 113);
            lblHeroHP0.Name = "lblHeroHP0";
            lblHeroHP0.Size = new Size(59, 25);
            lblHeroHP0.TabIndex = 9;
            lblHeroHP0.Text = "label2";
            // 
            // lblHero1
            // 
            lblHero1.AutoSize = true;
            lblHero1.Location = new Point(727, 296);
            lblHero1.Name = "lblHero1";
            lblHero1.Size = new Size(59, 25);
            lblHero1.TabIndex = 10;
            lblHero1.Text = "label3";
            // 
            // lblHeroHP1
            // 
            lblHeroHP1.AutoSize = true;
            lblHeroHP1.Location = new Point(727, 321);
            lblHeroHP1.Name = "lblHeroHP1";
            lblHeroHP1.Size = new Size(59, 25);
            lblHeroHP1.TabIndex = 11;
            lblHeroHP1.Text = "label4";
            // 
            // lblVillain0
            // 
            lblVillain0.AutoSize = true;
            lblVillain0.Location = new Point(33, 33);
            lblVillain0.Name = "lblVillain0";
            lblVillain0.Size = new Size(59, 25);
            lblVillain0.TabIndex = 12;
            lblVillain0.Text = "label5";
            // 
            // lblVillain1
            // 
            lblVillain1.AutoSize = true;
            lblVillain1.Location = new Point(34, 300);
            lblVillain1.Name = "lblVillain1";
            lblVillain1.Size = new Size(59, 25);
            lblVillain1.TabIndex = 15;
            lblVillain1.Text = "label7";
            // 
            // pbrVillain1
            // 
            pbrVillain1.Location = new Point(35, 355);
            pbrVillain1.Name = "pbrVillain1";
            pbrVillain1.Size = new Size(150, 34);
            pbrVillain1.TabIndex = 14;
            pbrVillain1.Value = 100;
            // 
            // pbxVillain1
            // 
            pbxVillain1.Image = CPT230RPGWithClasses.Properties.Resources.Lich;
            pbxVillain1.Location = new Point(34, 399);
            pbxVillain1.Name = "pbxVillain1";
            pbxVillain1.Size = new Size(150, 160);
            pbxVillain1.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxVillain1.TabIndex = 13;
            pbxVillain1.TabStop = false;
            // 
            // lblVillainHP1
            // 
            lblVillainHP1.AutoSize = true;
            lblVillainHP1.Location = new Point(31, 327);
            lblVillainHP1.Name = "lblVillainHP1";
            lblVillainHP1.Size = new Size(59, 25);
            lblVillainHP1.TabIndex = 16;
            lblVillainHP1.Text = "label8";
            // 
            // lblVillainHP0
            // 
            lblVillainHP0.AutoSize = true;
            lblVillainHP0.Location = new Point(31, 61);
            lblVillainHP0.Name = "lblVillainHP0";
            lblVillainHP0.Size = new Size(59, 25);
            lblVillainHP0.TabIndex = 17;
            lblVillainHP0.Text = "label6";
            // 
            // gbxTurnOption
            // 
            gbxTurnOption.Controls.Add(btnCure);
            gbxTurnOption.Controls.Add(btnTarget2);
            gbxTurnOption.Controls.Add(btnTarget1);
            gbxTurnOption.Controls.Add(btnAttck);
            gbxTurnOption.Location = new Point(399, 580);
            gbxTurnOption.Name = "gbxTurnOption";
            gbxTurnOption.Size = new Size(300, 150);
            gbxTurnOption.TabIndex = 18;
            gbxTurnOption.TabStop = false;
            gbxTurnOption.Text = "groupBox1";
            gbxTurnOption.Visible = false;
            // 
            // btnCure
            // 
            btnCure.Location = new Point(11, 90);
            btnCure.Name = "btnCure";
            btnCure.Size = new Size(112, 34);
            btnCure.TabIndex = 3;
            btnCure.Text = "Cure";
            btnCure.UseVisualStyleBackColor = true;
            btnCure.Click += btnCure_Click;
            // 
            // btnTarget2
            // 
            btnTarget2.Location = new Point(147, 90);
            btnTarget2.Name = "btnTarget2";
            btnTarget2.Size = new Size(135, 34);
            btnTarget2.TabIndex = 2;
            btnTarget2.Text = "button2";
            btnTarget2.UseVisualStyleBackColor = true;
            btnTarget2.Visible = false;
            btnTarget2.Click += btnTarget2_Click;
            // 
            // btnTarget1
            // 
            btnTarget1.Location = new Point(147, 34);
            btnTarget1.Name = "btnTarget1";
            btnTarget1.Size = new Size(135, 34);
            btnTarget1.TabIndex = 1;
            btnTarget1.Text = "button1";
            btnTarget1.UseVisualStyleBackColor = true;
            btnTarget1.Visible = false;
            btnTarget1.Click += btnTarget1_Click;
            // 
            // btnAttck
            // 
            btnAttck.Location = new Point(11, 34);
            btnAttck.Name = "btnAttck";
            btnAttck.Size = new Size(112, 34);
            btnAttck.TabIndex = 0;
            btnAttck.Text = "Attack";
            btnAttck.UseVisualStyleBackColor = true;
            btnAttck.Click += btnAttck_Click;
            // 
            // Battle
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(913, 813);
            Controls.Add(gbxTurnOption);
            Controls.Add(lblVillainHP0);
            Controls.Add(lblVillainHP1);
            Controls.Add(lblVillain1);
            Controls.Add(pbrVillain1);
            Controls.Add(pbxVillain1);
            Controls.Add(lblVillain0);
            Controls.Add(lblHeroHP1);
            Controls.Add(lblHero1);
            Controls.Add(lblHeroHP0);
            Controls.Add(lblHero0);
            Controls.Add(pbrVillain0);
            Controls.Add(pbrHero0);
            Controls.Add(pbrHero1);
            Controls.Add(pbxHero1);
            Controls.Add(pbxHero0);
            Controls.Add(pbxVillain0);
            Controls.Add(btnRun);
            Controls.Add(textBox1);
            Name = "Battle";
            Text = "Battle";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pbxVillain0).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxHero0).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxHero1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxVillain1).EndInit();
            gbxTurnOption.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button btnRun;
        private PictureBox pbxVillain0;
        private PictureBox pbxHero0;
        private PictureBox pbxHero1;
        private ProgressBar pbrHero1;
        private ProgressBar pbrHero0;
        private ProgressBar pbrVillain0;
        private Label lblHero0;
        private Label lblHeroHP0;
        private Label lblHero1;
        private Label lblHeroHP1;
        private Label lblVillain0;
        private Label lblVillain1;
        private ProgressBar pbrVillain1;
        private PictureBox pbxVillain1;
        private Label lblVillainHP1;
        private Label lblVillainHP0;
        private GroupBox gbxTurnOption;
        private Button btnAttck;
        private Button btnTarget2;
        private Button btnTarget1;
        private Button btnCure;
    }
}