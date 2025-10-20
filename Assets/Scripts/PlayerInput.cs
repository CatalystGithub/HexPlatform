using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour
{
    private Camera cam;
    public GameObject playerObj;

    void Start()
    {
        cam = Camera.main;
        SetPlayerPosition(0, 1);
    }

    private void SetPlayerPosition(int x, int y)
    {
        Vector3 pos = HexMetrics.HexToWorld(x, y);
        pos.y = 2;
        playerObj.transform.position = pos;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Eğer UI'nin üzerindeysek tıklamayı görmezden gel
            if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
                return;

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                HexObject block = hit.collider.GetComponent<HexObject>();
                if (block != null)
                {
                    SetPlayerPosition(block.tile.x, block.tile.y);
                    block.OnClicked();
                }
            }
        }
    }
}
