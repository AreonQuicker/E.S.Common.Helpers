using E.S.Common.Helpers.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E.S.Common.Helpers.Models
{
	public class CommonAPIResponseModel<T>
	{
		#region Constructor
		public CommonAPIResponseModel()
		{
			Warnings = new List<IWarning>();

		}

		public CommonAPIResponseModel(bool success, IList<IWarning> warnings, T data)
		{
			Success = success;
			Warnings = warnings;
			Data = data;
		}

		public CommonAPIResponseModel(bool success, IList<IWarning> warnings)
		{
			Success = success;
			Warnings = warnings;
		} 
		#endregion

		public T Data { get; set; }
		public bool Success { get; set; } = false;
		public IList<IWarning> Warnings { get; set; }


		#region Static Methods
		public static CommonAPIResponseModel<T> ToResponse(bool success, IList<IWarning> warnings, T Data) => new CommonAPIResponseModel<T>(success, warnings, Data);
		public static CommonAPIResponseModel<T> ToResponse(IList<IWarning> warnings, T Data) => new CommonAPIResponseModel<T>(!(warnings != null && warnings.Any()), warnings, Data);
		public static CommonAPIResponseModel<T> ToSuccessResponse(T Data) => new CommonAPIResponseModel<T>(true, null, Data);
		public static CommonAPIResponseModel<T> ToSuccessResponse() => new CommonAPIResponseModel<T>(true, null);
		public static CommonAPIResponseModel<T> ToFailureResponse(T Data) => new CommonAPIResponseModel<T>(false, null, Data);
		public static CommonAPIResponseModel<T> ToFailureResponse() => new CommonAPIResponseModel<T>(false, null);
		#endregion
	}
}

