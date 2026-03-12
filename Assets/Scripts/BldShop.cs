using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BldShop : MonoBehaviour
{
    public GameManager gm;
    public BuildingManager bm;

    //[SerializeField]
    #region
    public GameObject[] buildings;
    public int unlockLevelNeeded;
    public bool unlockable;
    public int costToUnlock;
    public float timeToBuildCompletion;
    public string bldngType;
    public int bldngLimit;
    #endregion

    void Awake()
    {

    }


    private void IsUnlockable()
    {
        for (int i = 0; i < buildings.Length; i++)
        {
            //bm = buildings[i].GetComponent<BuildingManager>();
            //unlockLevelNeeded = bm.unlockLevel;
            if (gm.playerLevel >= unlockLevelNeeded)
            {
                //buildings[i];//.IsUnlockable = true;
            }
        }
    }
}
