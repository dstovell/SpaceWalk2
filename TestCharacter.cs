using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCharacter : MonoBehaviour 
{
	public Animator Anim;
	public bool Run = false;
	public bool Walk = false;
	public bool Idle = false;

	void Start () 
	{
	}
		
	void DisableAnimations ()
	{
		Anim.SetBool ("Idle", false);
		Anim.SetBool ("Walk", false);
		Anim.SetBool ("Run", false);
	}

	void Update () 
	{
		if (this.Run) 
		{
			DisableAnimations();
			Anim.SetBool("Run", true);
			this.Run = false;
		}
		else if (this.Walk) 
		{
			DisableAnimations();
			Anim.SetBool("Walk", true);
			this.Walk = false;
		}
		else if (this.Idle) 
		{
			DisableAnimations();
			Anim.SetBool("Idle", true);
			this.Idle = false;
		}
	}
}
