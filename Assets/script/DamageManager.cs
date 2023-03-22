using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    [Header("¶Ë®`¶q")]
    [SerializeField] float hurt = 10f;

    private IEnumerator OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            yield return new WaitForSeconds(0.5f);
            PlayerCtrl.instance.TakeDamage(hurt * Time.deltaTime);
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
