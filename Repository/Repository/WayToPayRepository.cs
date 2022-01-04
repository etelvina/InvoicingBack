using AutoMapper;
using Data;
using Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repository
{
    public class WayToPayRepository : IBasicCRUD<WayToPayDTO>, ICreateCRUD<WayToPayDTO>, IDeleteCRUD<WayToPayDTO>, IUpdateCRUD<WayToPayDTO>
    {
        private readonly IMapper vMapper;
        private readonly InvoicingContext vInvoicingContext;

        public WayToPayRepository(IMapper pIMapper, InvoicingContext pAutomatizerContext)
        {
            vMapper = pIMapper;
            vInvoicingContext = pAutomatizerContext;
        }
        public void Create(Data.WayToPayDTO pWayToPay)
        {
            try
            {
                var vCreateWayToPay = vMapper.Map<WayToPayDTO, WayToPay>(pWayToPay);
                vInvoicingContext.WayToPays.AddAsync(vCreateWayToPay);
                vInvoicingContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se ha producido un error al momento de crear la forma de pago", exception));
            }
        }

        public void Delete(int pId)
        {
            try
            {
                var oWayToPay = vInvoicingContext.WayToPays.Where(where => where.Id == pId).FirstOrDefault();

                if (oWayToPay != null)
                {
                    vInvoicingContext.WayToPays.Remove(oWayToPay);
                    vInvoicingContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception(string.Concat("La forma de pago no existe"));
                }
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se ha producido un error al momento de eliminar la forma de pago", exception));
            }
        }

        public IEnumerable<WayToPayDTO> GetAll()
        {
            try
            {
                var listWayToPay = vInvoicingContext.WayToPays.ToList();
                List<WayToPayDTO> allWayToPay = vMapper.Map<List<WayToPay>, List<WayToPayDTO>>(listWayToPay);
                return allWayToPay;
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se ha producido un error al momento de buscar las formas de pago", exception));
            }
        }

        public Data.WayToPayDTO GetById(int pId)
        {
            try
            {
                var oWayToPay = vInvoicingContext.WayToPays.Where(where => where.Id == pId).FirstOrDefault();
                var wayToPay = vMapper.Map<WayToPay, WayToPayDTO>(oWayToPay);
                return wayToPay;
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se ha producido un error al momento de buscar la forma de pago", exception));
            }
        }

        public void Update(WayToPayDTO pWayToPay)
        {
            try
            {
                var oWayToPay = vInvoicingContext.WayToPays.Where(where => where.Id == pWayToPay.Id).FirstOrDefault();

                if (oWayToPay != null)
                {
                    oWayToPay.Description = pWayToPay.Description;
                    vInvoicingContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception(string.Concat("La forma de pago no existe"));
                }
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se ha producido un error al momento de actualizar la forma de pago", exception));
            }
        }
    }
}
