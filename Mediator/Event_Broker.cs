using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace DesignPattern.Mediator
{
    class Event_Broker
    {
        //static void Main(string[] args)
        //{
        //    var cb = new ContainerBuilder();
        //    cb.RegisterType<EventBroker>().SingleInstance();
        //    cb.RegisterType<FootballCoach>();
        //    cb.Register((c, p) => new FootballPlayer(
        //        c.Resolve<EventBroker>(),
        //        p.Named<string>("name")
        //    ));

        //    using (var c = cb.Build())
        //    {
        //        var coach = c.Resolve<FootballCoach>();
        //        var player1 = c.Resolve<FootballPlayer>(new NamedParameter("name", "John"));
        //        var player2 = c.Resolve<FootballPlayer>(new NamedParameter("name", "Chris"));

        //        player1.Score();
        //        player1.Score();
        //        player1.Score(); // x
        //        player1.AssaultReferee();

        //        player2.Score();

        //    }

        //    // ------------------------------------
        //    ReadLine();
        //}
    }

    public class Actor
    {
        protected EventBroker broker;

        public Actor(EventBroker broker)
        {
            this.broker = broker;
        }
    }

    public class FootballPlayer : Actor
    {
        public string Name { get; set; }
        public int GoalsScored { get; set; } = 0;

        public FootballPlayer(EventBroker broker, string name) : base(broker)
        {
            Name = name;

            broker.OfType<PlayerScoredEvent>().Where(ps => !ps.Name.Equals(name)).Subscribe(
                ps => Console.WriteLine($"{name}: nicely done, {ps.Name}! It's your {ps.GoalsScored} goal.")
            );

            broker.OfType<PlayerSentOffEvent>().Where(ps => !ps.Name.Equals(name)).Subscribe(
                ps => Console.WriteLine($"{name}: see you in the lockers, {ps.Name}")
            );
        }

        public void Score()
        {
            GoalsScored++;
            broker.Publish(new PlayerScoredEvent
            {
                Name = Name,
                GoalsScored = GoalsScored
            });
        }

        public void AssaultReferee()
        {
            broker.Publish(new PlayerSentOffEvent
            {
                Name = Name,
                Reason = "violence"
            });
        }
    }

    public class FootballCoach : Actor
    {
        public FootballCoach(EventBroker broker) : base(broker)
        {
            broker.OfType<PlayerScoredEvent>().Subscribe(pe =>
            {
                if (pe.GoalsScored < 3)
                    Console.WriteLine($"Coach: well done, {pe.Name}!");
            });

            broker.OfType<PlayerSentOffEvent>().Subscribe(pe =>
            {
                if (pe.Reason == "violence")
                {
                    Console.WriteLine($"Coach: how could you, {pe.Name}.");
                }
            });
        }
    }

    public class PlayerEvent
    {
        public string Name { get; set; }
    }

    public class PlayerScoredEvent : PlayerEvent
    {
        public int GoalsScored { get; set; }
    }

    public class PlayerSentOffEvent : PlayerEvent
    {
        public string Reason { get; set; }
    }

    public class EventBroker : IObservable<PlayerEvent>
    {
        private Subject<PlayerEvent> subscriptions = new Subject<PlayerEvent>();

        public IDisposable Subscribe(IObserver<PlayerEvent> observer)
        {
            return subscriptions.Subscribe(observer);
        }

        public void Publish(PlayerEvent pe)
        {
            subscriptions.OnNext(pe);
        }
    }
}
