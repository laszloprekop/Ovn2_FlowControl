namespace Ovn2_FlowControl;

public class Person
{
    public int Age { get; set; }

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
}