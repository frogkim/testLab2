using System;
using System.Collections.Generic;
using System.Text;

namespace testLab2
{
    class Graph
    {
        private object[] vertices;
        private bool[,] edges;

        public Graph(int numVertices)
        {
            vertices = new object[numVertices];
            edges = new bool[numVertices, numVertices];
        }
        public void addVertexData(int vertexNumber, object vertexData)
        {
            // TO DO: throw an exception if vertexNumber is bad
            vertices[vertexNumber] = vertexData;
        }
        public void addEdge(int vertex1, int vertex2)
        {
        }
        public void removeEdge(int vertex1, int vertex2)
        {
        }
        public bool hasEdge(int vertex1, int vertex2)
        {
            return false;
        }
        public object getVertexData(int vertexNumber)
        {
            // TO DO: throw an exception if vertexNumber is bad
            return vertices[vertexNumber];
        }
        public int getNumVertices()
        {
            return 0;
        }
        public bool isConnected()
        {
            return false;
        }
        public bool hasCycle()
        {
            return false;
        }
        public bool isTree()
        {
            return false;
        }
        public override string ToString()
        {
            return "";
        }
    }
}
