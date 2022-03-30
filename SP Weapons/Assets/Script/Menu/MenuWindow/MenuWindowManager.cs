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
        /* ���߂đJ�ڂ��Ă������ǂ��� */

        if (fadePanel.activeSelf == false)
        {
            animMenuCanvas.runtimeAnimatorController = animCtrlMenuCanvas;

            /* ���C�����[�v */

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

                // �O�̉�ʂ��A�N�e�B�u�ɂ���

                menuSceneManager.PreviousWindowInfoDiscard();

                Debug.Log("PreviousCanvas is NonActive");

                yield break;
            }
            yield return null;
        }
    }
}
