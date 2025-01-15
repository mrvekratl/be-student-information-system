using App.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Numerics;
using System.Security.Claims;
using System.Xml.Linq;

namespace App.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public static List<StudentRegisterModel> StudentsList = new()
        {
            new StudentRegisterModel{
                Username= "Mkiratli",
                Name="Merve", 
                Surname="Kiratli", 
                StudentIdNumber=1, 
                Class="A", 
                Email="mk@mk.com",
                Phone="05555555555",
                DateOfBirth = DateTime.ParseExact("06-09-1997", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                Adress="Ankara",
                Password="Mk12345",
                PasswordRepeat="Mk12345"
            }
        };

        [HttpGet("GetList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<StudentRegisterModel> GetList()
        {
            return StudentsList;
        }

        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Consumes("application/json")]

        public IActionResult Login([FromForm]StudentLoginModel student)
        {
            var user = StudentsList.FirstOrDefault(x => x.Username == student.UserName && x.Password == student.Password);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (user == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            return Ok();
        }

        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes("application/json")]
        public IActionResult Register([FromForm]StudentRegisterModel newStudent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (newStudent.Password != newStudent.PasswordRepeat)
            {
                return BadRequest("Passwords do not match.");
            }
            if (StudentsList.Any(s => s.StudentIdNumber == newStudent.StudentIdNumber))
            {
                return BadRequest("Student ID number must be unique.");
            }

            var student = new StudentRegisterModel
            {
                Username = newStudent.Username,
                Name= newStudent.Name,
                Surname= newStudent.Surname,
                StudentIdNumber= newStudent.StudentIdNumber,
                Class = newStudent.Class,
                Email = newStudent.Email,
                Phone = newStudent.Phone,
                DateOfBirth = newStudent.DateOfBirth,
                Adress = newStudent.Adress,
                Password = newStudent.Password,
                PasswordRepeat = newStudent.PasswordRepeat
            };

            StudentsList.Add(student);
            return Created();
        }


        [HttpPut("{studentIdNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Consumes("application/json")]
        public IActionResult Update(int id, [FromForm] StudentRegisterModel newStudent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var student = StudentsList.FirstOrDefault(s => s.StudentIdNumber == id);
            if (student == null)
            {
                return NotFound();
            }

            student.Username = newStudent.Username;
            student.Name = newStudent.Name;
            student.Surname = newStudent.Surname;            
            student.Class = newStudent.Class;
            student.Email = newStudent.Email;
            student.Phone = newStudent.Phone;
            student.DateOfBirth = newStudent.DateOfBirth;
            student.Adress = newStudent.Adress;
            student.Password = newStudent.Password;
            student.PasswordRepeat = newStudent.PasswordRepeat;

            return Ok(student);
        }

        [HttpDelete("{studentIdNumber}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteStudent(int id)        {
            
            var student = StudentsList.Find(s => s.StudentIdNumber == id);

            if (student == null)
            {
                return NotFound();
            }
            
            StudentsList.Remove(student);

            return NoContent(); 
        }

    }
}
