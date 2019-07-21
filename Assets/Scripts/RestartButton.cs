using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RestartButton : MonoBehaviour
{   
    void OnTriggerStay2D(Collider2D col)
    {
    
        if(col.gameObject.name == "Player" && Input.GetButtonDown("Interact"))
        {
            MinigameManager.RestartMinigame();

        }
    }
}
