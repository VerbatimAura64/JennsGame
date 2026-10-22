using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
    public struct ResourceCost
    {
        public ResourceType resource;
        public int amount;
    }
[System.Serializable]
public class Blding : MonoBehaviour
{
    
    public enum BldingClass
    {
        Housing,
        Resource,
        Storage,
        Farm
    }

    public GameObject bldObj;
    private GameManager gM;
    [Header("Shared Building Variables")]
    public BldingClass bldClass;
    public ResourceType resource;
    public int bldingLvl;
    public bool built;
    public int unlockLevel;
    public bool unlocked;

    [Header("Timers and Bools")]
    public bool building;
    public float buildTime;
    public List<ResourceCost> buildCost;
    public float prodTime;
    public float timeToProd;
    public int prodNum;
    public bool producing;

    public float consumptionTime;
    public List<ResourceCost> consumptionCost;
    public int storageLimit;

    [Header("Resource Workers")]
    public int workersNeeded;


    [Header("UI Elements")]
    public GameObject notif;


    
    void Awake()
    {
        bldObj = this.gameObject;
    }

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
                }
                if(bldClass == BldingClass.Housing)
                {
                    gM.UpdateHousing(consumptionCost[0].amount);
                }
                if(bldClass == BldingClass.Resource) 
                { 
                    gM.resourceBuildings.Add(this.gameObject);
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
                    DepleteFood(consumptionCost);
                    break;
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
                break;
            case BldingClass.Farm:
                if (built)
                {
                    GenerateResource();//bldClass);
                    if (producing)
                    {
                        timeToProd += Time.deltaTime;
                    }
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

    void DepleteFood(List<ResourceCost> cost)//List<ResourceCost> cost)
    {
        consumptionTime += Time.deltaTime;
        if (consumptionTime >= prodTime)
        {
            //Debug.Log(timeToProd);
            
            foreach (var resource in cost)
            {
                gM.inventory[resource.resource] -= resource.amount;
                gM.inventory[resource.resource] = Mathf.Max(0, gM.inventory[resource.resource]);
            }
            consumptionTime = 0;
            
            //notif.SetActive(true);
            //OnPointerClick(
            //Reset timer
            //Add resource to bar
            //Reset production);
        }
       
        //
    }

    /*public void ResetFoodProduction()
    {
        //Check This Building's class and add the appropriate resource to the GameManager's storage
        if (gM.CanStoreResource(ResourceType.Food, prodNum))
        {
            timeToProd = 0;
            //gM.EarnMoney(prodNum);
        }
        
    }*/

    public void ResetProduction()
    {
        //Check This Building's class and add the appropriate resource to the GameManager's storage
        if (gM.CanStoreResource(resource, prodNum))
        {
            timeToProd = 0;
            //gM.EarnMoney(prodNum);
        }

    }




}