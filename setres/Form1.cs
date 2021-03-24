﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
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

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Open A Text File.";
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        //Get the path of specified file
                        string filePath = openFileDialog.FileName;

                        //Read the contents of the file
                        string[] fileContent = File.ReadAllLines(filePath);

                        // debugzz
                        //string testShow = string.Join(Environment.NewLine, fileContent);
                        //MessageBox.Show(testShow, filePath);
                    }
                    catch (IOException)
                    {

                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
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
                //edge.Attr.Color = Microsoft.Msagl.Drawing.color.Black;
                string edgeName = node1 + "-" + node2;
                //kurang nambahin ke list of edge

            }

            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}


