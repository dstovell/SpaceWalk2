using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZeroG
{
	public class ThirdPersonController : MonoBehaviour 
	{
		public float RotateSpeed = 100;
		public float MoveSpeed = 8;

		public Rigidbody RB;
		public ThirdPersonInput Input;

		public void Awake()
		{
			this.RB = this.GetComponent<Rigidbody>();
			this.Input = this.GetComponent<ThirdPersonInput>();
		}

		public void Move(float inputAmount, float deltaTime)
		{
			this.Move( this.MoveSpeed*inputAmount*this.transform.forward, deltaTime );
		}

		public void Move(Vector3 motion, float deltaTime)
		{
			this.Move( deltaTime*motion );
		}

		public void Move(Vector3 motion)
		{
			Vector3 currentPos = this.transform.position;

			Vector3 targetPos = currentPos + motion;

			this.RB.MovePosition(targetPos);
		}

		public void Stop()
		{
			this.RB.velocity = Vector3.zero;
		}

		void FixedUpdate()
		{
			if (this.Input != null)
			{
				if (this.Input.ActiveInput)
				{
					//Quaternion to = Quaternion.AngleAxis(this.Input.MoveStick.x, this.transform.up);

					//this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, to, this.RotateSpeed);

					//this.transform.Rotate(this.transform.up, this.RotateSpeed*this.Input.MoveStick.x);

					this.Move(this.Input.MoveStick.y, Time.fixedDeltaTime);
				}
				else
				{
					//Stop();
				}
			}
		}
	}
}