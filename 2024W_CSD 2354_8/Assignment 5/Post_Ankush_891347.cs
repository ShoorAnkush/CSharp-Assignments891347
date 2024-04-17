using System;
using System.Collections.Generic;

namespace Post
{
    // Base class for different types of mail
    public abstract class Mail
    {
        protected double weight;
        protected bool express;
        protected string destination;

        public Mail(double weight, bool express, string destination)
        {
            this.weight = weight;
            this.express = express;
            this.destination = destination;
        }

        public abstract double CalculatePostage();

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(destination);
        }

        public abstract string Display();
    }

    // Concrete class representing a letter
    public class Lettre : Mail
    {
        private string format;

        public Lettre(double weight, bool express, string destination, string format)
            : base(weight, express, destination)
        {
            this.format = format;
        }

        public override double CalculatePostage()
        {
            double baseFare = format == "A3" ? 3.50 : 2.50;
            double amount = express ? 2 * (baseFare + 1.0 * weight / 1000) : baseFare + 1.0 * weight / 1000;
            return amount;
        }

        public override string Display()
        {
            string validity = IsValid() ? "" : "(Invalid courier)";
            double postage = IsValid() ? CalculatePostage() : 0.0;
            string expressStr = express ? "yes" : "no";
            return $"Letter\nWeight: {weight} grams\nExpress: {expressStr}\nDestination: {destination}\nPrice: ${postage}\nFormat: {format}\n{validity}";
        }
    }

    // Concrete class representing an advertisement
    public class Advertisement : Mail
    {
        public Advertisement(double weight, bool express, string destination)
            : base(weight, express, destination)
        {
        }

        public override double CalculatePostage()
        {
            double amount = express ? 2 * (5.0 * weight / 1000) : 5.0 * weight / 1000;
            return amount;
        }

        public override string Display()
        {
            string validity = IsValid() ? "" : "(Invalid courier)";
            double postage = IsValid() ? CalculatePostage() : 0.0;
            string expressStr = express ? "yes" : "no";
            return $"Advertisement\nWeight: {weight} grams\nExpress: {expressStr}\nDestination: {destination}\nPrice: ${postage}\n{validity}";
        }
    }

    // Concrete class representing a parcel
    public class Parcel : Mail
    {
        private double volume;

        public Parcel(double weight, bool express, string destination, double volume)
            : base(weight, express, destination)
        {
            this.volume = volume;
        }

        public override double CalculatePostage()
        {
            double amount = express ? 2 * (0.25 * volume + weight / 1000) : 0.25 * volume + weight / 1000;
            return amount;
        }

        public override string Display()
        {
            string validity = IsValid() ? "" : "(Invalid courier)";
            double postage = IsValid() ? CalculatePostage() : 0.0;
            string expressStr = express ? "yes" : "no";
            return $"Parcel\nWeight: {weight} grams\nExpress: {expressStr}\nDestination: {destination}\nPrice: ${postage}\nVolume: {volume} liters\n{validity}";
        }
    }

    // Class representing a mailbox
    public class Box
    {
        private List<Mail> mails;
        private double maxCapacity;

        public Box(double maxCapacity)
        {
            mails = new List<Mail>();
            this.maxCapacity = maxCapacity;
        }

        public void addMail(Mail mail)
        {
            if (mails.Count < maxCapacity)
                mails.Add(mail);
            else
                Console.WriteLine("Mailbox is full.");
        }

        public double stamp()
        {
            double totalPostage = 0.0;
            foreach (Mail mail in mails)
            {
                totalPostage += mail.IsValid() ? mail.CalculatePostage() : 0.0;
            }
            return totalPostage;
        }

        public int mailIsInvalid()
        {
            int invalidCount = 0;
            foreach (Mail mail in mails)
            {
                if (!mail.IsValid())
                    invalidCount++;
            }
            return invalidCount;
        }

        public void display()
        {
            foreach (Mail mail in mails)
            {
                Console.WriteLine(mail.Display());
            }
        }
    }

    // Main class to run the program
    public class Post
    {
        public static void Main(string[] args)
        {
            // Creation of a mailbox 
            // The maximum size of a box is 30
            Box box = new Box(30);

            Lettre lettre1 = new Lettre(200, true, "Chemin des Acacias 28, 1009 Pully", "A3");
            Lettre lettre2 = new Lettre(800, false, "", "A4"); // invalid

            Advertisement adv1 = new Advertisement(1500, true, "Les Moilles  13A, 1913 Saillon");
            Advertisement adv2 = new Advertisement(3000, false, ""); // invalid

            Parcel parcel1 = new Parcel(5000, true, "Grand rue 18, 1950 Sion", 30);
            Parcel parcel2 = new Parcel(3000, true, "Chemin des fleurs 48, 2800 Delemont", 70); // invalid parcel
		
            box.addMail(lettre1);
            box.addMail(lettre2);
            box.addMail(adv1);
            box.addMail(adv2);
            box.addMail(parcel1);
            box.addMail(parcel2);	
		

		    Console.WriteLine("The total amount of postage is " +
		                      box.stamp());
		    box.display();
		
            Console.WriteLine("The box contains " + box.mailIsInvalid() + " invalid mails");
        }
    }
}
