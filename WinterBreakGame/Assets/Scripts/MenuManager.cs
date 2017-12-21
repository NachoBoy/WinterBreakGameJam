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

    private Button orderButton;

    private bool deliveringOrder;
	// Use this for initialization
	void Start () {
        es = GameObject.FindObjectOfType<EventSystem>();
        SM = GameObject.FindObjectOfType<ScoreManager>();
        orderManager = GameObject.FindObjectOfType<Order>();
        queuedItems = GameObject.Find("QueuedItems").GetComponent<Text>();
        orderButton = GameObject.Find("OrderFood").GetComponent<Button>();
        UpdateSubmitButton();
	}

    public void MenuOption()
    {
        if (playerFood.Count < 4)
        {
            playerFood.Add(es.currentSelectedGameObject.GetComponent<FoodAssigned>().foodAssigned);
            queuedItems.text += es.currentSelectedGameObject.GetComponent<FoodAssigned>().foodAssigned + "\n";
            print(es.currentSelectedGameObject.GetComponent<FoodAssigned>().foodAssigned + " added");
            UpdateSubmitButton();
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
            queuedItems.text = "";
            playerFood.RemoveAt(playerFood.Count-1);
            for(int i = 0; i < playerFood.Count; i++)
            {
                queuedItems.text +=  playerFood[i].ToString() + "\n";
            }
            UpdateSubmitButton();
            
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
        Animator customerAnim = currentOrder.transform.GetChild(0).GetComponent<Animator>();
        if (currentOrder.foodItems.All(playerFood.Contains) && (currentOrder.foodItems.Count == playerFood.Count)){
            Order.dialog.text = currentOrder.characters[currentOrder.activeCharacter].GetComponent<Character>().exitHappyDialog;
            SM.AddPoints(currentOrder.foodItems.Count * 100);
        }
        else
        {
            Order.dialog.text = currentOrder.characters[currentOrder.activeCharacter].GetComponent<Character>().exitSadDialog;
        }
        customerAnim.SetBool("Talking", true);
        queuedItems.text = "";
        playerFood.Clear();
        UpdateSubmitButton();
        yield return new WaitForSeconds(3);
        customerAnim.SetBool("Talking", false);
        currentOrder.anim.SetBool("Ordering", false);
        Order.dialog.text = "";
        orderManager.RollCustomer();
        deliveringOrder = false;
    }

    public void UpdateSubmitButton()
    {
        if (playerFood.Count > 0 )
        {
            orderButton.interactable = true;
        }
        else
        {
            orderButton.interactable = false;
        }
    }
}
