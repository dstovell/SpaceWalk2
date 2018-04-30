using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CircularGravityForce;

namespace ZeroG
{
	public partial class ThirdPersonController : MonoBehaviour 
	{
		public Vector3 Gravity;

		private float GravityRotateSpeed = 20f;

		public enum GroundState
		{
			None,
			Falling,
			Grounded
		}
		public GroundState Ground = GroundState.None;

		private int SinceGravity = 0;

		protected void InitGravity()
		{
			CGF.OnApplyCGFEvent += CGF_OnApplyCGFEvent;
		}

		protected void DestroyGravity()
		{
			CGF.OnApplyCGFEvent -= CGF_OnApplyCGFEvent;
		}

		private void CGF_OnApplyCGFEvent(CGF cgf, Rigidbody rigid, Collider coll, Vector3 force)
		{
			this.Gravity = force;
			this.SinceGravity = 0;

			if (this.Ground == GroundState.None)
			{
				this.Ground = GroundState.Falling;
			}
		}

		void OnCollisionEnter(Collision hit)
		{
			if (hit.gameObject.tag == "walkable")
			{
				this.Ground = GroundState.Grounded;
			}
		}

		// Detect collision exit with floor
		void OnCollisionExit(Collision hit)
		{
			if (hit.gameObject.tag == "walkable")
			{
				this.Ground = GroundState.None;
			}
		}

		void UpdateGravity(float deltaTime)
		{
			if (this.IsFloating())
			{
				this.Gravity = Vector3.zero;
				return;
			}
			else if (this.IsFalling())
			{
				if (this.SinceGravity > 10)
				{
					this.Ground = GroundState.None;
				}
			}

			//this.transform.up = -1f*this.Gravity;

			this.transform.up = Vector3.RotateTowards(this.transform.up, -1f*this.Gravity, deltaTime*this.GravityRotateSpeed, 0.0f);



			this.SinceGravity++;
		}
	}
}