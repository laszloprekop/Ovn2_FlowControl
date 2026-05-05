using Spectre.Console;

namespace Ovn2_FlowControl;

class SpectreHeader : IViewFragment
{
    private readonly string _title;
    private readonly string _description;

    public SpectreHeader(string title, string description)
    {
        _title = title;
        _description = description;
    }

    public void Render()
    {
        AnsiConsole.Write(
            new Panel(Markup.Escape(_description))
            {
                Header = new PanelHeader(Markup.Escape(_title))
            });
        AnsiConsole.WriteLine();
    }
}