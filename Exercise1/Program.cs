using System;



class Program
{

    /// <summary>
    /// Initilize the Variable of sum
    /// iterate a for loop from 1 to 999 
    /// inner loop checking the current number is multiple of 3 of 5  using the module % operator.
    /// if the condition is true we add the current number to sum varible <3
    /// </summary>
    #region
    static void Main()
    {
        int sum = 0;

        for(int i = 1; i < 1000; i++) 
        {
            if (i % 3 == 0 || i % 5 == 0)
            {
                sum += i;
            }
        }
        Console.Write("Exercise 1");
        Console.WriteLine("");
        Console.WriteLine("the sum of all multiples of 3 or 5 below 1000 is " +  sum);
    }
    #endregion
}