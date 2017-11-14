using UnityEngine;

public class TileMap : MonoBehaviour
{
    public int mapWidth;
    public int mapHeight;
    public int tileSize = 16;

    public float tileSizeFloat { get { return tileSize / 100.0f; } }

    [HideInInspector]
    public Vector3 mousePos;


    public Texture2D sprites;

    public int gridSize;

    void OnDrawGizmos()
    {

        Gizmos.color = Color.grey;
        for (int x = 0; x <= mapWidth; x++)
        {
            Vector3 pos1 = new Vector3(x * tileSizeFloat, 0);
            Vector3 pos2 = new Vector3(x * tileSizeFloat, mapHeight * tileSizeFloat);

            Gizmos.DrawLine(pos1, pos2);
        }

        for (int y = 0; y <= mapHeight; y++)
        {
            Vector3 pos1 = new Vector3(0, y * tileSizeFloat);
            Vector3 pos2 = new Vector3(mapWidth * tileSizeFloat, y * tileSizeFloat);

            Gizmos.DrawLine(pos1, pos2);
        }
    }
}

