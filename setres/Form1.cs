using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Msagl;
using Microsoft.Msagl.GraphViewerGdi;

namespace setres
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public class Graph
        {
            //create a form 
            private System.Windows.Forms.Form form = new System.Windows.Forms.Form();
            
            //create a viewer object 
            private Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            
            //create a graph object 
            private Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph();
            // create list of edge representation
            // kira2 enakan pake list atau dictionary ya?
            
            // kayanya enakan pake dictionary sih
            
            // create Edge
            public void createEdge(string node1, string node2){
                Microsoft.Msagl.Drawing.Edge edge;
                edge = this.graph.AddEdge(node1, node2);
                edge.Attr.Color = Microsoft.Msagl.Drawing.color.Black;
                string edgeName = node1 + "-" + node2;
                //kurang nambahin ke list of edge

            }

            
        }
    }
}


