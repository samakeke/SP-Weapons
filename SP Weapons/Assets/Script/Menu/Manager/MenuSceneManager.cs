using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuSceneManager : MonoBehaviour
{
    /// <summary>
    /// ���j���[�V�[�����Ǘ�����N���X
    /// </summary>

    [SerializeField]
    private FadeControll fadeControll;  // ����N���X
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

        /* ���C�����[�v */
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





    /* ���݃A�N�e�B�u�ȉ�ʂ��擾(��ʑJ�ڃ{�^�������������ۂɌĂ΂��) */

    public void PreviousWindowInfoRegist()
    {
        objPreviousWindow = GameObject.FindWithTag(FINDWITHTAG_OBJ);

        groupPreviousWindow = objPreviousWindow.GetComponent<CanvasGroup>();

        Debug.Log(objPreviousWindow);
        Debug.Log(groupPreviousWindow);
    }





    /* �O��ʂ��A�N�e�B�u�ɂ��ACanvasGroupAlpha��0��*/

    public void PreviousWindowInfoDiscard()
    {
        objPreviousWindow.SetActive(false);

        groupPreviousWindow.alpha = default;

        Debug.Log(objPreviousWindow);
        Debug.Log(groupPreviousWindow);
    }
}
