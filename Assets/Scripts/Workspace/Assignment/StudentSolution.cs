using UnityEngine;
using Debug = AssignmentSystem.Services.AssignmentDebugConsole;
using System;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine.Experimental.AI;
using PlasticPipe.PlasticProtocol.Messages;

namespace Assignment
{
    public class StudentSolution : IAssignment
    {

        private static readonly int[] up = new int[] {-1,-1, 0, 1, 1, 1, 0, -1 };
        private static readonly int[] down = new int[] { 0, 1, 1, 1, 0, -1, -1, -1 };

        public void EXAM01_FindWords(string[,] board, string[] words)
        {
            if (board == null || words == null ) return;

            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            var found = new List<string>();
            foreach (var word in words)
            {
                if (string.IsNullOrEmpty(word)) continue;
                bool exists = FOUNDYOU(board, rows, cols, word);
                if (exists)
                 {
                    found.Add(word);
                }
            }

            for (int i = 0; i < found.Count; i++)
            {
                Debug.Log(found[i]);
            }
        }

        private bool FOUNDYOU(string[,] board, int rows, int cols, string word)
         {
            bool[,] CheckROWSandCOLS = new bool[rows, cols];
            char first = word[0];
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (CHARACTERCELLS(board, r, c) == first)
                    {
                        if (AISUS(board, rows, cols, word, 0, r, c, CheckROWSandCOLS))
                            return true;
                    }
                }
            }

            return false;
         }
          private bool AISUS(string[,] board, int rows, int cols, string word, int idx, int r, int c, bool[,] checknvisited)
        {
            if (idx == word.Length) return true;

            if (r < 0 || c < 0 || r >= rows || c >= cols) return false;
            if (checknvisited[r, c]) return false;

            if (CHARACTERCELLS(board, r, c) != word[idx]) return false;

            checknvisited[r, c] = true;
            if (idx == word.Length - 1)
            {
                checknvisited[r, c] = false;
                return true;
            }

            for (int k = 0; k < 8; k++)
            {
                int nr = r + up[k];
                int nc = c + down[k];

                if (AISUS(board, rows, cols, word, idx + 1, nr, nc, checknvisited))
                {
                    checknvisited[r, c] = false;
                    return true;
                }
            }
            checknvisited[r, c] = false;
            return false;
        }

        private char CHARACTERCELLS(string[,] board, int r, int c)
        {
            
            string s = board[r, c];
            return string.IsNullOrEmpty(s)?'\0': s[0];
        }
    }
}