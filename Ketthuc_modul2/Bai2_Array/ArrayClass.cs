using System;
using System.Collections.Generic;
using System.Text;

namespace Bai2_Array
{
    class ArrayClass
    {
        public static string emtyArrMess = "ban chua tao mang !!!";
        public static int[] CreateArr(int side)
        {
            int[] arr = new int[side];
            Random rnd = new Random();

            for (int i = 0; i < side; i++)
            {
                arr[i] = rnd.Next(10, 50);
            }

            return arr;
        }

        public bool IsIncrement(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    return false;
                }
            }

            return true;

        }

        public string Find(int[] arr, int val)
        {
            if (IsIncre(arr) == false)
                return "mang khong phai la mot mang tang dan !!!";

            int low = 0;
            int high = arr.Length - 1;

            while (high >= low)
            {
                int mid = (low + high) / 2;
                if (val < arr[mid])
                    high = mid - 1;

                else if (val == arr[mid])
                    return $"tim thay tai vi tri: {mid}";

                else
                    low = mid + 1;
            }
            return "khong tim thay";
        }

        public static void PrintArr(int[] arr)
        {
                string str = "";
                for (int i = 0; i < arr.Length; i++)
                {
                    str += $"{arr[i]} ";
                }

                Console.WriteLine(str);
        }

        public static bool IsSymmetryArray(int[] arr)
        {
            for (int i = 0; i < arr.Length / 2; i++)
            {
                if (arr[i] != arr[arr.Length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsIncre(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] >= arr[i + 1])
                {
                    return false;
                }
            }

            return true;

        }

        public static bool IsEmtyArray(int[] arr)
        {
            if (arr.Length == 0)
                return false;
            else
                return true;
        }

        public static void BubbleSort(int[] arr)
        {
                int i, j, temp;
                int n = arr.Length;
                bool swapped;
                for (i = 0; i < n - 1; i++)
                {
                    swapped = false;
                    for (j = 0; j < n - i - 1; j++)
                    {
                        if (arr[j] > arr[j + 1])
                        {
                            temp = arr[j];
                            arr[j] = arr[j + 1];
                            arr[j + 1] = temp;
                            swapped = true;
                        }
                    }

                    if (swapped == false)
                        break;
                }
        }
    }
}
