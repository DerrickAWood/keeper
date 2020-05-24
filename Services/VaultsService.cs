using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class VaultsService
    {
        private readonly VaultsRepository _repo;
        public VaultsService(VaultsRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Vault> GetAll()
        {
            return _repo.GetAll();
        }

        public Vault GetById(int id)
            {
            Vault foundVault = _repo.GetById(id);
            if(foundVault == null)
            {
                throw new Exception("invalid id");
            }
            return foundVault;
            }

        public Vault Create(Vault newVault)
        {
            return _repo.Create(newVault);
        }

        //  internal string Delete(int id, string userId)
        //     {
        //     Keep foundKeep = GetById(id);
        //             if (foundKeep.UserId != userId)
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