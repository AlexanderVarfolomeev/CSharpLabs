namespace StudentModel;

public abstract class Student : IEnrollee
{
    [Label("Имя")]
    public string Name { get; set; } = string.Empty;
    [Label("Универ")]
    public string University { get; set; } = string.Empty;
    [Label("Факультет")]
    public string Faculty { get; set; } = string.Empty;
    [Label("Ум")]
    public int Mind { get; set; }

    public abstract void GoToLesson();

    [Label("Пропустить лекцию")]
    public void SkipLesson(int count)
    {
        Mind -= count;
    }

    [Label("Учиться")]
    public void ToStudy()
    {
        Mind++;
    }
    [Label("Прочесть книгу")]
    public void ToReadBook()
    {
        Mind += 2;
    }
}