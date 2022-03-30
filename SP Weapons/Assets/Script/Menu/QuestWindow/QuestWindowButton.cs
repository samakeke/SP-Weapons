using UnityEngine;
using UnityEngine.UI;

public class QuestWindowButton : MonoBehaviour
{
    /// <summary>
    /// �N�G�X�g�E�B���h�E�Ɋ܂܂��S�Ẵ{�^��
    /// </summary>

    [SerializeField]
    private MenuSceneManager menuSceneManager;
    [SerializeField]
    private Button homeButton;
    [SerializeField]
    private Button backButton;
    [SerializeField]
    private GameObject objMenuCanvas;
    [SerializeField]
    private GameObject objQuestNonTouchPanel;





    private void Start()
    {
        ButtonRegist();
    }





    /* �e�{�^���̓o�^ */

    private void ButtonRegist()
    {
        /*homeButton.onClick.AddListener(() =>
        {
            
        });*/

        backButton.onClick.AddListener(() =>
        {
            objQuestNonTouchPanel.SetActive(true);  // �J�ڒ��̃{�^���^�b�`�h�~�p�p�l�����A�N�e�B�u��

            menuSceneManager.PreviousWindowInfoRegist();    // �������ʂ��L�^

            objMenuCanvas.SetActive(true);  // �Y����ʂ֑J��
        });
    }
}
