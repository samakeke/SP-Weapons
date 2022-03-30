using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestWindowManager : MonoBehaviour
{
    [SerializeField]
    private MenuSceneManager menuSceneManager;
    [SerializeField]
    private Animator animQuestCanvas;
    [SerializeField]
    private GameObject objQuestNonTouchPanel;

    private const byte ANIM_TIME_BORDER = 1;
    private const byte LAYER = 0;





    private void OnEnable()
    {
        /* ���C�����[�v */

        StartCoroutine(Main());
    }





    private IEnumerator Main()
    {
        for (; ; )
        {
            if(animQuestCanvas.GetCurrentAnimatorStateInfo(LAYER).normalizedTime >= ANIM_TIME_BORDER)
            {
                objQuestNonTouchPanel.SetActive(false);

                /* �O�̉�ʂ��A�N�e�B�u�ɂ��� */

                menuSceneManager.PreviousWindowInfoDiscard();

                Debug.Log("PreviousCanvas is NonActive");

                yield break;
            }
            yield return null;
        }
    }
}