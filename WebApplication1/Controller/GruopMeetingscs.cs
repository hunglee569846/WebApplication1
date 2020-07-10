using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controller
{
    public class GruopMeetingscs
    {
        public static IEnumerable<GroupMeeting> GetGroupMeetings()
        {
            List<GroupMeeting> groupMeetingsList = new List<GroupMeeting>();
            using (IDbConnection con = new SqlConnection(GroupMeeting.strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                groupMeetingsList = con.Query<GroupMeeting>("GetGroupMeetingDetails").ToList();
            }

            return groupMeetingsList;
        }
        public static GroupMeeting GetGroupMeetingByID(int? Id)
        {
            GroupMeeting groupMeeting = new GroupMeeting();
            if (Id == null)
                return groupMeeting;
            using (IDbConnection con = new SqlConnection(GroupMeeting.strConnectionString))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id);
                groupMeeting = con.Query<GroupMeeting>
                ("GetGroupMeetingByID", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return groupMeeting;
        }

        public static int AddGroupMeeting(GroupMeeting groupMeeting)
        {
            int rowAffectted = 0;
            try
            {

                using (IDbConnection con = new SqlConnection(GroupMeeting.strConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@ProjectName", groupMeeting.ProjectName);
                    parameters.Add("@GroupMeetingLeadName", groupMeeting.GroupMeetingLeadName);
                    parameters.Add("@TeamLeadName", groupMeeting.TeamLeadName);
                    parameters.Add("@Description", groupMeeting.Description);
                    parameters.Add("@GroupMeetingDate", groupMeeting.GroupMeetingDate);

                    rowAffectted = con.Execute("InsertGroupMeeting", parameters, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return rowAffectted;
        }
        public static int UpdateGroupMeeting(GroupMeeting groupMeeting)
        {
            {
                int rowAffected = 0;

                using (IDbConnection con = new SqlConnection(GroupMeeting.strConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@Id", groupMeeting.Id);
                    parameters.Add("@ProjectName", groupMeeting.ProjectName);
                    parameters.Add("@GroupMeetingLeadName", groupMeeting.GroupMeetingLeadName);
                    parameters.Add("@TeamLeadName", groupMeeting.TeamLeadName);
                    parameters.Add("@Description", groupMeeting.Description);
                    parameters.Add("@GroupMeetingDate", groupMeeting.GroupMeetingDate);
                    rowAffected = con.Execute("UpdateGroupMeeting", parameters, commandType: CommandType.StoredProcedure);
                }

                return rowAffected;
            }
        }

        public static int DeleteGroupMeeting(int id)
        {
            int rowAffected = 0;
            using (IDbConnection con = new SqlConnection(GroupMeeting.strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                rowAffected = con.Execute("DeleteGroupMeeting", parameters, commandType: CommandType.StoredProcedure);
            }
            return rowAffected;
        }
    }
}
