using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridInputTest : MonoBehaviour
{
    public Camera sceneCamera;
    private Vector3 m_lastPosition;
    public LayerMask placementLayerMask, uILayerMask, bldLayerMask;
    public BldShop shop;
    public GameManager gm;
    public GameObject hitObject;
    //[HideInInspector]


    public Vector3 GetSelectedMapPosition()
    {
        //if (shop.building)
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

    public bool IsPointerOverBuilding()
    {
        
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = sceneCamera.nearClipPlane;
            Ray ray = sceneCamera.ScreenPointToRay(mousePos);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red);
            if (Physics.Raycast(ray, out hit, 1000, bldLayerMask))
            {
                hitObject = hit.transform.gameObject;
                //Debug.LogError(hitObject.GetComponent<Blding>().producing);//Debug.Log("Hit building");
                return true;
            }
        
        
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
            if (Input.GetMouseButtonDown(0) && !IsPointerOverUI() && IsPointerOverBuilding())
            {
                if (hitObject != null)
                {
                    Blding bldingScript = hitObject.GetComponent<Blding>();
                    if (bldingScript != null)
                    {
                        if (!bldingScript.producing && bldingScript.built)
                        {
                            bldingScript.ResetProduction();
                            return true;
                            //Debug.Log("Collected " + bldingScript.prodAmt + " from " + hitObject.name);
                            //gm.EarnMoney(bldingScript.prodAmt);
                        } 
                            //Debug.Log(bldingScript.producing);

                        return false;
                        //bldingScript.notif.SetActive(false);
                        //bldingScript.producing = true;
                        //gm.EarnMoney(bldingScript.prodAmt);
                        //Debug.Log("Collected " + bldingScript.prodAmt + " from " + hitObject.name);
                    }
                    return false;
                }
                //Debug.Log("Clicked on building");
                return false;
                

            }
            else
            {
                return false;
            }
        }
        //else
        {
            //  if (Input.GetMouseButtonDown(0) && !IsPointerOverUI())
            //{ 
            //  if(IsPointerOverBuilding())
            //{
            //  Debug.Log("Clicked on building");
            //return true;
            //}

            //}
            //return false;
        }

    }
         
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
}
