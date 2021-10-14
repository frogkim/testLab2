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
            //Do not allow loops!!
            if(vertex1 == vertex2) throw Exception("Do not input loop");
            edges[vertex1, vertex2] = 1;
            edges[vertex2, vertex1] = 1;
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
            return vertices.Length;
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
            string ret = "";
            ret += "This graph has " + getNumVertices() + " verticies.";
            ret += "\r\n";
            ret += "This vertex information is as follows: ";
            for(int i = 0; i < getNumVertices(); i++)
            {
                ret += "\r\n";
                ret += "vertex #" + i + " contains " + vertices[i];
            }
            ret += "\r\n";
            ret += "The edge are as follows";
            bool atLeastOneEdgeExists = false;
            for(int i = 0; i < getNumVertices(); i++)
            {
                for(int j = 0; j < i; j ++)
                {
                    if(hasEdge(i, j))
                    {
                        ret += "\r\n";
                        ret += "{" + i + "," + j + "}";
                    }
                }
            }
            if(!atLeastOneEdgeExists)
            {
                ret += "\r\n";
                ret += "NO EDGES TO SEE!";
            }
            return ret;
        }
    }
}
