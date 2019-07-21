using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseButton : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerStay2D(Collider2D col)
    {
        
        if(col.gameObject.name == "Player" && Input.GetButtonDown("Interact"))
        {
            SceneManager.LoadSceneAsync("Desktop", LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("Browser");
            SceneManager.UnloadSceneAsync("Minigame");
        }
    }
}
