using Data;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using System.Collections.Generic;

namespace Invoicing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        #region Field

        private readonly IBasicCRUD<CategoryDTO> _IBasicCRUD;
        private readonly ICreateCRUD<CategoryDTO> _ICreateCRUD;
        private readonly IDeleteCRUD<CategoryDTO> _IDeleteCRUD;
        private readonly IUpdateCRUD<CategoryDTO> _IUpdateCRUD;

        #endregion Field

        #region Build

        public CategoryController(IBasicCRUD<CategoryDTO> pIBasicCRUD, ICreateCRUD<CategoryDTO> pICreateCRUD, IDeleteCRUD<CategoryDTO> pIDeleteCRUD, IUpdateCRUD<CategoryDTO> pIUpdateCRUD)
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
        public void Create([FromBody] CategoryDTO pCategoryDTO)
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
        public IEnumerable<CategoryDTO> GetAll()
        {
            return _IBasicCRUD.GetAll();
        }

        [HttpGet]
        [Route(nameof(CategoryController.GetById))]
        public CategoryDTO GetById(int pId)
        {
            return _IBasicCRUD.GetById(pId);
        }

        [HttpPut]
        [Route(nameof(CategoryController.Update))]
        public void Update([FromBody] CategoryDTO pCategoryDTO)
        {
            _IUpdateCRUD.Update(pCategoryDTO);
        }

        #endregion Method
    }
}
