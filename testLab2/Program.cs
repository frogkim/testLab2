// Modified by Jong-Young Choi
// ---------------
using System;

namespace testLab2
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Write C# code that does each of the following tasks. For parts (d), (e), and (f), also find the expected result and explain how you got it.
            //(a) creates a Graph g with 128 vertices;
            
            // CALL graph's int constructor.
            // syntax is same as for Java:
            int graphSize = 128;
            Graph g = new Graph(graphSize);

            //(b)stores the numbers 0 through 127 in the vertices, in that order;
            for (int i = 0; i < graphSize; i++)
            {
                //g.addVertexData(i, g.getVertexData(i));
                g.addVertexData(i, i);
            }

            //(c)joins all pairs of vertices of the form {j, j / 2}
            //where j is between 1 and 127, and where j / 2 is computed as usual with integer division;
            for(int j=1; j< graphSize; j++)
            {
                g.addEdge(j, j/2);
                //g.addEdge(j/2, j);
            }

            //(d)tests g for connectedness;
            Console.WriteLine(g.isConnected());
            // expected results:
            // True

            //(e)tests g for cycles;
            Console.WriteLine(g.hasCycle());
            // expected results:
            // False

            //(f)tests whether g is a tree.
            Console.WriteLine(g.isTree());
            //expected results:
            // True

//      2.Write C# code that starts with the graph g built in problem 1 above, then removes the edge from 1 to 3, and tests again for connectedness, cycles, and tree-ness.
//       expected results:
            g.removeEdge(1,3);

            //(d)tests g for connectedness;
            Console.WriteLine(g.isConnected());
            // expected results:
            // False

            //(e)tests g for cycles;
            Console.WriteLine(g.hasCycle());
            // expected results:
            // False

            //(f)tests whether g is a tree.
            Console.WriteLine(g.isTree());
            //expected results:
            // False

//      3.Write C# code that starts with the Graph g in the state after problem 2 above, then adds a new edge from 111 to 112. Test again for connectedness, cycles, and tree-ness.
//      expected results:
            g.addEdge(111,112);

            // tests g for connectedness;
            Console.WriteLine(g.isConnected());
            // expected results:
            // False

            //(e)tests g for cycles;
            Console.WriteLine(g.hasCycle());
            // expected results:
            // True

            //(f)tests whether g is a tree.
            Console.WriteLine(g.isTree());
            //expected results:
            // False

//      4.Write C# code that starts with the Graph g in the state after problem 3 above, then adds back the edge from 1 to 3. Test again for connectedness, cycles, and tree-ness.
//      expected results:
            g.addEdge(1,3);

            // tests g for connectedness;
            Console.WriteLine(g.isConnected());
            // expected results:
            // True

            //(e)tests g for cycles;
            Console.WriteLine(g.hasCycle());
            // expected results:
            // True

            //(f)tests whether g is a tree.
            Console.WriteLine(g.isTree());
            //expected results:
            // False

//       5.Write C# code that does each of the following tasks.
//      (a) Creates a weighted graph wg with 5 vertices(note that the vertices will be numbered 0 through 4);
            int gwSize = 5;
            Graph gw = new Graph(gwSize);
            for(int i=0; i<gwSize; i++)
            {
                gw.addVertexData(i, i);
            }

//      (b) adds edges between every pair of vertices in wg to create a "complete" graph;
            for(int i = 0; i < gwSize; i++)
            {
                for(int j = i + 1; j < gwSize; j++)
                {
                    gw.addEdge(i,j);
                }
            }

//      (c) adds edge weights to wg so that the weight of the edge {a, b} is equal to 1.0 / ((a^2 + b^2 - ab) % 11 + 1);
            double[,] weights = new double[gwSize, gwSize];
            for(int i = 0;i < gwSize; i++)
            {
                for(int j=0; j<=i; j++)
                {
                    double denominator = (i*i + j*j - i*j) % 11 + 1;
                    weights[i,j] = 1.0 / denominator;
                    weights[j,i] = weights[i,j];
                }
            }

//      (d) displays a minimum-weight spanning tree t in wg using Kruskal's Algorithm.
// From note
// 0. Make a copy C of W with the same vertices as W, but no edges;
// 1. Sort all the edges of W in increasing order of weight;
// 2. Add the next edge of the sorted list to C,
//    unless doing so would produce a cycle in C;
// 3. If C is not connected, then go to Step 2.

            // step 0
            Graph C = new Graph(g.getNumVertices());
            for(int i = 0; i < g.getNumVertices(); i++)
            {
                C.addVertexData(i, g.getVertexData(i));
            }


            // step 1
            // make a class
            Sorted[] sorted = new Sorted[gwSize*gwSize];

            for(int i=0; i< gwSize; i++)
            {
                for(int j=0; j<gwSize; j++)
                {
                    sorted[i*gwSize + j] = new Sorted(i,j, weights[i,j]);
                    
                    //sorted[i*gwSize,j].vertex1 = i;
                    //sorted[i*gwSize,j].vertex2 = j;
                    //sorted[i*gwSize,j].weight = weights[i,j];
                }
            }
            
            for(int i=0; i<gwSize*gwSize - 1; i++)
            {
                for(int j=0; j<gwSize*gwSize - 1 - i; j++)
                {
                    if(sorted[j].weight > sorted[j+1].weight)
                    {
                        Sorted temp = sorted[j];
                        sorted[j] = sorted[j+1];
                        sorted[j+1] = temp;
                    }
                }
            }

//       6.Show the work for problem 5(d) manually and give the expected result.

        }
    }
    class Sorted
    {
        public object vertex1;
        public object vertex2;
        public double weight;
        public Sorted(object v1, object v2, double w)
        {
            this.vertex1 = v1;
            this.vertex2 = v1;
            this.weight = w;
        }
    };
} // namespace
