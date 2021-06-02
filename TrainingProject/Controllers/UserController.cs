/*namespace TrainingProject.Controllers
{
    [Route("api/mapper")]
    [ApiController]
    public class UserController : Controller
    {
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        // Assign the object in the constructor for dependency injection

        public UserController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpGet("user")]
        public UserDto UseMap(string name, int age)
        {
            User user = new User
            {
                Name = name,
                Age = age
            };
            var man = _mapper.Map<UserDto>(user);
            return man;
        }
    }
}*/