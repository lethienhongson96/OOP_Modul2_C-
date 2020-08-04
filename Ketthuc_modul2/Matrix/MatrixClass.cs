using System;
using System.Collections.Generic;
using System.Text;

namespace Matrix
{
    class MatrixClass
    {
        public static int[,] CreateMatrix(int sides)
        {
            int[,] SquareMatrix = new int[sides, sides];
            Random rnd = new Random();

            for (int i = 0; i < SquareMatrix.GetLength(0); i++)
            {

                for (int j = 0; j < SquareMatrix.GetLength(1); j++)
                {
                    SquareMatrix[i, j] = rnd.Next(40, 80);
                }

            }

            return SquareMatrix;
        }

        public static void ShowMatrix(int[,] Matrix)
        {
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {

                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Console.Write(Matrix[i, j] + "  ");
                }

                Console.WriteLine();
            }
        }

        public static int FindMin(int[,] Matrix)
        {
            int min = Matrix[0, 0];

            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {

                    if (min>Matrix[i,j])
                    {
                        min = Matrix[i, j];
                    }

                }
            }

            return min;
        }

        public int SumOfMainDia(int[,] Matrix)
        {
            int sumOfMain = 0;

            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                sumOfMain += Matrix[i, i];
            }

            return sumOfMain;
        }

        public int SumOfFillerDia(int[,] Matrix)
        {
            int sumOfFill = 0;
            int j = Matrix.GetLength(1) - 1;

            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                sumOfFill += Matrix[i, j];
                j--;
            }

            return sumOfFill;
        }

        public int DiagonalDifference(int[,] Matrix)
        {
            return Math.Abs(SumOfMainDia(Matrix) - SumOfFillerDia(Matrix));
        }
    }
}
