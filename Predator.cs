using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Predator : Enemy
{
    public override void Move()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 100)
        {
            transform.LookAt(player.transform);
            GetComponent<CharacterController>().Move(transform.forward * Time.deltaTime * 2);
        }
    }

    public override void Attack()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 3)
        {
            player.GetComponent<PlayerController>().ChangeHealth(-100);
        }
    }
}
