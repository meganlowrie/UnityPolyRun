using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    //jumping power for the player object
    [Header("Default Jumping Power")]
    public float jumpPower = 6f;
    //true or false if the object is on the ground
    [Header("Boolean isGrounded")]
    public bool isGrounded = false;
    //position of the object
    float posX = 0.0f;
    //Rigidbody2D of the object
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //variable rb equals to Rigidbody2D component
        rb = transform.GetComponent<Rigidbody2D>();

        //variable posX equals to position of the object
        //on the x axis
        posX = transform.position.x;
    }

    void FixedUpdate(){
        //if the spacebar is pressed and the object
        //is on the ground and the game is playing
        if(Input.GetKey(KeyCode.Space) && isGrounded){
            //adds force to the object to jump
            //upwards based on jump power, mass, gravity
            rb.AddForce(Vector3.up * (jumpPower * rb.mass
            * rb.gravityScale * 20.0f));

        //if the player position is less than
        //the original position of the player
        if(transform.position.x < posX)
            GameOver();
        }
    }

    //when an incoming collider makes contact with
    //this object's collider
    void OnCollisionEnter2D(Collision2D collision){
        //if colliders tag equals ground
        if(collision.collider.tag == "Ground"){
            //isGrounded equals true
            isGrounded = true;
        //if colliders tag equals enemy
        if(collision.collider.tag == "Enemy")
            GameOver();
        }
    }

    //when a collider on another object is touching
    //this object's collider
    void OnCollisionStay2D(Collision2D collision){
        //if colliders tag equals ground
        if(collision.collider.tag == "Ground")
            //isGrounded equals true
            isGrounded = true;
    }

    //when a collider on another object is touching
    //this object's collider
    void OnCollisionExit2D(Collision2D collision){
        //if colliders tag equals ground
        if(collision.collider.tag == "Ground")
            //isGrounded equals true
            isGrounded = false;
    }

    void GameOver(){
        //game over function is called from the game manager
        GameObject.Find("GameController").GetComponent
        <GameController>().GameOver();
    }

    //when a collider on another object is touching
    //this object's trigger
    void OnTriggerEnter2D(Collider2D collision){
        //if triggers tag equals coin
        if(collision.tag == "Coin")
            //call IncrementScore from game controller
            GameObject.Find("GameController").GetComponent
            <GameController>().IncrementScore();
            //destroy object
            Destroy(collision.gameObject);
    }
}
