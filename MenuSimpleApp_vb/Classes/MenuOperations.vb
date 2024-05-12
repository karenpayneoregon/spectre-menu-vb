
Imports Spectre.Console

Namespace Classes
	Public Class MenuOperations
		''' <summary>
		''' Create the menu for showing months along with specifying colors,
		''' page size (how menu items to show w/o scrolling)
		''' </summary>
		''' <returns></returns>
		Public Shared Function SelectionPrompt() As SelectionPrompt(Of MenuItem)
			Dim menu As New SelectionPrompt(Of MenuItem)() With {.HighlightStyle = New Style(Color.Black, Color.White, Decoration.None)}

			menu.Title = "[yellow]Select a category[/]"
			menu.PageSize = 14
			menu.AddChoices(MockOperations.GetMenuItems())

			Return menu

		End Function
	End Class
End Namespace
