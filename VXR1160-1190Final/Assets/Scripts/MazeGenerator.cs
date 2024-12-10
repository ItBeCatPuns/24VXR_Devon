using UnityEngine;
using System.Collections.Generic;

public class MazeGenerator : MonoBehaviour
{
    public int width = 10; // Maze width
    public int height = 10; // Maze height
    public GameObject wallPrefab; // Prefab for walls
    public GameObject pathPrefab; // Prefab for regular pathways
    public GameObject correctPathPrefab; // Prefab for the correct path
    public float cellSize = 1.0f; // Size of each cell

    private int[,] maze; // 0 = Path, 1 = Wall
    private List<Vector2Int> solutionPath; // List to store the correct path

    void Start()
    {
        GenerateMaze();
        DrawMaze();
    }

    void GenerateMaze()
    {
        maze = new int[width, height];
        solutionPath = new List<Vector2Int>();

        // Initialize all cells as walls
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                maze[x, y] = 1;
            }
        }

        // Define entrance and exit
        Vector2Int entrance = new Vector2Int(0, height - 3); // 2 cells down from the top-left corner
        Vector2Int exit = new Vector2Int(width - 3, 0); // 2 cells left of the bottom-right corner

        // Ensure (width - 3, 1) is a path
        Vector2Int guaranteedPathCell = new Vector2Int(width - 3, 1);
        maze[guaranteedPathCell.x, guaranteedPathCell.y] = 0;

        // Clear entrance and exit
        maze[entrance.x, entrance.y] = 0;
        maze[exit.x, exit.y] = 0;

        // Start the maze generation and mark the solution path
        Stack<Vector2Int> stack = new Stack<Vector2Int>();
        stack.Push(entrance);
        maze[entrance.x, entrance.y] = 0;
        solutionPath.Add(entrance);

        while (stack.Count > 0)
        {
            Vector2Int current = stack.Peek();
            if (current == exit)
            {
                break; // Exit reached, solution path is complete
            }

            List<Vector2Int> neighbors = GetUnvisitedNeighbors(current);

            if (neighbors.Count > 0)
            {
                Vector2Int chosen = neighbors[Random.Range(0, neighbors.Count)];
                maze[(current.x + chosen.x) / 2, (current.y + chosen.y) / 2] = 0; // Remove wall between cells
                maze[chosen.x, chosen.y] = 0;
                stack.Push(chosen);
                solutionPath.Add(chosen);
            }
            else
            {
                stack.Pop();
            }
        }

        // Ensure a single solid border
        CreateSolidBorder(entrance, exit, guaranteedPathCell);
    }

    void CreateSolidBorder(Vector2Int entrance, Vector2Int exit, Vector2Int guaranteedPathCell)
    {
        for (int x = 0; x < width; x++)
        {
            maze[x, 0] = 1; // Bottom edge
            maze[x, height - 1] = 1; // Top edge
        }
        for (int y = 0; y < height; y++)
        {
            maze[0, y] = 1; // Left edge
            maze[width - 1, y] = 1; // Right edge
        }

        // Keep entrance, exit, and guaranteed path cell clear
        maze[entrance.x, entrance.y] = 0;
        maze[exit.x, exit.y] = 0;
        maze[guaranteedPathCell.x, guaranteedPathCell.y] = 0;
    }

    List<Vector2Int> GetUnvisitedNeighbors(Vector2Int cell)
    {
        List<Vector2Int> neighbors = new List<Vector2Int>();

        // Directions: Up, Down, Left, Right
        Vector2Int[] directions = {
            new Vector2Int(0, 2),
            new Vector2Int(0, -2),
            new Vector2Int(-2, 0),
            new Vector2Int(2, 0)
        };

        foreach (var dir in directions)
        {
            Vector2Int neighbor = cell + dir;
            if (neighbor.x > 0 && neighbor.x < width - 1 && neighbor.y > 0 && neighbor.y < height - 1 && maze[neighbor.x, neighbor.y] == 1)
            {
                neighbors.Add(neighbor);
            }
        }

        return neighbors;
    }

    void DrawMaze()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject prefab;

                // Check if this cell is part of the correct path
                if (solutionPath.Contains(new Vector2Int(x, y)))
                {
                    prefab = correctPathPrefab; // Use correct path prefab
                }
                else if (maze[x, y] == 0)
                {
                    prefab = pathPrefab; // Use regular path prefab
                }
                else
                {
                    prefab = wallPrefab; // Use wall prefab
                }

                Instantiate(prefab, new Vector3(x * cellSize, 0, y * cellSize), Quaternion.identity, transform);
            }
        }
    }
}
