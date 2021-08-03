using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    public bool enemyDamage,damagePlayer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Enemy")&& enemyDamage)
        {
            //Debug.Log("Hitted enemy");
            Destroy(this.gameObject);
            other.gameObject.GetComponent<EnemyHealth>().DamageEnemy(2);
        }
        if (other.gameObject.tag == "Player" && damagePlayer)
        {
            PlayerHealth.instance.PlayerDamage(1);
        }
    }
    
}
