
using UnityEngine;
using Fog.Dialogue;
public class Npc : MonoBehaviour
{

    [SerializeField] private Dialogue npcDialogue = null; 
    [SerializeField] private DialogueHandler dHandler = null;
    private  bool isInteractButtonPressed;


    void Update()
    {
        isInteractButtonPressed = isInteractButtonPressed || Input.GetKeyDown(KeyCode.Z);
    }   


    bool wasInteractButtonPressed()
    {
        bool ret = isInteractButtonPressed;
        isInteractButtonPressed = false;
        return ret;
    }
    void OnTriggerStay2D(Collider2D col)
    {
       
        if(col.gameObject.name == "Player" && wasInteractButtonPressed())
        {
           
            if(!dHandler.isDialogueActive())
            {    
                dHandler.StartDialogue(npcDialogue);
            }
            else
                dHandler.Skip();
        }
    }


}
