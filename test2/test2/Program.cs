using System;

class Program
{
    static int BinarySearch(int[] a, int n, int x)
    {
        int left = 0, right = n - 1, idx = -1;

        while (left <= right)
        {
            int middle = (left + right) / 2;

            if (a[middle] == x)
            {
                idx = middle;
                break;
            }
            else if (a[middle] > x)
            {
                right = middle - 1;
            }
            else
            {
                left = middle + 1;
            }
        }

        return idx;
    }

    static void Main()
    {
        // Khai báo mảng đã được sắp xếp
        int[] sortedArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int arraySize = sortedArray.Length;


        // Nhập giá trị cần tìm từ bàn phím
        Console.Write("Nhập giá trị cần tìm: ");
        int targetValue = Convert.ToInt32(Console.ReadLine());

        // Gọi hàm BinarySearch và in kết quả
        int resultIndex = BinarySearch(sortedArray, arraySize, targetValue);

        if (resultIndex != -1)
        {
            Console.WriteLine($"Giá tri {targetValue} đuoc tim thay tai chi so {resultIndex}");
        }
        else
        {
            Console.WriteLine($"Giá tri {targetValue} khong đuoc tim thay trong mang.");
        }
    }
}
