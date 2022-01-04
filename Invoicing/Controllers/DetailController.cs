using Data;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using System.Collections.Generic;

namespace Invoicing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailController : ControllerBase
    {
        #region Field

        private readonly IBasicCRUD<DetailDTO> _IBasicCRUD;
        private readonly ICreateCRUD<DetailDTO> _ICreateCRUD;
        private readonly IDeleteCRUD<DetailDTO> _IDeleteCRUD;
        private readonly IUpdateCRUD<DetailDTO> _IUpdateCRUD;

        #endregion Field

        #region Build

        public DetailController(IBasicCRUD<DetailDTO> pIBasicCRUD, ICreateCRUD<DetailDTO> pICreateCRUD, IDeleteCRUD<DetailDTO> pIDeleteCRUD, IUpdateCRUD<DetailDTO> pIUpdateCRUD)
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
        public void Create([FromBody] DetailDTO pCategoryDTO)
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
        public IEnumerable<DetailDTO> GetAll()
        {
            return _IBasicCRUD.GetAll();
        }

        [HttpGet]
        [Route(nameof(CategoryController.GetById))]
        public DetailDTO GetById(int pId)
        {
            return _IBasicCRUD.GetById(pId);
        }

        [HttpPut]
        [Route(nameof(CategoryController.Update))]
        public void Update([FromBody] DetailDTO pCategoryDTO)
        {
            _IUpdateCRUD.Update(pCategoryDTO);
        }

        #endregion Method
    }
}
