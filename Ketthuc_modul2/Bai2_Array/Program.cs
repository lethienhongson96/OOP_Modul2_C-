using System;

namespace Bai2_Array
{
    class Program
    {
        public static int[] arr = new int[0];
        static void Main(string[] args)
        {
            do
            {
                Menu();
                int checkPress = MustIntNumber();

                if (checkPress == 5)
                    break;

                switch (checkPress)
                {
                    case 1:

                        Console.Write("nhap side: ");
                        arr = ArrayClass.CreateArr(MustIntNumber());

                        ArrayClass.PrintArr(arr);
                        break;

                    case 2:

                        if (ArrayClass.IsEmtyArray(arr))
                            Console.WriteLine(ArrayClass.IsSymmetryArray(arr));
                        else
                            Console.WriteLine(ArrayClass.emtyArrMess);

                        break;

                    case 3:

                        if (ArrayClass.IsEmtyArray(arr))
                        {
                            ArrayClass.BubbleSort(arr);
                            ArrayClass.PrintArr(arr);
                        }
                        else
                            Console.WriteLine(ArrayClass.emtyArrMess);

                        break;

                    case 4:
                        if (ArrayClass.IsEmtyArray(arr))
                        {
                            Console.WriteLine("enter the number you looking for: ");
                            int num = NumForFind();

                            ArrayClass arrayOb = new ArrayClass();
                            Console.WriteLine(arrayOb.Find(arr, num));
                        }
                        else
                            Console.WriteLine(ArrayClass.emtyArrMess);
                        break;
                }
            } while (true);

        }

        public static void Menu()
        {
            Console.WriteLine("1/tao mang");
            Console.WriteLine("2/kiem tra mang doi xung");
            Console.WriteLine("3/sap xep mang");
            Console.WriteLine("4/tim kiem mang");
            Console.WriteLine("5/thoat");
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

        public static int NumForFind()
        {
            int num;
            bool check;

            do
            {
                check = int.TryParse(Console.ReadLine(), out num);
                if (check == false)
                    Console.WriteLine("enter again");

            } while (check == false);

            return num;
        }
    }
}
