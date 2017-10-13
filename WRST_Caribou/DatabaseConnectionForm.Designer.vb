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
        Me.ConnectionStringTextBox = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SaveButton = New System.Windows.Forms.Button()
        Me.CancelButton = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ConnectionStringTextBox
        '
        Me.ConnectionStringTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ConnectionStringTextBox.Font = New System.Drawing.Font("Courier New", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConnectionStringTextBox.Location = New System.Drawing.Point(0, 0)
        Me.ConnectionStringTextBox.Multiline = True
        Me.ConnectionStringTextBox.Name = "ConnectionStringTextBox"
        Me.ConnectionStringTextBox.Size = New System.Drawing.Size(585, 236)
        Me.ConnectionStringTextBox.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CancelButton)
        Me.Panel1.Controls.Add(Me.SaveButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 190)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(585, 46)
        Me.Panel1.TabIndex = 1
        '
        'SaveButton
        '
        Me.SaveButton.Location = New System.Drawing.Point(498, 11)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(75, 23)
        Me.SaveButton.TabIndex = 0
        Me.SaveButton.Text = "Save"
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'CancelButton
        '
        Me.CancelButton.Location = New System.Drawing.Point(417, 11)
        Me.CancelButton.Name = "CancelButton"
        Me.CancelButton.Size = New System.Drawing.Size(75, 23)
        Me.CancelButton.TabIndex = 1
        Me.CancelButton.Text = "Cancel"
        Me.CancelButton.UseVisualStyleBackColor = True
        '
        'DatabaseConnectionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(585, 236)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ConnectionStringTextBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "DatabaseConnectionForm"
        Me.Text = "Database ConnectionString"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ConnectionStringTextBox As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents CancelButton As Button
    Friend WithEvents SaveButton As Button
End Class
