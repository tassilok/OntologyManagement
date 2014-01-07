using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using QuickGraph;
using GraphSharp.Algorithms.Layout.Compound.FDP;
using GraphSharp.Algorithms.Layout.Compound;
using GraphSharp;
using System.Windows.Threading;
using GraphSharp.Controls;

namespace OGraph_Module
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private clsLocalConfig objLocalConfig;
        private clsDBLevel objDBLevel_Classes;
        private clsDBLevel objDBLevel_ClassTree;
        private CompoundFDPLayoutAlgorithm<object, TaggedEdge<object,object>, ICompoundGraph<object, TaggedEdge<object, object>>> layoutAlgorithm;

        private IBidirectionalGraph<object, IEdge<object>> _graphToVisualize;

        private DispatcherTimer dispatcherTime;

        private TreeViewItem treeViewItem;

        public IBidirectionalGraph<object, IEdge<object>> GraphToVisualize
        {
            get { return _graphToVisualize; }
            set { _graphToVisualize = value; }
        }
        public MainWindow()
        {
            
            objLocalConfig = new clsLocalConfig();
            //InitializeGraph();
            
            InitializeComponent();

            Initialize();

            
        }

        private void Initialize()
        {
            objDBLevel_ClassTree = new clsDBLevel(objLocalConfig.Globals);
            dispatcherTime = new DispatcherTimer();
            dispatcherTime.Interval = System.TimeSpan.FromMilliseconds(300);
            dispatcherTime.Tick += dispatcherTime_Tick;

            FillClassTree();
        }

        void dispatcherTime_Tick(object sender, EventArgs e)
        {
            dispatcherTime.Stop();

            if (treeViewItem != null)
            {
                InitializeGraph(treeViewItem.Name.Replace("_", ""));
            }
        }

        private clsOntologyItem FillClassTree(TreeViewItem treeViewItemParent = null)
        {
            var oItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            if (treeViewItemParent == null)
            {
                oItem_Result = objDBLevel_ClassTree.get_Data_Classes(new List<clsOntologyItem> {new clsOntologyItem {GUID = objLocalConfig.Globals.Root.GUID}});
                if (oItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    foreach (var oClass in objDBLevel_ClassTree.OList_Classes.OrderBy(cl => cl.Name).ToList())
                    {
                        var treeViewItemSub = new TreeViewItem { Header = oClass.Name, Name = "_" + oClass.GUID };
                        ClassTree.Items.Add(treeViewItemSub);
                        oItem_Result = FillClassTree(treeViewItemSub);
                        if (oItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID) break;
                    }
                }
            }
            else
            {
                try
                {
                    oItem_Result = objDBLevel_ClassTree.get_Data_Classes(new List<clsOntologyItem> { new clsOntologyItem { GUID_Parent = treeViewItemParent.Name.Replace("_", "") } });
                    if (oItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        foreach (var oClass in objDBLevel_ClassTree.OList_Classes.OrderBy(cl => cl.Name).ToList())
                        {
                            var treeViewItemSub = new TreeViewItem { Header = oClass.Name, Name = "_" + oClass.GUID };
                            treeViewItemSub.Selected += treeViewItemSub_Selected;
                            treeViewItemParent.Items.Add(treeViewItemSub);
                            oItem_Result = FillClassTree(treeViewItemSub);
                            if (oItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID) break;
                        }
                    }
                }
                catch (Exception ex)
                {
                   
                }
                
            }
            return oItem_Result;
        }
        

        void treeViewItemSub_Selected(object sender, RoutedEventArgs e)
        {
            
            //dispatcherTime.Stop();
            treeViewItem = sender as TreeViewItem;
            //dispatcherTime.Start();
            if (treeViewItem != null && treeViewItem.IsSelected)
            {
                InitializeGraph(treeViewItem.Name.Replace("_", ""));
            }
            
        }



        private void InitializeGraph(string idClass)
        {
            var g = new CompoundGraph<object, IEdge<object>>();
            
            objDBLevel_Classes = new clsDBLevel(objLocalConfig.Globals);
            var objOItem_Result = objDBLevel_Classes.get_Data_ClassRel(null, boolIDs: false);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var oList_ClassRel = objDBLevel_Classes.OList_ClassRel;
                foreach (var oClassRel in oList_ClassRel.Where(p => p.ID_Class_Left == idClass || p.ID_Class_Right == idClass).ToList())
                {
                    g.AddVertex(oClassRel.Name_Class_Left );
                    g.AddVertex(oClassRel.Name_Class_Right );
                    var edge = new TaggedEdge<object, object>(oClassRel.Name_Class_Left , oClassRel.Name_Class_Right, oClassRel.Name_RelationType);
                    
                    g.AddEdge(edge);
                }
            }

            var sizes = new Dictionary<object, Size>();
            var borders = new Dictionary<object, Thickness>();
            var layoutType = new Dictionary<object, CompoundVertexInnerLayoutType>();

            var b = new Thickness(5, 10, 5, 5);
            foreach (var v in g.CompoundVertices)
            {
                sizes[v] = new Size();
                borders[v] = b;
                layoutType[v] = CompoundVertexInnerLayoutType.Automatic;
            }
            var test = new GraphSharp.Controls.GraphLayout<object, IEdge<object>, CompoundGraph<object, IEdge<object>>>();
            test.LayoutAlgorithmType = "Circular";
            
            //var layoutAlg = new CompoundFDPLayoutAlgorithm<object,IEdge<object>,CompoundGraph<object, IEdge<object>>>(g, sizes, borders, layoutType, null,
            //                                 null);

            //layoutAlgorithm = new CompoundFDPLayoutAlgorithm<object, TaggedEdge<object, object>, ICompoundGraph<object, TaggedEdge<object, object>>>(
            //                                 g, sizes, borders, layoutType, null,
            //                                 null);
            ////layoutAlgorithm.Compute();
            GraphToVisualize = g;
            
            //layoutAlg.Compute();
            //graphLayout.LayoutAlgorithm=new CompoundFDPLayoutAlgorithm<object,TaggedEdge<object,object>, CompoundGraph<object, TaggedEdge<object,object>>>(
            graphLayout.GetBindingExpression(GraphSharp.Controls.GraphLayout.GraphProperty).UpdateTarget();
            //graphLayout.RefreshBinding();

        }

        private void Test()
        {
            
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            layoutAlgorithm.Compute();
        }
  
    }
}
