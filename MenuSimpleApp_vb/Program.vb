Imports Classes
Imports Spectre.Console
Imports W = ConsoleHelperLibrary.Classes.WindowUtility

Partial Friend Class Program
    Shared Sub Main(args() As String)

        Console.Title = "Code sample - Spectre.Console menu basic"
        W.SetConsoleWindowPosition(W.AnchorWindow.Center)

        Dim menuSelections = MockOperations.GetMenuItems()

        Do
            Console.Clear()

            Dim menuItem = AnsiConsole.Prompt(MenuOperations.SelectionPrompt())

            If menuItem.Id = -1 Then
                Return
            Else
                Dim month = menuSelections.FirstOrDefault(Function(item) item.Id = menuItem.Id)
                AnsiConsole.Write(New Markup($"[bold yellow]{month.Name}[/] [bold cyan]{month.Information}![/]"))
                Console.ReadLine()
            End If

        Loop

    End Sub
End Class