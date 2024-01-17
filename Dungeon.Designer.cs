namespace CPT230RPGWithClasses
{
    partial class Dungeon
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
            btnUseItem = new Button();
            lblEquipped = new Label();
            lstEquipped = new ListBox();
            gbxMoveSpeed = new GroupBox();
            rdoSprint = new RadioButton();
            rdoWalk = new RadioButton();
            lblInventory = new Label();
            cbxInventory = new ComboBox();
            txtMiniMap = new TextBox();
            txtOutput = new TextBox();
            txtKeyInv = new TextBox();
            btnAction = new Button();
            btnWest = new Button();
            btnEast = new Button();
            btnSouth = new Button();
            btnNorth = new Button();
            rtxOutputRoom = new RichTextBox();
            pbxMapThief = new PictureBox();
            pbxMapPlayer = new PictureBox();
            gbxMoveSpeed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxMapThief).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxMapPlayer).BeginInit();
            SuspendLayout();
            // 
            // btnUseItem
            // 
            btnUseItem.Location = new Point(575, 388);
            btnUseItem.Name = "btnUseItem";
            btnUseItem.Size = new Size(112, 34);
            btnUseItem.TabIndex = 29;
            btnUseItem.Text = "Use Item";
            btnUseItem.UseVisualStyleBackColor = true;
            btnUseItem.Click += btnUseItem_Click;
            // 
            // lblEquipped
            // 
            lblEquipped.AutoSize = true;
            lblEquipped.Location = new Point(575, 474);
            lblEquipped.Name = "lblEquipped";
            lblEquipped.Size = new Size(88, 25);
            lblEquipped.TabIndex = 28;
            lblEquipped.Text = "Equipped";
            // 
            // lstEquipped
            // 
            lstEquipped.FormattingEnabled = true;
            lstEquipped.ItemHeight = 25;
            lstEquipped.Location = new Point(575, 502);
            lstEquipped.Name = "lstEquipped";
            lstEquipped.Size = new Size(182, 129);
            lstEquipped.TabIndex = 27;
            // 
            // gbxMoveSpeed
            // 
            gbxMoveSpeed.Controls.Add(rdoSprint);
            gbxMoveSpeed.Controls.Add(rdoWalk);
            gbxMoveSpeed.Location = new Point(417, 698);
            gbxMoveSpeed.Name = "gbxMoveSpeed";
            gbxMoveSpeed.Size = new Size(165, 90);
            gbxMoveSpeed.TabIndex = 26;
            gbxMoveSpeed.TabStop = false;
            gbxMoveSpeed.Text = "Move Speed";
            // 
            // rdoSprint
            // 
            rdoSprint.AutoSize = true;
            rdoSprint.Location = new Point(6, 55);
            rdoSprint.Name = "rdoSprint";
            rdoSprint.Size = new Size(84, 29);
            rdoSprint.TabIndex = 1;
            rdoSprint.TabStop = true;
            rdoSprint.Text = "Sprint";
            rdoSprint.UseVisualStyleBackColor = true;
            // 
            // rdoWalk
            // 
            rdoWalk.AutoSize = true;
            rdoWalk.Checked = true;
            rdoWalk.Location = new Point(6, 30);
            rdoWalk.Name = "rdoWalk";
            rdoWalk.Size = new Size(75, 29);
            rdoWalk.TabIndex = 0;
            rdoWalk.TabStop = true;
            rdoWalk.Text = "Walk";
            rdoWalk.UseVisualStyleBackColor = true;
            // 
            // lblInventory
            // 
            lblInventory.AutoSize = true;
            lblInventory.Location = new Point(575, 317);
            lblInventory.Name = "lblInventory";
            lblInventory.Size = new Size(87, 25);
            lblInventory.TabIndex = 25;
            lblInventory.Text = "Inventory";
            // 
            // cbxInventory
            // 
            cbxInventory.FormattingEnabled = true;
            cbxInventory.Items.AddRange(new object[] { "Rock", "Stick", "Rope" });
            cbxInventory.Location = new Point(575, 346);
            cbxInventory.Name = "cbxInventory";
            cbxInventory.Size = new Size(182, 33);
            cbxInventory.TabIndex = 24;
            // 
            // txtMiniMap
            // 
            txtMiniMap.BackColor = SystemColors.ControlLight;
            txtMiniMap.BorderStyle = BorderStyle.FixedSingle;
            txtMiniMap.Font = new Font("Lucida Console", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtMiniMap.Location = new Point(575, 48);
            txtMiniMap.Multiline = true;
            txtMiniMap.Name = "txtMiniMap";
            txtMiniMap.Size = new Size(171, 137);
            txtMiniMap.TabIndex = 23;
            txtMiniMap.TextAlign = HorizontalAlignment.Center;
            // 
            // txtOutput
            // 
            txtOutput.Location = new Point(37, 390);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ReadOnly = true;
            txtOutput.Size = new Size(518, 241);
            txtOutput.TabIndex = 22;
            // 
            // txtKeyInv
            // 
            txtKeyInv.BackColor = SystemColors.GradientActiveCaption;
            txtKeyInv.BorderStyle = BorderStyle.None;
            txtKeyInv.Font = new Font("Lucida Console", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtKeyInv.Location = new Point(346, 355);
            txtKeyInv.Name = "txtKeyInv";
            txtKeyInv.Size = new Size(87, 18);
            txtKeyInv.TabIndex = 21;
            txtKeyInv.Text = "Keys: 0";
            txtKeyInv.TextAlign = HorizontalAlignment.Center;
            // 
            // btnAction
            // 
            btnAction.Location = new Point(446, 648);
            btnAction.Name = "btnAction";
            btnAction.Size = new Size(112, 33);
            btnAction.TabIndex = 20;
            btnAction.Text = "Action";
            btnAction.UseVisualStyleBackColor = true;
            btnAction.Click += btnAction_Click;
            // 
            // btnWest
            // 
            btnWest.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnWest.Location = new Point(37, 691);
            btnWest.Name = "btnWest";
            btnWest.Size = new Size(112, 33);
            btnWest.TabIndex = 19;
            btnWest.Text = "West";
            btnWest.UseVisualStyleBackColor = true;
            btnWest.Click += btnWest_Click;
            // 
            // btnEast
            // 
            btnEast.Location = new Point(273, 691);
            btnEast.Name = "btnEast";
            btnEast.Size = new Size(112, 33);
            btnEast.TabIndex = 18;
            btnEast.Text = "East";
            btnEast.UseVisualStyleBackColor = true;
            btnEast.Click += btnEast_Click;
            // 
            // btnSouth
            // 
            btnSouth.Location = new Point(155, 729);
            btnSouth.Name = "btnSouth";
            btnSouth.Size = new Size(112, 33);
            btnSouth.TabIndex = 17;
            btnSouth.Text = "South";
            btnSouth.UseVisualStyleBackColor = true;
            btnSouth.Click += btnSouth_Click;
            // 
            // btnNorth
            // 
            btnNorth.Location = new Point(155, 646);
            btnNorth.Name = "btnNorth";
            btnNorth.Size = new Size(112, 33);
            btnNorth.TabIndex = 16;
            btnNorth.Text = "North";
            btnNorth.UseVisualStyleBackColor = true;
            btnNorth.Click += btnNorth_Click;
            // 
            // rtxOutputRoom
            // 
            rtxOutputRoom.BackColor = Color.SandyBrown;
            rtxOutputRoom.BorderStyle = BorderStyle.None;
            rtxOutputRoom.Enabled = false;
            rtxOutputRoom.Font = new Font("Cascadia Code", 18F, FontStyle.Regular, GraphicsUnit.Point);
            rtxOutputRoom.Location = new Point(159, 25);
            rtxOutputRoom.Name = "rtxOutputRoom";
            rtxOutputRoom.ReadOnly = true;
            rtxOutputRoom.ScrollBars = RichTextBoxScrollBars.None;
            rtxOutputRoom.Size = new Size(289, 342);
            rtxOutputRoom.TabIndex = 15;
            rtxOutputRoom.Text = "WWWWWWWWWWWWW\nW00000000000W\nW00000000000W\nW00000000000W\nW00000000000W\nW00000000000W\nWWWWWWWWWWWWW";
            // 
            // pbxMapThief
            // 
            pbxMapThief.BackColor = Color.SandyBrown;
            pbxMapThief.Image = Properties.Resources.Thief_Left;
            pbxMapThief.Location = new Point(390, 271);
            pbxMapThief.Name = "pbxMapThief";
            pbxMapThief.Size = new Size(22, 31);
            pbxMapThief.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxMapThief.TabIndex = 30;
            pbxMapThief.TabStop = false;
            pbxMapThief.Visible = false;
            // 
            // pbxMapPlayer
            // 
            pbxMapPlayer.BackColor = Color.SandyBrown;
            pbxMapPlayer.Image = Properties.Resources.BlackMage_Front;
            pbxMapPlayer.Location = new Point(286, 177);
            pbxMapPlayer.Name = "pbxMapPlayer";
            pbxMapPlayer.Size = new Size(20, 30);
            pbxMapPlayer.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxMapPlayer.TabIndex = 31;
            pbxMapPlayer.TabStop = false;
            // 
            // Dungeon
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(913, 813);
            Controls.Add(pbxMapPlayer);
            Controls.Add(pbxMapThief);
            Controls.Add(btnUseItem);
            Controls.Add(lblEquipped);
            Controls.Add(lstEquipped);
            Controls.Add(gbxMoveSpeed);
            Controls.Add(lblInventory);
            Controls.Add(cbxInventory);
            Controls.Add(txtMiniMap);
            Controls.Add(txtOutput);
            Controls.Add(txtKeyInv);
            Controls.Add(btnAction);
            Controls.Add(btnWest);
            Controls.Add(btnEast);
            Controls.Add(btnSouth);
            Controls.Add(btnNorth);
            Controls.Add(rtxOutputRoom);
            Name = "Dungeon";
            Text = "Dungeon";
            Load += Dungeon_Load;
            gbxMoveSpeed.ResumeLayout(false);
            gbxMoveSpeed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbxMapThief).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxMapPlayer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnUseItem;
        private Label lblEquipped;
        private ListBox lstEquipped;
        private GroupBox gbxMoveSpeed;
        private RadioButton rdoSprint;
        private RadioButton rdoWalk;
        private Label lblInventory;
        private ComboBox cbxInventory;
        private TextBox txtMiniMap;
        private TextBox txtOutput;
        private TextBox txtKeyInv;
        private Button btnAction;
        private Button btnWest;
        private Button btnEast;
        private Button btnSouth;
        private Button btnNorth;
        private RichTextBox rtxOutputRoom;
        private PictureBox pbxMapThief;
        private PictureBox pbxMapPlayer;
    }
}