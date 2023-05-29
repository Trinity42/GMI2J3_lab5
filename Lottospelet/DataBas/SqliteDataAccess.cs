using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Dapper;
using System.Configuration;

namespace Lottospelet.DataBas
{
	public class SqliteDataAccess : ISqliteDataAccess
	{
		public List<T> LoadData<T>(string sql)
		{
			using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
			{
				var output = cnn.Query<T>(sql, new DynamicParameters());
				return output.ToList();
			}
		}

		public void SaveData<T>(T person, string sql)
		{
			using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
			{
				cnn.Execute(sql, person);
			}
		}
		public void UpdateData<T>(T person, string sql)
		{
			using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
			{
				cnn.Execute(sql, person);
			}
		}

		private string LoadConnectionString(string id = "Default")
		{
			return ConfigurationManager.ConnectionStrings[id].ConnectionString;
		}
	}
}
