using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuSceneManager : MonoBehaviour
{
    /// <summary>
    /// メニューシーンを管理するクラス
    /// </summary>

    [SerializeField]
    private FadeControll fadeControll;  // 自作クラス
    [SerializeField]
    private GameObject objFadePanel;
    [SerializeField]
    private GameObject objNonTouchPanel;
    
    private Animator animFadePanel = default;
    private GameObject objPreviousWindow = default;
    private CanvasGroup groupPreviousWindow = default;

    private const string FINDWITHTAG_OBJ = "Window";
    private const byte ANIMATION_TIME_BORDER = 1;
    private const byte LAYER = 0;
    




    private void Start()
    {
        animFadePanel = fadeControll.GetAnimFadePanel;

        /* メインループ */
        StartCoroutine(Main());
    }





    private IEnumerator Main()
    {
        for (; ; )
        {
            if (animFadePanel.GetCurrentAnimatorStateInfo(LAYER).normalizedTime >= ANIMATION_TIME_BORDER)
            {
                objFadePanel.SetActive(false);
                objNonTouchPanel.SetActive(false);

                Debug.Log("FadePanel is NonActive");

                yield break;
            }

            yield return null;
        }
    }





    /* 現在アクティブな画面を取得(画面遷移ボタンを押下した際に呼ばれる) */

    public void PreviousWindowInfoRegist()
    {
        objPreviousWindow = GameObject.FindWithTag(FINDWITHTAG_OBJ);

        groupPreviousWindow = objPreviousWindow.GetComponent<CanvasGroup>();

        Debug.Log(objPreviousWindow);
        Debug.Log(groupPreviousWindow);
    }





    /* 前画面を非アクティブにし、CanvasGroupAlphaを0に*/

    public void PreviousWindowInfoDiscard()
    {
        objPreviousWindow.SetActive(false);

        groupPreviousWindow.alpha = default;

        Debug.Log(objPreviousWindow);
        Debug.Log(groupPreviousWindow);
    }
}
