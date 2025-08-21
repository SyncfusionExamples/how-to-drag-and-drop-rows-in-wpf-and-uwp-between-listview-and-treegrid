# How to drag and drop rows in wpf and uwp between listview and treegrid?
This example illustrates how to drag and drop rows in wpf and uwp between listview and treegrid.

## UWP Sample

```xaml
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="*" />
        <ColumnDefinition Width="*" />
    </Grid.ColumnDefinitions>

    <syncfusion:SfTreeGrid Name="TreeGrid"
                            Grid.Column="0"
                            AllowDraggingColumns="True"
                            AllowDraggingRows="True"
                            AllowEditing="False"
                            AllowResizingColumns="True"
                            AllowResizingHiddenColumns="True"
                            AllowSorting="False"
                            AutoGenerateColumns="True"
                            ChildPropertyName="Children"
                            EditTrigger="OnDoubleTap"
                            ItemsSource="{Binding PersonDetails}"
                            LiveNodeUpdateMode="AllowDataShaping"
                            NavigationMode="Cell"
                            RowIndentMode="Level"
                            SelectionMode="Single"
                            ShowRowHeader="True" />
    <ListView x:Name="listView"
                Grid.Column="1"
                DisplayMemberPath="FirstName"
                ItemsSource="{Binding PersonDetails1}" />
</Grid>
```

## WPF Sample

```xaml
<Grid>
    <Grid.ColumnDefinitions>
        <ColumnDefinition/>
        <ColumnDefinition/>
    </Grid.ColumnDefinitions>

    <Grid Grid.Column="0">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        <TextBlock Grid.Row="0" FontSize="25" Text="SfTreeGrid" HorizontalAlignment="Center"/>
        <syncfusion:SfTreeGrid Name="sfTreeGrid" Grid.Row="1" 
                            AutoExpandMode="RootNodesExpanded" 
                            AllowDraggingRows="True" 
                            AllowDrop="True" 
                            RowDragDropTemplate="{StaticResource customizedpopup}"
                            ChildPropertyName="ReportsTo"  
                            ShowRowHeader="True" 
                            ItemsSource="{Binding Employees}"
                            ParentPropertyName="ID"
                            SelfRelationRootValue="-1"/>
    </Grid>

    <Grid  Grid.Column="1">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        <TextBlock  Text="ListView" FontSize="25" HorizontalAlignment="Center"/>
        <ListView Grid.Row="1" Name="listView" Height="650"  
                ItemsSource="{Binding Employee}" Width="300"
                DisplayMemberPath="FirstName"  
                AllowDrop="True" ></ListView>
    </Grid>
</Grid>
```