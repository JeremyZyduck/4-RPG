#region USING
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
#endregion
/*<SUMMARY>
 *When attached to an object said object will fade to 50% transparency on player collision and return to 0% transparency on collision exit.
<USE>
 *Roof objects.
</USE>
</SUMMARY>*/
public class RoofVisibility : MonoBehaviour
{
#region TODO
#endregion
#region COLLISION
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine("FadeToTransparent");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine("ReturnToOpaque");
        }
    }
    #endregion
#region COLOR FADE
    [BoxGroup("Color Change"), SerializeField, LabelText("Duration - Float")]
    private float duration = 0;
    [BoxGroup("Color Change"), SerializeField, LabelText("Transparency Amount - Float")]
    private float transparencyAmount = 0.45f;

    IEnumerator FadeToTransparent()
    {
        for (float i = 1f; i >= transparencyAmount; i -= 0.05f)
        {
            Color c = GetComponent<SpriteRenderer>().material.color;
            c.a = i;
            GetComponent<SpriteRenderer>().material.color = c;
            Debug.Log(c);
            yield return new WaitForSeconds(duration);
        }
    }
    IEnumerator ReturnToOpaque()
    {
        for (float i = 0.5f; i <= 1.05; i += 0.05f)
        {
            Color c = GetComponent<SpriteRenderer>().material.color;
            c.a = i;
            GetComponent<SpriteRenderer>().material.color = c;
            Debug.Log(c);
            yield return new WaitForSeconds(duration);
        }
    }
    #endregion
}
