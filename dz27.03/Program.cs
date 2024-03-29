using System;

public abstract class AbstractClass
{
    public void TemplateMethod()
    {
        BaseOperation1();
        RequiredOperation1();
        BaseOperation2();
        Hook1();
        ConcreteOperation();
        Hook2();
    }

    protected void BaseOperation1()
    {
        Console.WriteLine("Виконується базова операція 1");
    }

    protected void BaseOperation2()
    {
        Console.WriteLine("Виконується базова операція 2");
    }

    protected abstract void RequiredOperation1();

    protected virtual void Hook1() { }
    protected virtual void Hook2() { }

    private void ConcreteOperation()
    {
        Console.WriteLine("Виконується конкретна операція");
    }
}

public class ConcreteClass : AbstractClass
{
    protected override void RequiredOperation1()
    {
        Console.WriteLine("Виконується обов'язкова операція 1 для конкретного класу");
    }

    protected override void Hook2()
    {
        Console.WriteLine("Виконується додаткова перехідна операція 2 для конкретного класу");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.InputEncoding = System.Text.Encoding.Unicode;
        Console.OutputEncoding = System.Text.Encoding.Unicode;

        AbstractClass template = new ConcreteClass();
        template.TemplateMethod();
    }
}
