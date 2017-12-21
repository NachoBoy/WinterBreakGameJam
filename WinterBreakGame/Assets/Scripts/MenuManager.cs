using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class MenuManager : MonoBehaviour {

    [HideInInspector]
    public List<FoodManager.Food> playerFood;
    private EventSystem es;
    private ScoreManager SM;
    private Order orderManager;

    private bool deliveringOrder;
	// Use this for initialization
	void Start () {
        es = GameObject.FindObjectOfType<EventSystem>();
        SM = GameObject.FindObjectOfType<ScoreManager>();
        orderManager = GameObject.FindObjectOfType<Order>();
	}

    public void MenuOption()
    {
        playerFood.Add(es.currentSelectedGameObject.GetComponent<FoodAssigned>().foodAssigned);
        print(es.currentSelectedGameObject.GetComponent<FoodAssigned>().foodAssigned + " added");
    }

    public void StartOrderSubmission()
    {
        if(!deliveringOrder)
            StartCoroutine(SubmitFinishedOrder());
    }

    public IEnumerator SubmitFinishedOrder()
    {
        deliveringOrder = true;
        Order currentOrder = GameObject.FindObjectOfType<Order>();
        if(currentOrder.foodItems.All(playerFood.Contains) && (currentOrder.foodItems.Count == playerFood.Count)){
            Order.dialog.text = "Thank you!";
            SM.AddPoints(currentOrder.foodItems.Count * 100);
        }
        else
        {
            Order.dialog.text = "This isn't what I ordered :(";
        }
        yield return new WaitForSeconds(2);
        StartCoroutine(orderManager.SendCustomer());
        playerFood.Clear();
        deliveringOrder = false;
    }
}
