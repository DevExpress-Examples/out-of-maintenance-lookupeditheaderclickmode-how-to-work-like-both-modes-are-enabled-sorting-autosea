Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors.Controls
Imports System.Drawing
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraEditors.Drawing
Imports System.ComponentModel
Imports DevExpress.XtraEditors.Popup
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors
Imports System.Windows.Forms

Namespace SortAndSearch_LookUpEdit
	<UserRepositoryItem("RegisterSortAndSearchLookUpEdit")> _
	Public Class RepositoryItemSortAndSearchLookUpEdit
		Inherits RepositoryItemLookUpEdit
		Shared Sub New()
			RegisterSortAndSearchLookUpEdit()
		End Sub

		Public Sub New()
			MyBase.New()
			HeaderClickMode = DevExpress.XtraEditors.Controls.HeaderClickMode.Sorting
		End Sub

		Public Const SortAndSearchLookUpEditName As String = "SortAndSearchLookUpEdit"

		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return SortAndSearchLookUpEditName
			End Get
		End Property

        Public Shared Sub RegisterSortAndSearchLookUpEdit()
            EditorRegistrationInfo.Default.Editors.Add(New EditorClassInfo(SortAndSearchLookUpEditName, GetType(SortAndSearchLookUpEdit), GetType(RepositoryItemSortAndSearchLookUpEdit), GetType(LookUpEditViewInfo), New ButtonEditPainter(), True, EditImageIndexes.TextEdit, Nothing))
        End Sub
	End Class

	Public Class SortAndSearchLookUpEdit
		Inherits LookUpEdit
		Shared Sub New()
			RepositoryItemSortAndSearchLookUpEdit.RegisterSortAndSearchLookUpEdit()
		End Sub

		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return RepositoryItemSortAndSearchLookUpEdit.SortAndSearchLookUpEditName
			End Get
		End Property

		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
		Public Shadows ReadOnly Property Properties() As RepositoryItemSortAndSearchLookUpEdit
			Get
				Return TryCast(MyBase.Properties, RepositoryItemSortAndSearchLookUpEdit)
			End Get
		End Property

		Protected Overrides Function CreatePopupForm() As PopupBaseForm
			Return New SortAndSearchPopupLookUpEditForm(Me)
		End Function
	End Class

	Public Class SortAndSearchPopupLookUpEditForm
		Inherits PopupLookUpEditForm
		Public Sub New(ByVal ownerEdit As SortAndSearchLookUpEdit)
			MyBase.New(ownerEdit)
		End Sub

		Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
			Dim _pressInfo As LookUpPopupHitTest = ViewInfo.GetHitTest(New Point(e.X, e.Y))
			If _pressInfo.HitType = LookUpPopupHitType.Header Then
				If SelectedIndex > 0 Then
					SelectedIndex -= 1
				Else
					If Filter.RowCount > 1 Then
						SelectedIndex += 1
					End If
				End If
				ViewInfo.AutoSearchHeaderIndex = _pressInfo.Index
				LayoutChanged()
			End If
			MyBase.OnMouseDown(e)
		End Sub
	End Class
End Namespace

