using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteLogica1
{
    internal class Network
    {
        private int numbersOfElements;

        private int[,] connnections;
    

        public Network(int num)
        {
                if (num < 1) throw new ArgumentException("The value can´t be less then one");

                numbersOfElements = num;
                connnections = new int[num + 1, num + 1];       
        }

        public void Connect(int num1, int num2)
        {
            if (num1 < 1 || num2 < 1) throw new ArgumentException("The value can´t be less then one");
            if (num1 == num2) throw new ArgumentException("The values can't be equal");
            if (num1 > numbersOfElements || num2 > numbersOfElements) throw new ArgumentOutOfRangeException();

            connnections[num1, num2] = num2;


            for (int i = 1; i <= numbersOfElements; i++)
            {
                if (connnections[i, num1] == num1)
                {
                    connnections[i, num2] = num2;
                    connnections[num2, i] = i;
                }
                if (connnections[i, num2] == num2)
                {
                    connnections[i, num1] = num1;
                    connnections[num1, i] = i;
                }
            }

            connnections[num2, num1] = num1;
        }

        public bool Query(int num1, int num2)
        {
            if (num1 < 1 || num2 < 1) throw new ArgumentException("The value can´t be less then one");
            if (num1 == num2) throw new ArgumentException("The values can't be equal");
            if (num1 > numbersOfElements || num2 > numbersOfElements) throw new ArgumentOutOfRangeException();

            if (connnections[num1, num2] == num2)
            {
                return true;
            }
            return false;
        }
    }
}
