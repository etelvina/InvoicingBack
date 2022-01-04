using AutoMapper;
using Data;
using Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repository
{
    public class UserTypeRepository : IBasicCRUD<UserTypeDTO>, ICreateCRUD<UserTypeDTO>
    {
        private readonly IMapper vMapper;
        private readonly InvoicingContext vInvoicingContext;

        public UserTypeRepository(IMapper pIMapper, InvoicingContext pAutomatizerContext)
        {
            vMapper = pIMapper;
            vInvoicingContext = pAutomatizerContext;
        }

        public void Create(UserTypeDTO pUserType)
        {
            try
            {
                var vCreateUserType = vMapper.Map<UserTypeDTO, UserType>(pUserType);
                vInvoicingContext.UserTypes.AddAsync(vCreateUserType);
                vInvoicingContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se ha producido un error al momento de crear el tipo de usuario", exception));
            }
        }

        public IEnumerable<UserTypeDTO> GetAll()
        {
            try
            {
                var listUserType = vInvoicingContext.UserTypes.ToList();
                List<UserTypeDTO> allUserType = vMapper.Map<List<UserType>, List<UserTypeDTO>>(listUserType);
                return allUserType;
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se ha producido un error al momento de buscar los tipos de usuarios", exception));
            }
        }

        public UserTypeDTO GetById(int pId)
        {
            try
            {
                var oUserType = vInvoicingContext.UserTypes.Where(where => where.Id == pId).FirstOrDefault();
                var userType = vMapper.Map<UserType, UserTypeDTO>(oUserType);
                return userType;
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se ha producido un error al momento de buscar el tipo de usuario", exception));
            }
        }
    }
}
