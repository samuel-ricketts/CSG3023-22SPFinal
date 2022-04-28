/**** 
 * Created by: Bob Baloney
 * Date Created: April 20, 2022
 * 
 * Last Edited by: 
 * Last Edited:
 * 
 * Description: Controls the ball and sets up the intial game behaviors. 
****/

/*** Using Namespaces ***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ball : MonoBehaviour
{
    [Header("General Settings")]

    public int numOfBalls;
    private int score;
    public Text ballTxt;
    public Text scoreTxt;
    [Header("Ball Settings")]
    public float initialForce;
    public float speed;
    public GameObject paddle;
    private bool isInPlay;
    private Rigidbody rb;
    private AudioSource audioSource;
        



 


    //Awake is called when the game loads (before Start).  Awake only once during the lifetime of the script instance.
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }//end Awake()


        // Start is called before the first frame update
        void Start()
    {
        SetStartingPos(); //set the starting position

    }//end Start()


    // Update is called once per frame
    void Update()
    {
        ballTxt.text = "Balls: " + numOfBalls;
        scoreTxt.text = "Score: " + score;


        if (!isInPlay)
        {
            float posX = paddle.transform.position.x;
            float posY = transform.position.y;
            float posZ = transform.position.z;
            Vector3 pos = new Vector3(posX, posY, posZ);
            transform.position = pos; //new position
        }
        
        if ( (Input.GetKeyDown("space")) && !isInPlay)
        {
            isInPlay = true;
            Move();
        }

    }//end Update()


    private void LateUpdate()
    {
        if (isInPlay)
        {

            rb.velocity = speed * rb.velocity.normalized; //new velocity
        }
    }//end LateUpdate()


    void SetStartingPos()
    {
        isInPlay = false;//ball is not in play
        rb.velocity = Vector3.zero;//set velocity to keep ball stationary

        Vector3 pos = new Vector3();
        pos.x = paddle.transform.position.x; //x position of paddel
        pos.y = paddle.transform.position.y + paddle.transform.localScale.y; //Y position of paddle plus it's height

        transform.position = pos;//set starting position of the ball 
    }//end SetStartingPos()


    void Move()
    {
        Vector3 force = new Vector3(0, initialForce, 0);
        rb.AddForce(force);
    }


    private void OnCollisionEnter(Collision collision)
    {
        GameObject colGo = collision.gameObject;
        if (colGo.tag == "Brick")
        {
            score += 100;
            Destroy(colGo); //destroys
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "OutBounds") //checks tag
        {
            numOfBalls--; //decrements
        }

        if (numOfBalls <= 0)
        {
            score = 0; //resets score for further implementation
            
            
        }
        else
        {
            Invoke("SetStartingPos", 2f); // resets
        }
        
    }
}
