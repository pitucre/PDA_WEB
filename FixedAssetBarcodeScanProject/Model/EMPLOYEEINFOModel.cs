using System;
namespace CCT.Model
{
	/// <summary>
	/// EMPLOYEEINFO:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EMPLOYEEINFOModel
	{
		public EMPLOYEEINFOModel()
		{}
		#region Model
		private string _employeecode;
		private string _employeename;
		private string _cctemployeecode;
		/// <summary>
		/// 员工编码
		/// </summary>
		public string EMPLOYEECODE
		{
			set{ _employeecode=value;}
			get{return _employeecode;}
		}
		/// <summary>
		/// 员工名称
		/// </summary>
		public string EMPLOYEENAME
		{
			set{ _employeename=value;}
			get{return _employeename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CCTEMPLOYEECODE
		{
			set{ _cctemployeecode=value;}
			get{return _cctemployeecode;}
		}
		#endregion Model

	}
}

