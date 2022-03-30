using UnityEngine;
using System.Collections;

public class TitleSceneManager : MonoBehaviour
{
    [SerializeField]
    private BackGroundAnim backGroundAnim;  // ����N���X
    




    private void Start()
    {
        /* ���C�����[�v */
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