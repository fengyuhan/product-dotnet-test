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
            IList<MaterialModel> localCopyMaterialList = GetAll();
            if(localCopyMaterialList == null)
            {
                //  TODO: print null 
                return;
            }
            foreach(var m in localCopyMaterialList)
            {
                if(m!= null)
                {
                    // see if m.id == materialIdToDelete
                    // if match add to a local list of Material
                }
            }
            //
            // 2 for each product in the list replace 2 with 1
            //  start for loop
            // replacement:
            //      if  already using product 1 then quantity ++
            //          and then remove 2 in the product ingreadent list (remove 2 from list of material)
            //      else set productMaterial.MaterialName(1.name) 
            //           set productMaterial.MaterialID (1.id) 
            // 3 remove in DB:
            // in material table rm by id 2
            // end for loop

            // temp list list of product
            // somehow get list of Product
            // for each Product get ICollection<ProductMaterial> ProductMaterials
            //      for each ProductMaterials for each where MaterialId == materialIdToDelete
            //           add this.Product to temp list
            //  end of for loop
            // for each product in temp list
            //      replacement(Product p, Int32 materialIdToKeep, Int32 materialIdToDelete)
            // end of for loop
            throw new NotImplementedException("TODO: Please implement me");
        }
        private void replacement(Product product, Int32 materialIdToKeep, Int32 materialIdToDelete)
        {
            product.setName();
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