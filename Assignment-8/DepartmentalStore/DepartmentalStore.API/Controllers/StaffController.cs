using AutoMapper;
using DepartmentalStore.Domain;
using DepartmentalStore.Domain.Models;
using DepartmentalStore.Repositories.core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentalStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public StaffController(IStaffRepository repository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _repository = repository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        private ObjectResult ExceptionHandler()
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Not able to perform the task.");
        }

        [HttpGet]
        public async Task<ActionResult<List<StaffModel>>> GetAll(bool includeAddress = false, bool includeDesignation = false)
        {
            var staffs = await _repository.GetAllStaffs(includeAddress,includeDesignation);
            var result = _mapper.Map<List<StaffModel>>(staffs);
            return result;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<StaffModel>> GetStaff(int id,bool includeAddress = false, bool includeDesignation = false)
        {
            try
            {
                var staffs = await _repository.GetStaffByID(id, includeAddress, includeDesignation);
                var result = _mapper.Map<StaffModel>(staffs);
                return result;
            }
            catch (Exception)
            { 
                return this.ExceptionHandler();
            }
            
        }

        [HttpPost]
        public async Task<ActionResult<StaffModel>> AddStaffMember(Staff staff)
        {
            try
            {
                _repository.Add(staff);
                
                if (await _repository.SaveChangesAsync() )
                {
                    var url = _linkGenerator.GetPathByAction("GetStaff", "Staff", new { id = staff.ID });
                    if (!string.IsNullOrWhiteSpace(url))
                        return Created(url, _mapper.Map<StaffModel>(staff));
                }
                return BadRequest("Not able to save the data."); 
            }
            catch(Exception)
            {
                return this.ExceptionHandler();
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<StaffModel>> UpdateStaffMember(int id,StaffModel staff)
        {
            try
            {
                var data = await _repository.GetStaffByID(id, false, false);
                if (data == null) return NotFound();
                _mapper.Map(staff, data,opts => opts.BeforeMap((src,dest) => src.ID = dest.ID));
                _repository.Update(data);
                if (await _repository.SaveChangesAsync())
                {
                    return _mapper.Map<StaffModel>(data);
                }
                return BadRequest("Not able to save the data.");
            }
            catch (Exception)
            {
                return this.ExceptionHandler();
            }
        }
        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            try
            {
                var staff = await _repository.GetStaffByID(id, true, true);
                if (staff == null) return NotFound();
                _repository.Delete(staff);
                return Ok();
            }
            catch (Exception)
            {
                return this.ExceptionHandler();
            }

        }
    }
}
