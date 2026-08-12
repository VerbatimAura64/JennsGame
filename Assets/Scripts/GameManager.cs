using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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
    public TextMeshProUGUI level;
    public GridInputTest gInput;
    public GameObject[] buildings;

    private void Update()
    {
		//EarnXP();
		LevelUp();
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
		if (foodLevel + amount <= foodLevelMax)
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
		
        //foodLevel += amount;
	}

	void LoadShop()
	{

	}

}