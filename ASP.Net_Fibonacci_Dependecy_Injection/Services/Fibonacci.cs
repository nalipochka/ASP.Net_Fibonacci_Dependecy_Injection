namespace ASP.Net_Fibonacci_Dependecy_Injection.Services
{
    public class FibonacciService
    {
        public long Fibonacci(int index)
        {
            long[] arr = new long[40];
            arr[0] = 0;
            arr[1] = 1;
            for (int i = 2; i < arr.Length; i++)
            {
                arr[i] = arr[i - 1] + arr[i - 2];
            }
            if (index == 0)
            {
                return arr[0];
            }
            else if (index == 1)
            {
                return arr[1];
            }
            else
            {
                return arr[index - 1];
            }

        }
    }
}
