using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class MenuManager : MonoBehaviour {

    [HideInInspector]
    public List<FoodManager.Food> playerFood;
    private EventSystem es;
	// Use this for initialization
	void Start () {
        es = GameObject.FindObjectOfType<EventSystem>();
	}

    public void MenuOption()
    {
        playerFood.Add(es.currentSelectedGameObject.GetComponent<FoodAssigned>().foodAssigned);
        print(es.currentSelectedGameObject.GetComponent<FoodAssigned>().foodAssigned + " added");
    }

    public void SubmitFinishedOrder()
    {
        Order currentOrder = GameObject.FindObjectOfType<Order>();
        if(currentOrder.foodItems.All(playerFood.Contains) && (currentOrder.foodItems.Count == playerFood.Count)){
            print("yay");
        }
        else
        {
            print("boo");
        }
    }
}
