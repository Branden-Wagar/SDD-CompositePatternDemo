using System;
using System.Collections.Generic;

namespace CompositeDemo
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Train EngineCar = new EngineCar();
            Train PassengerCar = new PassengerCar();
            Train Kaboose = new Kaboose();

            PassengerCar.Add(Kaboose);
            EngineCar.Add(PassengerCar);
            EngineCar.Whistle();

            Console.WriteLine("\n\n");

            EngineCar = new EngineCar();
            EngineCar.Add(PassengerCar);
            EngineCar.Add(Kaboose);
            EngineCar.Whistle();
            Console.WriteLine("\n");
            EngineCar.Add(new PassengerCar());
            EngineCar.Add(new PassengerCar());
            EngineCar.EmergencyBrake();
        }
    }



    public interface Train {
        void Whistle();
        bool Forward();
        void EmergencyBrake();
        void Brakes();
        void Add(Train t);
        void Remove(Train t);
        Train GetChild(int i);
    }


    public class EngineCar : Train{
        private List<Train> _children;
        public EngineCar(){
            _children = new List<Train>();
        }
        public void Whistle(){
            Console.WriteLine("CHOO CHOO");
            foreach (var c in _children){
                c.Whistle();
            }
        }
        public bool Forward(){
            foreach(var c in _children){
                c.Forward();
            }
            return true;
        }
        public void EmergencyBrake(){
            foreach(var c in _children){
                c.EmergencyBrake();
            }
            Console.WriteLine("Apply E-Brake!");
        }
        public void Brakes(){
            foreach(var c in _children){
                c.Brakes(); 
            }
            Console.WriteLine("Applying Brakes...");
        }

        public void Add(Train t){
            _children.Add(t);
        }

        public void Remove(Train t){
            _children.Remove(t);
        }

        public Train GetChild(int i){
            return _children[i];
        }
    }

    public class PassengerCar : Train
    {
        public void Add(Train t)
        {
            return;
        }

        public void Brakes()
        {
            Console.WriteLine("Applying Brakes...");
        }

        public void EmergencyBrake()
        {
            Console.WriteLine("Apply E-Brake!");
        }

        public bool Forward()
        {
            return false;
        }

        public Train GetChild(int i)
        {
            return null;
        }

        public void Remove(Train t)
        {
            return;
        }

        public void Whistle()
        {
            Console.WriteLine("ALL ABOARD!");
        }
    }

    public class Kaboose : Train
    {
        public void Add(Train t)
        {
            throw new NotImplementedException();
        }

        public void Brakes()
        {
            Console.WriteLine("Applying brakes...");
        }

        public void EmergencyBrake()
        {
            Console.WriteLine("Apply E-Brake!");
        }

        public bool Forward()
        {
            return false;
        }

        public Train GetChild(int i)
        {
            throw new NotImplementedException();
        }

        public void Remove(Train t)
        {
            throw new NotImplementedException();
        }

        public void Whistle()
        {
            Console.WriteLine("Chugga Chugga!");
        }
    }


}
