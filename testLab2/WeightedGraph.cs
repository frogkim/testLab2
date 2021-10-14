using System;

namespace testLab2
{
    class WeightedGraph : Graph
    {
        private class WeightedEdge : IComparable
        {
            public int vertex1;
            public int vertex2;
            public double weight;

            public WeigtedEdge(int firstVertex, int secondVertex, double theWeight)
            {
                vertex1 = firstVertex;
                vertex2 = secondVertex;
                weight = theWeight;
            }

            public int CompareTo(object other) // other should be of type 
            {
                if(!(other is WeightedEdge))
                {
                    throw new Exception("Type mismatch: cannot compare type WeightedEdge to type " + other.GetType());
                }
                
                WeightedEdge otherEdge = (WeightedEdge)other;
                return weight.CompareTo(otherEdge.weight);
            }
        }

        private double[,] edgeWeights;
        //private object[] vertices; // NO!!!! vertices are inherited!
        public WeightedGraph(int numVertices) : base(numVertices) // base is similar with 'super' in Java. Invoke constructor.
        {
            //vertices = new object[numVertices]; // illegal. vertices array is private. If we chagne private to protected, it works.
            //Also, we declare it, vertices array will lost before data and declared new one.
            edgeWeights = new double[numVertices, numVertices];
            //edgeWeights = new double(numVertices, numVertices);
            
        }

        public double getEdgeWeight(int vertex1, int vertex2)
        {
            // TODO: check whether this request is valid:
            // (0) vertex1 and vertex2 must be valid indexes for edgeWeights
            // (1) there must be an edge from vertex1 to vertex2
            return edgeWeights[vertex1, vertex2];
        }

        public void setEdgeWeight(int vertex1, int vertex2, double theWeight)
        {
            // TODO: check whether this request is valid...
            edgeWeights[vertex1, vertex2] = theWeight;
            edgeWeights[vertex2, vertex1] = theWeight;
        }

        public WeightedGraph minWeightSpanningTree()
        {
            if(!isConnected())
            {
                throw new Exception("Invoking graph is not connected, has no spanning trees!");
            }
            int n = getNumVertices();
            WeightedGraph T = new WeightedGraph(n);
            var edgeArray = new List<WeightedEdge>();
            for(int i=0; i<n; i++)
            {
                for(int j=0; j<n; j++)
                {
                    if(hasEdge(i,j))
                    {
                        edgeArray.Add(new WeightedEdge(i, j, edgeWeights[i,j]));
                    }
                }
            }

            edgeArray.Sort();

            while(!T.isConnected())
            {
                // add next edge of invoking graph to T (already sorted)
                WeightedEdge we = edgeArray[index];
                T.addEdge(we.vertex1, we.vertex2);
                T.edgeWeights[we.vertex1, we.vertex2] = we.weight;
                if(T.hasCycle())
                {
                    T.removeEdge(we.vertex1, we.vertex2);
                }
                index++;
            }
            return T;
        }
    }
}