﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WaypointsPreviewForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WaypointsPreviewForm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SearchAreaComboBox = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PreviewDataGridView = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ImportWaypointsButton = New System.Windows.Forms.Button()
        Me.WaypointsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.WaypointsBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.DateColumnNameComboBox = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.PreviewDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.WaypointsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WaypointsBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.WaypointsBindingNavigator.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.DateColumnNameComboBox)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.SearchAreaComboBox)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1117, 138)
        Me.Panel1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(141, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Change search area:"
        '
        'SearchAreaComboBox
        '
        Me.SearchAreaComboBox.FormattingEnabled = True
        Me.SearchAreaComboBox.Location = New System.Drawing.Point(170, 55)
        Me.SearchAreaComboBox.Name = "SearchAreaComboBox"
        Me.SearchAreaComboBox.Size = New System.Drawing.Size(241, 24)
        Me.SearchAreaComboBox.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(23, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1082, 43)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'PreviewDataGridView
        '
        Me.PreviewDataGridView.AllowUserToAddRows = False
        Me.PreviewDataGridView.AllowUserToDeleteRows = False
        Me.PreviewDataGridView.AllowUserToOrderColumns = True
        Me.PreviewDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PreviewDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PreviewDataGridView.Location = New System.Drawing.Point(0, 138)
        Me.PreviewDataGridView.Name = "PreviewDataGridView"
        Me.PreviewDataGridView.ReadOnly = True
        Me.PreviewDataGridView.RowTemplate.Height = 24
        Me.PreviewDataGridView.Size = New System.Drawing.Size(1117, 355)
        Me.PreviewDataGridView.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ImportWaypointsButton)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 520)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1117, 44)
        Me.Panel2.TabIndex = 2
        '
        'ImportWaypointsButton
        '
        Me.ImportWaypointsButton.Location = New System.Drawing.Point(791, 3)
        Me.ImportWaypointsButton.Name = "ImportWaypointsButton"
        Me.ImportWaypointsButton.Size = New System.Drawing.Size(145, 32)
        Me.ImportWaypointsButton.TabIndex = 4
        Me.ImportWaypointsButton.Text = "Import waypoints"
        Me.ImportWaypointsButton.UseVisualStyleBackColor = True
        '
        'WaypointsBindingNavigator
        '
        Me.WaypointsBindingNavigator.AddNewItem = Nothing
        Me.WaypointsBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.WaypointsBindingNavigator.DeleteItem = Nothing
        Me.WaypointsBindingNavigator.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.WaypointsBindingNavigator.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.WaypointsBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2})
        Me.WaypointsBindingNavigator.Location = New System.Drawing.Point(0, 493)
        Me.WaypointsBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.WaypointsBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.WaypointsBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.WaypointsBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.WaypointsBindingNavigator.Name = "WaypointsBindingNavigator"
        Me.WaypointsBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.WaypointsBindingNavigator.Size = New System.Drawing.Size(1117, 27)
        Me.WaypointsBindingNavigator.TabIndex = 3
        Me.WaypointsBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(45, 24)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(24, 24)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(24, 24)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 27)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 27)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 27)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(24, 24)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(24, 24)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 27)
        '
        'DateColumnNameComboBox
        '
        Me.DateColumnNameComboBox.FormattingEnabled = True
        Me.DateColumnNameComboBox.Location = New System.Drawing.Point(384, 91)
        Me.DateColumnNameComboBox.Name = "DateColumnNameComboBox"
        Me.DateColumnNameComboBox.Size = New System.Drawing.Size(211, 24)
        Me.DateColumnNameComboBox.TabIndex = 4
        Me.DateColumnNameComboBox.Text = "LTIME"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(355, 17)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Column containing the date the waypoint was collected:"
        '
        'WaypointsPreviewForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1117, 564)
        Me.Controls.Add(Me.PreviewDataGridView)
        Me.Controls.Add(Me.WaypointsBindingNavigator)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "WaypointsPreviewForm"
        Me.ShowInTaskbar = False
        Me.Text = "Waypoints import preview form"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PreviewDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.WaypointsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WaypointsBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.WaypointsBindingNavigator.ResumeLayout(False)
        Me.WaypointsBindingNavigator.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents PreviewDataGridView As DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents WaypointsBindingSource As BindingSource
    Friend WithEvents WaypointsBindingNavigator As BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As ToolStripSeparator
    Friend WithEvents SearchAreaComboBox As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ImportWaypointsButton As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents DateColumnNameComboBox As ComboBox
End Class
