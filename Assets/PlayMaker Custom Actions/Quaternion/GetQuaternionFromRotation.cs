// (c) Copyright HutongGames, LLC 2010-2012. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Quaternion")]
	[Tooltip("Creates a rotation which rotates from fromDirection to toDirection. Usually you use this to rotate a transform so that one of its axes eg. the y-axis - follows a target direction toDirection in world space.")]
	[HelpUrl("https://hutonggames.fogbugz.com/default.asp?W968")]
	public class GetQuaternionFromRotation : FsmStateAction
	{

		[RequiredField]
		[Tooltip("the 'from' direction")]
		public FsmVector3 fromDirection;
		
		[RequiredField]
		[Tooltip("the 'to' direction")]
		public FsmVector3 toDirection;
		
		[RequiredField]
		[UIHint(UIHint.Variable)]
		[Tooltip("the resulting quaternion")]
		public FsmQuaternion result;
		
		[Tooltip("Repeat every frame.")]
		public bool everyFrame;

		public override void Reset()
		{
			fromDirection = null;
			toDirection = null;
	
			result = null;
			everyFrame = false;
		
		}

		public override void OnEnter()
		{
			DoQuatFromRotation();
			
			if (!everyFrame)
			{
				Finish();
			}
		}

		public override void OnUpdate()
		{
			DoQuatFromRotation();
		}
		
		void DoQuatFromRotation()
		{
			result.Value = Quaternion.FromToRotation(fromDirection.Value,toDirection.Value);		
		}
	}
}