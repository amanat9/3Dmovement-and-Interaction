using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestIfStatement : MonoBehaviour
{
    public int[] array = { 5,10, 20, 7, 40 };
    //public int[] array;

    // Start is called before the first frame update

    void PrintsHowmanyODDandHowManyEven()
    {
        Debug.Log(array[0]); // instead of 0 call array[i] inside a for loop
        //    num % 2 == 0 even (same as oddCounter)     //   num%2 != 0 odd=odd+1
        //    dont use num, use array[i]
    }
    
    void Start()
    {
        PrintsHowmanyODDandHowManyEven();
        

    }
  
}
