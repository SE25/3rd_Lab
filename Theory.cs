using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

namespace _3rd_Lab
{
    class Theory
    {
        static void Main(string[] args)
        {

            //Level1();
            //Level2();
            //Level3();
            //BinarySearch();
            MixingArrays1();
            //MixingArrays2();
            //Inverting();
            //LoopShifting();


        }
        static void Level1()
        {
            #region ex.6
            int[] listOfCoordinates = new int[] { 5, -6, 12, 7, 3 };
            int sumOfCoordsInPow2 = 0;
            double lengthOfVector;
            for (int i = 0; i <= listOfCoordinates.Length - 1; i++)
            {
                sumOfCoordsInPow2 += listOfCoordinates[i] * listOfCoordinates[i];

            }
            lengthOfVector = Math.Sqrt(sumOfCoordsInPow2);
            Console.WriteLine($"Lvl_1 || ex.6: {lengthOfVector}");
            #endregion

            #region ex.10
            int p = 4;
            int q = 25;
            int k = 0;
            int[] listOfNums = new int[] { 6, 7, 5, 12, 37, 26, 9, 16, 15, 20 };
            foreach (int i in listOfNums)
            {
                if (i > p && i < q) k++;
            }
            Console.WriteLine($"Lvl_1 || ex.10:{k}");
            #endregion

            #region ex.11
            int[] nums = new int[] { -10, 12, 3, 4, 5, -19, -1000, 2, -5, 7 };
            List<int> list = new List<int>();
            foreach (int i in nums)
            {
                if (i > 0) list.Add(i);

            }
            foreach (int i in list)
            {
                Console.WriteLine($"Lvl_1 || ex.11:{i}");
            }
            #endregion

            #region ex.12
            List<int> ints = new List<int>() { 5, 4, -2, 3, 5, -9, 9, 0 };
            int negativeNum = 0;
            int positionInList = 0;
            foreach (int i in ints)
            {
                if (i < 0)
                {
                    negativeNum = i;
                    positionInList = ints.IndexOf(negativeNum);
                }
            }
            Console.WriteLine($"Lvl_1 || ex.12: number: {negativeNum} position: {positionInList + 1}");
            #endregion

            #region ex.13
            List<int> ints1 = new List<int>() { 10, 5, 15, 17, 4, 8, 10, 3, 9, 44 };
            List<int> evenInts = new List<int>();
            List<int> oddInts = new List<int>();
            foreach (int i in ints1)
            {
                if (i % 2 == 0)
                {
                    evenInts.Add(i);
                }
                else
                {
                    oddInts.Add(i);
                }
            }
            foreach (int i in evenInts)
            {
                Console.WriteLine($"Lvl_1 || ex.13: Evens: {i}");
            }
            foreach (int i in oddInts)
            {
                Console.WriteLine($"Lvl_1 || ex.13: Odds: {i}");
            }
            #endregion
        }

        static void Level2()
        {
            //fixed try-catch here
            #region ex.5 (fixed)
            int numOfElements = 0;
            List<int> ints = new List<int>();
            List<int> negativeInts = new List<int>();
            List<int> positiveInts = new List<int>();
            List<int> finalList = new List<int>();
            try
            {
                Console.Write("Enter the number of elements of an array: ");
                numOfElements = int.Parse(Console.ReadLine());
                if (numOfElements > 0)
                {
                    Console.WriteLine("Fill the array with integers: ");
                    for (int i = 0; i < numOfElements; i++)
                    {
                        int numbers = int.Parse(Console.ReadLine());
                        ints.Add(numbers);
                    }
                }
                else Console.WriteLine("List's range can't be negative");
            }
            catch (Exception)
            {
                Console.WriteLine("Program supports only integers!");
            }
            //filling lists with positive and negative integers
            foreach (int i in ints)
            {
                if (i > 0) positiveInts.Add(i);
                else negativeInts.Add(i);
            }
            //searching for max and min ints among positive integers(check Algorithms region to see the code of Max() and Min() methods)
            if (positiveInts.Count > 0 && negativeInts.Count > 0)
            {
                int maxPositiveInt = MaxForLists(positiveInts);
                int minPositiveInt = MinForLists(positiveInts);
                //firstly adding the min int to the list, then adding negative ones and finally max int
                finalList.Add(minPositiveInt);
                foreach (int i in negativeInts)
                {
                    finalList.Add(i);
                }
                finalList.Add(maxPositiveInt);
                //printing the answer
                Console.Write("Lvl_2 || ex.5: ");
                foreach (int i in finalList)
                {
                    Console.Write(i + "; ");
                }
                Console.WriteLine();
            }
            else Console.WriteLine("List of positive/negative nums is empty");


            #endregion

            #region ex.6 (fixed)
            int n = 0;
            List<int> array = new List<int>();
            int numberP = 0;
            //filling the list with numbers and getting P number
            try
            {
                Console.Write("Enter the number of elements in an array:");
                n = int.Parse(Console.ReadLine());
                if (n > 0)
                {
                    Console.WriteLine("Fill the array with nums: ");
                    for (int i = 0; i < n; i++)
                    {
                        int element = int.Parse(Console.ReadLine());
                        array.Add(element);
                    }
                    Console.Write("Enter the P number: ");
                    numberP = int.Parse(Console.ReadLine());
                }
                else Console.WriteLine("List's range can't be negative");
            }
            catch (Exception)
            {
                Console.WriteLine("Program supports only integers!");
            }
            if (n > 0)
            {
                //counting the average value of the list
                double sum = 0;
                foreach (double i in array)
                {
                    sum += i;
                }
                double sr = sum / array.Count;
                //searching for the nearest element to the average value of the list
                double min = Math.Abs(sr - array[0]);
                int index = 0;
                for (int i = 0; i < n; i++)
                {
                    double difference = Math.Abs(sr - array[i]);
                    if (difference < min)
                    {
                        min = difference;
                        index = i;
                    }
                }
                //adding P number after the found element
                array.Insert(index + 1, numberP);
                Console.Write("Lvl_2 || ex.6: ");
                foreach (int i in array)
                {
                    Console.Write(i + "; ");
                }
                Console.WriteLine();
            }

            #endregion

            #region ex.9 (fixed)
            int numberOfElemenets = 0;
            List<int> ints1 = new List<int>();
            int average = 0;
            try
            {
                Console.Write("Enter the number of elements in a list: ");
                numberOfElemenets = int.Parse(Console.ReadLine());
                if (numberOfElemenets > 0)
                {
                    Console.WriteLine("Fill the list with numbers: ");
                    for (int i = 0; i < numberOfElemenets; i++)
                    {
                        int element = int.Parse(Console.ReadLine());
                        ints1.Add(element);
                    }
                }
                else Console.WriteLine("The list is empty or its range is negative");
            }
            catch (Exception)
            {
                Console.WriteLine("Program supports only integers!");
            }
            if (numberOfElemenets > 0) 
            {
                int maxInt = MaxForLists(ints1);
                int minInt = MinForLists(ints1);
                int indexOfMax = ints1.IndexOf(maxInt);
                int indexOfMin = ints1.IndexOf(minInt);
                if (Compare(indexOfMin, indexOfMax))
                {
                    average = CountAverage(ints1, minInt, maxInt);
                }
                else if (Math.Abs(indexOfMax - indexOfMin) == 1) average = 0;
                else
                {
                    Swaping(ints1, minInt, maxInt);
                    average = CountAverage(ints1, minInt, maxInt);
                }

                Console.WriteLine($"Lvl_2 || ex.9: {average}");
                Console.WriteLine(); 
            }
            #endregion

            #region ex.10 (fixed)
            List<int> ints2 = new List<int>();
            List<int> posInts = new List<int>();
            int quantityOfElemenets = 0;
            try
            {
                Console.Write("Enter the number of elements in list: ");
                quantityOfElemenets = int.Parse(Console.ReadLine());
                if (quantityOfElemenets > 0)
                {
                    Console.WriteLine("Fill the list with integers: ");
                    for (int i = 0; i < quantityOfElemenets; i++)
                    {
                        int element = int.Parse(Console.ReadLine());
                        ints2.Add(element);
                    }
                }
                else Console.WriteLine("List is empty or range is a negative name");

            }
            catch (Exception)
            {
                Console.WriteLine("Program supports only integers!");
            }
            if (quantityOfElemenets > 0)
            {
                foreach (int i in ints2)
                {
                    if (i > 0) posInts.Add(i);
                }
                int minOfPositive = MinForLists(posInts);
                int indexOfMinPositive = ints2.IndexOf(minOfPositive);
                ints2.RemoveAt(indexOfMinPositive);
                Console.Write("Lvl_2 || ex.10: ");
                foreach (int i in ints2)
                {
                    Console.Write(i + "; ");
                }
                Console.WriteLine();
            }
            #endregion

            #region ex.11 (fixed)
            int figureOfElements = 0;
            int pNum1 = 0;
            List<int> ints3 = new List<int>();
            try
            {
                Console.Write("Enter the number of elements in a list: ");
                figureOfElements = int.Parse(Console.ReadLine());
                Console.Write("Enter the P number: ");
                pNum1 = int.Parse(Console.ReadLine());
                if (figureOfElements > 0)
                {
                    Console.WriteLine("Fill the list with numbers: ");
                    for (int i = 0; i < figureOfElements; i++)
                    {
                        int element = int.Parse(Console.ReadLine());
                        ints3.Add(element);
                    }
                }
                else Console.WriteLine("The list's range can't be negative or equal to 0");
            }
            catch (Exception)
            {
                Console.WriteLine("Program supports only integers!");
            }
            if (figureOfElements > 0)
            {
                int indexOfEl = 0;
                foreach (int i in ints3)
                {
                    if (i > 0) indexOfEl = ints3.IndexOf(i);
                }
                ints3.Insert(indexOfEl + 1, pNum1);
                Console.Write("Lvl_2 || ex.11: ");
                foreach (int i in ints3)
                {
                    Console.Write(i + "; ");
                }
                Console.WriteLine();
            }
            #endregion

            #region ex.13 (fixed)
            List<int> ints4 = new List<int>();
            List<int> evenIndexes = new List<int>();
            int quantityOfNums = 0;
            try
            {
                Console.Write("Enter the number of elements of list: ");
                quantityOfNums = int.Parse(Console.ReadLine());
                if (quantityOfNums > 0)
                {
                    Console.WriteLine("Fill the list with integers: ");
                    for (int i = 0; i < quantityOfNums; i++)
                    {
                        int element = int.Parse(Console.ReadLine());
                        ints4.Add(element);
                    }
                }
                else Console.WriteLine("The list is empty or it's range is negative");
            }
            catch (Exception)
            {
                Console.WriteLine("Program supports only integers!");
            }
            if (quantityOfNums > 0)
            {
                foreach (int i in ints4)
                {
                    if (ints4.IndexOf(i) % 2 == 0)
                    {
                        evenIndexes.Add(i);
                    }
                }
                int maxEvenIndexNum = MaxForLists(evenIndexes);
                int indexOfMaxEvenIndexNum = ints4.IndexOf(maxEvenIndexNum);
                ints4[indexOfMaxEvenIndexNum] = indexOfMaxEvenIndexNum;
                Console.Write("Lvl_2 || ex.13: ");
                foreach (int i in ints4)
                {
                    Console.Write(i + "; ");
                }
                Console.WriteLine();
            }
            #endregion

            #region ex.15 (fixed)
            List<int> intsA = new List<int>();
            List<int> intsB = new List<int>();
            int quantityOfNumbersA = 0;
            int quantityOfNumbersB = 0;
            int kElement = 0;
            try
            {
                Console.Write("Enter the number of elements of list A: ");
                quantityOfNumbersA = int.Parse(Console.ReadLine());
                Console.Write("Enter the number of elements of list B: ");
                quantityOfNumbersB = int.Parse(Console.ReadLine());
                if (quantityOfNumbersA > 0 || quantityOfNumbersB > 0)
                {
                    Console.WriteLine("Fill the list A with integers: ");
                    for (int i = 0; i < quantityOfNumbersA; i++)
                    {
                        int element = int.Parse(Console.ReadLine());
                        intsA.Add(element);
                    }
                    Console.WriteLine("Fill the list B with integers: ");
                    for (int i = 0; i < quantityOfNumbersB; i++)
                    {
                        int element = int.Parse(Console.ReadLine());
                        intsB.Add(element);
                    }
                    Console.WriteLine("Choose the k element of the A list: ");
                    kElement = int.Parse(Console.ReadLine()) - 1;
                }
                else Console.WriteLine("The list is empty or it's range is negative");
            }
            catch (Exception)
            {
                Console.WriteLine("Program supports only integers!");
            }
            if (quantityOfNumbersA > 0 || quantityOfNumbersB > 0)
            {
                if (kElement >= 0 || kElement <= intsA.Count - 1)
                {
                    intsA.InsertRange(kElement + 1, intsB);
                }
                else Console.WriteLine("k is out of list's range");
                Console.Write("Lvl_2 || ex.13: ");
                foreach (int i in intsA)
                {
                    Console.Write(i + "; ");
                }
                Console.WriteLine();
            }
            #endregion
        }

        static void Level3()
        {
            //fixed try-catch here
            #region ex.1 (fixed)
            List<int> ints = new List<int>();
            List<int> indexes = new List<int>();
            List<int> buffer = new List<int>();
            int quantityOfNums = 0;
            try
            {
                Console.Write("Enter the number of elements of list: ");
                quantityOfNums = int.Parse(Console.ReadLine());
                if (quantityOfNums > 0)
                {
                    Console.WriteLine("Fill the list with integers: ");
                    for (int i = 0; i < quantityOfNums; i++)
                    {
                        int element = int.Parse(Console.ReadLine());
                        ints.Add(element);
                    }
                }
                else Console.WriteLine("The list is empty or it's range is negative");
            }
            catch (Exception)
            {
                Console.WriteLine("Program supports only integers!");
            }
            if (quantityOfNums > 0)
            {
                int max = ints[0];
                int index = 0;
                foreach (int i in ints)
                {
                    if (i > max)
                    {
                        max = i;
                        indexes.Clear();
                        indexes.Add(index);
                    }
                    else if (i == max)
                    {
                        indexes.Add(index);
                    }
                    index++;
                }
                Console.Write("Lvl_3 || ex.1: ");
                foreach (int i in indexes)
                {
                    Console.Write(i + ";");
                }
                Console.WriteLine();
            }


            #endregion

            #region ex.5 (fixed)
            List<int> ints1 = new List<int>();
            List<int> ints2 = new List<int>();
            int numberOfElements = 0;
            try
            {
                Console.Write("Enter number of elements: ");
                numberOfElements = int.Parse(Console.ReadLine());
                if (numberOfElements > 0)
                {
                    Console.WriteLine("Fill the list with integers:");
                    for (int i = 0; i < numberOfElements; i++)
                    {
                        int element = int.Parse(Console.ReadLine());
                        ints1.Add(element);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Program supports only integers!");
            }
            if (numberOfElements > 0)
            {
                for (int i = 0; i < ints1.Count; i += 2)
                {
                    ints2.Add(ints1[i]);
                }
                ints2.Sort();
                for (int i = 0; i < ints1.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        ints1[i] = ints2[i / 2];
                    }
                }
                Console.Write("Lvl_3 || ex.5: ");
                foreach (int i in ints1)
                {
                    Console.Write(i + "; ");
                }
                Console.WriteLine();
            }
            #endregion

            #region ex.8 (fixed)
            List<int> ints3 = new List<int>();
            List<int> negativeInts = new List<int>();
            List<int> indexesOfNegativeNums = new List<int>();
            int numberOfElems = 0;
            try
            {
                Console.Write("Enter the number of elements: ");
                numberOfElems = int.Parse(Console.ReadLine());
                if (numberOfElems > 0)
                {
                    Console.WriteLine("Fill the list with numbers: ");
                    for (int i = 0; i < numberOfElems; i++)
                    {
                        int element = int.Parse(Console.ReadLine());
                        ints3.Add(element);
                        if (element < 0)
                        {
                            negativeInts.Add(element);
                            indexesOfNegativeNums.Add(i);
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Program supports only integers!");
            }
            if (numberOfElems > 0)
            {
                if (negativeInts.Count > 0)
                {
                    negativeInts.Sort();
                    negativeInts.Reverse();
                    for (int j = 0; j < indexesOfNegativeNums.Count; j++)
                    {
                        ints3[indexesOfNegativeNums[j]] = negativeInts[j];
                    }
                    Console.Write("Lvl_3 || ex.8: ");
                    foreach (int i in ints3)
                    {
                        Console.Write(i + "; ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("There are no negative ints in list");
                }
            }
            else Console.WriteLine("The list is empty");

            #endregion

            #region ex.9 (fixed)
            Console.Write("Enter the number of elements: ");
            bool check = int.TryParse(Console.ReadLine(), out int quantOfNums);
            int[] ints4 = new int[quantOfNums];
            int[] lengthsOfSequences = new int[quantOfNums];
            try
            {
                if (quantOfNums > 0)
                {
                    Console.WriteLine("Fill the list with numbers: ");
                    for (int i = 0; i < quantOfNums; i++)
                    {
                        int element = int.Parse(Console.ReadLine());
                        ints4[i] = element;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Program supports only integers!");
            }
            if (quantOfNums > 0)
            {
                int currentRaise = ints4[0];
                int currentDawn = ints4[0];
                int counterRaise = 1;
                int counterDawn = 1;
                for (int i = 1; i < ints4.Length; i++)
                {
                    if (ints4[i] < currentDawn)
                    {
                        counterDawn++;
                        currentDawn = ints4[i];
                    }
                    else
                    {
                        lengthsOfSequences[i] = counterDawn;
                        counterDawn = 1;
                        currentDawn = ints4[i];
                    }
                    if (ints4[i] > currentRaise)
                    {
                        counterRaise++;
                        currentRaise = ints4[i];
                    }
                    else
                    {
                        lengthsOfSequences[i] = counterRaise;
                        counterRaise = 1;
                        currentRaise = ints4[i];
                    }
                }
                int maximum = MaxForArrays(lengthsOfSequences);
                Console.WriteLine($"Lvl_3 || ex.9: The maximum length of sequence is {maximum}");
                Console.WriteLine();
            }
            else Console.WriteLine("The list is empty");
            #endregion

            #region ex.12 (fixed)
            List<int> ints5 = new List<int>();
            int numberOfIntegers = 0;
            try
            {
                Console.Write("Enter the number of nums: ");
                numberOfIntegers = int.Parse(Console.ReadLine());
                if (numberOfIntegers > 0)
                {
                    Console.WriteLine("Fill the list with integers: ");
                    for (int i = 0; i < numberOfIntegers; i++)
                    {
                        int element = int.Parse(Console.ReadLine());
                        ints5.Add(element);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Program supports only integers");
            }
            if (numberOfIntegers > 0)
            {
                ints5.RemoveAll(negative => negative < 0);
                Console.Write("Lvl_3 || ex.12: ");
                foreach (int i in ints5)
                {
                    Console.Write(i + "; ");
                }
                Console.WriteLine();
            }
            else Console.WriteLine("The list is empty");
            #endregion

            #region ex.13 (fixed)
            List<int> ints7 = new List<int>();
            List<int> listOfUniqueElements = new List<int>();
            List<int> listOfRepeatingIndexes = new List<int>();
            int quantityOfNumbers = 0;
            try
            {
                Console.Write("Enter the size of the list: ");
                quantityOfNumbers = int.Parse(Console.ReadLine());
                if (quantityOfNumbers > 0)
                {
                    Console.WriteLine("Enter the elements of the list: ");
                    for (int i = 0; i < quantityOfNumbers; i++)
                    {
                        int element = int.Parse(Console.ReadLine());
                        ints.Add(element);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Program supports only integers!");
            }
            if (quantityOfNumbers > 0)
            {
                int supportingCounter = 0;
                for (int i = 0; i < quantityOfNumbers; i++)
                {
                    if (listOfUniqueElements.Contains(ints[i]) == true)
                    {
                        listOfRepeatingIndexes.Add(i);
                    }
                    if (listOfUniqueElements.Contains(ints[i]) == false)
                    {
                        listOfUniqueElements.Add(ints[i]);
                    }
                }
                for (int i = 0; i < quantityOfNumbers; i++)
                {
                    if (listOfRepeatingIndexes.Contains(i + supportingCounter) == true)
                    {
                        ints.RemoveAt(i);
                        quantityOfNumbers--;
                        supportingCounter++;
                        i--;
                    }
                }
                Console.Write("Lvl_3 || ex.13: ");
                foreach (int i in ints)
                {
                    Console.Write(i + "; ");
                }
                Console.WriteLine();
            }
            else Console.WriteLine("The list is empty");
            #endregion

        }



        #region Binary Search (11) (fixed)
        static void BinarySearch()
        {
            int item = 5;
            int[] list = new int[] { 2, 3, 5, 7, 8, 9, 10, 12 };
            int lowBoundary = 0;
            int highBoundary = list.Length - 1;
            while(lowBoundary <= highBoundary)
            {
                int middleElementIndex = (lowBoundary + highBoundary) / 2;
                int guess = list[middleElementIndex];
                if(guess == item)
                {
                    Console.WriteLine($"Your number's index: {middleElementIndex}");
                }
                if(guess > item)
                {
                    highBoundary = middleElementIndex - 1;
                }
                else
                {
                    lowBoundary = middleElementIndex + 1;
                }
            }
        }
        #endregion

        #region Mixing Arrays (12) (fixed)
        static void MixingArrays1()
        {
            List<int> listA = new List<int>() { 11, 12, 23, 55, 65, 82, 90 };
            List<int> listB = new List<int>() { 13, 15, 6, 4, 5 ,100, 92, 13, 41, 5};
            List<int> listC = new List<int>();
            int lengthOfListA = listA.Count;
            int lengthOfListB = listB.Count;
            int smallestLength = FindingSmaller(lengthOfListA, lengthOfListB);
            int biggestLength = FindingBigger(lengthOfListA, lengthOfListB);
            int differenceOfLengths = Math.Abs(lengthOfListA - lengthOfListB);
            for (int i = 0; i < smallestLength; i++)
            {
                listC.Add(listA[i]);
                listC.Add(listB[i]);
            }
            for (int i = 0; i < differenceOfLengths; i++)
            {
                if (lengthOfListA > lengthOfListB)
                {
                    listC.Add(listA[biggestLength - differenceOfLengths + i]);
                }
                else listC.Add(listB[biggestLength - differenceOfLengths + i]);
            }
            
            Console.Write("--- Algorithms || n.12 ---  ");
            foreach (int i in listC)
            {
                Console.Write(i + "; ");
            }
            Console.WriteLine();
        }
        #endregion

        #region Mixing 2.0 (13)
        static void MixingArrays2()
        {
            List<int> A = new List<int>() { 1, 5, 6, 7, 2, 69 };
            List<int> B = new List<int>() { 3, 1, 3, 5 };
            List<int> C = new List<int>();
            int i = 0;
            int j = 0;
            while (i < A.Count || j < B.Count)
            {
                if (i == A.Count)
                {
                    C.Add(B[j]);
                    j++;
                    continue;
                }
                if (j == B.Count)
                {
                    C.Add(A[i]);
                    i++;
                    continue;
                }
                if (A[i] >= B[j])
                {
                    C.Add(A[i]);
                    i++;
                }
                else if (B[j] > A[i])
                {
                    C.Add(B[j]);
                    j++;
                }
            }
            Console.Write("--- Algorithms || n.13 ---  ");
            foreach (int x in C)
            {
                Console.Write(x + "; ");
            }
            Console.WriteLine();
        }
        #endregion

        #region Inverting Array (14)
        static void Inverting()
        {
            int buffer = 0;
            List<int> list = new List<int>() { 1, 5, 6, 7, 2, 69 };
            for (int i = 0; i < list.Count / 2; i++)
            {
                buffer = list[i];
                list[i] = list[list.Count - (i + 1)];
                list[list.Count - (i + 1)] = buffer;
            }
            Console.Write("--- Algorithms || n.14 ---  ");
            foreach (int i in list)
            {
                Console.Write(i + "; ");
            }
            Console.WriteLine();
        }
        #endregion

        #region Loop Shift (15)
        static void LoopShifting()
        {
            List<int> list = new List<int>() { 0, 1, 2, 3, 4, 5, 7, 12, 3 };
            List<int> m = new List<int>();
            int shift = 3;
            int indexOfSlidePosition = list.Count - shift;
            for (int i = indexOfSlidePosition; i < list.Count; i++)
            {
                m.Add(list[i]);
            }
            for (int i = 0; i < indexOfSlidePosition; i++)
            {
                m.Add(list[i]);
            }
            Console.Write("--- Algorithms || n.15 ---  ");
            foreach (int i in m)
            {
                Console.Write(i + "; ");
            }
        }
        #endregion

        #region Algorithms for exercises

        static int MaxForLists(List<int> ints)
        {
            int max = ints[0];
            foreach (int i in ints)
            {
                if (i > max) max = i;
            }
            return max;
        }

        static int MinForLists(List<int> ints)
        {
            int min = ints[0];
            foreach (int i in ints)
            {
                if (i < min) min = i;
            }
            return min;
        }

        static int MaxForArrays(int[] array)
        {
            int max = array[0];
            foreach (int i in array)
            {
                if (i > max) max = i;
            }
            return max;
        }

        static int MinForArrays(int[] array)
        {
            int min = array[0];
            foreach (int i in array)
            {
                if (i < min) min = i;
            }
            return min;
        }

        static bool Compare(int indexMin, int indexMax)
        {
            if (indexMin < indexMax)
            {
                return true;
            }
            else return false;
        }
        static void Swaping(List<int> list, int minNumber, int maxNumber)
        {
            int maxElementIndex = list.IndexOf(maxNumber);
            int minElementIndex = list.IndexOf(minNumber);
            int buffer = 0;
            if (Compare(minElementIndex, maxElementIndex) == false)
            {
                buffer = minNumber;
                list[minElementIndex] = maxNumber;
                list[maxElementIndex] = buffer;
            }
        }

        static int CountAverage(List<int> list, int minNumber, int maxNumber)
        {
            int sumBetweenMaxMin = 0;
            int k = 0;
            int average = 0;
            for (int i = list.IndexOf(minNumber) + 1; i < list.IndexOf(maxNumber); i++)
            {
                sumBetweenMaxMin += list[i];
                k++;
            }
            average = sumBetweenMaxMin / k;
            return average;
        }

        #region Helping Methods for ex.12
        static int FindingBigger(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            else return b;
        }
        static int FindingSmaller(int a, int b)
        {
            if (a < b)
            {
                return a;
            }
            else return b;
        }
        #endregion

        #endregion
    }
}
