Namespace Classes
	Public Class MenuItem
		Public Property Id As Integer
		Public Property Name As String
		Public Property Information As String
		Public Overrides Function ToString() As String
			Return Name
		End Function
	End Class
End Namespace
