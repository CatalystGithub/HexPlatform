using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour
{
    private Camera cam;
    public CameraFollow cameraFollow;
    public Character playerObj;

    void Start()
    {
        cam = Camera.main;
        MovePlayer(0, 1);
        cameraFollow.target = playerObj.transform;
    }

    private void MovePlayer(int x, int y)
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
                HexBase block = hit.collider.GetComponent<HexBase>();
                if (block != null)
                {
                    MovePlayer(block.tileData.x, block.tileData.y);
                    block.OnClicked();
                }
            }
        }
    }
}
