using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using APBD04.DAL;
using APBD04.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APBD04.Controllers
{
    [Route("api/animals")]
    [ApiController]
    public class Animals : ControllerBase
    {
        private string SqlConn = "Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s18902;Integrated Security=True";

        private readonly IDbService _dbService;

        public Animals(IDbService dbService)
        {
            _dbService = dbService;
        }


        [HttpGet]
        public IActionResult GetAnimals()
        {
            using (var client = new SqlConnection(SqlConn))
            {
                using (var com = new SqlCommand())
                {
                    com.Connection = client;
                    com.CommandText = "select * from Animals";

                    client.Open();
                    var dr = com.ExecuteReader();

                    var AnimalsList = new List<Animal>();

                    while (dr.Read())
                    {
                        var st = new Animal();
                        st.Name = dr["Name"].ToString();
                        st.Descripton = dr["Descripton"].ToString();
                        st.IdAnimal = dr["IdAnimal"].ToString();
                        st.Category = dr["Category"].ToString();
                        st.Area = dr["Area"].ToString();
                        AnimalsList.Add(st);
                    }

                    return Ok(AnimalsList);
                }
            }
        }

        [HttpGet("{IdAnimal}")]
        public IActionResult getAnimal(string IdAnimal)
        {
            using (SqlConnection con = new SqlConnection(SqlConn))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "select * from dbo.Animal where IdAnimal = @IdAnimal";
                com.Parameters.AddWithValue("IdAnimal", IdAnimal);
                con.Open();

                var dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var st = new Animal();
                    st.Name = dr["Name"].ToString();
                    st.Descripton = dr["Descripton"].ToString();
                    st.IdAnimal = dr["IdAnimal"].ToString();
                    st.Category = dr["Category"].ToString();
                    st.Area = dr["Area"].ToString();
                    return Ok(st);
                }

            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateAnimal(Animal animal)
        {
            animal.IdAnimal = $"s{new Random().Next(1, 200000)}";
            return Ok(animal);
        }

        [HttpPut("{IdAnimal}")]
        public IActionResult PutAnimal(int id)
        {
            return Ok($"Aktualizacja zakonczona [id:{id}]");
        }

        [HttpDelete("{IdAnimal}")]
        public IActionResult DeleteAnimal(int id)
        {
            return Ok($"Usuwanie zwierzątka {id} ukonczone");
        }
    }
}
