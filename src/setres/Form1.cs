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
        String startAccount;
        String destAccount;
        String[] fileContent;
        Graph networkGraph;
        BreadthFirstSearch bfs;
        DepthFirstSearch dfs;
        MutualFriend friendRec;
        List<string> people;
        List<Node> bfsPath;
        List<Node> dfsPath;
        Microsoft.Msagl.Drawing.Graph graph;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxChooseAccount.Enabled = false;
            comboBoxExploreFriends.Enabled = false;
            radioButtonBFS.Enabled = false;
            radioButtonDFS.Enabled = false;
            buttonSubmit.Enabled = false;
            buttonReset.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            startAccount = "";
            destAccount = "";

            if (comboBoxChooseAccount.SelectedIndex == -1)
            {
                MessageBox.Show("Choose an account to begin with");
            }
            else
            {
                startAccount = comboBoxChooseAccount.SelectedItem.ToString();
            }

            networkGraph = new Graph(startAccount);
            List<string> acc = new List<string>();

            foreach (string item in people)
            {
                if (item != startAccount)
                {
                    acc.Add(item);
                }
            }

            String[] account = acc.ToArray();

            for (int i = 0; i < account.Length; i++)
            {
                networkGraph.InsertNode(account[i]);
            }

            for (int i = 1; i < fileContent.Length; i++)
            {
                int j = 0;

                while (fileContent[i][j] != ' ')
                {
                    j++;
                }

                networkGraph.InsertEdge(fileContent[i].Substring(0, j), fileContent[i].Substring(j + 1, fileContent[i].Length - j - 1));
            }

            if (comboBoxExploreFriends.SelectedIndex != -1)
            {
                destAccount = comboBoxExploreFriends.SelectedItem.ToString();

                if (radioButtonBFS.Checked)
                {
                    bfs = new BreadthFirstSearch(networkGraph, startAccount);
                    bfs.RunBFS();
                    bfsPath = bfs.Path(destAccount);   
                    bfsPath.Reverse();
                    int level = bfs.PrintLevel(destAccount);
                    string resultBFS = "Nama akun: " + startAccount + " dan " + destAccount + "\r\n";
                    if (level != -1)
                    {
                        resultBFS += level.ToString() + "th degree connection \r\n";
                        resultBFS += dfs.PrintStringDFS(dfsPath);
                    }
                    else
                    {
                        resultBFS += "Tidak ada jalur koneksi yang tersedia \r\n";
                        resultBFS += "Anda harus memulai koneksi baru itu sendiri. \r\n";
                    }
                    textBoxResult.Text = resultBFS;
                    //colorGraph(fileContent, bfsPath);
                }

                else if (radioButtonDFS.Checked)
                {
                    dfs = new DepthFirstSearch(networkGraph, startAccount);
                    dfs.RunDFS();
                    dfsPath = dfs.Path(destAccount);
                    dfsPath.Reverse();
                    int degree = dfs.PrintInterval(destAccount);
                    string resultDFS = "";
                    resultDFS += "Nama akun: " + startAccount + " dan " + destAccount + "\r\n";
                    if (degree != -1)
                    {
                        resultDFS += degree.ToString() + "th degree connection \r\n";
                        resultDFS += dfs.PrintStringDFS(dfsPath);
                    }
                    else
                    {
                        resultDFS += "Tidak ada jalur koneksi yang tersedia \r\n";
                        resultDFS += "Anda harus memulai koneksi baru itu sendiri. \r\n";
                    }
                    textBoxResult.Text = resultDFS;
                    //colorGraph(fileContent, dfsPath);

                }
                else
                {
                    MessageBox.Show("Please select an algorithm");
                }
            }
            else
            {
                friendRec = new MutualFriend(networkGraph, startAccount);
                //friendRec.FindMutualFriend();
                string resultFriend = "Daftar rekomendasi teman untuk akun " + startAccount + "\r\n";
                resultFriend += friendRec.PrintHasil();
                textBoxResult.Multiline = true;
                textBoxResult.Text = resultFriend;
                MessageBox.Show(resultFriend);
            }

            //colorGraph(fileContent, startAccount, destAccount);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Pilih Test Case";
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
                        fileContent = File.ReadAllLines(filePath);

                        fillCombo(fileContent);

                        drawGraph(fileContent);

                    }
                    catch (IOException)
                    {

                    }

                    radioButtonDFS.Enabled = true;
                    radioButtonBFS.Enabled = true;
                    comboBoxChooseAccount.Enabled = true;
                    comboBoxExploreFriends.Enabled = true;
                    buttonSubmit.Enabled = true;
                    buttonReset.Enabled = true;
                }
            }
        }

        private void buttonReset_Click(object Sender, EventArgs e)
        {
            radioButtonBFS.Checked = false;
            radioButtonDFS.Checked = false;
            comboBoxChooseAccount.ResetText();
            comboBoxExploreFriends.ResetText();
            textBoxResult.ResetText();
            clearGraph();
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
                string[] content = input[i].Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
                var edge = graph.AddEdge(content[0], content[1]);
                edge.Attr.ArrowheadAtSource = Microsoft.Msagl.Drawing.ArrowStyle.None;
                edge.Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.None;
            }

            //bind the graph to the viewer 
            viewer.Graph = graph;
            viewer.Name = "view";
            viewer.Dock = DockStyle.Fill;

            panelGraph.Controls.Add(viewer);
        }

        private void clearGraph()
        {
            GViewer viewer = new GViewer();
            viewer.Graph = graph;
            viewer.Name = "viewer";
            viewer.Dock = DockStyle.Fill;

            panelGraph.Controls.Clear();
            panelGraph.Controls.Add(viewer);
        }

        private void colorGraph (string[] input, List<Node> path)
        {
            //create a viewer object 
            GViewer viewer = new GViewer();
            Microsoft.Msagl.Drawing.Graph graph1 = new Microsoft.Msagl.Drawing.Graph();

            for (int i = 1; i < input.Length; i++)
            {
                //create the graph content 
                string[] content = input[i].Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
                var edge = graph1.AddEdge(content[0], content[1]);
                edge.Attr.ArrowheadAtSource = Microsoft.Msagl.Drawing.ArrowStyle.None;
                edge.Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.None;
                //foreach (Node n in path)
                //{
                //    string tmp = n.Name;
                //    //MessageBox.Show(n.Name);
                //    graph1.FindNode(tmp).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Aqua;
                //}
                //graph1.FindNode(path.First().Name).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Aquamarine;
                //if (dest != "")
                //{
                //   graph1.FindNode(dest).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Blue;
                //}
                //graph1.FindNode(dest).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Blue;
            }

            viewer.Graph = graph1;
            viewer.Name = "viewer";
            viewer.Dock = DockStyle.Fill;

            panelGraph.Controls.Clear();
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
                comboBoxExploreFriends.Items.Remove(item);
            }

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

        private void textBoxResult_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


