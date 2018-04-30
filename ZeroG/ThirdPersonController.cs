using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZeroG
{
	public partial class ThirdPersonController : MonoBehaviour 
	{
		public float RotateSpeed = 100;
		public float MoveSpeed = 8;
		public float JumpForce = 10;

		public Rigidbody RB;
		public ThirdPersonInput Input;

		public void Awake()
		{
			this.RB = this.GetComponent<Rigidbody>();
			this.Input = this.GetComponent<ThirdPersonInput>();

			this.InitGravity();
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

		public bool IsIdle()
		{
			return (this.RB.velocity.magnitude < 0.1f);
		}

		public bool IsWalking()
		{
			return (this.RB.velocity.magnitude > 0.1f);
		}

		public bool IsRunning()
		{
			return false;
		}

		public bool IsFloating()
		{
			return (this.Ground == GroundState.None);
		}

		public bool IsFalling()
		{
			return (this.Ground == GroundState.Falling);
		}

		public bool IsThrusting()
		{
			return false;
		}

		public bool IsOnGround()
		{
			return (this.Ground == GroundState.Grounded);
		}

		void FixedUpdate()
		{
			this.UpdateGravity();

			if (this.Input != null)
			{
				if (this.Input.Jump)
				{
					this.RB.AddForce(this.transform.up * this.JumpForce);
					this.Input.Jump = false;
				}

				//Quaternion to = Quaternion.AngleAxis(this.Input.MoveStick.x, this.transform.up);

				//this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, to, this.RotateSpeed);

				//this.transform.Rotate(this.transform.up, this.RotateSpeed*this.Input.MoveStick.x);

				this.Move(this.Input.MoveStick.y, Time.fixedDeltaTime);
			}
		}
	}
}