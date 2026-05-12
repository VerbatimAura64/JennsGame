using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BldShop : MonoBehaviour
{
    #region Variables
    [Header("Shop Variables")]
    public GameManager gM;
    public Blding bM;
    public GameObject shopPanel;
    //[SerializeField]
    public GameObject shopButton;
    //[SerializeField]
    public GameObject exampleButton;
    public bool shopping;
    public bool building;
    public int unlockLevelNeeded;
    public bool unlockable;
    public int costToUnlock;
    public float timeToBuildCompletion;
    public string bldngType;
    public int bldngLimit;
    #endregion

    [System.Serializable]
    public class BldingInfo
    {
        public GameObject bldObj;
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
        public GameObject[] buttons;
    }

    public BldingList bldingList = new();
    #endregion
    
    
    //public GameObject[] buildings;

    void Awake()
    {
        gM = GameObject.Find("GM").GetComponent<GameManager>();
        bldingList.shop = new BldingInfo[gM.buildings.Length];
        
        for (int i = 0; i < gM.buildings.Length; i++)
        {
            bM = gM.buildings[i].gameObject.GetComponent<Blding>();
            bldingList.shop[i] = new BldingInfo
            {
                bldObj = gM.buildings[i],
                //bldClass = bM.bldClass,
                bldClass = (BldingInfo.BldingClass)gM.buildings[i].GetComponent<Blding>().bldClass,
                bldingLvl = bM.bldingLvl,
                unlockLevel = bM.bldingLvl,
                unlockCost = bM.unlockCost,
                buildTime = bM.buildTime,
                prodTime = bM.prodTime,
                product = bM.product,
                prodNum = bM.prodNum
            };
        }
        shopPanel.SetActive(false);
    }
    public void Start()
    {
       //shopPanel.SetActive(false);
    }
    public void BuildThis()
    {
        shopPanel.SetActive(false);
        shopButton.SetActive(true);
        shopping = false;
        building = true;

    }

    private void LoadShop()
    {
        shopPanel.SetActive(true);
        bldingList.buttons = new GameObject[gM.buildings.Length];
        for (int i = 0; i < gM.buildings.Length; i++)
        {
            bldingList.buttons[i] = GameObject.Find("BuildingBtn (" + i + ")");
            bldingList.buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = bldingList.shop[i].bldObj.name;
            //exampleButton.GetComponent<Blding>().bldObj = bldingList.shop[i].bldObj;
            //exampleButton.GetComponent<Button>().GetComponentInChildren<Text>().text = bldingList.shop[0].bldObj.name;


            //bldingList.buttons[i] = shopPanel.transform.GetChild(i).gameObject;
            //bldingList.buttons[i].GetComponent<Button>().GetComponentInChildren<Text>().text = bldingList.shop[i].bldObj.name;
        }
        
        
        //bldingList.shop = new 
        //for (int i = 0; i < buildings.Length; i++)
        {

        }
    }

    public void OpenShop()
    {
        LoadShop();
        shopButton.SetActive(false);
        shopPanel.SetActive(true);
        shopping = true;
    }

    public void CloseShop()
    {
        shopPanel.SetActive(false);
        shopButton.SetActive(true);
        shopping = false;
    }

    //[SerializeField]

    private void IsUnlockable()
    {
        //for (int i = 0; i < buildings.Length; i++)
        {
            //bm = buildings[i].GetComponent<BuildingManager>();
            //unlockLevelNeeded = bm.unlockLevel;
            if (gM.playerLevel >= unlockLevelNeeded)
            {
                //buildings[i];//.IsUnlockable = true;
            }
        }
    }
}
/*

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BldShop : MonoBehaviour
{
    #region Variables
    [Header("Shop Variables")]
    public GameManager gM;
    public Blding bM;
    public GameObject shopPanel;
    [SerializeField]
    private Button shopButton;
    [SerializeField]
    private Button exampleButton;
    public bool shopping;
    public bool building;
    public int unlockLevelNeeded;
    public bool unlockable;
    public int costToUnlock;
    public float timeToBuildCompletion;
    public string bldngType;
    public int bldngLimit;
    #endregion

    #region Lists
    [System.Serializable]
    public class BldingList
    {
        public BldingInfo[] shop;
        public Button[] buttons;
    }

    public BldingList bldingList = new();
    #endregion


    //public GameObject[] buildings;

    void Awake()
    {
        gM = GameObject.Find("GM").GetComponent<GameManager>();
        bldingList.shop = new BldingInfo[gM.buildings.Length];
        bldingList.buttons = new Button[gM.buildings.Length];

        for (int i = 0; i < gM.buildings.Length; i++)
        {
            //bldingList.buttons[i] = shopPanel.transform.GetChild(i).GetComponent<Button>();
            bM = gM.buildings[i].GetComponent<Blding>();
            bldingList.shop[i] = new BldingInfo
            {
                bldObj = gM.buildings[i].gameObject,
                //bldClass = bM.bldClass,
                bldClass = (BldingInfo.BldingClass)gM.buildings[i].GetComponent<Blding>().bldClass,
                bldingLvl = bM.bldingLvl,
                //unlockLevelNeeded = bM.unlockLevel,
                //unlockCost = bM.unlockCost,
                //buildTime = bM.buildTime,
                prodTime = bM.timeToProd,
                product = bM.product,
                prodNum = bM.prodNum
            };
        }
        shopPanel.SetActive(false);
    }
    public void Start()
    {
        //shopPanel.SetActive(false);
    }

    public void BuildThis()
    {
        shopPanel.SetActive(false);
        shopButton.enabled = true;
        shopping = false;
        building = true;

    }

    private void loadShop()
    {
        //bldingList.shop = new 
        //for (int i = 0; i < buildings.Length; i++)
        {

        }
    }

    public void OpenShop()
    {
        loadShop();
        shopButton.enabled = false;
        shopPanel.SetActive(true);
        shopping = true;
    }

    public void CloseShop()
    {
        shopPanel.SetActive(false);
        shopButton.enabled = true;
        shopping = false;
    }

    //[SerializeField]

    private void IsUnlockable()
    {
        //for (int i = 0; i < buildings.Length; i++)
        {
            //bm = buildings[i].GetComponent<BuildingManager>();
            //unlockLevelNeeded = bm.unlockLevel;
            if (gM.playerLevel >= unlockLevelNeeded)
            {
                //buildings[i];//.IsUnlockable = true;
            }
        }
    }
}
*/