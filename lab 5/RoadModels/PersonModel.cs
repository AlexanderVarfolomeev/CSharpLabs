using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Models
{
    public abstract class PersonModel : Model
    {
        protected float defaultX, defaultY;

        public float ToX { get; internal set; }
        public float ToY { get; internal set; }

        public PersonModel(Action<string> Notification, float defaultX, float defaultY)
            : base(Notification)
        {
            this.defaultX = defaultX;
            this.defaultY = defaultY;

            X = defaultX;
            Y = defaultY;

            ToX = defaultX;
            ToY = defaultY;

            DoSomething = null;
        }

        public string LastName { get; set; }
        public string FirstName { get; set; }

        const float maxSpeed = 3;

        protected Action DoSomething;

        protected abstract void CheckEvents();

        public bool IsCome()
        {
            return Math.Abs(X - ToX) < 5 && Math.Abs(Y - ToY) < 5;
        }

        public void Go()
        {
            if (IsCome())
                return;


            if (X - ToX != 0)
            {
                Y += maxSpeed * (ToY - Y) / Math.Abs(X - ToX);
                X += maxSpeed * Math.Sign(ToX - X);
            }
            else
            {
                X += maxSpeed * (ToX - X) / Math.Abs(Y - ToY);
                Y += maxSpeed * Math.Sign(Y - ToY);
            }
        }

        public override void Start()
        {
            while (!IsCanceled)
            {

                CheckEvents();
                Go();

                DoSomething?.Invoke();

                Task.Delay(30).Wait();
            }
        }
    }
}
