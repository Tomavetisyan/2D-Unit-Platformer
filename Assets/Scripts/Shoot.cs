using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Update is called once per frame
    public GameObject bulletPrefab;
    private BoxCollider2D boxCollider2D;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
       
        if(Input.GetButtonDown("Fire1")){
            
            shootBullet();
        }
    }
    private void shootBullet(){
        Vector3 spawnPoint = new Vector3(boxCollider2D.bounds.center.x - boxCollider2D.size.x, boxCollider2D.bounds.center.y, 0 );
        
        if(this.spriteRenderer.flipX){
            spawnPoint = new Vector3(boxCollider2D.bounds.center.x + boxCollider2D.size.x, boxCollider2D.bounds.center.y, 0 );
        }
        
        Instantiate(bulletPrefab, spawnPoint, Quaternion.identity);
    }
}
