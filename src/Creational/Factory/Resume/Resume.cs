namespace Patterns.Creational.Factory.Resume;

internal class Resume : Document
{
    public override void CreatePages()
    {
        Pages.Add(new SkillsPage());
        Pages.Add(new EducationPage());
        Pages.Add(new ExperiencePage());
    }
}