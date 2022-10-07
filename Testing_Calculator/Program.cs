// See https://aka.ms/new-console-template for more information
using System.Text;
using static Testing_Calculator.CustomExceptions;

var keepAlive = true;
decimal intOne = 0;
decimal intTwo = 0;
string operand = "";
ConsoleKeyInfo status;


while (keepAlive)
{
    decimal result = 0;
    decimal resultA = 0;
    var divZero = false;
    var operandT = true;
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
    }

    decimal[] arr = { intOne, intTwo };

    Calculations c = new Calculations();

    switch (operand)
    {
        case "+":
            result = c.Addition(intOne, intTwo);
            resultA = c.Addition(arr);
            break;
        case "*":
            result = c.Multiply(intOne, intTwo);
            break;
        case "-":
            result = c.Subtract(intOne, intTwo);
            resultA = c.Subtract(arr);
            break;
        case "/":
            result = c.Divide(intOne, intTwo);
            break;
        default:
            break;
    }
    Console.ResetColor();
    Console.WriteLine("The result is {0}", result);
    Console.WriteLine("Array result is {0}", resultA);
    Console.WriteLine("Do you want to quit? (Y/y)");
    status = Console.ReadKey();
    if (status.Key == ConsoleKey.Y)
    {
        keepAlive = false;
        break;
    }
    Console.Clear();
}

public class Calculations
{
    public decimal Addition(decimal param1, decimal param2)
    {
        decimal Result = param1 + param2;
        return Result;
    }
    public decimal Addition(decimal[] arr)
    {
        decimal Result = arr[0] + arr[1];
        return Result;
    }
    public decimal Multiply(decimal param1, decimal param2)
    {
        decimal Result = param1 * param2;
        return Result;
    }
    public decimal Subtract(decimal param1, decimal param2)
    {
        decimal Result = param1 - param2;
        return Result;
    }

    public decimal Subtract(decimal[] arr)
    {
        decimal Result = arr[0] - arr[1];
        return Result;
    }
    public decimal Divide(decimal param1, decimal param2)
    {
        decimal Result = param1 / param2;
        return Result;
    }

}
