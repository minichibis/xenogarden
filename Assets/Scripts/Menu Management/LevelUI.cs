using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    //Panel References
    public GameObject ResourcePanel;
    public GameObject SelectPanel;

    //Resource Value References
    public TextMeshProUGUI charmText;
    public TextMeshProUGUI oxygenText;
    public TextMeshProUGUI waterText;
    public TextMeshProUGUI carbonText;

    //Select Value References
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI requireText;
    public TextMeshProUGUI produceText;

    //Variables
    public bool startWithToolsObtained = true;
    private bool toolShovelObtained = false; //should only cost 1 gold
    private bool toolCanObtained = false; 
    private bool toolInjectorObtained = false;

    void Start()
    {
        if(startWithToolsObtained)
        {
            toggleObtainedTool("Shovel");
            toggleObtainedTool("WateringCan");
            toggleObtainedTool("O2Injector");
        }
    }

    void Update()
    {
        
    }

    # region ToggleObtainedTool
    public void toggleObtainedTool(string tool)
    {
        if(tool == "Shovel")
        {
            if(toolShovelObtained)
            {
                toolShovelObtained = false;
            }
            else
            {
                toolShovelObtained = true;
            }
        }
        if (tool == "WateringCan")
        {
            if (toolCanObtained)
            {
                toolCanObtained = false;
            }
            else
            {
                toolCanObtained = true;
            }
        }
        if (tool == "O2Injector")
        {
            if (toolInjectorObtained)
            {
                toolInjectorObtained = false;
            }
            else
            {
                toolInjectorObtained = true;
            }
        }
    }
    #endregion

    /*public void refreshResources()
    {
        //charmText.text = "";
    }
    public void refreshSelect()
    {

    }*/

    #region setCost Functions
    //For setCost text - plant
    public void setCost(int inputOxygen, int inputWater, int inputCarbon)
    {
        //Later, colorcode this text
        costText.text = "" + inputOxygen + ", " + inputWater + ", " + inputCarbon;
    }

    //For setCost text - tool
    public void setCost(int toolCost)
    {
        costText.text = "$" + toolCost;
    }
    #endregion

    #region setRequire Function
    //For require text - tool
    public void setRequire(string toolNeeded)
    {
        //Later, colorcode this text
        requireText.text = "" + toolNeeded;
    }
    #endregion

    #region setProduce Function
    //For require text - tool
    public void setProduce(float charmProduced, float o2Produced, float waterProduced, float carbonProduced)
    {
        //Later, colorcode this text
        produceText.text = "" + charmProduced + ", " + o2Produced + ", " + waterProduced + ", " + carbonProduced;
    }
    #endregion

    #region setResources Function
    public void setResources(int charmValue, int oxygenValue, int waterValue, int carbonValue)
    {
        setCharm(charmValue);
        setOxygen(oxygenValue);
        setWater(waterValue);
        setCarbon(carbonValue);
    }
    private void setCharm(int value)
    {
        charmText.text = "" + value;
    }
    private void setOxygen(int value)
    {
        oxygenText.text = "" + value;
    }
    private void setWater(int value)
    {
        waterText.text = "" + value;
    }
    private void setCarbon(int value)
    {
        carbonText.text = "" + value;
    }
    #endregion

    #region setName Function
    public void setName(string nameToSet)
    {
        nameText.text = nameToSet;
    }

    #endregion
}