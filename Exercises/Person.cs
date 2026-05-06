namespace Ovn2_FlowControl.Exercises;

public class Person(int age)
{
    public int Age { get; } = age;

    public int GetTicketPrice()
    {
        return Age switch
        {
            < 5 or > 100 => 0,
            < 20 => 80,
            > 64 => 90,
            _ => 120
        };
    }

    public override string ToString() => $"Person(Age={Age}, Price={GetTicketPrice()}kr)";
}