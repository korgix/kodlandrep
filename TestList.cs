using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestList : MonoBehaviour
{
    List<string> friends = new List<string>();
    void Start()
    {
        friends.Add("Коля");//0    //0   //0
        friends.Add("Женя");//1    //2   //2   //1
        friends.Add("Олег");//2    //3     
        friends.Add("Леша");//3    //4   //3   //2
        friends.Add("Карим");//4   //5   //4    //3
        friends.Add("Саша");//5    //6   //5    //4

        friends.Insert(1, "Марк"); //1   //1   //0

        friends.Remove("Олег");

        friends.RemoveAt(0);

        print(friends.Count);

        for (int i = 0; i < friends.Count; i++)
        {
            print(i);
            print(friends[i]);
        }
    }
}
