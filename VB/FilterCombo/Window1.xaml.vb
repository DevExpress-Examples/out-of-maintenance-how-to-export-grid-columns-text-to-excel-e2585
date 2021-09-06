﻿Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.ComponentModel
Imports System.Collections
Imports DevExpress.Xpf.Editors.Settings
Imports DevExpress.Xpf.Grid
Imports DevExpress.Xpf.Editors
Imports DevExpress.XtraPrinting

Namespace FilterCombo
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>
	''' 

	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()
			cars = New BindingList(Of Car)()
			colors = New BindingList(Of CustomColor)()

			cars.Add(New Car() With {
				.AvailableColor = 2,
				.Make = "Make1"
			})
			cars.Add(New Car() With {
				.AvailableColor = 1,
				.Make = "Make2"
			})
			cars.Add(New Car() With {
				.AvailableColor = 3,
				.Make = "Make1"
			})

			gridControl1.ItemsSource = cars

			colors.Add(New CustomColor() With {
				.ID = 1,
				.Name="Red"
			})
			colors.Add(New CustomColor() With {
				.ID = 2,
				.Name = "Blue"
			})
			colors.Add(New CustomColor() With {
				.ID = 3,
				.Name = "Pink"
			})


			Dim combo As New ComboBoxEditSettings()
			combo.ItemsSource = colors
			combo.DisplayMember = "Name"
			combo.ValueMember = "ID"
			combo.IsTextEditable = False
			gridControl1.Columns("AvailableColor").EditSettings = combo

		End Sub


		Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)

		End Sub

		Public cars As BindingList(Of Car)
		Public colors As BindingList(Of CustomColor)

		Private Sub button1_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			view.ExportToXls("1.xls", New XlsExportOptions() With {.TextExportMode = TextExportMode.Text})
		End Sub




	End Class


	Public Class Car
		Public Property AvailableColor() As Integer
		Public Property Make() As String
	End Class

	Public Class CustomColor
		Public Property ID() As Integer
		Public Property Name() As String
	End Class
End Namespace
