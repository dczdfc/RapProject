using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class battleManager : MonoBehaviour
{
    [SerializeField] private Image LeftIcon;
    [SerializeField] private Image RightIcon;
    public BaceEnemy currentEnemy;
    [Space(20f)]
    public Sprite[] PunchTipesImages = new Sprite[3];
    [Space(10f)]
    [SerializeField] private Animator animatorLeftBattleIcon;
    [SerializeField] private Animator animatorRightBattleIcon;
    [Space(10f)]
    [SerializeField] private GameObject QTEPanel;
    [SerializeField] private float time;
    public UnityEvent HitEvent;
    public UnityEvent<bool, bool> EndEvent;
    public QTEcontroller qTEcontroller;

    public pick_queue player_pick_queue;
    public pick_queue enemy_pick_queue;
    private int roundNumb;

    [Space(5f)]
    [Header("score")]

    public float score;
    public Slider scoreBar;

    public void AddScore(float PlusScore){
        score += PlusScore;
        scoreBar.value += PlusScore;
        if (score >= 100)
        {
            EndEvent.Invoke(true, true);
            
        }if (score <= -100)
        {
            
            EndEvent.Invoke(true, false);
        }

    }

    public void SStart()
    {
        QTEPanel.SetActive(false);
        roundNumb = 0;

        StartRound(roundNumb);
        
    }
    void StartRound(int round){
        enemy_pick_queue = currentEnemy.get_pick_queue(round, null);
        LeftIcon.sprite = PunchTipesImages[player_pick_queue.punch_queue[round]];
        RightIcon.sprite = PunchTipesImages[enemy_pick_queue.punch_queue[round]];
        animatorLeftBattleIcon.SetTrigger("start");
        animatorRightBattleIcon.SetTrigger("start");
        StartCoroutine(WhateToHit());
    }
    IEnumerator WhateToHit(){
        yield return new WaitForSeconds(.3f);
        animatorLeftBattleIcon.SetTrigger("hit");
        animatorRightBattleIcon.SetTrigger("hit");
        StartCoroutine(WhaitToQTEIvent());

    }
    IEnumerator WhaitToQTEIvent(){
        yield return new WaitForSeconds(time);
        qTEcontroller.StartQTE(player_pick_queue.punch_queue[roundNumb], enemy_pick_queue.punch_queue[roundNumb]);
        HitEvent.Invoke();
    }
    public void EndQTE(bool ISWin, float DeltaScore){
        QTEPanel.SetActive(false);
        if (ISWin)
        {
            animatorLeftBattleIcon.SetTrigger("win");
            animatorRightBattleIcon.SetTrigger("lose");
            
        }else{
            animatorLeftBattleIcon.SetTrigger("lose");
            animatorRightBattleIcon.SetTrigger("win");
        }
        AddScore(DeltaScore);
        StartCoroutine(WhateToLose());

    }
    IEnumerator WhateToLose(){
        yield return new WaitForSeconds(.3f);
        roundNumb++;
        Debug.Log(roundNumb);
        if (roundNumb == player_pick_queue.punch_queue.Length)
        {
            EndEvent.Invoke(false, false);
        }
        else
        {
            Debug.Log("Enter WhateToLose");
            StartRound(roundNumb);
        }
        

    }
    


    // Update is called once per frame
    void Update()
    {
        
    }
}
