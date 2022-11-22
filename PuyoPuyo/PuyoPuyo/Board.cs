using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuyoPuyo {
    class Board
    {
        public int[,] Map = new int[12, 6];
        public int[,] copyMap = new int[12, 6];
        public int StartX = 0;
        public int StartY = 0;
        public Board() {
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
                        { 00,00,00,00,00,00 },};
            for (int y = 0; y < 12; y++)
                for (int x = 0; x < 6; x++)
                {
                    copyMap[y, x] = Map[y, x];
                }
            StartX = 3;
            StartY = 0;
        }
        public void CopyMap()
        {
            for (int y = 0; y < 12; y++)
                for (int x = 0; x < 6; x++)
                {
                    Map[y, x] = copyMap[y, x];
                }
        }
    }
}
