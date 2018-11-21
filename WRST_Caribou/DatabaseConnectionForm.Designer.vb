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
        Me.CancelButton = New System.Windows.Forms.Button()
        Me.SaveButton = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ConnectionStringTextBox
        '
        Me.ConnectionStringTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ConnectionStringTextBox.Font = New System.Drawing.Font("Courier New", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConnectionStringTextBox.Location = New System.Drawing.Point(0, 0)
        Me.ConnectionStringTextBox.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ConnectionStringTextBox.Multiline = True
        Me.ConnectionStringTextBox.Name = "ConnectionStringTextBox"
        Me.ConnectionStringTextBox.Size = New System.Drawing.Size(439, 155)
        Me.ConnectionStringTextBox.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CancelButton)
        Me.Panel1.Controls.Add(Me.SaveButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 155)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(439, 37)
        Me.Panel1.TabIndex = 1
        '
        'CancelButton
        '
        Me.CancelButton.Location = New System.Drawing.Point(313, 9)
        Me.CancelButton.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CancelButton.Name = "CancelButton"
        Me.CancelButton.Size = New System.Drawing.Size(56, 19)
        Me.CancelButton.TabIndex = 1
        Me.CancelButton.Text = "Cancel"
        Me.CancelButton.UseVisualStyleBackColor = True
        '
        'SaveButton
        '
        Me.SaveButton.Location = New System.Drawing.Point(374, 9)
        Me.SaveButton.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(56, 19)
        Me.SaveButton.TabIndex = 0
        Me.SaveButton.Text = "Save"
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'DatabaseConnectionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(439, 192)
        Me.Controls.Add(Me.ConnectionStringTextBox)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
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
