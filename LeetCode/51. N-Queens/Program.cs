using System;
using System.Collections.Generic;
using System.Linq;
using Utility;

namespace _51._N_Queens
{
    class Program : BaseProgram
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();

            IList<IList<string>> a = s.SolveNQueens(4);

            Console.WriteLine("Hello World!");
        }
    }

    public class Solution
    {
        readonly IList<IList<string>> list = new List<IList<string>>();
        readonly List<string> track = new List<string>();
        const char EMPTY = '.';
        const char QUEUE = 'Q';
        private int N;
        public IList<IList<string>> SolveNQueens(int n)
        {
            if (n == 0) return list;
            N = n;
            Backtrack(0);
            return list;
        }

        // 路径：board 中小于 row 的那些行都已经成功放置了皇后
        // 选择列表：第 row 行的所有列都是放置皇后的选择
        // 结束条件：row 超过 board 的最后一行
        void Backtrack(int row)
        {
            // 触发结束条件
            if (row == N)
            {
                list.Add(new List<string>(track));
                return;
            }

            for (int col = 0; col < N; col++)
            {
                // 排除不合法选择
                if (!isValid(row, col)) continue;
                var s = Enumerable.Repeat(EMPTY,N).ToArray();
                s[col] = QUEUE;
                track.Add(new string(s));
                Backtrack(row + 1);
                track.RemoveAt(track.Count - 1);
            }
        }

        /// <summary>
        /// WRONG
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        bool isValid(int row, int col)
        {
            if (track == null || track.Count == 0) return true;
            // 检查列是否有皇后互相冲突
            for (int i = 0; i < track.Count; i++)
            {
                if (track[i][col] == 'Q')
                    return false;
            }
            // 检查右上方是否有皇后互相冲突
            for (int i = row - 1, j = col + 1;
                    i >= 0 && j < track.Count; i--, j++)
            {
                if (track[i][j] == 'Q')
                    return false;
            }
            // 检查左上方是否有皇后互相冲突
            for (int i = row - 1, j = col - 1;
                    i >= 0 && j >= 0; i--, j--)
            {
                if (track[i][j] == 'Q')
                    return false;
            }
            return true;
        }
    }
}
