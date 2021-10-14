using System;

namespace testLab2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            1.Write C# code that does each of the following tasks. For parts (d), (e), and (f), also find the expected result and explain how you got it.

            (a) creates a Graph g with 128 vertices;*/
            // CALL graph's int constructor.
            // syntax is same as for Java:
            int graphSize = 128;
            Graph g = new Graph(graphSize);

            
            // (b)stores the numbers 0 through 127 in the vertices, in that order;
            for(int i = 0; i< graphSize; i++)
            {
                g.addVertexData(i, i);
            }
            Console.WriteLine(g);

           

            /*
            

            (c)joins all pairs of vertices of the form { j, j / 2}
            where j is between 1 and 127, and where j / 2 is computed as usual with integer division;

            (d)tests g for connectedness;
            expected results:



            (e)tests g for cycles;
            expected results:



            (f)tests whether g is a tree.

            expected results:
*/
        }
    }
}
