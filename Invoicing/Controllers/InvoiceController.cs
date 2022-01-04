using Data;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using System.Collections.Generic;

namespace Invoicing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        #region Field

        private readonly IBasicCRUD<InvoiceDTO> _IBasicCRUD;
        private readonly ICreateCRUD<InvoiceDTO> _ICreateCRUD;
        private readonly IDeleteCRUD<InvoiceDTO> _IDeleteCRUD;
        private readonly IUpdateCRUD<InvoiceDTO> _IUpdateCRUD;

        #endregion Field

        #region Build

        public InvoiceController(IBasicCRUD<InvoiceDTO> pIBasicCRUD, ICreateCRUD<InvoiceDTO> pICreateCRUD, IDeleteCRUD<InvoiceDTO> pIDeleteCRUD, IUpdateCRUD<InvoiceDTO> pIUpdateCRUD)
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
        public void Create([FromBody] InvoiceDTO pCategoryDTO)
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
        public IEnumerable<InvoiceDTO> GetAll()
        {
            return _IBasicCRUD.GetAll();
        }

        [HttpGet]
        [Route(nameof(CategoryController.GetById))]
        public InvoiceDTO GetById(int pId)
        {
            return _IBasicCRUD.GetById(pId);
        }

        [HttpPut]
        [Route(nameof(CategoryController.Update))]
        public void Update([FromBody] InvoiceDTO pCategoryDTO)
        {
            _IUpdateCRUD.Update(pCategoryDTO);
        }

        #endregion Method
    }
}
