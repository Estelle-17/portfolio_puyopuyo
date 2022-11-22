namespace PuyoPuyo {
    partial class Form1 {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// this.panel1 = new DoubleBufferdPanel();
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new DoubleBufferdPanel();
            this.PlayerImagelist = new System.Windows.Forms.ImageList(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 20000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(125)))), ((int)(((byte)(71)))));
            this.label1.Font = new System.Drawing.Font("굴림", 20F);
            this.label1.Location = new System.Drawing.Point(452, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("굴림", 15F);
            this.button1.Location = new System.Drawing.Point(558, 581);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 45);
            this.button1.TabIndex = 3;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("굴림", 15F);
            this.button2.Location = new System.Drawing.Point(558, 632);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 48);
            this.button2.TabIndex = 4;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Location = new System.Drawing.Point(31, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(316, 627);
            this.panel1.TabIndex = 5;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // PlayerImagelist
            // 
            this.PlayerImagelist.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("PlayerImagelist.ImageStream")));
            this.PlayerImagelist.TransparentColor = System.Drawing.Color.Transparent;
            this.PlayerImagelist.Images.SetKeyName(0, "Blue.png");
            this.PlayerImagelist.Images.SetKeyName(1, "Green.png");
            this.PlayerImagelist.Images.SetKeyName(2, "Purple.png");
            this.PlayerImagelist.Images.SetKeyName(3, "Red.png");
            this.PlayerImagelist.Images.SetKeyName(4, "Yellow.png");
            this.PlayerImagelist.Images.SetKeyName(5, "Blue1.png");
            this.PlayerImagelist.Images.SetKeyName(6, "Blue2.png");
            this.PlayerImagelist.Images.SetKeyName(7, "Blue3.png");
            this.PlayerImagelist.Images.SetKeyName(8, "Blue4.png");
            this.PlayerImagelist.Images.SetKeyName(9, "Blue5.png");
            this.PlayerImagelist.Images.SetKeyName(10, "Blue6.png");
            this.PlayerImagelist.Images.SetKeyName(11, "Blue7.png");
            this.PlayerImagelist.Images.SetKeyName(12, "Blue8.png");
            this.PlayerImagelist.Images.SetKeyName(13, "Blue9.png");
            this.PlayerImagelist.Images.SetKeyName(14, "Blue10.png");
            this.PlayerImagelist.Images.SetKeyName(15, "Blue11.png");
            this.PlayerImagelist.Images.SetKeyName(16, "Blue12.png");
            this.PlayerImagelist.Images.SetKeyName(17, "Blue13.png");
            this.PlayerImagelist.Images.SetKeyName(18, "Blue14.png");
            this.PlayerImagelist.Images.SetKeyName(19, "Blue15.png");
            this.PlayerImagelist.Images.SetKeyName(20, "BlueDead.png");
            this.PlayerImagelist.Images.SetKeyName(21, "Green1.png");
            this.PlayerImagelist.Images.SetKeyName(22, "Green2.png");
            this.PlayerImagelist.Images.SetKeyName(23, "Green3.png");
            this.PlayerImagelist.Images.SetKeyName(24, "Green4.png");
            this.PlayerImagelist.Images.SetKeyName(25, "Green5.png");
            this.PlayerImagelist.Images.SetKeyName(26, "Green6.png");
            this.PlayerImagelist.Images.SetKeyName(27, "Green7.png");
            this.PlayerImagelist.Images.SetKeyName(28, "Green8.png");
            this.PlayerImagelist.Images.SetKeyName(29, "Green9.png");
            this.PlayerImagelist.Images.SetKeyName(30, "Green10.png");
            this.PlayerImagelist.Images.SetKeyName(31, "Green11.png");
            this.PlayerImagelist.Images.SetKeyName(32, "Green12.png");
            this.PlayerImagelist.Images.SetKeyName(33, "Green13.png");
            this.PlayerImagelist.Images.SetKeyName(34, "Green14.png");
            this.PlayerImagelist.Images.SetKeyName(35, "Green15.png");
            this.PlayerImagelist.Images.SetKeyName(36, "GreenDead.png");
            this.PlayerImagelist.Images.SetKeyName(37, "Purple1.png");
            this.PlayerImagelist.Images.SetKeyName(38, "Purple2.png");
            this.PlayerImagelist.Images.SetKeyName(39, "Purple3.png");
            this.PlayerImagelist.Images.SetKeyName(40, "Purple4.png");
            this.PlayerImagelist.Images.SetKeyName(41, "Purple5.png");
            this.PlayerImagelist.Images.SetKeyName(42, "Purple6.png");
            this.PlayerImagelist.Images.SetKeyName(43, "Purple7.png");
            this.PlayerImagelist.Images.SetKeyName(44, "Purple8.png");
            this.PlayerImagelist.Images.SetKeyName(45, "Purple9.png");
            this.PlayerImagelist.Images.SetKeyName(46, "Purple10.png");
            this.PlayerImagelist.Images.SetKeyName(47, "Purple11.png");
            this.PlayerImagelist.Images.SetKeyName(48, "Purple12.png");
            this.PlayerImagelist.Images.SetKeyName(49, "Purple13.png");
            this.PlayerImagelist.Images.SetKeyName(50, "Purple14.png");
            this.PlayerImagelist.Images.SetKeyName(51, "Purple15.png");
            this.PlayerImagelist.Images.SetKeyName(52, "PurpleDead.png");
            this.PlayerImagelist.Images.SetKeyName(53, "Red1.png");
            this.PlayerImagelist.Images.SetKeyName(54, "Red2.png");
            this.PlayerImagelist.Images.SetKeyName(55, "Red3.png");
            this.PlayerImagelist.Images.SetKeyName(56, "Red4.png");
            this.PlayerImagelist.Images.SetKeyName(57, "Red5.png");
            this.PlayerImagelist.Images.SetKeyName(58, "Red6.png");
            this.PlayerImagelist.Images.SetKeyName(59, "Red7.png");
            this.PlayerImagelist.Images.SetKeyName(60, "Red8.png");
            this.PlayerImagelist.Images.SetKeyName(61, "Red9.png");
            this.PlayerImagelist.Images.SetKeyName(62, "Red10.png");
            this.PlayerImagelist.Images.SetKeyName(63, "Red11.png");
            this.PlayerImagelist.Images.SetKeyName(64, "Red12.png");
            this.PlayerImagelist.Images.SetKeyName(65, "Red13.png");
            this.PlayerImagelist.Images.SetKeyName(66, "Red14.png");
            this.PlayerImagelist.Images.SetKeyName(67, "Red15.png");
            this.PlayerImagelist.Images.SetKeyName(68, "RedDead.png");
            this.PlayerImagelist.Images.SetKeyName(69, "Yellow1.png");
            this.PlayerImagelist.Images.SetKeyName(70, "Yellow2.png");
            this.PlayerImagelist.Images.SetKeyName(71, "Yellow3.png");
            this.PlayerImagelist.Images.SetKeyName(72, "Yellow4.png");
            this.PlayerImagelist.Images.SetKeyName(73, "Yellow5.png");
            this.PlayerImagelist.Images.SetKeyName(74, "Yellow6.png");
            this.PlayerImagelist.Images.SetKeyName(75, "Yellow7.png");
            this.PlayerImagelist.Images.SetKeyName(76, "Yellow8.png");
            this.PlayerImagelist.Images.SetKeyName(77, "Yellow9.png");
            this.PlayerImagelist.Images.SetKeyName(78, "Yellow10.png");
            this.PlayerImagelist.Images.SetKeyName(79, "Yellow11.png");
            this.PlayerImagelist.Images.SetKeyName(80, "Yellow12.png");
            this.PlayerImagelist.Images.SetKeyName(81, "Yellow13.png");
            this.PlayerImagelist.Images.SetKeyName(82, "Yellow14.png");
            this.PlayerImagelist.Images.SetKeyName(83, "Yellow15.png");
            this.PlayerImagelist.Images.SetKeyName(84, "YellowDead.png");
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(708, 720);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ImageList PlayerImagelist;
        private System.Windows.Forms.Timer timer2;
        public System.Windows.Forms.Panel panel1;
    }
    //public System.Windows.Forms.Panel panel1;
}

