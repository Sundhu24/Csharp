using Microsoft.AspNetCore.Mvc;
using ProjectManagementAPI.Models;
using System.Data;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public UserController(IConfiguration config, IWebHostEnvironment env)
        {
            _configuration = config;
            _env = env;
        }
        // GET: api/<UserController>
        [HttpGet("Login")]
        public ResponseModel Get(string username, string password)
        {
                ResponseModel _objResponseModel = new ResponseModel();

                string query = @"
                            select * from
                            User_account
                            where username = @username
                            and userpassword = @password
                            ";

                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("prjDB");
                SqlDataReader myReader;

                using (SqlConnection myCon1 = new SqlConnection(sqlDataSource))
                {

                    myCon1.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon1))
                    {
                        myCommand.Parameters.AddWithValue("@username", username);
                        myCommand.Parameters.AddWithValue("@password", password);

                        myReader = myCommand.ExecuteReader();

                        table.Load(myReader);
                        myReader.Close();
                        myCon1.Close();
                    }
                }

                List<dynamic> user_tableList = new List<dynamic>();

                 int recordcount = table.Rows.Count;
            if (recordcount > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    Registration user_login = new Registration();
                    user_login.Id = Convert.ToInt32(table.Rows[i]["id"]);
                    user_login.User_name = table.Rows[i]["username"].ToString();
                    user_login.UserPassword = table.Rows[i]["userpassword"].ToString();

                    user_tableList.Add(user_login);
                }
                _objResponseModel.Data = user_tableList;
                _objResponseModel.Status = "Success";
                _objResponseModel.Message = "User Data Received successfully";
            }
            else
            {
                _objResponseModel.Status = "Failure";
                _objResponseModel.Message = "User Account not found";
            }
            return _objResponseModel;
        
        }
        [HttpGet]
        public ResponseModel Get()
        {
            ResponseModel _objResponseModel = new ResponseModel();

            string query = @"
                            select * from
                            User_account
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

            List<dynamic> user_tableList = new List<dynamic>();
            for (int i = 0; i < table.Rows.Count; i++)
            {

                Registration user_login = new Registration();
                user_login.Id = Convert.ToInt32(table.Rows[i]["id"]);
                user_login.User_name = table.Rows[i]["username"].ToString();
                user_login.UserPassword = table.Rows[i]["userpassword"].ToString();
                user_login.Email = table.Rows[i]["email"].ToString();
                user_login.Firstname = table.Rows[i]["first_name"].ToString();
                user_login.Lastname = table.Rows[i]["last_name"].ToString();
                user_login.Is_project_manager = Convert.ToBoolean(table.Rows[i]["is_project_manager"]);
                user_login.Registrationtime = Convert.ToDateTime(table.Rows[i]["registration_time"]);


                user_tableList.Add(user_login);
            }


            _objResponseModel.Data = user_tableList;
            _objResponseModel.Status = "Success";
            _objResponseModel.Message = "Registration Data Received successfully";
            return _objResponseModel; ;
        }
        /*
        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        */
        // POST api/<UserController>
        [HttpPost("Registration")]
        public StatusResponse Post(Registration reg_userdata)
        {
            StatusResponse _objResponseModel = new StatusResponse();

            //To check if the ID exists in Database
            string query1 = @"select count(*)
                              from User_account
                              where username =@username";
            string sqlDataSource1 = _configuration.GetConnectionString("prjDB");
            int rowexists = 0;

            using (SqlConnection myCon1 = new SqlConnection(sqlDataSource1))
            {


                myCon1.Open();
                using (SqlCommand myCommand = new SqlCommand(query1, myCon1))
                {

                   //myCommand.Parameters.AddWithValue("@id", reg_userdata.Id);
                  // myCommand.Parameters.AddWithValue("@first_name", reg_userdata.Firstname);
               myCommand.Parameters.AddWithValue("@username", reg_userdata.User_name);
                   /*   myComyCommand.Parameters.AddWithValue("@is_project_manager", reg_userdata.Is_project_manager);
                mand.Parameters.AddWithValue("@last_name", reg_userdata.Lastname);
                    m    myCommand.Parameters.AddWithValue("@registration_time", reg_userdata.Registrationtime);
                          myCommand.Parameters.AddWithValue("@userpassword", reg_userdata.UserPassword);
                    myCommand.Parameters.AddWithValue("@email", reg_userdata.Email);*/
                  rowexists = (int)myCommand.ExecuteScalar();

                   if (rowexists == 0)
                    {
                        string query = @"
                           insert into User_account
                           (username,userpassword,email,first_name,last_name,is_project_manager,registration_time)
                            values (@username,@userpassword,@email,@first_name,@last_name,@is_project_manager,@registration_time)
                            ";

                        DataTable table = new DataTable();
                       
                        SqlDataReader myReader1;                  

                           
                            using (SqlCommand myCommand1 = new SqlCommand(query, myCon1))
                            {

                                myCommand1.Parameters.AddWithValue("@id", reg_userdata.Id);
                                myCommand1.Parameters.AddWithValue("@username", reg_userdata.User_name);
                                myCommand1.Parameters.AddWithValue("@userpassword", reg_userdata.UserPassword);
                                myCommand1.Parameters.AddWithValue("@email", reg_userdata.Email);
                                myCommand1.Parameters.AddWithValue("@first_name", reg_userdata.Firstname);
                                myCommand1.Parameters.AddWithValue("@last_name", reg_userdata.Lastname);
                                myCommand1.Parameters.AddWithValue("@is_project_manager", reg_userdata.Is_project_manager);
                                myCommand1.Parameters.AddWithValue("@registration_time", reg_userdata.Registrationtime);

                                myReader1 = myCommand1.ExecuteReader();
                                table.Load(myReader1);
                                myReader1.Close();
                                
                            }

                        _objResponseModel.Status = "Success";
                        _objResponseModel.Message = "User Account Created Successfully";
                    }
                 else
                {
                    _objResponseModel.Status = "Failure";
                    _objResponseModel.Message = "User Account already exists";
                }

                myCon1.Close();
                }
            }                          

            return _objResponseModel;
        }
        
        // PUT api/<UserController>/5
        [HttpPut("Forgot Password")]
        public StatusResponse Put(string username, string userpassword)
        {
            StatusResponse _objResponseModel = new StatusResponse();
            //To check if the ID exists in Database
            string query1 = @"select count(*)
                              from User_account
                              where username = @username
                              ";
            string sqlDataSource1 = _configuration.GetConnectionString("prjDB");
            int rowexists = 0;

            using (SqlConnection myCon1 = new SqlConnection(sqlDataSource1))
            {


                myCon1.Open();
                using (SqlCommand myCommand = new SqlCommand(query1, myCon1))
                {

                    myCommand.Parameters.AddWithValue("@username", @username);
                    
                    rowexists = (int)myCommand.ExecuteScalar();

                    if (rowexists == 1)
                    {
                        string query = @"
                           update User_account set
                           userpassword =@userpassword
                           where 
                           username =@username
                           ";

                        DataTable table = new DataTable();

                        SqlDataReader myReader1;


                        using (SqlCommand myCommand1 = new SqlCommand(query, myCon1))
                        {
                            //myCommand1.Parameters.AddWithValue("@id", teamdata.Team_id);
                            myCommand1.Parameters.AddWithValue("@username", username);
                            myCommand1.Parameters.AddWithValue("@userpassword",userpassword);
                            

                            myReader1 = myCommand1.ExecuteReader();
                            table.Load(myReader1);
                            myReader1.Close();

                        }


                        _objResponseModel.Status = "Success";
                        _objResponseModel.Message = "Password Updated successfully";

                    }
                    else
                    {
                        _objResponseModel.Status = "Failure";
                        _objResponseModel.Message = "Failed to update password";

                    }
                    myCon1.Close();
                }
            }

            return _objResponseModel;
        }
        /*
         // DELETE api/<UserController>/5
         [HttpDelete("{id}")]
         public void Delete(int id)
         {
         } */
    }
}
