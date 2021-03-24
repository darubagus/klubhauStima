using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Microsoft.Msagl;
using Microsoft.Msagl.GraphViewerGdi;
using Stima;

namespace setres
{
    public partial class Form1 : Form
    {
        Microsoft.Msagl.Drawing.Graph graph;
        String startAccount;
        String destAccount;
        String[] acc;
        Graph networkGraph;
        BreadthFirstSearch bfs;
        DepthFirstSearch dfs;
        MutualFriend friendRec;
        List<string> people;
        List<Node> bfsPath;
        List<Node> dfsPath;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            startAccount = comboBoxChooseAccount.SelectedItem.ToString();
            destAccount = comboBoxExploreFriends.SelectedItem.ToString();
            networkGraph = new Graph(startAccount);

            if (radioButtonBFS.Checked)
            {
                bfs = new BreadthFirstSearch(networkGraph, startAccount); 
                bfs.RunBFS();
                bfsPath = bfs.Path(destAccount); 
                bfsPath.Reverse();
                bfs.PrintPath(bfsPath); // ini bakal ngeprint di console doang. baru bisa dipake kalo console.WriteLine di implementasinya diganti jd Debug.WriteLine
            }

            if (radioButtonDFS.Checked)
            {
                dfs = new DepthFirstSearch(networkGraph, startAccount); 
                dfs.RunDFS();
                dfsPath = dfs.Path(destAccount); 
                dfsPath.Reverse();
                dfs.PrintPath(dfsPath); // ini juga ngeprint di console doang. baru bisa dipake kalo console.WriteLine di implementasinya diganti jd Debug.WriteLine
            }

            friendRec = new MutualFriend(networkGraph, startAccount);  
            friendRec.FindMutualFriend();
            friendRec.PrintResult();
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

                        fillCombo(fileContent);

                        drawGraph(fileContent);

                    }
                    catch (IOException)
                    {

                    }
                }
            }
        }

        private void fillCombo (string[] input)
        {
            var tmp = new List<string>();
            string[] lines;

            for (int i = 1; i < input.Length; i++)
            {
                lines = input[i].Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in lines)
                {
                    tmp.Add(line);
                }
            }

            people = tmp.Distinct().ToList();
            people.Sort();

            foreach(string item in people)
            {
                comboBoxChooseAccount.Items.Add(item);
            }

        }

        private void drawGraph (string[] input)
        {
            //create a viewer object 
            GViewer viewer = new GViewer();
            graph = new Microsoft.Msagl.Drawing.Graph();

            for (int i = 1; i < input.Length; i++)
            {
                //create the graph content 
                string[] lines2 = input[i].Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
                var edge = graph.AddEdge(lines2[0], lines2[1]);
                edge.Attr.ArrowheadAtSource = Microsoft.Msagl.Drawing.ArrowStyle.None;
                edge.Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.None;

            }

            //bind the graph to the viewer 
            viewer.Graph = graph;
            viewer.Name = "view";
            viewer.Dock = DockStyle.Fill;

            panelGraph.Controls.Add(viewer);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            startAccount = comboBoxChooseAccount.SelectedItem.ToString();

            foreach (string item in people)
            {
                if (item != startAccount)
                {
                    comboBoxExploreFriends.Items.Add(item);
                }
            }
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


