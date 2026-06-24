using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlacementSystem : MonoBehaviour
{
    public GameObject mouseIndicator, cellIndicator, bldPrefab;
    public GridInputTest inputManager;
    public Grid grid;
    public BldShop shop;

    private void Update()
    {
        Vector3 mousePosition = inputManager.GetSelectedMapPosition();
        Vector3Int cellPosition = grid.WorldToCell(mousePosition);
        if (shop.building)
        {
            cellIndicator.SetActive(true);
            mouseIndicator.transform.position = mousePosition;
            cellIndicator.transform.position = grid.CellToWorld(cellPosition);
        }
        
        if (inputManager.GetPlacementInput())
        {
            bldPrefab.GetComponent<Blding>().building = true;
            Instantiate(bldPrefab, cellIndicator.transform.position, Quaternion.identity);
            
            cellIndicator.SetActive(false);
            shop.grid.SetActive(false);
        }
    }
}
