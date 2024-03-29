using System;

public class Context
{
    private IStrategy strategy;

    public Context(IStrategy strategy)
    {
        this.strategy = strategy;
    }

    public void ExecuteStrategy()
    {
        strategy.Execute();
    }

    public void SetStrategy(IStrategy strategy)
    {
        this.strategy = strategy;
    }
}

public interface IStrategy
{
    void Execute();
}

public class ConcreteStrategy1 : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Виконується конкретна стратегія 1");
    }
}

public class ConcreteStrategy2 : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Виконується конкретна стратегія 2");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.InputEncoding = System.Text.Encoding.Unicode;
        Console.OutputEncoding = System.Text.Encoding.Unicode;

        Context context = new Context(new ConcreteStrategy1());

        context.ExecuteStrategy();

        context.SetStrategy(new ConcreteStrategy2());

        context.ExecuteStrategy();
    }
}
