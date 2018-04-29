﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZeroG
{
	public class ThirdPersonInput : MonoBehaviour 
	{
		public const float DeadZone = 0.1f;

		public string MoveStickNameX = "HorizontalLS";
		public string MoveStickNameY = "VerticalLS";
		public string LookStickNameX = "HorizontalRS";
		public string LookStickNameY = "VerticalRS";

		public bool ActiveInput = false;
		public Vector2 MoveStick;
		public Vector2 LookStick;

		private float GetAxis(string name) 
		{
			float v = Input.GetAxis(name);
			if (Mathf.Abs(v) < DeadZone)
			{
				v = 0f;
			}
			return v;
		}

		void Awake()
		{
		}

		public void Update()
		{
			this.MoveStick = new Vector2( this.GetAxis(MoveStickNameX), this.GetAxis(MoveStickNameY) );
			this.LookStick = new Vector2( this.GetAxis(LookStickNameX), this.GetAxis(LookStickNameY) );

			this.ActiveInput = true;//(this.MoveStick.Equals(Vector3.zero) || this.LookStick.Equals(Vector3.zero));
		}
	}
}