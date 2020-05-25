namespace Keepr.Models
{
    public class Vault
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }

    }
    public class VaultViewModel : Vault
    {
        public int VaultKeepId { get; set; }
    }
}

// -- CREATE TABLE vaults (
// --     id int NOT NULL AUTO_INCREMENT,
// --     name VARCHAR(255) NOT NULL,
// --     description VARCHAR(255) NOT NULL,
// --     userId VARCHAR(255),
// --     INDEX userId (userId),  
// --     PRIMARY KEY (id)
// -- );