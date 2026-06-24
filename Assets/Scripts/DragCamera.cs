using UnityEngine;
using UnityEngine.EventSystems;

public class DragCamera : MonoBehaviour, IDragHandler
{
    public GameManager gm;
    public PlacementSystem pS;
    public BldShop shop;
    public Camera mainCam;
    public Vector2 newMove;
    public Canvas canvas;
    public Vector3 camPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!shop.building)
        {

        }    
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!shop.building)
        {
            newMove += eventData.delta / canvas.scaleFactor;
        }
    }
}
