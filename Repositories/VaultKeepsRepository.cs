using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
    public class VaultKeepsRepository
    {
        private readonly IDbConnection _db;

        public VaultKeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<VaultKeep> Get()
        {
            string sql = "SELECT * FROM vaultkeeps;";
            return _db.Query<VaultKeep>(sql);
        }

         internal VaultKeep GetById(int id)
            {
            string sql = "SELECT * FROM vaultkeeps WHERE id = @id";
            return _db.QueryFirstOrDefault<VaultKeep>(sql, new {id});
            }
        internal VaultKeep Create(VaultKeep newVaultKeep)
        {
             string sql = @"
                INSERT INTO vaultkeeps
                (vaultId, keepId, userId)
                VALUES
                (@VaultId, @KeepId, @UserId);
                SELECT LAST_INSERT_ID()";
            newVaultKeep.Id = _db.ExecuteScalar<int>(sql,newVaultKeep);
            return newVaultKeep;
        }
        // internal bool Delete(int id, string userId)
        //     {
        //     string sql = "DELETE FROM vaultkeeps WHERE id = @id AND userId = @userId LIMIT 1";
        //             int affectedRows = _db.Execute(sql, new { id, userId });
        //             return affectedRows == 1;
        //     }
    }
}

// id int NOT NULL AUTO_INCREMENT,
// --     vaultId int NOT NULL,
// --     keepId int NOT NULL,
// --     userId VARCHAR(255) NOT NULL,