using System.Collections;
using UnityEngine;

public class GameManager2 : MonoBehaviour 
{
	public int playerLevel;
	public int playerMoney;
	public int xp;
	private int xpNeeded;
	public int foodLevel;
	public int foodEarned;
	public int foodLevelMax;
	

	void LevelUp()
	{
		if(xp == xpNeeded){
			playerLevel++;
			xp = 0;
			xpNeeded += 100;
			playerMoney += 50;
		}
		
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
}