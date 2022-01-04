using AutoMapper;
using Data;
using Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repository
{
    public class InvoiceRepository : IBasicCRUD<InvoiceDTO>, ICreateCRUD<InvoiceDTO>, IDeleteCRUD<InvoiceDTO>
    {
        private readonly IMapper vMapper;
        private readonly InvoicingContext vInvoicingContext;

        public InvoiceRepository(IMapper pIMapper, InvoicingContext pAutomatizerContext)
        {
            vMapper = pIMapper;
            vInvoicingContext = pAutomatizerContext;
        }
        public void Create(InvoiceDTO pInvoice)
        {
            try
            {
                var vCreateInvoice = vMapper.Map<InvoiceDTO, Invoice>(pInvoice);
                vInvoicingContext.Invoices.AddAsync(vCreateInvoice);
                vInvoicingContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se ha producido un error al crear la factura", exception));
            }
        }

        public void Delete(int pId)
        {
            try
            {
                var oInvoice = vInvoicingContext.Invoices.Where(where => where.Id == pId).FirstOrDefault();
                if (oInvoice != null)
                {
                    oInvoice.IdState = 2;
                    vInvoicingContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception(string.Concat("No se ha podido al eliminar la factura"));
                }
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se ha producido un error al momento de eliminar la factura", exception));
            }
        }

        public IEnumerable<InvoiceDTO> GetAll()
        {
            try
            {
                var listInvoice = vInvoicingContext.Invoices.ToList(); 
                List<InvoiceDTO> allInvoice = vMapper.Map<List<Invoice>, List<InvoiceDTO>>(listInvoice);
                return allInvoice;
            }
            catch(Exception exception)
            {
                throw new Exception(string.Concat("Se ha producido un eror al momento de buscar las facturas", exception));
            }
        }

        public InvoiceDTO GetById(int pId)
        {
            try
            {
                var oInvoice = vInvoicingContext.Invoices.Where(where => where.Id == pId).FirstOrDefault();
                var invoice = vMapper.Map<Invoice, InvoiceDTO>(oInvoice);
                return invoice;
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se ha producido un error al buscar la facturas", exception));
            }
        }
    }
}
