using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentModel
{
    [Label("Студент очной формы обучения")]
    internal class OfflineStudent : Student
    {
        [Label("Семестр")]
        public int Semester { get; set; }
        [Label("Узнать курс")]
        public int Course()
        {
            if (Semester == 1 || Semester == 2)
                return 1;
            else if (Semester == 3 || Semester == 4)
                return 2;
            else if (Semester == 5 || Semester == 6)
                return 3;
            else 
                return 4;
        }
        [Label("Посетить практику")]
        public override void GoToLesson()
        {
            Mind++;
        }
        [Label("Узнать краткую информацию")]
        public override string ToString()
        {
            return $"Имя: {Name}, Форма обучения: Очная, Вуз: {University}, Факультет: {Faculty}";
        }
    }
}
