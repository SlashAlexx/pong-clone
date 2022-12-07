using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ButtonMoveOver : MonoBehaviour
{
    [SerializeField] private Animator anim;

	private float animDirection;

	private void Start()
	{
		animDirection = 1.0f;
	}

	public void CustomizeButtonPress()
    {
		if(animDirection == 1.0f)
		{
			anim.SetFloat("Direction", 1);
			anim.Play("ButtonMoveOverAnim");
		}
		else
		{
			anim.SetFloat("Direction", -1);
			anim.Play("ButtonMoveOverAnim");
		}

		animDirection = -animDirection;
	}
}
