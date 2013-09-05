// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Quaternion")]
	[Tooltip("Creates a rotation which rotates angle degrees around axis.")]
	[HelpUrl("https://hutonggames.fogbugz.com/default.asp?W1095")]
	public class QuaternionAngleAxis : FsmStateAction
	{
		[RequiredField]
		[Tooltip("The angle.")]
		public FsmFloat angle;
		
		[RequiredField]
		[Tooltip("The rotation axis.")]
		public FsmVector3 axis;
		
		[RequiredField]
		[UIHint(UIHint.Variable)]
		[Tooltip("Store the rotation of this quaternion variable.")]
		public FsmQuaternion result;

		[Tooltip("Repeat every frame. Useful if any of the values are changing.")]
		public bool everyFrame;

		public override void Reset()
		{
			angle = null;
			axis = null;
			result = null;
			everyFrame = true;
		}

		public override void OnEnter()
		{
			DoQuatAngleAxis();

			if (!everyFrame)
			{
				Finish();
			}
		}

		public override void OnUpdate()
		{
			DoQuatAngleAxis();
		}

		void DoQuatAngleAxis()
		{
			result.Value = Quaternion.AngleAxis(angle.Value,axis.Value);
		}
	}
}

