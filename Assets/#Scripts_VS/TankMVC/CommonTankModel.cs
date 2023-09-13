using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonTankModel
{
    public int Health { get; protected set; }

    // i have made take damage function here because
    // i want to have encapsulation in my class
    // if i mark my health property as public get, and public set
    // then there is no point of having a property i can just create a public variable
    public virtual void TakeDamage(float damage)
    {
        Health -= (int)damage;
        // the logic of dying (when health gets lesser than 0 is executed by EnemyTankController)
        // because it(Enemy tank controller) can access model
        // and on top of that EnemyTankModel does not need to know
        // about EnemyTankController (Model does not need hold the refrence of Controller)
    }
}
