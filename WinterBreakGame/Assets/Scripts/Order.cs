using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour {

    [HideInInspector]
    public List<FoodManager.Food> foodItems;

    [HideInInspector]
    public int numOfItems;

    // Use this for initialization
    void Start()
    {
        numOfItems = Random.Range(1, 4);
        for (int j = 0; j < numOfItems; j++)
        {
            foodItems.Add(((FoodManager.Food)Random.Range(0, System.Enum.GetValues(typeof(FoodManager.Food)).Length)));
        }

        print("I would like " + foodItems[0]);
        for(int i = 1; i < foodItems.Count; i++)
        {
            print(" and some " + foodItems[i]);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
