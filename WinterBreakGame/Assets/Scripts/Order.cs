using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Order : MonoBehaviour {

    [HideInInspector]
    public List<FoodManager.Food> foodItems;

    [HideInInspector]
    public int numOfItems;

    [HideInInspector]
    public int activeCharacter;

    public static Text dialog;
    public GameObject[] characters;
    [HideInInspector]
    public Animator anim;
    private SpriteRenderer spriteRend;
    private Animator spriteAnim;

    private Button menuButton;

    private void Start()
    {
        
        dialog = GameObject.Find("DialogBox").GetComponent<Text>();
        spriteRend = transform.GetChild(0).GetComponent<SpriteRenderer>();
        spriteAnim = transform.GetChild(0).GetComponent<Animator>();
        anim = transform.parent.GetComponent<Animator>();
        menuButton = GameObject.Find("Menu").GetComponent<Button>();
        menuButton.interactable = false;
        RollCustomer();
    }
    // Use this for initialization
    public IEnumerator SendCustomer(GameObject character)
    {
        yield return new WaitForSeconds(2);
        spriteRend.sprite = characters[activeCharacter].GetComponent<SpriteRenderer>().sprite;
        spriteAnim.runtimeAnimatorController = character.GetComponent<Animator>().runtimeAnimatorController;
        anim.SetBool("Ordering", true);
        foodItems.Clear();
        numOfItems = Random.Range(1, 4);
        for (int j = 0; j < numOfItems; j++)
        {
            foodItems.Add(((FoodManager.Food)Random.Range(0, System.Enum.GetValues(typeof(FoodManager.Food)).Length)));
        }
        yield return new WaitForSeconds(2);
        dialog.text = character.GetComponent<Character>().entryDialog + "\n" + foodItems[0];
        for (int i = 1; i < foodItems.Count; i++)
        {
            dialog.text += "\n" + foodItems[i];
        }
        spriteAnim.SetBool("Talking", true);
        menuButton.interactable = true;
        yield return new WaitForSeconds(3);
        spriteAnim.SetBool("Talking", false);
    }

    public void RollCustomer()
    {
        activeCharacter = Random.Range(0, characters.Length);
        StartCoroutine(SendCustomer(characters[activeCharacter]));
    }
    
}
