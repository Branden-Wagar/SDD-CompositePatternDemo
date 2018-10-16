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


            EngineCar.Add(PassengerCar);
            EngineCar.Add(Kaboose);
            EngineCar.Whistle();
            /* RESULTS:
             * CHOO CHOO 
             * ALL ABOARD!
             * Chugga Chugga!
            */

            Console.WriteLine("\n");
            EngineCar.Add(new PassengerCar());
            EngineCar.Add(new PassengerCar());
            EngineCar.EmergencyBrake();
            /* RESULTS:
             * Apply E-Brake!
             * Apply E-Brake!
             * Apply E-Brake!
             * Apply E-Brake!
             * Apply E-Brake!
            */

            Console.WriteLine("\n\n");
            EngineCar = new EngineCar();

            PassengerCar.Add(Kaboose);
            EngineCar.Add(PassengerCar);
            EngineCar.Whistle();
            /* RESULTS:
             * CHOO CHOO
             * ALL ABOARD!
             * 
             * Note that the Kaboose does not 'Chugga Chugga!'
             * because it was added to a leaf node, which did not throw an exception
            */

            Kaboose.Add(PassengerCar);
            /* RESULTS:
             * Exception is thrown from Kaboose, it is a leaf node
             * 
            */

        }
    }


    /// <summary>
    /// Component Interface for our Train
    /// </summary>
    public interface Train {
        void Whistle();
        bool Forward();
        void EmergencyBrake();
        void Brakes();
        void Add(Train t); // can handle all objects 
        void Remove(Train t); // which implement this interface
        Train GetChild(int i);
    }

    /// <summary>
    /// Composite class which implements our Train interface
    /// </summary>
    public class EngineCar : Train{
        
        private List<Train> _children; // holds all children of this Composite


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

        /// <summary>
        /// Our add/remove/get functions all handle any object
        /// that implements Train
        /// </summary>
        /// <returns>The add.</returns>
        /// <param name="t">T.</param>
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

    /// <summary>
    /// This is a leaf node of our Component Structure
    /// Returns null/ just returns on child operations
    /// </summary>
    public class PassengerCar : Train
    {

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

        public void Add(Train t)
        {
            return; // we can't add children to a leaf
        }

        public Train GetChild(int i)
        {
            return null; // leaves have no children so we can return null
        }

        public void Remove(Train t)
        {
            return; // nor remove what we don't have
        }

        public void Whistle()
        {
            Console.WriteLine("ALL ABOARD!");
        }
    }

    /// <summary>
    /// This is another leaf of our Component Structure
    /// Throws exceptions on child operations
    /// </summary>
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
