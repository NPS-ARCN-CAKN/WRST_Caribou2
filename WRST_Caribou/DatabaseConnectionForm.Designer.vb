<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DatabaseConnectionForm
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
        Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'PropertyGrid1
        '
        Me.PropertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PropertyGrid1.Location = New System.Drawing.Point(0, 57)
        Me.PropertyGrid1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PropertyGrid1.Name = "PropertyGrid1"
        Me.PropertyGrid1.Size = New System.Drawing.Size(818, 649)
        Me.PropertyGrid1.TabIndex = 2
        '
        'TextBox1
        '
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TextBox1.Location = New System.Drawing.Point(0, 0)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(818, 57)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = "Note: You cannot change the WRST_Caribou database ConnectionString using this for" &
    "m. Edit App.Config in the application directory to point the application to a di" &
    "fferent version of the database."
        '
        'DatabaseConnectionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(818, 706)
        Me.Controls.Add(Me.PropertyGrid1)
        Me.Controls.Add(Me.TextBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "DatabaseConnectionForm"
        Me.Text = "Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PropertyGrid1 As PropertyGrid
    Friend WithEvents TextBox1 As TextBox
End Class
