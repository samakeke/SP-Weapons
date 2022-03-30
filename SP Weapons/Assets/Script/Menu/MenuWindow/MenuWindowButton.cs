using UnityEngine;
using UnityEngine.UI;

public class MenuWindowButton : MonoBehaviour
{
    /// <summary>
    /// ���j���[�E�B���h�E�Ɋ܂܂��S�Ẵ{�^��
    /// </summary>

    [SerializeField]
    private MenuSceneManager menuSceneManager;  // ����N���X
    [SerializeField]
    private Button questButton;
    [SerializeField]
    private Button editButton;
    [SerializeField]
    private Button otherButton;
    [SerializeField]
    private Button optionButton;
    [SerializeField]
    private GameObject objQuestCanvas;
    [SerializeField]
    private GameObject objEditCanvas;
    [SerializeField]
    private GameObject objOtherCnvas;
    [SerializeField]
    private GameObject objOptionCanvas;
    [SerializeField]
    private GameObject objMenuNonTouchPanel;





    private void Start()
    {
        /* �e�{�^���̓o�^ */

        ButtonRegist();
    }





    private void ButtonRegist()
    {
        questButton.onClick.AddListener(() =>
        {
            objMenuNonTouchPanel.SetActive(true);   // �J�ڒ��̃{�^���^�b�`�h�~�p�p�l�����A�N�e�B�u��

            menuSceneManager.PreviousWindowInfoRegist();    // �������ʂ��L�^

            objQuestCanvas.SetActive(true); // �Y����ʂ֑J��
        });

        editButton.onClick.AddListener(() =>
        {
            objMenuNonTouchPanel.SetActive(true);

            menuSceneManager.PreviousWindowInfoRegist();

            objEditCanvas.SetActive(true);
        });

        otherButton.onClick.AddListener(() =>
        {
            objMenuNonTouchPanel.SetActive(true);

            menuSceneManager.PreviousWindowInfoRegist();

            objOtherCnvas.SetActive(true);
        });

        optionButton.onClick.AddListener(() =>
        {
            objMenuNonTouchPanel.SetActive(true);

            menuSceneManager.PreviousWindowInfoRegist();

            objOptionCanvas.SetActive(true);
        });
    }
}
