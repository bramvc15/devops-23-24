namespace Domain.Tests;

public class FaqTest
{
    #region Fields
    private readonly Faq _faq;
    #endregion

    #region Init
    public FaqTest()
    {
        _faq = new Faq("question!", "answer!!");
    }
    #endregion

    #region Constructor tests
    [Fact]
    public void Faq_Constructor_ValidParameters()
    {
        new Faq("question!", "answer!!");
    }

    [Fact]
    public void Faq_Constructor_EmptyQuestion_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new Faq("", "answer!!"));
    }

    [Fact]
    public void Faq_Constructor_EmptyAnswer_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new Faq("question!", ""));
    }
    #endregion

    #region Method tests
    [Fact]
    public void Faq_UpdateFaq()
    {
        _faq.UpdateFaq("new", "new2");
        Assert.Equal(_faq.Question, "new");
        Assert.Equal(_faq.Answer, "new2");
    }
    #endregion
}