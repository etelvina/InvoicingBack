using AutoMapper;
using Data;
using Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repository
{
    public class StateRepository : IBasicCRUD<StateDTO>, ICreateCRUD<StateDTO>, IDeleteCRUD<StateDTO>, IUpdateCRUD<StateDTO>
    {
        private readonly IMapper vMapper;
        private readonly InvoicingContext vInvoicingContext;

        public StateRepository(IMapper pIMapper, InvoicingContext pAutomatizerContext)
        {
            vMapper = pIMapper;
            vInvoicingContext = pAutomatizerContext;
        }
        public void Create(StateDTO pState)
        {
            try
            {
                var vCreateState = vMapper.Map<StateDTO, State>(pState);
                vInvoicingContext.States.AddAsync(vCreateState);
                vInvoicingContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se ha producido un error al momento de crear el estado", exception));
            }
        }

        public void Delete(int pId)
        {
            try
            {
                var oState = vInvoicingContext.States.Where(where => where.Id == pId).FirstOrDefault();
                if (oState != null)
                {
                    vInvoicingContext.States.Remove(oState);
                    vInvoicingContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception(string.Concat("El estado no existe"));
                }
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se ha producido un error al momento de eliminar el estado", exception));
            }
        }

        public IEnumerable<StateDTO> GetAll()
        {
            try
            {
                var listState = vInvoicingContext.States.ToList();
                List<StateDTO> allState = vMapper.Map<List<State>, List<StateDTO>>(listState);
                return allState;
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se ha producido un error al momento de buscar los estados", exception));
            }
        }

        public StateDTO GetById(int pId)
        {
            try
            {
                var oState = vInvoicingContext.States.Where(where => where.Id == pId).FirstOrDefault();
                var state = vMapper.Map<State, StateDTO>(oState);
                return state;
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se ha producido un error al momento de buscar el estado", exception));
            }
        }

        public void Update(StateDTO pState)
        {
            try
            {
                var oState = vInvoicingContext.States.Where(where => where.Id == pState.Id).FirstOrDefault();
                if (oState != null)
                {
                    oState.Description = pState.Description;
                    vInvoicingContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception(string.Concat("El estado no existe"));
                }
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se ha producido un error al momento de actualizar el estado", exception));
            }
        }
    }
}
