using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceManagementSystem.Model;
using InsuranceManagementSystem.ServiceProvider;
using InsuranceManagementSystem.Utility;
using InsuranceManagementSystem.Exceptions;
using System.Data.SqlClient;
using System.Runtime.ConstrainedExecution;

namespace InsuranceManagementSystem.ServiceProvider
{
    internal class PolicyRepository : IPolicyRepository
    {
        public string connectionString;
        SqlCommand cmd = null;

        public PolicyRepository()
        {
            connectionString = DbConnectionUtility.GetConnectionString();
            cmd = new SqlCommand();
        }

        #region---->CreatePolicy() method 

        public int CreatePolicy(Policies policy)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "Insert into Policies ( policy_number , policy_type , coverage_amount,premium_amount ,start_date ,end_date) values (@PolicyNumber , @PolicyType , @CoverageAmount , @PremiumAmount , @StartDate , @EndDate)";
                //cmd.Parameters.AddWithValue("@PolicyId", policy.PolicyId);
                cmd.Parameters.AddWithValue("@PolicyNumber", policy.PolicyNumber);
                cmd.Parameters.AddWithValue("@PolicyType", policy.PolicyType);
                cmd.Parameters.AddWithValue("@CoverageAmount", policy.CoverageAmount);
                cmd.Parameters.AddWithValue("@PremiumAmount", policy.PremiumAmount);
                cmd.Parameters.AddWithValue("@StartDate", policy.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", policy.EndDate);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int CreatePolicyStatus = cmd.ExecuteNonQuery();

                if (CreatePolicyStatus > 0)
                {
                    Console.WriteLine($"{CreatePolicyStatus} policy created Successfully !!!!!!!!!!");
                }
                else
                {
                    Console.WriteLine("There Was Error while creating policy !!!!!!!!!!!!!!!");
                }

                return CreatePolicyStatus;
            }
        }

        #endregion



        #region----->GetPolicy() method

        public List<Policies> GetPolicy(int policyId)
        {
            List<Policies> policies = new List<Policies>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "SELECT * FROM Policies WHERE policy_id = @P_Id";
                cmd.Parameters.AddWithValue("@P_Id", policyId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Policies policy = new Policies();
                    policy.PolicyId = (int)reader["PolicyId"];
                    policy.PolicyNumber = (string)reader["PolicyNumber"];
                    policy.PolicyType = (string)reader["PolicyType"];
                    policy.CoverageAmount = (double)reader["CoverageAmount"];
                    policy.PremiumAmount = (double)reader["PremiumAmount"];
                    policy.StartDate = (DateTime)reader["StartDate"];
                    policy.EndDate = (DateTime)reader["EndDate"];
                    policies.Add(policy);
                }
                cmd.Parameters.Clear();
                if (policies.Count() > 0)
                {
                    return policies;
                }
                else
                {
                    throw new PolicyNumberNotFoundException("Sorry, Policy cannot be Found , Invalid Id Entered...Exit and Please Enter Valid Id !!\n");

                }
            }
        }

        #endregion



        #region--->GetAllPolicies() method

        public List<Policies> GetAllPolicies()
        {
            List<Policies> policies = new List<Policies>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "SELECT * FROM Policies";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Policies policy = new Policies();
                    policy.PolicyId = (int)reader["PolicyId"];
                    policy.PolicyNumber = (string)reader["PolicyNumber"];
                    policy.PolicyType = (string)reader["PolicyType"];
                    policy.CoverageAmount = (double)reader["CoverageAmount"];
                    policy.PremiumAmount = (double)reader["PremiumAmount"];
                    policy.StartDate = (DateTime)reader["StartDate"];
                    policy.EndDate = (DateTime)reader["EndDate"];
                    policies.Add(policy);
                }
                return policies;
            }
        }

        #endregion



        #region---->DeletePolicy() method

        public void DeletePolicy(int policyId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "Delete from Policies Where policy_id= @P_Id";
                cmd.Parameters.AddWithValue("@P_Id", policyId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();

                int deletepolicyStatus = cmd.ExecuteNonQuery();
                if (deletepolicyStatus > 0)
                {
                    Console.WriteLine("Policy Deleted SuccessFully !!!!!!!!!!!!!!!!!!!\n");
                }
                else
                {
                    throw new PolicyNumberNotFoundException("Invalid PolicyId Entered !!!!!!!!!!!!!!!!!\n");
                }
                cmd.Parameters.Clear();
            }
        }

        #endregion



        #region----->UpdatePolicy() method 
        public int UpdatePolicy(Policies policy)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "UPDATE Policies SET policy_number = @PolicyNumber, policy_type = @PolicyType, " +
                                      "coverage_amount = @CoverageAmount, premium_amount = @PremiumAmount, " +
                                      "start_date = @StartDate, end_date = @EndDate " +
                                      "WHERE policy_id = @PolicyId";

                    //cmd.Parameters.AddWithValue("@PolicyId", policy.PolicyId);
                    cmd.Parameters.AddWithValue("@PolicyNumber", policy.PolicyNumber);
                    cmd.Parameters.AddWithValue("@PolicyType", policy.PolicyType);
                    cmd.Parameters.AddWithValue("@CoverageAmount", policy.CoverageAmount);
                    cmd.Parameters.AddWithValue("@PremiumAmount", policy.PremiumAmount);
                    cmd.Parameters.AddWithValue("@StartDate", policy.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", policy.EndDate);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"{rowsAffected} policy updated Successfully !!!!!!!!!!");
                    }
                    else
                    {
                        Console.WriteLine("There Was Error while updating policy !!!!!!!!!!!!!!!");
                    }

                    return rowsAffected;
                }
            }
        }
        #endregion


    }
}
