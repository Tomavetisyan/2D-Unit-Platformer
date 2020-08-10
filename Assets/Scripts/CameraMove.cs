using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    float timeOffSet;
    [SerializeField]
    Vector2 posOffSet;

    void Update(){
        Vector3 startPos = transform.position;
        Vector3 endPos = player.transform.position;
        endPos.x+=posOffSet.x;
        endPos.y+=posOffSet.y;
        endPos.z = -10;

        transform.position = Vector3.Lerp(startPos, endPos, timeOffSet*Time.deltaTime);
    }
}
