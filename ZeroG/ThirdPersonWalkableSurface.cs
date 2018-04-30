using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CircularGravityForce;

namespace ZeroG
{
	public class ThirdPersonWalkableSurface : MonoBehaviour 
	{
		public CircularGravityForce.CGF GravitySource;

		void Awake()
		{
			this.GravitySource = this.GetComponent<CircularGravityForce.CGF>();
			this.gameObject.tag = "walkable";
		}
	}
}