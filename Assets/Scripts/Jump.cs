using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    
    [SerializeField] private float jumpVelocity = 6f;
    [SerializeField] private float jumpHeight = 7f;
    [SerializeField] private float fallMultiplier = 2.5f; 
    [SerializeField] private float lowfallMultiplier = 2f;

    [SerializeField] private GameObject corner = null;
    [SerializeField] private GameObject below = null;

    [SerializeField] private LayerMask groundLayer;

    private float heightBeforeJump = 0;
    public bool isJumping = false;  
    public static bool jumpEnable = true;

  
    

    // Update is called once per frame
    void Update()
    {
        if(jumpEnable)
        {
            NormalJump();
        }
        else
        {
            Player.rb.velocity = Vector2.down * jumpVelocity;
        }


    }


    private void NormalJump()
    {   
        isJumping = !Physics2D.OverlapArea(corner.transform.position, below.transform.position, groundLayer);
        
        Player.animator.SetBool("isJumping", isJumping);
        

        //Ação de pular
        if(Input.GetButtonDown("Jump") && !isJumping)
        {   
            heightBeforeJump = transform.position.y;
            Player.rb.velocity = Vector2.up * jumpVelocity;
            // isJumping = true;
            // Player.animator.SetBool("isJumping",true);
        }

        float actualHeight = (transform.position.y - heightBeforeJump);

        //Se o jogador estiver caindo, adiciona o multiplicador de queda
        if(Player.rb.velocity.y < 0) 
        {
            Player.rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        //Se o jogador atingir a altura máxima do pulo, zera a velocidade vertical 
        else if(  actualHeight > jumpHeight   ||  (Input.GetButtonUp("Jump")  && actualHeight > jumpHeight/2)  )
        {
            Player.rb.velocity = new Vector2(Player.rb.velocity.x, 0f);
        }
        //se o jogador não apertar o botão de pulo até o final do pulo da um pulo menor
        else if(Player.rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            Player.rb.velocity += Vector2.up * Physics2D.gravity.y * (lowfallMultiplier - 1) * Time.deltaTime;
        }
    }
    // void OnCollisionEnter2D(Collision2D col)
    // {
    //     if(col.gameObject.tag == "ground")
    //     {
    //         isJumping = false;
    //         Player.animator.SetBool("isJumping",false);
    //     }
    // }
}

