using UnityEngine;
using System.Collections;

public class MenuWindowManager : MonoBehaviour
{
    [SerializeField]
    private MenuSceneManager menuSceneManager;
    [SerializeField]
    private Animator animMenuCanvas;
    [SerializeField]
    private RuntimeAnimatorController animCtrlMenuCanvas;
    [SerializeField]
    private GameObject fadePanel;
    [SerializeField]
    private GameObject objMenuNonTouchPanel;

    private const byte ANIMATION_TIME_BORDER = 1;
    private const byte LAYER = 0;
    




    private void OnEnable()
    {
        /* 初めて遷移してきたかどうか */

        if (fadePanel.activeSelf == false)
        {
            animMenuCanvas.runtimeAnimatorController = animCtrlMenuCanvas;

            /* メインループ */

            StartCoroutine(Main());
        }
    }
    




    private IEnumerator Main()
    {
        for(; ; )
        {
            if (animMenuCanvas.GetCurrentAnimatorStateInfo(LAYER).normalizedTime >= ANIMATION_TIME_BORDER)
            {
                objMenuNonTouchPanel.SetActive(false);

                // 前の画面を非アクティブにする

                menuSceneManager.PreviousWindowInfoDiscard();

                Debug.Log("PreviousCanvas is NonActive");

                yield break;
            }
            yield return null;
        }
    }
}
