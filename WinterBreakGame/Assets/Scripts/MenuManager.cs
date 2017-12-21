using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;

public class MenuManager : MonoBehaviour {

    [HideInInspector]
    public List<FoodManager.Food> playerFood;
    private EventSystem es;
    private ScoreManager SM;
    private Order orderManager;
    private Text queuedItems;
    public GameObject[] itemCanvases;

    private bool deliveringOrder;
	// Use this for initialization
	void Start () {
        es = GameObject.FindObjectOfType<EventSystem>();
        SM = GameObject.FindObjectOfType<ScoreManager>();
        orderManager = GameObject.FindObjectOfType<Order>();
        queuedItems = GameObject.Find("QueuedItems").GetComponent<Text>();
	}

    public void MenuOption()
    {
        if (playerFood.Count < 4)
        {
            playerFood.Add(es.currentSelectedGameObject.GetComponent<FoodAssigned>().foodAssigned);
            queuedItems.text += "\n" + es.currentSelectedGameObject.GetComponent<FoodAssigned>().foodAssigned;
            print(es.currentSelectedGameObject.GetComponent<FoodAssigned>().foodAssigned + " added");
        }
    }
    
    public void CanvasSwap(GameObject activeCanvas)
    {
        for(int i = 0; i < itemCanvases.Length; i++)
        {
            itemCanvases[i].SetActive(false);
        }
        activeCanvas.SetActive(true);
    }

    public void RemoveItem()
    {
        if (playerFood.Count > 0)
        {
            string removedItem = playerFood[playerFood.Count - 1].ToString();
            print(playerFood[playerFood.Count - 1] + " removed");
            print(removedItem + " Is a thing");
            queuedItems.text = "Queued Items:";
            playerFood.RemoveAt(playerFood.Count-1);
            for(int i = 0; i < playerFood.Count; i++)
            {
                queuedItems.text += "\n" + playerFood[i].ToString();
            }
            
        }
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
            Order.dialog.text = currentOrder.characters[currentOrder.activeCharacter].GetComponent<Character>().exitHappyDialog;
            SM.AddPoints(currentOrder.foodItems.Count * 100);
        }
        else
        {
            Order.dialog.text = currentOrder.characters[currentOrder.activeCharacter].GetComponent<Character>().exitSadDialog;
        }
        queuedItems.text = "Queued Items:";
        yield return new WaitForSeconds(3);
        currentOrder.anim.SetBool("Ordering", false);
        Order.dialog.text = "";
        orderManager.RollCustomer();
        playerFood.Clear();
        deliveringOrder = false;
    }
}
