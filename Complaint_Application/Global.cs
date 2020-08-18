using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Complaint_Application
{
    public class Global
    {
        public static int CountRows(string query, string connString)
        {
            int Count = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // define command to be stored procedure
                        cmd.CommandType = CommandType.Text;
                        // open connection, execute command, close connection
                        conn.Open();
                        Count = (int)cmd.ExecuteScalar();
                        conn.Close();
                    }
                }
                return Count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Count;
        }
        public static DataTable GetDataTable(string query, string connString)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return dt;
        }
        public static void InsertDeleteUpdate(string query, string constring)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(constring))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("InsUpDel: " + Environment.NewLine + query + Environment.NewLine + ex);
            }
        }
    }
}