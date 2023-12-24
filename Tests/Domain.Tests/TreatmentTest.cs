namespace Domain.Tests;

public class TreatmentTest
{
    #region Fields
    private readonly Treatment _treatment;
    #endregion

    #region Init
    public TreatmentTest()
    {
        _treatment = new Treatment("name", "description", "link");
    }
    #endregion

    #region Constructor tests
    [Fact]
    public void Treatment_Constructor_ValidParameters()
    {
        new Treatment("name", "description", "link");
    }

    [Fact]
    public void Treatment_Constructor_EmptyName_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new Treatment("", "description", "link"));
    }

    [Fact]
    public void Treatment_Constructor_EmptyDescription_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new Treatment("name", "", "link"));
    }

    [Fact]
    public void Treatment_Constructor_EmptyImageLink_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new Treatment("name", "description", ""));
    }
    #endregion

    #region Method tests
    [Fact]
    public void Treatment_UpdateTreatment()
    {
        _treatment.UpdateTreatment("new", "new2", "new3");
        Assert.Equal(_treatment.Name, "new");
        Assert.Equal(_treatment.Description, "new2");
        Assert.Equal(_treatment.ImageLink, "new3");
    }
    #endregion
}