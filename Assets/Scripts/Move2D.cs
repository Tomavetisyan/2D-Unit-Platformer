using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Move2D : MonoBehaviour
{
    public Sprite Snailbert_Jump;
    public Sprite Snailbert_Crouch;
    public Sprite Snailbert_Idle;
    public float moveSpeed =5f;
    public float JumpHeight = 5f;
    [SerializeField] private LayerMask theGround;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;
    private bool isCrouching;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update(){

    }
    void FixedUpdate(){
        

        if(Input.GetKey("up") && isGrounded()){
            moveUp();
        }else if(isGrounded()){
            spriteRenderer.sprite = Snailbert_Idle;
        }
        
        if(Input.GetKey("down")){
           moveDown();
        }

        if(Input.GetKey("right")){
           moveRight();
        }else if (Input.GetKey("left")){
           moveLeft();
        }else{
            rb.velocity= new Vector2(0,rb.velocity.y); 
            isCrouching=false;
        }
    }
    private void moveRight(){
        spriteRenderer.flipX=true;
        if(isCrouching != true){
            rb.velocity= new Vector2(moveSpeed,rb.velocity.y);
        }
    }
    private void moveLeft(){
        spriteRenderer.flipX=false;
        if(isCrouching != true){
            rb.velocity= new Vector2(-1*moveSpeed,rb.velocity.y);
        }
    }
    private void moveUp(){
        rb.velocity = new Vector2(rb.velocity.x, JumpHeight);
        spriteRenderer.sprite = Snailbert_Jump;
    }
    private void moveDown(){
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y-1);
        if(isGrounded()){
            spriteRenderer.sprite = Snailbert_Crouch;
            isCrouching = true;
        }   
    }

    private bool isGrounded(){
        Vector3 bottomLeft = new Vector3(-boxCollider2D.size.x, -boxCollider2D.size.y, 0);
        Vector3 bottomRight = new Vector3(boxCollider2D.size.x, -boxCollider2D.size.y, 0);

        if(Physics2D.Raycast(boxCollider2D.bounds.center, Vector3.down, boxCollider2D.bounds.extents.y +.1f, theGround)
            || Physics2D.Raycast(boxCollider2D.bounds.center, bottomLeft, getHypotenuse(boxCollider2D.size.x,boxCollider2D.size.y) - .5f, theGround)
            || Physics2D.Raycast(boxCollider2D.bounds.center, bottomRight, getHypotenuse(boxCollider2D.size.x,boxCollider2D.size.y) - .5f, theGround)){
            return true;
        }else{
            return false;
        }
    }
    private float getHypotenuse(double sideA, double sideB){
        return (float)Math.Sqrt(Math.Pow(sideA,2) + Math.Pow(sideB, 2));
    }
    
}
