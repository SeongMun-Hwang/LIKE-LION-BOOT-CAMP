using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Graph
{
    public class Node
    {
        public int vertex;
        public int weight;

        public Node(int vertex, int weight)
        {
            this.vertex = vertex;
            this.weight = weight;
        }
    }

    int vertices;
    List<Node>[] adjacencyList;
    bool[] visited;

    public Graph(int v)
    {
        vertices = v;
        adjacencyList = new List<Node>[vertices];
        for (int i = 0; i < v; i++)
        {
            adjacencyList[i] = new List<Node>();
        }
        visited = new bool[vertices];
    }
    public void AddEdge(int v, int w, int weight)
    {
        adjacencyList[v].Add(new Node(w, weight));
        adjacencyList[w].Add(new Node(v, weight));
    }
    public void PrintGraph()
    {
        for (int i = 0; i < vertices; i++)
        {
            Console.Write("Vertex " + i + " : ");
            foreach (Node node in adjacencyList[i])
            {
                Console.Write(" -> " + node.vertex + " (" + node.weight + ")");
            }
            Console.WriteLine();
        }
    }
    public void ResetVisited()
    {
        for (int i = 0; i < vertices; i++)
        {
            visited[i] = false;
        }
    }
    public void DFS(int startVertex)
    {
        visited[startVertex] = true;
        Console.Write(startVertex + " ");

        foreach (Node node in adjacencyList[startVertex])
        {
            if (!visited[node.vertex])
            {
                Console.Write("(" + node.weight + ")-");
                DFS(node.vertex);
            }
        }
    }
    public void BFS(int startVertex)
    {
        Queue<int> queue = new Queue<int>();
        visited[startVertex] = true;

        queue.Enqueue(startVertex);
        while (queue.Count > 0)
        {
            int vertex = queue.Dequeue();
            Console.Write(vertex);

            foreach (Node node in adjacencyList[vertex])
            {
                if (!visited[node.vertex])
                {
                    visited[node.vertex] = true;
                    Console.Write("(" + node.weight + ")-");

                    queue.Enqueue(node.vertex);
                }
            }
        }
    }
    public void PrimNST()
    {
        bool[] mstSet = new bool[vertices];
        int[] key = new int[vertices];
        int[] parent = new int[vertices];

        for (int i = 0; i < vertices; i++)
        {
            key[i] = int.MaxValue;
            parent[i] = -1;
        }
        key[0] = 0;
        for (int count = 0; count < vertices - 1; count++)
        {
            int u = MinKey(key, mstSet);
            mstSet[u] = true;

            foreach (Node node in adjacencyList[u])
            {
                int v = node.vertex;
                int weight = node.weight;

                if (!mstSet[v] && weight < key[v])
                {
                    parent[v] = u;
                    key[v] = weight;
                }
            }
            Console.WriteLine("Edge \tWeight");
            for (int i = 1; i < vertices; i++)
            {
                if (parent[i] != -1)
                {
                    Console.WriteLine(parent[i] + " - " + i + "\t" + key[i]);
                }
            }
        }
        int MinKey(int[] key, bool[] mstSet)
        {
            int min = int.MaxValue;
            int minIndex = -1;

            for (int i = 0; i < vertices; i++)
            {
                if (!mstSet[i] && key[i] < min)
                {
                    min = key[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }
    }
}