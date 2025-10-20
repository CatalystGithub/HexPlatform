using UnityEngine;

public class WorldBuilder : MonoBehaviour
{
    private Tile[,] tileMap;
    public int sizeX;
    public int sizeY;

    public HexObject hexPrefab;

    private void Start()
    {
        tileMap = CreateDefaultMap();
        for (int y = 0; y < sizeY; y++)
        {
            for (int x = 0; x < sizeX; x++)
            {
                var ho = Instantiate(hexPrefab);
                ho.transform.position = HexMetrics.HexToWorld(x, y);
                ho.transform.SetParent(transform);
                ho.tile = tileMap[x, y];
            }
        }
    }

    private Tile[,] CreateDefaultMap()
    {
        var tm = new Tile[sizeX, sizeY];

        for (int y = 0; y < sizeY; y++)
        {
            for (int x = 0; x < sizeX; x++)
            {
                tm[x, y] = new Tile(x, y);
            }
        }

        return tm;
    }

}