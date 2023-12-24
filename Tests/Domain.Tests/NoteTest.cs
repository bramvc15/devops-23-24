namespace Domain.Tests;

public class NoteTest
{
    #region Fields
    private readonly Note _note;
    #endregion

    #region Init
    public NoteTest()
    {
        _note = new Note("question!", "answer!!");
    }
    #endregion

    #region Constructor tests
    [Fact]
    public void Note_Constructor_ValidParameters()
    {
        new Note("question!", "answer!!");
    }

    [Fact]
    public void Note_Constructor_EmptyTitle_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new Note("", "answer!!"));
    }

    [Fact]
    public void Note_Constructor_EmptyContext_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new Note("question!", ""));
    }
    #endregion

    #region Method tests
    [Fact]
    public void Note_UpdateNote()
    {
        _note.UpdateNote("new", "new2");
        Assert.Equal(_note.Title, "new");
        Assert.Equal(_note.Content, "new2");
    }
    #endregion
}