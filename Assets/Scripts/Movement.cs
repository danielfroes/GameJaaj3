using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private float speed = 10;
    public static bool enableWalk = false;

    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enableWalk)
        {
            Walk();
        }
            
    }

    private void Walk()
    {
        
        float xDir = Input.GetAxisRaw("Horizontal");    
        if(xDir < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(xDir > 0)
        {
            spriteRenderer.flipX = false;
        }

        Player.rb.velocity = new Vector2(xDir * speed * Time.fixedDeltaTime, Player.rb.velocity.y);
        Player.animator.SetFloat("horizontalSpeed", Mathf.Abs(xDir*speed));
    }
}
