using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnim : MonoBehaviour 
{
	public Animator Anim;
	public bool Run = false;
	public bool Walk = false;
	public bool Idle = false;

	private List<string> Animations = new List<string> ();

	public void AddAnimation(string name)
	{
		this.Animations.Add(name);
	}

	public void SetAnimation(string name)
	{
		for (int i=0; i<this.Animations.Count; i++) 
		{
			if (this.Animations[i] == name)
			{
				this.Anim.SetBool(this.Animations[i], true);
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
	}

	void SetupAnimations()
	{
		AddAnimation("Idle");
		AddAnimation("Walk");
		AddAnimation("Run");
	}

	void Update() 
	{
		if (this.Run) 
		{
			this.SetAnimation("Run");
			this.Run = false;
		}
		else if (this.Walk) 
		{
			this.SetAnimation("Walk");
			this.Walk = false;
		}
		else if (this.Idle) 
		{
			this.SetAnimation("Idle");
			this.Idle = false;
		}
	}
}
