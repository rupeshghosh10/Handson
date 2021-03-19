using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryCaseStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            var steve = new SteveObserver();
            var john = new JohnObserver();

            var noticificationService = new NotificationService();

            noticificationService.AddSubscriber(steve);
            noticificationService.AddSubscriber(john);

            noticificationService.NotifySubscriber();

            noticificationService.RemoveSubsriber(steve);
        }
    }

    #region Car realted - Product and its parent abstract class

    public enum CarType
    {
        MICRO, MINI, LUXURY
    }
    public enum Location
    {
        DEFAULT, USA, INDIA
    }

    abstract class Car
    {
        public Car(CarType model, Location location)
        {
            this.CarType = model;
            this.Location = location;
        }

        public abstract void Construct();

        public CarType CarType { get; set; }
        public Location Location { get; set; }

        public override string ToString()
        {
            return "CarModel - " + CarType.ToString() + "located in " + Location.ToString();
        }
    }

    class LuxuryCar : Car
    {
        public LuxuryCar(CarType carType, Location location)
            :base(CarType.LUXURY, location)
        {
            Construct();
        }
        public override void Construct()
        {
            Console.WriteLine("Connecting to luxury car");
            Console.WriteLine(base.ToString());
        }
    }

    class MicroCar : Car
    {
        public MicroCar(CarType carType, Location location)
            : base(CarType.MICRO, location)
        {
            Construct();
        }
        public override void Construct()
        {
            Console.WriteLine("Connecting to micro car");
            Console.WriteLine(base.ToString());
        }
    }

    class MiniCar : Car
    {
        public MiniCar(CarType carType, Location location)
            : base(CarType.MINI, location)
        {
            Construct();
        }
        public override void Construct()
        {
            Console.WriteLine("Connecting to mini car");
            Console.WriteLine(base.ToString());
        }
    }

    #endregion

    public interface INotificationObserver
    {
        string Name { get; }

        void OnServerDown();
    }

    class SteveObserver : INotificationObserver
    {
        public string Name 
        {
            get { return "Steve"; }
        }

        public void OnServerDown()
        {
            Console.WriteLine($"{Name} server down");
        }
    }

    class JohnObserver : INotificationObserver
    {
        public string Name
        {
            get { return "John"; }
        }

        public void OnServerDown()
        {
            Console.WriteLine($"{Name} server down");
        }
    }

    public interface INotificationService
    {
        void AddSubscriber(INotificationObserver observer);

        void RemoveSubsriber(INotificationObserver observer);

        void NotifySubscriber();
    }

    public class NotificationService : INotificationService
    {
        private List<INotificationObserver> _observers = new List<INotificationObserver>();

        public void AddSubscriber(INotificationObserver observer)
        {
            _observers.Add(observer);
            Console.WriteLine("observers: ");
            foreach (var ob in _observers)
            {
                Console.WriteLine(ob.Name);
            }
        }

        public void RemoveSubsriber(INotificationObserver observer)
        {
            _observers.Remove(observer);
            Console.WriteLine("observers: ");
            foreach (var ob in _observers)
            {
                Console.WriteLine(ob.Name);
            }
        }

        public void NotifySubscriber()
        {
            foreach (var ob in _observers)
            {
                ob.OnServerDown();
            }
        }
    }
}
