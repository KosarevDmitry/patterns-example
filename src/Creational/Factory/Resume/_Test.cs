namespace Patterns.Creational.Factory.Resume;

public class _Test
{
    [Fact]
    public void Factory_Resume()
    {
        var documents = new Document[] { new Resume(), new Report() };
        foreach (Document document in documents)
        {
            foreach (Page page in document.Pages)
            {
            }
        }
    }
}