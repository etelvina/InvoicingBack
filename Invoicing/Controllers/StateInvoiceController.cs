using Data;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using System.Collections.Generic;

namespace Invoicing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateInvoiceController : ControllerBase
    {
        #region Field

        private readonly IBasicCRUD<StateInvoiceDTO> _IBasicCRUD;
        private readonly ICreateCRUD<StateInvoiceDTO> _ICreateCRUD;
        private readonly IDeleteCRUD<StateInvoiceDTO> _IDeleteCRUD;
        private readonly IUpdateCRUD<StateInvoiceDTO> _IUpdateCRUD;

        #endregion Field

        #region Build

        public StateInvoiceController(IBasicCRUD<StateInvoiceDTO> pIBasicCRUD, ICreateCRUD<StateInvoiceDTO> pICreateCRUD, IDeleteCRUD<StateInvoiceDTO> pIDeleteCRUD, IUpdateCRUD<StateInvoiceDTO> pIUpdateCRUD)
        {
            _IBasicCRUD = pIBasicCRUD;
            _ICreateCRUD = pICreateCRUD;
            _IDeleteCRUD = pIDeleteCRUD;
            _IUpdateCRUD = pIUpdateCRUD;
        }

        #endregion Build

        #region Method

        [HttpPost]
        [Route(nameof(StateInvoiceController.Create))]
        public void Create([FromBody] StateInvoiceDTO pStateInvoiceDTO)
        {
            _ICreateCRUD.Create(pStateInvoiceDTO);
        }

        [HttpDelete]
        [Route(nameof(StateInvoiceController.Delete))]
        public void Delete(int pId)
        {
            _IDeleteCRUD.Delete(pId);
        }

        [HttpGet]
        [Route(nameof(StateInvoiceController.GetAll))]
        public IEnumerable<StateInvoiceDTO> GetAll()
        {
            return _IBasicCRUD.GetAll();
        }

        [HttpGet]
        [Route(nameof(StateInvoiceController.GetById))]
        public StateInvoiceDTO GetById(int pId)
        {
            return _IBasicCRUD.GetById(pId);
        }

        [HttpPut]
        [Route(nameof(StateInvoiceController.Update))]
        public void Update([FromBody] StateInvoiceDTO pStateInvoiceDTO)
        {
            _IUpdateCRUD.Update(pStateInvoiceDTO);
        }

        #endregion 
    }
}
