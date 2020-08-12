﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Vector
{

    public class Vector<T>
    {

        // This constant determines the default number of elements in a newly created vector.
        // It is also used to extended the capacity of the existing vector
        private const int DEFAULT_CAPACITY = 10;

        // This array represents the internal data structure wrapped by the vector class.
        // In fact, all the elements are to be stored in this private  array. 
        // You will just write extra functionality (methods) to make the work with the array more convenient for the user.
        private T[] data;
        // This property represents the number of elements in the vector
        public int Count { get; private set; } = 0;

        // This property represents the maximum number of elements (capacity) in the vector
        public int Capacity { get; private set; } = 0;

        // This is an overloaded constructor
        public Vector(int capacity)
        {
            data = new T[capacity];
        }

        // This is the implementation of the default constructor
        public Vector() : this(DEFAULT_CAPACITY) { }

        // An Indexer is a special type of property that allows a class or structure to be accessed the same way as array for its internal collection. 
        // For example, introducing the following indexer you may address an element of the vector as vector[i] or vector[0] or ...
        public T this[int index]
        {
            get
            {
                if (index >= Count || index < 0) throw new IndexOutOfRangeException();
                return data[index];
            }
            set
            {
                if (index >= Count || index < 0) throw new IndexOutOfRangeException();
                data[index] = value;
            }
        }

        // This private method allows extension of the existing capacity of the vector by another 'extraCapacity' elements.
        // The new capacity is equal to the existing one plus 'extraCapacity'.
        // It copies the elements of 'data' (the existing array) to 'newData' (the new array), and then makes data pointing to 'newData'.
        private void ExtendData(int extraCapacity)
        {
            T[] newData = new T[data.Length + extraCapacity];
            for (int i = 0; i < Count; i++)
            {
                newData[i] = data[i];
                data = newData;
            }
        }

        // This method adds a new element to the existing array.
        // If the internal array is out of capacity, its capacity is first extended to fit the new element.
        public void Add(T element)
        {
            if (Count == data.Length) ExtendData(DEFAULT_CAPACITY);
            data[Count++] = element;
        }

        // This method searches for the specified object and returns the zero‐based index of the first occurrence within the entire data structure.
        // This method performs a linear search; therefore, this method is an O(n) runtime complexity operation.
        // If occurrence is not found, then the method returns –1.
        // Note that Equals is the proper method to compare two objects for equality, you must not use operator '=' for this purpose.
        public int IndexOf(T element)
        {
            for (var i = 0; i < Count; i++)
            {
                if (data[i].Equals(element)) return i;
            }
            return -1;
        }
        // TODO:********************************************************************************************
        // TODO: Your task is to implement all the remaining methods.
        // Read the instruction carefully, study the code examples from above as they should help you to write the rest of the code.

        public void Insert(int index, T element)
        {
            if (index < 0 || index > Count) throw new IndexOutOfRangeException(); //if outside of array throw new exception
            if (Count == Capacity) ExtendData(DEFAULT_CAPACITY); //if the the total space is taken increase the size of the array
            if (index == Count)
            {
                Add(element);
                return;
            }
            if (index >= 0 && index < Count)
            {
                for (int i = Count; i > index; i--)
                {
                    data[i] = data[i - 1];
                }
                data[index] = element;
                Count++;
            }
        }
        public void Clear()
        {
            T[] clearArray = new T[Count]; // create a new array that allows and set the size equal to the new count
            data = clearArray;
            Count = 0; // set the index of the array equal to 0
        }
        public bool Contains(T element)
        {
            int exists = IndexOf(element); // assign the valuse of indexOf to exists
            if (exists > -1) //if index off does not return a value of -1 or a value grater than 0 it exists
            {
                return true;
            }
            return false;
        }
        public bool Remove(T element)
        {
            int i = IndexOf(element);
            if (i >= 0)
            {
                RemoveAt(i);
                return true;
            }
            return false;
        }
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
            for (int i = index; i < Count - 1; i++)
            {
                data[i] = data[i + 1];
            }
            Count--;
        }
        public override string ToString()
        {
            StringBuilder newString = new StringBuilder();
            newString.Append("[");
            for (int i = 0; i < Count; i++)
            {
                newString.Append(data[i]);
                newString.Append(",");
            }
            newString.Append("]");
            return newString.ToString();
        }
    }
}