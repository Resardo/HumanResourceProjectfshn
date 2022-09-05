using Domain.Contracts;
using DTO.EducationDTO;
using Entities.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace HumanResourceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private IConfiguration _config;
        private readonly IEducationDomain _educationdomain;

        public EducationController(IConfiguration config, IEducationDomain educationdomain)
        {
            _config = config;
            _educationdomain = educationdomain;
        }



        [HttpGet]
        [Route("{userId}")]
        public IActionResult GetEducationById([FromRoute] Guid userId)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                var user = _educationdomain.GetEducationById(userId);


                return Ok(user);


            }

            catch (Exception ex)
            {
                throw ex;
            }


        }


        [HttpPost]
        [Route("addEducation")]
        public IActionResult AddEducation([FromBody] EducationDTO education)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                var user = _educationdomain.Add(education);


                return Ok(user);


            }

            catch (Exception ex)
            {
                throw ex;
            }


        }


        [HttpPut]
        [Route("userId")]
        public IActionResult UpdateEducation([FromBody] EducationDTO education )
        {
            var educationToUpdate = _educationdomain.GetEducationById(education.Id);
            if (education == null || educationToUpdate == null)
            {
                return BadRequest("Job does not exist.");
            }
            else
            {
                _educationdomain.Update(education);
                return Ok();

            }
        }
    




    [HttpDelete]
    [Route("{userId}")]
    public IActionResult DeleteEducation([FromRoute] Guid Id)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest();
            _educationdomain.Remove(Id);


            return Ok("update completed");


        }

        catch (Exception ex)
        {
            throw ex;
        }


    }



    }


}
