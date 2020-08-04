using System;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("enter the side  for matrix: ");
            int side = MustIntNumber();

            int[,] Matrix1 = MatrixClass.CreateMatrix(side);
            MatrixClass.ShowMatrix(Matrix1);

            Console.WriteLine(MatrixClass.FindMin(Matrix1)); 

            MatrixClass matrixOb = new MatrixClass();
            Console.WriteLine(matrixOb.DiagonalDifference(Matrix1));
        }

        public static int MustIntNumber()
        {
            int num;
            bool check;

            do
            {
                check = int.TryParse(Console.ReadLine(), out num);
                if (check == false || num < 1)
                {
                    Console.WriteLine("enter again");
                    check = false;
                }

            } while (check == false);

            return num;
        }
    }
}
