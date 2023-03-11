﻿using RMC.Core.Architectures.Umvcs.Model.Data;
using UnityEngine;

namespace RMC.Core.Architectures.Umvcs.Samples.MyBouncyBallExample.Umvcs.Model
{
	[CreateAssetMenu(fileName = "MainConfigData", 
		menuName = MyBouncyBallExampleConstants.CreateAssetMenuPath + "MainConfigData", 
		order = MyBouncyBallExampleConstants.CreateAssetMenuOrder)]

	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class MainConfigData : BaseConfigData
	{
		public int BounceCountMax { get { return _bounceCountMax; }  }

		public Vector3 InitialBouncyBallPosition { get { return _initialBouncyBallPosition; } }

		[SerializeField]
		private int _bounceCountMax = 10;

		[SerializeField]
		private Vector3 _initialBouncyBallPosition = new Vector3(0, 5, 0);

	}
}