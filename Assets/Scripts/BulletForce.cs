using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForce : MonoBehaviour
{
    public int shootSpeed = 10;
    private Rigidbody2D rb;
    
    private GameObject playerObj = null;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
         if (playerObj == null)
             playerObj = GameObject.FindGameObjectWithTag("Player");
        if(playerObj.transform.position.x > transform.position.x){
            rb.velocity= new Vector2(-shootSpeed,0);
        }else{
            rb.velocity= new Vector2(shootSpeed,0);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(){
        Destroy(gameObject);
    }

}
