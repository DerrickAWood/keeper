using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class VaultKeepsService
    {
        private readonly VaultKeepsRepository _repo;
        public VaultKeepsService(VaultKeepsRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<VaultKeep> Get()
        {
            return _repo.Get();
        }

        public VaultKeep GetById(int id)
            {
            VaultKeep foundVaultKeep = _repo.GetById(id);
            if(foundVaultKeep == null)
            {
                throw new Exception("invalid id");
            }
            return foundVaultKeep;
            }

        public VaultKeep Create(VaultKeep newVaultKeep)
        {
            return _repo.Create(newVaultKeep);
        }

        //  internal string Delete(int id, string userId)
        //     {
        //     VaultKeep foundVaultKeep = GetById(id);
        //             if (foundVaultKeep.UserId != userId)
        //             {
        //                 throw new Exception("not your Keep");
        //             }
        //             if (_repo.Delete(id, userId))
        //             {
        //                 return "deleted.";
        //             }
        //             throw new Exception("ooopps");
        //     }
    }
}