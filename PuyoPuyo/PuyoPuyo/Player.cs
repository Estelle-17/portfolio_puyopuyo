using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuyoPuyo {
    class Player
    {
        public Graphics g;
        public Bitmap PlayerBitmap;
        public Form1 form;
        public Board board;
        //public PictureBox PacmanImage = new PictureBox();
        private ImageList PlayerImages = new ImageList();
        public Timer timer = new Timer();
        public int pX;
        public int pY;
		public int checkX;
		public int checkY;
        public int currentDirection = 1;
        
        public Player(){
            
        }
        public Player(int x, int y, ImageList imglist, Board board, Form1 form){
            this.form = form;
            this.board = board;
            pX = x * 24;
            pY = y * 24;
			checkX = x;
			checkY = y;

            for(int i = 0; i < imglist.Images.Count; i++)
                PlayerImages.Images.Add(imglist.Images[i]);

            PlayerBitmap = new Bitmap(PlayerImages.Images[0], new Size(35, 35));

            g = form.CreateGraphics();
            g.DrawImage(PlayerBitmap, new Point(pX, pY));
            g.Dispose();

            timer.Interval = 200;
            timer.Enabled = false;
            timer.Tick += new EventHandler(timer_Tick);
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            PlayerBitmap.Dispose();
        }

        public void StartGame()
        {
            timer.Enabled = true;
        }

        public void StopGame()
        {
            timer.Enabled = false;
        }

        public void ResetGame()
        {
            currentDirection = 1;
            pX = board.StartX * 24;
            pY = board.StartY * 24;
            checkX = board.StartX;
            checkY = board.StartY;

            PlayerBitmap = new Bitmap(PlayerImages.Images[1], new Size(35, 35));
            g.DrawImage(PlayerBitmap, new Point(pX, pY));
            g.Dispose();

            timer.Interval = 200;
            timer.Enabled = false;
            timer.Tick += new EventHandler(timer_Tick);
        }
    }
}
