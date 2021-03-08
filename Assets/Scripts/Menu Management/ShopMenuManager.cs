using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/*
 * CIS 497_2 : Design Patterns
 * Group Project 1 - XenoGarden
 * Contributed by: Wolfgang Gross 
 */

public class ShopMenuManager : MonoBehaviour
{
    public GameObject manager;

    //Need reference to resources[1] (ie coins)
    public int playerCoins = 25;

    //Reference to text Objects (shop)
    public TextMeshProUGUI buyCanButton;
    public TextMeshProUGUI buyShovelButton;
    public TextMeshProUGUI buyInjectorButton;

    public TextMeshProUGUI playerCoinsText;

    //Prices
    private int wateringCanPrice;
    private int shovelPrice;
    private int o2InjectorPrice;

    //Check for if items have been bought
    private bool hasWaterCan = false;
    private bool hasShovel = false;
    private bool hasInjector = false;

    private void Start()
    {
        wateringCanPrice = 5;
        shovelPrice = 10;
        o2InjectorPrice = 15;
    }

    private void Update()
    {
        playerCoinsText.text = "" + playerCoins;
    }

    public void resetBuyButtons()
    {
        buyCanButton.text = "BUY";
        buyShovelButton.text = "BUY";
        buyInjectorButton.text = "BUY";
    }
    public void resetItemsBought()
    {
        hasShovel = false;
        hasWaterCan = false;
        hasInjector = false;
    }

    public void BuyWateringCan()
    {
        if(!hasWaterCan)
        {
            if (playerCoins >= wateringCanPrice)
            {
                playerCoins -= wateringCanPrice;

                //Do show you bought item

                hasWaterCan = true;
                buyCanButton.text = "SOLD";
                
            }
            else
            {

            }
        }
        
    }
    public void BuyShovel()
    {
        if(!hasShovel)
        {
            if (playerCoins >= shovelPrice)
            {
                playerCoins -= shovelPrice;

                //Do show you bought item

                hasShovel = true;
                buyShovelButton.text = "SOLD";
                

                //Need functionality to tell 'Manager' that this item can be used
            }
            else
            {

            }
        }
        
    }
    public void BuyO2Injector()
    {
        if(!hasInjector)
        {
            if (playerCoins >= o2InjectorPrice)
            {
                playerCoins -= o2InjectorPrice;

                //Do show you bought item

                hasInjector = true;
                buyInjectorButton.text = "SOLD";
            }
            else
            {

            }
        }
        
    }
}
