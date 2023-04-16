using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    [Header("¶Ë®`¶q")]
    [SerializeField] float hurt = 1f;

    /*private IEnumerator OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            yield return new WaitForSeconds(0.5f);
            PlayerCtrl.instance.TakeDamage(hurt * Time.deltaTime);
        }
    }*/

    Collider2D tempTarget = null;
    bool killPlayer = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        tempTarget = collision;
        killPlayer = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        tempTarget = null;
        killPlayer = false;
    }

    private void Update()
    {
        if (killPlayer == true && tempTarget != null)
        {
            if (tempTarget.gameObject.tag == "Player")
            {
                PlayerCtrl.instance.TakeDamage(hurt * Time.deltaTime);
            }
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
