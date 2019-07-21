using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroll : MonoBehaviour
{

    [SerializeField]private float scrollSpeed = 18f;
    [SerializeField]private float incrementPerFrame = 0.001f;
    [SerializeField]private float speedThreshold = 25f;
    // [SerializeField]private GameObject sunImage;
    public static bool enableScroll = false;

    private Rigidbody2D bgRb;
    private Rigidbody2D sunRb;

    // Start is called before the first frame update
    void Start()
    {
        bgRb = GetComponent<Rigidbody2D>();
        // sunRb = sunImage.GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {

        
        if(enableScroll){
            if(scrollSpeed <= speedThreshold)
                scrollSpeed += incrementPerFrame;

            // sunRb.velocity = Vector2.left * scrollSpeed/1000;
            bgRb.velocity = Vector2.left * scrollSpeed;
        }
        else
        {
            // sunRb.velocity = Vector2.zero;
            bgRb.velocity = Vector2.zero;
        }
    }



   
}
