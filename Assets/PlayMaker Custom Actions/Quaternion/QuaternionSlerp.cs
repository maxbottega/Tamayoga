// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Quaternion")]
	[Tooltip("Spherically interpolates between from and to by t.")]
	[HelpUrl("https://hutonggames.fogbugz.com/default.asp?W1093")]
	public class QuaternionSlerp : FsmStateAction
	{
		[RequiredField]
		[Tooltip("From Quaternion.")]
		public FsmQuaternion fromQuaternion;
		
		[RequiredField]
		[Tooltip("To Quaternion.")]
		public FsmQuaternion toQuaternion;
		
		[RequiredField]
		[Tooltip("Interpolate between fromQuaternion and toQuaternion by this amount. Value is clamped to 0-1 range. 0 = fromQuaternion; 1 = toQuaternion; 0.5 = half way between.")]
		[HasFloatSlider(0f, 1f)]
		public FsmFloat amount;
		
		[RequiredField]
		[UIHint(UIHint.Variable)]
		[Tooltip("Store the result in this quaternion variable.")]
		public FsmQuaternion storeResult;

		[Tooltip("Repeat every frame. Useful if any of the values are changing. SHOULD BE ALWAYS TRUE")]
		public bool everyFrame;

		public override void Reset()
		{
			fromQuaternion = new FsmQuaternion { UseVariable = true };
			toQuaternion = new FsmQuaternion { UseVariable = true };
			amount = 0.1f;
			storeResult = null;
			everyFrame = true;
		}

		public override void OnEnter()
		{
			DoQuatSlerp();

			if (!everyFrame)
			{
				Finish();
			}
		}

		public override void OnUpdate()
		{
			DoQuatSlerp();
		}

		void DoQuatSlerp()
		{
			storeResult.Value = Quaternion.Slerp(fromQuaternion.Value, toQuaternion.Value, amount.Value);
		}
	}
}

