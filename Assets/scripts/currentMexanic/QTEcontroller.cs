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
    public QTEScriptableObject QTErock;
    public QTEScriptableObject QTEpaper;
    public QTEScriptableObject QTEsisors;
    public Sprite[] QTEbuttonImagesFromIDs;
    public GameObject Icon;
    public Slider timeBar;

    private float QTEtime;
    private float StartQTEtime;
    private float QTEWinScore;
     private float QTELoseScore;
    private bool started = false;


    private QTEButtons[] qteNow;
    private int buttonNow;
    private Image[] Buttons;
    public UnityEvent<bool, float> EndQTEEvent;
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
        timeBar.value = 1;
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
    public void SetupQTEButtons(QTEScriptableObject QteScrObj){
        QTEButtons[] butt = QteScrObj.QTEcombo;
        StartQTEtime = QteScrObj.QTEtime;
        QTEtime = StartQTEtime;
        QTEWinScore = QteScrObj.QTEScoreWin;
        QTELoseScore = QteScrObj.QTEScoreLose;
        buttonNow = 0;
        qteNow = butt;
        Buttons = new Image[butt.Length];
        for (int i = 0; i < butt.Length; i++)
        {
            GameObject button = Instantiate(Icon, transform);
            Buttons[i] = button.GetComponent<Image>();
            Buttons[i].sprite = QTEbuttonImagesFromIDs[ButEnum_to_ID(butt[i])];
        }
        started = true;

    }
    public void ExitQTE(bool isWin, float deltaScore){
        started = false;
        for (int i = 0; i < Buttons.Length; i++)
        {
            if (Buttons[i] != null)
            {
                Destroy(Buttons[i].gameObject);
            }
            
        }
        EndQTEEvent.Invoke(isWin, deltaScore);
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
                ExitQTE(true, QTEWinScore);
            }
        }
    }
    public void FixedUpdate(){
        if (started)
        {
            QTEtime -= Time.fixedDeltaTime;
            timeBar.value = QTEtime / StartQTEtime;
            if (QTEtime <= 0)
            {
                ExitQTE(false, -1*QTELoseScore);
                
            }

        }
        


    }
}

