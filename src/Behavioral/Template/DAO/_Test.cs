namespace Patterns.Behavioral.Template.DAO;

public class Test
{
    
    [Fact]
    public void Template_DAO()
    {
        DataAccessObject daoCategories = new Postgres();
        daoCategories.Run();

        DataAccessObject daoProducts = new MSSQL();
        daoProducts.Run();
    }
}