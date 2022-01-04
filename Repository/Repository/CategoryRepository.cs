using AutoMapper;
using Data;
using Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repository
{
    public class CategoryRepository : IBasicCRUD<CategoryDTO>, ICreateCRUD<CategoryDTO>, IDeleteCRUD<CategoryDTO>, IUpdateCRUD<CategoryDTO>
    {
        private readonly IMapper vMapper;
        private readonly InvoicingContext vInvoicingContext;

        public CategoryRepository(IMapper pIMapper, InvoicingContext pAutomatizerContext)
        {
            vMapper = pIMapper;
            vInvoicingContext = pAutomatizerContext;
        }

        public void Create(CategoryDTO pCategory)
        {
            try
            {
                var vCreateCategory = vMapper.Map<CategoryDTO, Category>(pCategory);
                vInvoicingContext.Categories.AddAsync(vCreateCategory);
                vInvoicingContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se ha producio un erro al momento de crear la categoria", exception));
            }
        }

        public void Delete(int pId)
        {
            try
            {
                var oCategory = vInvoicingContext.Categories.Where(where => where.Id == pId).FirstOrDefault();

                if (oCategory != null)
                {
                    vInvoicingContext.Categories.Remove(oCategory);
                    vInvoicingContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception(string.Concat("La categoria no existe"));
                }

            }catch (Exception exception)
            {
                throw new Exception(string.Concat("Se ha producido un error al momento de eliminar la categoria", exception));
            }
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            try
            {
                var listCategory = vInvoicingContext.Categories.ToList();
                List<CategoryDTO> allCategory = vMapper.Map<List<Category>, List<CategoryDTO>>(listCategory);
                return allCategory;
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se ha producido un error al momento de buscar las categorias", exception));
            }
        }

        public CategoryDTO GetById(int pId)
        {
            try
            {
                var oCategory = vInvoicingContext.Categories.Where(where => where.Id == pId).FirstOrDefault();
                var category = vMapper.Map<Category, CategoryDTO>(oCategory);
                return category;
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se ha producido un error al momento de buscar la categoria", exception));
            }
        }

        public void Update(CategoryDTO pCategory)
        {
            try
            {
                var oCategory = vInvoicingContext.Categories.Where(where => where.Id == pCategory.Id).FirstOrDefault();
                if (oCategory != null)
                {
                    oCategory.Description = pCategory.Description;
                    vInvoicingContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception(string.Concat("La categoria no existe"));
                }

            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se presento un error al momento de actualizar la categoria", exception));
            }
        }
    }
}
