using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MinigameManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject _minigameOver = null;
    [SerializeField] private GameObject _textWall = null;
    [SerializeField] private GameObject _minigameWall = null;
    public static GameObject minigameOver = null;
    public static Animator textWallAnim = null;
    public static Animator minigameWallAnim = null;


    private static bool trggerMinigameState = true;

    private static bool triggerPlataformerState = false;

    public static bool isMinigameRunning = false;
    public static bool isMinigameOver = false;

    
    void Start()
    {
        minigameOver = _minigameOver;
        textWallAnim = _textWall.GetComponent<Animator>();
        minigameWallAnim = _minigameWall.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Starts the minigame
        if(Input.GetButtonDown("Jump") && trggerMinigameState)
        {
            Debug.Log("StartMinigameState");
            StartMinigameState();
            minigameWallAnim.SetBool("triggerInitialSlide", true);
            trggerMinigameState = false;
        }
        else if(Input.GetButtonDown("Jump") && triggerPlataformerState)
        {
            StartPlataformerState();
            triggerPlataformerState = false;
        }
    }

    
    private static void StartMinigameState()
    {

        minigameOver.SetActive(false);
        isMinigameRunning = true;
        isMinigameOver = false;
        Movement.enableWalk = false;
        BgScroll.enableScroll = true;
        Player.animator.SetBool("minigameStateHasStarted", true);
        Player.animator.SetBool("isRunning", true);

    }

    public static void EndMinigameState()
    {
        isMinigameOver = true;
        isMinigameRunning = false;
        BgScroll.enableScroll = false;
        // Player.animator.SetBool("isMoving", false);
        // Jump.jumpEnable = false;
        Player.animator.SetBool("hasDied", true);
        Player.animator.SetBool("isRunning", false);
        minigameOver.SetActive(true);
        textWallAnim.SetBool("startSlidingDown", true);

        triggerPlataformerState = true;
        
    }

    private static void StartPlataformerState()
    {
        Debug.Log("StartPlataformer");
        Movement.enableWalk = true;
        Player.animator.SetBool("hasDied", false);
        Player.animator.SetBool("plataformerStateHasStarted", true);
    }


    public static void RestartMinigame()
    {

        Player.transf.position = Player.initPos;
        Score.scoreF = 0f;
        SceneManager.UnloadSceneAsync("Minigame");
        SceneManager.LoadSceneAsync("Minigame",LoadSceneMode.Additive);
        StartMinigameState();

        
    }  
}
