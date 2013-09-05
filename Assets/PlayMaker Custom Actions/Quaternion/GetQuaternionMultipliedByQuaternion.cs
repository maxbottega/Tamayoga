// (c) Copyright HutongGames, LLC 2010-2012. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Quaternion")]
	[Tooltip("Get the quaternion from a quaternion multiplied by a quaternion.")]
	[HelpUrl("https://hutonggames.fogbugz.com/default.asp?W969")]
	public class GetQuaternionMultipliedByQuaternion : FsmStateAction
	{

		[RequiredField]
		[Tooltip("The first quaternion to multiply")]
		public FsmQuaternion quaternionA;
		
		[RequiredField]
		[Tooltip("The second quaternion to multiply")]
		public FsmQuaternion quaternionB;
		
		[RequiredField]
		[UIHint(UIHint.Variable)]
		[Tooltip("The resulting quaternion")]
		public FsmQuaternion result;
		
		[Tooltip("Repeat every frame.")]
		public bool everyFrame;

		public override void Reset()
		{
			quaternionA = null;
			quaternionB = null;
	
			result = null;
			everyFrame = false;
		
		}

		public override void OnEnter()
		{
			DoQuatMult();
			
			if (!everyFrame)
			{
				Finish();
			}
		}

		public override void OnUpdate()
		{
			DoQuatMult();
		}
		
		void DoQuatMult()
		{
			result.Value = quaternionA.Value * quaternionB.Value;		
		}
	}
}