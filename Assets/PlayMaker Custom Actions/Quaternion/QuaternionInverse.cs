// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Quaternion")]
	[Tooltip("Inverse a quaternion")]
	//[HelpUrl("https://hutonggames.fogbugz.com/default.asp?W1094")]
	public class QuaternionInverse : FsmStateAction
	{
		[RequiredField]
		[Tooltip("the rotation")]
		public FsmQuaternion rotation;
		
		[RequiredField]
		[UIHint(UIHint.Variable)]
		[Tooltip("Store the inverse of the rotation variable.")]
		public FsmQuaternion result;

		[Tooltip("Repeat every frame. Useful if any of the values are changing.")]
		public bool everyFrame;

		public override void Reset()
		{
			rotation = null;
			result = null;
			everyFrame = true;
		}

		public override void OnEnter()
		{
			DoQuatInverse();

			if (!everyFrame)
			{
				Finish();
			}
		}

		public override void OnUpdate()
		{
			DoQuatInverse();
		}

		void DoQuatInverse()
		{
			result.Value = Quaternion.Inverse(rotation.Value);
		}
	}
}

