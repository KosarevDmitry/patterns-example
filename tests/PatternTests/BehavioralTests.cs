﻿using Patterns.Behavioral.ChainOfResponsibility;
using Patterns.Behavioral.ChainOfResponsibility.Calculator.Handlers;
using C = Patterns.Behavioral.Command.Calculator;
using Action = Patterns.Behavioral.ChainOfResponsibility.Calculator.Action;
using Patterns.Behavioral.ListOfSignatories;
using Patterns.Behavioral.ListOfSignatories.Signatories;
using Xunit.Abstractions;
using G = Patterns.Behavioral.Command.Garage;
using Patterns.Behavioral.Interpreter.RomanNumerals;
using Patterns.Behavioral.Iterator.Iteration;
using Patterns.Behavioral.Mediator.Chatroom;
using Patterns.Behavioral.Memento.Care;
using M = Patterns.Behavioral.Memento.MementoList;
using Patterns.Behavioral.State.Banking;
using Patterns.Behavioral.Strategy.Strategy;
using Patterns.Behavioral.Template.DAO;
using Patterns.Behavioral.Visitor.Employees;
using V = Patterns.Behavioral.Visitor.ExpressionPrinting;
using P = Patterns.Behavioral.Visitor.Painting;

namespace PatternTests.Patterns.Behavioral;

public class BehavioralTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public BehavioralTests(ITestOutputHelper testOutputHelper) => _testOutputHelper = testOutputHelper;


    [Theory]
    [InlineData(new double[] { 1, 2, 3, 4, 5 })]
    public void ChainOfResponsibility_Calculator(double[] n)
    {
        Addition       addition       = new();
        Subtraction    subtraction    = new();
        Multiplication multiplication = new();
        addition.AddChain(subtraction);
        subtraction.AddChain(multiplication);
        Assert.Equal(n.Sum(),                      addition.Handle(n, Action.Add));
        Assert.Equal(n.Aggregate((x, y) => x - y), addition.Handle(n, Action.Substruct));
        Assert.Equal(n.Aggregate((x, y) => x * y), addition.Handle(n, Action.Multiply));
        Assert.Throws<InvalidOperationException>(() => addition.Handle(n, Action.Divide));
    }


    [Fact]
    public void ChainOfResponsibility_Signatories()
    {
        var list = new Approvallist();
        Assert.True(list.All(v => v.Value == null));
        Chief     chief     = new();
        Finance   finance   = new();
        Marketing marketing = new();
        Sales     sales     = new();
        Secretary secretary = new();

        chief.AddChain(marketing);
        marketing.AddChain(sales);
        sales.AddChain(finance);
        finance.AddChain(chief);
        secretary.AddChain(chief);

        var result = chief.Handle(new object(), list);
        Assert.True(result.All(v => v.Value != null));
        var rejected = result.Where(v => v.Value.Approval == false).ToArray();
        Assert.Equal(2, rejected.Length);
        var rejectedDivisions = rejected.Select(x => x.Key).OrderBy(x => x).ToArray();

        Assert.True(Division.Chief == rejectedDivisions[0] && Division.Sales == rejectedDivisions[1]);
    }


    [Fact]
    public void Command_Garage()
    {
        var remoteControl = new G.RemoteControl(3);

        var bike          = new G.Garage("Bike");
        var bikeDoorClose = new G.GarageDoorCloseCommand(bike);
        var bikeDoorOpen  = new G.GarageDoorOpenCommand(bike);

        var car          = new G.Garage("Car");
        var carDoorClose = new G.GarageDoorCloseCommand(car);
        var carDoorOpen  = new G.GarageDoorOpenCommand(car);

        var garageButton = new G.OnOffStruct
        {
            On = bikeDoorOpen, Off = bikeDoorClose
        };

        remoteControl[0] = garageButton;
        remoteControl.PushOn(0);
        remoteControl.PushUndo();
        remoteControl.PushUndo();
        remoteControl.PushOff(0);

        _testOutputHelper.WriteLine("");
        var light = new G.Light("Hall");

        G.ICommand[] partyOn  = { new G.LightOffCommand(light), bikeDoorOpen, carDoorOpen };
        G.ICommand[] partyOff = { new G.LightOnCommand(light), bikeDoorClose, carDoorClose };

        remoteControl[2] = new G.OnOffStruct { On = new G.MacroCommand(partyOn), Off = new G.MacroCommand(partyOff) };

        try
        {
            remoteControl.PushOn(2);
            _testOutputHelper.WriteLine("");
            remoteControl.PushOff(2);
        }
        catch (Exception)
        {
            _testOutputHelper.WriteLine("Oops");
        }
    }


    /// <summary>
    /// A little bit modified version Command from <see href="https://www.dofactory.com/net/command-design-pattern">docfactory</see> 
    /// </summary>
    [Fact]
    public void Command_Calculator()
    {
        var user = new C.User();
        user.Compute('+', 100);
        Assert.True(user.Result == 100);
        user.Compute('-', 50);
        Assert.True(user.Result == 50);
        user.Compute('*', 10);
        Assert.True(user.Result == 500);
        user.Compute('/', 2);
        Assert.True(user.Result == 250);

        // Undo 4 commands
        user.Undo(4);
        Assert.True(user.Result == 0);

        // Redo 3 commands
        user.Redo(3);
        Assert.True(user.Result == 500);
    }

    /// <summary>
    /// Interpreter, a modified version from <see href="https://www.dofactory.com"/>
    /// </summary>
    [Theory]
    [InlineData("MCMXXVIII", 1928)]
    public void RomanNumerals(string n, int expected)
    {
        Context context = new(n);
        var expressions = new List<Expression>()
        {
            new ThousandExpression(), new HundredExpression(), new TenExpression(), new OneExpression()
        };

        foreach (Expression exp in expressions)
        {
            exp.Interpret(context);
        }

        Assert.Equal(expected, context.Output);
    }


    /// <see href="https://www.britannica.com/topic/Roman-numeral"/>
    [Theory]
    [InlineData("MCMXXVIII", 1928)]
    public void RomanNumerals_1(string n, int expected)
    {
        string[,] romenum = new string[4, 4]
        {
            { "M", " ", " ", " " }, { "C", "CD", "D", "CM" }, { "X", "XL", "L", "XC" }, { "I", "IV", "V", "IX" }
        };
        Assert.Equal(expected, 1928);
    }

    [Fact]
    public void Iteration()
    {
        DemoCollection collection = new();
        Enumerable.Range(0, 9).ToList().ForEach(x =>
            collection[x] = new Item($"Item {x}")
        );

        DemoIterator iterator = collection.CreateIterator();
        iterator.Step = 2;

        for (Item item = iterator.First(); !iterator.IsDone; item = iterator.Next())
        {
            _testOutputHelper.WriteLine(item.Name);
        }
    }

    ///<see href="https://www.dofactory.com"/>
    [Fact]
    private void Mediator_Chat()
    {
        var chatroom = new Chatroom();
        var George   = new Beatle("George");
        var Paul     = new Beatle("Paul");
        var Ringo    = new Beatle("Ringo");
        var John     = new Beatle("John");
        var Yoko     = new NonBeatle("Yoko");

        chatroom.Register(George);
        chatroom.Register(Paul);
        chatroom.Register(Ringo);
        chatroom.Register(John);
        chatroom.Register(Yoko);

        Yoko.Send("John", "Hi John!");
        Paul.Send("Ringo", "All you need is love");
        Ringo.Send("George", "My sweet Lord");
        Paul.Send("John", "Can't buy me love");
        John.Send("Yoko", "My sweet love");

        Assert.True(Yoko.Outbox.Count == 1 && John.Outbox.Count == 1 && Paul.Outbox.Count == 2 &&
                    Ringo.Outbox.Count == 1 && George.Outbox.Count == 0);
        Assert.True(Yoko.Inbox.Count == 1 && John.Inbox.Count == 2 && Paul.Inbox.Count == 0 && Ringo.Inbox.Count == 1 &&
                    George.Inbox.Count == 1);
    }

    [Fact]
    public void Memento_Care()
    {
        Originator o = new Originator();
        o.State = "On";
        Caretaker c = new Caretaker();
        c.Memento = o.CreateMemento();
        o.State   = "Off";
        o.SetMemento(c.Memento);
    }

    /// <see href= "https://en.wikipedia.org/wiki/Memento_pattern"/>
    [Fact]
    public void MementoList()
    {
        var savedStates = new List<M.Memento>();
        var originator  = new M.Memento.Originator();
        originator.Set("State1");
        originator.Set("State2");
        savedStates.Add(originator.SaveToMemento());
        originator.Set("State3");
        savedStates.Add(originator.SaveToMemento());
        originator.Set("State4");
        originator.RestoreFromMemento(savedStates[1]);
        Assert.True(originator.State == "State3");
    }

    /// <see href="https://en.wikipedia.org/wiki/Memento_pattern"/>
    [Fact]
    public void Observer()
    {
        ConcreteSubject s = new ConcreteSubject();

        s.Attach(new ConcreteObserver(s, "X"));
        s.Attach(new ConcreteObserver(s, "Y"));
        s.Attach(new ConcreteObserver(s, "Z"));

        s.SubjectState = "ABC";
        s.Notify();
    }

    /// <see href="https://www.dofactory.com"/>
    [Fact]
    public void State_banking()
    {
        Account account = new Account("Jim Johnson");
        account.Deposit(500.0);
        account.Deposit(300.0);
        account.Deposit(550.0);
        account.PayInterest();
        account.Withdraw(2000.00);
        account.Withdraw(1100.00);
    }

    [Fact]
    public void Strategy()
    {
        SortedList studentRecords = new SortedList();
        studentRecords.Add("Samual");
        studentRecords.Add("Jimmy");
        studentRecords.Add("Sandra");

        studentRecords.SetSortStrategy(new QuickSort());
        studentRecords.Sort();
        studentRecords.SetSortStrategy(new ShellSort());
        studentRecords.Sort();
        studentRecords.SetSortStrategy(new MergeSort());
        studentRecords.Sort();
    }

    [Fact]
    public void Template_DAO()
    {
        DataAccessObject daoCategories = new Postgres();
        daoCategories.Run();

        DataAccessObject daoProducts = new MSSQL();
        daoProducts.Run();
    }

    [Fact]
    public void Visitor_Employees()
    {
        Employees e = new();
        e.Add(new Clerk());
        e.Add(new Director());
        e.Recalculate(new IncomeApprover());
        e.Recalculate(new VacationApprover());
    }


    [Fact]
    public void Visitor_Painting()
    {
        P.Picture picture = new P.Picture(new P.Scetch1(), new P.Scetch2());
        Assert.Equal(40, picture.Price);
    }

    [Fact]
    public void Visitor_ExpressionPrinting()
    {
        var e = new V.Addition(
            new V.Addition(
                new V.Literal(1),
                new V.Literal(2)
            ),
            new V.Literal(3)
        );

        var printingVisitor = new V.ExpressionPrinting();
        e.Accept(printingVisitor);
    }
}