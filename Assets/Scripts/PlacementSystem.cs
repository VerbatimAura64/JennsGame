using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlacementSystem : MonoBehaviour
{
    public GameObject mouseIndicator, cellIndicator, bldPrefab;
    public GridInputTest inputManager;
    public Grid grid;

    private void Update()
    {
        Vector3 mousePosition = inputManager.GetSelectedMapPosition();
        Vector3Int cellPosition = grid.WorldToCell(mousePosition);
        mouseIndicator.transform.position = mousePosition;
        cellIndicator.transform.position = grid.CellToWorld(cellPosition);

        if (inputManager.GetPlacementInput())
        {
            Instantiate(bldPrefab, cellIndicator.transform.position, Quaternion.identity);
        }
    }
}
