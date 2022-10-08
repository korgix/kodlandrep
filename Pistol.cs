using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    void Start()
    {
        cooldown = 0;
        auto = false;
    }
    protected override void OnShoot()
    {
        GameObject buf = Instantiate(bullet);
        buf.transform.position = rifleStart.transform.position;
        buf.transform.rotation = transform.rotation;
        buf.GetComponent<Bullet>().setDirection(transform.forward);
    }
}
