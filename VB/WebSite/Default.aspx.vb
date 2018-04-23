Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.ASPxTreeList
Imports DevExpress.Web.ASPxHiddenField
Imports DevExpress.Web.ASPxEditors
Imports System.Text

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
		ASPxGridViewWithTreeList.DataBind()
	End Sub

	Protected Sub ASPxTreeListInTemplate_Init(ByVal sender As Object, ByVal e As EventArgs)
		Dim treeList As ASPxTreeList = CType(sender, ASPxTreeList)
		Dim templateContainer As GridViewDataItemTemplateContainer = CType(treeList.NamingContainer, GridViewDataItemTemplateContainer)
		treeList.ID = String.Format("tl_{0}", templateContainer.KeyValue)
		treeList.ClientInstanceName = String.Format("tl_{0}", templateContainer.KeyValue)

		Dim nodeParent1 As TreeListNode = treeList.AppendNode(1)
		nodeParent1("ID") = 1
		nodeParent1("Details") = "Details1"

		Dim node1 As TreeListNode = treeList.AppendNode(2, nodeParent1)
		node1("ID") = 2
		node1("Details") = "Details2"
	End Sub

	Protected Sub ASPxSpinEditInTemplate_Init(ByVal sender As Object, ByVal e As EventArgs)
		Dim spinEdit As ASPxSpinEdit = CType(sender, ASPxSpinEdit)
		Dim templateContainer As TreeListDataCellTemplateContainer = CType(spinEdit.NamingContainer, TreeListDataCellTemplateContainer)
		Dim treeList As ASPxTreeList = CType(templateContainer.TreeList, ASPxTreeList)

		Dim clientInstanceName As String = String.Format("{0}_spEdit_{1}", treeList.ClientInstanceName, templateContainer.NodeKey)
		spinEdit.ID = clientInstanceName
		spinEdit.ClientInstanceName = clientInstanceName

		spinEdit.ClientSideEvents.NumberChanged = String.Format("function(s, e) {{ OnClientNumberChanged(s, '{0}'); }}", clientInstanceName)

		If ASPxHiddenFieldStorage.Contains(clientInstanceName) Then
			spinEdit.Number = Decimal.Parse(ASPxHiddenFieldStorage(clientInstanceName).ToString())
		End If
	End Sub

	Protected Sub ASPxButtonSubmit_Click(ByVal sender As Object, ByVal e As EventArgs)
		Dim result As New StringBuilder()
		For Each item As KeyValuePair(Of String, Object) In ASPxHiddenFieldStorage
			result.AppendFormat("{0}, ", item.Value)
		Next item
		Response.Write(result)
	End Sub

	Private Function CreateDataSource() As List(Of DemoDataSource)
		Dim dataSource As List(Of DemoDataSource) = New List(Of DemoDataSource)()
		dataSource.Add(New DemoDataSource() With {.ID = 1, .Venue = "Name1"})
		dataSource.Add(New DemoDataSource() With {.ID = 2, .Venue = "Name2"})
		Return dataSource
	End Function

	Protected Sub ASPxGridViewWithTreeList_BeforePerformDataSelect(ByVal sender As Object, ByVal e As EventArgs)
		ASPxGridViewWithTreeList.DataSource = CreateDataSource()
	End Sub
End Class
Public Class DemoDataSource
	Private privateID As Integer
	Public Property ID() As Integer
		Get
			Return privateID
		End Get
		Set(ByVal value As Integer)
			privateID = value
		End Set
	End Property
	Private privateVenue As String
	Public Property Venue() As String
		Get
			Return privateVenue
		End Get
		Set(ByVal value As String)
			privateVenue = value
		End Set
	End Property
End Class