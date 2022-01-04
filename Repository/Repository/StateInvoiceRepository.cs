using AutoMapper;
using Data;
using Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repository
{
    public class StateInvoiceRepository : IBasicCRUD<StateInvoiceDTO>, ICreateCRUD<StateInvoiceDTO>, IDeleteCRUD<StateInvoiceDTO>, IUpdateCRUD<StateInvoiceDTO>
    {
        private readonly IMapper vMapper;
        private readonly InvoicingContext vInvoicingContext;

        public StateInvoiceRepository(IMapper pIMapper, InvoicingContext pAutomatizerContext)
        {
            vMapper = pIMapper;
            vInvoicingContext = pAutomatizerContext;
        }

        public void Create(StateInvoiceDTO pStateInvoice)
        {
            try
            {
                var vCreateStateInvoice = vMapper.Map<StateInvoiceDTO, StateInvoice>(pStateInvoice);
                vInvoicingContext.StateInvoices.AddAsync(vCreateStateInvoice);
                vInvoicingContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se ha producido un error al momento de crear el estado de la factura", exception));
            }
        }

        public void Delete(int pId)
        {
            try
            {
                var oStateInvoice = vInvoicingContext.StateInvoices.Where(where => where.Id == pId).FirstOrDefault();
                if (oStateInvoice != null)
                {
                    vInvoicingContext.StateInvoices.Remove(oStateInvoice);
                    vInvoicingContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception(string.Concat("El estado la factura no existe"));
                }
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se ha producido un error al momento de eliminar el estado la factura", exception));
            }
        }

        public IEnumerable<StateInvoiceDTO> GetAll()
        {
            try
            {
                var listStateInvoice = vInvoicingContext.StateInvoices.ToList();
                List<StateInvoiceDTO> allStateInvoice = vMapper.Map<List<StateInvoice>, List<StateInvoiceDTO>>(listStateInvoice);
                return allStateInvoice;
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se ha producido un error al momento de buscar los estados las facturas", exception));
            }
        }

        public StateInvoiceDTO GetById(int pId)
        {
            try
            {
                var oStateInvoice = vInvoicingContext.StateInvoices.Where(where => where.Id == pId).FirstOrDefault();
                var stateInvoice = vMapper.Map<StateInvoice, StateInvoiceDTO>(oStateInvoice);
                return stateInvoice;
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se ha producido un error al momento de buscar el estado la factura", exception));
            }
        }

        public void Update(StateInvoiceDTO pStateInvoice)
        {
            try
            {
                var oStateInvoice = vInvoicingContext.StateInvoices.Where(where => where.Id == pStateInvoice.Id).FirstOrDefault();
                if (oStateInvoice != null)
                {
                    oStateInvoice.Description = pStateInvoice.Description;
                    vInvoicingContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception(string.Concat("El estado la factura no existe"));
                }
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se ha producido un error al momento de actualizar el estado la factura", exception));
            }
        }
    }
}
