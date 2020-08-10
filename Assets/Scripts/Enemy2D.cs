using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy2D : MonoBehaviour{

    public float moveSpeed = 1;
    public bool pacing = true;
    public float travelTime = 8;
    public float agroDistance = 5;
    private float timeSinceChange;
    [SerializeField]
    Transform player;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public void FixedUpdate(){
    
        if(pacing){
            timeSinceChange += Time.deltaTime;
            if(timeSinceChange<=travelTime/2){
                MoveRight();
            }else if(timeSinceChange>=travelTime/2 && timeSinceChange <=travelTime){
                MoveLeft();
            }else if(timeSinceChange > travelTime){
                timeSinceChange = 0;
            }
        }
        
        float distToPlayer = GetDistanceToPlayer();
        
        if(distToPlayer<=agroDistance){
            rb.velocity = new Vector2(0,0);
            pacing=false;
            if(player.position.x < transform.position.x){
                spriteRenderer.flipX = false;
            }else{
                spriteRenderer.flipX = true;
            }
        }else{
            pacing = true;
        }
    }
    private void MoveRight(){
        rb.velocity = new Vector2(Math.Abs(moveSpeed),0);
        spriteRenderer.flipX = true;
    }
    private void MoveLeft(){
        rb.velocity = new Vector2(-moveSpeed,0);
        spriteRenderer.flipX = false;
    }
    private float GetDistanceToPlayer(){
        return Vector2.Distance(transform.position, player.position);
    }
}