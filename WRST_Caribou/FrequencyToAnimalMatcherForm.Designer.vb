<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrequencyToAnimalMatcherForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupDataGridView = New System.Windows.Forms.DataGridView()
        Me.CurrentCollarsDataGridView = New System.Windows.Forms.DataGridView()
        Me.MatcherToolStrip = New System.Windows.Forms.ToolStrip()
        Me.HeaderToolStripLabel = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.GroupDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrentCollarsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MatcherToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupDataGridView)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.CurrentCollarsDataGridView)
        Me.SplitContainer1.Panel2.Controls.Add(Me.MatcherToolStrip)
        Me.SplitContainer1.Size = New System.Drawing.Size(1051, 561)
        Me.SplitContainer1.SplitterDistance = 350
        Me.SplitContainer1.TabIndex = 0
        '
        'GroupDataGridView
        '
        Me.GroupDataGridView.AllowUserToAddRows = False
        Me.GroupDataGridView.AllowUserToDeleteRows = False
        Me.GroupDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GroupDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GroupDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.GroupDataGridView.Name = "GroupDataGridView"
        Me.GroupDataGridView.Size = New System.Drawing.Size(350, 561)
        Me.GroupDataGridView.TabIndex = 0
        '
        'CurrentCollarsDataGridView
        '
        Me.CurrentCollarsDataGridView.AllowUserToAddRows = False
        Me.CurrentCollarsDataGridView.AllowUserToDeleteRows = False
        Me.CurrentCollarsDataGridView.AllowUserToOrderColumns = True
        Me.CurrentCollarsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.CurrentCollarsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CurrentCollarsDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.CurrentCollarsDataGridView.MultiSelect = False
        Me.CurrentCollarsDataGridView.Name = "CurrentCollarsDataGridView"
        Me.CurrentCollarsDataGridView.ReadOnly = True
        Me.CurrentCollarsDataGridView.Size = New System.Drawing.Size(697, 536)
        Me.CurrentCollarsDataGridView.TabIndex = 0
        '
        'MatcherToolStrip
        '
        Me.MatcherToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HeaderToolStripLabel, Me.ToolStripSeparator1, Me.ToolStripLabel1})
        Me.MatcherToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.MatcherToolStrip.Name = "MatcherToolStrip"
        Me.MatcherToolStrip.Size = New System.Drawing.Size(697, 25)
        Me.MatcherToolStrip.TabIndex = 1
        Me.MatcherToolStrip.Text = "ToolStrip1"
        '
        'HeaderToolStripLabel
        '
        Me.HeaderToolStripLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.HeaderToolStripLabel.Name = "HeaderToolStripLabel"
        Me.HeaderToolStripLabel.Size = New System.Drawing.Size(175, 22)
        Me.HeaderToolStripLabel.Text = "Collars that were deployed on "
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(161, 22)
        Me.ToolStripLabel1.Text = "Double click a row to select it"
        '
        'FrequencyToAnimalMatcherForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1051, 561)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrequencyToAnimalMatcherForm"
        Me.Text = "FrequencyToAnimalMatcherForm"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.GroupDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrentCollarsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MatcherToolStrip.ResumeLayout(False)
        Me.MatcherToolStrip.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents GroupDataGridView As DataGridView
    Friend WithEvents CurrentCollarsDataGridView As DataGridView
    Friend WithEvents MatcherToolStrip As ToolStrip
    Friend WithEvents HeaderToolStripLabel As ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
End Class
