using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridInputTest : MonoBehaviour
{
    public Camera sceneCamera;
    private Vector3 m_lastPosition;
    public LayerMask placementLayerMask, uILayerMask;
    public BldShop shop;
    public GameManager gm;
    //[HideInInspector]

    public Vector3 GetSelectedMapPosition()
    {
        if (shop.building)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = sceneCamera.nearClipPlane;
            Ray ray = sceneCamera.ScreenPointToRay(mousePos);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red);
            if (Physics.Raycast(ray, out hit, 1000, placementLayerMask))
            {

                m_lastPosition = hit.point;
            }
        }
            return m_lastPosition;

        
    }

    public bool IsPointerOverUI()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            //Debug.LogError("UI HIT!");
            return true;
        }
        //Debug.LogError("NOT UI!");
        return false;
    }

    public bool GetPlacementInput()
    {
        if (shop.building)
        {
            if (Input.GetMouseButtonDown(0) && !IsPointerOverUI())
            {
                gm.EarnXP();
                shop.building = false;
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
