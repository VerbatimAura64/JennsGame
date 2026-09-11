using Mono.Cecil;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.iOS;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class GameManager : MonoBehaviour 
{
	public int playerLevel;
	public int playerMoney;
	public int xp;
	public int maxStorage;
	public int woodLevel;
	public int stoneLevel;
	public int foodLevel;
	public int coins;
	//public int woodLevelMax;
	private int xpNeeded = 100;
	
	public int foodEarned;
	public int foodLevelMax;
	public Slider xpBar;
	public Slider foodBar;
	public Slider stoneBar;
	public Slider woodBar;
    public TextMeshProUGUI level;
    public GridInputTest gInput;
    public GameObject[] buildings;
	public List<GameObject> storageBlds;
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
			xpNeeded += 100;
			playerMoney += 50;
			xpBar.value = 0;
			xpBar.maxValue = xpNeeded;
		}
		
	}

	public void EarnXP()
	{
		xp += 10;
		xpBar.value += 10;   
		
    }

	public void EarnMoney(int earnedAmt)
	{
		playerMoney += earnedAmt;
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

	void ResourceIntake(ResourceType resource,int amount)
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

    void LoadShop()
	{

	}

}