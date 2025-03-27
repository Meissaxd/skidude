using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateExample : MonoBehaviour
{
    public delegate void DelegateEx();
    private DelegateEx function;
    void Start()
    {
        function = Example1;
        function();
        function = Example2;
        function();
    }
    private void Example1()
    {
        Debug.Log("EXAMPLE");
    }

    private void Example2()
    {
        Debug.Log("EXAMPLE 2");
    }
}
