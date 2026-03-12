using System.Collections;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class GameManager : MonoBehaviour 
{
	public int playerLevel;
	public int playerMoney;
	public int xp;
	private int xpNeeded = 100;
	public int foodLevel;
	public int foodEarned;
	public int foodLevelMax;
	public Slider xpBar;


    private void Update()
    {
		EarnXP();
		
    }


    void LevelUp()
	{
		if(xp == xpNeeded){
			playerLevel++;
			xp = 0;
			xpNeeded += 100;
			playerMoney += 50;
			xpBar.value = 0;
			xpBar.maxValue = xpNeeded;
		}
		
	}

	void EarnXP()
	{
        if (Input.GetMouseButtonDown(0))
        {
			xp += 10;
			xpBar.value += 10;
        }
		LevelUp();
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

	void FoodStorage()
	{
		if (foodLevel != foodLevelMax)
		{
			FoodIntake();
		}
		else 
		{
			Debug.Log("Need more food storage!");
		}
	}

	void FoodIntake()
	{
		foodLevel += foodEarned;
	}

	void LoadShop()
	{

	}

}