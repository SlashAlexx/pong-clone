using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    [SerializeField] private GameObject ball;
	[SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private float AI_Velocity, lerpSpeed, distanceBuffer;


    void FixedUpdate()
    {
        // If ball + or - offset is greater than AI position
        if ((ball.transform.position.y + distanceBuffer) > transform.position.y && (ball.transform.position.y - distanceBuffer) > transform.position.y)
        {
            if (rigidBody.velocity.y < 0) rigidBody.velocity = Vector2.zero; //assures velocity is zero
            rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, Vector2.up * AI_Velocity, lerpSpeed * Time.deltaTime); //increase velocity to match with ball y position
        }

		// If ball + or - offset is lesser than AI position
		if ((ball.transform.position.y + distanceBuffer) < transform.position.y && (ball.transform.position.y - distanceBuffer) < transform.position.y)
        {
            if (rigidBody.velocity.y > 0) rigidBody.velocity = Vector2.zero;  //assures velocity is zero
			rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, Vector2.down * AI_Velocity, lerpSpeed * Time.deltaTime);//increase velocity to match with ball y position
        }
        else
        {
            //rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, Vector2.zero * AI_Velocity, lerpSpeed * Time.deltaTime); //increase velocity to match with ball y position
        }
    }
}
