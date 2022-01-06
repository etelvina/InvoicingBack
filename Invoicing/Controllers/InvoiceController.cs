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
        //private readonly ICreateCRUD<InvoiceDTO> _ICreateCRUD;
        //private readonly IDeleteCRUD<InvoiceDTO> _IDeleteCRUD;
        //private readonly IUpdateCRUD<InvoiceDTO> _IUpdateCRUD;

        #endregion Field

        #region Build

        public InvoiceController(IBasicCRUD<InvoiceDTO> pIBasicCRUD)
        {
            _IBasicCRUD = pIBasicCRUD;
            //_ICreateCRUD = pICreateCRUD;
            //_IDeleteCRUD = pIDeleteCRUD;
            //_IUpdateCRUD = pIUpdateCRUD;
        }

        #endregion Build

        #region Method

        //[HttpPost]
        //[Route(nameof(InvoiceController.Create))]
        //public void Create([FromBody] InvoiceDTO pInvoiceDTO)
        //{
        //    _ICreateCRUD.Create(pInvoiceDTO);
        //}

        //[HttpDelete]
        //[Route(nameof(InvoiceController.Delete))]
        //public void Delete(int pId)
        //{
        //    _IDeleteCRUD.Delete(pId);
        //}

        [HttpGet]
        [Route(nameof(InvoiceController.GetAll))]
        public IEnumerable<InvoiceDTO> GetAll()
        {
            return _IBasicCRUD.GetAll();
        }

        [HttpGet]
        [Route(nameof(InvoiceController.GetById))]
        public InvoiceDTO GetById(int pId)
        {
            return _IBasicCRUD.GetById(pId);
        }

        //[HttpPut]
        //[Route(nameof(InvoiceController.Update))]
        //public void Update([FromBody] InvoiceDTO pInvoiceDTO)
        //{
        //    _IUpdateCRUD.Update(pInvoiceDTO);
        //}

        #endregion Method
    }
}
