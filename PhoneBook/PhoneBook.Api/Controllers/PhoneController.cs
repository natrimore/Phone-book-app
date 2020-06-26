using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Api.Models;
using PhoneBook.Api.Repositories;
using PhoneBook.Api.Resources;
using PhoneBook.Core.Entities;

namespace PhoneBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private readonly IPhoneRepository _phoneRepository;
        private readonly IMapper _mapper;
        public PhoneController(IPhoneRepository phoneRepository, IMapper mapper)
        {
            _phoneRepository = phoneRepository;
            _mapper = mapper;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll([FromQuery] PhoneResourceParametr phoneResourceParametr)
        {
            var query = _phoneRepository.SelectByParam(phoneResourceParametr);
            var models = _mapper.Map<IEnumerable<PhoneDto>>(query);
            var result = new { result = models };
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreatePhoneDto createPhone)
        {
            var entity = _mapper.Map<Phone>(createPhone);
            await _phoneRepository.Create(entity);

            return Ok(entity);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdatePhoneDto updatePhone)
        {
            var entity = _mapper.Map<Phone>(updatePhone);
            await _phoneRepository.Update(entity);

            return Ok(entity);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _phoneRepository.Delete(id);
            return Ok();
        }


    }
}