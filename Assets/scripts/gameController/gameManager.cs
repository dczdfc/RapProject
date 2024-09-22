using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class gameManager : StateManager<gameManager.EgameStates>
{
    public enum EgameStates
    {
        start,
        pick,
        battle,
        end

    }
    [Header("ParametrsForAll")]
    [SerializeField] private Text debugText;
    [Space(5f)]

    [Header("startGameContext")]
    [SerializeField] private Text startText;
    [Space(5f)]
    [Header("pickGameContext")]
    [SerializeField] private GameObject pickPanel;
    [SerializeField] private inventoryController invController;

    [Space(5f)]
    [Header("battleStateContext")]
    [SerializeField] private GameObject battlePanel;
    [SerializeField] private battleManager battle_manager;
    [SerializeField] private BaceEnemy enemy;

    private battleContext battle_context;
    private endGameContext end_game_context;
    private pickGameContext pick_game_context;
    private startGameContext start_game_context;
    private pick_queue Pick_queue;
    public void Awake(){
        ValidateConstraints();
        
        InitializeStates();
        
    }

    
    private void ValidateConstraints(){
        //Assert.IsNotNull(RB, "Rigedbody is not assignet");
        //Assert.IsNotNull(graphObj, "graphObj is not assignet");
        //Assert.IsNotNull(anim, "anim is not assignet");
    }
    private void InitializeStates(){
        Pick_queue = new pick_queue(new int[4]{0,0,0,0});
        battle_context = new battleContext(debugText, Pick_queue, battle_manager, battlePanel, enemy);
        end_game_context = new endGameContext(debugText);
        pick_game_context = new pickGameContext(debugText, pickPanel, invController,Pick_queue, enemy);
        start_game_context = new startGameContext(debugText, startText);
        

        States.Add(EgameStates.battle, new battleState(battle_context, EgameStates.battle));
        States.Add(EgameStates.start, new startGameState(start_game_context, EgameStates.start));
        States.Add(EgameStates.pick, new pickGameState(pick_game_context, EgameStates.pick));
        States.Add(EgameStates.end, new endGameState(end_game_context, EgameStates.end));

        
        
        CurrentState = States[EgameStates.start];
    }
}
