using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Report_DO
{
    public class DbConnectivity
    {
        private SqlConnection _mSqlConnection;
        private void InitConnection()
        {
            _mSqlConnection = new SqlConnection();
            _mSqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["PMSReports"].ConnectionString;
            if (_mSqlConnection.State == ConnectionState.Closed)
            {
                _mSqlConnection.Open();
            }
        }

        public SqlConnection Connection
        {
            get
            {
                if (_mSqlConnection == null)
                    InitConnection();
                else if (_mSqlConnection.State == ConnectionState.Closed)
                    _mSqlConnection.Open();

                return _mSqlConnection;

            }
        }
    }
}
