using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rfidsinfo;

namespace DBconnection
{
    public class MyConnection
    {
        public static SqlConnection OpenConnection()
        {
            string connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=testDB;User ID=NVS123;Password=nvs";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            return conn;
        }

        public static void Add(rfidinfo info)
        {
            SqlConnection conn = OpenConnection();
            try
            {
                string sql = "insert into " +
                    "RFIDtbl (RFID, Type)" +
                    " values (@rfid, @type)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@rfid", SqlDbType.VarChar).Value = info.RFID;
                cmd.Parameters.Add("@type", SqlDbType.VarChar).Value = info.Type;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public static void Edit(rfidinfo info, string id)
        {
            SqlConnection conn = OpenConnection();
            try
            {
                string sql = "update RFIDtbl set Type = @type " +
                    "where RFID = @rfid";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@rfid", SqlDbType.VarChar).Value = id;
                cmd.Parameters.Add("@type", SqlDbType.VarChar).Value = info.Type;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        public static void Delete(string ID)
        {
            SqlConnection conn = OpenConnection();
            try
            {
                string sql = "DELETE from RFIDtbl where RFID = @rfid";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@rfid", SqlDbType.VarChar).Value = ID;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public static bool Check(rfidinfo info)
        {
            SqlConnection conn = OpenConnection();
            int count = default;
            bool isFound = default;
            try
            {
                string sql = "SELECT COUNT(RFID) FROM RFIDtbl WHERE(RFID = @rfid and Type = @type)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@rfid", SqlDbType.VarChar).Value = info.RFID;
                cmd.Parameters.Add("@type", SqlDbType.VarChar).Value = info.Type;
                count = (int)cmd.ExecuteScalar();
                isFound = Convert.ToBoolean(count);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
                
            }
            return isFound;
        }
        public static List<rfidinfo> GetTable(string Q)
        {
            string sql = Q;
            SqlConnection conn = OpenConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<rfidinfo> ms = new List<rfidinfo>();
            while (reader.Read())
            {
                rfidinfo m = new rfidinfo();
                m.RFID = (string)reader["RFID"];
                m.Type = (string)reader["Type"];
                ms.Add(m);
            }
            conn.Close();
            return ms;
        }
    }
}