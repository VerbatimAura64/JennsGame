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
        if(bldClass == BldingClass.Resource && built)
        {
            GenerateResource(bldClass);
            timeToProd += Time.deltaTime;
        }
        
    }

    void GenerateResource(BldingClass bldClass)
    {
        //if (bldClass == BldingClass.Resource)
        {
            if (timeToProd >= prodTime)
            {
                //OnPointerClick(
                //Reset timer
                //Add resource to bar
                //Reset production);
            }
        }
    }





}