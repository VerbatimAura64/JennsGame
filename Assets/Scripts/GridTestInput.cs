using UnityEngine;

public class GridTestInput : MonoBehaviour
{
    public Camera sceneCamera;
    private Vector3 m_lastPosition;
    public LayerMask placementLayerMask;

    public Vector3 GetSelectedMapPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = sceneCamera.nearClipPlane;
        Ray ray = sceneCamera.ScreenPointToRay(mousePos);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red);
        if(Physics.Raycast(ray, out hit, 1000, placementLayerMask))
        {
            m_lastPosition = hit.point;
        }
        return m_lastPosition;
    }

    public bool GetPlacementInput() 
        => Input.GetMouseButtonDown(0);
}
