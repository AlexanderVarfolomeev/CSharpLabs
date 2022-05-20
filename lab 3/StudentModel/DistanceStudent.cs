namespace StudentModel;

public class DistanceStudent : Student
{
    public int NumberOfLectures { get; set; }
    public int Course { get; set; }

    public string GetMind()
    {
        if (Mind > 20)
            return "Студент отлично разбирается в материале.";
        else if (Mind > 10)
            return "Студент понимает материал.";
        else
            return "Претендент на отчисление.";
    }

    public override string ToString()
    {
        return $"Имя: {Name}, Вуз: {University}, Факультет: {Faculty}, Количество лекций: {NumberOfLectures}, Курс: {Course}";
    }

    public override void GoToLesson()
    {
        Mind += 3;
    }
}