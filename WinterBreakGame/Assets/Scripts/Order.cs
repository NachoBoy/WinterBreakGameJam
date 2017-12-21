using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour {

    [HideInInspector]
    public List<FoodManager.Food> foodItems;

    [HideInInspector]
    public int numOfItems = Random.Range(0, 3);

    // Use this for initialization
    void Start()
    {
        for(int j = 0; j < numOfItems; j++)
        {
            foodItems[j] = (FoodManager.Food)Random.Range(0, System.Enum.GetValues(typeof(FoodManager.Food)).Length);
        }

        print("I would like a " + foodItems[0]);
        for(int i = 1; i < numOfItems; i++)
        {
            print("/n and some " + foodItems[i]);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
