﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Dim CampaignsGridEX_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Dim CompositionCountsGridEX_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim XrefCompCountCaribouGridEX_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim PopulationEstimateGridEX_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim XrefPopulationCaribouGridEX_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim RadioTrackingGridEX_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim XrefRadiotrackingCaribouGridEX_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim SurveyFlightsGridEX_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim CaribouGridEX_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.CampaignsGridEX = New Janus.Windows.GridEX.GridEX()
        Me.CampaignsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.WRST_CaribouDataSet = New WRST_Caribou.WRST_CaribouDataSet()
        Me.SurveyDataTabControl = New System.Windows.Forms.TabControl()
        Me.CompositionCountTabPage = New System.Windows.Forms.TabPage()
        Me.CompCountSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.CompositionCountsGridEX = New Janus.Windows.GridEX.GridEX()
        Me.CompositionCountsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SurveyFlightsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.XrefCompCountCaribouGridEX = New Janus.Windows.GridEX.GridEX()
        Me.XrefCompCountCaribouBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CompCountToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ImportCompCountWaypointsToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PopulationTabPage = New System.Windows.Forms.TabPage()
        Me.PopulationSurveySplitContainer = New System.Windows.Forms.SplitContainer()
        Me.PopulationEstimateGridEX = New Janus.Windows.GridEX.GridEX()
        Me.PopulationEstimateBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.XrefPopulationCaribouGridEX = New Janus.Windows.GridEX.GridEX()
        Me.XrefPopulationCaribouBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PopulationToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ImportPopulationWaypointsToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.RadiotrackingTabPage = New System.Windows.Forms.TabPage()
        Me.RadioTrackingSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.RadioTrackingGridEX = New Janus.Windows.GridEX.GridEX()
        Me.RadioTrackingBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.XrefRadiotrackingCaribouGridEX = New Janus.Windows.GridEX.GridEX()
        Me.XrefRadiotrackingCaribouBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.RadiotrackingToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ImportRadiotrackingWaypointsToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.CampaignsSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CampaignLabel = New System.Windows.Forms.Label()
        Me.CampaignTabControl = New System.Windows.Forms.TabControl()
        Me.DataEditingTabPage = New System.Windows.Forms.TabPage()
        Me.SurveyFlightsSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.CampaignContextLabel = New System.Windows.Forms.Label()
        Me.SurveyFlightsGridEX = New Janus.Windows.GridEX.GridEX()
        Me.SurveysPanel = New System.Windows.Forms.Panel()
        Me.DataPanel = New System.Windows.Forms.Panel()
        Me.FlightContextLabel = New System.Windows.Forms.Label()
        Me.ResultsTabPage = New System.Windows.Forms.TabPage()
        Me.ResultsDataGridView = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveChangesToDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditDatabaseConnectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainToolStrip = New System.Windows.Forms.ToolStrip()
        Me.SaveDatasetToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.MainTabControl = New System.Windows.Forms.TabControl()
        Me.SurveysTabPage = New System.Windows.Forms.TabPage()
        Me.CaribouTabPage = New System.Windows.Forms.TabPage()
        Me.CaribouGridEX = New Janus.Windows.GridEX.GridEX()
        Me.CaribouBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CapturesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.XrefRadiotrackingCaribouBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CampaignsTableAdapter = New WRST_Caribou.WRST_CaribouDataSetTableAdapters.CampaignsTableAdapter()
        Me.TableAdapterManager = New WRST_Caribou.WRST_CaribouDataSetTableAdapters.TableAdapterManager()
        Me.CapturesTableAdapter = New WRST_Caribou.WRST_CaribouDataSetTableAdapters.CapturesTableAdapter()
        Me.CaribouTableAdapter = New WRST_Caribou.WRST_CaribouDataSetTableAdapters.CaribouTableAdapter()
        Me.CompositionCountsTableAdapter = New WRST_Caribou.WRST_CaribouDataSetTableAdapters.CompositionCountsTableAdapter()
        Me.PopulationEstimateTableAdapter = New WRST_Caribou.WRST_CaribouDataSetTableAdapters.PopulationEstimateTableAdapter()
        Me.RadioTrackingTableAdapter = New WRST_Caribou.WRST_CaribouDataSetTableAdapters.RadioTrackingTableAdapter()
        Me.SurveyFlightsTableAdapter = New WRST_Caribou.WRST_CaribouDataSetTableAdapters.SurveyFlightsTableAdapter()
        Me.XrefCompCountCaribouTableAdapter = New WRST_Caribou.WRST_CaribouDataSetTableAdapters.xrefCompCountCaribouTableAdapter()
        Me.XrefPopulationCaribouTableAdapter = New WRST_Caribou.WRST_CaribouDataSetTableAdapters.xrefPopulationCaribouTableAdapter()
        Me.XrefRadiotrackingCaribouTableAdapter = New WRST_Caribou.WRST_CaribouDataSetTableAdapters.xrefRadiotrackingCaribouTableAdapter()
        Me.ResultsToolStrip = New System.Windows.Forms.ToolStrip()
        Me.RefreshResultsToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.DatabaseViewLabel = New System.Windows.Forms.ToolStripLabel()
        Me.DatabaseViewNameToolStripLabel = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        CType(Me.CampaignsGridEX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CampaignsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WRST_CaribouDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SurveyDataTabControl.SuspendLayout()
        Me.CompositionCountTabPage.SuspendLayout()
        CType(Me.CompCountSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CompCountSplitContainer.Panel1.SuspendLayout()
        Me.CompCountSplitContainer.Panel2.SuspendLayout()
        Me.CompCountSplitContainer.SuspendLayout()
        CType(Me.CompositionCountsGridEX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompositionCountsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SurveyFlightsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrefCompCountCaribouGridEX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrefCompCountCaribouBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CompCountToolStrip.SuspendLayout()
        Me.PopulationTabPage.SuspendLayout()
        CType(Me.PopulationSurveySplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PopulationSurveySplitContainer.Panel1.SuspendLayout()
        Me.PopulationSurveySplitContainer.Panel2.SuspendLayout()
        Me.PopulationSurveySplitContainer.SuspendLayout()
        CType(Me.PopulationEstimateGridEX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopulationEstimateBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrefPopulationCaribouGridEX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrefPopulationCaribouBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PopulationToolStrip.SuspendLayout()
        Me.RadiotrackingTabPage.SuspendLayout()
        CType(Me.RadioTrackingSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadioTrackingSplitContainer.Panel1.SuspendLayout()
        Me.RadioTrackingSplitContainer.Panel2.SuspendLayout()
        Me.RadioTrackingSplitContainer.SuspendLayout()
        CType(Me.RadioTrackingGridEX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadioTrackingBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrefRadiotrackingCaribouGridEX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrefRadiotrackingCaribouBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadiotrackingToolStrip.SuspendLayout()
        CType(Me.CampaignsSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CampaignsSplitContainer.Panel1.SuspendLayout()
        Me.CampaignsSplitContainer.Panel2.SuspendLayout()
        Me.CampaignsSplitContainer.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.CampaignTabControl.SuspendLayout()
        Me.DataEditingTabPage.SuspendLayout()
        CType(Me.SurveyFlightsSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SurveyFlightsSplitContainer.Panel1.SuspendLayout()
        Me.SurveyFlightsSplitContainer.Panel2.SuspendLayout()
        Me.SurveyFlightsSplitContainer.SuspendLayout()
        CType(Me.SurveyFlightsGridEX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SurveysPanel.SuspendLayout()
        Me.DataPanel.SuspendLayout()
        Me.ResultsTabPage.SuspendLayout()
        CType(Me.ResultsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.MainToolStrip.SuspendLayout()
        Me.MainTabControl.SuspendLayout()
        Me.SurveysTabPage.SuspendLayout()
        Me.CaribouTabPage.SuspendLayout()
        CType(Me.CaribouGridEX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CaribouBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CapturesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrefRadiotrackingCaribouBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ResultsToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'CampaignsGridEX
        '
        Me.CampaignsGridEX.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.CampaignsGridEX.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.CampaignsGridEX.AlternatingColors = True
        Me.CampaignsGridEX.DataSource = Me.CampaignsBindingSource
        CampaignsGridEX_DesignTimeLayout.LayoutString = resources.GetString("CampaignsGridEX_DesignTimeLayout.LayoutString")
        Me.CampaignsGridEX.DesignTimeLayout = CampaignsGridEX_DesignTimeLayout
        Me.CampaignsGridEX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CampaignsGridEX.GroupByBoxVisible = False
        Me.CampaignsGridEX.Location = New System.Drawing.Point(0, 38)
        Me.CampaignsGridEX.Name = "CampaignsGridEX"
        Me.CampaignsGridEX.RecordNavigator = True
        Me.CampaignsGridEX.Size = New System.Drawing.Size(393, 565)
        Me.CampaignsGridEX.TabIndex = 1
        '
        'CampaignsBindingSource
        '
        Me.CampaignsBindingSource.DataMember = "Campaigns"
        Me.CampaignsBindingSource.DataSource = Me.WRST_CaribouDataSet
        '
        'WRST_CaribouDataSet
        '
        Me.WRST_CaribouDataSet.DataSetName = "WRST_CaribouDataSet"
        Me.WRST_CaribouDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SurveyDataTabControl
        '
        Me.SurveyDataTabControl.Controls.Add(Me.CompositionCountTabPage)
        Me.SurveyDataTabControl.Controls.Add(Me.PopulationTabPage)
        Me.SurveyDataTabControl.Controls.Add(Me.RadiotrackingTabPage)
        Me.SurveyDataTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SurveyDataTabControl.Location = New System.Drawing.Point(0, 38)
        Me.SurveyDataTabControl.Name = "SurveyDataTabControl"
        Me.SurveyDataTabControl.SelectedIndex = 0
        Me.SurveyDataTabControl.Size = New System.Drawing.Size(770, 321)
        Me.SurveyDataTabControl.TabIndex = 4
        '
        'CompositionCountTabPage
        '
        Me.CompositionCountTabPage.Controls.Add(Me.CompCountSplitContainer)
        Me.CompositionCountTabPage.Controls.Add(Me.CompCountToolStrip)
        Me.CompositionCountTabPage.Location = New System.Drawing.Point(4, 25)
        Me.CompositionCountTabPage.Name = "CompositionCountTabPage"
        Me.CompositionCountTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.CompositionCountTabPage.Size = New System.Drawing.Size(762, 292)
        Me.CompositionCountTabPage.TabIndex = 0
        Me.CompositionCountTabPage.Text = "Composition"
        Me.CompositionCountTabPage.UseVisualStyleBackColor = True
        '
        'CompCountSplitContainer
        '
        Me.CompCountSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CompCountSplitContainer.Location = New System.Drawing.Point(3, 30)
        Me.CompCountSplitContainer.Name = "CompCountSplitContainer"
        '
        'CompCountSplitContainer.Panel1
        '
        Me.CompCountSplitContainer.Panel1.Controls.Add(Me.CompositionCountsGridEX)
        '
        'CompCountSplitContainer.Panel2
        '
        Me.CompCountSplitContainer.Panel2.AutoScroll = True
        Me.CompCountSplitContainer.Panel2.Controls.Add(Me.XrefCompCountCaribouGridEX)
        Me.CompCountSplitContainer.Size = New System.Drawing.Size(756, 259)
        Me.CompCountSplitContainer.SplitterDistance = 339
        Me.CompCountSplitContainer.TabIndex = 3
        '
        'CompositionCountsGridEX
        '
        Me.CompositionCountsGridEX.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.CompositionCountsGridEX.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.CompositionCountsGridEX.DataSource = Me.CompositionCountsBindingSource
        CompositionCountsGridEX_DesignTimeLayout.LayoutString = resources.GetString("CompositionCountsGridEX_DesignTimeLayout.LayoutString")
        Me.CompositionCountsGridEX.DesignTimeLayout = CompositionCountsGridEX_DesignTimeLayout
        Me.CompositionCountsGridEX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CompositionCountsGridEX.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CompositionCountsGridEX.GroupByBoxVisible = False
        Me.CompositionCountsGridEX.Location = New System.Drawing.Point(0, 0)
        Me.CompositionCountsGridEX.Name = "CompositionCountsGridEX"
        Me.CompositionCountsGridEX.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.CompositionCountsGridEX.Size = New System.Drawing.Size(339, 259)
        Me.CompositionCountsGridEX.TabIndex = 0
        Me.CompositionCountsGridEX.TotalRow = Janus.Windows.GridEX.InheritableBoolean.[True]
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
        'XrefCompCountCaribouGridEX
        '
        Me.XrefCompCountCaribouGridEX.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.XrefCompCountCaribouGridEX.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.XrefCompCountCaribouGridEX.DataSource = Me.XrefCompCountCaribouBindingSource
        XrefCompCountCaribouGridEX_DesignTimeLayout.LayoutString = resources.GetString("XrefCompCountCaribouGridEX_DesignTimeLayout.LayoutString")
        Me.XrefCompCountCaribouGridEX.DesignTimeLayout = XrefCompCountCaribouGridEX_DesignTimeLayout
        Me.XrefCompCountCaribouGridEX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XrefCompCountCaribouGridEX.GroupByBoxVisible = False
        Me.XrefCompCountCaribouGridEX.Location = New System.Drawing.Point(0, 0)
        Me.XrefCompCountCaribouGridEX.Name = "XrefCompCountCaribouGridEX"
        Me.XrefCompCountCaribouGridEX.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.XrefCompCountCaribouGridEX.Size = New System.Drawing.Size(413, 259)
        Me.XrefCompCountCaribouGridEX.TabIndex = 0
        Me.XrefCompCountCaribouGridEX.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        '
        'XrefCompCountCaribouBindingSource
        '
        Me.XrefCompCountCaribouBindingSource.DataMember = "FK_xrefCompCountCaribou_CompositionCounts"
        Me.XrefCompCountCaribouBindingSource.DataSource = Me.CompositionCountsBindingSource
        '
        'CompCountToolStrip
        '
        Me.CompCountToolStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.CompCountToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportCompCountWaypointsToolStripButton})
        Me.CompCountToolStrip.Location = New System.Drawing.Point(3, 3)
        Me.CompCountToolStrip.Name = "CompCountToolStrip"
        Me.CompCountToolStrip.Size = New System.Drawing.Size(756, 27)
        Me.CompCountToolStrip.TabIndex = 1
        Me.CompCountToolStrip.Text = "ToolStrip1"
        '
        'ImportCompCountWaypointsToolStripButton
        '
        Me.ImportCompCountWaypointsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ImportCompCountWaypointsToolStripButton.Image = CType(resources.GetObject("ImportCompCountWaypointsToolStripButton.Image"), System.Drawing.Image)
        Me.ImportCompCountWaypointsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ImportCompCountWaypointsToolStripButton.Name = "ImportCompCountWaypointsToolStripButton"
        Me.ImportCompCountWaypointsToolStripButton.Size = New System.Drawing.Size(138, 24)
        Me.ImportCompCountWaypointsToolStripButton.Text = "Import waypoints..."
        '
        'PopulationTabPage
        '
        Me.PopulationTabPage.AutoScroll = True
        Me.PopulationTabPage.Controls.Add(Me.PopulationSurveySplitContainer)
        Me.PopulationTabPage.Controls.Add(Me.PopulationToolStrip)
        Me.PopulationTabPage.Location = New System.Drawing.Point(4, 25)
        Me.PopulationTabPage.Name = "PopulationTabPage"
        Me.PopulationTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.PopulationTabPage.Size = New System.Drawing.Size(762, 318)
        Me.PopulationTabPage.TabIndex = 1
        Me.PopulationTabPage.Text = "Population"
        Me.PopulationTabPage.UseVisualStyleBackColor = True
        '
        'PopulationSurveySplitContainer
        '
        Me.PopulationSurveySplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PopulationSurveySplitContainer.Location = New System.Drawing.Point(3, 30)
        Me.PopulationSurveySplitContainer.Name = "PopulationSurveySplitContainer"
        '
        'PopulationSurveySplitContainer.Panel1
        '
        Me.PopulationSurveySplitContainer.Panel1.Controls.Add(Me.PopulationEstimateGridEX)
        '
        'PopulationSurveySplitContainer.Panel2
        '
        Me.PopulationSurveySplitContainer.Panel2.AutoScroll = True
        Me.PopulationSurveySplitContainer.Panel2.Controls.Add(Me.XrefPopulationCaribouGridEX)
        Me.PopulationSurveySplitContainer.Size = New System.Drawing.Size(756, 285)
        Me.PopulationSurveySplitContainer.SplitterDistance = 400
        Me.PopulationSurveySplitContainer.TabIndex = 2
        '
        'PopulationEstimateGridEX
        '
        Me.PopulationEstimateGridEX.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.PopulationEstimateGridEX.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.PopulationEstimateGridEX.AlternatingColors = True
        Me.PopulationEstimateGridEX.DataSource = Me.PopulationEstimateBindingSource
        PopulationEstimateGridEX_DesignTimeLayout.LayoutString = resources.GetString("PopulationEstimateGridEX_DesignTimeLayout.LayoutString")
        Me.PopulationEstimateGridEX.DesignTimeLayout = PopulationEstimateGridEX_DesignTimeLayout
        Me.PopulationEstimateGridEX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PopulationEstimateGridEX.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PopulationEstimateGridEX.GroupByBoxVisible = False
        Me.PopulationEstimateGridEX.GroupTotals = Janus.Windows.GridEX.GroupTotals.Always
        Me.PopulationEstimateGridEX.Location = New System.Drawing.Point(0, 0)
        Me.PopulationEstimateGridEX.Name = "PopulationEstimateGridEX"
        Me.PopulationEstimateGridEX.RecordNavigator = True
        Me.PopulationEstimateGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.PopulationEstimateGridEX.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection
        Me.PopulationEstimateGridEX.Size = New System.Drawing.Size(400, 285)
        Me.PopulationEstimateGridEX.TabIndex = 0
        Me.PopulationEstimateGridEX.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.PopulationEstimateGridEX.TotalRow = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.PopulationEstimateGridEX.TotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
        '
        'PopulationEstimateBindingSource
        '
        Me.PopulationEstimateBindingSource.DataMember = "FK_PopulationEstimate_SurveyFlights"
        Me.PopulationEstimateBindingSource.DataSource = Me.SurveyFlightsBindingSource
        '
        'XrefPopulationCaribouGridEX
        '
        Me.XrefPopulationCaribouGridEX.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.XrefPopulationCaribouGridEX.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.XrefPopulationCaribouGridEX.DataSource = Me.XrefPopulationCaribouBindingSource
        XrefPopulationCaribouGridEX_DesignTimeLayout.LayoutString = resources.GetString("XrefPopulationCaribouGridEX_DesignTimeLayout.LayoutString")
        Me.XrefPopulationCaribouGridEX.DesignTimeLayout = XrefPopulationCaribouGridEX_DesignTimeLayout
        Me.XrefPopulationCaribouGridEX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XrefPopulationCaribouGridEX.GroupByBoxVisible = False
        Me.XrefPopulationCaribouGridEX.Location = New System.Drawing.Point(0, 0)
        Me.XrefPopulationCaribouGridEX.Name = "XrefPopulationCaribouGridEX"
        Me.XrefPopulationCaribouGridEX.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.XrefPopulationCaribouGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.XrefPopulationCaribouGridEX.Size = New System.Drawing.Size(352, 285)
        Me.XrefPopulationCaribouGridEX.TabIndex = 0
        Me.XrefPopulationCaribouGridEX.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        '
        'XrefPopulationCaribouBindingSource
        '
        Me.XrefPopulationCaribouBindingSource.DataMember = "FK_xrefPopulationCaribou_PopulationEstimate"
        Me.XrefPopulationCaribouBindingSource.DataSource = Me.PopulationEstimateBindingSource
        '
        'PopulationToolStrip
        '
        Me.PopulationToolStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.PopulationToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportPopulationWaypointsToolStripButton})
        Me.PopulationToolStrip.Location = New System.Drawing.Point(3, 3)
        Me.PopulationToolStrip.Name = "PopulationToolStrip"
        Me.PopulationToolStrip.Size = New System.Drawing.Size(756, 27)
        Me.PopulationToolStrip.TabIndex = 1
        Me.PopulationToolStrip.Text = "ToolStrip1"
        '
        'ImportPopulationWaypointsToolStripButton
        '
        Me.ImportPopulationWaypointsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ImportPopulationWaypointsToolStripButton.Image = CType(resources.GetObject("ImportPopulationWaypointsToolStripButton.Image"), System.Drawing.Image)
        Me.ImportPopulationWaypointsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ImportPopulationWaypointsToolStripButton.Name = "ImportPopulationWaypointsToolStripButton"
        Me.ImportPopulationWaypointsToolStripButton.Size = New System.Drawing.Size(138, 24)
        Me.ImportPopulationWaypointsToolStripButton.Text = "Import waypoints..."
        '
        'RadiotrackingTabPage
        '
        Me.RadiotrackingTabPage.Controls.Add(Me.RadioTrackingSplitContainer)
        Me.RadiotrackingTabPage.Controls.Add(Me.RadiotrackingToolStrip)
        Me.RadiotrackingTabPage.Location = New System.Drawing.Point(4, 25)
        Me.RadiotrackingTabPage.Name = "RadiotrackingTabPage"
        Me.RadiotrackingTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.RadiotrackingTabPage.Size = New System.Drawing.Size(762, 318)
        Me.RadiotrackingTabPage.TabIndex = 2
        Me.RadiotrackingTabPage.Text = "Radiotracking"
        Me.RadiotrackingTabPage.UseVisualStyleBackColor = True
        '
        'RadioTrackingSplitContainer
        '
        Me.RadioTrackingSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadioTrackingSplitContainer.Location = New System.Drawing.Point(3, 30)
        Me.RadioTrackingSplitContainer.Name = "RadioTrackingSplitContainer"
        '
        'RadioTrackingSplitContainer.Panel1
        '
        Me.RadioTrackingSplitContainer.Panel1.AutoScroll = True
        Me.RadioTrackingSplitContainer.Panel1.Controls.Add(Me.RadioTrackingGridEX)
        '
        'RadioTrackingSplitContainer.Panel2
        '
        Me.RadioTrackingSplitContainer.Panel2.AutoScroll = True
        Me.RadioTrackingSplitContainer.Panel2.Controls.Add(Me.XrefRadiotrackingCaribouGridEX)
        Me.RadioTrackingSplitContainer.Size = New System.Drawing.Size(756, 285)
        Me.RadioTrackingSplitContainer.SplitterDistance = 398
        Me.RadioTrackingSplitContainer.TabIndex = 2
        '
        'RadioTrackingGridEX
        '
        Me.RadioTrackingGridEX.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.RadioTrackingGridEX.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.RadioTrackingGridEX.DataSource = Me.RadioTrackingBindingSource
        RadioTrackingGridEX_DesignTimeLayout.LayoutString = resources.GetString("RadioTrackingGridEX_DesignTimeLayout.LayoutString")
        Me.RadioTrackingGridEX.DesignTimeLayout = RadioTrackingGridEX_DesignTimeLayout
        Me.RadioTrackingGridEX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadioTrackingGridEX.GroupByBoxVisible = False
        Me.RadioTrackingGridEX.GroupTotals = Janus.Windows.GridEX.GroupTotals.Always
        Me.RadioTrackingGridEX.Location = New System.Drawing.Point(0, 0)
        Me.RadioTrackingGridEX.Name = "RadioTrackingGridEX"
        Me.RadioTrackingGridEX.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.RadioTrackingGridEX.Size = New System.Drawing.Size(398, 285)
        Me.RadioTrackingGridEX.TabIndex = 0
        '
        'RadioTrackingBindingSource
        '
        Me.RadioTrackingBindingSource.DataMember = "FK_RadioTracking_SurveyFlights"
        Me.RadioTrackingBindingSource.DataSource = Me.SurveyFlightsBindingSource
        '
        'XrefRadiotrackingCaribouGridEX
        '
        Me.XrefRadiotrackingCaribouGridEX.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.XrefRadiotrackingCaribouGridEX.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.XrefRadiotrackingCaribouGridEX.DataSource = Me.XrefRadiotrackingCaribouBindingSource1
        XrefRadiotrackingCaribouGridEX_DesignTimeLayout.LayoutString = resources.GetString("XrefRadiotrackingCaribouGridEX_DesignTimeLayout.LayoutString")
        Me.XrefRadiotrackingCaribouGridEX.DesignTimeLayout = XrefRadiotrackingCaribouGridEX_DesignTimeLayout
        Me.XrefRadiotrackingCaribouGridEX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XrefRadiotrackingCaribouGridEX.GroupByBoxVisible = False
        Me.XrefRadiotrackingCaribouGridEX.Location = New System.Drawing.Point(0, 0)
        Me.XrefRadiotrackingCaribouGridEX.Name = "XrefRadiotrackingCaribouGridEX"
        Me.XrefRadiotrackingCaribouGridEX.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.XrefRadiotrackingCaribouGridEX.Size = New System.Drawing.Size(354, 285)
        Me.XrefRadiotrackingCaribouGridEX.TabIndex = 0
        '
        'XrefRadiotrackingCaribouBindingSource1
        '
        Me.XrefRadiotrackingCaribouBindingSource1.DataMember = "FK_xrefRadiotrackingCaribou_RadioTracking"
        Me.XrefRadiotrackingCaribouBindingSource1.DataSource = Me.RadioTrackingBindingSource
        '
        'RadiotrackingToolStrip
        '
        Me.RadiotrackingToolStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.RadiotrackingToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportRadiotrackingWaypointsToolStripButton})
        Me.RadiotrackingToolStrip.Location = New System.Drawing.Point(3, 3)
        Me.RadiotrackingToolStrip.Name = "RadiotrackingToolStrip"
        Me.RadiotrackingToolStrip.Size = New System.Drawing.Size(756, 27)
        Me.RadiotrackingToolStrip.TabIndex = 1
        Me.RadiotrackingToolStrip.Text = "ToolStrip1"
        '
        'ImportRadiotrackingWaypointsToolStripButton
        '
        Me.ImportRadiotrackingWaypointsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ImportRadiotrackingWaypointsToolStripButton.Image = CType(resources.GetObject("ImportRadiotrackingWaypointsToolStripButton.Image"), System.Drawing.Image)
        Me.ImportRadiotrackingWaypointsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ImportRadiotrackingWaypointsToolStripButton.Name = "ImportRadiotrackingWaypointsToolStripButton"
        Me.ImportRadiotrackingWaypointsToolStripButton.Size = New System.Drawing.Size(230, 24)
        Me.ImportRadiotrackingWaypointsToolStripButton.Text = "Import radiotracking waypoints..."
        '
        'CampaignsSplitContainer
        '
        Me.CampaignsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CampaignsSplitContainer.Location = New System.Drawing.Point(3, 3)
        Me.CampaignsSplitContainer.Name = "CampaignsSplitContainer"
        '
        'CampaignsSplitContainer.Panel1
        '
        Me.CampaignsSplitContainer.Panel1.Controls.Add(Me.CampaignsGridEX)
        Me.CampaignsSplitContainer.Panel1.Controls.Add(Me.Panel1)
        '
        'CampaignsSplitContainer.Panel2
        '
        Me.CampaignsSplitContainer.Panel2.Controls.Add(Me.CampaignTabControl)
        Me.CampaignsSplitContainer.Panel2.Controls.Add(Me.SurveysPanel)
        Me.CampaignsSplitContainer.Size = New System.Drawing.Size(1181, 603)
        Me.CampaignsSplitContainer.SplitterDistance = 393
        Me.CampaignsSplitContainer.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CampaignLabel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(393, 38)
        Me.Panel1.TabIndex = 2
        '
        'CampaignLabel
        '
        Me.CampaignLabel.AutoSize = True
        Me.CampaignLabel.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CampaignLabel.Location = New System.Drawing.Point(5, 9)
        Me.CampaignLabel.Name = "CampaignLabel"
        Me.CampaignLabel.Size = New System.Drawing.Size(87, 24)
        Me.CampaignLabel.TabIndex = 0
        Me.CampaignLabel.Text = "Surveys"
        '
        'CampaignTabControl
        '
        Me.CampaignTabControl.Controls.Add(Me.DataEditingTabPage)
        Me.CampaignTabControl.Controls.Add(Me.ResultsTabPage)
        Me.CampaignTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CampaignTabControl.Location = New System.Drawing.Point(0, 38)
        Me.CampaignTabControl.Name = "CampaignTabControl"
        Me.CampaignTabControl.SelectedIndex = 0
        Me.CampaignTabControl.Size = New System.Drawing.Size(784, 565)
        Me.CampaignTabControl.TabIndex = 4
        '
        'DataEditingTabPage
        '
        Me.DataEditingTabPage.Controls.Add(Me.SurveyFlightsSplitContainer)
        Me.DataEditingTabPage.Location = New System.Drawing.Point(4, 25)
        Me.DataEditingTabPage.Name = "DataEditingTabPage"
        Me.DataEditingTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.DataEditingTabPage.Size = New System.Drawing.Size(776, 536)
        Me.DataEditingTabPage.TabIndex = 1
        Me.DataEditingTabPage.Text = "Data editing"
        Me.DataEditingTabPage.UseVisualStyleBackColor = True
        '
        'SurveyFlightsSplitContainer
        '
        Me.SurveyFlightsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SurveyFlightsSplitContainer.Location = New System.Drawing.Point(3, 3)
        Me.SurveyFlightsSplitContainer.Name = "SurveyFlightsSplitContainer"
        Me.SurveyFlightsSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SurveyFlightsSplitContainer.Panel1
        '
        Me.SurveyFlightsSplitContainer.Panel1.Controls.Add(Me.SurveyFlightsGridEX)
        '
        'SurveyFlightsSplitContainer.Panel2
        '
        Me.SurveyFlightsSplitContainer.Panel2.Controls.Add(Me.SurveyDataTabControl)
        Me.SurveyFlightsSplitContainer.Panel2.Controls.Add(Me.DataPanel)
        Me.SurveyFlightsSplitContainer.Size = New System.Drawing.Size(770, 530)
        Me.SurveyFlightsSplitContainer.SplitterDistance = 167
        Me.SurveyFlightsSplitContainer.TabIndex = 5
        '
        'CampaignContextLabel
        '
        Me.CampaignContextLabel.AutoSize = True
        Me.CampaignContextLabel.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CampaignContextLabel.Location = New System.Drawing.Point(12, 9)
        Me.CampaignContextLabel.Name = "CampaignContextLabel"
        Me.CampaignContextLabel.Size = New System.Drawing.Size(74, 24)
        Me.CampaignContextLabel.TabIndex = 0
        Me.CampaignContextLabel.Text = "Flights"
        '
        'SurveyFlightsGridEX
        '
        Me.SurveyFlightsGridEX.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.SurveyFlightsGridEX.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.SurveyFlightsGridEX.AutoEdit = True
        Me.SurveyFlightsGridEX.DataSource = Me.SurveyFlightsBindingSource
        SurveyFlightsGridEX_DesignTimeLayout.LayoutString = resources.GetString("SurveyFlightsGridEX_DesignTimeLayout.LayoutString")
        Me.SurveyFlightsGridEX.DesignTimeLayout = SurveyFlightsGridEX_DesignTimeLayout
        Me.SurveyFlightsGridEX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SurveyFlightsGridEX.GroupByBoxVisible = False
        Me.SurveyFlightsGridEX.Location = New System.Drawing.Point(0, 0)
        Me.SurveyFlightsGridEX.Name = "SurveyFlightsGridEX"
        Me.SurveyFlightsGridEX.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.SurveyFlightsGridEX.RecordNavigator = True
        Me.SurveyFlightsGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[Default]
        Me.SurveyFlightsGridEX.Size = New System.Drawing.Size(770, 167)
        Me.SurveyFlightsGridEX.TabIndex = 0
        '
        'SurveysPanel
        '
        Me.SurveysPanel.Controls.Add(Me.CampaignContextLabel)
        Me.SurveysPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.SurveysPanel.Location = New System.Drawing.Point(0, 0)
        Me.SurveysPanel.Name = "SurveysPanel"
        Me.SurveysPanel.Size = New System.Drawing.Size(784, 38)
        Me.SurveysPanel.TabIndex = 3
        '
        'DataPanel
        '
        Me.DataPanel.Controls.Add(Me.FlightContextLabel)
        Me.DataPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.DataPanel.Location = New System.Drawing.Point(0, 0)
        Me.DataPanel.Name = "DataPanel"
        Me.DataPanel.Size = New System.Drawing.Size(770, 38)
        Me.DataPanel.TabIndex = 5
        '
        'FlightContextLabel
        '
        Me.FlightContextLabel.AutoSize = True
        Me.FlightContextLabel.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FlightContextLabel.Location = New System.Drawing.Point(5, 9)
        Me.FlightContextLabel.Name = "FlightContextLabel"
        Me.FlightContextLabel.Size = New System.Drawing.Size(53, 24)
        Me.FlightContextLabel.TabIndex = 0
        Me.FlightContextLabel.Text = "Data"
        '
        'ResultsTabPage
        '
        Me.ResultsTabPage.Controls.Add(Me.ResultsDataGridView)
        Me.ResultsTabPage.Controls.Add(Me.ResultsToolStrip)
        Me.ResultsTabPage.Location = New System.Drawing.Point(4, 25)
        Me.ResultsTabPage.Name = "ResultsTabPage"
        Me.ResultsTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.ResultsTabPage.Size = New System.Drawing.Size(776, 574)
        Me.ResultsTabPage.TabIndex = 0
        Me.ResultsTabPage.Text = "Results"
        Me.ResultsTabPage.UseVisualStyleBackColor = True
        '
        'ResultsDataGridView
        '
        Me.ResultsDataGridView.AllowUserToAddRows = False
        Me.ResultsDataGridView.AllowUserToDeleteRows = False
        Me.ResultsDataGridView.AllowUserToOrderColumns = True
        Me.ResultsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.ResultsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ResultsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ResultsDataGridView.Location = New System.Drawing.Point(3, 30)
        Me.ResultsDataGridView.Name = "ResultsDataGridView"
        Me.ResultsDataGridView.ReadOnly = True
        Me.ResultsDataGridView.RowTemplate.Height = 24
        Me.ResultsDataGridView.Size = New System.Drawing.Size(770, 541)
        Me.ResultsDataGridView.TabIndex = 0
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
        'MainToolStrip
        '
        Me.MainToolStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveDatasetToolStripButton})
        Me.MainToolStrip.Location = New System.Drawing.Point(0, 28)
        Me.MainToolStrip.Name = "MainToolStrip"
        Me.MainToolStrip.Size = New System.Drawing.Size(1195, 27)
        Me.MainToolStrip.TabIndex = 5
        Me.MainToolStrip.Text = "Tools"
        '
        'SaveDatasetToolStripButton
        '
        Me.SaveDatasetToolStripButton.Image = CType(resources.GetObject("SaveDatasetToolStripButton.Image"), System.Drawing.Image)
        Me.SaveDatasetToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveDatasetToolStripButton.Name = "SaveDatasetToolStripButton"
        Me.SaveDatasetToolStripButton.Size = New System.Drawing.Size(147, 24)
        Me.SaveDatasetToolStripButton.Text = "Save to database"
        '
        'MainTabControl
        '
        Me.MainTabControl.Controls.Add(Me.SurveysTabPage)
        Me.MainTabControl.Controls.Add(Me.CaribouTabPage)
        Me.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainTabControl.Location = New System.Drawing.Point(0, 55)
        Me.MainTabControl.Name = "MainTabControl"
        Me.MainTabControl.SelectedIndex = 0
        Me.MainTabControl.Size = New System.Drawing.Size(1195, 638)
        Me.MainTabControl.TabIndex = 6
        '
        'SurveysTabPage
        '
        Me.SurveysTabPage.Controls.Add(Me.CampaignsSplitContainer)
        Me.SurveysTabPage.Location = New System.Drawing.Point(4, 25)
        Me.SurveysTabPage.Name = "SurveysTabPage"
        Me.SurveysTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.SurveysTabPage.Size = New System.Drawing.Size(1187, 609)
        Me.SurveysTabPage.TabIndex = 0
        Me.SurveysTabPage.Text = "Surveys"
        Me.SurveysTabPage.UseVisualStyleBackColor = True
        '
        'CaribouTabPage
        '
        Me.CaribouTabPage.AutoScroll = True
        Me.CaribouTabPage.Controls.Add(Me.CaribouGridEX)
        Me.CaribouTabPage.Location = New System.Drawing.Point(4, 25)
        Me.CaribouTabPage.Name = "CaribouTabPage"
        Me.CaribouTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.CaribouTabPage.Size = New System.Drawing.Size(1187, 609)
        Me.CaribouTabPage.TabIndex = 1
        Me.CaribouTabPage.Text = "Caribou"
        Me.CaribouTabPage.UseVisualStyleBackColor = True
        '
        'CaribouGridEX
        '
        Me.CaribouGridEX.DataSource = Me.CaribouBindingSource
        CaribouGridEX_DesignTimeLayout.LayoutString = resources.GetString("CaribouGridEX_DesignTimeLayout.LayoutString")
        Me.CaribouGridEX.DesignTimeLayout = CaribouGridEX_DesignTimeLayout
        Me.CaribouGridEX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CaribouGridEX.Hierarchical = True
        Me.CaribouGridEX.Location = New System.Drawing.Point(3, 3)
        Me.CaribouGridEX.Name = "CaribouGridEX"
        Me.CaribouGridEX.Size = New System.Drawing.Size(1181, 603)
        Me.CaribouGridEX.TabIndex = 0
        '
        'CaribouBindingSource
        '
        Me.CaribouBindingSource.DataMember = "Caribou"
        Me.CaribouBindingSource.DataSource = Me.WRST_CaribouDataSet
        '
        'CapturesBindingSource
        '
        Me.CapturesBindingSource.DataMember = "FK_Captures_Caribou"
        Me.CapturesBindingSource.DataSource = Me.CaribouBindingSource
        '
        'XrefRadiotrackingCaribouBindingSource
        '
        Me.XrefRadiotrackingCaribouBindingSource.DataMember = "FK_xrefRadiotrackingCaribou_Caribou"
        Me.XrefRadiotrackingCaribouBindingSource.DataSource = Me.CaribouBindingSource
        '
        'CampaignsTableAdapter
        '
        Me.CampaignsTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CampaignsTableAdapter = Me.CampaignsTableAdapter
        Me.TableAdapterManager.CapturesTableAdapter = Me.CapturesTableAdapter
        Me.TableAdapterManager.CaribouTableAdapter = Me.CaribouTableAdapter
        Me.TableAdapterManager.CompositionCountsTableAdapter = Me.CompositionCountsTableAdapter
        Me.TableAdapterManager.PopulationEstimateTableAdapter = Me.PopulationEstimateTableAdapter
        Me.TableAdapterManager.RadioTrackingTableAdapter = Me.RadioTrackingTableAdapter
        Me.TableAdapterManager.SurveyFlightsTableAdapter = Me.SurveyFlightsTableAdapter
        Me.TableAdapterManager.UpdateOrder = WRST_Caribou.WRST_CaribouDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.WorkLogTableAdapter = Nothing
        Me.TableAdapterManager.xrefCompCountCaribouTableAdapter = Me.XrefCompCountCaribouTableAdapter
        Me.TableAdapterManager.xrefPopulationCaribouTableAdapter = Me.XrefPopulationCaribouTableAdapter
        Me.TableAdapterManager.xrefRadiotrackingCaribouTableAdapter = Me.XrefRadiotrackingCaribouTableAdapter
        '
        'CapturesTableAdapter
        '
        Me.CapturesTableAdapter.ClearBeforeFill = True
        '
        'CaribouTableAdapter
        '
        Me.CaribouTableAdapter.ClearBeforeFill = True
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
        'SurveyFlightsTableAdapter
        '
        Me.SurveyFlightsTableAdapter.ClearBeforeFill = True
        '
        'XrefCompCountCaribouTableAdapter
        '
        Me.XrefCompCountCaribouTableAdapter.ClearBeforeFill = True
        '
        'XrefPopulationCaribouTableAdapter
        '
        Me.XrefPopulationCaribouTableAdapter.ClearBeforeFill = True
        '
        'XrefRadiotrackingCaribouTableAdapter
        '
        Me.XrefRadiotrackingCaribouTableAdapter.ClearBeforeFill = True
        '
        'ResultsToolStrip
        '
        Me.ResultsToolStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ResultsToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DatabaseViewLabel, Me.DatabaseViewNameToolStripLabel, Me.ToolStripSeparator2, Me.RefreshResultsToolStripButton, Me.ToolStripSeparator1})
        Me.ResultsToolStrip.Location = New System.Drawing.Point(3, 3)
        Me.ResultsToolStrip.Name = "ResultsToolStrip"
        Me.ResultsToolStrip.Size = New System.Drawing.Size(770, 27)
        Me.ResultsToolStrip.TabIndex = 1
        Me.ResultsToolStrip.Text = "ToolStrip1"
        '
        'RefreshResultsToolStripButton
        '
        Me.RefreshResultsToolStripButton.Image = CType(resources.GetObject("RefreshResultsToolStripButton.Image"), System.Drawing.Image)
        Me.RefreshResultsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RefreshResultsToolStripButton.Name = "RefreshResultsToolStripButton"
        Me.RefreshResultsToolStripButton.Size = New System.Drawing.Size(82, 24)
        Me.RefreshResultsToolStripButton.Text = "Refresh"
        '
        'DatabaseViewLabel
        '
        Me.DatabaseViewLabel.Name = "DatabaseViewLabel"
        Me.DatabaseViewLabel.Size = New System.Drawing.Size(109, 24)
        Me.DatabaseViewLabel.Text = "Database view:"
        '
        'DatabaseViewNameToolStripLabel
        '
        Me.DatabaseViewNameToolStripLabel.Name = "DatabaseViewNameToolStripLabel"
        Me.DatabaseViewNameToolStripLabel.Size = New System.Drawing.Size(147, 24)
        Me.DatabaseViewNameToolStripLabel.Text = "Database view name"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 27)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 27)
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1195, 693)
        Me.Controls.Add(Me.MainTabControl)
        Me.Controls.Add(Me.MainToolStrip)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "NPS Wrangell St. Elias National Park & Preserve Caribou Monitoring Program"
        CType(Me.CampaignsGridEX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CampaignsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WRST_CaribouDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SurveyDataTabControl.ResumeLayout(False)
        Me.CompositionCountTabPage.ResumeLayout(False)
        Me.CompositionCountTabPage.PerformLayout()
        Me.CompCountSplitContainer.Panel1.ResumeLayout(False)
        Me.CompCountSplitContainer.Panel2.ResumeLayout(False)
        CType(Me.CompCountSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CompCountSplitContainer.ResumeLayout(False)
        CType(Me.CompositionCountsGridEX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompositionCountsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SurveyFlightsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrefCompCountCaribouGridEX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrefCompCountCaribouBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CompCountToolStrip.ResumeLayout(False)
        Me.CompCountToolStrip.PerformLayout()
        Me.PopulationTabPage.ResumeLayout(False)
        Me.PopulationTabPage.PerformLayout()
        Me.PopulationSurveySplitContainer.Panel1.ResumeLayout(False)
        Me.PopulationSurveySplitContainer.Panel2.ResumeLayout(False)
        CType(Me.PopulationSurveySplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PopulationSurveySplitContainer.ResumeLayout(False)
        CType(Me.PopulationEstimateGridEX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopulationEstimateBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrefPopulationCaribouGridEX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrefPopulationCaribouBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PopulationToolStrip.ResumeLayout(False)
        Me.PopulationToolStrip.PerformLayout()
        Me.RadiotrackingTabPage.ResumeLayout(False)
        Me.RadiotrackingTabPage.PerformLayout()
        Me.RadioTrackingSplitContainer.Panel1.ResumeLayout(False)
        Me.RadioTrackingSplitContainer.Panel2.ResumeLayout(False)
        CType(Me.RadioTrackingSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadioTrackingSplitContainer.ResumeLayout(False)
        CType(Me.RadioTrackingGridEX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadioTrackingBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrefRadiotrackingCaribouGridEX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrefRadiotrackingCaribouBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadiotrackingToolStrip.ResumeLayout(False)
        Me.RadiotrackingToolStrip.PerformLayout()
        Me.CampaignsSplitContainer.Panel1.ResumeLayout(False)
        Me.CampaignsSplitContainer.Panel2.ResumeLayout(False)
        CType(Me.CampaignsSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CampaignsSplitContainer.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.CampaignTabControl.ResumeLayout(False)
        Me.DataEditingTabPage.ResumeLayout(False)
        Me.SurveyFlightsSplitContainer.Panel1.ResumeLayout(False)
        Me.SurveyFlightsSplitContainer.Panel2.ResumeLayout(False)
        CType(Me.SurveyFlightsSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SurveyFlightsSplitContainer.ResumeLayout(False)
        CType(Me.SurveyFlightsGridEX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SurveysPanel.ResumeLayout(False)
        Me.SurveysPanel.PerformLayout()
        Me.DataPanel.ResumeLayout(False)
        Me.DataPanel.PerformLayout()
        Me.ResultsTabPage.ResumeLayout(False)
        Me.ResultsTabPage.PerformLayout()
        CType(Me.ResultsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.MainToolStrip.ResumeLayout(False)
        Me.MainToolStrip.PerformLayout()
        Me.MainTabControl.ResumeLayout(False)
        Me.SurveysTabPage.ResumeLayout(False)
        Me.CaribouTabPage.ResumeLayout(False)
        CType(Me.CaribouGridEX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CaribouBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CapturesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrefRadiotrackingCaribouBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResultsToolStrip.ResumeLayout(False)
        Me.ResultsToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents WRST_CaribouDataSet As WRST_CaribouDataSet
    Friend WithEvents CampaignsBindingSource As BindingSource
    Friend WithEvents CampaignsTableAdapter As WRST_CaribouDataSetTableAdapters.CampaignsTableAdapter
    Friend WithEvents TableAdapterManager As WRST_CaribouDataSetTableAdapters.TableAdapterManager
    Friend WithEvents CampaignsGridEX As Janus.Windows.GridEX.GridEX
    Friend WithEvents SurveyDataTabControl As TabControl
    Friend WithEvents CompositionCountTabPage As TabPage
    Friend WithEvents PopulationTabPage As TabPage
    Friend WithEvents CampaignsSplitContainer As SplitContainer
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
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveChangesToDatabaseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DatabaseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditDatabaseConnectionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SurveyFlightsSplitContainer As SplitContainer
    Friend WithEvents MainToolStrip As ToolStrip
    Friend WithEvents SaveDatasetToolStripButton As ToolStripButton
    Friend WithEvents MainTabControl As TabControl
    Friend WithEvents SurveysTabPage As TabPage
    Friend WithEvents CaribouTabPage As TabPage
    Friend WithEvents CaribouBindingSource As BindingSource
    Friend WithEvents CaribouTableAdapter As WRST_CaribouDataSetTableAdapters.CaribouTableAdapter
    Friend WithEvents CaribouGridEX As Janus.Windows.GridEX.GridEX
    Friend WithEvents CapturesBindingSource As BindingSource
    Friend WithEvents CapturesTableAdapter As WRST_CaribouDataSetTableAdapters.CapturesTableAdapter
    Friend WithEvents XrefRadiotrackingCaribouBindingSource As BindingSource
    Friend WithEvents XrefRadiotrackingCaribouTableAdapter As WRST_CaribouDataSetTableAdapters.xrefRadiotrackingCaribouTableAdapter
    Friend WithEvents CompCountToolStrip As ToolStrip
    Friend WithEvents PopulationToolStrip As ToolStrip
    Friend WithEvents ImportPopulationWaypointsToolStripButton As ToolStripButton
    Friend WithEvents PopulationSurveySplitContainer As SplitContainer
    Friend WithEvents ImportCompCountWaypointsToolStripButton As ToolStripButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents CampaignLabel As Label
    Friend WithEvents CampaignContextLabel As Label
    Friend WithEvents SurveysPanel As Panel
    Friend WithEvents DataPanel As Panel
    Friend WithEvents FlightContextLabel As Label
    Friend WithEvents CampaignTabControl As TabControl
    Friend WithEvents ResultsTabPage As TabPage
    Friend WithEvents DataEditingTabPage As TabPage
    Friend WithEvents ResultsDataGridView As DataGridView
    Friend WithEvents RadioTrackingSplitContainer As SplitContainer
    Friend WithEvents XrefPopulationCaribouBindingSource As BindingSource
    Friend WithEvents XrefPopulationCaribouTableAdapter As WRST_CaribouDataSetTableAdapters.xrefPopulationCaribouTableAdapter
    Friend WithEvents XrefPopulationCaribouGridEX As Janus.Windows.GridEX.GridEX
    Friend WithEvents CompCountSplitContainer As SplitContainer
    Friend WithEvents XrefCompCountCaribouBindingSource As BindingSource
    Friend WithEvents XrefCompCountCaribouTableAdapter As WRST_CaribouDataSetTableAdapters.xrefCompCountCaribouTableAdapter
    Friend WithEvents XrefCompCountCaribouGridEX As Janus.Windows.GridEX.GridEX
    Friend WithEvents RadiotrackingToolStrip As ToolStrip
    Friend WithEvents ImportRadiotrackingWaypointsToolStripButton As ToolStripButton
    Friend WithEvents RadioTrackingBindingSource As BindingSource
    Friend WithEvents RadioTrackingTableAdapter As WRST_CaribouDataSetTableAdapters.RadioTrackingTableAdapter
    Friend WithEvents RadioTrackingGridEX As Janus.Windows.GridEX.GridEX
    Friend WithEvents XrefRadiotrackingCaribouGridEX As Janus.Windows.GridEX.GridEX
    Friend WithEvents XrefRadiotrackingCaribouBindingSource1 As BindingSource
    Friend WithEvents ResultsToolStrip As ToolStrip
    Friend WithEvents RefreshResultsToolStripButton As ToolStripButton
    Friend WithEvents DatabaseViewLabel As ToolStripLabel
    Friend WithEvents DatabaseViewNameToolStripLabel As ToolStripLabel
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
End Class
