﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7
{
    class MatrixMultiplier
    {
        public int[,] First { get; set; }
        public int[,] Second { get; set; }
        public int[,] Result { get; private set; }

        public MatrixMultiplier(int[,] first, int[,] second)
        {
            First = first;
            Second = second;
            Result = new int[first.GetLength(1), second.GetLength(0)];
        }

        public void GenerateFirstMatrix(int rows, int columns)
        {
            First = new int[rows, columns];
            Random random = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    First[i, j] = random.Next(-100, 100);
                }
            }
        }

        public void GenerateSecondMatrix(int rows, int columns)
        {
            Second = new int[rows, columns];
            Random random = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Second[i, j] = random.Next(-100, 100);
                }
            }
        }

        public bool CheckMultiply()
        {
            if (First.GetLength(1) == Second.GetLength(0))
            {
                return true;
            }
            return false;
        }

        public void MultiplyElement(int i, int j)
        {
            Result[i, j] = 0; 
            for (int k = 0; k < this.First.GetLength(0); ++k)
            {
                this.Result[i, j] += this.First[i, k] * this.Second[k, j];
            }
        }


    }
}