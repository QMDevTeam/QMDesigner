<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExpresionEditor
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
        Me.txtExpresion = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.cmdOk = New DevComponents.DotNetBar.ButtonX
        Me.cmdCancel = New DevComponents.DotNetBar.ButtonX
        Me.barOperators = New DevComponents.DotNetBar.Bar
        Me.ItemContainerAritmeticOperators = New DevComponents.DotNetBar.ItemContainer
        Me.cmdAdd = New DevComponents.DotNetBar.ButtonItem
        Me.cmdSubstract = New DevComponents.DotNetBar.ButtonItem
        Me.cmdMultiply = New DevComponents.DotNetBar.ButtonItem
        Me.cmdDivide = New DevComponents.DotNetBar.ButtonItem
        Me.ItemContainerRelationalOperators = New DevComponents.DotNetBar.ItemContainer
        Me.cmdEquals = New DevComponents.DotNetBar.ButtonItem
        Me.cmdLowerThan = New DevComponents.DotNetBar.ButtonItem
        Me.cmdGreaterThan = New DevComponents.DotNetBar.ButtonItem
        Me.cmdDistinct = New DevComponents.DotNetBar.ButtonItem
        Me.ItemContainer1 = New DevComponents.DotNetBar.ItemContainer
        Me.cmdAnd = New DevComponents.DotNetBar.ButtonItem
        Me.cmdOr = New DevComponents.DotNetBar.ButtonItem
        Me.cmdNot = New DevComponents.DotNetBar.ButtonItem
        Me.ItemContainerPharentesis = New DevComponents.DotNetBar.ItemContainer
        Me.cmdOpenarenthesis = New DevComponents.DotNetBar.ButtonItem
        Me.cmdClosingParenthesis = New DevComponents.DotNetBar.ButtonItem
        Me.cmdParenthesis = New DevComponents.DotNetBar.ButtonItem
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx
        Me.pgdVariable = New DevComponents.DotNetBar.AdvPropertyGrid
        Me.ExpandableSplitter2 = New DevComponents.DotNetBar.ExpandableSplitter
        Me.PanelVariables = New DevComponents.DotNetBar.PanelEx
        Me.treVariables = New DevComponents.AdvTree.AdvTree
        Me.Node2 = New DevComponents.AdvTree.Node
        Me.NodeConnector2 = New DevComponents.AdvTree.NodeConnector
        Me.ElementStyle2 = New DevComponents.DotNetBar.ElementStyle
        Me.txtSearchVariables = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.ExpandableSplitter1 = New DevComponents.DotNetBar.ExpandableSplitter
        Me.PanelContainers = New DevComponents.DotNetBar.PanelEx
        Me.treContainers = New DevComponents.AdvTree.AdvTree
        Me.Node1 = New DevComponents.AdvTree.Node
        Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle
        Me.txtSearchContainers = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.PanelExpresion = New DevComponents.DotNetBar.PanelEx
        Me.cmdCheckExpresion = New DevComponents.DotNetBar.ButtonX
        Me.GalleryContainer1 = New DevComponents.DotNetBar.GalleryContainer
        Me.GalleryContainer2 = New DevComponents.DotNetBar.GalleryContainer
        CType(Me.barOperators, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx1.SuspendLayout()
        CType(Me.pgdVariable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelVariables.SuspendLayout()
        CType(Me.treVariables, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelContainers.SuspendLayout()
        CType(Me.treContainers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelExpresion.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtExpresion
        '
        '
        '
        '
        Me.txtExpresion.Border.Class = ""
        Me.txtExpresion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtExpresion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtExpresion.Location = New System.Drawing.Point(0, 0)
        Me.txtExpresion.Multiline = True
        Me.txtExpresion.Name = "txtExpresion"
        Me.txtExpresion.Size = New System.Drawing.Size(454, 55)
        Me.txtExpresion.TabIndex = 0
        '
        'cmdOk
        '
        Me.cmdOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdOk.Location = New System.Drawing.Point(472, 8)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmdOk.TabIndex = 1
        Me.cmdOk.Text = "Ok"
        '
        'cmdCancel
        '
        Me.cmdCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdCancel.Location = New System.Drawing.Point(472, 37)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "Cancel"
        '
        'barOperators
        '
        Me.barOperators.AccessibleDescription = "Operators (barOperators)"
        Me.barOperators.AccessibleName = "Operators"
        Me.barOperators.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar
        Me.barOperators.AntiAlias = True
        Me.barOperators.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barOperators.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerAritmeticOperators, Me.ItemContainerRelationalOperators, Me.ItemContainer1, Me.ItemContainerPharentesis})
        Me.barOperators.Location = New System.Drawing.Point(0, 55)
        Me.barOperators.Name = "barOperators"
        Me.barOperators.Size = New System.Drawing.Size(454, 25)
        Me.barOperators.Stretch = True
        Me.barOperators.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.barOperators.TabIndex = 3
        Me.barOperators.TabStop = False
        Me.barOperators.Text = "Operators"
        '
        'ItemContainerAritmeticOperators
        '
        '
        '
        '
        Me.ItemContainerAritmeticOperators.BackgroundStyle.Class = ""
        Me.ItemContainerAritmeticOperators.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainerAritmeticOperators.Name = "ItemContainerAritmeticOperators"
        Me.ItemContainerAritmeticOperators.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.cmdAdd, Me.cmdSubstract, Me.cmdMultiply, Me.cmdDivide})
        '
        'cmdAdd
        '
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Text = "+"
        '
        'cmdSubstract
        '
        Me.cmdSubstract.Name = "cmdSubstract"
        Me.cmdSubstract.Text = "-"
        '
        'cmdMultiply
        '
        Me.cmdMultiply.Name = "cmdMultiply"
        Me.cmdMultiply.Text = "*"
        '
        'cmdDivide
        '
        Me.cmdDivide.Name = "cmdDivide"
        Me.cmdDivide.Text = "/"
        '
        'ItemContainerRelationalOperators
        '
        '
        '
        '
        Me.ItemContainerRelationalOperators.BackgroundStyle.Class = ""
        Me.ItemContainerRelationalOperators.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainerRelationalOperators.Name = "ItemContainerRelationalOperators"
        Me.ItemContainerRelationalOperators.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.cmdEquals, Me.cmdLowerThan, Me.cmdGreaterThan, Me.cmdDistinct})
        '
        'cmdEquals
        '
        Me.cmdEquals.Name = "cmdEquals"
        Me.cmdEquals.Text = "="
        '
        'cmdLowerThan
        '
        Me.cmdLowerThan.Name = "cmdLowerThan"
        Me.cmdLowerThan.Text = "<"
        '
        'cmdGreaterThan
        '
        Me.cmdGreaterThan.Name = "cmdGreaterThan"
        Me.cmdGreaterThan.Text = ">"
        '
        'cmdDistinct
        '
        Me.cmdDistinct.Name = "cmdDistinct"
        Me.cmdDistinct.Text = "<>"
        '
        'ItemContainer1
        '
        '
        '
        '
        Me.ItemContainer1.BackgroundStyle.Class = ""
        Me.ItemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer1.Name = "ItemContainer1"
        Me.ItemContainer1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.cmdAnd, Me.cmdOr, Me.cmdNot})
        '
        'cmdAnd
        '
        Me.cmdAnd.Name = "cmdAnd"
        Me.cmdAnd.Text = "And"
        '
        'cmdOr
        '
        Me.cmdOr.Name = "cmdOr"
        Me.cmdOr.Text = "Or"
        '
        'cmdNot
        '
        Me.cmdNot.Name = "cmdNot"
        Me.cmdNot.Text = "Not"
        '
        'ItemContainerPharentesis
        '
        '
        '
        '
        Me.ItemContainerPharentesis.BackgroundStyle.Class = ""
        Me.ItemContainerPharentesis.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainerPharentesis.Name = "ItemContainerPharentesis"
        Me.ItemContainerPharentesis.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.cmdOpenarenthesis, Me.cmdClosingParenthesis, Me.cmdParenthesis})
        '
        'cmdOpenarenthesis
        '
        Me.cmdOpenarenthesis.Name = "cmdOpenarenthesis"
        Me.cmdOpenarenthesis.Text = "("
        '
        'cmdClosingParenthesis
        '
        Me.cmdClosingParenthesis.Name = "cmdClosingParenthesis"
        Me.cmdClosingParenthesis.Text = ")"
        '
        'cmdParenthesis
        '
        Me.cmdParenthesis.Name = "cmdParenthesis"
        Me.cmdParenthesis.Text = "()"
        '
        'PanelEx1
        '
        Me.PanelEx1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.pgdVariable)
        Me.PanelEx1.Controls.Add(Me.ExpandableSplitter2)
        Me.PanelEx1.Controls.Add(Me.PanelVariables)
        Me.PanelEx1.Controls.Add(Me.ExpandableSplitter1)
        Me.PanelEx1.Controls.Add(Me.PanelContainers)
        Me.PanelEx1.Location = New System.Drawing.Point(7, 92)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(540, 215)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 4
        Me.PanelEx1.Text = "PanelEx1"
        '
        'pgdVariable
        '
        Me.pgdVariable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pgdVariable.GridLinesColor = System.Drawing.Color.WhiteSmoke
        Me.pgdVariable.Location = New System.Drawing.Point(332, 0)
        Me.pgdVariable.Name = "pgdVariable"
        Me.pgdVariable.Size = New System.Drawing.Size(208, 215)
        Me.pgdVariable.TabIndex = 4
        Me.pgdVariable.Text = "AdvPropertyGrid1"
        '
        'ExpandableSplitter2
        '
        Me.ExpandableSplitter2.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ExpandableSplitter2.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter2.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandableSplitter2.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ExpandableSplitter2.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter2.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ExpandableSplitter2.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandableSplitter2.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ExpandableSplitter2.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandableSplitter2.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ExpandableSplitter2.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.ExpandableSplitter2.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.ExpandableSplitter2.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.ExpandableSplitter2.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
        Me.ExpandableSplitter2.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
        Me.ExpandableSplitter2.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ExpandableSplitter2.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter2.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ExpandableSplitter2.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandableSplitter2.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ExpandableSplitter2.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter2.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ExpandableSplitter2.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.ExpandableSplitter2.Location = New System.Drawing.Point(326, 0)
        Me.ExpandableSplitter2.Name = "ExpandableSplitter2"
        Me.ExpandableSplitter2.Size = New System.Drawing.Size(6, 215)
        Me.ExpandableSplitter2.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
        Me.ExpandableSplitter2.TabIndex = 3
        Me.ExpandableSplitter2.TabStop = False
        '
        'PanelVariables
        '
        Me.PanelVariables.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelVariables.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelVariables.Controls.Add(Me.treVariables)
        Me.PanelVariables.Controls.Add(Me.txtSearchVariables)
        Me.PanelVariables.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelVariables.Location = New System.Drawing.Point(155, 0)
        Me.PanelVariables.Name = "PanelVariables"
        Me.PanelVariables.Size = New System.Drawing.Size(171, 215)
        Me.PanelVariables.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelVariables.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelVariables.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelVariables.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelVariables.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelVariables.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelVariables.Style.GradientAngle = 90
        Me.PanelVariables.TabIndex = 2
        Me.PanelVariables.Text = "PanelEx3"
        '
        'treVariables
        '
        Me.treVariables.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
        Me.treVariables.AllowDrop = True
        Me.treVariables.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.treVariables.BackgroundStyle.Class = "TreeBorderKey"
        Me.treVariables.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.treVariables.Dock = System.Windows.Forms.DockStyle.Fill
        Me.treVariables.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.treVariables.Location = New System.Drawing.Point(0, 20)
        Me.treVariables.Name = "treVariables"
        Me.treVariables.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.Node2})
        Me.treVariables.NodesConnector = Me.NodeConnector2
        Me.treVariables.NodeStyle = Me.ElementStyle2
        Me.treVariables.PathSeparator = ";"
        Me.treVariables.Size = New System.Drawing.Size(171, 195)
        Me.treVariables.Styles.Add(Me.ElementStyle2)
        Me.treVariables.TabIndex = 1
        Me.treVariables.Text = "AdvTree2"
        '
        'Node2
        '
        Me.Node2.Expanded = True
        Me.Node2.Name = "Node2"
        Me.Node2.Text = "Node2"
        '
        'NodeConnector2
        '
        Me.NodeConnector2.LineColor = System.Drawing.SystemColors.ControlText
        '
        'ElementStyle2
        '
        Me.ElementStyle2.Class = ""
        Me.ElementStyle2.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle2.Name = "ElementStyle2"
        Me.ElementStyle2.TextColor = System.Drawing.SystemColors.ControlText
        '
        'txtSearchVariables
        '
        '
        '
        '
        Me.txtSearchVariables.Border.Class = "TextBoxBorder"
        Me.txtSearchVariables.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtSearchVariables.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtSearchVariables.Location = New System.Drawing.Point(0, 0)
        Me.txtSearchVariables.Name = "txtSearchVariables"
        Me.txtSearchVariables.Size = New System.Drawing.Size(171, 20)
        Me.txtSearchVariables.TabIndex = 0
        '
        'ExpandableSplitter1
        '
        Me.ExpandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ExpandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ExpandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter1.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ExpandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandableSplitter1.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ExpandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ExpandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.ExpandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.ExpandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.ExpandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
        Me.ExpandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
        Me.ExpandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ExpandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter1.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ExpandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ExpandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ExpandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.ExpandableSplitter1.Location = New System.Drawing.Point(149, 0)
        Me.ExpandableSplitter1.Name = "ExpandableSplitter1"
        Me.ExpandableSplitter1.Size = New System.Drawing.Size(6, 215)
        Me.ExpandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
        Me.ExpandableSplitter1.TabIndex = 1
        Me.ExpandableSplitter1.TabStop = False
        '
        'PanelContainers
        '
        Me.PanelContainers.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelContainers.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelContainers.Controls.Add(Me.treContainers)
        Me.PanelContainers.Controls.Add(Me.txtSearchContainers)
        Me.PanelContainers.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelContainers.Location = New System.Drawing.Point(0, 0)
        Me.PanelContainers.Name = "PanelContainers"
        Me.PanelContainers.Size = New System.Drawing.Size(149, 215)
        Me.PanelContainers.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelContainers.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelContainers.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelContainers.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelContainers.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelContainers.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelContainers.Style.GradientAngle = 90
        Me.PanelContainers.TabIndex = 0
        Me.PanelContainers.Text = "PanelEx2"
        '
        'treContainers
        '
        Me.treContainers.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
        Me.treContainers.AllowDrop = True
        Me.treContainers.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.treContainers.BackgroundStyle.Class = "TreeBorderKey"
        Me.treContainers.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.treContainers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.treContainers.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.treContainers.Location = New System.Drawing.Point(0, 20)
        Me.treContainers.Name = "treContainers"
        Me.treContainers.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.Node1})
        Me.treContainers.NodesConnector = Me.NodeConnector1
        Me.treContainers.NodeStyle = Me.ElementStyle1
        Me.treContainers.PathSeparator = ";"
        Me.treContainers.Size = New System.Drawing.Size(149, 195)
        Me.treContainers.Styles.Add(Me.ElementStyle1)
        Me.treContainers.TabIndex = 1
        Me.treContainers.Text = "AdvTree1"
        '
        'Node1
        '
        Me.Node1.Expanded = True
        Me.Node1.Name = "Node1"
        Me.Node1.Text = "Node1"
        '
        'NodeConnector1
        '
        Me.NodeConnector1.LineColor = System.Drawing.SystemColors.ControlText
        '
        'ElementStyle1
        '
        Me.ElementStyle1.Class = ""
        Me.ElementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle1.Name = "ElementStyle1"
        Me.ElementStyle1.TextColor = System.Drawing.SystemColors.ControlText
        '
        'txtSearchContainers
        '
        '
        '
        '
        Me.txtSearchContainers.Border.Class = "TextBoxBorder"
        Me.txtSearchContainers.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtSearchContainers.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtSearchContainers.Location = New System.Drawing.Point(0, 0)
        Me.txtSearchContainers.Name = "txtSearchContainers"
        Me.txtSearchContainers.Size = New System.Drawing.Size(149, 20)
        Me.txtSearchContainers.TabIndex = 0
        '
        'PanelExpresion
        '
        Me.PanelExpresion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelExpresion.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelExpresion.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelExpresion.Controls.Add(Me.txtExpresion)
        Me.PanelExpresion.Controls.Add(Me.barOperators)
        Me.PanelExpresion.Location = New System.Drawing.Point(7, 8)
        Me.PanelExpresion.Name = "PanelExpresion"
        Me.PanelExpresion.Size = New System.Drawing.Size(454, 80)
        Me.PanelExpresion.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelExpresion.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelExpresion.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelExpresion.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelExpresion.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelExpresion.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelExpresion.Style.GradientAngle = 90
        Me.PanelExpresion.TabIndex = 5
        Me.PanelExpresion.Text = "PanelEx2"
        '
        'cmdCheckExpresion
        '
        Me.cmdCheckExpresion.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdCheckExpresion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCheckExpresion.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdCheckExpresion.Location = New System.Drawing.Point(472, 66)
        Me.cmdCheckExpresion.Name = "cmdCheckExpresion"
        Me.cmdCheckExpresion.Size = New System.Drawing.Size(75, 23)
        Me.cmdCheckExpresion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmdCheckExpresion.TabIndex = 6
        Me.cmdCheckExpresion.Text = "Check"
        '
        'GalleryContainer1
        '
        '
        '
        '
        Me.GalleryContainer1.BackgroundStyle.Class = ""
        Me.GalleryContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GalleryContainer1.EnableGalleryPopup = False
        Me.GalleryContainer1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.GalleryContainer1.MinimumSize = New System.Drawing.Size(150, 200)
        Me.GalleryContainer1.MultiLine = False
        Me.GalleryContainer1.Name = "GalleryContainer1"
        Me.GalleryContainer1.PopupUsesStandardScrollbars = False
        '
        'GalleryContainer2
        '
        '
        '
        '
        Me.GalleryContainer2.BackgroundStyle.Class = ""
        Me.GalleryContainer2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GalleryContainer2.EnableGalleryPopup = False
        Me.GalleryContainer2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.GalleryContainer2.MinimumSize = New System.Drawing.Size(150, 200)
        Me.GalleryContainer2.MultiLine = False
        Me.GalleryContainer2.Name = "GalleryContainer2"
        Me.GalleryContainer2.PopupUsesStandardScrollbars = False
        '
        'ExpresionEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(559, 319)
        Me.Controls.Add(Me.cmdCheckExpresion)
        Me.Controls.Add(Me.PanelExpresion)
        Me.Controls.Add(Me.PanelEx1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Name = "ExpresionEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Expresion Editor"
        CType(Me.barOperators, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx1.ResumeLayout(False)
        CType(Me.pgdVariable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelVariables.ResumeLayout(False)
        CType(Me.treVariables, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelContainers.ResumeLayout(False)
        CType(Me.treContainers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelExpresion.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtExpresion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cmdOk As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmdCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents barOperators As DevComponents.DotNetBar.Bar
    Friend WithEvents ItemContainerAritmeticOperators As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents cmdAdd As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents cmdSubstract As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents cmdMultiply As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents cmdDivide As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ItemContainerRelationalOperators As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents cmdEquals As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents cmdLowerThan As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents cmdGreaterThan As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents cmdDistinct As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ItemContainer1 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents cmdAnd As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents cmdOr As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents cmdNot As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ItemContainerPharentesis As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents cmdOpenarenthesis As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents cmdClosingParenthesis As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents cmdParenthesis As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents PanelVariables As DevComponents.DotNetBar.PanelEx
    Friend WithEvents ExpandableSplitter1 As DevComponents.DotNetBar.ExpandableSplitter
    Friend WithEvents PanelContainers As DevComponents.DotNetBar.PanelEx
    Friend WithEvents txtSearchContainers As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ExpandableSplitter2 As DevComponents.DotNetBar.ExpandableSplitter
    Friend WithEvents treVariables As DevComponents.AdvTree.AdvTree
    Friend WithEvents Node2 As DevComponents.AdvTree.Node
    Friend WithEvents NodeConnector2 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle2 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents txtSearchVariables As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents treContainers As DevComponents.AdvTree.AdvTree
    Friend WithEvents Node1 As DevComponents.AdvTree.Node
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents pgdVariable As DevComponents.DotNetBar.AdvPropertyGrid
    Friend WithEvents PanelExpresion As DevComponents.DotNetBar.PanelEx
    Friend WithEvents cmdCheckExpresion As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GalleryContainer1 As DevComponents.DotNetBar.GalleryContainer
    Friend WithEvents GalleryContainer2 As DevComponents.DotNetBar.GalleryContainer
End Class
