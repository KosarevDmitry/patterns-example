{
  "ConnectionStrings": {
    "DefaultConnection": "DataSource=./Data/Students.db;Cache=Shared"
  },
}

  <ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="8.0.10" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.10">
  </ItemGroup>
  <ItemGroup>
    <Folder Include="Migrations\" />
  </ItemGroup>


builder.Services.AddDbContext<DataContext>(options =>
{
  var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
  options.UseSqlite(connectionString, opt =>
  {
    opt.CommandTimeout((int)TimeSpan.FromSeconds(60).TotalSeconds);
  });
});


builder.Services.AddTransient<IStudentRepository, StudentRepository>();



public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        
}



public class BaseRepository<TEntity, TDbContext> : IBaseRepository<TEntity>
    where TEntity : class
    where TDbContext : DbContext
{
    protected readonly TDbContext DatabaseContext;
    protected readonly DbSet<TEntity> DatabaseSet;

    public BaseRepository(TDbContext? dbContext)
    {
        DatabaseContext = dbContext ?? throw new ArgumentException("DbContext is null", nameof(dbContext));
        DatabaseSet = DatabaseContext.Set<TEntity>();
    }

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await DatabaseSet.AddAsync(entity, cancellationToken).ConfigureAwait(false);
        await DatabaseContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return entity;
    }
	
}


public interface IStudentRepository : IBaseRepository<Student>
{
    Task<IList<Student>> AddMultipleAsync(IList<Student> models, CancellationToken cancellationToken = default);
}


public class StudentRepository : BaseRepository<Student, DataContext>, IStudentRepository
{

    public StudentRepository(DataContext? dbContext)
        : base(dbContext)
    {
    }

    public async Task<Student> AddAsync(Student student, CancellationToken cancellationToken = default)
    {
        @Student result = await AddAsync(student, cancellationToken).ConfigureAwait(false);
        return result;
    }
	
	
	  Task<IList<Student>> AddMultipleAsync(IList<Student> students, CancellationToken cancellationToken = default)
	  {
		  List<Student> students = new();
		  
		  foreach (Student student in students)
		  {
			Student result = await AddAsync(student, cancellationToken).ConfigureAwait(false);
			students.Add(result);
			Console.WriteLine();
		  }
		  
		  return students;
	  }
	
}
