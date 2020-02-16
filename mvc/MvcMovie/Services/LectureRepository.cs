// To take the data as getting the request from the controller
using System;
using System.Collections.Generic;
using mvc_example.Models;
using mvc_example.Utils;
using MySql.Data.MySqlClient;


namespace mvc_example.Services
{
    public class LectureRepository : DbFunctions
    {
        public List<Lecture> GetList () {
            List<Lecture> result = new List<Lecture>();

            string query = "SELECT * FROM lecture";
            using (MySqlConnection conn = new MySqlConnection(Secrets.dbAuth)) {
                using (MySqlDataReader reader = exReader(query, conn)) {
                    while (reader.Read())
                    {
                        result.Add(
                            new Lecture {
                                idx = Convert.ToInt64(reader["idx"].ToString()),
                                title = reader["lec_title"].ToString(),
                                date = reader["lec_date"].ToString(),
                                thumb = reader["lec_thumb"].ToString()
                            }
                        );
                    }
                }
            }

            return result;
        }

        public Lecture GetOne (Int64 lecNo) {
            Lecture result = null;

            string query = $"SELECT * FROM lecture WHERE idx = {lecNo}";
            using (MySqlConnection conn = new MySqlConnection(Secrets.dbAuth)) {
                using (MySqlConnection reader = exReader(query, conn)) {
                    if (reader.Read())
                    {
                        result = new Lecture {
                            idx = Convert.ToInt64(reader["idx"].ToString()),
                            title = reader["lec_title"].ToString(),
                            category = reader["lec_category"].ToString(),
                            length = Convert.ToInt64(reader["lec_length"].ToString()),
                            date = reader["lec_date"].ToString(),
                            code = reader["lec_code"].ToString()
                        };
                    }
                }
            }
            
            return result;
        }
    }
}

