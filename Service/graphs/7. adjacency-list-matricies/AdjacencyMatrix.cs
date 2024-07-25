using System;

public class GraphAdjacencyMatrix
{
    private bool[,] _adjacencyMatrix;
    private int _vertexCount;

    public GraphAdjacencyMatrix(int vertexCount)
    {
        _vertexCount = vertexCount;
        _adjacencyMatrix = new bool[vertexCount, vertexCount];
    }

    public void AddEdge(int vertex1, int vertex2, bool isDirected = false)
    {
        if (vertex1 >= _vertexCount || vertex2 >= _vertexCount || vertex1 < 0 || vertex2 < 0)
        {
            throw new ArgumentException("Vertex index out of bounds.");
        }

        _adjacencyMatrix[vertex1, vertex2] = true;

        if (!isDirected)
        {
            _adjacencyMatrix[vertex2, vertex1] = true;
        }
    }

    public void PrintGraph()
    {
        for (int i = 0; i < _vertexCount; i++)
        {
            for (int j = 0; j < _vertexCount; j++)
            {
                Console.Write(_adjacencyMatrix[i, j] ? "1 " : "0 ");
            }
            Console.WriteLine();
        }
    }
}

