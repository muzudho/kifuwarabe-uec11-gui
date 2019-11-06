﻿namespace KifuwarabeUec11Gui.InputScript.InternationalGo
{
    using System;
    using KifuwarabeUec11Gui.InputScript;
    using KifuwarabeUec11Gui.Output;

    /// <summary>
    /// 国際囲碁のセル番地表記☆（＾～＾）
    /// 
    /// このオブジェクトは、Z字方向式で使い回せるものは　どんどん使い回せだぜ☆（＾～＾）
    /// </summary>
    public class InternationalCellAddress : CellAddress
    {
        public InternationalCellAddress(InternationalRowAddress rowAddress, ColumnAddress columnAddress)
            : base(rowAddress, columnAddress)
        {
        }

        public new static (InternationalCellAddress, int) Parse(string text, int start, BoardModel model)
        {
            ColumnAddress columnAddress;
            var next = 0;
            {
                (columnAddress, next) = ColumnAddress.Parse(text, start, model);
                if (columnAddress == null)
                {
                    // 片方でもマッチしなければ、非マッチ☆（＾～＾）
                    return (null, start);
                }
            }

            // 列はマッチ☆（＾～＾）

            InternationalRowAddress rowAddress;
            {
                (rowAddress, next) = InternationalRowAddress.Parse(text, next, model);
                if (rowAddress == null)
                {
                    // 片方でもマッチしなければ、非マッチ☆（＾～＾）
                    return (null, start);
                }
            }

            // 列と行の両方マッチ☆（＾～＾）
            return (new InternationalCellAddress(rowAddress, columnAddress), next);
        }

        /// <summary>
        /// 盤の上下をひっくり返すぜ☆（＾～＾）
        /// </summary>
        /// <param name="rowNumberO0"></param>
        /// <param name="columnNumberO0"></param>
        /// <returns></returns>
        public new static int ToIndex(int rowNumberO0, int columnNumberO0, BoardModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return (model.GetRowLastO0() - rowNumberO0) * model.ColumnSize + columnNumberO0;
        }

        public new static InternationalCellAddress FromIndex(int zShapedIndexO0, BoardModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var rowNumberO0 = zShapedIndexO0 / model.ColumnSize;
            var columnNumberO0 = zShapedIndexO0 % model.ColumnSize;
            return new InternationalCellAddress(new InternationalRowAddress(rowNumberO0), new ColumnAddress(columnNumberO0));
        }
    }
}
