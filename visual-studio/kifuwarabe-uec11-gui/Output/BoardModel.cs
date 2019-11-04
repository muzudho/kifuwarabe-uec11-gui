﻿namespace KifuwarabeUec11Gui.Output
{
    using System.Collections.Generic;
    using KifuwarabeUec11Gui.InputScript;

    /// <summary>
    /// 盤だぜ☆（＾～＾）
    /// </summary>
    public class BoardModel
    {
        /// <summary>
        /// 19路盤☆（＾～＾）
        /// </summary>
        public static int RowSize => 19;

        /// <summary>
        /// 19路盤☆（＾～＾）
        /// </summary>
        public static int ColumnSize => 19;

        /// <summary>
        /// 19路盤の最終行のインデックス 0 から始まる（0 Origin）ので、 -1 する☆（＾～＾）
        /// </summary>
        public static int RowLastO0 => RowSize - 1;

        /// <summary>
        /// 石を置ける場所の数☆（＾～＾）
        /// </summary>
        public static int CellCount => RowSize * ColumnSize;

        /// <summary>
        /// 置いている石☆（＾～＾）
        /// </summary>
        public List<Stone> Stones { get; private set; }

        public BoardModel()
        {
            this.Stones = new List<Stone>();
            for (int i=0; i< BoardModel.CellCount; i++)
            {
                // 初期値は 空点 で☆（＾～＾）
                this.Stones.Add(Stone.None);
            }
        }

        public void SetStone(int zShapedIndex, Stone stone)
        {
            this.Stones[zShapedIndex] = stone;
        }
    }
}
