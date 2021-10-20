// Modified by Jong-Young Choi
// ---------------

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
            if(vertexNumber >= vertices.Length || vertexNumber < 0) throw Exception("Invalid vertexNumber.");
            vertices[vertexNumber] = vertexData;
        }

        public void addEdge(int vertex1, int vertex2)
        {
            if(vertex1 == vertex2) throw Exception("Do not input loop");
            if(vertex1 >= vertices.Length || vertex1 < 0) throw Exception("Invalid vertex1 number.");
            if(vertex2 >= vertices.Length || vertex2 < 0) throw Exception("Invalid vertex2 number.");
            edges[vertex1, vertex2] = true;
            edges[vertex2, vertex1] = true;
        }
        public void removeEdge(int vertex1, int vertex2)
        {
            // It is about removing. It is not necessary to check loop.
            if(vertex1 >= vertices.Length || vertex1 < 0) throw Exception("Invalid vertex1 number.");
            if(vertex2 >= vertices.Length || vertex2 < 0) throw Exception("Invalid vertex2 number.");
            edges[vertex1, vertex2] = false;
            edges[vertex2, vertex1] = false;
        }
        public bool hasEdge(int vertex1, int vertex2)
        {
            if(edges[vertex1, vertex2] == true) return true;
            else return false;
        }
        public object getVertexData(int vertexNumber)
        {
            if (vertexNumber >= vertices.Length || vertexNumber < 0) throw Exception("Invalid vertexNumber.");
            return vertices[vertexNumber];
        }
        public int getNumVertices()
        {
            return vertices.Length;
        }
        public bool isConnected()
        {
            // TODO
            return false;
        }
        public bool hasCycle()
        {
            // TODO
            return false;
        }
        public bool isTree()
        {
            // TODO
            return false;
        }
        
        protected Exception Exception(string s)
        {
            Console.WriteLine(s);
            throw new NotImplementedException();
        }

        private int[] DFS(int a)
        {
            int[] verticeDFS = new object[vertices.Length];
            int order = 1;
            DFS_Recursive(0, verticeDFS, order);
            return verticeDFS;
        }

        private void DFS_Recursive(int index, int[] verticeArray, ref int order)
        {
            verticeArray[index] = order;
            order++;
            for(int i=0; i<vertices.Length; i++)
            {
                if(index == i) continue;
                if(edges[index,i] == true)
                {
                    DFS_Recursive(i, verticeArray, order);
                }
            }
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
    } // end class Graph
} // end namespace testLab2
