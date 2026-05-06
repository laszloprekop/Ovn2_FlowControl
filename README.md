# Flow Control Exercises — OOP Refactor

![Demo](docs/demo.gif)

A C# console application built as part of the Lexicon .NET course. The project refactors a set of beginner flow-control exercises into a structured OOP design with a two-panel Spectre.Console UI.

## Exercises

| # | Title | Description |
|---|-------|-------------|
| 1 | Single Ticket Price calculator | Calculates ticket price based on age |
| 2 | Group Ticket Price calculator | Calculates total price for a group |
| 3 | Text Repeater | Repeats input text 10 times |
| 4 | What's the Third Word? | Extracts the third word from a sentence |

## Architecture

The refactor introduces a small set of interfaces that decouple presentation from logic:

```mermaid
classDiagram
    class IExercise {
        <<interface>>
        +Title string
        +Description string
        +Run(IConsoleAdapter)
    }
    class IConsoleAdapter {
        <<interface>>
        +Write(string)
        +WriteLine(string)
        +ReadLine(string) string?
    }
    class IViewFragment {
        <<interface>>
        +Render()
    }

    class ExerciseBase {
        <<abstract>>
        +Title string
        +Description string
        #ExerciseBase(string, string)
        +Run(IConsoleAdapter)*
        +ToString() string
    }
    class SingleTicketExercise {
        +Run(IConsoleAdapter)
    }
    class GroupTicketExercise {
        +Run(IConsoleAdapter)
    }
    class RepeatTextExercise {
        +Run(IConsoleAdapter)
    }
    class ThirdWordExercise {
        +Run(IConsoleAdapter)
    }
    class Person {
        +Age int
        +GetTicketPrice() int
        +ToString() string
    }

    class StandardConsole {
        +Write(string)
        +WriteLine(string)
        +ReadLine(string) string?
    }
    class SpectreConsole {
        -_lines List~string~
        +Write(string)
        +WriteLine(string)
        +ReadLine(string) string?
    }
    class SpectreHeader {
        -_title string
        -_description string
        +Render()
    }

    class ConsoleLayout {
        +RenderMenu()
        +RenderExercise(IExercise)
    }
    class Menu {
        -_layout ConsoleLayout
        +Run()
    }

    ExerciseBase ..|> IExercise
    SingleTicketExercise --|> ExerciseBase
    GroupTicketExercise --|> ExerciseBase
    RepeatTextExercise --|> ExerciseBase
    ThirdWordExercise --|> ExerciseBase
    StandardConsole ..|> IConsoleAdapter
    SpectreConsole ..|> IConsoleAdapter
    SpectreHeader ..|> IViewFragment

    Menu *-- ConsoleLayout : composes
    Menu ..> SpectreConsole : creates
    Menu ..> IExercise : dispatches
    ConsoleLayout ..> IExercise : renders
    SpectreConsole ..> IExercise : renders
    GroupTicketExercise ..> Person : creates
```

`SpectreConsole` implements `IConsoleAdapter` and renders all exercise I/O live inside the right panel, re-drawing on every write or read. `StandardConsole` is a plain pass-through wrapper around `System.Console` used for testing without the UI.

The composition root (`Program.cs`) wires the exercise list and passes it to `Menu`, which owns the run loop. `ConsoleLayout` handles the static menu and exercise description views using Spectre.Console panels.

## Tech

- .NET 10 · C# 12
- [Spectre.Console](https://spectreconsole.net/) 0.55 — panels, markup, tables
