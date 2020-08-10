using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ChangeColor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public float timeToChange =0.1f;
    private float timeSinceChange =0.1f;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Awake(){

    }

    // Update is called once per frame
    void Update()
    {
        this.timeSinceChange += Time.deltaTime;

        if(spriteRenderer != null && timeSinceChange >= timeToChange){
            Color newColor = new Color(Random.value, Random.value,Random.value);
            spriteRenderer.color = newColor;
            this.timeSinceChange=0f;
        }
    
     
    }

}
