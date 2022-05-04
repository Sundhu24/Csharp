using Microsoft.AspNetCore.Mvc;
using ProjectManagementAPI.Models;
using System.Data;
using System.Data.SqlClient;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeammemberController : ControllerBase
    {
        IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public TeammemberController(IConfiguration config, IWebHostEnvironment env)
        {
            _configuration = config;
            _env = env;
        }
       

        // POST api/<TeammemberController>
        [HttpPost("Team member Creation")]
        public StatusResponse Post(Team_member teamdata)
        {
            StatusResponse _objResponseModel = new StatusResponse();

            //To check if the ID exists in Database
            string query1 = @"select count(*)
                              from Team_member
                              where 
                              team_id = @team_id
                              and project_id =@project_id
                              ";
            string sqlDataSource1 = _configuration.GetConnectionString("prjDB");
            int rowexists = 0;

            using (SqlConnection myCon1 = new SqlConnection(sqlDataSource1))
            {


                myCon1.Open();
                using (SqlCommand myCommand = new SqlCommand(query1, myCon1))
                {
                                       
                    myCommand.Parameters.AddWithValue("@team_id", teamdata.Team_id);
                    myCommand.Parameters.AddWithValue("@project_id", teamdata.Project_id);
                    rowexists = (int)myCommand.ExecuteScalar();

                    if (rowexists == 0)
                    {
                        string query = @"
                           insert into Team_member
                           (team_id,employee_id,role_id,project_id)
                           values (@team_id,@employee_id,@role_id,@project_id)
                            ";

                        DataTable table = new DataTable();

                        SqlDataReader myReader1;

                        using (SqlCommand myCommand1 = new SqlCommand(query, myCon1))
                        {
                            // myCommand1.Parameters.AddWithValue("@Id", tskdata.Id);
                            myCommand1.Parameters.AddWithValue("@team_id", teamdata.Team_id);
                            myCommand1.Parameters.AddWithValue("@employee_id", teamdata.Employee_id);
                            myCommand1.Parameters.AddWithValue("@role_id", teamdata.Role_id);
                            myCommand1.Parameters.AddWithValue("@project_id", teamdata.Project_id);
                            

                            myReader1 = myCommand1.ExecuteReader();
                            table.Load(myReader1);
                            myReader1.Close();

                        }
                        _objResponseModel.Status = "Success";
                        _objResponseModel.Message = "Team member added successfully";
                    }
                    else
                    {
                        _objResponseModel.Status = "Failure";
                        _objResponseModel.Message = "Team member not added";
                    }

                    myCon1.Close();
                }
            }

            return _objResponseModel;
        }

        // PUT api/<TeammemberController>/5
        [HttpPut("Update Team member")]
        public StatusResponse Put(Team_member teamdata)
        {
            StatusResponse _objResponseModel = new StatusResponse();
            //To check if the ID exists in Database
            string query1 = @"select count(*)
                              from Team_member
                              where project_id = @project_id
                              ";
            string sqlDataSource1 = _configuration.GetConnectionString("prjDB");
            int rowexists = 0;

            using (SqlConnection myCon1 = new SqlConnection(sqlDataSource1))
            {


                myCon1.Open();
                using (SqlCommand myCommand = new SqlCommand(query1, myCon1))
                {
                   
                    myCommand.Parameters.AddWithValue("@team_id", teamdata.Team_id);
                    myCommand.Parameters.AddWithValue("@project_id", teamdata.Project_id);
                    rowexists = (int)myCommand.ExecuteScalar();

                    if (rowexists == 1)
                    {
                        string query = @"
                           update Team_member set
                           team_id =@team_id
                           where 
                           project_id =@project_id
                           ";

                        DataTable table = new DataTable();

                        SqlDataReader myReader1;


                        using (SqlCommand myCommand1 = new SqlCommand(query, myCon1))
                        {
                           //myCommand1.Parameters.AddWithValue("@id", teamdata.Team_id);
                            myCommand1.Parameters.AddWithValue("@team_id", teamdata.Team_id);
                            myCommand1.Parameters.AddWithValue("@employee_id", teamdata.Employee_id);
                            myCommand1.Parameters.AddWithValue("@role_id", teamdata.Role_id);
                            myCommand1.Parameters.AddWithValue("@project_id", teamdata.Project_id);

                            myReader1 = myCommand1.ExecuteReader();
                            table.Load(myReader1);
                            myReader1.Close();

                        }


                        _objResponseModel.Status = "Success";
                        _objResponseModel.Message = "Team member Data Updated successfully";

                    }
                    else
                    {
                        _objResponseModel.Status = "Failure";
                        _objResponseModel.Message = "Team member does not exists";

                    }
                    myCon1.Close();
                }
            }

            return _objResponseModel;
        }


        // DELETE api/<TeammemberController>/5
        [HttpDelete("{team_id}/{project_id}")]
        public StatusResponse Delete(int team_id, int project_id)
        {
            StatusResponse _objResponseModel = new StatusResponse();
            //To check if the ID exists in Database
            string query1 = @"select count(*)
                              from Team_member
                              where team_id = @team_id
                              and project_id =@project_id";

            string sqlDataSource1 = _configuration.GetConnectionString("prjDB");
            int rowexists = 0;

            
            using (SqlConnection myCon1 = new SqlConnection(sqlDataSource1))
            {

                myCon1.Open();
                using (SqlCommand myCommand = new SqlCommand(query1, myCon1))
                {


                    myCommand.Parameters.AddWithValue("@team_id", team_id);
                    myCommand.Parameters.AddWithValue("@project_id", project_id);
                    rowexists = (Int32)myCommand.ExecuteScalar();

                    if (rowexists >= 1)
                    {
                        string query = @"
                           delete from Team_member where team_id=@team_id
                           and project_id =@project_id";

                        DataTable table = new DataTable();

                        SqlDataReader myReader1;

                        using (SqlCommand myCommand1 = new SqlCommand(query, myCon1))
                        {
                            myCommand1.Parameters.AddWithValue("@team_id", team_id);
                            myCommand1.Parameters.AddWithValue("@project_id", project_id);
                            myReader1 = myCommand1.ExecuteReader();
                            table.Load(myReader1);
                            myReader1.Close();

                        }
                        _objResponseModel.Status = "Success";
                        _objResponseModel.Message = "Team member Deleted successfully";

                    }
                    else
                    {
                        _objResponseModel.Status = "Failure";
                        _objResponseModel.Message = "Team member does not exists";

                    }
                    myCon1.Close();
                }
            }
            

            return _objResponseModel;
        }
    }
}
