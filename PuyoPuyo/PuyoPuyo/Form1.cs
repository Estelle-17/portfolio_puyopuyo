using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuyoPuyo {
    public partial class Form1 : Form {
        Graphics g;
        private Board board = new Board();
        private Player player;
        private bool isKeyDown;
        private Keys keyCode;
        private bool isUp;
        private bool isDown;
        private bool isLeft;
        private bool isRight;
        private bool isSpace;
        private int Y;
        public int cnt;
        public int BlockNum = 0;
        public int score;
        public int BombBlockCnt;
        public int ScoreStack;
        public int DeleteCount;
        private bool gameSet;
        public bool IsBlockDelete;
        public bool IsBlockDeletePaint;
        public bool ChangeTimer;
        public bool GameStop;
        public int TimerCnt;
        public int EnemySpawnCount;
        public float ExtraTime;
        public List<int> bulletDirection;
        public List<int> bulletPositionX;
        public List<int> bulletPositionY;

        private Bitmap bitmap;
        public int[] StickBlock = new int[4];
        public int[,] Map = new int[14, 6];
        public int[,] CheckMap = new int[14, 6];
        public int[,] BlockArr = new int[3, 2];
        public int[] BlockHeight;
        public int BlockAngle;
        public int BlockPos;

        private Random rand;

        private String labelText;
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {  
            timer1.Enabled = false;
            timer2.Enabled = false;
            timer2.Interval = 25;
            ScoreStack = 1;
            DeleteCount = 0;

            player = new Player(board.StartX, board.StartY, PlayerImagelist, board, this);

            bitmap = new Bitmap(PlayerImagelist.Images[0], new Size(50, 50));
            bitmap.MakeTransparent(Color.Black);

            isKeyDown = false;

            rand = new Random();
            score = 0;
            gameSet = false;
            IsBlockDelete = false;
            IsBlockDeletePaint = false;
            ChangeTimer = false;
            GameStop = true;
            ExtraTime = 0;
            TimerCnt = 0;
            isUp = false;
            Y = -50;

            Map = new int[,] {
                        { 00,00,00,00,00,00 },
                        { 00,00,00,00,00,00 },
                        { 00,00,00,00,00,00 },
                        { 00,00,00,00,00,00 },
                        { 00,00,00,00,00,00 },
                        { 00,00,00,00,00,00 },
                        { 00,00,00,00,00,00 },
                        { 00,00,00,00,00,00 },
                        { 00,00,00,00,00,00 },
                        { 00,00,00,00,00,00 },
                        { 00,00,00,00,00,00 },
                        { 00,00,00,00,00,00 },
                        { 00,00,00,00,00,00 },
                        { 00,00,00,00,00,00 },};

            CheckMap = new int[,] {
                        { 00,00,00,00,00,00 },
                        { 00,00,00,00,00,00 },
                        { 00,00,00,00,00,00 },
                        { 00,00,00,00,00,00 },
                        { 00,00,00,00,00,00 },
                        { 00,00,00,00,00,00 },
                        { 00,00,00,00,00,00 },
                        { 00,00,00,00,00,00 },
                        { 00,00,00,00,00,00 },
                        { 00,00,00,00,00,00 },
                        { 00,00,00,00,00,00 },
                        { 00,00,00,00,00,00 },
                        { 00,00,00,00,00,00 },
                        { 00,00,00,00,00,00 },};

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 2; j++)
                    BlockArr[i, j] = rand.Next(5);

            BlockHeight = new int[6];
            for (int i = 0; i < 6; i++)
                BlockHeight[i] = 0;

            BlockAngle = 0;
            BlockPos = 2;
            labelText = String.Format("Score : {0}", score);
            label1.Text = labelText;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            isKeyDown = true;
            if (keyCode != e.KeyCode)
                keyCode = e.KeyCode;
            if (e.KeyCode == Keys.Up) {
                isUp = true;
            }
            if (e.KeyCode == Keys.Down) {
                isDown = true;
            }
            if (e.KeyCode == Keys.Left) {
                isLeft = true;
            }
            if (e.KeyCode == Keys.Right) {
                isRight = true;
            }
            if(e.KeyCode == Keys.Space) {
                isSpace = true;
            }

            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Up) {
                isUp = false;
            }
            if (e.KeyCode == Keys.Down) {
                isDown = false;
            }
            if (e.KeyCode == Keys.Left) {
                isLeft = false;
            }
            if (e.KeyCode == Keys.Right) {
                isRight = false;
            }
            if (e.KeyCode == Keys.Space) {
                isSpace = false;
            }

            isKeyDown = false;
        }

        //칸마다 사이값 52
        //가로 0-52-104-156-208-260
        //세로 575-523-471-491-367-315-263-211-159-107-55-0

        private void panel1_Paint(object sender, PaintEventArgs e) {
            g = e.Graphics;

            if (!GameStop) {
                switch (BlockAngle) {
                    case 0:
                        bitmap = new Bitmap(PlayerImagelist.Images[BlockArr[0, 0]], new Size(50, 50));
                        bitmap.MakeTransparent(Color.Black);
                        g.DrawImage(bitmap, new Point(52 * BlockPos, Y));
                        bitmap = new Bitmap(PlayerImagelist.Images[BlockArr[0, 1]], new Size(50, 50));
                        bitmap.MakeTransparent(Color.Black);
                        g.DrawImage(bitmap, new Point(52 * BlockPos, Y - 52));
                        break;
                    case 1:
                        bitmap = new Bitmap(PlayerImagelist.Images[BlockArr[0, 0]], new Size(50, 50));
                        bitmap.MakeTransparent(Color.Black);
                        g.DrawImage(bitmap, new Point(52 * BlockPos, Y));
                        bitmap = new Bitmap(PlayerImagelist.Images[BlockArr[0, 1]], new Size(50, 50));
                        bitmap.MakeTransparent(Color.Black);
                        g.DrawImage(bitmap, new Point(52 * (BlockPos + 1), Y));
                        break;
                    case 2:
                        bitmap = new Bitmap(PlayerImagelist.Images[BlockArr[0, 0]], new Size(50, 50));
                        bitmap.MakeTransparent(Color.Black);
                        g.DrawImage(bitmap, new Point(52 * BlockPos, Y));
                        bitmap = new Bitmap(PlayerImagelist.Images[BlockArr[0, 1]], new Size(50, 50));
                        bitmap.MakeTransparent(Color.Black);
                        g.DrawImage(bitmap, new Point(52 * BlockPos, Y + 52));
                        break;
                    case 3:
                        bitmap = new Bitmap(PlayerImagelist.Images[BlockArr[0, 0]], new Size(50, 50));
                        bitmap.MakeTransparent(Color.Black);
                        g.DrawImage(bitmap, new Point(52 * BlockPos, Y));
                        bitmap = new Bitmap(PlayerImagelist.Images[BlockArr[0, 1]], new Size(50, 50));
                        bitmap.MakeTransparent(Color.Black);
                        g.DrawImage(bitmap, new Point(52 * (BlockPos - 1), Y));
                        break;
                }
            }
            if (IsBlockDeletePaint){
                for (int y = 2; y < 14; y++)
                    for (int x = 0; x < 6; x++){
                        if (Map[y, x] != 0 && CheckMap[y, x] == 0){
                            bitmap = new Bitmap(PlayerImagelist.Images[Map[y, x] - 1], new Size(50, 50));
                            bitmap.MakeTransparent(Color.Black);
                            g.DrawImage(bitmap, new Point(51 * x, 575 - ((14 - y - 1) * 51)));
                        }
                    }
            } else {
                for (int y = 2; y < 14; y++)
                    for (int x = 0; x < 6; x++){
                        if (Map[y, x] != 0){
                            bitmap = new Bitmap(PlayerImagelist.Images[Map[y, x] - 1], new Size(50, 50));
                            bitmap.MakeTransparent(Color.Black);
                            g.DrawImage(bitmap, new Point(51 * x, 575 - ((14 - y - 1) * 51)));
                        }
                    }
            }

            labelText = String.Format("Score : {0}", score);
            label1.Text = labelText;
            if (gameSet) {
                GameOver();
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e) {
            g = e.Graphics;

            bitmap = new Bitmap(PlayerImagelist.Images[BlockArr[1, 0]], new Size(50, 50));
            bitmap.MakeTransparent(Color.Black);
            g.DrawImage(bitmap, new Point(388, 80));
            bitmap = new Bitmap(PlayerImagelist.Images[BlockArr[1, 1]], new Size(50, 50));
            bitmap.MakeTransparent(Color.Black);
            g.DrawImage(bitmap, new Point(388, 132));

            bitmap = new Bitmap(PlayerImagelist.Images[BlockArr[2, 0]], new Size(50, 50));
            bitmap.MakeTransparent(Color.Black);
            g.DrawImage(bitmap, new Point(433, 190));
            bitmap = new Bitmap(PlayerImagelist.Images[BlockArr[2, 1]], new Size(50, 50));
            bitmap.MakeTransparent(Color.Black);
            g.DrawImage(bitmap, new Point(433, 242));

            if (ChangeTimer) {
                timer1.Enabled = false;
                timer2.Enabled = true;
            } else if (!ChangeTimer) {
                timer1.Enabled = true;
                timer2.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            if (!GameStop) {
                if (isKeyDown) {
                    if (isUp) {
                        BlockAngle--;
                        if (BlockAngle < 0)
                            BlockAngle += 4;
                        TurnBlock(true);
                        isKeyDown = false;
                    } else if (isRight && BlockPos <= 4 && 575 - (BlockHeight[BlockPos + 1] * 52) > Y) {
                        BlockPos++;
                        isKeyDown = false;
                    } else if (isDown) {
                        BlockAngle++;
                        if (BlockAngle > 3)
                            BlockAngle -= 4;
                        TurnBlock(false);
                        isKeyDown = false;
                    } else if (isLeft && BlockPos >= 1 && 575 - (BlockHeight[BlockPos - 1] * 52) > Y) {
                        BlockPos--;
                        isKeyDown = false;
                    }
                }

                if (Y < 575) {
                    if (isSpace)
                        Y += 10;
                    else
                        Y += 3;
                }

                if (BlockAngle == 1 && BlockPos == 5)
                    BlockPos = 4;
                if (BlockAngle == 3 && BlockPos == 0)
                    BlockPos = 1;

                if (574 - (BlockHeight[BlockPos] * 52) < Y ||
                    BlockAngle == 1 && 575 - (BlockHeight[BlockPos + 1] * 52) < Y  ||
                    BlockAngle == 2 && 575 - (BlockHeight[BlockPos] * 52) - 52 < Y ||
                    BlockAngle == 3 && 575 - (BlockHeight[BlockPos - 1] * 52) < Y ) {
                    switch (BlockAngle) {
                        case 0:
                            Map[14 - BlockHeight[BlockPos] - 2, BlockPos] = BlockArr[0, 1] + 1;
                            Map[14 - BlockHeight[BlockPos] - 1, BlockPos] = BlockArr[0, 0] + 1;
                            BlockHeight[BlockPos] += 2;
                            break;
                        case 1:
                            Map[14 - BlockHeight[BlockPos] - 1, BlockPos] = BlockArr[0, 0] + 1;
                            Map[14 - BlockHeight[BlockPos + 1] - 1, BlockPos + 1] = BlockArr[0, 1] + 1;
                            BlockHeight[BlockPos] += 1;
                            BlockHeight[BlockPos + 1] += 1;
                            break;
                        case 2:
                            Map[14 - BlockHeight[BlockPos] - 2, BlockPos] = BlockArr[0, 0] + 1;
                            Map[14 - BlockHeight[BlockPos] - 1, BlockPos] = BlockArr[0, 1] + 1;
                            BlockHeight[BlockPos] += 2;
                            break;
                        case 3:
                            Map[14 - BlockHeight[BlockPos] - 1, BlockPos] = BlockArr[0, 0] + 1;
                            Map[14 - BlockHeight[BlockPos - 1] - 1, BlockPos - 1] = BlockArr[0, 1] + 1;
                            BlockHeight[BlockPos] += 1;
                            BlockHeight[BlockPos - 1] += 1;
                            break;
                    }

                    score += 75;

                    BlockConnect();
                    CheckStuckBlockCount();
                    //블록 4개이상 확인
                    for (int y = 2; y < 14; y++)
                        for (int x = 0; x < 6; x++) {
                            if (CheckMap[y, x] != 0) {
                                ChangeTimer = true;
                            }
                        }

                    BombBlockCnt = 0;
                    Y = -50;
                    for (int i = 0; i < 2; i++) {
                        BlockArr[i, 0] = BlockArr[i + 1, 0];
                        BlockArr[i, 1] = BlockArr[i + 1, 1];
                    }
                    BlockArr[2, 0] = rand.Next(5);
                    BlockArr[2, 1] = rand.Next(5);
                    BlockAngle = 0;
                    Invalidate();
                    BlockPos = 2;
                    CheckDeadBlock();
                    ExtraTime = 0;
                }
                Invalidate();
                panel1.Invalidate();
            }
        }

        private void timer2_Tick(object sender, EventArgs e){

            if (IsBlockDeletePaint && TimerCnt < 15)
                IsBlockDeletePaint = false;
            else if (!IsBlockDeletePaint && TimerCnt < 15)
                IsBlockDeletePaint = true;

            TimerCnt++;
            if (TimerCnt >= 15) {
                IsBlockDeletePaint = false;
                for (int y = 2; y < 14; y++)
                    for (int x = 0; x < 6; x++) {
                        if (CheckMap[y, x] != 0) {
                            if (Map[y, x] > 5 && Map[y, x] <= 21)
                                Map[y, x] = 21;
                            else if (Map[y, x] > 21 && Map[y, x] <= 37)
                                Map[y, x] = 37;
                            else if (Map[y, x] > 37 && Map[y, x] <= 53)
                                Map[y, x] = 53;
                            else if (Map[y, x] > 53 && Map[y, x] <= 69)
                                Map[y, x] = 69;
                            else if (Map[y, x] > 69 && Map[y, x] <= 84)
                                Map[y, x] = 85;
                        }
                    }
            }
            if (TimerCnt >= 24) {
                TimerCnt = 0;
                CheckStuckBlockDelete();
                score += (150 * DeleteCount) + (250 * (ScoreStack - 1)) * ScoreStack;
                ScoreStack++;
                DeleteCount = 0;
                for (int z = 0; z < 12; z++) {
                    for (int y = 13; y >= 2; y--) {
                        for (int x = 0; x < 6; x++) {
                            if (Map[y, x] == 0 && Map[y - 1, x] != 0) {
                                Map[y, x] = Map[y - 1, x];
                                Map[y - 1, x] = 0;
                                if (y != 13)
                                    y++;
                            }
                        }
                    }
                }
                BombBlockCnt = 0;
                BlockConnect();
                CheckStuckBlockCount();
                ChangeTimer = false;

                //블록 4개이상 확인
                for (int y = 2; y < 14; y++)
                    for (int x = 0; x < 6; x++) {
                        if (CheckMap[y, x] != 0) {
                            ChangeTimer = true;
                        }
                    }

                if (!ChangeTimer)
                    NextBlock();
            }

            panel1.Invalidate();
        }

        public void TurnBlock(bool isUp) {
           
            if (BlockAngle == 1) {
                if (BlockPos == 0) {
                    if (575 - (BlockHeight[BlockPos + 1] * 52) < Y) {
                        if (BlockAngle == 1 && isUp)
                            BlockAngle = 0;
                        else if (BlockAngle == 1 && !isUp)
                            BlockAngle = 2;
                    }
                } else if (BlockPos == 5) {
                    if (575 - (BlockHeight[BlockPos - 1] * 52) < Y) {
                        if (BlockAngle == 1 && isUp)
                            BlockAngle = 0;
                        else if (BlockAngle == 1 && !isUp)
                            BlockAngle = 2;
                    }
                } else {
                    if (BlockAngle == 1 && BlockPos == 5)
                        BlockPos = 4;
                    if (BlockAngle == 3 && BlockPos == 0)
                        BlockPos = 1;

                    if (575 - (BlockHeight[BlockPos + 1] * 52) < Y) {
                        if (575 - (BlockHeight[BlockPos - 1] * 52) < Y) {
                            if (BlockAngle == 1 && isUp)
                                BlockAngle = 0;
                            else if (BlockAngle == 1 && !isUp)
                                BlockAngle = 2;
                        } else {
                            BlockPos--;
                        }
                    }
                }
            }

            if (BlockAngle == 3) {
                if (BlockPos == 0) {
                    if (575 - (BlockHeight[BlockPos + 1] * 52) < Y) {
                        if (BlockAngle == 3 && isUp)
                            BlockAngle = 2;
                        else if (BlockAngle == 3 && !isUp)
                            BlockAngle = 0;
                    }
                } else if (BlockPos == 5) {
                    if (575 - (BlockHeight[BlockPos - 1] * 52) < Y) {
                        if (BlockAngle == 3 && isUp)
                            BlockAngle = 2;
                        else if (BlockAngle == 3 && !isUp)
                            BlockAngle = 0;
                    }
                } else {
                    if (BlockAngle == 1 && BlockPos == 5)
                        BlockPos = 4;
                    if (BlockAngle == 3 && BlockPos == 0)
                        BlockPos = 1;

                    if (575 - (BlockHeight[BlockPos - 1] * 52) < Y) {
                        if (575 - (BlockHeight[BlockPos + 1] * 52) < Y) {
                            if (BlockAngle == 3 && isUp)
                                BlockAngle = 2;
                            else if (BlockAngle == 3 && !isUp)
                                BlockAngle = 0;
                        } else {
                            BlockPos++;
                        }
                    }
                }      
            }
        }

        public void NextBlock() {
            ChangeTimer = false;
            CheckDeadBlock();
            Invalidate();
            ScoreStack = 1;
        }

        public void CheckDeadBlock() {
            if(Map[2, 2] != 0 || Map[2, 3] != 0) {
                GameOver();
            }
        }

        public void CheckStuckBlockDelete() {
            //블록 4개이상 확인 후 제거
            for (int y = 2; y < 14; y++)
                for (int x = 0; x < 6; x++) {
                    if (CheckMap[y, x] != 0) {
                        Map[y, x] = 0;
                        DeleteCount ++;
                        BlockHeight[x]--;
                        IsBlockDelete = true;
                    }
                }

            //체크맵 초기화
            for (int y = 0; y < 14; y++)
                for (int x = 0; x < 6; x++)
                    CheckMap[y, x] = 0;
        }

        public void CheckStuckBlockCount() {
            BombBlockCnt = 1;
            cnt = 0;
            for (int y = 2; y < 14; y++)
                for (int x = 0; x < 6; x++) {
                    if (Map[y, x] != 0 && CheckMap[y, x] == 0) {
                        cnt = 1;
                        if (y != 2) {
                            if (StickBlockCalc(y, x, y - 1, x)) {
                                CheckMap[y, x] = BombBlockCnt;
                                CheckBlock(y - 1, x);
                            }
                        }
                        if (x != 5) {
                            if (StickBlockCalc(y, x, y, x + 1)) {
                                CheckMap[y, x] = BombBlockCnt;
                                CheckBlock(y, x + 1);
                            }
                        }
                        if (y != 13) {
                            if (StickBlockCalc(y, x, y + 1, x)) {
                                CheckMap[y, x] = BombBlockCnt;
                                CheckBlock(y + 1, x);
                            }
                        }
                        if (x != 0) {
                            if (StickBlockCalc(y, x, y, x - 1)) {
                                CheckMap[y, x] = BombBlockCnt;
                                CheckBlock(y, x - 1);
                            }
                        }

                        if (cnt < 4) {
                            if (Map[y, x] != 0 && CheckMap[y, x] == BombBlockCnt) {
                                if (y != 2) {
                                    if (StickBlockCalc(y, x, y - 1, x)) {
                                        CheckMap[y, x] = 0;
                                        ReturnBlock(y - 1, x, BombBlockCnt);
                                    }
                                }
                                if (x != 5) {
                                    if (StickBlockCalc(y, x, y, x + 1)) {
                                        CheckMap[y, x] = 0;
                                        ReturnBlock(y, x + 1, BombBlockCnt);
                                    }
                                }
                                if (y != 13) {
                                    if (StickBlockCalc(y, x, y + 1, x)) {
                                        CheckMap[y, x] = 0;
                                        ReturnBlock(y + 1, x, BombBlockCnt);
                                    }
                                }
                                if (x != 0) {
                                    if (StickBlockCalc(y, x, y, x - 1)) {
                                        CheckMap[y, x] = 0;
                                        ReturnBlock(y, x - 1, BombBlockCnt);
                                    }
                                }
                            }
                        } else {
                            BombBlockCnt++;
                        }
                    }
                   
                }
        }
        public void CheckBlock(int y, int x) {
            cnt++;
            CheckMap[y, x] = BombBlockCnt;
            if (y != 2) {
                if (StickBlockCalc(y, x, y - 1, x) && CheckMap[y - 1, x] == 0) {
                    CheckBlock(y - 1, x);
                }
            }
            if (x != 5) {
                if (StickBlockCalc(y, x, y, x + 1) && CheckMap[y, x + 1] == 0) {
                    CheckBlock(y, x + 1);
                }
            }
            if (y != 13) {
                if (StickBlockCalc(y, x, y + 1, x) && CheckMap[y + 1, x] == 0) {
                    CheckBlock(y + 1, x);
                }
            }
            if (x != 0) {
                if (StickBlockCalc(y, x, y, x - 1) && CheckMap[y, x - 1] == 0) {
                    CheckBlock(y, x - 1);
                }
            }
        }

        public void ReturnBlock(int y, int x, int Num) {
            CheckMap[y, x] = 0;
            if (y != 2) {
                if (CheckMap[y - 1, x] == Num) {
                    ReturnBlock(y - 1, x, Num);
                }
            }
            if (x != 5) {
                if (CheckMap[y, x + 1] == Num) {
                    ReturnBlock(y, x + 1, Num);
                }
            }
            if (y != 13) {
                if (CheckMap[y + 1, x] == Num) {
                    ReturnBlock(y + 1, x, Num);
                }
            }
            if (x != 0) {
                if (CheckMap[y, x - 1] == Num) {
                    ReturnBlock(y, x - 1, Num);
                }
            }
        }

        public void BlockConnect() { // 주변 블록이 있는지 계산 후 알맞은 블록으로 변환
            cnt = 0;
            for (int y = 2; y < 14; y++)
                for (int x = 0; x < 6; x++) {
                    if (Map[y, x] != 0) {
                        cnt = 0;
                        for (int z = 0; z < 4; z++) {
                            StickBlock[z] = 0;
                        }
                        if (y != 2) {
                            if (StickBlockCalc(y, x, y - 1, x)) {
                                StickBlock[0] = 1;
                                cnt++;
                            }
                        }
                        if (x != 5) {
                            if (StickBlockCalc(y, x, y, x + 1)) {
                                StickBlock[1] = 1;
                                cnt++;
                            }
                        }
                        if (y != 13) {
                            if (StickBlockCalc(y, x, y + 1, x)) {
                                StickBlock[2] = 1;
                                cnt++;
                            }
                        }
                        if (x != 0) {
                            if (StickBlockCalc(y, x, y, x - 1)) {
                                StickBlock[3] = 1;
                                cnt++;
                            }
                        }
                        if (cnt >= 1)
                        {
                            if (Map[y, x] <= 5)
                            {
                                switch (Map[y, x])
                                {
                                    case 1:
                                        Map[y, x] = 6 + BlockConnectCalc();
                                        break;
                                    case 2:
                                        Map[y, x] = 22 + BlockConnectCalc();
                                        break;
                                    case 3:
                                        Map[y, x] = 38 + BlockConnectCalc();
                                        break;
                                    case 4:
                                        Map[y, x] = 54 + BlockConnectCalc();
                                        break;
                                    case 5:
                                        Map[y, x] = 70 + BlockConnectCalc();
                                        break;
                                }
                            }
                            else if (Map[y, x] > 5 && Map[y, x] <= 85)
                            {
                                if (Map[y, x] > 5 && Map[y, x] <= 21)
                                    BlockNum = 1;
                                else if (Map[y, x] > 21 && Map[y, x] <= 37)
                                    BlockNum = 2;
                                else if (Map[y, x] > 37 && Map[y, x] <= 53)
                                    BlockNum = 3;
                                else if (Map[y, x] > 53 && Map[y, x] <= 69)
                                    BlockNum = 4;
                                else if (Map[y, x] > 69 && Map[y, x] <= 84)
                                    BlockNum = 5;

                                switch (BlockNum)
                                {
                                    case 1:
                                        Map[y, x] = 6 + BlockConnectCalc();
                                        break;
                                    case 2:
                                        Map[y, x] = 22 + BlockConnectCalc();
                                        break;
                                    case 3:
                                        Map[y, x] = 38 + BlockConnectCalc();
                                        break;
                                    case 4:
                                        Map[y, x] = 54 + BlockConnectCalc();
                                        break;
                                    case 5:
                                        Map[y, x] = 70 + BlockConnectCalc();
                                        break;
                                }
                            }
                        }
                        else if (cnt == 0){
                            if (Map[y, x] > 5 && Map[y, x] <= 21)
                                Map[y, x] = 1;
                            else if (Map[y, x] > 21 && Map[y, x] <= 37)
                                Map[y, x] = 2;
                            else if (Map[y, x] > 37 && Map[y, x] <= 53)
                                Map[y, x] = 3;
                            else if (Map[y, x] > 53 && Map[y, x] <= 69)
                                Map[y, x] = 4;
                            else if (Map[y, x] > 69 && Map[y, x] <= 84)
                                Map[y, x] = 5;
                        }
                    }
                }
        }

        public bool StickBlockCalc(int y, int x, int y1, int x1) {
            if (Map[y, x] == Map[y1, x1] ||
                            Map[y, x] >= 6 && Map[y, x] <= 21 && Map[y1, x1] >= 6 && Map[y1, x1] <= 21 || 
                            Map[y, x] == 1 && Map[y1, x1] >= 6 && Map[y1, x1] <= 21 ||
                            Map[y, x] >= 6 && Map[y, x] <= 21 && Map[y1, x1] == 1 ||
                            Map[y, x] >= 22 && Map[y, x] <= 37 && Map[y1, x1] >= 22 && Map[y1, x1] <= 37 ||
                            Map[y, x] == 2 && Map[y1, x1] >= 22 && Map[y1, x1] <= 37 ||
                            Map[y, x] >= 22 && Map[y, x] <= 37 && Map[y1, x1] == 2 ||
                            Map[y, x] >= 38 && Map[y, x] <= 53 && Map[y1, x1] >= 38 && Map[y1, x1] <= 53 ||
                            Map[y, x] == 3 && Map[y1, x1] >= 38 && Map[y1, x1] <= 53 ||
                            Map[y, x] >= 38 && Map[y, x] <= 53 && Map[y1, x1] == 3 ||
                            Map[y, x] >= 54 && Map[y, x] <= 69 && Map[y1, x1] >= 54 && Map[y1, x1] <= 69 ||
                            Map[y, x] == 4 && Map[y1, x1] >= 54 && Map[y1, x1] <= 69 ||
                            Map[y, x] >= 54 && Map[y, x] <= 69 && Map[y1, x1] == 4 ||
                            Map[y, x] >= 70 && Map[y, x] <= 85 && Map[y1, x1] >= 70 && Map[y1, x1] <= 85 ||
                            Map[y, x] == 5 && Map[y1, x1] >= 70 && Map[y1, x1] <= 85 ||
                            Map[y, x] >= 70 && Map[y, x] <= 85 && Map[y1, x1] == 5)
                return true;
            else
                return false;
        }

        public int BlockConnectCalc()  {
            if(StickBlock[0] == 0 && StickBlock[1] == 1 && StickBlock[2] == 1 && StickBlock[3] == 0) {
                return 0;
            }else if (StickBlock[0] == 0 && StickBlock[1] == 1 && StickBlock[2] == 1 && StickBlock[3] == 1) {
                return 1;
            } else if(StickBlock[0] == 0 && StickBlock[1] == 0 && StickBlock[2] == 1 && StickBlock[3] == 1) {
                return 2;
            } else if(StickBlock[0] == 1 && StickBlock[1] == 1 && StickBlock[2] == 1 && StickBlock[3] == 0) {
                return 3;
            } else if(StickBlock[0] == 1 && StickBlock[1] == 1 && StickBlock[2] == 1 && StickBlock[3] == 1) {
                return 4;
            } else if(StickBlock[0] == 1 && StickBlock[1] == 0 && StickBlock[2] == 1 && StickBlock[3] == 1) {
                return 5;
            } else if(StickBlock[0] == 1 && StickBlock[1] == 1 && StickBlock[2] == 0 && StickBlock[3] == 0) {
                return 6;
            } else if(StickBlock[0] == 1 && StickBlock[1] == 1 && StickBlock[2] == 0 && StickBlock[3] == 1) {
                return 7;
            } else if(StickBlock[0] == 1 && StickBlock[1] == 0 && StickBlock[2] == 0 && StickBlock[3] == 1) {
                return 8;
            } else if (StickBlock[0] == 0 && StickBlock[1] ==1 && StickBlock[2] == 0 && StickBlock[3] == 0) {
                return 9;
            } else if (StickBlock[0] == 0 && StickBlock[1] == 1 && StickBlock[2] == 0 && StickBlock[3] == 1) {
                return 10;
            } else if (StickBlock[0] == 0 && StickBlock[1] == 0 && StickBlock[2] == 0 && StickBlock[3] == 1) {
                return 11;
            } else if (StickBlock[0] == 0 && StickBlock[1] == 0 && StickBlock[2] == 1 && StickBlock[3] == 0) {
                return 12;
            } else if (StickBlock[0] == 1 && StickBlock[1] == 0 && StickBlock[2] == 1 && StickBlock[3] == 0) {
                return 13;
            } else if (StickBlock[0] == 1 && StickBlock[1] == 0 && StickBlock[2] == 0 && StickBlock[3] == 0) {
                return 14;
            }
            return 0;
        }

        public void GameOver() {
            GameStop = true;
            timer1.Enabled = false;
            timer2.Enabled = false;
            button2.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e) {
            GameStop = false;
            timer1.Enabled = true;
            timer1.Interval = 40;
            button1.Enabled = false;
            button2.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e) {
            button1.Enabled = true;
            timer1.Enabled = false;
            for (int y = 0; y < 14; y++)
                for (int x = 0; x < 6; x++)
                        Map[y, x] = 0;

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 2; j++)
                    BlockArr[i, j] = rand.Next(5);

            for (int i = 0; i < 6; i++)
                BlockHeight[i] = 0;

            BlockAngle = 0;
            BlockPos = 2;
            score = 0;
            gameSet = false;
            board.CopyMap();
            panel1.Invalidate();
            Invalidate();
        }
    }
}
