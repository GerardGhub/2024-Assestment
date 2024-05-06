﻿using System;

class Program
{
    /// <summary>
    /// Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1 and 2, the first 10 terms will be: 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ... By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms
    /// 
    /// initilize the var maxlimit to store the upper limit of fibo seq 
    /// using while loop the exceed the value of a as 1
    /// inner loop check if its even if yes add the sum variable using modulo operator
    /// updating next fibo term setting  a to b and b to the next term inner variable to the sum of previos terms as (a+b)
    /// </summary>
    static void Main()
    {
        int maxlimit  = 4000000;
        int sum = 0;
        int a = 1;
        int b = 2;

        while (a <=  maxlimit)
        {
            if (a % 2 == 0)
            {
                sum += a;

            }

            int nextTerm = a + b;
            a = b;
            b = nextTerm;   
        }

        Console.Write("Exercise 2");
        Console.WriteLine("");
        Console.WriteLine("the sum of even valued terms in the fibo seq below four million is: " + sum);
    }


}