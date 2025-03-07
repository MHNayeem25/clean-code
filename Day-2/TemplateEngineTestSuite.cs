namespace TemplateEngine.Tests;

public class TemplateEngineTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ShouldEvaluateForSingleVariable()
    {
        //Arange

        TemplateEngine templateEngine = new TemplateEngine();
        templateEngine.setTemplate("Hello {name}");
        templateEngine.setVariables("name", "Nm");

        //Act
        string result = templateEngine.Evaluate();

        //Assert
        Assert.That("Hello NM", Is.EqualTo(result));
    }
}