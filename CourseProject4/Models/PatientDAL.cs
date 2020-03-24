using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject4.Models
{
    public class PatientDAL
    {
        string connectionString = "Data Source=АЛЕКС-ПК;Initial Catalog=Hospital;Persist Security Info=False;User ID=sa;Password=123;";
        //Get All Patients
        public IEnumerable<Patient> GetAllPatients()
        {
           List<Patient> patList = new List<Patient>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllPatients",con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Patient pat = new Patient();
                    pat.PatientID = Convert.ToInt32(dr["PatientID"].ToString());
                    pat.Name = dr["Name"].ToString();
                    pat.Gender = dr["Gender"].ToString();
                    pat.Age = Convert.ToInt32(dr["Age"].ToString());
                    pat.Insurance = dr["Insurance"].ToString();
                    pat.Diagnosis = dr["Diagnosis"].ToString();
                    pat.Doctor = dr["Doctor"].ToString();
                    pat.AdmitDate = Convert.ToDateTime(dr["AdmitDate"].ToString());
                    pat.DischargeDate = Convert.ToDateTime(dr["DischargeDate"].ToString());


                    patList.Add(pat);
                }
                con.Close();
            }

            return patList;
           }


        //Get Patient By Name
        public Patient GetPatientByName(string patName)
        {
            Patient pat = new Patient();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetPatientByName", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PatName", patName);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    pat.PatientID = Convert.ToInt32(dr["PatientID"].ToString());
                    pat.Name = dr["Name"].ToString();
                    pat.Gender = dr["Gender"].ToString();
                    pat.Age = Convert.ToInt32(dr["Age"].ToString());
                    pat.Insurance = dr["Insurance"].ToString();
                    pat.Diagnosis = dr["Diagnosis"].ToString();
                    pat.Doctor = dr["Doctor"].ToString();
                    pat.AdmitDate = Convert.ToDateTime(dr["AdmitDate"].ToString());
                    pat.DischargeDate = Convert.ToDateTime(dr["DischargeDate"].ToString());
                }
                con.Close();
            }

            return pat;
        }

        //to Insert Patient
        public void AddPatient(Patient pat)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertPatient", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", pat.Name);
                cmd.Parameters.AddWithValue("@Gender", pat.Gender);
                cmd.Parameters.AddWithValue("@Age", pat.Age);
                cmd.Parameters.AddWithValue("@Insurance", pat.Insurance);
                cmd.Parameters.AddWithValue("@AdmitDateID", pat.AdmitDate);
                cmd.Parameters.AddWithValue("@DischargeDateID", pat.DischargeDate);
                cmd.Parameters.AddWithValue("@DiagnosisID", pat.Diagnosis);
                cmd.Parameters.AddWithValue("@DoctorID", pat.Doctor);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            }

        //To Update

        public void UpdatePatient(Patient pat)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdatePatient", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PatID", pat.PatientID);
                cmd.Parameters.AddWithValue("@Name", pat.Name);
                cmd.Parameters.AddWithValue("@Gender", pat.Gender);
                cmd.Parameters.AddWithValue("@Age", pat.Age);
                cmd.Parameters.AddWithValue("@Insurance", pat.Insurance);
                cmd.Parameters.AddWithValue("@AdmitDateID", pat.AdmitDate);
                cmd.Parameters.AddWithValue("@DischargeDateID", pat.DischargeDate);
                cmd.Parameters.AddWithValue("@DiagnosisID", pat.Diagnosis);
                cmd.Parameters.AddWithValue("@DoctorID", pat.Doctor);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

 }

        //To Delete
        public void DeletePatient(int? patId)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_DeletePatient", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PatID", patId);
               

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        //Get Patient by ID
        public Patient GetPatientById(int? patId)
        {
            Patient pat = new Patient();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetPatientByID", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PatID", patId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                { 
                    pat.PatientID = Convert.ToInt32(dr["PatientID"].ToString());
                    pat.Name = dr["Name"].ToString();
                    pat.Gender = dr["Gender"].ToString();
                    pat.Age = Convert.ToInt32(dr["Age"].ToString());
                    pat.Insurance = dr["Insurance"].ToString();
                    pat.Diagnosis = dr["Diagnosis"].ToString();
                    pat.Doctor = dr["Doctor"].ToString();
                    pat.AdmitDate = Convert.ToDateTime(dr["AdmitDate"].ToString());
                    pat.DischargeDate = Convert.ToDateTime(dr["DischargeDate"].ToString());
                }
                con.Close();
            }

            return pat;
        }
    }
}
