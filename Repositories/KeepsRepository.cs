using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
    public class KeepsRepository
    {
        private readonly IDbConnection _db;

        public KeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Keep> Get()
        {
            string sql = "SELECT * FROM Keeps WHERE isPrivate = 0;";
            return _db.Query<Keep>(sql);
        }

        internal IEnumerable<VaultKeepModel> GetKeepByVaultId(int vaultId, string userId)
        {
            string sql = @"
         SELECT 
         k.*,
         vk.id as vaultKeepId
         FROM vaultkeeps vk
         INNER JOIN keeps k ON k.id = vk.keepId 
         WHERE (vaultId = @vaultId AND vk.userId = @userId)
            ";
            return _db.Query<VaultKeepModel>(sql, new { vaultId, userId });
        }

         internal Keep GetById(int id)
            {
            string sql = "SELECT * FROM keeps WHERE id = @Id";
            return _db.QueryFirstOrDefault<Keep>(sql, new {id});
            }
        internal Keep Create(Keep newKeep)
        {
             string sql = @"
                INSERT INTO keeps
                (name, description, img, isPrivate, shares, views, keeps, userId)
                VALUES
                (@Name, @Description, @Img, @IsPrivate, @Shares, @Views, @Keeps, @UserId);
                SELECT LAST_INSERT_ID()";
            newKeep.Id = _db.ExecuteScalar<int>(sql,newKeep);
            return newKeep;
            throw new NotImplementedException();
        }
        internal bool Delete(int id, string userId)
            {
            string sql = "DELETE FROM keeps WHERE id = @id AND userId = @userId LIMIT 1";
                    int affectedRows = _db.Execute(sql, new { id, userId });
                    return affectedRows == 1;
            }

            internal bool Edit(Keep keepToUpdate, string userId)
            {
                keepToUpdate.UserId = userId;
                string sql = @"
                UPDATE keeps 
                SET
                name = @Name, 
                description = @description,
                img = @Img, 
                isPrivate = @IsPrivate, 
                shares = @Shares, 
                views = @Views,
                keeps = @Keeps, 
                AND userId = @UserId";
                int affectedRows = _db.Execute(sql, keepToUpdate);
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