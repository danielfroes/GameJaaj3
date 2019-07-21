using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    private int score = 0;
    public static float scoreF = 0;
    private int high = 0;
    public Text scoreText;
    public Text highText;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(MinigameManager.isMinigameRunning){
            scoreF += Time.deltaTime * 8;
            score = (int) scoreF;
            
            if(score > high)
            {
                high = score;
            }
            scoreText.text = fixNumString(score.ToString());  
        }
        else
        {
            highText.text = "HI " + fixNumString(high.ToString());
        }
    }

       

    private string fixNumString(string num)
    {
        while(num.Length < 5)
        {
            num = "0" + num;
        }

        return num;
    }

}
