using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMoveCamera : MonoBehaviour {

    //variables
    public float movementTime = 2.0f; //amount of time the camera moves
    public float movementDistance = 30f; //distance the camera moves
    public bool register = false; //if the player is currently looking at the register screen or not
    public bool inMotion = false; //if the screen is currently moving - prevent mouse clicks from firing anything during the process

    private Button menuButton;
    private Button optionBackButton;
    private Button creditButton;
    private Button creditButtonBack;

    private void Start()
    {
        menuButton = GameObject.Find("OptionTomato").GetComponent<Button>();
        optionBackButton = GameObject.Find("OptionsBackButton").GetComponent<Button>();
        creditButton = GameObject.Find("CreditOnion").GetComponent<Button>();
        creditButtonBack = GameObject.Find("CreditsBackButton").GetComponent<Button>();
    }


    public void MainMove()
    {
        Debug.Log("hewwo");
                optionBackButton.interactable = false;
                inMotion = true;
                StopCoroutine("MoveObjectLeft");
                StartCoroutine("MoveObjectLeft", movementDistance);
    }

    public void MainMoveBack()
    {
        Debug.Log("hewwo2");
        menuButton.interactable = false;
        inMotion = true;
            StopCoroutine("MoveObjectRight");
            StartCoroutine("MoveObjectRight", movementDistance);
    }

    public void MainMoveUp()
    {
        Debug.Log("hewwo3");
        creditButton.interactable = false;
        inMotion = true;
        StopCoroutine("MoveObjectUp");
        StartCoroutine("MoveObjectUp", movementDistance);
    }

    public void MainMoveDown()
    {
        Debug.Log("hewwo3");
        creditButtonBack.interactable = false;
        inMotion = true;
        StopCoroutine("MoveObjectDown");
        StartCoroutine("MoveObjectDown", movementDistance);
    }

    //moving camera left
    private IEnumerator MoveObjectLeft(float distance)
    {
        Vector3 currentPosition = this.transform.position;
        Vector3 targetPosition = new Vector3(this.transform.position.x - distance, this.transform.position.y, this.transform.position.z);
        float currentTime = 0.0f;

        while (currentTime <= movementTime)
        {
            float movementFactor = (Mathf.Sin(Mathf.PI * currentTime / movementTime - Mathf.PI / 2) + 1) / 2;
            this.transform.position = Vector3.Lerp(currentPosition, targetPosition, movementFactor);
            currentTime += Time.deltaTime;
            yield return null;
        }
        inMotion = false;
        menuButton.interactable = true;
    }

    //moving camera right
    private IEnumerator MoveObjectRight(float distance)
    {
        Vector3 currentPosition = this.transform.position;
        Vector3 targetPosition = new Vector3(this.transform.position.x + distance, this.transform.position.y, this.transform.position.z);
        float currentTime = 0.0f;

        while (currentTime <= movementTime)
        {
            float movementFactor = (Mathf.Sin(Mathf.PI * currentTime / movementTime - Mathf.PI / 2) + 1) / 2;
            this.transform.position = Vector3.Lerp(currentPosition, targetPosition, movementFactor);
            currentTime += Time.deltaTime;
            yield return null;
        }
        inMotion = false;
        optionBackButton.interactable = true;
    }

    private IEnumerator MoveObjectUp(float distance)
    {
        Vector3 currentPosition = this.transform.position;
        Vector3 targetPosition = new Vector3(this.transform.position.x, this.transform.position.y + distance, this.transform.position.z);
        float currentTime = 0.0f;

        while (currentTime <= movementTime)
        {
            float movementFactor = (Mathf.Sin(Mathf.PI * currentTime / movementTime - Mathf.PI / 2) + 1) / 2;
            this.transform.position = Vector3.Lerp(currentPosition, targetPosition, movementFactor);
            currentTime += Time.deltaTime;
            yield return null;
        }
        inMotion = false;
        creditButton.interactable = true;
    }

    private IEnumerator MoveObjectDown(float distance)
    {
        Vector3 currentPosition = this.transform.position;
        Vector3 targetPosition = new Vector3(this.transform.position.x, this.transform.position.y - distance, this.transform.position.z);
        float currentTime = 0.0f;

        while (currentTime <= movementTime)
        {
            float movementFactor = (Mathf.Sin(Mathf.PI * currentTime / movementTime - Mathf.PI / 2) + 1) / 2;
            this.transform.position = Vector3.Lerp(currentPosition, targetPosition, movementFactor);
            currentTime += Time.deltaTime;
            yield return null;
        }
        inMotion = false;
        creditButtonBack.interactable = true;
    }
}
