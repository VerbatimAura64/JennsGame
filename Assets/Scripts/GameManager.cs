using Mono.Cecil;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditor.iOS;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class GameManager : MonoBehaviour 
{
	[Header("Player Stats")]
    public int playerLevel;
	//public int playerMoney;
	public int xp;
	private int xpNeeded = 30;
	[Header("Resources")]
    public int maxStorage;
	public int woodLevel;
	public int stoneLevel;
	public int foodLevel;
	public float foodMin;

	[Header("Population")]
    
	public int totalPop;
	public int totalWorkers;
	public int availWorkers;
	
	//public int woodLevelMax;
	
	
	public int foodEarned;
	public int foodLevelMax;

	[Header("UI Elements")]
    public Slider xpBar;
	public Slider foodBar;
	public Slider stoneBar;
	public Slider woodBar;
	public TextMeshProUGUI citizenNum;
    public TextMeshProUGUI level;
	[Header("References")]
    public GridInputTest gInput;
    public GameObject[] buildings;
	public List<GameObject> storageBlds;
	public List<GameObject> resourceBuildings;
	public int units;

	public Dictionary<ResourceType, int> inventory = new Dictionary<ResourceType, int>()
	{
        {ResourceType.Food, 0},
		{ResourceType.Wood, 0},
		{ResourceType.Stone, 0},
	};

    private void Start()
    {
        storageBlds = new List<GameObject>();
    }

	private void Update()
	{
		//EarnXP();
		LevelUp();
		StorageValues();
		CheckStorage();
		AssignWorkers();
		
		
	}

	public void UpdateStorage(int amount)
	{
		units += amount;
        if (maxStorage != units)
        {
            maxStorage =  units;
        }
    }

	void CheckStorage()
	{
		foodLevel = inventory[ResourceType.Food];
		foodBar.value = foodLevel;
        stoneLevel = inventory[ResourceType.Stone];
		stoneBar.value = stoneLevel;
        woodLevel = inventory[ResourceType.Wood];
		woodBar.value = woodLevel;
        citizenNum.text = totalPop.ToString();

    }
    void StorageValues()
	{
        foodBar.maxValue = maxStorage;
        stoneBar.maxValue = maxStorage;
        woodBar.maxValue = maxStorage;
    }

    void LevelUp()
	{
		if(xp == xpNeeded){
			playerLevel++;
			level.text = playerLevel.ToString();
            xp = 0;
			xpNeeded += 10;
			//playerMoney += 50;
			xpBar.value = 0;
			xpBar.maxValue = xpNeeded;
		}
		
	}

	public void UpdateHousing(int citizens)
	{
		totalPop += citizens;
		totalWorkers = totalPop;
        availWorkers += citizens;
    }

	public void EarnXP()
	{
		xp += 10;
		xpBar.value += 10;   
		
    }

	public void EarnMoney(int earnedAmt)
	{
		//playerMoney += earnedAmt;
	}

	public void PayResource(List<ResourceCost> cost)//List<ResourceCost> cost)
    {
        foreach (var resource in cost)
        {
			inventory[resource.resource] -= resource.amount;

            //    if(inventory[resource.resource] < resource.amount)
        }
       

		//if (playerMoney >= costAmt)
		//{
			//playerMoney -= costAmt;
		//}
		
	}

	public bool Starving()
	{
		if (!EnoughFood())
		{
			//availWorkers -= 1;
            return true;
		} else 
		{
			
			return false; 
		}
	}

	public bool EnoughFood()
	{
		foodMin = totalPop * 1.25f;
		if(foodLevel >= foodMin)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public void AssignWorkers()
	{
		availWorkers = totalWorkers;
		foreach (var bld in resourceBuildings)
		{
			Blding bldScript = bld.GetComponent<Blding>();
			if (bldScript != null && bldScript.built)
			{
				bldScript.staffed = false;
                if (availWorkers >= bldScript.workersNeeded)
				{
					availWorkers -= bldScript.workersNeeded;
					bldScript.staffed = true;
				}
				else
				{
					bldScript.staffed = false;
                }
                
            }
        }
    }

    public bool CanStoreResource(ResourceType resource, int amount)
    {
        if (inventory[resource] + amount <= maxStorage)
        {
            ResourceIntake(resource, amount);
            return true;
        }
        else
        {
            Debug.Log("Need more Resource storage!");
            return false;
        }
    }

	void ResourceIntake(ResourceType resource, int amount)
	{
		inventory[resource] += amount;
		switch (resource)
		{
			case ResourceType.Wood:
				woodBar.value = inventory[resource];
				break;
			case ResourceType.Stone:
				stoneBar.value = inventory[resource];
				break;
			case ResourceType.Food:
				foodBar.value = inventory[resource];
				break;
			default:
				break;
		}
	}

}