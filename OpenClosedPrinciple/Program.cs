
public interface IOperation
{
    double Calculate(double x, double y);
}

public class AddOperation : IOperation
{
    public double Calculate(double x, double y)
    {
        return x + y;
    }
}

public class MultiplyOperation : IOperation
{
    public double Calculate(double x, double y)
    {
        return x * y;
    }
}

public class Calculator
{
    public double Calculate(IOperation operation, double x, double y)
    {
        return operation.Calculate(x, y);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Calculator calculator = new Calculator();

        IOperation addOperation = new AddOperation();
        double result = calculator.Calculate(addOperation, 3, 4);
        Console.WriteLine("3 + 4 = " + result);

        IOperation multiplyOperation = new MultiplyOperation();
        result = calculator.Calculate(multiplyOperation, 3, 4);
        Console.WriteLine("3 * 4 = " + result);

        Console.ReadKey();
    }
}


