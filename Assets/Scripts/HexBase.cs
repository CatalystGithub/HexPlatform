using UnityEngine;

// Bu sınıf ayrıca env nesneleri için konteyner görevi de görür
public class HexBase : MonoBehaviour
{
    public TileData tileData;

    public virtual void OnClicked()
    {
        Debug.Log($"Bu blok tıklandı! {tileData.x}, {tileData.y}");
    }
}
