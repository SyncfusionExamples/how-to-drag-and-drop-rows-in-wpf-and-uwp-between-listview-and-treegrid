
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;
using Syncfusion.UI.Xaml.TreeGrid;
using Syncfusion.UI.Xaml.TreeGrid.Helpers;
using Syncfusion.Data.Extensions;

namespace Drag_Drop_between_TreeGrid_and_ListView
{
    /// <summary>
    /// Describes the DragDropBehavior
    /// </summary>
   public class DragDropBehavior:Behavior<MainWindow>
   {
        /// <summary>
        /// Initialize the OnAttached method
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.Loaded += AssociatedObject_Loaded;
        }

        /// <summary>
        /// Denotes the Loaded event of this class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AssociatedObject.listView.PreviewMouseMove += ListView_PreviewMouseMove;
            this.AssociatedObject.listView.Drop += ListView_Drop;
            this.AssociatedObject.sfTreeGrid.RowDragDropController.Drop += RowDragDropController_Drop;
        }

        /// <summary>
        /// Descrides the Drop event of the RowDragDroController and handles the drop items from ListView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RowDragDropController_Drop(object sender, Syncfusion.UI.Xaml.TreeGrid.TreeGridRowDropEventArgs e)
        {
            if (e.IsFromOutSideSource)
            {
                var item = e.Data.GetData("ListViewRecords") as ObservableCollection<object>;
                var record = item[0] as EmployeeInfo;
                var dropPosition = e.DropPosition.ToString();
                var newItem = new EmployeeInfo();

                var rowIndex = AssociatedObject.sfTreeGrid.ResolveToRowIndex(e.TargetNode.Item);
                int nodeIndex = (int)rowIndex;
                if (dropPosition != "None" && rowIndex != -1)
                {
                    if (AssociatedObject.sfTreeGrid.View is TreeGridSelfRelationalView)
                    {
                        var treeNode = AssociatedObject.sfTreeGrid.GetNodeAtRowIndex(rowIndex);

                        if (treeNode == null)
                            return;
                        var data = treeNode.Item;
                        AssociatedObject.sfTreeGrid.SelectionController.SuspendUpdates();
                        var itemIndex = -1;

                        TreeNode parentNode = null;

                        if (dropPosition == "DropBelow" || dropPosition == "DropAbove")
                        {
                            parentNode = treeNode.ParentNode;

                            if (parentNode == null)
                                newItem = new EmployeeInfo() { FirstName = record.FirstName, LastName = record.LastName, ID = record.ID, Salary = record.Salary, Title = record.Title, ReportsTo = -1 };
                            else
                            {
                                var parentkey = parentNode.Item as EmployeeInfo;
                                newItem = new EmployeeInfo() { FirstName = record.FirstName, LastName = record.LastName, ID = record.ID, Salary = record.Salary, Title = record.Title, ReportsTo = parentkey.ID };
                            }
                        }

                        else if (dropPosition == "DropAsChild")
                        {

                            if (!treeNode.IsExpanded)
                                AssociatedObject.sfTreeGrid.ExpandNode(treeNode);
                            parentNode = treeNode;
                            var parentkey = parentNode.Item as EmployeeInfo;
                            newItem = new EmployeeInfo() { FirstName = record.FirstName, LastName = record.LastName, ID = record.ID, Salary = record.Salary, Title = record.Title, ReportsTo = parentkey.ID };

                        }
                        IList sourceCollection = null;

                        if (dropPosition == "DropBelow" || dropPosition == "DropAbove")
                        {

                            if (treeNode.ParentNode != null)
                            {

                                var collection = AssociatedObject.sfTreeGrid.View.GetPropertyAccessProvider().GetValue(treeNode.ParentNode.Item, AssociatedObject.sfTreeGrid.ChildPropertyName) as IEnumerable;

                                sourceCollection = GetSourceListCollection(collection);
                            }

                            else
                            {

                                sourceCollection = GetSourceListCollection(AssociatedObject.sfTreeGrid.View.SourceCollection);
                            }
                            itemIndex = sourceCollection.IndexOf(data);

                            if (dropPosition == "DropBelow")
                            {
                                itemIndex += 1;
                            }
                        }

                        else if (dropPosition == "DropAsChild")
                        {
                            var collection = AssociatedObject.sfTreeGrid.View.GetPropertyAccessProvider().GetValue(data, AssociatedObject.sfTreeGrid.ChildPropertyName) as IEnumerable;

                            sourceCollection = GetSourceListCollection(collection);

                            if (sourceCollection == null)
                            {
                                var list = data.GetType().GetProperty(AssociatedObject.sfTreeGrid.ChildPropertyName).PropertyType.CreateNew() as IList;

                                if (list != null)
                                {
                                    AssociatedObject.sfTreeGrid.View.GetPropertyAccessProvider().SetValue(treeNode.Item, AssociatedObject.sfTreeGrid.ChildPropertyName, list);
                                    sourceCollection = list;
                                }
                            }
                            itemIndex = sourceCollection.Count;
                        }
                        sourceCollection.Insert(itemIndex, newItem);
                        AssociatedObject.sfTreeGrid.SelectionController.ResumeUpdates();
                        (AssociatedObject.sfTreeGrid.SelectionController as TreeGridRowSelectionController).RefreshSelection();
                        e.Handled = true;
                    }
                }
                (AssociatedObject.listView.ItemsSource as ObservableCollection<EmployeeInfo>).Remove(record as EmployeeInfo);
            }
        }

        /// <summary>
        /// Gets the source collection of TreeGrid
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        private IList GetSourceListCollection(IEnumerable collection)
        {
            IList list = null;
            if (collection == null)
                collection = AssociatedObject.sfTreeGrid.View.SourceCollection;
            if ((collection as IList) != null)
            {
                list = collection as IList;
            }
            return list;
        }
        List<EmployeeInfo> list = new List<EmployeeInfo>();
        /// <summary>
        /// Handle the Drop event of ListView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_Drop(object sender, DragEventArgs e)
        {
            ObservableCollection<TreeNode> treeNodes = new ObservableCollection<TreeNode>();

            if (e.Data.GetDataPresent("Nodes"))
                treeNodes= e.Data.GetData("Nodes") as ObservableCollection<TreeNode>;

            EmployeeInfo item = new EmployeeInfo();

            if (treeNodes.Count == 0 ||treeNodes==null)
                return;
           
            foreach (var node in treeNodes)
            {
                (AssociatedObject.sfTreeGrid.ItemsSource as ObservableCollection<EmployeeInfo>).Remove(node.Item as EmployeeInfo);
                if (node.HasChildNodes)
                {
                    list.Add(node.Item as EmployeeInfo);
                    GetChildNodes(node);
                }
                else
                {
                    list.Add(node.Item as EmployeeInfo);
                }
            }
            
            foreach (var listItem in list)
            {
                (this.AssociatedObject.DataContext as ViewModel).Employee.Add(listItem);
            }
            list.Clear();
        }

        /// <summary>
        /// Get the child nodes from parent node
        /// </summary>
        /// <param name="node"></param>
        private void GetChildNodes(TreeNode node)
        {
            foreach (var childNode in node.ChildNodes)
            {
                list.Add(childNode.Item as EmployeeInfo);
                GetChildNodes(childNode);
            }
        }

        /// <summary>
        /// Descrides the PreviewMouseMove event of ListView and start the drag operaion of ListView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_PreviewMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                ListBox dragSource = null;
                var records = new ObservableCollection<object>();
                ListBox parent = (ListBox)sender;
                dragSource = parent;
                object data = GetDataFromListBox(dragSource, e.GetPosition(parent));

                records.Add(data);

                var dataObject = new DataObject();
                dataObject.SetData("ListViewRecords", records);
                dataObject.SetData("ListView", this.AssociatedObject.listView);

                
                if (data != null)
                {
                    DragDrop.DoDragDrop(parent, dataObject, DragDropEffects.Move);
                }
            }
            e.Handled = true;
        }
        /// <summary>
        /// Get the data from list box control
        /// </summary>
        /// <param name="source"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        private static object GetDataFromListBox(ListBox source, Point point)
        {
            UIElement element = source.InputHitTest(point) as UIElement;
            if (element != null)
            {
                object data = DependencyProperty.UnsetValue;
                while (data == DependencyProperty.UnsetValue)
                {
                    data = source.ItemContainerGenerator.ItemFromContainer(element);
                    if (data == DependencyProperty.UnsetValue)
                    {
                        element = VisualTreeHelper.GetParent(element) as UIElement;
                    }
                    if (element == source)
                    {
                        return null;
                    }
                }
                if (data != DependencyProperty.UnsetValue)
                {
                    return data;
                }
            }
            return null;
        }
        /// <summary>
        /// Initialize the OnDetaching method
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= AssociatedObject_Loaded;
            this.AssociatedObject.listView.PreviewMouseMove -= ListView_PreviewMouseMove;
            this.AssociatedObject.listView.Drop -= ListView_Drop;
            this.AssociatedObject.sfTreeGrid.RowDragDropController.Drop -= RowDragDropController_Drop;
        }
    }

 }
