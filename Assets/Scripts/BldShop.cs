using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BldShop : MonoBehaviour
{
    public GameManager gm;
    public BuildingManager bm;
    public GameObject shopPanel;
    public bool shopping;

    public void Start()
    {
       shopPanel.SetActive(false);
    }

    [System.Serializable]
    public class BldingInfo
    {
        public enum BldingClass
        {
            Housing,
            Resource,
            Storage,
            Farm
        }

        public BldingClass bldClass;
        public int bldingLvl;
        public int unlockLevel;
        public int unlockCost;
        public float buildTime;
        public float prodTime;
        public GameObject product;
        public int prodNum;
    }


    #region
    [System.Serializable]
    public class BldingList
    {
        public BldingInfo[] shop;
    }

    public BldingList bldingList = new();
    #endregion


    private void loadShop()
    {

    }

    public void OpenShop()
    {
        shopPanel.SetActive(true);
        shopping = true;
    }

    public void CloseShop()
    {
        shopPanel.SetActive(false);
        shopping = false;
    }

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
