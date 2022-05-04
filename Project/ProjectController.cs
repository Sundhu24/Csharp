using Microsoft.AspNetCore.Mvc;
using ProjectManagementAPI.Models;
using System.Data;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class ProjectController : ControllerBase
    {
        IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public ProjectController(IConfiguration config, IWebHostEnvironment env)
        {
            _configuration = config;
            _env = env;
        }
        // GET: api/<ProjectController>
        [HttpGet]
        public ResponseModel Get()
        {
            ResponseModel _objResponseModel = new ResponseModel();

            string query = @"
                            select * from
                            Project
                            ";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("prjDB");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {

                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            List<dynamic> prjList = new List<dynamic>();
            for (int i = 0; i < table.Rows.Count; i++)
            {

                Project prj = new Project();
                prj.Id = Convert.ToInt32(table.Rows[i]["id"]);
                prj.Project_name = table.Rows[i]["project_name"].ToString();
                prj.Project_desc = table.Rows[i]["project_desc"].ToString();
                prj.Client_id = Convert.ToInt32(table.Rows[i]["Client_id"]);
                prj.Created_date = Convert.ToDateTime(table.Rows[i]["created_date"]);
                prj.Project_manager_id = Convert.ToInt32(table.Rows[i]["project_manager_id"]);
                prj.Status = table.Rows[i]["status"].ToString();

                prjList.Add(prj);
            }


            _objResponseModel.Data = prjList;
            _objResponseModel.Status = "Success";
            _objResponseModel.Message = "Project Data Received successfully";
            return _objResponseModel;
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        public ResponseModel Get(int id)
        {
            ResponseModel _objResponseModel = new ResponseModel();

            string query = @"
                            select * from
                            Project where id=@id
                            ";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("prjDB");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {

                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            if (table.Rows.Count > 0)
            {
                List<dynamic> prjList = new List<dynamic>();
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    Project prj = new Project();
                    prj.Id = Convert.ToInt32(table.Rows[i]["id"]);
                    prj.Project_name = table.Rows[i]["project_name"].ToString();
                    prj.Project_desc = table.Rows[i]["project_desc"].ToString();
                    prj.Client_id = Convert.ToInt32(table.Rows[i]["Client_id"]);
                    prj.Created_date = Convert.ToDateTime(table.Rows[i]["created_date"]);
                    prj.Project_manager_id = Convert.ToInt32(table.Rows[i]["project_manager_id"]);
                    prj.Status = table.Rows[i]["status"].ToString();

                    prjList.Add(prj);
                }


                _objResponseModel.Data = prjList;
                _objResponseModel.Status = "Success";
                _objResponseModel.Message = "Project Data Received successfully";
               
            }
            else
            {
                _objResponseModel.Status = "Failure";
                _objResponseModel.Message = "No Data Found";
            }
            return _objResponseModel;
        }
        [HttpGet("ProjectName")]
        public ResponseModel Get(string project_name)
        {
            ResponseModel _objResponseModel = new ResponseModel();

            string query = @"
                            select * from
                            Project where project_name=@project_name
                            ";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("prjDB");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {

                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@project_name", project_name);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            if (table.Rows.Count > 0)
            {
                List<dynamic> prjList = new List<dynamic>();
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    Project prj = new Project();
                    prj.Id = Convert.ToInt32(table.Rows[i]["id"]);
                    prj.Project_name = table.Rows[i]["project_name"].ToString();
                    prj.Project_desc = table.Rows[i]["project_desc"].ToString();
                    prj.Client_id = Convert.ToInt32(table.Rows[i]["Client_id"]);
                    prj.Created_date = Convert.ToDateTime(table.Rows[i]["created_date"]);
                    prj.Project_manager_id = Convert.ToInt32(table.Rows[i]["project_manager_id"]);
                    prj.Status = table.Rows[i]["status"].ToString();

                    prjList.Add(prj);
                }


                _objResponseModel.Data = prjList;
                _objResponseModel.Status = "Success";
                _objResponseModel.Message = "Project Data Received successfully";

            }
            else
            {
                _objResponseModel.Status = "Failure";
                _objResponseModel.Message = "Project does not exists";
            }
            return _objResponseModel;
        }

        // POST api/<ProjectController>
        [HttpPost]
        public StatusResponse Post(Project prjdata)
        {
            StatusResponse _objResponseModel = new StatusResponse();

            //To check if the ID exists in Database
            string query1 = @"select count(*)
                              from Project
                              where id = @id
                              and project_name =@project_name
                              and client_id = @client_id";
            string sqlDataSource1 = _configuration.GetConnectionString("prjDB");
            int rowexists = 0;

            using (SqlConnection myCon1 = new SqlConnection(sqlDataSource1))
            {


                myCon1.Open();
                using (SqlCommand myCommand = new SqlCommand(query1, myCon1))
                {

                    myCommand.Parameters.AddWithValue("@id", prjdata.Id);
                    myCommand.Parameters.AddWithValue("@project_name", prjdata.Project_name);
                    myCommand.Parameters.AddWithValue("@client_id", prjdata.Client_id);
                    rowexists = (int)myCommand.ExecuteScalar();

                    if (rowexists == 0)
                    {
                        string query = @"
                           insert into Project
                           (project_name,project_desc,client_id,created_date,project_manager_id,status)
                           values (@project_name,@project_desc,@client_id,@created_date,@project_manager_id,@status)
                            ";

                        DataTable table = new DataTable();
                       
                        SqlDataReader myReader1;                    
                                                  
                        using (SqlCommand myCommand1 = new SqlCommand(query, myCon1))
                        {
                                myCommand1.Parameters.AddWithValue("@Project_name", prjdata.Project_name);
                                myCommand1.Parameters.AddWithValue("@Project_desc", prjdata.Project_desc);
                                myCommand1.Parameters.AddWithValue("@Client_id", prjdata.Client_id);
                                myCommand1.Parameters.AddWithValue("@Created_date", prjdata.Created_date);
                                myCommand1.Parameters.AddWithValue("@Project_manager_id", prjdata.Project_manager_id);
                                myCommand1.Parameters.AddWithValue("@Status", prjdata.Status);

                                myReader1 = myCommand1.ExecuteReader();
                                table.Load(myReader1);
                                myReader1.Close();
                            
                         }
                       _objResponseModel.Status = "Success";
                        _objResponseModel.Message = "Project Data Inserted successfully";
                    }
                    else
                    {
                        _objResponseModel.Status = "Failure";
                        _objResponseModel.Message = "Project Data already exists";
                    }

                    myCon1.Close();
                }
            }
                       
            return _objResponseModel;
        }

        // PUT api/<ProjectController>/5
        [HttpPut]
        public StatusResponse Put(Project prjdata)
        {
            StatusResponse _objResponseModel = new StatusResponse();
            //To check if the ID exists in Database
            string query1 = @"select count(*)
                              from Project
                              where id = @id";
            string sqlDataSource1 = _configuration.GetConnectionString("prjDB");
            int rowexists = 0;

            using (SqlConnection myCon1 = new SqlConnection(sqlDataSource1))
            {


                myCon1.Open();
                using (SqlCommand myCommand = new SqlCommand(query1, myCon1))
                {

                    myCommand.Parameters.AddWithValue("@id", prjdata.Id);
                    rowexists = (int)myCommand.ExecuteScalar();

                    if (rowexists == 1)
                    {
                        string query = @"
                           update Project set
                          project_name =@project_name,
                          project_desc = @project_desc,
                         client_id = @client_id,
                          created_date = @created_date,
                          project_manager_id =@project_manager_id,
                          status = @status
                          where id=@id
                            ";

                        DataTable table = new DataTable();
                       
                        SqlDataReader myReader1;                 

                       
                            using (SqlCommand myCommand1 = new SqlCommand(query, myCon1))
                            {
                                myCommand1.Parameters.AddWithValue("@Project_name", prjdata.Project_name);
                                myCommand1.Parameters.AddWithValue("@Project_desc", prjdata.Project_desc);
                                myCommand1.Parameters.AddWithValue("@Client_id", prjdata.Client_id);
                                myCommand1.Parameters.AddWithValue("@Created_date", prjdata.Created_date);
                                myCommand1.Parameters.AddWithValue("@Project_manager_id", prjdata.Project_manager_id);
                                myCommand1.Parameters.AddWithValue("@Status", prjdata.Status);
                                myCommand1.Parameters.AddWithValue("@Id", prjdata.Id);


                                myReader1 = myCommand1.ExecuteReader();
                                table.Load(myReader1);
                                myReader1.Close();
                               
                            }
                     

                        _objResponseModel.Status = "Success";
                        _objResponseModel.Message = "Project Data Updated successfully";

                    }
                    else
                    {
                        _objResponseModel.Status = "Failure";
                        _objResponseModel.Message = "Project Data does not exists";

                    }
                    myCon1.Close();
                }
            }
                                 
            return _objResponseModel;
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public StatusResponse Delete(int id)
        {
            StatusResponse _objResponseModel = new StatusResponse();
            //To check if the ID exists in Database
            string query1 = @"select count(*)
                              from Project
                              where id = @id";
            string sqlDataSource1 = _configuration.GetConnectionString("prjDB");
            int rowexists = 0;

            Project prjdata = new Project();

            using (SqlConnection myCon1 = new SqlConnection(sqlDataSource1))
            {

                myCon1.Open();
                using (SqlCommand myCommand = new SqlCommand(query1, myCon1))
                {


                    myCommand.Parameters.AddWithValue("@id", id);
                    rowexists = (Int32)myCommand.ExecuteScalar();

                    if (rowexists == 1)
                    {
                        string query = @"
                           delete from Project where id=@id
                            ";

                        DataTable table = new DataTable();
                       
                        SqlDataReader myReader1;                    
                            
                        using (SqlCommand myCommand1 = new SqlCommand(query, myCon1))
                        {
                                myCommand1.Parameters.AddWithValue("@id", id);
                                myReader1 = myCommand1.ExecuteReader();
                                table.Load(myReader1);
                                myReader1.Close();
                               
                        }
                        _objResponseModel.Status = "Success";
                        _objResponseModel.Message = "Project Data Deleted successfully";

                    }
                    else
                    {
                        _objResponseModel.Status = "Failure";
                        _objResponseModel.Message = "Project Data does not exists";

                    }
                    myCon1.Close();
                }
            }
            //end To check if the ID exists in Database
                      
            return _objResponseModel;
        }
        [HttpPut("Update Project Status")]
        public StatusResponse Put(Project_Status prjdata)
        {
            StatusResponse _objResponseModel = new StatusResponse();
            //To check if the ID exists in Database
            string query1 = @"select count(*)
                              from Project
                              where id = @id
                              and project_name =@project_name
                              and project_manager_id =@project_manager_id";

            string sqlDataSource1 = _configuration.GetConnectionString("prjDB");
            int rowexists = 0;

            using (SqlConnection myCon1 = new SqlConnection(sqlDataSource1))
            {


                myCon1.Open();
                using (SqlCommand myCommand = new SqlCommand(query1, myCon1))
                {

                    myCommand.Parameters.AddWithValue("@id", prjdata.Id);
                    myCommand.Parameters.AddWithValue("@project_name", prjdata.Project_name);
                    myCommand.Parameters.AddWithValue("@project_manager_id", prjdata.Project_manager_id);
                    rowexists = (int)myCommand.ExecuteScalar();

                    if (rowexists == 1)
                    {
                        string query = @"
                           update Project set
                           status = @status
                            where id=@id 
                          and project_name =@project_name
                          and  project_manager_id =@project_manager_id
                            ";

                        DataTable table = new DataTable();
                      
                        SqlDataReader myReader;                     
                        
                        using (SqlCommand myCommand1 = new SqlCommand(query, myCon1))
                        {
                                myCommand1.Parameters.AddWithValue("@Project_name",prjdata.Project_name);
                                myCommand1.Parameters.AddWithValue("@Project_manager_id",prjdata.Project_manager_id);
                                myCommand1.Parameters.AddWithValue("@Status",prjdata.Status);
                                myCommand1.Parameters.AddWithValue("@Id",prjdata.Id);


                                myReader = myCommand1.ExecuteReader();
                                table.Load(myReader);
                                myReader.Close();
                               
                        }
                        _objResponseModel.Status = "Success";
                        _objResponseModel.Message = "Project Status Updated successfully";

                    }
                    else
                    {
                        _objResponseModel.Status = "Failure";
                        _objResponseModel.Message = "Project Status not updated";

                    }

                    myCon1.Close();
                }
            }
            //end To check if the ID exists in Database
                       
            return _objResponseModel;
        }

    }
}
