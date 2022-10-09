// See https://aka.ms/new-console-template for more information
using System.Globalization;
using System.Text;
using static Testing_Calculator.CustomExceptions;

var keepAlive = true;
decimal intOne = 0;
decimal intTwo = 0;
string operand = "";
ConsoleKeyInfo status;
decimal[] arr = new decimal[20];
Calculations c = new Calculations();


while (keepAlive)
{
    decimal result = 0;
    decimal resultA = 0;
    int counter = 1;
    var divZero = false;
    var operandT = true;
    var moreValues = true;

    while (operandT)
    {
        Console.Write("Enter type of calculation +,-,*,/.");
        try
        {
            operand = (Console.ReadLine() ?? "");
            
            if (operand == "+" || operand == "-" || operand == "*" || operand == "/")
            {
                operandT = false;
            }
            else
            {
                throw new NonOperandException();
            }
        }
        catch (NonOperandException ex)
        {
            Console.WriteLine($"Error: {ex:Message}");
            Console.ReadKey();
            Console.Clear();
        }
    }
    
    Console.Write("Enter first integer:");
    try
    {
        intOne = Convert.ToDecimal(Console.ReadLine() ?? "");
        arr[0] = intOne;
        
    }
    catch (FormatException ex)
    {
        Console.WriteLine($"Error: {ex:Message}");
        Console.ReadKey();
        Console.Clear();
    }

    if (operand == "/")
    {
        while (!divZero)
        {
            Console.Write("Enter second integer:");
            try
            {
                intTwo = Convert.ToDecimal(Console.ReadLine() ?? "");
                if (intTwo == 0)
                {
                    divZero = false;
                    throw new DivideByZeroException();
                }
                else
                {
                    divZero = true;
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: {ex:Message}");
                Console.ReadKey();
                Console.Clear();
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error: {ex:Message}");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
    else
    {
        Console.Write("Enter second integer:");
        intTwo = Convert.ToDecimal(Console.ReadLine() ?? "");
        arr[1] = intTwo;
    }

    if (operand == "+" || operand == "-")
    {
        while (moreValues)
        {   
            Console.WriteLine("Do you want to add more numbers? (Y/y)");
            status = Console.ReadKey();

            if (status.Key == ConsoleKey.Y)
            {
                counter++;
                moreValues = true;
                Console.Write("Add another value:");
                try
                {
                    arr[counter] = Convert.ToDecimal(Console.ReadLine() ?? "");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Error: {ex:Message}");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            else
            {
                moreValues = false;
            }
        }

    }

    switch (operand)
    {
        case "+":
            
            if (counter > 0 )
            {
                result = c.Addition(arr);
            }
            else
            {
                result = c.Addition(intOne, intTwo);
            }
            break;
        case "*":
            result = c.Multiply(intOne, intTwo);
            break;
        case "-":
            if (counter > 0)
            {
                result = c.Subtract(arr);
            }
            else
            {
                result = c.Subtract(intOne, intTwo);
            }
            break;
        case "/":
            result = c.Divide(intOne, intTwo);
            break;
        default:
            break;
    }

    Console.Clear();
    Console.WriteLine("The result is {0}", result);

    Console.WriteLine("Do you want to quit? (Y/y)");
    status = Console.ReadKey();
    
    if (status.Key == ConsoleKey.Y)
    {
        keepAlive = false;
        break;
    }

    Array.Clear(arr, 0, arr.Length);
    Console.Clear();
}

public class Calculations
{
    decimal Result;
    public decimal Addition(decimal param1, decimal param2)
    {
        Result = param1 + param2;      
        return Result;
    }
    public decimal Addition(decimal[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Result += arr[i];
        }
        return Result;
    }
    public decimal Multiply(decimal param1, decimal param2)
    {
        Result = param1 * param2;
        return Result;
    }
    public decimal Subtract(decimal param1, decimal param2)
    {
        Result = param1 - param2;
        return Result;
    }

    public decimal Subtract(decimal[] arr)
    {
        Result = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            Result -= arr[i];
        }
        return Result;
    }
    public decimal Divide(decimal param1, decimal param2)
    {
        Result = param1 / param2;
        return Result;
    }

}
