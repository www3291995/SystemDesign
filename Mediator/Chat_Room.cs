using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Mediator
{
    class Chat_Room
    {
        //static void Main(string[] args)
        //{
        //    var room = new ChatRoom();

        //    var john = new Person("john");
        //    var jane = new Person("jane");

        //    room.Join(john);
        //    room.Join(jane);

        //    john.Say("hi");
        //    jane.Say("oh, hey");

        //    var simon = new Person("simon");
        //    room.Join(simon);
        //    simon.Say("hi everyone");

        //    jane.PrivateMessage("simon", "glad to join us");

        //    // ------------------------------------
        //    ReadLine();
        //}
    }

    public class Person
    {
        public string Name;
        public ChatRoom Room;
        private readonly List<string> chatLog = new List<string>();

        public Person(string name)
        {
            Name = name;
        }

        public void Say(string message)
        {
            Room.Broadcast(Name, message);
        }

        public void PrivateMessage(string who, string message)
        {
            Room.Message(Name, who, message);
        }

        public void Receive(string sender, string message)
        {
            string s = $"{sender}: '{message}'";
            chatLog.Add(s);
            Console.WriteLine($"[{Name}'s chat session] {s}");
        }
    }

    public class ChatRoom
    {
        private readonly List<Person> people = new List<Person>();

        public void Join(Person p)
        {
            string joinMsg = $"{p.Name} joins the chat";
            Broadcast("room", joinMsg);

            p.Room = this;
            people.Add(p);
        }

        public void Broadcast(string source, string message)
        {
            foreach (var p in people)
            {
                if (p.Name != source)
                {
                    p.Receive(source, message);
                }
            }
        }

        public void Message(string source, string destination, string message)
        {
            people.FirstOrDefault(p => p.Name == destination)?.Receive(source, message);
        }
    }
}
