using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class QTEcontroller : MonoBehaviour
{
    public enum QTEButtons
    {
        up,
        left,
        right,
        down

    }
    public QTEButtons[] QTErock;
    public QTEButtons[] QTEpaper;
    public QTEButtons[] QTEsisors;
    public Sprite[] QTEbuttonImagesFromIDs;
    public GameObject Icon;

    private QTEButtons[] qteNow;
    private int buttonNow;
    private Image[] Buttons;
    public UnityEvent<bool> EndQTEEvent;
    public QTEcontroller.QTEButtons ButID_to_Enum(int ID){
        switch (ID)
        {
            case 1:
                return QTEButtons.up;
            case 2:
                return QTEButtons.left;
            case 3:
                return QTEButtons.right;
            case 4:
                return QTEButtons.down;


            default:
                return QTEButtons.up;
        }

    }
    public int ButEnum_to_ID(QTEButtons Enu){
        switch (Enu)
        {
            case QTEButtons.up:
                return 0;
            case QTEButtons.left:
                return 1;
            case QTEButtons.right:
                return 2;
            case QTEButtons.down:
                return 3;


            default:
                return 1;
        }

    }
    public void StartQTE(int leftID, int rightID){
        switch (leftID)
        {
            case 1:
                SetupQTEButtons(QTErock);
                break;
            case 2:
                SetupQTEButtons(QTEpaper);
                break;
            case 3:
                SetupQTEButtons(QTEsisors);
                break;

            default:
                break;
        }

    }
    public void SetupQTEButtons(QTEButtons[] butt){
        buttonNow = 0;
        qteNow = butt;
        Buttons = new Image[butt.Length];
        for (int i = 0; i < butt.Length; i++)
        {
            GameObject button = Instantiate(Icon, transform);
            Buttons[i] = button.GetComponent<Image>();
            Buttons[i].sprite = QTEbuttonImagesFromIDs[ButEnum_to_ID(butt[i])];
        }

    }
    public void ExitQTE(bool isWin){
        EndQTEEvent.Invoke(isWin);
    }
    public void Update(){
        if (Input.GetKeyDown(KeyCode.UpArrow) && qteNow[buttonNow] == QTEButtons.up
        || Input.GetKeyDown(KeyCode.DownArrow) && qteNow[buttonNow] == QTEButtons.down
        || Input.GetKeyDown(KeyCode.RightArrow) && qteNow[buttonNow] == QTEButtons.right
        || Input.GetKeyDown(KeyCode.LeftArrow) && qteNow[buttonNow] == QTEButtons.left)
        {
            Destroy(Buttons[buttonNow].gameObject);
            buttonNow++;
            if (buttonNow == Buttons.Length)
            {
                ExitQTE(true);
            }
        }
    }
}
