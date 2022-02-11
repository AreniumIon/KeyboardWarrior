using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public static class ListFunctions
{
    /** Input: List of parent class T2
     * Output: First instance of specified child class T1
     */
    public static T1 Find<T1, T2>(this IEnumerable<T2> list) where T1 : T2
    {
        return list.OfType<T1>().FirstOrDefault();
    }
}
