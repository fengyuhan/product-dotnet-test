using System;
using System.Collections.Generic;
using System.Linq;
using Product.Data.Repositories;
using Product.DomainObjects.Models;

namespace Product.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;

        public MaterialService(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public MaterialModel GetById(Int32 id)
        {
            return Transfer(_materialRepository.GetById(id));
        }

        public IList<MaterialModel> GetAll()
        {
            return _materialRepository.GetAll().Select(Transfer).ToList();
        }

        public void Merge(Int32 materialIdToKeep, Int32 materialIdToDelete)
        {
            // find list of product:
            // 1 get all the product where has meterial by id 2
            //
            // 2 for each product replace 2 with 1
            // replacement:
            //      if  already using product 1 then quantity ++
            //      else set productMaterial.MaterialName(1.name) set productMaterial.MaterialID (1.id)
            // 3 remove:
            // in material table rm by id 2
            throw new NotImplementedException("TODO: Please implement me");
        }

        private MaterialModel Transfer(Data.Entities.Material entity)
        {
            return new MaterialModel
            {
                MaterialId = entity.MaterialId,
                Name = entity.Name,
                Cost = entity.Cost
            };
        }
    }
}