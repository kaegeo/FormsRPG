namespace CPT230RPGWithClasses
{
    partial class Start
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
            btnNewGame = new Button();
            btnContinueGame = new Button();
            btnLoadGame = new Button();
            SuspendLayout();
            // 
            // btnNewGame
            // 
            btnNewGame.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btnNewGame.Location = new Point(295, 140);
            btnNewGame.Name = "btnNewGame";
            btnNewGame.Size = new Size(318, 162);
            btnNewGame.TabIndex = 0;
            btnNewGame.Text = "New Game";
            btnNewGame.UseVisualStyleBackColor = true;
            btnNewGame.Click += btnNewGame_Click;
            // 
            // btnContinueGame
            // 
            btnContinueGame.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btnContinueGame.Location = new Point(295, 308);
            btnContinueGame.Name = "btnContinueGame";
            btnContinueGame.Size = new Size(318, 162);
            btnContinueGame.TabIndex = 1;
            btnContinueGame.Text = "Continue Game";
            btnContinueGame.UseVisualStyleBackColor = true;
            btnContinueGame.Click += btnContinueGame_Click;
            // 
            // btnLoadGame
            // 
            btnLoadGame.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btnLoadGame.Location = new Point(295, 476);
            btnLoadGame.Name = "btnLoadGame";
            btnLoadGame.Size = new Size(318, 162);
            btnLoadGame.TabIndex = 2;
            btnLoadGame.Text = "Load Game";
            btnLoadGame.UseVisualStyleBackColor = true;
            btnLoadGame.Click += btnLoadGame_Click;
            // 
            // Start
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(913, 813);
            Controls.Add(btnLoadGame);
            Controls.Add(btnContinueGame);
            Controls.Add(btnNewGame);
            Name = "Start";
            Text = "Start";
            ResumeLayout(false);
        }

        #endregion

        private Button btnNewGame;
        private Button btnContinueGame;
        private Button btnLoadGame;
    }
}