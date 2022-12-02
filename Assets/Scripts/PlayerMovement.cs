using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed; //Player Speed

    void FixedUpdate()
    {
        float verticalInput = Input.GetAxisRaw("Vertical"); // Gets input value from vertical arrow keys, either 1 or -1;
        transform.Translate(new Vector2(0, 1) * verticalInput * speed * Time.deltaTime); //Translates object on y axis by speed, and factor of input

        //Debug.Log(transform.position.y); // Check position of player for bounds vvv
        if (transform.position.y > 4.4757f) { transform.position = new Vector2(transform.position.x, 4.4757f); } //Checks upper constraint
        if (transform.position.y < -4.4757f) { transform.position = new Vector2(transform.position.x, -4.4757f); } //Checks lower constraint
    }
}
