class Program
{
    public static void Main()
    {
        Console.WriteLine(missingNumber([3,0,1]));
    }

    public static int missingNumber(int[] array)
    {
        int total = 0;
        int max = array[0];
        foreach (int item in array)
        {
            total += item;
            if(item > max)
            {
                max = item;
            }
        }
        int realTotal = max * (max + 1) / 2;
        return realTotal - total;
    }
}