using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public int pumpkinHealth;
    public int pumpkinMaxHealth = 80;
    public void TakeDamageToPumpkin(int damage)
    {
        pumpkinHealth -= damage;
    }

}
