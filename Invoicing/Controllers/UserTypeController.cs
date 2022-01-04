using Data;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using System.Collections.Generic;

namespace Invoicing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        #region Field

        private readonly IBasicCRUD<UserTypeDTO> _IBasicCRUD;
        private readonly ICreateCRUD<UserTypeDTO> _ICreateCRUD;
        private readonly IDeleteCRUD<UserTypeDTO> _IDeleteCRUD;
        private readonly IUpdateCRUD<UserTypeDTO> _IUpdateCRUD;

        #endregion Field

        #region Build

        public UserTypeController(IBasicCRUD<UserTypeDTO> pIBasicCRUD, ICreateCRUD<UserTypeDTO> pICreateCRUD, IDeleteCRUD<UserTypeDTO> pIDeleteCRUD, IUpdateCRUD<UserTypeDTO> pIUpdateCRUD)
        {
            _IBasicCRUD = pIBasicCRUD;
            _ICreateCRUD = pICreateCRUD;
            _IDeleteCRUD = pIDeleteCRUD;
            _IUpdateCRUD = pIUpdateCRUD;
        }

        #endregion Build

        #region Method

        [HttpPost]
        [Route(nameof(UserTypeController.Create))]
        public void Create([FromBody] UserTypeDTO pUserTypeDTO)
        {
            _ICreateCRUD.Create(pUserTypeDTO);
        }

        [HttpDelete]
        [Route(nameof(UserTypeController.Delete))]
        public void Delete(int pId)
        {
            _IDeleteCRUD.Delete(pId);
        }

        [HttpGet]
        [Route(nameof(UserTypeController.GetAll))]
        public IEnumerable<UserTypeDTO> GetAll()
        {
            return _IBasicCRUD.GetAll();
        }

        [HttpGet]
        [Route(nameof(UserTypeController.GetById))]
        public UserTypeDTO GetById(int pId)
        {
            return _IBasicCRUD.GetById(pId);
        }

        [HttpPut]
        [Route(nameof(UserTypeController.Update))]
        public void Update([FromBody] UserTypeDTO pUserTypeDTO)
        {
            _IUpdateCRUD.Update(pUserTypeDTO);
        }

        #endregion Method
    }
}
