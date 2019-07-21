using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Rigidbody2D rb = null;
    public static Animator animator = null;
    public static Transform transf = null;
    public static Vector2 initPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        transf = transform;
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
