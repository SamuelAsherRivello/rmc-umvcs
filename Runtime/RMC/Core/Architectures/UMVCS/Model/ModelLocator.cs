﻿using System.Collections.Generic;
using System.Linq;

namespace RMC.Core.Architectures.Umvcs.Model
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class ModelLocator
	{
		private List<BaseModel> _models;

		public ModelLocator()
		{
			_models = new List<BaseModel>();
		}

		public void AddModel(BaseModel baseModel)
		{
			_models.Add(baseModel);
		}

		public T GetModel<T>() where T: BaseModel
		{
			return _models.OfType<T>().ToList().FirstOrDefault<T>();
		}

		public void RemoveModel(BaseModel baseModel)
		{
			_models.Remove(baseModel);
		}
	}
}