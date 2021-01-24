using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace КР_8
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in both code and config file together.
    public class Service : IService
    {
        public static string connectionString = @"Data Source=TH0;Initial Catalog=Warehouse;Integrated Security=True";
        public SqlConnection sqlConnection = new SqlConnection(connectionString);

        public DataInvoices[] GetInvoices()
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("SELECT invoice_id,  FORMAT (date, 'dd.MM.yyyy') as date, provider_id_fk, FORMAT(summary, 'C0') as summary FROM [Invoices]", sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<DataInvoices> data = new List<DataInvoices>();
            while (reader.Read())
            {
                DataInvoices info = new DataInvoices
                {
                    invoice_id = reader["invoice_id"].ToString(),
                    date = reader["date"].ToString(),
                    provider_id = reader["provider_id_fk"].ToString(),
                    summary = reader["summary"].ToString(),
                };
                data.Add(info);
            }
            reader.Close();
            sqlConnection.Close();
            return data.ToArray();
        }

        public DataProviders[] GetProviders()
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("SELECT provider_id, provider_name FROM [Providers]", sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<DataProviders> data = new List<DataProviders>();
            while (reader.Read())
            {
                DataProviders info = new DataProviders
                {
                    provider_id = reader["provider_id"].ToString(),
                    provider_name = reader["provider_name"].ToString(),
                };
                data.Add(info);
            }
            reader.Close();
            sqlConnection.Close();
            return data.ToArray();
        }

        public void NewInvoice(DateTime date, int provider_id, int summary)
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO[Invoices] (date, provider_id_fk, summary) VALUES (@date, @provider_id, @summary)", sqlConnection);
            command.Parameters.AddWithValue("date", date);
            command.Parameters.AddWithValue("provider_id", provider_id);
            command.Parameters.AddWithValue("summary", summary);
            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void NewProvider(string provider_name)
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO[Providers] (provider_name) VALUES (@provider_name)", sqlConnection);
            command.Parameters.AddWithValue("provider_name", provider_name);
            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public Dictionary<int, string> Providers()
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("SELECT provider_id, provider_name FROM [Providers]", sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            Dictionary<int, string> dict = new Dictionary<int, string>();
            while (reader.Read())
            {
                dict.Add(Convert.ToInt32(reader[0]), reader[1].ToString());
            }
            sqlConnection.Close();
            return dict;
        }
    }
}
