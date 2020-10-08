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

    // Start is called before the first frame update
    void Start()
    {
        // Clicker
        currentScope = 0;
        hitPower = 1;
        scoreIncreasedPerSecond = 1;
        x = 0F;
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
}
