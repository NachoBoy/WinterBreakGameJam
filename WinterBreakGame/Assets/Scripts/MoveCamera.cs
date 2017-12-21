using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

    //variables
    public float movementTime = 2.0f; //amount of time the camera moves
    public float movementDistance = 9.2f; //distance the camera moves
    public bool register = false; //if the player is currently looking at the register screen or not
    public bool inMotion = false; //if the screen is currently moving - prevent mouse clicks from firing anything during the process
    
    public void Move()
    {
            if(register == true)
            {
                inMotion = true;
                StopCoroutine("MoveObjectRight");
                StartCoroutine("MoveObjectRight", movementDistance);
                register = false;
            }
            else if (register == false)
            {
                inMotion = true;
                StopCoroutine("MoveObjectLeft");
                StartCoroutine("MoveObjectLeft", movementDistance);
                register = true;
            }       
    }

    //moving camera left
    private IEnumerator MoveObjectLeft(float distance)
    {
        Vector3 currentPosition = this.transform.position;
        Vector3 targetPosition = new Vector3(this.transform.position.x - distance, this.transform.position.y, this.transform.position.z);
        float currentTime = 0.0f;

        while (currentTime <= movementTime)
        {
            float movementFactor = currentTime / movementTime;
            this.transform.position = Vector3.Lerp(currentPosition, targetPosition, movementFactor);
            currentTime += Time.deltaTime;
            yield return null;
        }
        inMotion = false;
    }

    //moving camera right
    private IEnumerator MoveObjectRight(float distance)
    {
        Vector3 currentPosition = this.transform.position;
        Vector3 targetPosition = new Vector3(this.transform.position.x + distance, this.transform.position.y, this.transform.position.z);
        float currentTime = 0.0f;

        while (currentTime <= movementTime)
        {
            float movementFactor = currentTime / movementTime;
            this.transform.position = Vector3.Lerp(currentPosition, targetPosition, movementFactor);
            currentTime += Time.deltaTime;
            yield return null;
        }
        inMotion = false;
    }
}
