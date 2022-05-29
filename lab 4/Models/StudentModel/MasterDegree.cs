using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentModel
{
    [Label("Магистр")]
    internal class MasterDegree : Student
    {
        [Label("Возраст")]
        public int Age { get; set; }

        [Label("Установить возраст")]
        public void SetAge(int age)
        {
            Age = age;
        }

        [Label("Посетить пару")]
        public override void GoToLesson()
        {
            Mind += 4;
        }
        [Label("Узнать краткий отчет")]
        public override string ToString()
        {
            return $"Имя: {Name}, Универ: {University}";
        }
        [Label("Узнать ум студента")]
        public string GetMind()
        {
            return Mind > 40 ? "Студент умный" : "Студент глупый";
        }
    }
}
