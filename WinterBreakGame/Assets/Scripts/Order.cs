using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Order : MonoBehaviour {

    [HideInInspector]
    public List<FoodManager.Food> foodItems;

    [HideInInspector]
    public int numOfItems;

    public static Text dialog;

    private void Start()
    {
        dialog = GameObject.Find("DialogBox").GetComponent<Text>();
        StartCoroutine(SendCustomer());
    }
    // Use this for initialization
    public IEnumerator SendCustomer()
    {
        yield return new WaitForSeconds(2);
        foodItems.Clear();
        numOfItems = Random.Range(1, 4);
        for (int j = 0; j < numOfItems; j++)
        {
            foodItems.Add(((FoodManager.Food)Random.Range(0, System.Enum.GetValues(typeof(FoodManager.Food)).Length)));
        }

        dialog.text = "I would like: \n" + foodItems[0];
        for (int i = 1; i < foodItems.Count; i++)
        {
            dialog.text += "\n" + foodItems[i];
        }
    }
    

    // Update is called once per frame
    void Update () {
		
	}
}
