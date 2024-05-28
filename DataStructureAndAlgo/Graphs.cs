using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgo
{
    public class GraphsRunner
    {
        public void MainMethod()
        {
            Graphs graph = new Graphs(5);
            graph.AddVertices(0, 1);
            graph.AddVertices(0, 2);
            graph.AddVertices(1, 3);
            graph.AddVertices(1, 4);
            graph.AddVertices(2, 4);


            Console.Write("BFS");
            graph.BFS(0);

            Console.Write("DFS");
            graph.DFS(0, new bool[5]);
        }
    }
    public class Graphs
    {
        int totalVertices;
        List<int>[] Edges;
        
        public Graphs(int verticesCount)
        {
            totalVertices = verticesCount;
            Edges = new List<int>[verticesCount];
            for (int i = 0; i < verticesCount; i++)
            {
                Edges[i]= new List<int>();
            }
        }

        public void AddVertices(int first, int second)
        {
            Edges[first].Add(second);
        }

        public void BFS(int startNode)
        {
            Queue<int> queue = new Queue<int>();
            bool[] visited = new bool[totalVertices];

            queue.Enqueue(startNode);
            visited[startNode] = true;

            while (queue.Count != 0)
            {
                int currentNode = queue.Dequeue();
                Console.Write(currentNode + " ");

                foreach(var item in Edges[currentNode])
                {
                    if (!visited[item])
                    {
                        queue.Enqueue(item);
                        visited[item] = true;
                    }
                }

            }
        }

        public void DFS(int startNode, bool[] visited)
        {
            visited[startNode] = true;
            Console.Write(startNode + " ");

            List<int> vs = Edges[startNode];
            foreach (var item in vs)
            {
                if (!visited[item])
                {
                    DFS(item, visited);
                }
            }
        }


    }
}
