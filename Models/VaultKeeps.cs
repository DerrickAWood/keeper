namespace Keepr.Models
{
    public class VaultKeep
    {
        public int Id { get; set; }
        public string userId { get; set; }
        public int keepId { get; set; }
        public int vaultId { get; set; }
    }
    public class VaultKeepModel
    {
        public int VaultKeepId { get; set; }
    }
}

//  vaultId int NOT NULL,
// --     keepId int NOT NULL,
// --     userId VARCHAR(255) NOT NULL,
