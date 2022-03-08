using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler :MonoBehaviour
{
    private static ICommand btnX = new RunCommand();
    //private static ICommand btnJ = new Skill1Command(1);
    //private static ICommand btnU = new Skill1Command(2);
    //private static ICommand btnL = new Skill1Command(3);
    //private static ICommand btnT = new Skill1Command(4);
    private PlayerCtrl playerCtrl;
    public void Init()
    {
        playerCtrl=GetComponent<PlayerCtrl>();
    }
    void Start()
    {
        Init();
    }
    private void Update()
    {
        //∑¢≤º√¸¡Ó
        playerCtrl.command = HandleInput();
    }
    private ICommand HandleInput()
    {
        //if (Input.GetButtonDown("Jump")) return btnSpace;
        //if (Input.GetKeyDown(KeyCode.J)) return btnJ;
        //if (Input.GetKeyDown(KeyCode.U)) return btnU;
        //if (Input.GetKeyDown(KeyCode.L)) return btnL;
        //if (Input.GetKeyDown(KeyCode.T)) return btnT;
        //if (Input.GetKeyDown(KeyCode.E)) GetComponent<AttackCtrl>().Interrupt();
        return btnX;
    }
}
