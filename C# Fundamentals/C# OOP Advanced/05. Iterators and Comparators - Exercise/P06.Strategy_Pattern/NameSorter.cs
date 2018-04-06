﻿namespace P06.Strategy_Pattern
{
    using System.Collections.Generic;

    public class NameSorter :IComparer<Person>
    {

        public int Compare(Person first, Person second)
        {
            int result = first.Name.Length.CompareTo(second.Name.Length);
            if (result == 0)
            {              
                result = first.Name.ToLower()[0].CompareTo(second.Name.ToLower()[0]);
            }
            return result;
        }
    }
}
