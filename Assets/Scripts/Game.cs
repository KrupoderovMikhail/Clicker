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
    }

    // Hit
    public void Hit()
    {
        currentScope += hitPower;
    }
}
