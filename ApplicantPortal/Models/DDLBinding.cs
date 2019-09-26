using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApplicantPortal.Models
{
    public class DDLBinding
    {
        public DDLBinding(string type, string keyword, string RelatedValue, string whereclause = null, Boolean IsPopup = false, string Type = "LIST")
        {

            this.Count = 50;
            List<ColumnInfo> lstColumns = new List<ColumnInfo>();
            this.Type = Type;
            if (type == "BoardMaster")
            {
                this.TableName = "BoardMaster";
                this.DisplayColumnName = "BoardName";
                this.Keyword = keyword;
                this.ValueColumnName = "BoardId";
                if (!IsPopup)
                    this.Result = this.GetData();
                else
                {
                    this.PopupTitle = "Select BoardName From List";
                    lstColumns.Add(new ColumnInfo() { title = "Board Name", field = "BoardName", show = true, sortable = "BoardName", filter = new Dictionary<string, string>() { { "BoardName", "text" } } });
                    this.PopupColumns = lstColumns;
                }
            }
            else if (type == "NationalityMaster")
            {
                this.TableName = "NationalityMaster";
                this.DisplayColumnName = "Name";
                this.Keyword = keyword;
                this.ValueColumnName = "Id";
                this.WhereCalue = "";
                if (!IsPopup)
                    this.Result = this.GetData();
                else
                {
                    this.PopupTitle = "Select Category From List";
                    lstColumns.Add(new ColumnInfo() { title = "Category Name", field = "CategoryName", show = true, sortable = "CategoryName", filter = new Dictionary<string, string>() { { "CategoryName", "text" } } });
                    this.PopupColumns = lstColumns;
                }
            }
            else if (type == "DistrictMaster")
            {
                this.TableName = "DistrictMaster";
                this.DisplayColumnName = "DistrictName";
                this.Keyword = keyword;
                this.ValueColumnName = "DistrictId";
                this.WhereCalue = " ISNULL(IsActive,1)=1 " + whereclause;
                if (!IsPopup)
                    this.Result = this.GetData();
                else
                {
                    this.PopupTitle = "Select Category From List";
                    lstColumns.Add(new ColumnInfo() { title = "Category Name", field = "CategoryName", show = true, sortable = "CategoryName", filter = new Dictionary<string, string>() { { "CategoryName", "text" } } });
                    this.PopupColumns = lstColumns;
                }
            }
            else if (type == "CollegeMaster")
            {
                this.TableName = "CollegeMaster";
                this.DisplayColumnName = "CollegeName";
                this.Keyword = keyword;
                this.ValueColumnName = "CollegeId";
                this.WhereCalue = " ISNULL(IsActive,1)=1 " + whereclause;
                if (!IsPopup)
                    this.Result = this.GetData();
                else
                {
                    this.PopupTitle = "Select Category From List";
                    lstColumns.Add(new ColumnInfo() { title = "Category Name", field = "CategoryName", show = true, sortable = "CategoryName", filter = new Dictionary<string, string>() { { "CategoryName", "text" } } });
                    this.PopupColumns = lstColumns;
                }
            }
            else if (type == "StreamMaster")
            {
                this.TableName = "StreamMaster";
                this.DisplayColumnName = "StreamName";
                this.Keyword = keyword;
                this.ValueColumnName = "StreamId";
                this.WhereCalue = " ISNULL(IsActive,1)=1 ";
                if (!IsPopup)
                    this.Result = this.GetData();
                else
                {
                    this.PopupTitle = "Select InterviweeCandidate From List";
                    lstColumns.Add(new ColumnInfo() { title = "CandidateRef Number", field = "CandidateRefno", show = true, sortable = "CandidateRefno", filter = new Dictionary<string, string>() { { "CandidateRefno", "text" } } });
                    this.PopupColumns = lstColumns;
                }
            }
            else if (type == "MotherToungeMaster")
            {
                this.TableName = "MotherToungeMaster";
                this.DisplayColumnName = "Name";
                this.Keyword = keyword;
                this.ValueColumnName = "Id";
                this.WhereCalue = "";
                if (!IsPopup)
                    this.Result = this.GetData();
                else
                {
                    this.PopupTitle = "Select InterviweeCandidate From List";
                    lstColumns.Add(new ColumnInfo() { title = "CandidateRef Number", field = "CandidateRefno", show = true, sortable = "CandidateRefno", filter = new Dictionary<string, string>() { { "CandidateRefno", "text" } } });
                    this.PopupColumns = lstColumns;
                }
            }
            else if (type == "YearMaster")
            {
                this.TableName = "YearMaster";
                this.DisplayColumnName = "Year";
                this.Keyword = keyword;
                this.ValueColumnName = "Year";
                this.WhereCalue = "";
                if (!IsPopup)
                    this.Result = this.GetData();
                else
                {
                    this.PopupTitle = "Select InterviweeCandidate From List";
                    lstColumns.Add(new ColumnInfo() { title = "User Name", field = "FirstName + ' ' + SurName", show = true, sortable = "FirstName + ' ' + SurName", filter = new Dictionary<string, string>() { { "FirstName + ' ' + SurName", "text" } } });
                    this.PopupColumns = lstColumns;
                }
            }
            else if(type == "GenderMaster")
            {
                this.TableName = "GenderMaster";
                this.DisplayColumnName = "Name";
                this.Keyword = keyword;
                this.ValueColumnName = "Id";
                this.WhereCalue = "";
                this.Result = this.GetData();

            }
            else if (type == "StateMaster")
            {
                this.TableName = "StateMaster";
                this.DisplayColumnName = "StateName";
                this.Keyword = keyword;
                this.ValueColumnName = "StateId";
                this.WhereCalue = "";
                this.Result = this.GetData();

            }
            else if (type == "ReligionMaster")
            {
                this.TableName = "ReligionMaster";
                this.DisplayColumnName = "Name";
                this.Keyword = keyword;
                this.ValueColumnName = "Id";
                this.WhereCalue = "";
                this.Result = this.GetData();

            }
            else if (type == "BloodGroupMaster")
            {
                this.TableName = "BloodGroupMaster";
                this.DisplayColumnName = "Name";
                this.Keyword = keyword;
                this.ValueColumnName = "Id";
                this.WhereCalue = "";
                this.Result = this.GetData();

            }
            else if (type == "BlockMaster")
            {
                this.TableName = "BlockMaster";
                this.DisplayColumnName = "Name";
                this.Keyword = keyword;
                this.ValueColumnName = "Id";
                this.WhereCalue = "";
                this.Result = this.GetData();

            }


        }

        public List<DDLBindingData> GetData()
        {
            SqlParameter[] para = new SqlParameter[7];
            para[0] = new SqlParameter().CreateParameter("@TableName", this.TableName, 500);
            para[1] = new SqlParameter().CreateParameter("@DisplayColumnName", this.DisplayColumnName, 1000);
            para[2] = new SqlParameter().CreateParameter("@Keyword", this.Keyword);
            para[3] = new SqlParameter().CreateParameter("@ValueColumnName", this.ValueColumnName);
            para[4] = new SqlParameter().CreateParameter("@Count", this.Count);
            para[5] = new SqlParameter().CreateParameter("@WhereClause", this.WhereCalue, 500);
            para[6] = new SqlParameter().CreateParameter("@Type", this.Type);
            return new dalc().GetDataTable("GetAutoCompleteData", para).ConvertToList<DDLBindingData>();
        }

        public string TableName { get; set; }
        public string Keyword { get; set; }
        public string DisplayColumnName { get; set; }
        public string ValueColumnName { get; set; }
        public int Count { get; set; }
        public List<DDLBindingData> Result { get; set; }
        public List<ColumnInfo> PopupColumns { get; set; }
        public string PopupTitle { get; set; }
        public string WhereCalue { get; set; }
        public string Type { get; set; }
    }

    public class DDLBindingData
    {
        public string Name { get; set; }
        public string ID { get; set; }
    }

    public class ColumnInfo
    {
        public string title { get; set; }
        public string field { get; set; }
        public string sortable { get; set; }
        public Boolean show { get; set; }
        public Dictionary<string, string> filter { get; set; }
        public string cellTemplte { get; set; }
    }
   
}