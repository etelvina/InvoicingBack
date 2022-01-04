using Data;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using System.Collections.Generic;

namespace Invoicing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        #region Field

        private readonly IBasicCRUD<DeliveryDTO> _IBasicCRUD;
        private readonly ICreateCRUD<DeliveryDTO> _ICreateCRUD;
        private readonly IDeleteCRUD<DeliveryDTO> _IDeleteCRUD;
        private readonly IUpdateCRUD<DeliveryDTO> _IUpdateCRUD;

        #endregion Field

        #region Build

        public DeliveryController(IBasicCRUD<DeliveryDTO> pIBasicCRUD, ICreateCRUD<DeliveryDTO> pICreateCRUD, IDeleteCRUD<DeliveryDTO> pIDeleteCRUD, IUpdateCRUD<DeliveryDTO> pIUpdateCRUD)
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
        public void Create([FromBody] DeliveryDTO pCategoryDTO)
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
        public IEnumerable<DeliveryDTO> GetAll()
        {
            return _IBasicCRUD.GetAll();
        }

        [HttpGet]
        [Route(nameof(CategoryController.GetById))]
        public DeliveryDTO GetById(int pId)
        {
            return _IBasicCRUD.GetById(pId);
        }

        [HttpPut]
        [Route(nameof(CategoryController.Update))]
        public void Update([FromBody] DeliveryDTO pCategoryDTO)
        {
            _IUpdateCRUD.Update(pCategoryDTO);
        }

        #endregion Method
    }
}
