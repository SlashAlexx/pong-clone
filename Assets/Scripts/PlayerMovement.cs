using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float playerSpeed; //Set in inspector

    void FixedUpdate()
    {
        float verticalInput = Input.GetAxisRaw("Vertical"); // Gets input value from vertical arrow keys,either 1 or -1;
        transform.Translate(new Vector2(0, 1) * verticalInput * playerSpeed * Time.deltaTime); //Translates object on y axis by speed and factor of input

        if (transform.position.y > 4.4757f) { transform.position = new Vector2(transform.position.x, 4.4757f); } //Checks upper constraint
        if (transform.position.y < -4.4757f) { transform.position = new Vector2(transform.position.x, -4.4757f); } //Checks lower constraint
    }
}
