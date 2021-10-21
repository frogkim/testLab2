namespace testLab2
{
    class user
    {
// Idea : DFS returns an array of vertices that is connected with a specific vertex.
// The set of elements which has a value more than 0 will be a member of a connected component.
// Then, in next, call DFS with an element which has a value zero.
// This time DFS will return an array of vertices that is a different connected component.
// Repeat this until all elements have a value more than 1.
// Repeated number will be the number of connected components.

        public static int connectedComponent(Graph g)
        {
            int count = 0;
            // This line is added last time.
            // I found that my method will not be functioned when a graph has no or one vertex.
            if (g.getNumVertices() < 2)
            {
                // The only vertex will be the only connected component.
                return g.getNumVertices();
            }

            int[] vertex = new int[g.getNumVertices()];

            for(int i = 0; i < g.getNumVertices()-1; i++)
            {
                if(vertex[i] == 0)
                {
                    count++;
                    int[] tmp = DFS(g, i);
                    for(int j = i; j < g.getNumVertices(); j++)
                    {
                        vertex[j] = vertex[j] | tmp[j];
                        // In this time, the exact value is not important.
                        // We just need to check that it is 0 or not.
                        // To use bit operator will be more efficient.
                    }
                }
            }
            return count;
        }

        // In Graph class, DFS is not public method, so I made a similar one.
        // If possible, it will be good choice to request to Graph class designer to make DFS method public.
        
        // connectedComponent is static method. Therefore the method it will call also should be a static.

        private static int[] DFS(Graph g, int start)
        {
            int order = 0;
            int[] vertexTmp = new int[g.getNumVertices()];
            DFS_Recursive(g, start, vertexTmp, ref order);

            return vertexTmp;
        }

        private static void DFS_Recursive(Graph g, int start, int[] vertexTmp, ref int order)
        {
            vertexTmp[start] = order;
            order++;
            //for (int i = start+1; i < g.getNumVertices(); i++)
            for (int i = 1; i < g.getNumVertices(); i++)
            {
                if( start == i )
                {
                    // We do not allow loop.
                    continue;
                }

                if (g.hasEdge(start, i))
                {
                    DFS_Recursive(g, start, vertexTmp, ref order);
                }
            }
        }
    }
}