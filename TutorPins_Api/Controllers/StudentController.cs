﻿using BusinessLayer.Repository;
using BusinessLayer.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace TutorPins_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _Repository;
        public StudentController(IStudentRepository studentRepository)
        {
            _Repository = studentRepository;
        }
        [HttpGet]
        [Route("GetStudents")]
        public async Task<IActionResult> GetStudents()
        {
            var allObjects = await _Repository.GetAllStudents();
            return Ok(allObjects);
        }
        [HttpPost]
        [Route("AddStudent")]
        public async Task<StudentDto> AddStudent([FromBody] StudentDto objectDto)
        {
            return await _Repository.CreateStudent(objectDto);
        }
        [HttpGet("{id}")]
        public async Task<StudentDto> Get(int id)
        {
            return await _Repository.GetStudent(id);
        }
        [HttpGet]
        [Route("GetStudentByStatus/{status}")]
        public async Task<IEnumerable<StudentDto>> GetStudentByStatus(string status)
        {
            return await _Repository.GetStudentsByStatus(status);
        }
    }
}
