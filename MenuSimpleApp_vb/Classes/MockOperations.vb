Imports System.Globalization
Imports System.IO
Imports System.Text.Json

Namespace Classes
	Public Class MockOperations
		''' <summary>
		''' Name of the json file to read from
		''' </summary>
		Private Shared ReadOnly Property _fileName As String
			Get
				Return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Menu.json")
			End Get
		End Property

		''' <summary>
		''' Create a list of months
		''' Information property is not need as we get details from the .json file
		''' </summary>
		''' <returns>List of <see cref="MenuItem"/></returns>
		Public Shared Function MenuItems() As List(Of MenuItem)

			Dim list = DateTimeFormatInfo.CurrentInfo.MonthNames.Take(11).Select(Function(value, index) New With {
				Key .Name = value,
				Key .Id = index + 1
			}).ToList().Select(Function(anonymous) New MenuItem() With {
				.Id = anonymous.Id,
				.Name = anonymous.Name
			}).ToList()

			list.Insert(list.Count, New MenuItem() With {
				.Id = -1,
				.Name = "Exit"
			})

			Return list

		End Function

		''' <summary>
		''' Read month details from json file
		''' </summary>
		''' <returns>List of <see cref="MenuItem"/></returns>
		Public Shared Function GetMenuItems() As List(Of MenuItem)
			Return JsonSerializer.Deserialize(Of List(Of MenuItem))(File.ReadAllText(_fileName))
		End Function

		''' <summary>
		''' Create .json file and note the .Information property is set to
		''' </summary>
		Public Shared Sub SerializeMonths()

			Dim json = JsonSerializer.Serialize(MenuItems(), New JsonSerializerOptions() With {.WriteIndented = True})

			File.WriteAllText(_fileName, json)

		End Sub
	End Class
End Namespace
