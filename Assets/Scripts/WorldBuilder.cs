using UnityEngine;

public class WorldBuilder : MonoBehaviour
{
    [Header("References")]
    public PlayerInput input;

    private TileData[,] tileMap;

    [Header("Testing values")]
    public HexBase hex_grass;
    public Character playerInstance;
    public Resource res_tree;

    public int sizeX;
    public int sizeY;

    private void Awake()
    {
        CreateSampleLevel();
    }

    // Önce tile verisini oluştur
    // Tile içlerine enviroment ekle (kaynak, karakter, sandık)
    // Oyuncuyu ekle
    // Haritayı görselleştir

    public void CreateSampleLevel()
    {
        tileMap = new TileData[sizeX, sizeY]; 
        CreateHexes();
        AddRandomTrees();
        var player = DeployEnv(tileMap[0, 1], playerInstance);
        input.playerObj = player;
    }

    private void AddRandomTrees()
    {
        int trees = 3;

        for (int i = 0; i < trees;)
        {
            int rx = Random.Range(3, sizeX);
            int ry = Random.Range(0, sizeY);

            if (tileMap[rx, ry].HasEnvironment) continue;
            DeployEnv(tileMap[rx, ry], res_tree);
            i++;
        }
    }

    private void CreateHexes()
    {
        for (int y = 0; y < sizeY; y++)
        {
            for (int x = 0; x < sizeX; x++)
            {
                TileData td = new TileData(x, y);
                tileMap[x, y] = td;

                HexBase hexObj = Instantiate(hex_grass);
                hexObj.transform.SetParent(transform);
                hexObj.transform.position = HexMetrics.HexToWorld(td.x, td.y);
                hexObj.tileData = td;
                td.hex = hexObj;
            }
        }
    }

    private T DeployEnv<T>(TileData target, T env) where T : EnvironmentBase
    {
        if(target.env != null)
        {
            Debug.Log("This tile is not empty!");
            return null;
        }
        T envObj = Instantiate(env);
        envObj.transform.SetParent(target.hex.transform);
        envObj.transform.localPosition = Vector3.zero;
        target.env = envObj;
        return envObj;
    }
}