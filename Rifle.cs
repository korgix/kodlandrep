using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Pistol
{
    void Start()
    {
        auto = true;
        cooldown = 0.2f;
    }
}
