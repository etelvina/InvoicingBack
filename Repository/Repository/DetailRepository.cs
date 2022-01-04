using AutoMapper;
using Data;
using Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repository
{
    public class DetailRepository : IBasicCRUD<DetailDTO>, ICreateCRUD<DetailDTO>
    {
        private readonly IMapper vMapper;
        private readonly InvoicingContext vInvoicingContext;

        public DetailRepository(IMapper pIMapper, InvoicingContext pAutomatizerContext)
        {
            vMapper = pIMapper;
            vInvoicingContext = pAutomatizerContext;
        }

        public void Create(DetailDTO pDetail)
        {
            try
            {
                var vCreateDetail = vMapper.Map<DetailDTO, Detail>(pDetail);
                vInvoicingContext.Details.AddAsync(vCreateDetail);
                vInvoicingContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se ha producio un erro al momento de crear el detalle", exception));
            }
        }

        public IEnumerable<DetailDTO> GetAll()
        {
            try
            {
                var listDetail = vInvoicingContext.Details.ToList();
                List<DetailDTO> allDetail = vMapper.Map<List<Detail>, List<DetailDTO>>(listDetail);
                return allDetail;
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se ha producido un error al momento de buscar los detalles", exception));
            }
        }

        public DetailDTO GetById(int pId)
        {
            try
            {
                var oDetail = vInvoicingContext.Details.Where(where => where.Id == pId).FirstOrDefault();
                var detail = vMapper.Map<Detail, DetailDTO>(oDetail);
                return detail;
            }
            catch(Exception exception)
            {
                throw new Exception(string.Concat("Se ha producido un error al momento de buscar el detalle", exception));
            }
            
        }
    }
}
