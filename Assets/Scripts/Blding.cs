using UnityEngine;

public class Blding : MonoBehaviour
{
    public GameObject bldObj;
    public enum BldingClass
    {
        Housing,
        Resource,
        Storage,
        Farm
    }
    private GameManager gM;
    public BldingClass bldClass;
    public int bldingLvl;
    public int unlockCost;
    public int unlockLevel;
    public float buildTime;
    public float prodTime;
    public float timeToProd;
    public GameObject product;
    public int prodNum;
    public bool built;
    public bool building;
    public bool producing;
    public GameObject notif;

    void Awake()
    {
        bldObj = this.gameObject;
    }

    /*[System.Serializable]
    public class BldingInfo
    {

      //  [System.Serializable]
        
    }*/

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        building = true;
        gM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(building)
        {
            if (buildTime <= 0)
            {
                building = false;
                built = true;
            }
            else
            {
                buildTime -= Time.deltaTime;
            }
        }
        if (bldClass == BldingClass.Resource && built)
        {
            GenerateResource();//bldClass);
            if (producing)
            {
                timeToProd += Time.deltaTime;
            }
        }
        
    }

    void GenerateResource()//BldingClass bldClass)
    {
 
        if (timeToProd >= prodTime)
        {
            //Debug.Log(timeToProd);
            producing = false;
            notif.SetActive(true);
            //OnPointerClick(
            //Reset timer
            //Add resource to bar
            //Reset production);
        } else
        {
            producing = true;
            notif.SetActive(false);
        }
        
       
    }

    public void ResetProduction()
    {
        if(gM.CanStoreFood(prodNum))
        {
            timeToProd = 0;
        }
        
    }




}