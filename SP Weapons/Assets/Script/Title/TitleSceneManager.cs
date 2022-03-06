using UnityEngine;
using System.Collections;

public class TitleSceneManager : MonoBehaviour
{
    [SerializeField]
    private BackGroundAnim backGroundAnim;

    private void Start()
    {
        StartCoroutine(Main());
    }

    IEnumerator Main()
    {
        for(; ; )
        {
            yield return StartCoroutine(backGroundAnim.Movie());

            yield return null;
        }
    }
}