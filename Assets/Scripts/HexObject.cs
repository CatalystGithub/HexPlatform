using UnityEngine;

public class HexObject : MonoBehaviour
{
    public Tile tile;

    public void OnClicked()
    {
        Debug.Log($"Bu blok tıklandı! {tile.x}, {tile.y}");
    }
}
