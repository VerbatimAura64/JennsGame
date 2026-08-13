using UnityEngine;

public class Blding : MonoBehaviour
{
    
    public enum BldingClass
    {
        Housing,
        Resource,
        Storage,
        Farm
    }
    public enum ResourceType
    {
        Wood,
        Stone
        
    }
    public GameObject bldObj;
    private GameManager gM;
    public BldingClass bldClass;
    public int bldingLvl;
    public int unlockCost;
    public int unlockLevel;
    public int storageLimit;
    public float buildTime;
    public float prodTime;
    public float timeToProd;
    public int prodNum;
    public GameObject product;
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
                if(bldClass == BldingClass.Storage)
                {
                    gM.storageBlds.Add(this.gameObject);
                    gM.UpdateStorage(storageLimit);
                    
                    //storageLimit = 1;
                    //if (gM.storageBlds.Count <= storageLimit)
                    //{
                    //gM.storageBlds.Add(this.gameObject);
                    //gM.UpdateStorage();
                    //}
                }
            }
            else
            {
                buildTime -= Time.deltaTime;
            }
        }
        switch (bldClass)
        {
            case BldingClass.Housing:
                if(built)
                {
                    //gM.AddHousing();
                }
                break;
            case BldingClass.Resource:
                if (built)
                {
                    GenerateResource();//bldClass);
                    if (producing)
                    {
                        timeToProd += Time.deltaTime;
                    }
                }
                break;
            case BldingClass.Storage:
                if (built)
                {
                    
                    
                }
                break;
            case BldingClass.Farm:
                GenerateFood();//bldClass);
                if (producing)
                {
                    timeToProd += Time.deltaTime;
                }
                break;
            default:
                break;
        }
        /*if (bldClass == BldingClass.Resource && built)
        {
            GenerateResource();//bldClass);
            if (producing)
            {
                timeToProd += Time.deltaTime;
            }
        }*/
        
    }

    void GenerateFood()
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
        }
        else
        {
            producing = true;
            notif.SetActive(false);
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
        //Check This Building's class and add the appropriate resource to the GameManager's storage
        if (gM.CanStoreFood(prodNum))
        {
            timeToProd = 0;
        }
        
    }






}