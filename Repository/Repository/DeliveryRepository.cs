using AutoMapper;
using Data;
using Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repository
{
    public class DeliveryRepository : IBasicCRUD<DeliveryDTO>, ICreateCRUD<DeliveryDTO>, IDeleteCRUD<DeliveryDTO>, IUpdateCRUD<DeliveryDTO>
    {
        private readonly IMapper vMapper;
        private readonly InvoicingContext vInvoicingContext;

        public DeliveryRepository(IMapper pIMapper, InvoicingContext pAutomatizerContext)
        {
            vMapper = pIMapper;
            vInvoicingContext = pAutomatizerContext;
        }
        public void Create(DeliveryDTO pDelivery)
        {
            try
            {
                var vCreateDelivery = vMapper.Map<DeliveryDTO, Delivery>(pDelivery);
                vInvoicingContext.Deliveries.AddAsync(vCreateDelivery);
                vInvoicingContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se ha producio un erro al momento de crear el envio", exception));
            }
        }

        public void Delete(int pId)
        {
            try
            {
                var oDelivery = vInvoicingContext.Deliveries.Where(where => where.Id == pId).FirstOrDefault();

                if (oDelivery != null)
                {
                    vInvoicingContext.Deliveries.Remove(oDelivery);
                    vInvoicingContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception(string.Concat("El envio no existe"));
                }

            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se ha producido un error al momento de eliminar el envio", exception));
            }
        }

        public IEnumerable<DeliveryDTO> GetAll()
        {
            try
            {
                var listDelivery = vInvoicingContext.Deliveries.ToList();
                List<DeliveryDTO> allDelivery = vMapper.Map<List<Delivery>, List<DeliveryDTO>>(listDelivery);
                return allDelivery;
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se ha producido un error al momento de buscar los envios", exception));
            }
        }

        public DeliveryDTO GetById(int pId)
        {
            try
            {
                var oDelivery = vInvoicingContext.Deliveries.Where(where => where.Id == pId).FirstOrDefault();
                var delivery = vMapper.Map<Delivery, DeliveryDTO>(oDelivery);
                return delivery;
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se ha producido un error al momento de buscar el envio", exception));
            }
        }

        public void Update(DeliveryDTO pDelivery)
        {
            try
            {
                var oDelivery = vInvoicingContext.Deliveries.Where(Where => Where.Id == pDelivery.Id).FirstOrDefault();
                if (oDelivery != null)
                {
                    oDelivery.Description = pDelivery.Description;
                    vInvoicingContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception(string.Concat("El envio no existe"));
                }

            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se presento un error al momento de actualizar el envio", exception));
            }
        }
    }
}
