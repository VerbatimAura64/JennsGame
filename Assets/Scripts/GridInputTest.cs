using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridInputTest : MonoBehaviour
{
    public Camera sceneCamera;
    private Vector3 m_lastPosition;
    public LayerMask placementLayerMask;
    public BldShop shop;
    //[HideInInspector]

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
    {
        if (!shop.shopping)
        {
            if (Input.GetMouseButtonDown(0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }

    }
         
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
}
