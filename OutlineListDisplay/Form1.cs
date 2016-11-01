using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OutlineListDisplay;

namespace OutlineListDisplay
{
    public partial class Form1 : Form
    {
        public static string[] List = {"test.prt.1", "test.prt.2", "test.prt.3", "test.prt.5"};

        public Form1( )
        {
            InitializeComponent( );
        }

        private void AddItemToSelectedButton_Click( object sender, EventArgs e )
        {
            FillMyTreeView();

        }

        private void RemoveSelected_Click( object sender, EventArgs e )
        {
            var tnc = new ArrayList();

            myTreeView.BeginUpdate( );
            foreach ( TreeNode tn in new ArrayList(myTreeView.Nodes).ToArray())
            {

                if ( tn.Checked ) myTreeView.Nodes.RemoveAt( myTreeView.Nodes.IndexOf( tn ) );
                else
                    foreach (TreeNode tn_child in new ArrayList(tn.Nodes).ToArray())
                    {
                        if ( tn_child.Checked ) myTreeView.Nodes[myTreeView.Nodes.IndexOf( tn )].Nodes.RemoveAt( myTreeView.Nodes[myTreeView.Nodes.IndexOf( tn )].Nodes.IndexOf(tn_child));
                    }
                
            }
            myTreeView.EndUpdate();


        }

        // Create a new ArrayList to hold the Customer objects.
        private ArrayList _customerArray = new ArrayList( );

        private void FillMyTreeView( )
        {
            _customerArray.Clear();
            // Add customers to the ArrayList of Customer objects.
            for ( int x = 0; x < 1000; x++ )
            {
                _customerArray.Add( new Customer( "Customer" + x.ToString( ) ) );
            }

            // Add orders to each Customer object in the ArrayList.
            foreach ( Customer customer1 in _customerArray )
            {
                for ( int y = 0; y < 15; y++ )
                {
                    customer1.CustomerOrders.Add( new Order( "Order" + y.ToString( ) ) );
                }
            }

            // Display a wait cursor while the TreeNodes are being created.
            Cursor.Current = Cursors.WaitCursor;

            // Suppress repainting the TreeView until all the objects have been created.
            myTreeView.BeginUpdate( );

            // Clear the TreeView each time the method is called.
            myTreeView.Nodes.Clear();
            myTreeView.EndUpdate();
            var mbox = MessageBox.Show( "Should have Cleared the list" );
            myTreeView.BeginUpdate( );

            // Add a root TreeNode for each Customer object in the ArrayList.
            foreach ( Customer customer2 in _customerArray )
            {
                myTreeView.Nodes.Add( new TreeNode( customer2.CustomerName ) );

                // Add a child treenode for each Order object in the current Customer object.
                foreach ( Order order1 in customer2.CustomerOrders )
                {
                    myTreeView.Nodes[_customerArray.IndexOf( customer2 )].Nodes.Add(
                      new TreeNode( customer2.CustomerName + "." + order1.OrderId ) );
                }
            }

            // Reset the cursor to the default for all controls.
            Cursor.Current = Cursors.Default;

            // Begin repainting the TreeView.
            myTreeView.EndUpdate( );
        }

        private void myTreeView_AfterSelect( object sender, TreeViewEventArgs e )
        {
            MessageBox.Show( $"Sender = {sender}, event args (Checked?) = {e.Node.Checked}" );
        }

        private void myTreeView_AfterCheck( object sender, TreeViewEventArgs e )
        {
            MessageBox.Show( $"Sender = {sender}, event args = {e.Node.Nodes.Count}" );
            
        }
    }

    // The basic Customer class.
    public class Customer : System.Object
    {
        private string _custName = "";
        protected ArrayList CustOrders = new ArrayList( );

        public Customer( string customername )
        {
            this._custName = customername;
        }

        public string CustomerName
        {
            get { return this._custName; }
            set { this._custName = value; }
        }

        public ArrayList CustomerOrders
        {
            get { return this.CustOrders; }
        }

    } // End Customer class 


    // The basic customer Order class.
    public class Order : System.Object
    {
        private string _ordId = "";

        public Order( string orderid )
        {
            this._ordId = orderid;
        }

        public string OrderId
        {
            get { return this._ordId; }
            set { this._ordId = value; }
        }

    } // End Order class

    
}

