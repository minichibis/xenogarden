using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlantUpkeep
{
	//upkeepneeds and upkeephas should be roughly analogous to the resource table in manager
	//you need to give the plants resources
	
    int[] returnUpkeepNeeds();
	int[] returnUpkeepHas();
	void damageUpkeep();
}
