
// Oyun esnasında hex ve environment verilerini taşıyacak veri konteyneri

[System.Serializable]
public class TileData
{
    public int x;
    public int y;
    public HexBase hex;
    public EnvironmentBase env;

    public bool HasEnvironment => env != null;

    public TileData(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}