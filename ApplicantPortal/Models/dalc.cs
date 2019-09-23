using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Web;

namespace ApplicantPortal.Models
{
    public class dalc
    {
        SqlConnection conn= new SqlConnection(ConfigurationManager.ConnectionStrings["Dalc_Conn"].ConnectionString);

        public dalc()
        {
            //conn.ConnectionString = ConfigurationSettings.AppSettings["myconn"];
            // conn.ConnectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        }

        public DataSet selectbyquery(string str)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 0;
            cmd.Connection = conn;
            cmd.CommandText = str.ToString();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                conn.Open();
                da.Fill(ds);
                return ds;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
            }
        }
        public DataTable selectbyspdt(string str, SqlParameter[] para)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 0;
            cmd.Connection = conn;
            if(para != null)
            {
                cmd.Parameters.AddRange(para);
            }
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = str.ToString();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                conn.Open();
                da.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
            }
        }
        public SqlCommand GetCommand()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 0;
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd;
        }
        public DataSet GetDataset(string Spname, SqlParameter[] para)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = GetCommand();
            cmd.Parameters.AddRange(para);
            cmd.CommandText = Spname.ToString();
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                conn.Open();
                da.Fill(ds);
                return ds;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
            }
        }
        public DataTable GetDataTable(string Query, SqlParameter[] para)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            if(para.Length != 0)
            {
                cmd.Parameters.AddRange(para);
            }
            cmd.CommandTimeout = 0;
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.CommandText = Query.ToString();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                conn.Open();
                da.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
            }
        }

        public DataTable GetDataTable_Text(string Query, SqlParameter[] para)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 0;
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddRange(para);
            cmd.CommandText = Query.ToString();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                conn.Open();
                da.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
               // conn.Dispose();
            }
        }

        public string IUD(string SPName, SqlParameter[] para)
        {
            string result = "";
            SqlCommand cmd = GetCommand();
            cmd.CommandText = SPName.ToString();
            cmd.Parameters.AddRange(para);
            try
            {
                conn.Open();
                result=(string)cmd.ExecuteScalar();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
            }
        }

        public void updatedata(string str)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 0;
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = str;
            //cmd.Parameters.AddRange(para);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }
        }
    }

}
