using UnityEngine;

public class GridTest : MonoBehaviour
{
    public GameObject house, bldPrefab;
    public Grid grid;
    public GridTestInput gridInput;

    // Update is called once per frame
    void Update()
    {
        Vector3 selectedPosition = gridInput.GetSelectedMapPosition();
        Vector3Int cellPosition = grid.WorldToCell(selectedPosition);
        house.transform.position = grid.GetCellCenterWorld(cellPosition);

        if (gridInput.GetPlacementInput())
        {
            Instantiate(bldPrefab, house.transform.position, Quaternion.identity);
        }
    }
}
