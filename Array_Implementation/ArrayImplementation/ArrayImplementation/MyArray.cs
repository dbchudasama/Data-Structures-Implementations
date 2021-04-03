using System;

namespace ArrayImplementation
{
    public class MyArray
    {
        public int length;
        private Object[] data;

        //Constructor
        public MyArray()
        {
            length = 0;
            data = new Object[1];
        }


        /// <summary>
        /// Method to get Array index
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Array index item</returns>
        public Object get(int index)
        {
            return data[index];
        }


        /// <summary>
        /// Method to add item to array
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Array with added item</returns>
        public Object[] push(Object item)
        {
            // If the length of the array = length counter
            if (data.Length == length)
            {
                //Temp empty array
                Object[] temp = new Object[length];
                //Copying current array into new Temp array of same length
                Array.Copy(data, temp, length);
                //Updating current array size by 1 (next index value)
                data = new Object[length + 1];
                //Copying temp (previous array) back into our updated array 
                Array.Copy(temp, data, length);
            }
            //FIRST ITEM WILL JUMP STRAIGHT TO THIS AND MISS THE FOR LOOP - Setting the value of the latest index to the added item
            data[length] = item;
            //iterate the value of length
            length++;
            return data;
        }


        /// <summary>
        /// Method to remove the LAST element of the array
        /// </summary>
        /// <returns>Last Element of the Array</returns>
        public Object pop()
        {
            //Object = Last element of the array
            Object poped = data[length - 1];
            //Setting the last element of the array to null
            data[length - 1] = null;
            //Decrement array size by 1
            length--;
            //Return element to remove 
            return poped;
        }


        /// <summary>
        /// Method to delete array item
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Item to Delete</returns>
        public Object delete(int index)
        {
            //itemToDelete = Array index value item
            Object itemToDelete = data[index];
            //Shifting items 
            shiftItems(index);
            //Return itemToDelete
            return itemToDelete;
        }


        /// <summary>
        /// Private method to shift array elements during a delete operation
        /// </summary>
        /// <param name="index"></param>
        private void shiftItems(int index)
        {
            //Iterating over array
            for (int i = index; i < length - 1; i++)
            {
                //Shifting all elements one place to the right
                data[i] = data[i + 1];
            }
            //Setting last element to null
            data[length - 1] = null;
            //Decrement length of array by 1
            length--;
        }


        static void Main(string[] args)
        {
            MyArray myArray = new MyArray();

            myArray.push("Hello");
            myArray.push("World");
            myArray.push("!");

            myArray.delete(1);

            //Testing array after delete
            for (int i = 0; i < myArray.length; i++)
            {
                Console.WriteLine(myArray.get(i));
            }
        }
    }
}
