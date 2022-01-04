using AutoMapper;
using Data;
using Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repository
{
    public class UserRepository : IBasicCRUD<UserDTO>, ICreateCRUD<UserDTO>, IDeleteCRUD<UserDTO>, IUpdateCRUD<UserDTO>
    {
        private readonly IMapper vMapper;
        private readonly InvoicingContext vInvoicingContext;

        public UserRepository(IMapper pIMapper, InvoicingContext pAutomatizerContext)
        {
            vMapper = pIMapper;
            vInvoicingContext = pAutomatizerContext;
        }
        public void Create(UserDTO pUser)
        {
            try
            {
                var vCreateUser = vMapper.Map<UserDTO, User>(pUser);
                vInvoicingContext.Users.AddAsync(vCreateUser);
                vInvoicingContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new Exception("Se ha producido un error al momento de crear el usuario", exception);
            }
        }

        public void Delete(int pId)
        {
            try
            {
                var oUser = vInvoicingContext.Users.Where(where => where.Id == pId).FirstOrDefault();

                if (oUser != null)
                {
                    oUser.IdState = 2;
                    vInvoicingContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception(string.Concat("La categoria no existe"));
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Se ha producido un error al momento de eliminar el usuario", exception);
            }
        }

        public IEnumerable<UserDTO> GetAll()
        {
            try
            {
                var listUser = vInvoicingContext.Users.ToList();
                List<UserDTO> allUser = vMapper.Map<List<User>, List<UserDTO>>(listUser);
                return allUser;
            }
            catch (Exception exception)
            {
                throw new Exception("Se ha producido un error al momento de buscar los usuarios", exception);
            }
        }

        public UserDTO GetById(int pId)
        {
            try
            {
                var oUser = vInvoicingContext.Users.Where(where => where.Id == pId).FirstOrDefault();
                var user = vMapper.Map<User, UserDTO>(oUser);
                return user;
            }
            catch (Exception exception)
            {
                throw new Exception("Se ha producido un error al momento de buscar el usuario", exception);
            }
        }

        public void Update(UserDTO pUser)
        {
            try
            {
                var oUser = vInvoicingContext.Users.Where(where => where.Id == pUser.Id).FirstOrDefault();
                if (oUser != null)
                {
                    oUser.Name = pUser.Name;
                    oUser.LastName = pUser.LastName;
                    oUser.Address = pUser.Address;
                    oUser.Age = pUser.Age;
                    oUser.Phone = pUser.Phone;
                    oUser.Email = pUser.Email;
                    vInvoicingContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception(string.Concat("El usuario no existe"));
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Se ha producido un error al momento de actualizar el usuario", exception);
            }
        }
    }
}
