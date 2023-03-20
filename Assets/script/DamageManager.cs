using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    [Header("¶Ë®`¶q")]
    [SerializeField] float hurt = 1f;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //yield return new WaitForSeconds(5f);
            PlayerCtrl.instance.TakeDamage(hurt);
        }
    }

    /*
    IEnumerator MapDamage()
    {
        IEnumerator OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                yield return new WaitForSeconds(5f);
                PlayerCtrl.instance.TakeDamage(hurt);
            }
        }
        yield return null;
    }
    */
}
