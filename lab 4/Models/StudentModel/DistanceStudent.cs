namespace StudentModel;

[Label("Студент заочной формы обучения")]
public class DistanceStudent : Student
{
    [Label("Количество лекций")]
    public int NumberOfLectures { get; set; }
    [Label("Курс")]
    public int Course { get; set; }

    [Label("Узнать успехи в учебе")]
    public string GetMind()
    {
        if (Mind > 20)
            return "Студент отлично разбирается в материале.";
        else if (Mind > 10)
            return "Студент понимает материал.";
        else
            return "Претендент на отчисление.";
    }

    [Label("Получить краткий отчет")]
    public override string ToString()
    {
        return $"Имя: {Name}, Форма обучения: заочная, Вуз: {University},\nФакультет: {Faculty}, Количество лекций: {NumberOfLectures}, Курс: {Course}";
    }

    [Label("Пойти на лекцию")]
    public override void GoToLesson()
    {
        Mind += 3;
    }
}