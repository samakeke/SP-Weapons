using UnityEngine;
using System.Collections;

public class TitleSceneManager : MonoBehaviour
{
    [SerializeField]
    private BackGroundAnim backGroundAnim;  // 自作クラス
    




    private void Start()
    {
        /* メインループ */
        StartCoroutine(Main());
    }





    private IEnumerator Main()
    {
        for(; ; )
        {
            yield return StartCoroutine(backGroundAnim.Movie());

            yield return null;
        }
    }
}