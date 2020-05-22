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

        internal Keep Create(Keep newKeep)
        {
             string sql = @"
                INSERT INTO keeps
                (name, description, img, isPrivate)
                VALUES
                (@Name, @Description, @Img, @IsPrivate);
                SELECT LAST_INSERT_ID()";
            newKeep.Id = _db.ExecuteScalar<int>(sql,newKeep);
            return newKeep;
            throw new NotImplementedException();
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