using System;
using System.Collections.Generic;

public interface IElement
{
    void Accept(IVisitor visitor);
}

public class ConcreteElementA : IElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.VisitConcreteElementA(this);
    }

    public void OperationA()
    {
        Console.WriteLine("Виконується операція A для ConcreteElementA");
    }
}

public class ConcreteElementB : IElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.VisitConcreteElementB(this);
    }

    public void OperationB()
    {
        Console.WriteLine("Виконується операція B для ConcreteElementB");
    }
}

public interface IVisitor
{
    void VisitConcreteElementA(ConcreteElementA element);
    void VisitConcreteElementB(ConcreteElementB element);
}

public class ConcreteVisitor : IVisitor
{
    public void VisitConcreteElementA(ConcreteElementA element)
    {
        Console.WriteLine("Відвідувач обробляє ConcreteElementA");
        element.OperationA();
    }

    public void VisitConcreteElementB(ConcreteElementB element)
    {
        Console.WriteLine("Відвідувач обробляє ConcreteElementB");
        element.OperationB();
    }
}

public class ObjectStructure
{
    private List<IElement> elements = new List<IElement>();

    public void Attach(IElement element)
    {
        elements.Add(element);
    }

    public void Detach(IElement element)
    {
        elements.Remove(element);
    }

    public void Accept(IVisitor visitor)
    {
        foreach (var element in elements)
        {
            element.Accept(visitor);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ObjectStructure structure = new ObjectStructure();
        structure.Attach(new ConcreteElementA());
        structure.Attach(new ConcreteElementB());

        IVisitor visitor = new ConcreteVisitor();
        structure.Accept(visitor);
    }
}
