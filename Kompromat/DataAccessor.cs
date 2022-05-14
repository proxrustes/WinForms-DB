using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Kompromat
{
    public class DataAccessor
    {
        public List<Person> GetPerson(string text)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(Helper.CnnVal("StudentsDB")))
                {
                    var res = connection.Query<Person>($"SELECT * FROM dbo.Peoples WHERE {text}").ToList();

                    return res;
                }
            }
            catch
            {
                using (IDbConnection connection = new SqlConnection(Helper.CnnVal("StudentsDB")))
                {
                    var res = connection.Query<Person>($"SELECT * FROM dbo.Peoples").ToList();

                    return res;
                }
            }
            
        }
        public void UpdatePerson(Person person)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("StudentsDB")))
            {
                connection.Query<Person>($"dbo.sp_UserUpdate @Id, @FirstName, @LastName, @FatherName, @Email, @University, @Birthday, @PhoneNumber, @Telegram, @Bio", new { Id = person.Id, FirstName = person.FirstName, LastName = person.LastName, FatherName = person.FatherName, Email = person.Email, University = person.University, Birthday = person.Birthday, PhoneNumber = person.PhoneNumber, Telegram = person.Telegram, Bio = person.Bio });
            }
        }
        public List<Person> ShowAll()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("StudentsDB")))
            {
                return connection.Query<Person>($"dbo.sp_UserGetAll").ToList();
            }
        }
        public void InsertPerson(Person person)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("StudentsDB")))
            {
                connection.Query<Person>($"dbo.sp_UserInsert @FirstName, @LastName, @FatherName, @Email, @University, @Birthday, @PhoneNumber, @Telegram, @Bio", new {FirstName = person.FirstName, LastName = person.LastName, FatherName = person.FatherName, Email = person.Email, University = person.University, Birthday = person.Birthday, PhoneNumber = person.PhoneNumber, Telegram = person.Telegram, Bio = person.Bio });

            }
        }
        public Person GetInfo(int _Id)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("StudentsDB")))
            {
                return connection.Query<Person>($"dbo.sp_UserGetId @Id", new {Id = _Id }).FirstOrDefault();
            }
        }
        public void DeleteUser(int _Id)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("StudentsDB")))
            {
                connection.Query<Person>($"dbo.sp_UserDelete @Id", new { Id = _Id }).FirstOrDefault();
            }
        }

    }
}
