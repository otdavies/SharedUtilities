using System;
using System.Collections.Generic;

//TODO: Consider implementing an "iterator" concept similar to rust.

namespace Psyfer.Utilities
{
    public static class ListExtensions
    {
        /// <summary>
        /// Shuffle the list in place using the Fisher-Yates method.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static void Shuffle<T>(this List<T> list)
        {
            Random rng = new();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        /// <summary>
        /// Return a random item from the list.
        /// Sampling with replacement.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static T RandomItem<T>(this List<T> list)
        {
            if (list.Count == 0) throw new IndexOutOfRangeException("Cannot select a random item from an empty list");
            return list[UnityEngine.Random.Range(0, list.Count)];
        }

        /// <summary>
        /// Removes a random item from the list, returning that item.
        /// Sampling without replacement.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static T RemoveRandom<T>(this List<T> list)
        {
            if (list.Count == 0) throw new IndexOutOfRangeException("Cannot remove a random item from an empty list");
            int index = UnityEngine.Random.Range(0, list.Count);
            T item = list[index];
            list.RemoveAt(index);
            return item;
        }

        /// <summary>
        /// Filters out all items from the list that don't match the predicate.
        /// </summary>
        public static List<T> Filter<T>(this List<T> list, Func<T, bool> predicate)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (!predicate(list[i])) list.RemoveAt(i);
            }
            return list;
        }

        /// <summary>
        /// Filter out all items from the list that don't match the predicate and return them in a new list.
        /// </summary>
        public static List<T> FilterCloned<T>(this List<T> list, Func<T, bool> predicate)
        {
            List<T> filtered = new();
            for (int i = 0; i < list.Count; i++)
            {
                if (predicate(list[i])) filtered.Add(list[i]);
            }
            return filtered;
        }

        /// <summary>
        /// Reduce the list down to a single value by applying a function to each item in the list.
        /// </summary>
        public static T Reduce<T>(this List<T> list, Func<T, T, T> func)
        {
            T result = list[0];
            for (int i = 1; i < list.Count; i++)
            {
                result = func(result, list[i]);
            }
            return result;
        }

        /// <summary>
        /// Combine two lists together
        /// </summary>
        public static List<T> Concat<T>(this List<T> list, List<T> other)
        {
            list.AddRange(other);
            return list;
        }

        /// <summary>
        /// Combine two lists together and return them in a new list.
        /// </summary>
        public static List<T> ConcatCloned<T>(this List<T> list, List<T> other)
        {
            List<T> newList = new();
            newList.AddRange(list);
            newList.AddRange(other);
            return newList;
        }

        /// <summary>
        /// Remaps the type of the list to a new type
        /// </summary>
        public static List<T1> Map<T, T1>(this List<T> list, Func<T, T1> func)
        {
            List<T1> newList = new();
            foreach (T item in list)
            {
                newList.Add(func(item));
            }
            return newList;
        }

        /// <summary>
        /// Flattens a list of lists into a single list.
        /// </summary>
        public static List<T> Flatten<T>(this List<List<T>> list)
        {
            List<T> newList = new();
            foreach (List<T> subList in list)
            {
                newList.AddRange(subList);
            }
            return newList;
        }

        /// <summary>
        /// Adds an item to the list
        /// </summary>
        public static void Push<T>(this List<T> list, T item)
        {
            list.Add(item);
        }

        /// <summary>
        /// Removes an item from the list
        /// </summary>
        public static T Pop<T>(this List<T> list)
        {
            if (list.Count == 0) throw new IndexOutOfRangeException("Cannot pop an empty list");
            T item = list.NthFromEnd(0);
            list.RemoveAt(list.Count - 1);
            return item;
        }

        /// <summary>
        /// Looks at the last item in the list, but doesn't remove it
        /// </summary>
        public static T Peek<T>(this List<T> list)
        {
            if (list.Count == 0) throw new IndexOutOfRangeException("Cannot peek an empty list");
            return list.NthFromEnd(0);
        }

        /// <summary>
        /// Is the list empty?
        /// </summary>
        public static bool IsEmpty<T>(this List<T> list)
        {
            return list.Count == 0;
        }

        /// <summary>
        /// Returns a the item nth from the end of the list.
        /// </summary>
        public static T NthFromEnd<T>(this List<T> list, int n)
        {
            if (list.Count == 0) throw new IndexOutOfRangeException("Cannot get the nth item from an empty list");
            if (n < 0) throw new IndexOutOfRangeException("Cannot get a negative index from a list");
            if (n >= list.Count) throw new IndexOutOfRangeException("Cannot get an index greater than the list size");
            return list[list.Count - n - 1];
        }
    }
}