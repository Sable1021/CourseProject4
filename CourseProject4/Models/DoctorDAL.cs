using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject4.Models
{
    public class DoctorDAL
    {
        string connectionString = "Data Source=АЛЕКС-ПК;Initial Catalog=Hospital;Persist Security Info=False;User ID=sa;Password=123;";
        //Get All Doctors
        public IEnumerable<Doctor> GetAllDoctors()
        {
            List<Doctor> docList = new List<Doctor>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllDoctors", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Doctor doc = new Doctor();
                    doc.DoctorID = Convert.ToInt32(dr["DoctorID"].ToString());
                    doc.Name = dr["Name"].ToString();
                    doc.Position = dr["Position"].ToString();
                    doc.Room = Convert.ToInt32(dr["Room"].ToString());
                    doc.Age = Convert.ToInt32(dr["Age"].ToString());
                 


                    docList.Add(doc);
                }
                con.Close();
            }

            return docList;
        }




        //to Insert Doctor
        public void AddDoctor(Doctor doc)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertDoctor", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", doc.Name);
                cmd.Parameters.AddWithValue("@Position", doc.Position);
                cmd.Parameters.AddWithValue("@Room", doc.Room);
                cmd.Parameters.AddWithValue("@Age", doc.Age);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        //To Update

        public void UpdateDoctor(Doctor doc)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateDoctor", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DocID", doc.DoctorID);
                cmd.Parameters.AddWithValue("@Name", doc.Name);
                cmd.Parameters.AddWithValue("@Position", doc.Position);
                cmd.Parameters.AddWithValue("@Room", doc.Room);
                cmd.Parameters.AddWithValue("@Age", doc.Age);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        //To Delete
        public void DeleteDoctor(int? docId)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteDoctor", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DocID", docId);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        //Get Doctor by ID
        public Doctor GetDoctorById(int? docId)
        {
            Doctor doc = new Doctor ();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetDoctorByID", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DocID", docId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    doc.DoctorID = Convert.ToInt32(dr["DoctorID"].ToString());
                    doc.Name = dr["Name"].ToString();
                    doc.Position = dr["Position"].ToString();
                    doc.Room = Convert.ToInt32(dr["Room"].ToString());
                    doc.Age = Convert.ToInt32(dr["Age"].ToString());
 
                }
                con.Close();
            }

            return doc;
        }



        public Doctor GetDoctorByName(string docName)
        {
            Doctor doc = new Doctor();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetDoctorByName", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DocName", docName);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    doc.DoctorID = Convert.ToInt32(dr["DoctorID"].ToString());
                    doc.Name = dr["Name"].ToString();
                    doc.Position = dr["Position"].ToString();
                    doc.Room = Convert.ToInt32(dr["Room"].ToString());
                    doc.Age = Convert.ToInt32(dr["Age"].ToString());

                }
                con.Close();
            }

            return doc;
        }

        public IEnumerable<Doctor> GetDoctorPatientsById(int? docId)
        {
            List<Doctor> docList = new List<Doctor>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetDoctorPatientsByID", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DocID", docId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Doctor doc = new Doctor();
                    doc.DoctorID = Convert.ToInt32(dr["DoctorID"].ToString());
                    doc.Name = dr["Name"].ToString();
                    doc.PatientName = dr["PatientName"].ToString();
                    doc.PatientAge = Convert.ToInt32(dr["PatientAge"].ToString());
                    doc.Insurance = dr["Insurance"].ToString();
                    doc.AdmitDate = Convert.ToDateTime(dr["AdmitDate"].ToString());
                    doc.DischargeDate = Convert.ToDateTime(dr["DischargeDate"].ToString());
                    doc.Diagnosis = dr["Diagnosis"].ToString();

                    docList.Add(doc);
                }
                con.Close();
            }


            return docList;
        }



    }
}

