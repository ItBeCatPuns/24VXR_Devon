using UnityEngine;
using System.Collections.Generic;

public class MazeGenerator : MonoBehaviour
{
    public int width = 10; // Maze width
    public int height = 10; // Maze height
    public GameObject wallPrefab; // Prefab for walls
    public GameObject pathPrefab; // Prefab for regular pathways
    public GameObject keyPrefab; // Prefab for the key
    public float cellSize = 1.0f; // Size of each cell

    private int[,] maze; // 0 = Path, 1 = Wall

    void Start()
    {
        GenerateMaze();
        DrawMaze();
    }

    void GenerateMaze()
    {
        maze = new int[width, height];

        // Initialize all cells as walls
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                maze[x, y] = 1;
            }
        }

        // Ensure the exit block is not blocked by random generation
        Vector2Int guaranteedPathCell = new Vector2Int(width - 3, 1);
        maze[guaranteedPathCell.x, guaranteedPathCell.y] = 0;

        // Define entrance, exit, and key location
        Vector2Int entrance = new Vector2Int(0, height - 3); // 2 cells down from the top-left corner
        Vector2Int exit = new Vector2Int(width - 3, 0); // 2 cells left of the bottom-right corner
        Vector2Int keyLocation = new Vector2Int(width / 2, height / 2); // Key in the center of the maze

        // Clear entrance, exit, and key location
        maze[entrance.x, entrance.y] = 0;
        maze[exit.x, exit.y] = 0;
        maze[keyLocation.x, keyLocation.y] = 0;

        // Start the maze generation
        Stack<Vector2Int> stack = new Stack<Vector2Int>();
        stack.Push(entrance);
        maze[entrance.x, entrance.y] = 0;

        while (stack.Count > 0)
        {
            Vector2Int current = stack.Peek();

            List<Vector2Int> neighbors = GetUnvisitedNeighbors(current);

            if (neighbors.Count > 0)
            {
                Vector2Int chosen = neighbors[Random.Range(0, neighbors.Count)];
                maze[(current.x + chosen.x) / 2, (current.y + chosen.y) / 2] = 0; // Remove wall between cells
                maze[chosen.x, chosen.y] = 0;
                stack.Push(chosen);
            }
            else
            {
                stack.Pop();
            }
        }

        // Ensure a single solid border
        CreateSolidBorder(entrance, exit);
    }

    void CreateSolidBorder(Vector2Int entrance, Vector2Int exit)
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

        // Keep entrance and exit clear
        maze[entrance.x, entrance.y] = 0;
        maze[exit.x, exit.y] = 0;
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
        Vector2Int keyLocation = new Vector2Int(width / 2, height / 2); // Key location in the center

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject prefab;

                if (maze[x, y] == 1) // Wall
                {
                    prefab = wallPrefab;
                }
                else if (x == keyLocation.x && y == keyLocation.y) // Key location
                {
                    prefab = keyPrefab;
                }
                else // Regular path
                {
                    prefab = pathPrefab;
                }

                Instantiate(prefab, new Vector3(x * cellSize, 0, y * cellSize), Quaternion.identity, transform);
            }
        }
    }
}
