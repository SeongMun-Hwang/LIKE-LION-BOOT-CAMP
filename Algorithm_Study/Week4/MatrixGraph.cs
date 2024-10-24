using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class MatrixGraph
{
    int vertices;
    int[,] adjacencyMatrix;
    bool[] visited;

    public MatrixGraph(int vertices)
    {
        this.vertices = vertices;
        adjacencyMatrix = new int[vertices, vertices];
        visited = new bool[vertices];
    }
    public void AddEdge(int m, int n, int wegiht)
    {
        adjacencyMatrix[m, n] = wegiht;
        adjacencyMatrix[n, m] = wegiht;
    }
    public void ResetVisted()
    {
        for(int i=0; i < vertices; i++)
        {
            visited[i] = false;
        }
    }
    public void DFS(int startIndex)
    {
        visited[startIndex] = true;
        Console.WriteLine(startIndex + " ");
        for(int i=0; i < vertices; i++)
        {
            if (adjacencyMatrix[startIndex,i]>0 && !visited[i])
            {
                DFS(i);
            }
        }
    }
    public void BFS(int startIndex)
    {
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(startIndex);

        while(queue.Count > 0)
        {
            int vertex=queue.Dequeue();
            Console.Write(vertex+" ");

            for(int i=0; i < vertices; i++)
            {
                if (adjacencyMatrix[vertex, i] > 0 && !visited[i])
                {
                    visited[i] = true;
                    queue.Enqueue(i);
                }
            }
        }
    }
}