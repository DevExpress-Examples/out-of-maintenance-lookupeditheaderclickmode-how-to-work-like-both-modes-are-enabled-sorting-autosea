Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Collections

Namespace SortAndSearch_LookUpEdit
	Partial Public Class Form1
		Inherits Form

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Dim users As New UserList()
			users.Add(New User("Bill", "b", 20))
			users.Add(New User("Jeck", "j", 14))
			users.Add(New User("Stan", "s", 18))
			users.Add(New User("Bruce", "b", 29))
			users.Add(New User("Stanny", "s", 18))

			Dim sortAndSearchLookUpEdit As New SortAndSearchLookUpEdit()
			sortAndSearchLookUpEdit.Bounds = New Rectangle(10, 50, 100, 20)
			sortAndSearchLookUpEdit.Properties.DataSource = users
			sortAndSearchLookUpEdit.Properties.DisplayMember = "Name"
			sortAndSearchLookUpEdit.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup
			Controls.Add(sortAndSearchLookUpEdit)
		End Sub
	End Class

	Friend Class User
		Private name_Renamed As String
		Private login_Renamed As String
		Private age_Renamed As Integer
		Public Sub New(ByVal name As String, ByVal login As String, ByVal age As Integer)
			Me.name_Renamed = name
			Me.login_Renamed = login
			Me.age_Renamed = age
		End Sub
		Public Property Name() As String
			Get
				Return name_Renamed
			End Get
			Set(ByVal value As String)
				name_Renamed = value
			End Set
		End Property
		Public Property Login() As String
			Get
				Return login_Renamed
			End Get
			Set(ByVal value As String)
				name_Renamed = login_Renamed
			End Set
		End Property
		Public Property Age() As Integer
			Get
				Return age_Renamed
			End Get
			Set(ByVal value As Integer)
				age_Renamed = value
			End Set
		End Property
	End Class
	Friend Class UserList
		Inherits ArrayList
	End Class
End Namespace