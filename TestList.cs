using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestList : MonoBehaviour
{
    List<string> friends = new List<string>();
    void Start()
    {
        friends.Add("����");//0    //0   //0
        friends.Add("����");//1    //2   //2   //1
        friends.Add("����");//2    //3     
        friends.Add("����");//3    //4   //3   //2
        friends.Add("�����");//4   //5   //4    //3
        friends.Add("����");//5    //6   //5    //4

        friends.Insert(1, "����"); //1   //1   //0

        friends.Remove("����");

        friends.RemoveAt(0);

        print(friends.Count);

        for (int i = 0; i < friends.Count; i++)
        {
            print(i);
            print(friends[i]);
        }
    }
}
