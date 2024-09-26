using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/QTEScriptableObject", order = 1)]
public class QTEScriptableObject : ScriptableObject
{
    public QTEcontroller.QTEButtons[] QTEcombo;
    public float QTEtime;
    public float QTEScoreLose;
    public float QTEScoreWin;
}
