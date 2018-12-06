using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace Team02.Scene.Stage.GameObjs
{
    public class BlockGroup
    {
        private static byte[,] OffI = new byte[3, 3];
        private StageMap stageMap;
        private Block[,] blocks;
        private Point size;

        public List<BlockGroup> blockGroups { get => stageMap.BlockGroups; }
        public Point Size { get => size; }

        public BlockGroup(StageMap stageMap, Point size)
        {
            this.stageMap = stageMap;
            this.size = size;
            blocks = new Block[size.X, size.Y];
        }

        public static void SetOffI()
        {
            OffI[0, 0] = 1;
            OffI[1, 0] = 2;
            OffI[2, 0] = 4;
            OffI[0, 1] = 8;
            OffI[1, 1] = 0;
            OffI[2, 1] = 16;
            OffI[0, 2] = 32;
            OffI[1, 2] = 64;
            OffI[2, 2] = 128;
        }

        public void AddObj(Point coo, Block block)
        {
            blocks[coo.X, coo.Y] = block;
            block.SetGroupCoo(this, coo);
            Offset();
        }

        public void RemoveObj(Block block)
        {
            var coo = block.GroupCoo;
            blocks[coo.X, coo.Y] = null;
            block.SetGroupCoo(this, default(Point));
            Offset();
        }

        public void RemoveObj(Point coo)
        {
            var block = blocks[coo.X, coo.Y];
            blocks[coo.X, coo.Y] = null;
            block.SetGroupCoo(this, default(Point));
            Offset();
        }

        public void Offset()
        {
            for (int i = 0; i < size.X; i++)
            {
                for (int j = 0; j < size.Y; j++)
                {
                    Offset(i, j);
                }
            }
        }

        public void Offset(int x, int y)
        {
            var block = blocks[x, y];
            byte offset = 0;
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    int ci = x + i;
                    int cj = y + j;
                    if (ci < 0 || cj < 0 || ci >= size.X || cj >= size.Y || blocks[x, y] == null)
                        continue;
                    offset += OffI[i + i, j + 1];
                }
            }
            block.EOffset = (EOffset)offset;
        }
    }
}
