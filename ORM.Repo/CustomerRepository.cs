using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using ORM.Repo.Interface;
using ORM.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Repo
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly string connectionString;

        public CustomerRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(connectionString);
            }
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                return await connection.QueryAsync<Customer>("SELECT * FROM customer");
            }
        }

        public Customer Get(int id)
        {
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                return connection.Query<Customer>("SELECT * FROM customer WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public async Task InsertAsync(Customer entity)
        {
           using( IDbConnection connection = Connection)
            {
                connection.Open();
                await connection.ExecuteAsync("INSERT INTO customer (name, email, address, phone) VALUES (@Name, @Email, @Eddress, @Phone)", entity);
            }
        }

        public void Remove(int id)
        {
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                connection.Execute("DELETE FROM customer WHERE id = @Id", new { Id = id});
            }
        }

        public void Update(Customer entity)
        {
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                connection.Query("UPDATE customer SET name = @Name, email = @Email, address = @Address, phone = @Phone WHERE id = @Id", entity);
            }
        }
    }
}
