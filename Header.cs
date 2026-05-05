using System;

namespace Ovn2_FlowControl;

class Header : IViewFragment
{
    private readonly string _title;
    private readonly string _description;

    public Header(string title, string description)
    {
        _title = title;
        _description = description;
    }

    public void Render()
    {
        Console.Clear();
        Console.WriteLine(_title);
        Console.WriteLine(_description);
        Console.WriteLine(new string('─', Math.Max(_title.Length, _description.Length)));
        Console.WriteLine();
    }
}