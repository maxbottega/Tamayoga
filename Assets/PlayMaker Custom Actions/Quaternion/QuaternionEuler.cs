// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Quaternion")]
	[Tooltip("Returns a rotation that rotates z degrees around the z axis, x degrees around the x axis, and y degrees around the y axis (in that order).")]
	[HelpUrl("https://hutonggames.fogbugz.com/default.asp?W1094")]
	public class QuaternionEuler : FsmStateAction
	{
		[RequiredField]
		[Tooltip("The Euler angles.")]
		public FsmVector3 eulerAngles;
		
		[RequiredField]
		[UIHint(UIHint.Variable)]
		[Tooltip("Store the euler angles of this quaternion variable.")]
		public FsmQuaternion result;

		[Tooltip("Repeat every frame. Useful if any of the values are changing.")]
		public bool everyFrame;

		public override void Reset()
		{
			eulerAngles = null;
			result = null;
			everyFrame = true;
		}

		public override void OnEnter()
		{
			DoQuatEuler();

			if (!everyFrame)
			{
				Finish();
			}
		}

		public override void OnUpdate()
		{
			DoQuatEuler();
		}

		void DoQuatEuler()
		{
			result.Value = Quaternion.Euler(eulerAngles.Value);
		}
	}
}

