// (c) Copyright HutongGames, LLC 2010-2012. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Quaternion")]
	[Tooltip("Get the vector3 from a quaternion multiplied by a vector.")]
	[HelpUrl("https://hutonggames.fogbugz.com/default.asp?W970")]
	public class GetQuaternionMultipliedByVector : FsmStateAction
	{

		[RequiredField]
		[Tooltip("The quaternion to multiply")]
		public FsmQuaternion quaternion;
		
		[RequiredField]
		[Tooltip("The vector3 to multiply")]
		public FsmVector3 vector3;
		
		[RequiredField]
		[UIHint(UIHint.Variable)]
		[Tooltip("The resulting vector3")]
		public FsmVector3 result;
		
		[Tooltip("Repeat every frame.")]
		public bool everyFrame;

		public override void Reset()
		{
			quaternion = null;
			vector3 = null;
	
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
			result.Value = quaternion.Value * vector3.Value;		
		}
	}
}