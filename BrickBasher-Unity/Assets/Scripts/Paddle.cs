/**** 
 * Created by: Bob Baloney
 * Date Created: April 20, 2022
 * 
 * Last Edited by: 
 * Last Edited:
 * 
 * Description: Paddle controler on Horizontal Axis
****/

/*** Using Namespaces ***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 10; //speed of paddle


    // Update is called once per frame
    void Update()
    {
        float posX = transform.position.x;
        float posY = transform.position.y;
        float posZ = transform.position.z;
        float moveX = Input.GetAxis("Horizontal");
        Vector3 newPos = new Vector3(posX + (moveX * speed * Time.deltaTime), posY, posZ);
        transform.position = newPos;
    }//end Update()
}
