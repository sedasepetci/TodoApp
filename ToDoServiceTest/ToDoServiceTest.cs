using AutoMapper;
using Moq;
using TodoApp.DataAccess.Abstracts;
using TodoApp.Models.Dtos.ToDos.Responses;
using TodoApp.Models.Entities;
using TodoApp.Models.Enums;
using TodoApp.Service.Concretes;
using TodoApp.Models.Dtos.ToDos.Requests;
using Core.Exceptions;

[TestFixture]
public class ToDoServiceTest
{
    private ToDoService _todoService;
    private Mock<IMapper> _mockMapper;
    private Mock<IToDoRepository> _repositoryMock;
    private Mock<TodoBusinessRules> _rulesMock;

    [SetUp]
    public void SetUp()
    {
        _repositoryMock = new Mock<IToDoRepository>();
        _mockMapper = new Mock<IMapper>();
        _rulesMock = new Mock<TodoBusinessRules>();
        _todoService = new ToDoService(_repositoryMock.Object, _mockMapper.Object, _rulesMock.Object);
    }

    [Test]
    public async Task GetAllAsync_ReturnsSuccess()
    {

        List<ToDo> todos = new List<ToDo>
        {
            new ToDo
            {
                Id = Guid.NewGuid(),
                Title = "ToDo 1",
                Description = "Description 1",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                Priority = Priority.Medium
            },
            new ToDo
            {
                Id = Guid.NewGuid(),
                Title = "ToDo 2",
                Description = "Description 2",
                StartDate = DateTime.Now.AddDays(1),
                EndDate = DateTime.Now.AddDays(2),
                Priority = Priority.Low
            }
        };

        List<ToDoResponseDto> responses = new List<ToDoResponseDto>
        {
            new ToDoResponseDto
            {
                Title = "ToDo 1",
                Description = "Description 1",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                Priority = Priority.Medium
            },
            new ToDoResponseDto
            {
                Title = "ToDo 2",
                Description = "Description 2",
                StartDate = DateTime.Now.AddDays(1),
                EndDate = DateTime.Now.AddDays(2),
                Priority = Priority.Low
            }
        };


        _repositoryMock.Setup(x => x.GetAllAsync(null, true)).ReturnsAsync(todos);
        _mockMapper.Setup(x => x.Map<List<ToDoResponseDto>>(todos)).Returns(responses);


        var result = await _todoService.GetAllAsync();


        Assert.IsTrue(result.Success);
        Assert.AreEqual(responses, result.Data);
        Assert.AreEqual(200, result.StatusCode);
        Assert.AreEqual(string.Empty, result.Message);
    }

    public async Task Add_WhenPostAdded_ReturnsSuccess()
    {


        CreateToDoRequestDto dto = new CreateToDoRequestDto(
            Title: "Deneme",
            Description: "Content",
            StartDate: DateTime.Now,
            EndDate: DateTime.Now.AddDays(1),
            Completed: false,
            UserId: "{5C95E9E2-3ECE-4465-8A1D-8E38CA2BFFDC}",
            Priority: Priority.Medium,
            CategoryId: 100
        );


        ToDo todo = new ToDo
        {
            Id = new Guid("{6C95E9E2-3ECE-4465-8A1D-8E38CA2BFFDC}"),
            Title = dto.Title,
            Description = dto.Description,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            Completed = dto.Completed,
            UserId = dto.UserId,
            Priority = dto.Priority,
            CategoryId = dto.CategoryId,
            CreatedDate = DateTime.Now
        };


        ToDoResponseDto response = new ToDoResponseDto
        {
            Title = "Deneme",
            Description = "Deneme",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(1),
            Priority = Priority.Medium
        };


        _mockMapper.Setup(x => x.Map<ToDo>(dto)).Returns(todo);
        _repositoryMock.Setup(x => x.AddAsync(todo)).ReturnsAsync(todo);
        _mockMapper.Setup(x => x.Map<ToDoResponseDto>(todo)).Returns(response);


        var result = await _todoService.AddAsync(dto, "{5C95E9E2-3ECE-4465-8A1D-8E38CA2BFFDC}");


        Assert.IsTrue(result.Success);
        Assert.AreEqual(response, result.Data);
        Assert.AreEqual(201, result.StatusCode);
    }
    [Test]
    public async Task GetById_WhenToDoIsNotPresent_ThrowsNotFoundException()
    {
     
        Guid id = new Guid("{BA663833-98D6-4BE6-93C3-65997006B13A}");
        ToDo todo = null;
        _rulesMock.Setup(x => x.TodoIsNullCheck(todo)).Throws(new NotFoundException("İlgili iş bulunamadı."));
        var exception = Assert.ThrowsAsync<NotFoundException>(async () => await _todoService.GetByIdAsync(id));
        Assert.AreEqual("İlgili iş bulunamadı.", exception.Message);
    }

    [Test]
    public async Task GetById_WhenTodoIsPresent_ReturnsSuccess()
    {
       
        ToDo todo = new ToDo
        {
            Id = new Guid("{BA663833-98D6-4BE6-93C3-65997006B13A}")
        };

        Guid id = new Guid("{BA663833-98D6-4BE6-93C3-65997006B13A}");

        
        ToDoResponseDto response = new ToDoResponseDto
        {
            Title = "Deneme",
            Description = "Deneme",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(1),
            Priority = Priority.Medium
        };

        
        _repositoryMock.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(todo); 
        _rulesMock.Setup(x => x.TodoIsNullCheck(todo));
        _mockMapper.Setup(x => x.Map<ToDoResponseDto>(todo)).Returns(response);
        var result = await _todoService.GetByIdAsync(id); 

        Assert.AreEqual(response, result.Data);
        Assert.IsTrue(result.Success);
    }

}







