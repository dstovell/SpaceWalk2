using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnim : MonoBehaviour 
{
	public Rigidbody RB;

	public Animator Anim;
	public bool Run = false;
	public bool Walk = false;
	public bool Idle = false;

	private List<string> Animations = new List<string> ();
	private string LastAnim = "";

	public void AddAnimation(string name)
	{
		this.Animations.Add(name);
	}

	public void SetAnimation(string name)
	{
		if (this.LastAnim == name)
		{
			return;
		}

		for (int i=0; i<this.Animations.Count; i++) 
		{
			if (this.Animations[i] == name)
			{
				this.Anim.SetBool(this.Animations[i], true);
				this.LastAnim = name;
			}
			else
			{
				this.Anim.SetBool(this.Animations[i], false);
			}
		}
	}

	void Start() 
	{
		this.SetupAnimations();
		this.RB = this.GetComponent<Rigidbody>();
	}

	void SetupAnimations()
	{
		AddAnimation("Idle");
		AddAnimation("Walk");
		AddAnimation("Jog");
	}

	void Update() 
	{
		Vector3 velocity = this.RB.velocity;
		float speed = velocity.magnitude;
		if (speed > 5)
		{
			this.SetAnimation("Run");
		}
		else if (speed > 0.01f)
		{
			this.SetAnimation("Walk");
		}
		else
		{
			this.SetAnimation("Idle");
		}
	}
}
