<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ImportCompCountXYFromFileToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.PopulationTabPage = New System.Windows.Forms.TabPage()
        Me.PopulationSurveySplitContainer = New System.Windows.Forms.SplitContainer()
        Me.PopulationEstimateGridEX = New Janus.Windows.GridEX.GridEX()
        Me.PopulationEstimateBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.XrefPopulationCaribouGridEX = New Janus.Windows.GridEX.GridEX()
        Me.XrefPopulationCaribouBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PopulationToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ImportPopulationWaypointsToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ImportPopulationSurveyWaypointsFromFileToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.RadiotrackingTabPage = New System.Windows.Forms.TabPage()
        Me.RadioTrackingSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.RadioTrackingGridEX = New Janus.Windows.GridEX.GridEX()
        Me.RadioTrackingBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.XrefRadiotrackingCaribouGridEX = New Janus.Windows.GridEX.GridEX()
        Me.RadiotrackingToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ImportRadiotrackingWaypointsToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ImportRadiotrackingWaypointsFromFileToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.CampaignsSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.EditCampaignsCheckBox = New System.Windows.Forms.CheckBox()
        Me.CampaignLabel = New System.Windows.Forms.Label()
        Me.CampaignTabControl = New System.Windows.Forms.TabControl()
        Me.DataEditingTabPage = New System.Windows.Forms.TabPage()
        Me.SurveyFlightsSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.SurveyFlightsGridEX = New Janus.Windows.GridEX.GridEX()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataPanel = New System.Windows.Forms.Panel()
        Me.FlightContextLabel = New System.Windows.Forms.Label()
        Me.ResultsTabPage = New System.Windows.Forms.TabPage()
        Me.ResultsDataGridView = New System.Windows.Forms.DataGridView()
        Me.ResultsPanel = New System.Windows.Forms.Panel()
        Me.ResultsLabel = New System.Windows.Forms.Label()
        Me.ResultsToolStrip = New System.Windows.Forms.ToolStrip()
        Me.DatabaseViewLabel = New System.Windows.Forms.ToolStripLabel()
        Me.DatabaseViewNameToolStripLabel = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.RefreshResultsToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SurveysPanel = New System.Windows.Forms.Panel()
        Me.CampaignHeaderLabel = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveChangesToDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditDatabaseConnectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainToolStrip = New System.Windows.Forms.ToolStrip()
        Me.SaveDatasetToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.RefreshDataToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.MainTabControl = New System.Windows.Forms.TabControl()
        Me.SurveysTabPage = New System.Windows.Forms.TabPage()
        Me.CaribouTabPage = New System.Windows.Forms.TabPage()
        Me.AnimalsSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.AnimalsDataGridView = New System.Windows.Forms.DataGridView()
        Me.CollarDeploymentsDataGridView = New System.Windows.Forms.DataGridView()
        Me.ResultsTabPage2 = New System.Windows.Forms.TabPage()
        Me.SurveyResultsDataGridView = New System.Windows.Forms.DataGridView()
        Me.SurveyResultsBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.SurveyResultsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExportResultsToCSVToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SurveyResultsToolStrip = New System.Windows.Forms.ToolStrip()
        Me.SelectSurveyTypeToolStripLabel = New System.Windows.Forms.ToolStripLabel()
        Me.SelectSurveyTypeToolStripComboBox = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.RefreshToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.CapturesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CaribouBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.XrefRadiotrackingCaribouBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.HelpProvider = New System.Windows.Forms.HelpProvider()
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
        Me.Panel2.SuspendLayout()
        Me.DataPanel.SuspendLayout()
        Me.ResultsTabPage.SuspendLayout()
        CType(Me.ResultsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ResultsPanel.SuspendLayout()
        Me.ResultsToolStrip.SuspendLayout()
        Me.SurveysPanel.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.MainToolStrip.SuspendLayout()
        Me.MainTabControl.SuspendLayout()
        Me.SurveysTabPage.SuspendLayout()
        Me.CaribouTabPage.SuspendLayout()
        CType(Me.AnimalsSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AnimalsSplitContainer.Panel1.SuspendLayout()
        Me.AnimalsSplitContainer.Panel2.SuspendLayout()
        Me.AnimalsSplitContainer.SuspendLayout()
        CType(Me.AnimalsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CollarDeploymentsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ResultsTabPage2.SuspendLayout()
        CType(Me.SurveyResultsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SurveyResultsBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SurveyResultsBindingNavigator.SuspendLayout()
        CType(Me.SurveyResultsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SurveyResultsToolStrip.SuspendLayout()
        CType(Me.CapturesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CaribouBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrefRadiotrackingCaribouBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CampaignsGridEX
        '
        Me.CampaignsGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.CampaignsGridEX.AlternatingColors = True
        Me.CampaignsGridEX.DataSource = Me.CampaignsBindingSource
        CampaignsGridEX_DesignTimeLayout.LayoutString = resources.GetString("CampaignsGridEX_DesignTimeLayout.LayoutString")
        Me.CampaignsGridEX.DesignTimeLayout = CampaignsGridEX_DesignTimeLayout
        Me.CampaignsGridEX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CampaignsGridEX.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CampaignsGridEX.GroupByBoxVisible = False
        Me.HelpProvider.SetHelpKeyword(Me.CampaignsGridEX, "Introduction")
        Me.CampaignsGridEX.Location = New System.Drawing.Point(0, 31)
        Me.CampaignsGridEX.Margin = New System.Windows.Forms.Padding(2)
        Me.CampaignsGridEX.Name = "CampaignsGridEX"
        Me.CampaignsGridEX.RecordNavigator = True
        Me.CampaignsGridEX.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection
        Me.HelpProvider.SetShowHelp(Me.CampaignsGridEX, True)
        Me.CampaignsGridEX.Size = New System.Drawing.Size(217, 649)
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
        Me.SurveyDataTabControl.Location = New System.Drawing.Point(0, 31)
        Me.SurveyDataTabControl.Margin = New System.Windows.Forms.Padding(2)
        Me.SurveyDataTabControl.Name = "SurveyDataTabControl"
        Me.SurveyDataTabControl.SelectedIndex = 0
        Me.SurveyDataTabControl.Size = New System.Drawing.Size(940, 392)
        Me.SurveyDataTabControl.TabIndex = 4
        '
        'CompositionCountTabPage
        '
        Me.CompositionCountTabPage.Controls.Add(Me.CompCountSplitContainer)
        Me.CompositionCountTabPage.Controls.Add(Me.CompCountToolStrip)
        Me.CompositionCountTabPage.Location = New System.Drawing.Point(4, 22)
        Me.CompositionCountTabPage.Margin = New System.Windows.Forms.Padding(2)
        Me.CompositionCountTabPage.Name = "CompositionCountTabPage"
        Me.CompositionCountTabPage.Padding = New System.Windows.Forms.Padding(2)
        Me.CompositionCountTabPage.Size = New System.Drawing.Size(932, 366)
        Me.CompositionCountTabPage.TabIndex = 0
        Me.CompositionCountTabPage.Text = "Composition"
        Me.CompositionCountTabPage.UseVisualStyleBackColor = True
        '
        'CompCountSplitContainer
        '
        Me.CompCountSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CompCountSplitContainer.Location = New System.Drawing.Point(2, 27)
        Me.CompCountSplitContainer.Margin = New System.Windows.Forms.Padding(2)
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
        Me.CompCountSplitContainer.Size = New System.Drawing.Size(928, 337)
        Me.CompCountSplitContainer.SplitterDistance = 537
        Me.CompCountSplitContainer.SplitterWidth = 3
        Me.CompCountSplitContainer.TabIndex = 3
        '
        'CompositionCountsGridEX
        '
        Me.CompositionCountsGridEX.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.CompositionCountsGridEX.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.CompositionCountsGridEX.AlternatingColors = True
        Me.CompositionCountsGridEX.DataSource = Me.CompositionCountsBindingSource
        CompositionCountsGridEX_DesignTimeLayout.LayoutString = resources.GetString("CompositionCountsGridEX_DesignTimeLayout.LayoutString")
        Me.CompositionCountsGridEX.DesignTimeLayout = CompositionCountsGridEX_DesignTimeLayout
        Me.CompositionCountsGridEX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CompositionCountsGridEX.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!)
        Me.CompositionCountsGridEX.GroupByBoxVisible = False
        Me.CompositionCountsGridEX.Location = New System.Drawing.Point(0, 0)
        Me.CompositionCountsGridEX.Margin = New System.Windows.Forms.Padding(2)
        Me.CompositionCountsGridEX.Name = "CompositionCountsGridEX"
        Me.CompositionCountsGridEX.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.CompositionCountsGridEX.Size = New System.Drawing.Size(537, 337)
        Me.CompositionCountsGridEX.TabIndex = 0
        Me.CompositionCountsGridEX.TotalRow = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.CompositionCountsGridEX.TotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
        Me.CompositionCountsGridEX.TotalRowFormatStyle.Key = "CCTotalRowFormatStyleKey"
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
        Me.XrefCompCountCaribouGridEX.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrefCompCountCaribouGridEX.GroupByBoxVisible = False
        Me.XrefCompCountCaribouGridEX.Location = New System.Drawing.Point(0, 0)
        Me.XrefCompCountCaribouGridEX.Margin = New System.Windows.Forms.Padding(2)
        Me.XrefCompCountCaribouGridEX.Name = "XrefCompCountCaribouGridEX"
        Me.XrefCompCountCaribouGridEX.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.XrefCompCountCaribouGridEX.Size = New System.Drawing.Size(388, 337)
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
        Me.CompCountToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportCompCountWaypointsToolStripButton, Me.ToolStripSeparator7, Me.ImportCompCountXYFromFileToolStripButton, Me.ToolStripSeparator6})
        Me.CompCountToolStrip.Location = New System.Drawing.Point(2, 2)
        Me.CompCountToolStrip.Name = "CompCountToolStrip"
        Me.CompCountToolStrip.Size = New System.Drawing.Size(928, 25)
        Me.CompCountToolStrip.TabIndex = 1
        Me.CompCountToolStrip.Text = "ToolStrip1"
        '
        'ImportCompCountWaypointsToolStripButton
        '
        Me.ImportCompCountWaypointsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ImportCompCountWaypointsToolStripButton.Enabled = False
        Me.ImportCompCountWaypointsToolStripButton.Image = CType(resources.GetObject("ImportCompCountWaypointsToolStripButton.Image"), System.Drawing.Image)
        Me.ImportCompCountWaypointsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ImportCompCountWaypointsToolStripButton.Name = "ImportCompCountWaypointsToolStripButton"
        Me.ImportCompCountWaypointsToolStripButton.Size = New System.Drawing.Size(161, 22)
        Me.ImportCompCountWaypointsToolStripButton.Text = "Import DNRGPS waypoints..."
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'ImportCompCountXYFromFileToolStripButton
        '
        Me.ImportCompCountXYFromFileToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ImportCompCountXYFromFileToolStripButton.Image = CType(resources.GetObject("ImportCompCountXYFromFileToolStripButton.Image"), System.Drawing.Image)
        Me.ImportCompCountXYFromFileToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ImportCompCountXYFromFileToolStripButton.Name = "ImportCompCountXYFromFileToolStripButton"
        Me.ImportCompCountXYFromFileToolStripButton.Size = New System.Drawing.Size(238, 22)
        Me.ImportCompCountXYFromFileToolStripButton.Text = "Import comp. count survey data from file..."
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'PopulationTabPage
        '
        Me.PopulationTabPage.AutoScroll = True
        Me.PopulationTabPage.Controls.Add(Me.PopulationSurveySplitContainer)
        Me.PopulationTabPage.Controls.Add(Me.PopulationToolStrip)
        Me.PopulationTabPage.Location = New System.Drawing.Point(4, 22)
        Me.PopulationTabPage.Margin = New System.Windows.Forms.Padding(2)
        Me.PopulationTabPage.Name = "PopulationTabPage"
        Me.PopulationTabPage.Padding = New System.Windows.Forms.Padding(2)
        Me.PopulationTabPage.Size = New System.Drawing.Size(932, 366)
        Me.PopulationTabPage.TabIndex = 1
        Me.PopulationTabPage.Text = "Population"
        Me.PopulationTabPage.UseVisualStyleBackColor = True
        '
        'PopulationSurveySplitContainer
        '
        Me.PopulationSurveySplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PopulationSurveySplitContainer.Location = New System.Drawing.Point(2, 27)
        Me.PopulationSurveySplitContainer.Margin = New System.Windows.Forms.Padding(2)
        Me.PopulationSurveySplitContainer.Name = "PopulationSurveySplitContainer"
        '
        'PopulationSurveySplitContainer.Panel1
        '
        Me.PopulationSurveySplitContainer.Panel1.AutoScroll = True
        Me.PopulationSurveySplitContainer.Panel1.Controls.Add(Me.PopulationEstimateGridEX)
        '
        'PopulationSurveySplitContainer.Panel2
        '
        Me.PopulationSurveySplitContainer.Panel2.AutoScroll = True
        Me.PopulationSurveySplitContainer.Panel2.Controls.Add(Me.XrefPopulationCaribouGridEX)
        Me.PopulationSurveySplitContainer.Size = New System.Drawing.Size(928, 337)
        Me.PopulationSurveySplitContainer.SplitterDistance = 488
        Me.PopulationSurveySplitContainer.SplitterWidth = 3
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
        Me.PopulationEstimateGridEX.Margin = New System.Windows.Forms.Padding(2)
        Me.PopulationEstimateGridEX.Name = "PopulationEstimateGridEX"
        Me.PopulationEstimateGridEX.RecordNavigator = True
        Me.PopulationEstimateGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.PopulationEstimateGridEX.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection
        Me.PopulationEstimateGridEX.Size = New System.Drawing.Size(488, 337)
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
        Me.XrefPopulationCaribouGridEX.Margin = New System.Windows.Forms.Padding(2)
        Me.XrefPopulationCaribouGridEX.Name = "XrefPopulationCaribouGridEX"
        Me.XrefPopulationCaribouGridEX.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.XrefPopulationCaribouGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.XrefPopulationCaribouGridEX.Size = New System.Drawing.Size(437, 337)
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
        Me.PopulationToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportPopulationWaypointsToolStripButton, Me.ToolStripSeparator4, Me.ImportPopulationSurveyWaypointsFromFileToolStripButton, Me.ToolStripSeparator8})
        Me.PopulationToolStrip.Location = New System.Drawing.Point(2, 2)
        Me.PopulationToolStrip.Name = "PopulationToolStrip"
        Me.PopulationToolStrip.Size = New System.Drawing.Size(928, 25)
        Me.PopulationToolStrip.TabIndex = 1
        Me.PopulationToolStrip.Text = "ToolStrip1"
        '
        'ImportPopulationWaypointsToolStripButton
        '
        Me.ImportPopulationWaypointsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ImportPopulationWaypointsToolStripButton.Enabled = False
        Me.ImportPopulationWaypointsToolStripButton.Image = CType(resources.GetObject("ImportPopulationWaypointsToolStripButton.Image"), System.Drawing.Image)
        Me.ImportPopulationWaypointsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ImportPopulationWaypointsToolStripButton.Name = "ImportPopulationWaypointsToolStripButton"
        Me.ImportPopulationWaypointsToolStripButton.Size = New System.Drawing.Size(161, 22)
        Me.ImportPopulationWaypointsToolStripButton.Text = "Import DNRGPS waypoints..."
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ImportPopulationSurveyWaypointsFromFileToolStripButton
        '
        Me.ImportPopulationSurveyWaypointsFromFileToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ImportPopulationSurveyWaypointsFromFileToolStripButton.Image = CType(resources.GetObject("ImportPopulationSurveyWaypointsFromFileToolStripButton.Image"), System.Drawing.Image)
        Me.ImportPopulationSurveyWaypointsFromFileToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ImportPopulationSurveyWaypointsFromFileToolStripButton.Name = "ImportPopulationSurveyWaypointsFromFileToolStripButton"
        Me.ImportPopulationSurveyWaypointsFromFileToolStripButton.Size = New System.Drawing.Size(228, 22)
        Me.ImportPopulationSurveyWaypointsFromFileToolStripButton.Text = "Import population survey data from file..."
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'RadiotrackingTabPage
        '
        Me.RadiotrackingTabPage.Controls.Add(Me.RadioTrackingSplitContainer)
        Me.RadiotrackingTabPage.Controls.Add(Me.RadiotrackingToolStrip)
        Me.RadiotrackingTabPage.Location = New System.Drawing.Point(4, 22)
        Me.RadiotrackingTabPage.Margin = New System.Windows.Forms.Padding(2)
        Me.RadiotrackingTabPage.Name = "RadiotrackingTabPage"
        Me.RadiotrackingTabPage.Padding = New System.Windows.Forms.Padding(2)
        Me.RadiotrackingTabPage.Size = New System.Drawing.Size(932, 366)
        Me.RadiotrackingTabPage.TabIndex = 2
        Me.RadiotrackingTabPage.Text = "Radiotracking"
        Me.RadiotrackingTabPage.UseVisualStyleBackColor = True
        '
        'RadioTrackingSplitContainer
        '
        Me.RadioTrackingSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadioTrackingSplitContainer.Location = New System.Drawing.Point(2, 27)
        Me.RadioTrackingSplitContainer.Margin = New System.Windows.Forms.Padding(2)
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
        Me.RadioTrackingSplitContainer.Size = New System.Drawing.Size(928, 337)
        Me.RadioTrackingSplitContainer.SplitterDistance = 484
        Me.RadioTrackingSplitContainer.SplitterWidth = 3
        Me.RadioTrackingSplitContainer.TabIndex = 2
        '
        'RadioTrackingGridEX
        '
        Me.RadioTrackingGridEX.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.RadioTrackingGridEX.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.RadioTrackingGridEX.AlternatingColors = True
        Me.RadioTrackingGridEX.DataSource = Me.RadioTrackingBindingSource
        RadioTrackingGridEX_DesignTimeLayout.LayoutString = resources.GetString("RadioTrackingGridEX_DesignTimeLayout.LayoutString")
        Me.RadioTrackingGridEX.DesignTimeLayout = RadioTrackingGridEX_DesignTimeLayout
        Me.RadioTrackingGridEX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadioTrackingGridEX.GroupByBoxVisible = False
        Me.RadioTrackingGridEX.GroupTotals = Janus.Windows.GridEX.GroupTotals.Always
        Me.RadioTrackingGridEX.Location = New System.Drawing.Point(0, 0)
        Me.RadioTrackingGridEX.Margin = New System.Windows.Forms.Padding(2)
        Me.RadioTrackingGridEX.Name = "RadioTrackingGridEX"
        Me.RadioTrackingGridEX.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.RadioTrackingGridEX.Size = New System.Drawing.Size(484, 337)
        Me.RadioTrackingGridEX.TabIndex = 0
        Me.RadioTrackingGridEX.TotalRow = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.RadioTrackingGridEX.TotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
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
        XrefRadiotrackingCaribouGridEX_DesignTimeLayout.LayoutString = resources.GetString("XrefRadiotrackingCaribouGridEX_DesignTimeLayout.LayoutString")
        Me.XrefRadiotrackingCaribouGridEX.DesignTimeLayout = XrefRadiotrackingCaribouGridEX_DesignTimeLayout
        Me.XrefRadiotrackingCaribouGridEX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XrefRadiotrackingCaribouGridEX.GroupByBoxVisible = False
        Me.XrefRadiotrackingCaribouGridEX.Location = New System.Drawing.Point(0, 0)
        Me.XrefRadiotrackingCaribouGridEX.Margin = New System.Windows.Forms.Padding(2)
        Me.XrefRadiotrackingCaribouGridEX.Name = "XrefRadiotrackingCaribouGridEX"
        Me.XrefRadiotrackingCaribouGridEX.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.XrefRadiotrackingCaribouGridEX.Size = New System.Drawing.Size(441, 337)
        Me.XrefRadiotrackingCaribouGridEX.TabIndex = 0
        '
        'RadiotrackingToolStrip
        '
        Me.RadiotrackingToolStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.RadiotrackingToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportRadiotrackingWaypointsToolStripButton, Me.ToolStripSeparator5, Me.ImportRadiotrackingWaypointsFromFileToolStripButton, Me.ToolStripSeparator9})
        Me.RadiotrackingToolStrip.Location = New System.Drawing.Point(2, 2)
        Me.RadiotrackingToolStrip.Name = "RadiotrackingToolStrip"
        Me.RadiotrackingToolStrip.Size = New System.Drawing.Size(928, 25)
        Me.RadiotrackingToolStrip.TabIndex = 1
        Me.RadiotrackingToolStrip.Text = "ToolStrip1"
        '
        'ImportRadiotrackingWaypointsToolStripButton
        '
        Me.ImportRadiotrackingWaypointsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ImportRadiotrackingWaypointsToolStripButton.Enabled = False
        Me.ImportRadiotrackingWaypointsToolStripButton.Image = CType(resources.GetObject("ImportRadiotrackingWaypointsToolStripButton.Image"), System.Drawing.Image)
        Me.ImportRadiotrackingWaypointsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ImportRadiotrackingWaypointsToolStripButton.Name = "ImportRadiotrackingWaypointsToolStripButton"
        Me.ImportRadiotrackingWaypointsToolStripButton.Size = New System.Drawing.Size(161, 22)
        Me.ImportRadiotrackingWaypointsToolStripButton.Text = "Import DNRGPS waypoints..."
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ImportRadiotrackingWaypointsFromFileToolStripButton
        '
        Me.ImportRadiotrackingWaypointsFromFileToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ImportRadiotrackingWaypointsFromFileToolStripButton.Image = CType(resources.GetObject("ImportRadiotrackingWaypointsFromFileToolStripButton.Image"), System.Drawing.Image)
        Me.ImportRadiotrackingWaypointsFromFileToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ImportRadiotrackingWaypointsFromFileToolStripButton.Name = "ImportRadiotrackingWaypointsFromFileToolStripButton"
        Me.ImportRadiotrackingWaypointsFromFileToolStripButton.Size = New System.Drawing.Size(240, 22)
        Me.ImportRadiotrackingWaypointsFromFileToolStripButton.Text = "Import radiotracking survey data from file..."
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        '
        'CampaignsSplitContainer
        '
        Me.CampaignsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CampaignsSplitContainer.Location = New System.Drawing.Point(2, 2)
        Me.CampaignsSplitContainer.Margin = New System.Windows.Forms.Padding(2)
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
        Me.CampaignsSplitContainer.Size = New System.Drawing.Size(1172, 680)
        Me.CampaignsSplitContainer.SplitterDistance = 217
        Me.CampaignsSplitContainer.SplitterWidth = 3
        Me.CampaignsSplitContainer.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.EditCampaignsCheckBox)
        Me.Panel1.Controls.Add(Me.CampaignLabel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(217, 31)
        Me.Panel1.TabIndex = 2
        '
        'EditCampaignsCheckBox
        '
        Me.EditCampaignsCheckBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EditCampaignsCheckBox.AutoSize = True
        Me.EditCampaignsCheckBox.Location = New System.Drawing.Point(138, 7)
        Me.EditCampaignsCheckBox.Name = "EditCampaignsCheckBox"
        Me.EditCampaignsCheckBox.Size = New System.Drawing.Size(76, 17)
        Me.EditCampaignsCheckBox.TabIndex = 1
        Me.EditCampaignsCheckBox.Text = "Allow edits"
        Me.EditCampaignsCheckBox.UseVisualStyleBackColor = True
        '
        'CampaignLabel
        '
        Me.CampaignLabel.AutoSize = True
        Me.CampaignLabel.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CampaignLabel.Location = New System.Drawing.Point(4, 7)
        Me.CampaignLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.CampaignLabel.Name = "CampaignLabel"
        Me.CampaignLabel.Size = New System.Drawing.Size(72, 19)
        Me.CampaignLabel.TabIndex = 0
        Me.CampaignLabel.Text = "Surveys"
        '
        'CampaignTabControl
        '
        Me.CampaignTabControl.Controls.Add(Me.DataEditingTabPage)
        Me.CampaignTabControl.Controls.Add(Me.ResultsTabPage)
        Me.CampaignTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CampaignTabControl.Location = New System.Drawing.Point(0, 31)
        Me.CampaignTabControl.Margin = New System.Windows.Forms.Padding(2)
        Me.CampaignTabControl.Name = "CampaignTabControl"
        Me.CampaignTabControl.SelectedIndex = 0
        Me.CampaignTabControl.Size = New System.Drawing.Size(952, 649)
        Me.CampaignTabControl.TabIndex = 4
        '
        'DataEditingTabPage
        '
        Me.DataEditingTabPage.Controls.Add(Me.SurveyFlightsSplitContainer)
        Me.DataEditingTabPage.Location = New System.Drawing.Point(4, 22)
        Me.DataEditingTabPage.Margin = New System.Windows.Forms.Padding(2)
        Me.DataEditingTabPage.Name = "DataEditingTabPage"
        Me.DataEditingTabPage.Padding = New System.Windows.Forms.Padding(2)
        Me.DataEditingTabPage.Size = New System.Drawing.Size(944, 623)
        Me.DataEditingTabPage.TabIndex = 1
        Me.DataEditingTabPage.Text = "Data editing"
        Me.DataEditingTabPage.UseVisualStyleBackColor = True
        '
        'SurveyFlightsSplitContainer
        '
        Me.SurveyFlightsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SurveyFlightsSplitContainer.Location = New System.Drawing.Point(2, 2)
        Me.SurveyFlightsSplitContainer.Margin = New System.Windows.Forms.Padding(2)
        Me.SurveyFlightsSplitContainer.Name = "SurveyFlightsSplitContainer"
        Me.SurveyFlightsSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SurveyFlightsSplitContainer.Panel1
        '
        Me.SurveyFlightsSplitContainer.Panel1.Controls.Add(Me.SurveyFlightsGridEX)
        Me.SurveyFlightsSplitContainer.Panel1.Controls.Add(Me.Panel2)
        '
        'SurveyFlightsSplitContainer.Panel2
        '
        Me.SurveyFlightsSplitContainer.Panel2.Controls.Add(Me.SurveyDataTabControl)
        Me.SurveyFlightsSplitContainer.Panel2.Controls.Add(Me.DataPanel)
        Me.SurveyFlightsSplitContainer.Size = New System.Drawing.Size(940, 619)
        Me.SurveyFlightsSplitContainer.SplitterDistance = 193
        Me.SurveyFlightsSplitContainer.SplitterWidth = 3
        Me.SurveyFlightsSplitContainer.TabIndex = 5
        '
        'SurveyFlightsGridEX
        '
        Me.SurveyFlightsGridEX.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.SurveyFlightsGridEX.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.SurveyFlightsGridEX.AlternatingColors = True
        Me.SurveyFlightsGridEX.AutoEdit = True
        Me.SurveyFlightsGridEX.DataSource = Me.SurveyFlightsBindingSource
        SurveyFlightsGridEX_DesignTimeLayout.LayoutString = resources.GetString("SurveyFlightsGridEX_DesignTimeLayout.LayoutString")
        Me.SurveyFlightsGridEX.DesignTimeLayout = SurveyFlightsGridEX_DesignTimeLayout
        Me.SurveyFlightsGridEX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SurveyFlightsGridEX.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.SurveyFlightsGridEX.GroupByBoxVisible = False
        Me.SurveyFlightsGridEX.Location = New System.Drawing.Point(0, 31)
        Me.SurveyFlightsGridEX.Margin = New System.Windows.Forms.Padding(2)
        Me.SurveyFlightsGridEX.Name = "SurveyFlightsGridEX"
        Me.SurveyFlightsGridEX.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.SurveyFlightsGridEX.RecordNavigator = True
        Me.SurveyFlightsGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[Default]
        Me.SurveyFlightsGridEX.Size = New System.Drawing.Size(940, 162)
        Me.SurveyFlightsGridEX.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(940, 31)
        Me.Panel2.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 7)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Flights"
        '
        'DataPanel
        '
        Me.DataPanel.Controls.Add(Me.FlightContextLabel)
        Me.DataPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.DataPanel.Location = New System.Drawing.Point(0, 0)
        Me.DataPanel.Margin = New System.Windows.Forms.Padding(2)
        Me.DataPanel.Name = "DataPanel"
        Me.DataPanel.Size = New System.Drawing.Size(940, 31)
        Me.DataPanel.TabIndex = 5
        '
        'FlightContextLabel
        '
        Me.FlightContextLabel.AutoSize = True
        Me.FlightContextLabel.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FlightContextLabel.Location = New System.Drawing.Point(4, 7)
        Me.FlightContextLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.FlightContextLabel.Name = "FlightContextLabel"
        Me.FlightContextLabel.Size = New System.Drawing.Size(76, 19)
        Me.FlightContextLabel.TabIndex = 0
        Me.FlightContextLabel.Text = "Caribou:"
        '
        'ResultsTabPage
        '
        Me.ResultsTabPage.Controls.Add(Me.ResultsDataGridView)
        Me.ResultsTabPage.Controls.Add(Me.ResultsPanel)
        Me.ResultsTabPage.Controls.Add(Me.ResultsToolStrip)
        Me.ResultsTabPage.Location = New System.Drawing.Point(4, 22)
        Me.ResultsTabPage.Margin = New System.Windows.Forms.Padding(2)
        Me.ResultsTabPage.Name = "ResultsTabPage"
        Me.ResultsTabPage.Padding = New System.Windows.Forms.Padding(2)
        Me.ResultsTabPage.Size = New System.Drawing.Size(944, 623)
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
        Me.ResultsDataGridView.Location = New System.Drawing.Point(2, 37)
        Me.ResultsDataGridView.Margin = New System.Windows.Forms.Padding(2)
        Me.ResultsDataGridView.Name = "ResultsDataGridView"
        Me.ResultsDataGridView.ReadOnly = True
        Me.ResultsDataGridView.RowTemplate.Height = 24
        Me.ResultsDataGridView.Size = New System.Drawing.Size(940, 557)
        Me.ResultsDataGridView.TabIndex = 0
        '
        'ResultsPanel
        '
        Me.ResultsPanel.Controls.Add(Me.ResultsLabel)
        Me.ResultsPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.ResultsPanel.Location = New System.Drawing.Point(2, 2)
        Me.ResultsPanel.Margin = New System.Windows.Forms.Padding(2)
        Me.ResultsPanel.Name = "ResultsPanel"
        Me.ResultsPanel.Size = New System.Drawing.Size(940, 35)
        Me.ResultsPanel.TabIndex = 6
        '
        'ResultsLabel
        '
        Me.ResultsLabel.AutoSize = True
        Me.ResultsLabel.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResultsLabel.Location = New System.Drawing.Point(9, 7)
        Me.ResultsLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.ResultsLabel.Name = "ResultsLabel"
        Me.ResultsLabel.Size = New System.Drawing.Size(143, 19)
        Me.ResultsLabel.TabIndex = 0
        Me.ResultsLabel.Text = "Campaign results"
        '
        'ResultsToolStrip
        '
        Me.ResultsToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ResultsToolStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ResultsToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DatabaseViewLabel, Me.DatabaseViewNameToolStripLabel, Me.ToolStripSeparator2, Me.RefreshResultsToolStripButton, Me.ToolStripSeparator1})
        Me.ResultsToolStrip.Location = New System.Drawing.Point(2, 594)
        Me.ResultsToolStrip.Name = "ResultsToolStrip"
        Me.ResultsToolStrip.Size = New System.Drawing.Size(940, 27)
        Me.ResultsToolStrip.TabIndex = 1
        Me.ResultsToolStrip.Text = "ToolStrip1"
        '
        'DatabaseViewLabel
        '
        Me.DatabaseViewLabel.Name = "DatabaseViewLabel"
        Me.DatabaseViewLabel.Size = New System.Drawing.Size(199, 24)
        Me.DatabaseViewLabel.Text = "Showing results from database view:"
        '
        'DatabaseViewNameToolStripLabel
        '
        Me.DatabaseViewNameToolStripLabel.Name = "DatabaseViewNameToolStripLabel"
        Me.DatabaseViewNameToolStripLabel.Size = New System.Drawing.Size(115, 24)
        Me.DatabaseViewNameToolStripLabel.Text = "Database view name"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 27)
        '
        'RefreshResultsToolStripButton
        '
        Me.RefreshResultsToolStripButton.Image = CType(resources.GetObject("RefreshResultsToolStripButton.Image"), System.Drawing.Image)
        Me.RefreshResultsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RefreshResultsToolStripButton.Name = "RefreshResultsToolStripButton"
        Me.RefreshResultsToolStripButton.Size = New System.Drawing.Size(149, 24)
        Me.RefreshResultsToolStripButton.Text = "Refresh from database"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 27)
        '
        'SurveysPanel
        '
        Me.SurveysPanel.Controls.Add(Me.CampaignHeaderLabel)
        Me.SurveysPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.SurveysPanel.Location = New System.Drawing.Point(0, 0)
        Me.SurveysPanel.Margin = New System.Windows.Forms.Padding(2)
        Me.SurveysPanel.Name = "SurveysPanel"
        Me.SurveysPanel.Size = New System.Drawing.Size(952, 31)
        Me.SurveysPanel.TabIndex = 4
        '
        'CampaignHeaderLabel
        '
        Me.CampaignHeaderLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CampaignHeaderLabel.AutoSize = True
        Me.CampaignHeaderLabel.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CampaignHeaderLabel.Location = New System.Drawing.Point(9, 7)
        Me.CampaignHeaderLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.CampaignHeaderLabel.Name = "CampaignHeaderLabel"
        Me.CampaignHeaderLabel.Size = New System.Drawing.Size(142, 19)
        Me.CampaignHeaderLabel.TabIndex = 0
        Me.CampaignHeaderLabel.Text = "CampaignHeader"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem, Me.DatabaseToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1184, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveChangesToDatabaseToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(71, 20)
        Me.SaveToolStripMenuItem.Text = "Functions"
        '
        'SaveChangesToDatabaseToolStripMenuItem
        '
        Me.SaveChangesToDatabaseToolStripMenuItem.Image = CType(resources.GetObject("SaveChangesToDatabaseToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SaveChangesToDatabaseToolStripMenuItem.Name = "SaveChangesToDatabaseToolStripMenuItem"
        Me.SaveChangesToDatabaseToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.SaveChangesToDatabaseToolStripMenuItem.Text = "Save changes to database"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'DatabaseToolStripMenuItem
        '
        Me.DatabaseToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditDatabaseConnectionToolStripMenuItem})
        Me.DatabaseToolStripMenuItem.Name = "DatabaseToolStripMenuItem"
        Me.DatabaseToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.DatabaseToolStripMenuItem.Text = "Database"
        '
        'EditDatabaseConnectionToolStripMenuItem
        '
        Me.EditDatabaseConnectionToolStripMenuItem.Image = CType(resources.GetObject("EditDatabaseConnectionToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EditDatabaseConnectionToolStripMenuItem.Name = "EditDatabaseConnectionToolStripMenuItem"
        Me.EditDatabaseConnectionToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.EditDatabaseConnectionToolStripMenuItem.Text = "Edit database connection..."
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'MainToolStrip
        '
        Me.MainToolStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveDatasetToolStripButton, Me.ToolStripSeparator3, Me.RefreshDataToolStripButton})
        Me.MainToolStrip.Location = New System.Drawing.Point(0, 24)
        Me.MainToolStrip.Name = "MainToolStrip"
        Me.MainToolStrip.Size = New System.Drawing.Size(1184, 27)
        Me.MainToolStrip.TabIndex = 5
        Me.MainToolStrip.Text = "Tools"
        '
        'SaveDatasetToolStripButton
        '
        Me.SaveDatasetToolStripButton.Image = CType(resources.GetObject("SaveDatasetToolStripButton.Image"), System.Drawing.Image)
        Me.SaveDatasetToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveDatasetToolStripButton.Name = "SaveDatasetToolStripButton"
        Me.SaveDatasetToolStripButton.Size = New System.Drawing.Size(119, 24)
        Me.SaveDatasetToolStripButton.Text = "Save to database"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 27)
        '
        'RefreshDataToolStripButton
        '
        Me.RefreshDataToolStripButton.Image = CType(resources.GetObject("RefreshDataToolStripButton.Image"), System.Drawing.Image)
        Me.RefreshDataToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RefreshDataToolStripButton.Name = "RefreshDataToolStripButton"
        Me.RefreshDataToolStripButton.Size = New System.Drawing.Size(96, 24)
        Me.RefreshDataToolStripButton.Text = "Refresh data"
        '
        'MainTabControl
        '
        Me.MainTabControl.Controls.Add(Me.SurveysTabPage)
        Me.MainTabControl.Controls.Add(Me.CaribouTabPage)
        Me.MainTabControl.Controls.Add(Me.ResultsTabPage2)
        Me.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainTabControl.Location = New System.Drawing.Point(0, 51)
        Me.MainTabControl.Margin = New System.Windows.Forms.Padding(2)
        Me.MainTabControl.Name = "MainTabControl"
        Me.MainTabControl.SelectedIndex = 0
        Me.MainTabControl.Size = New System.Drawing.Size(1184, 710)
        Me.MainTabControl.TabIndex = 6
        '
        'SurveysTabPage
        '
        Me.SurveysTabPage.Controls.Add(Me.CampaignsSplitContainer)
        Me.SurveysTabPage.Location = New System.Drawing.Point(4, 22)
        Me.SurveysTabPage.Margin = New System.Windows.Forms.Padding(2)
        Me.SurveysTabPage.Name = "SurveysTabPage"
        Me.SurveysTabPage.Padding = New System.Windows.Forms.Padding(2)
        Me.SurveysTabPage.Size = New System.Drawing.Size(1176, 684)
        Me.SurveysTabPage.TabIndex = 0
        Me.SurveysTabPage.Text = "Surveys"
        Me.SurveysTabPage.UseVisualStyleBackColor = True
        '
        'CaribouTabPage
        '
        Me.CaribouTabPage.AutoScroll = True
        Me.CaribouTabPage.Controls.Add(Me.AnimalsSplitContainer)
        Me.CaribouTabPage.Location = New System.Drawing.Point(4, 22)
        Me.CaribouTabPage.Margin = New System.Windows.Forms.Padding(2)
        Me.CaribouTabPage.Name = "CaribouTabPage"
        Me.CaribouTabPage.Padding = New System.Windows.Forms.Padding(2)
        Me.CaribouTabPage.Size = New System.Drawing.Size(1176, 684)
        Me.CaribouTabPage.TabIndex = 1
        Me.CaribouTabPage.Text = "Caribou"
        Me.CaribouTabPage.UseVisualStyleBackColor = True
        '
        'AnimalsSplitContainer
        '
        Me.AnimalsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AnimalsSplitContainer.Location = New System.Drawing.Point(2, 2)
        Me.AnimalsSplitContainer.Name = "AnimalsSplitContainer"
        '
        'AnimalsSplitContainer.Panel1
        '
        Me.AnimalsSplitContainer.Panel1.Controls.Add(Me.AnimalsDataGridView)
        '
        'AnimalsSplitContainer.Panel2
        '
        Me.AnimalsSplitContainer.Panel2.Controls.Add(Me.CollarDeploymentsDataGridView)
        Me.AnimalsSplitContainer.Size = New System.Drawing.Size(1172, 680)
        Me.AnimalsSplitContainer.SplitterDistance = 654
        Me.AnimalsSplitContainer.TabIndex = 2
        '
        'AnimalsDataGridView
        '
        Me.AnimalsDataGridView.AllowUserToAddRows = False
        Me.AnimalsDataGridView.AllowUserToDeleteRows = False
        Me.AnimalsDataGridView.AllowUserToOrderColumns = True
        Me.AnimalsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.AnimalsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AnimalsDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.AnimalsDataGridView.Name = "AnimalsDataGridView"
        Me.AnimalsDataGridView.ReadOnly = True
        Me.AnimalsDataGridView.Size = New System.Drawing.Size(654, 680)
        Me.AnimalsDataGridView.TabIndex = 0
        '
        'CollarDeploymentsDataGridView
        '
        Me.CollarDeploymentsDataGridView.AllowUserToAddRows = False
        Me.CollarDeploymentsDataGridView.AllowUserToDeleteRows = False
        Me.CollarDeploymentsDataGridView.AllowUserToOrderColumns = True
        Me.CollarDeploymentsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.CollarDeploymentsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CollarDeploymentsDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.CollarDeploymentsDataGridView.Name = "CollarDeploymentsDataGridView"
        Me.CollarDeploymentsDataGridView.ReadOnly = True
        Me.CollarDeploymentsDataGridView.Size = New System.Drawing.Size(514, 680)
        Me.CollarDeploymentsDataGridView.TabIndex = 1
        '
        'ResultsTabPage2
        '
        Me.ResultsTabPage2.Controls.Add(Me.SurveyResultsDataGridView)
        Me.ResultsTabPage2.Controls.Add(Me.SurveyResultsBindingNavigator)
        Me.ResultsTabPage2.Controls.Add(Me.SurveyResultsToolStrip)
        Me.ResultsTabPage2.Location = New System.Drawing.Point(4, 22)
        Me.ResultsTabPage2.Name = "ResultsTabPage2"
        Me.ResultsTabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.ResultsTabPage2.Size = New System.Drawing.Size(1176, 684)
        Me.ResultsTabPage2.TabIndex = 2
        Me.ResultsTabPage2.Text = "Results"
        Me.ResultsTabPage2.UseVisualStyleBackColor = True
        '
        'SurveyResultsDataGridView
        '
        Me.SurveyResultsDataGridView.AllowUserToAddRows = False
        Me.SurveyResultsDataGridView.AllowUserToDeleteRows = False
        Me.SurveyResultsDataGridView.AllowUserToOrderColumns = True
        Me.SurveyResultsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.SurveyResultsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SurveyResultsDataGridView.Location = New System.Drawing.Point(3, 28)
        Me.SurveyResultsDataGridView.Name = "SurveyResultsDataGridView"
        Me.SurveyResultsDataGridView.ReadOnly = True
        Me.SurveyResultsDataGridView.Size = New System.Drawing.Size(1170, 628)
        Me.SurveyResultsDataGridView.TabIndex = 0
        '
        'SurveyResultsBindingNavigator
        '
        Me.SurveyResultsBindingNavigator.AddNewItem = Nothing
        Me.SurveyResultsBindingNavigator.BindingSource = Me.SurveyResultsBindingSource
        Me.SurveyResultsBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.SurveyResultsBindingNavigator.DeleteItem = Nothing
        Me.SurveyResultsBindingNavigator.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SurveyResultsBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.ExportResultsToCSVToolStripButton})
        Me.SurveyResultsBindingNavigator.Location = New System.Drawing.Point(3, 656)
        Me.SurveyResultsBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.SurveyResultsBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.SurveyResultsBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.SurveyResultsBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.SurveyResultsBindingNavigator.Name = "SurveyResultsBindingNavigator"
        Me.SurveyResultsBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.SurveyResultsBindingNavigator.Size = New System.Drawing.Size(1170, 25)
        Me.SurveyResultsBindingNavigator.TabIndex = 2
        Me.SurveyResultsBindingNavigator.Text = "BindingNavigator1"
        '
        'SurveyResultsBindingSource
        '
        Me.SurveyResultsBindingSource.AllowNew = False
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ExportResultsToCSVToolStripButton
        '
        Me.ExportResultsToCSVToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ExportResultsToCSVToolStripButton.Image = CType(resources.GetObject("ExportResultsToCSVToolStripButton.Image"), System.Drawing.Image)
        Me.ExportResultsToCSVToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ExportResultsToCSVToolStripButton.Name = "ExportResultsToCSVToolStripButton"
        Me.ExportResultsToCSVToolStripButton.Size = New System.Drawing.Size(79, 22)
        Me.ExportResultsToCSVToolStripButton.Text = "Export data..."
        '
        'SurveyResultsToolStrip
        '
        Me.SurveyResultsToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectSurveyTypeToolStripLabel, Me.SelectSurveyTypeToolStripComboBox, Me.ToolStripSeparator10, Me.RefreshToolStripButton})
        Me.SurveyResultsToolStrip.Location = New System.Drawing.Point(3, 3)
        Me.SurveyResultsToolStrip.Name = "SurveyResultsToolStrip"
        Me.SurveyResultsToolStrip.Size = New System.Drawing.Size(1170, 25)
        Me.SurveyResultsToolStrip.TabIndex = 1
        Me.SurveyResultsToolStrip.Text = "ToolStrip1"
        '
        'SelectSurveyTypeToolStripLabel
        '
        Me.SelectSurveyTypeToolStripLabel.Name = "SelectSurveyTypeToolStripLabel"
        Me.SelectSurveyTypeToolStripLabel.Size = New System.Drawing.Size(104, 22)
        Me.SelectSurveyTypeToolStripLabel.Text = "Select survey type:"
        '
        'SelectSurveyTypeToolStripComboBox
        '
        Me.SelectSurveyTypeToolStripComboBox.Items.AddRange(New Object() {"", "Composition count", "Population", "Radiotracking"})
        Me.SelectSurveyTypeToolStripComboBox.Name = "SelectSurveyTypeToolStripComboBox"
        Me.SelectSurveyTypeToolStripComboBox.Size = New System.Drawing.Size(200, 25)
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 25)
        '
        'RefreshToolStripButton
        '
        Me.RefreshToolStripButton.Image = CType(resources.GetObject("RefreshToolStripButton.Image"), System.Drawing.Image)
        Me.RefreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RefreshToolStripButton.Name = "RefreshToolStripButton"
        Me.RefreshToolStripButton.Size = New System.Drawing.Size(145, 22)
        Me.RefreshToolStripButton.Text = "Refresh from database"
        '
        'CapturesBindingSource
        '
        Me.CapturesBindingSource.DataMember = "FK_Captures_Caribou"
        Me.CapturesBindingSource.DataSource = Me.CaribouBindingSource
        '
        'CaribouBindingSource
        '
        Me.CaribouBindingSource.DataMember = "Caribou"
        Me.CaribouBindingSource.DataSource = Me.WRST_CaribouDataSet
        '
        'XrefRadiotrackingCaribouBindingSource
        '
        Me.XrefRadiotrackingCaribouBindingSource.DataMember = "FK_xrefRadiotrackingCaribou_Caribou"
        Me.XrefRadiotrackingCaribouBindingSource.DataSource = Me.CaribouBindingSource
        '
        'HelpProvider
        '
        Me.HelpProvider.HelpNamespace = "C:\Work\Code\WRST_CaribouWindowsForms\WRST_Caribou\WRST_Caribou\help\WRST Caribou" &
    " Database Application.chm"
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
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 761)
        Me.Controls.Add(Me.MainTabControl)
        Me.Controls.Add(Me.MainToolStrip)
        Me.Controls.Add(Me.MenuStrip1)
        Me.HelpButton = True
        Me.HelpProvider.SetHelpKeyword(Me, "Introduction")
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Form1"
        Me.HelpProvider.SetShowHelp(Me, True)
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
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.DataPanel.ResumeLayout(False)
        Me.DataPanel.PerformLayout()
        Me.ResultsTabPage.ResumeLayout(False)
        Me.ResultsTabPage.PerformLayout()
        CType(Me.ResultsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResultsPanel.ResumeLayout(False)
        Me.ResultsPanel.PerformLayout()
        Me.ResultsToolStrip.ResumeLayout(False)
        Me.ResultsToolStrip.PerformLayout()
        Me.SurveysPanel.ResumeLayout(False)
        Me.SurveysPanel.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.MainToolStrip.ResumeLayout(False)
        Me.MainToolStrip.PerformLayout()
        Me.MainTabControl.ResumeLayout(False)
        Me.SurveysTabPage.ResumeLayout(False)
        Me.CaribouTabPage.ResumeLayout(False)
        Me.AnimalsSplitContainer.Panel1.ResumeLayout(False)
        Me.AnimalsSplitContainer.Panel2.ResumeLayout(False)
        CType(Me.AnimalsSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AnimalsSplitContainer.ResumeLayout(False)
        CType(Me.AnimalsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CollarDeploymentsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResultsTabPage2.ResumeLayout(False)
        Me.ResultsTabPage2.PerformLayout()
        CType(Me.SurveyResultsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SurveyResultsBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SurveyResultsBindingNavigator.ResumeLayout(False)
        Me.SurveyResultsBindingNavigator.PerformLayout()
        CType(Me.SurveyResultsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SurveyResultsToolStrip.ResumeLayout(False)
        Me.SurveyResultsToolStrip.PerformLayout()
        CType(Me.CapturesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CaribouBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrefRadiotrackingCaribouBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents CapturesBindingSource As BindingSource
    Friend WithEvents CapturesTableAdapter As WRST_CaribouDataSetTableAdapters.CapturesTableAdapter
    Friend WithEvents XrefRadiotrackingCaribouBindingSource As BindingSource
    Friend WithEvents XrefRadiotrackingCaribouTableAdapter As WRST_CaribouDataSetTableAdapters.xrefRadiotrackingCaribouTableAdapter
    Friend WithEvents CompCountToolStrip As ToolStrip
    Friend WithEvents PopulationToolStrip As ToolStrip
    Friend WithEvents ImportPopulationWaypointsToolStripButton As ToolStripButton
    Friend WithEvents PopulationSurveySplitContainer As SplitContainer
    Friend WithEvents ImportCompCountWaypointsToolStripButton As ToolStripButton
    Friend WithEvents CampaignLabel As Label
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
    Friend WithEvents ResultsToolStrip As ToolStrip
    Friend WithEvents RefreshResultsToolStripButton As ToolStripButton
    Friend WithEvents DatabaseViewLabel As ToolStripLabel
    Friend WithEvents DatabaseViewNameToolStripLabel As ToolStripLabel
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents SurveysPanel As Panel
    Friend WithEvents CampaignHeaderLabel As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ResultsPanel As Panel
    Friend WithEvents ResultsLabel As Label
    Friend WithEvents HelpProvider As HelpProvider
    Friend WithEvents ImportCompCountXYFromFileToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents RefreshDataToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ImportPopulationSurveyWaypointsFromFileToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents ImportRadiotrackingWaypointsFromFileToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents ResultsTabPage2 As TabPage
    Friend WithEvents SurveyResultsDataGridView As DataGridView
    Friend WithEvents SurveyResultsToolStrip As ToolStrip
    Friend WithEvents SelectSurveyTypeToolStripLabel As ToolStripLabel
    Friend WithEvents SelectSurveyTypeToolStripComboBox As ToolStripComboBox
    Friend WithEvents SurveyResultsBindingNavigator As BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As ToolStripSeparator
    Friend WithEvents ExportResultsToCSVToolStripButton As ToolStripButton
    Friend WithEvents SurveyResultsBindingSource As BindingSource
    Friend WithEvents ToolStripSeparator10 As ToolStripSeparator
    Friend WithEvents RefreshToolStripButton As ToolStripButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents AnimalsDataGridView As DataGridView
    Friend WithEvents CollarDeploymentsDataGridView As DataGridView
    Friend WithEvents AnimalsSplitContainer As SplitContainer
    Friend WithEvents EditCampaignsCheckBox As CheckBox
End Class
