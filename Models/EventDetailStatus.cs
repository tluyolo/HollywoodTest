using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HollywoodTest.Models
{
    public class EventDetailStatus
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["HollywoodTestEntitie"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW Even *********************
        public bool AddEventDetailStatus(EventDetailStatusModels Emodel)
        {
            int EventID =Convert.ToInt16(Emodel.EventDetailstatusID);
            connection();
            SqlCommand cmd = new SqlCommand("ProcEventDetailsStatus", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EventDetailsStatusID", EventID);
            cmd.Parameters.AddWithValue("@EventDetailstatusName",Emodel.EventDetailstatus.ToString ());
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                
            }
          catch(Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return true;

        }

        // ********** VIEW Event DETAILS ********************
        public List<EventDetailStatusModels> GetEventDetailstatus()
        {
            connection();
            List<EventDetailStatusModels> studentlist = new List<EventDetailStatusModels>();

            SqlCommand cmd = new SqlCommand("UpdateProcEventDetailsStatus", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                studentlist.Add(
                    new EventDetailStatusModels
                    {
                        EventDetailstatusID = Convert.ToInt32(dr["EventDatailStatusID"]),
                        EventDetailstatus = Convert.ToString(dr["EventDatailStatusName"])
                     
                    });
            }
            return studentlist;
        }

        // ***************** UPDATE Event DETAILS *********************
        public bool UpdateDetails(EventDetailStatusModels Emodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateProcEventDetailsStatus", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EventDetailstatusID", Emodel.EventDetailstatusID);
            cmd.Parameters.AddWithValue("@EventDetailstatusName", Emodel.EventDetailstatus);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********************** DELETE Event DETAILS *******************
        public bool DeleteEventDetailstatus(int EventDetailstatusId)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteProcEventDetailsStatus", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EventDetailStatusID", EventDetailstatusId);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}