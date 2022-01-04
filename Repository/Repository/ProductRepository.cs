using AutoMapper;
using Data;
using Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repository
{
    public class ProductRepository : IBasicCRUD<ProductDTO>, ICreateCRUD<ProductDTO>, IDeleteCRUD<ProductDTO>, IUpdateCRUD<ProductDTO>
    {
        private readonly IMapper vMapper;
        private readonly InvoicingContext vInvoicingContext;

        public ProductRepository(IMapper pIMapper, InvoicingContext pAutomatizerContext)
        {
            vMapper = pIMapper;
            vInvoicingContext = pAutomatizerContext;
        }
        public void Create(ProductDTO pProduct)
        {
            try
            {
                var vCreateProduct = vMapper.Map<ProductDTO, Product>(pProduct);
                vInvoicingContext.Products.AddAsync(vCreateProduct);
                vInvoicingContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se ha producido un error al momento de crear el producto", exception));
            }
        }

        public void Delete(int pId)
        {
            try
            {
                var oProducto = vInvoicingContext.Products.Where(where => where.Id == pId).FirstOrDefault();
                if (oProducto != null)
                {
                    oProducto.IdState = 2;
                    vInvoicingContext.SaveChangesAsync();
                }
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se ha producido un error al momento de eliminar el producto", exception));
            }
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            try
            {
                var listProduct = vInvoicingContext.Products.ToList();
                List<ProductDTO> allProduct = vMapper.Map<List<Product>, List<ProductDTO>>(listProduct);
                return allProduct;
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se ha producido un error al momento de buscar los productos", exception));
            }
        }

        public ProductDTO GetById(int pId)
        {
            try
            {
                var oProduct = vInvoicingContext.Products.Where(where => where.Id == pId).FirstOrDefault();
                var product = vMapper.Map<Product, ProductDTO>(oProduct);
                return product;
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se ha producido un error al momento de buscar el producto", exception));
            }
        }

        public void Update(ProductDTO pProduct)
        {
            try
            {
                var oProduct = vInvoicingContext.Products.Where(where => where.Id == pProduct.Id).FirstOrDefault();
                if (oProduct != null)
                {
                    oProduct.Description = oProduct.Description;
                    oProduct.Price = oProduct.Price;
                    oProduct.Vat = pProduct.Vat;
                    oProduct.Stock = pProduct.Stock;
                    vInvoicingContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception(string.Concat("El producto no existe"));
                }
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se presento un error al momento de actualizar el producto", exception));
            }
        }
    }
}
