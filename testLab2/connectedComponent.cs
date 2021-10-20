namespace testLab2
{
    class test2
    {
        public static int connectedComponent(Graph g)
        {
            int count = 0;
            int[] vertex = new int[g.getNumVertices()];

            for(int i = 0; i < g.getNumVertices()-1; i++)
            {
                if(vertex[i] == 0)
                {
                    count++;
                    int tmp[] = DFS(g, i);
                    for(int j = i; j < g.getNumVertices(); j++)
                    {
                        vertex[j] = vertex[j] + tmp[j];
                        //vertex[j] = vertex[j] + tmp[j];
                    }
                }
            }
            return count;
        }

        int[] DFS(Graph g, int start)
        {
            int order = 0;
            int[] vertexTmp = new int[g.getNumVertices()];
            DFS_Recursive(g, start, vertexTmp, ref order);

            return tmp;
        }

        void DFS_Recursive(Graph g, int start, int[] vertexTmp, ref int order)
        {
            for(int i = start+1; i < g.getNumVertices(); i++)
            {
                if (g.hasEdge(start, i))
                {

                }
            }
            
        }
    }
}