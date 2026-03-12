using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridTest : MonoBehaviour
{
    public GameManager GM;
    public BldShop bldShop;
    public bool shopping;
    public GameObject house;
    public GameObject bldPrefab;
    public Grid grid;
    public GridInputTest gridInput;    
    
    void Awake()
    {
        gridInput = GetComponent<GridInputTest>();
        grid = this.gameObject.GetComponent<Grid>();
        
    }

    // Update is called once per frame
    void Update()
    {
     Vector3 selectedPosition = gridInput.GetSelectedMapPosition();
     Vector3Int cellPosition = grid.WorldToCell(selectedPosition);
     house.transform.position = grid.GetCellCenterWorld(cellPosition);

     if(gridInput.GetPlacementInput())
     {
        Instantiate(bldPrefab, house.transform.position, Quaternion.identity);
     }
     
    }
}