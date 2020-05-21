﻿using System;

namespace Task01
{
    class MobileProgram
    {
        static void Main(string[] args)
        {
            Mobile jimMobile = new Mobile("Monthly", "Samsung Galaxy S6", "07712223344");

            Console.WriteLine("Account type: " + jimMobile.getAccType() + "\nMobile Number: " + jimMobile.getNumber()
            + "\nDevice: " + jimMobile.getDevice() + "\nBalance: " + jimMobile.getBalance());

            jimMobile.setAccType("PAYG");
            jimMobile.setDevice("iPhone 6S");
            jimMobile.setNumber("07713334466");
            jimMobile.setBalance(15.50);

            Console.WriteLine();
            Console.WriteLine("Account type: " + jimMobile.getAccType() + "\nMobile Number: " + jimMobile.getNumber()
            + "\nDevice: " + jimMobile.getDevice() + "\nBalance: " + jimMobile.getBalance());

            Console.WriteLine();
            jimMobile.addCredit(10.0);
            jimMobile.makeCall(5);
            jimMobile.sendText(2);
            Console.ReadLine();
        }
    }
    class Mobile
    {
        // Instance variables
        private String accType, device, number;
        private double balance;

        // VARIABLES
        private const double CALL_COST = 0.245;
        private const double TEXT_COST = 0.078;
        public Mobile(String accType, String device, String number)
        {
            this.accType = accType;
            this.device = device;
            this.number = number;
            this.balance = 0.0;
        }

        // Accessor Methods
        public String getAccType()
        {
            return this.accType;
        }
        public String getDevice()
        {
            return this.device;
        }
        public String getNumber()
        {
            return this.number;
        }
        public String getBalance()
        {
            // return the balance as a currency through the
            // ToString method and the parameter "C"
            return this.balance.ToString("C");
        }

        // Mutator Methods
        public void setAccType(String accType)
        {
            this.accType = accType;
        }
        public void setDevice(String device)
        {
            this.device = device;
        }
        public void setNumber(String number)
        {
            this.number = number;
        }
        public void setBalance(Double balance)
        {
            this.balance = balance;
        }

        // Methods
        public void addCredit(double amount)
        {
            this.balance += amount;
            Console.WriteLine("Credit added successfully. New balance: " + getBalance());
        }
        public void makeCall(int minutes)
        {
            double cost = minutes * CALL_COST;
            this.balance -= cost;
            Console.WriteLine("Call made. New balance: " + getBalance());
        }
        public void sendText(int numTexts)
        {
            double cost = numTexts * TEXT_COST;
            this.balance -= cost;
            Console.WriteLine("Text sent. New balance: " + getBalance());
        }
    }
}
