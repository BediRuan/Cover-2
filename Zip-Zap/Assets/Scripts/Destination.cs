using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class TriggerTimer : MonoBehaviour
{
    public TextMeshProUGUI hiddenText; 
    private float timeInTrigger = 0f;
    private bool isPlayerInTrigger = false;

    void Update()
    {
        if (isPlayerInTrigger)
        {
            timeInTrigger += Time.deltaTime;
            if (timeInTrigger >= 3f) 
            {
                hiddenText.gameObject.SetActive(true); // Activate the hidden text
                isPlayerInTrigger = false; // Prevent this from happening repeatedly
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) // Use OnTriggerEnter2D(Collider2D other) for 2D
    {
        if (other.CompareTag("Player")) 
        {
            isPlayerInTrigger = true;
            timeInTrigger = 0f; // Reset timer
        }
    }

    private void OnTriggerExit2D(Collider2D other) // Use OnTriggerExit2D(Collider2D other) for 2D
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            timeInTrigger = 0f; 
        }
    }
}
