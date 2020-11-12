using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [Header("Default Speed")]
    //speed for the movement
    public float speed;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform the object to move to left
        //according to the axis and speed
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
