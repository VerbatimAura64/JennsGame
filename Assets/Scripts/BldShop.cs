using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BldShop : MonoBehaviour
{
    private GameManager gm;

    [SerializeField]
    private GameObject[] buildings;
    private int unlockLevelNeeded;
    private bool unlockable;
    private int costToUnlock;
    private float timeToBuildCompletion;
    private string bldngType;

    void Awake()
    {

    }


    private void IsUnlockable()
    {
        if(gm.playerLevel >= unlockLevelNeeded)
        {
            
        }
    }
}
