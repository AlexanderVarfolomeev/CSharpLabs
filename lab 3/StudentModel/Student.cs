namespace StudentModel;

public abstract class Student : IEnrollee
{
    public string Name { get; set; } = string.Empty;
    public string University { get; set; } = string.Empty;
    public string Faculty { get; set; } = string.Empty;
    public int Mind { get; set; }

    public abstract void GoToLesson();

    public void SkipLesson()
    {
        Mind--;
    }

    public void ToStudy()
    {
        Mind++;
    }

    public void ToReadBook()
    {
        Mind += 2;
    }
}