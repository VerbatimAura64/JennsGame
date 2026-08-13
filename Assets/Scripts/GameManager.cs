using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NUnit.Framework;
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

    private void Start()
    {
        storageBlds = new List<GameObject>();
    }

	private void Update()
	{
		//EarnXP();
		LevelUp();
		StorageValues();
		
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
		if(maxStorage != storageBlds.Count * units)
		{
			maxStorage = storageBlds.Count * units;
		}
                //units += storageBlds[i].GetComponent<Blding>().storageLimit;
            
		
		if (foodLevel >= maxStorage)
		{
			Debug.Log("Food storage is full!");
		}
		if (stoneLevel >= maxStorage)
		{
			Debug.Log("Stone storage is full!");
		}
		if (woodLevel >= maxStorage)
		{
			Debug.Log("Wood storage is full!");
		}

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

	void EarnMoney(int earnedAmt)
	{
		playerMoney += earnedAmt;
	}

	void LoseMoney(int costAmt)
	{
		if (playerMoney >= costAmt)
		{
			playerMoney -= costAmt;
		}
		
	}

	public bool CanStoreFood(int amount)
	{
		if (foodLevel + amount <= maxStorage)
		{
			FoodIntake(amount);
			return true;
        }
		else 
		{
			Debug.Log("Need more food storage!");
			return false;
		}
	}

	void FoodIntake(int amount)
	{
		
		foodLevel += amount;
		foodBar.value = foodLevel;
        //foodLevel += amount;
    }

	void LoadShop()
	{

	}

}