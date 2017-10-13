<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim CampaignsGridEX_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Dim CompositionCountsGridEX_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim PopulationEstimateGridEX_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim RadioTrackingGridEX_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim SurveyFlightsGridEX_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.WRST_CaribouDataSet = New WRST_Caribou.WRST_CaribouDataSet()
        Me.CampaignsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CampaignsTableAdapter = New WRST_Caribou.WRST_CaribouDataSetTableAdapters.CampaignsTableAdapter()
        Me.TableAdapterManager = New WRST_Caribou.WRST_CaribouDataSetTableAdapters.TableAdapterManager()
        Me.CompositionCountsTableAdapter = New WRST_Caribou.WRST_CaribouDataSetTableAdapters.CompositionCountsTableAdapter()
        Me.PopulationEstimateTableAdapter = New WRST_Caribou.WRST_CaribouDataSetTableAdapters.PopulationEstimateTableAdapter()
        Me.RadioTrackingTableAdapter = New WRST_Caribou.WRST_CaribouDataSetTableAdapters.RadioTrackingTableAdapter()
        Me.CampaignsGridEX = New Janus.Windows.GridEX.GridEX()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.CompositionCountTabPage = New System.Windows.Forms.TabPage()
        Me.CompositionCountsGridEX = New Janus.Windows.GridEX.GridEX()
        Me.CompositionCountsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SurveyFlightsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PopulationTabPage = New System.Windows.Forms.TabPage()
        Me.PopulationEstimateGridEX = New Janus.Windows.GridEX.GridEX()
        Me.PopulationEstimateBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RadiotrackingTabPage = New System.Windows.Forms.TabPage()
        Me.RadioTrackingGridEX = New Janus.Windows.GridEX.GridEX()
        Me.RadioTrackingBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.SurveyFlightsGridEX = New Janus.Windows.GridEX.GridEX()
        Me.SurveyFlightsTableAdapter = New WRST_Caribou.WRST_CaribouDataSetTableAdapters.SurveyFlightsTableAdapter()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveChangesToDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditDatabaseConnectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.WRST_CaribouDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CampaignsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CampaignsGridEX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.CompositionCountTabPage.SuspendLayout()
        CType(Me.CompositionCountsGridEX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompositionCountsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SurveyFlightsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PopulationTabPage.SuspendLayout()
        CType(Me.PopulationEstimateGridEX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopulationEstimateBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadiotrackingTabPage.SuspendLayout()
        CType(Me.RadioTrackingGridEX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadioTrackingBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.SurveyFlightsGridEX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'WRST_CaribouDataSet
        '
        Me.WRST_CaribouDataSet.DataSetName = "WRST_CaribouDataSet"
        Me.WRST_CaribouDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CampaignsBindingSource
        '
        Me.CampaignsBindingSource.DataMember = "Campaigns"
        Me.CampaignsBindingSource.DataSource = Me.WRST_CaribouDataSet
        '
        'CampaignsTableAdapter
        '
        Me.CampaignsTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CampaignsTableAdapter = Me.CampaignsTableAdapter
        Me.TableAdapterManager.CapturesTableAdapter = Nothing
        Me.TableAdapterManager.CaribouTableAdapter = Nothing
        Me.TableAdapterManager.CompositionCountsTableAdapter = Me.CompositionCountsTableAdapter
        Me.TableAdapterManager.PopulationEstimateTableAdapter = Me.PopulationEstimateTableAdapter
        Me.TableAdapterManager.RadioTrackingTableAdapter = Me.RadioTrackingTableAdapter
        Me.TableAdapterManager.SurveyFlightsTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = WRST_Caribou.WRST_CaribouDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.WorkLogTableAdapter = Nothing
        Me.TableAdapterManager.xrefCompCountCaribouTableAdapter = Nothing
        Me.TableAdapterManager.xrefPopulationCaribouTableAdapter = Nothing
        Me.TableAdapterManager.xrefRadiotrackingCaribouTableAdapter = Nothing
        '
        'CompositionCountsTableAdapter
        '
        Me.CompositionCountsTableAdapter.ClearBeforeFill = True
        '
        'PopulationEstimateTableAdapter
        '
        Me.PopulationEstimateTableAdapter.ClearBeforeFill = True
        '
        'RadioTrackingTableAdapter
        '
        Me.RadioTrackingTableAdapter.ClearBeforeFill = True
        '
        'CampaignsGridEX
        '
        Me.CampaignsGridEX.DataSource = Me.CampaignsBindingSource
        CampaignsGridEX_DesignTimeLayout.LayoutString = resources.GetString("CampaignsGridEX_DesignTimeLayout.LayoutString")
        Me.CampaignsGridEX.DesignTimeLayout = CampaignsGridEX_DesignTimeLayout
        Me.CampaignsGridEX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CampaignsGridEX.Location = New System.Drawing.Point(0, 0)
        Me.CampaignsGridEX.Name = "CampaignsGridEX"
        Me.CampaignsGridEX.RecordNavigator = True
        Me.CampaignsGridEX.Size = New System.Drawing.Size(398, 254)
        Me.CampaignsGridEX.TabIndex = 1
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.CompositionCountTabPage)
        Me.TabControl1.Controls.Add(Me.PopulationTabPage)
        Me.TabControl1.Controls.Add(Me.RadiotrackingTabPage)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(793, 665)
        Me.TabControl1.TabIndex = 4
        '
        'CompositionCountTabPage
        '
        Me.CompositionCountTabPage.Controls.Add(Me.CompositionCountsGridEX)
        Me.CompositionCountTabPage.Location = New System.Drawing.Point(4, 25)
        Me.CompositionCountTabPage.Name = "CompositionCountTabPage"
        Me.CompositionCountTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.CompositionCountTabPage.Size = New System.Drawing.Size(785, 636)
        Me.CompositionCountTabPage.TabIndex = 0
        Me.CompositionCountTabPage.Text = "Composition count"
        Me.CompositionCountTabPage.UseVisualStyleBackColor = True
        '
        'CompositionCountsGridEX
        '
        Me.CompositionCountsGridEX.DataSource = Me.CompositionCountsBindingSource
        CompositionCountsGridEX_DesignTimeLayout.LayoutString = resources.GetString("CompositionCountsGridEX_DesignTimeLayout.LayoutString")
        Me.CompositionCountsGridEX.DesignTimeLayout = CompositionCountsGridEX_DesignTimeLayout
        Me.CompositionCountsGridEX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CompositionCountsGridEX.Location = New System.Drawing.Point(3, 3)
        Me.CompositionCountsGridEX.Name = "CompositionCountsGridEX"
        Me.CompositionCountsGridEX.Size = New System.Drawing.Size(779, 630)
        Me.CompositionCountsGridEX.TabIndex = 0
        '
        'CompositionCountsBindingSource
        '
        Me.CompositionCountsBindingSource.DataMember = "FK_CompositionCounts_SurveyFlights"
        Me.CompositionCountsBindingSource.DataSource = Me.SurveyFlightsBindingSource
        '
        'SurveyFlightsBindingSource
        '
        Me.SurveyFlightsBindingSource.DataMember = "FK_SurveyFlights_Campaigns"
        Me.SurveyFlightsBindingSource.DataSource = Me.CampaignsBindingSource
        '
        'PopulationTabPage
        '
        Me.PopulationTabPage.AutoScroll = True
        Me.PopulationTabPage.Controls.Add(Me.PopulationEstimateGridEX)
        Me.PopulationTabPage.Location = New System.Drawing.Point(4, 25)
        Me.PopulationTabPage.Name = "PopulationTabPage"
        Me.PopulationTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.PopulationTabPage.Size = New System.Drawing.Size(785, 636)
        Me.PopulationTabPage.TabIndex = 1
        Me.PopulationTabPage.Text = "Population"
        Me.PopulationTabPage.UseVisualStyleBackColor = True
        '
        'PopulationEstimateGridEX
        '
        Me.PopulationEstimateGridEX.DataSource = Me.PopulationEstimateBindingSource
        PopulationEstimateGridEX_DesignTimeLayout.LayoutString = resources.GetString("PopulationEstimateGridEX_DesignTimeLayout.LayoutString")
        Me.PopulationEstimateGridEX.DesignTimeLayout = PopulationEstimateGridEX_DesignTimeLayout
        Me.PopulationEstimateGridEX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PopulationEstimateGridEX.Location = New System.Drawing.Point(3, 3)
        Me.PopulationEstimateGridEX.Name = "PopulationEstimateGridEX"
        Me.PopulationEstimateGridEX.Size = New System.Drawing.Size(779, 630)
        Me.PopulationEstimateGridEX.TabIndex = 0
        '
        'PopulationEstimateBindingSource
        '
        Me.PopulationEstimateBindingSource.DataMember = "FK_PopulationEstimate_SurveyFlights"
        Me.PopulationEstimateBindingSource.DataSource = Me.SurveyFlightsBindingSource
        '
        'RadiotrackingTabPage
        '
        Me.RadiotrackingTabPage.Controls.Add(Me.RadioTrackingGridEX)
        Me.RadiotrackingTabPage.Location = New System.Drawing.Point(4, 25)
        Me.RadiotrackingTabPage.Name = "RadiotrackingTabPage"
        Me.RadiotrackingTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.RadiotrackingTabPage.Size = New System.Drawing.Size(785, 636)
        Me.RadiotrackingTabPage.TabIndex = 2
        Me.RadiotrackingTabPage.Text = "Radiotracking"
        Me.RadiotrackingTabPage.UseVisualStyleBackColor = True
        '
        'RadioTrackingGridEX
        '
        Me.RadioTrackingGridEX.DataSource = Me.RadioTrackingBindingSource
        RadioTrackingGridEX_DesignTimeLayout.LayoutString = resources.GetString("RadioTrackingGridEX_DesignTimeLayout.LayoutString")
        Me.RadioTrackingGridEX.DesignTimeLayout = RadioTrackingGridEX_DesignTimeLayout
        Me.RadioTrackingGridEX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadioTrackingGridEX.Location = New System.Drawing.Point(3, 3)
        Me.RadioTrackingGridEX.Name = "RadioTrackingGridEX"
        Me.RadioTrackingGridEX.Size = New System.Drawing.Size(779, 630)
        Me.RadioTrackingGridEX.TabIndex = 0
        '
        'RadioTrackingBindingSource
        '
        Me.RadioTrackingBindingSource.DataMember = "FK_RadioTracking_SurveyFlights"
        Me.RadioTrackingBindingSource.DataSource = Me.SurveyFlightsBindingSource
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 28)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TabControl1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1195, 665)
        Me.SplitContainer1.SplitterDistance = 398
        Me.SplitContainer1.TabIndex = 2
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.CampaignsGridEX)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SurveyFlightsGridEX)
        Me.SplitContainer2.Size = New System.Drawing.Size(398, 665)
        Me.SplitContainer2.SplitterDistance = 254
        Me.SplitContainer2.TabIndex = 0
        '
        'SurveyFlightsGridEX
        '
        Me.SurveyFlightsGridEX.DataSource = Me.SurveyFlightsBindingSource
        SurveyFlightsGridEX_DesignTimeLayout.LayoutString = resources.GetString("SurveyFlightsGridEX_DesignTimeLayout.LayoutString")
        Me.SurveyFlightsGridEX.DesignTimeLayout = SurveyFlightsGridEX_DesignTimeLayout
        Me.SurveyFlightsGridEX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SurveyFlightsGridEX.Location = New System.Drawing.Point(0, 0)
        Me.SurveyFlightsGridEX.Name = "SurveyFlightsGridEX"
        Me.SurveyFlightsGridEX.Size = New System.Drawing.Size(398, 407)
        Me.SurveyFlightsGridEX.TabIndex = 0
        '
        'SurveyFlightsTableAdapter
        '
        Me.SurveyFlightsTableAdapter.ClearBeforeFill = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem, Me.DatabaseToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1195, 28)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveChangesToDatabaseToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(83, 24)
        Me.SaveToolStripMenuItem.Text = "Functions"
        '
        'SaveChangesToDatabaseToolStripMenuItem
        '
        Me.SaveChangesToDatabaseToolStripMenuItem.Image = CType(resources.GetObject("SaveChangesToDatabaseToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SaveChangesToDatabaseToolStripMenuItem.Name = "SaveChangesToDatabaseToolStripMenuItem"
        Me.SaveChangesToDatabaseToolStripMenuItem.Size = New System.Drawing.Size(256, 26)
        Me.SaveChangesToDatabaseToolStripMenuItem.Text = "Save changes to database"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(256, 26)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'DatabaseToolStripMenuItem
        '
        Me.DatabaseToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditDatabaseConnectionToolStripMenuItem})
        Me.DatabaseToolStripMenuItem.Name = "DatabaseToolStripMenuItem"
        Me.DatabaseToolStripMenuItem.Size = New System.Drawing.Size(84, 24)
        Me.DatabaseToolStripMenuItem.Text = "Database"
        '
        'EditDatabaseConnectionToolStripMenuItem
        '
        Me.EditDatabaseConnectionToolStripMenuItem.Image = CType(resources.GetObject("EditDatabaseConnectionToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EditDatabaseConnectionToolStripMenuItem.Name = "EditDatabaseConnectionToolStripMenuItem"
        Me.EditDatabaseConnectionToolStripMenuItem.Size = New System.Drawing.Size(261, 26)
        Me.EditDatabaseConnectionToolStripMenuItem.Text = "Edit database connection..."
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(62, 24)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1195, 693)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "NPS Wrangell St. Elias NPP Caribou Monitoring Program"
        CType(Me.WRST_CaribouDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CampaignsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CampaignsGridEX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.CompositionCountTabPage.ResumeLayout(False)
        CType(Me.CompositionCountsGridEX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompositionCountsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SurveyFlightsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PopulationTabPage.ResumeLayout(False)
        CType(Me.PopulationEstimateGridEX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopulationEstimateBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadiotrackingTabPage.ResumeLayout(False)
        CType(Me.RadioTrackingGridEX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadioTrackingBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.SurveyFlightsGridEX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents WRST_CaribouDataSet As WRST_CaribouDataSet
    Friend WithEvents CampaignsBindingSource As BindingSource
    Friend WithEvents CampaignsTableAdapter As WRST_CaribouDataSetTableAdapters.CampaignsTableAdapter
    Friend WithEvents TableAdapterManager As WRST_CaribouDataSetTableAdapters.TableAdapterManager
    Friend WithEvents CampaignsGridEX As Janus.Windows.GridEX.GridEX
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents CompositionCountTabPage As TabPage
    Friend WithEvents PopulationTabPage As TabPage
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents SurveyFlightsBindingSource As BindingSource
    Friend WithEvents SurveyFlightsTableAdapter As WRST_CaribouDataSetTableAdapters.SurveyFlightsTableAdapter
    Friend WithEvents SurveyFlightsGridEX As Janus.Windows.GridEX.GridEX
    Friend WithEvents CompositionCountsBindingSource As BindingSource
    Friend WithEvents CompositionCountsTableAdapter As WRST_CaribouDataSetTableAdapters.CompositionCountsTableAdapter
    Friend WithEvents CompositionCountsGridEX As Janus.Windows.GridEX.GridEX
    Friend WithEvents PopulationEstimateBindingSource As BindingSource
    Friend WithEvents PopulationEstimateTableAdapter As WRST_CaribouDataSetTableAdapters.PopulationEstimateTableAdapter
    Friend WithEvents PopulationEstimateGridEX As Janus.Windows.GridEX.GridEX
    Friend WithEvents RadiotrackingTabPage As TabPage
    Friend WithEvents RadioTrackingBindingSource As BindingSource
    Friend WithEvents RadioTrackingTableAdapter As WRST_CaribouDataSetTableAdapters.RadioTrackingTableAdapter
    Friend WithEvents RadioTrackingGridEX As Janus.Windows.GridEX.GridEX
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveChangesToDatabaseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DatabaseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditDatabaseConnectionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
End Class
