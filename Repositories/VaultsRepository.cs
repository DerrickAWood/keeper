using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
    public class VaultsRepository
    {
        private readonly IDbConnection _db;

        public VaultsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Vault> GetAll()
        {
            string sql = "SELECT * FROM vaults;";
            return _db.Query<Vault>(sql);
        }

         internal Vault GetById(int id)
            {
            string sql = "SELECT * FROM vaults WHERE id = @id";
            return _db.QueryFirstOrDefault<Vault>(sql, new {id});
            }
        internal Vault Create(Vault newVault)
        {
             string sql = @"
                INSERT INTO vaults
                (name, description, userId)
                VALUES
                (@Name, @Description, @UserId);
                SELECT LAST_INSERT_ID()";
            newVault.Id = _db.ExecuteScalar<int>(sql,newVault);
            return newVault;
            throw new NotImplementedException();
        }
        internal bool Delete(int id, string userId)
            {
            string sql = "DELETE FROM vaults WHERE id = @id AND userId = @userId LIMIT 1";
                    int affectedRows = _db.Execute(sql, new { id, userId });
                    return affectedRows == 1;
            }
    }
}

// name VARCHAR(255) NOT NULL,
// --     description VARCHAR(255) NOT NULL,
// --     userId VARCHAR(255),
// --     img VARCHAR(255),
// --     isPrivate TINYINT,
// --     views INT DEFAULT 0,
// --     shares INT DEFAULT 0,
// --     keeps INT DEFAULT 0,
// --     INDEX userId (userId),
// --     PRIMARY KEY (id)