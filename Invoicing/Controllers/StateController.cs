using Data;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using System.Collections.Generic;

namespace Invoicing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        #region Field

        private readonly IBasicCRUD<StateDTO> _IBasicCRUD;
        private readonly ICreateCRUD<StateDTO> _ICreateCRUD;
        private readonly IDeleteCRUD<StateDTO> _IDeleteCRUD;
        private readonly IUpdateCRUD<StateDTO> _IUpdateCRUD;

        #endregion Field

        #region Build

        public StateController(IBasicCRUD<StateDTO> pIBasicCRUD, ICreateCRUD<StateDTO> pICreateCRUD, IDeleteCRUD<StateDTO> pIDeleteCRUD, IUpdateCRUD<StateDTO> pIUpdateCRUD)
        {
            _IBasicCRUD = pIBasicCRUD;
            _ICreateCRUD = pICreateCRUD;
            _IDeleteCRUD = pIDeleteCRUD;
            _IUpdateCRUD = pIUpdateCRUD;
        }

        #endregion Build

        #region Method

        [HttpPost]
        [Route(nameof(CategoryController.Create))]
        public void Create([FromBody] StateDTO pCategoryDTO)
        {
            _ICreateCRUD.Create(pCategoryDTO);
        }

        [HttpDelete]
        [Route(nameof(CategoryController.Delete))]
        public void Delete(int pId)
        {
            _IDeleteCRUD.Delete(pId);
        }

        [HttpGet]
        [Route(nameof(CategoryController.GetAll))]
        public IEnumerable<StateDTO> GetAll()
        {
            return _IBasicCRUD.GetAll();
        }

        [HttpGet]
        [Route(nameof(CategoryController.GetById))]
        public StateDTO GetById(int pId)
        {
            return _IBasicCRUD.GetById(pId);
        }

        [HttpPut]
        [Route(nameof(CategoryController.Update))]
        public void Update([FromBody] StateDTO pCategoryDTO)
        {
            _IUpdateCRUD.Update(pCategoryDTO);
        }

        #endregion Method
    }
}
