using Data;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using System.Collections.Generic;

namespace Invoicing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WayToPayController : ControllerBase
    {
        #region Field

        private readonly IBasicCRUD<WayToPayDTO> _IBasicCRUD;
        private readonly ICreateCRUD<WayToPayDTO> _ICreateCRUD;
        private readonly IDeleteCRUD<WayToPayDTO> _IDeleteCRUD;
        private readonly IUpdateCRUD<WayToPayDTO> _IUpdateCRUD;

        #endregion Field

        #region Build

        public WayToPayController(IBasicCRUD<WayToPayDTO> pIBasicCRUD, ICreateCRUD<WayToPayDTO> pICreateCRUD, IDeleteCRUD<WayToPayDTO> pIDeleteCRUD, IUpdateCRUD<WayToPayDTO> pIUpdateCRUD)
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
        public void Create([FromBody] WayToPayDTO pCategoryDTO)
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
        public IEnumerable<WayToPayDTO> GetAll()
        {
            return _IBasicCRUD.GetAll();
        }

        [HttpGet]
        [Route(nameof(CategoryController.GetById))]
        public WayToPayDTO GetById(int pId)
        {
            return _IBasicCRUD.GetById(pId);
        }

        [HttpPut]
        [Route(nameof(CategoryController.Update))]
        public void Update([FromBody] WayToPayDTO pCategoryDTO)
        {
            _IUpdateCRUD.Update(pCategoryDTO);
        }

        #endregion Method
    }
}
