
// ### D:\src\CQRS.MinimalAPI.Demo\src\CQRS.MinimalAPI.Demo\CQRS.MinimalAPI.Demo.csproj
<Project Sdk="Microsoft.NET.Sdk.Web">
  <ItemGroup>
    <PackageReference Include="MediatR" Version="12.4.1" />
  </ItemGroup>
</Project>


builder.Services.AddMediatR(cfg =>
{
  cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
});


builder.Services.AddScoped<IStudentsService, StudentsService>();

public record Student(string Name)
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }
  public string Name { get; set; } = Name;
}



public class CreateStudentCommand : IRequest<Student>
{
  public string? Name { get; set; }

}

public interface IStudentsService
{
  Task<Student> Create(Student student);
}


public class StudentsService(IMediator mediator) : IStudentsService
{
  public async Task<Student> Create(Student student)
  {
    CreateStudentCommand command = new(student.Name)
    {
      Name = student.Name
    };
	
    Student response = await mediator.Send(command);
    return response;
  }
}



public class CreateStudentCommandHandler(IStudentsRepository studentsRepository) : IRequestHandler<CreateStudentCommand, Student>
{
  public async Task<Student> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
  {
    var newStudent = new Student(request.Name);
    return await studentsRepository.AddAsync(newStudent, cancellationToken).ConfigureAwait(false);
  }
}






