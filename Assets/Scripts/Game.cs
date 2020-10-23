using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{

    // Clicker
    public Text scoreText;
    public float currentScope;
    public float hitPower;
    public float scoreIncreasedPerSecond;
    public float x;

    // Shop
    public int shop1prize;
    public Text shop1text;

    public int shop2prize;
    public Text shop2text;

    // Amount
    public int amount1;
    public Text amount1text;
    public float amount1Profit;

    public int amount2;
    public Text amount2text;
    public float amount2Profit;

    // Upgrade
    public int upgradePrize;
    public Text upgradeText;

    // New
    public int allUpgradePrize;
    public Text allUpgradeText;

    // Achievement
    public bool achievementScore;
    public bool achievementShop;

    public Image image1;
    public Image image2;

    // Start is called before the first frame update
    void Start()
    {
        // Clicker
        currentScope = 0;
        hitPower = 1;
        scoreIncreasedPerSecond = 1;
        x = 0F;

        // We must set  all default variables before load
        shop1prize = 25;
        shop2prize = 125;
        amount1 = 0;
        amount1Profit = 1;
        amount2 = 0;
        amount2Profit = 5;

        // Reset line
        PlayerPrefs.DeleteAll();

        // Load
        currentScope = PlayerPrefs.GetInt("currentScore", 0);
        hitPower = PlayerPrefs.GetInt("hitPower", 1);
        x = PlayerPrefs.GetInt("x", 0);

        shop1prize = PlayerPrefs.GetInt("shop1prize", 25);
        shop2prize = PlayerPrefs.GetInt("shop2prize", 125);
        amount1 = PlayerPrefs.GetInt("amount1", 0);
        amount1Profit = PlayerPrefs.GetInt("amount1Profit", 0); 
        amount2 = PlayerPrefs.GetInt("amount2", 0);
        amount2Profit = PlayerPrefs.GetInt("amount2Profit", 0);
        upgradePrize = PlayerPrefs.GetInt("upgradePrize", 50);

        // New
        allUpgradePrize = 500;
    }

    // Update is called once per frame
    void Update()
    {
        // Clicker
        scoreText.text = (int)currentScope + " $";
        scoreIncreasedPerSecond = x * Time.deltaTime;
        currentScope = currentScope + scoreIncreasedPerSecond;

        // Shop
        shop1text.text = "Tier 1: " + shop1prize + " $";
        shop2text.text = "Tier 2: " + shop2prize + " $";

        // Amount
        amount1text.text = "Tier 1: " + amount1 + " arts $: " + amount1Profit + "/s";
        amount2text.text = "Tier 2: " + amount2 + " arts $: " + amount2Profit + "/s";

        // Upgrade
        upgradeText.text = "Cost: " + upgradePrize + " $";

        // Save
        PlayerPrefs.SetInt("currentScore", (int) currentScope);
        PlayerPrefs.SetInt("hitPower", (int) hitPower);
        PlayerPrefs.SetInt("x", (int) x);

        PlayerPrefs.SetInt("shop1prize",  (int) shop1prize);
        PlayerPrefs.SetInt("shop2prize", (int) shop2prize);
        PlayerPrefs.SetInt("amount1", (int) amount1);
        PlayerPrefs.SetInt("amount1Profit", (int) amount1Profit);
        PlayerPrefs.SetInt("amount2", (int) amount2);
        PlayerPrefs.SetInt("amount2Profit", (int)  amount2Profit);
        PlayerPrefs.SetInt("upgradePrize", (int) upgradePrize);

        // New
        allUpgradeText.text = "Cost: " + allUpgradePrize + " $";

        // Achievement
        if (currentScope >= 50)
        {
            achievementScore = true;
        }

        if (amount1 >= 2)
        {
            achievementShop = true;
        }

        if (achievementScore == true)
        {
            image1.color = new Color(1F, 1F, 1F, 1F);
        }
        else
        {
            image1.color = new Color(0.2F, 0.2F, 0.2F, 0.2F);
        }

        if (achievementShop == true)
        {
            image2.color = new Color(1F, 1F, 1F, 1F);
        }
        else
        {
            image2.color = new Color(0.2F, 0.2F, 0.2F, 0.2F);
        }
    }

    // Hit
    public void Hit()
    {
        currentScope += hitPower;
    }

    // Shop
    public void Shop1()
    {
        if (currentScope >= shop1prize)
        {
            currentScope -= shop1prize;
            amount1 += 1;
            amount1Profit += 1;
            x += 1;
            shop1prize += 25;
        }
    }

    public void Shop2()
    {
        if (currentScope >= shop2prize)
        {
            currentScope -= shop2prize;
            amount2 += 1;
            amount2Profit += 5;
            x += 5;
            shop2prize += 125;
        }
    }

    // Upgrade
    public void Upgrade()
    {
        if (currentScope >= upgradePrize)
        {
            currentScope -= upgradePrize;
            hitPower *= 2;
            upgradePrize *= 3;
        }
    }

    // New
    public void AllProfitsUpgrade()
    {
        if (currentScope >= allUpgradePrize)
        {
            currentScope -= allUpgradePrize;
            x *= 2;
            allUpgradePrize *= 3;
            amount1Profit *= 2;
            amount2Profit *= 2;
        }
    }

   public void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
