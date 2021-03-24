using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Stima;

namespace StimaClass
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string[] ids_test = new string[8] { "A", "B", "C", "D", "E", "F", "G", "H" };

            Graph graph_test = new Graph("A");
            for (int i = 1; i < 8; i++)
            {
                Console.WriteLine(ids_test[i]);
                graph_test.InsertNode(ids_test[i]);
            }

            
            graph_test.InsertEdge("A", "B");
            graph_test.InsertEdge("A", "C");
            graph_test.InsertEdge("A", "D");

            graph_test.InsertEdge("B", "C");
            graph_test.InsertEdge("B", "E");
            graph_test.InsertEdge("B", "F");

            graph_test.InsertEdge("C", "F");
            graph_test.InsertEdge("C", "G");

            graph_test.InsertEdge("D", "F");
            graph_test.InsertEdge("D", "G");
         
            graph_test.InsertEdge("E", "F");
            graph_test.InsertEdge("E", "H");

            graph_test.InsertEdge("F", "H");


            /*
             * [A] --> [B] -> [C] -> [D]
             * [B] --> [A] -> [C] -> [E] -> [F]
             * [C] --> [A] -> [B] -> [F] -> [G]
             * [D] --> [A] -> [G] -> [F]
             * [E] --> [B] -> [H] -> [F]
             * [F] --> [B] -> [C] -> [D] -> [E]
             * [G] --> [C] -> [D]
             * [H] --> [E]
             */

            //MutualFriend test = new MutualFriend(graph_test, "A");
            ////test.PrintResult();
            //string testHasil = test.PrintHasil();
            //Console.WriteLine(testHasil);

            //Console.WriteLine("\n");

            DepthFirstSearch dfs = new DepthFirstSearch(graph_test, "A");
            dfs.RunDFS();
            List<Node> dfs_path = dfs.Path("H");
            dfs_path.Reverse();
            Console.WriteLine("Ini DFS:");
            //dfs.PrintInterval();
            //dfs.PrintPath(dfs_path);
            string hasilDFS = dfs.PrintPathString(dfs_path);
            Console.WriteLine(hasilDFS);

            //Console.WriteLine("\n");

            //BreadthFirstSearch bfs = new BreadthFirstSearch(graph_test, "A");
            //bfs.RunBFS();
            //List<Node> bfs_path = bfs.Path("H");
            //bfs_path.Reverse();
            //Console.WriteLine("Ini BFS :");
            ////bfs.PrintLevel();
            //bfs.PrintPath(bfs_path);


            //string[] inputFile = fileContent;
            //// Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("g");
            //for (int i = 1; i < inputFile.Length; i++)
            //{
            //    int j = 0;

            //    while (inputFile[i][j] != ' ')
            //    {
            //        j++;
            //    }

            //    // g.AddEdge(inputFile[i].Substring(0,j), inputFile[i].Substring(j+1, inputFile[i].Length - j-1));
            //    /*

            //    if (!comboBoxChooseAccount.Items.Contains(inputFile[i].Substring(0,j)))
            //    {
            //        comboBoxChooseAccount.Items.Add(inputFile[i].Substring(0,j));
            //    }

            //    if (!comboBoxChooseAccount.Items.Contains(inputFile[i].Substring(0,j)))
            //    {
            //        comboBoxChooseAccount.Items.Add(inputFile[i].Substring(j+1, inputFile[i].Length - j-1));
            //    }
            // }
            //giewer1.Graph = g;

            //string[] listOfAccount = new string[comboBoxChooseAccount.Items.Count];

            //comboBoxChooseAccount.Items.CopyTo(listOfAccount, 0);
            //listOfAcc = listOfAccount;

            // */
            //}




            ////ini harusnya di button submitnya
            //startAccount = comboBoxChooseAccount.SelectedItem.ToString();   // ini dibikin public static aja
            //destAccount = comboBoxExploreFriends.SelectedItem.ToString();   // ini dibikin public static aja
            //Acc = Acc.Where(x => x != account).ToArray();   // ini dibikin public static aja tipenya string[] harusnya
            //networkGraph = new Graph(startAccount);   // ini dibikin public static aja

            //for (int i = 0; i < Acc.Length; i++)
            //{
            //    networkGraph.InsertNode(Acc[i]);
            //}

            //for (int i = 1; i < inputFile.Length; i++)
            //{
            //    int j = 0;

            //    while (inputFile[i][j] != ' ')
            //    {
            //        j++;
            //    }

            //    networkGraph.InsertEdge(inputFile[i].Substring(0, j), inputFile[i].Substring(j + 1, inputFile[i].Length - j - 1));
            //}

            //if (radioButtonBFS.Checked)
            //{
            //    BreadthFirstSearch bfs = new BreadthFirstSearch(networkGraph, startAccount); // ini dibikin public static aja
            //    bfs.RunBFS();
            //    List<Node> bfs_path = bfs.Path(destAccount); // ini dibikin public static aja
            //    bfs_path.Reverse();
            //    bfs.PrintPath(bfs_path); // ini bakal ngeprint di console doang. baru bisa dipake kalo console.WriteLine di implementasinya diganti jd Debug.WriteLine
            //}

            //if (radioButtonDFS.Checked)
            //{
            //    DepthFirstSearch dfs = new DepthFirstSearch(networkGraph, startAccount); // ini dibikin public static aja
            //    dfs.RunDFS();
            //    List<Node> dfs_path = dfs.Path(destAccount); // ini dibikin public static aja
            //    dfs_path.Reverse()
            //    dfs.PrintPath(dfs_path); // ini juga ngeprint di console doang. baru bisa dipake kalo console.WriteLine di implementasinya diganti jd Debug.WriteLine
            //}

            //MutualFriend friendRec = new MutualFriend(networkGraph, startAccount);  // ini dibikin public static aja
            //friendRec.FindMutualFriend();
            //friendRec.PrintResult();    // ini juga ngeprint di console doang. baru bisa dipake kalo console.WriteLine di implementasinya diganti jd Debug.WriteLine


        }
    }
}
