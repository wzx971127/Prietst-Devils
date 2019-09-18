using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mygame;
 
public class Model : MonoBehaviour {
 
    Stack<GameObject> start_priests = new Stack<GameObject>();
    Stack<GameObject> end_priests = new Stack<GameObject>();
    Stack<GameObject> start_devils = new Stack<GameObject>();
    Stack<GameObject> end_devils = new Stack<GameObject>();
 
    GameObject[] boat = new GameObject[2];
    GameObject boat_obj;
    public float speed = 50;

    SSDirector one;
 
    //对象的位置
    Vector3 boatStartPos = new Vector3(-6, 0, 0);
    Vector3 boatEndPos = new Vector3(6, 0, 0);
    Vector3 sideStartPos = new Vector3(-10, 0, 0);
    Vector3 sideEndPos = new Vector3(10, 0, 0);
 
    float gap = 1.1f;
    Vector3 priestsStartPos = new Vector3(-11, 1, 0);
    Vector3 priestsEndPos = new Vector3(13, 1, 0);
    Vector3 devilsStartPos = new Vector3(-7, 1, 0);
    Vector3 devilsEndPos = new Vector3(10, 1, 0);
    
 
    // Use this for initialization
    void Start () {
		one = SSDirector.GetInstance();
        one.setModel(this);
        loadSrc();
	}
	
	// Update is called once per frame
	void Update () {
        setposition(start_priests, priestsStartPos);
        setposition(end_priests, priestsEndPos);
        setposition(start_devils, devilsStartPos);
        setposition(end_devils, devilsEndPos);
 
        if(one.state == State.SE_move)
        {
            boat_obj.transform.position = Vector3.MoveTowards(boat_obj.transform.position, boatEndPos, Time.deltaTime * speed);
            if (boat_obj.transform.position == boatEndPos)
            {
                one.state = State.End;
            }
        }
        else if(one.state == State.ES_move)
        {
            boat_obj.transform.position = Vector3.MoveTowards(boat_obj.transform.position, boatStartPos, Time.deltaTime * speed);
            if (boat_obj.transform.position == boatStartPos)
            {
                one.state = State.Start;
            }
        }
        else
        {
            check();
        }
	}
 
    //加载游戏对象
    void loadSrc()
    {   
        //sides
        Instantiate(Resources.Load("sides"), sideStartPos, Quaternion.identity);
        Instantiate(Resources.Load("sides"), sideEndPos, Quaternion.identity);
 
        //boat
        boat_obj = Instantiate(Resources.Load("boat"), boatStartPos, Quaternion.identity) as GameObject;
        
        //prisets and devils
        for(int i = 0; i < 3; i++)
        {
            start_priests.Push(Instantiate(Resources.Load("Priests")) as GameObject);
            start_devils.Push(Instantiate(Resources.Load("Devils")) as GameObject);
        }
    }
 
    void setposition(Stack<GameObject> aaa, Vector3 pos)
    {
        GameObject[] temp = aaa.ToArray();
        for(int i = 0; i < aaa.Count; i++)
        {
            temp[i].transform.position = pos + new Vector3(-gap * i, 0, 0);
        }
    }
 
    //上船
    void getOnTheBoat(GameObject obj)
    {
        obj.transform.parent = boat_obj.transform;
        if(boatNum() != 0)
        {
            if (boat[0] == null)
            {
                boat[0] = obj;
                obj.transform.localPosition = new Vector3(-0.3f, 2.5f, 0);
            }
            else
            {
                boat[1] = obj;
                obj.transform.localPosition = new Vector3(0.3f, 2.5f, 0);
            }
        }
    }
    //判断船上是否有空位
    int boatNum()
    {
        int num = 0;
        for(int i = 0; i < 2; i++)
        {
            if (boat[i] == null)
            {
                num++;
            }
        }
        return num;
    }
 
    //船移动
    public void moveBoat()
    {
        if(boatNum() != 2)
        {
            if(one.state == State.Start)
            {
                one.state = State.SE_move;
            }
            else if(one.state == State.End)
            {
                one.state = State.ES_move;
            }
        }
    }
 
    //下船
    public void getOffTheBoat(int side)
    {
        if (boat[side] != null)
        {
            boat[side].transform.parent = null;
            if(one.state == State.Start)
            {
                if (boat[side].tag == "Priests")
                {
                    start_priests.Push(boat[side]);
                }
                else
                {
                    start_devils.Push(boat[side]);
                }
            }
            else if(one.state == State.End)
            {
                if (boat[side].tag == "Priests")
                {
                    end_priests.Push(boat[side]);
                }
                else
                {
                    end_devils.Push(boat[side]);
                }
            }
            boat[side] = null;
        }
    }
 
    void check()
    {   
        if(end_devils.Count == 3 && end_priests.Count == 3)
        {
            one.state = State.Win;
            return;
        }
 
        int bp = 0, bd = 0;
        for(int i = 0; i < 2; i++)
        {
            if (boat[i] != null && boat[i].tag == "Priests")
            {
                bp++;
            }
            else if (boat[i] != null && boat[i].tag == "Devils")
            {
                bd++;
            }
        }
 
        int sp = 0, sd = 0, ep = 0, ed = 0;
        if(one.state == State.Start)
        {
            sp = start_priests.Count + bp;
            ep = end_priests.Count;
            sd = start_devils.Count + bd;
            ed = end_devils.Count;
        }
        else if(one.state == State.End)
        {
            sp = start_priests.Count;
            ep = end_priests.Count + bp;
            sd = start_devils.Count;
            ed = end_devils.Count + bd;
        }
 
        if((sp != 0 && sp < sd) || (ep != 0 && ep < ed))
        {
            one.state = State.Lose;
        }
    }
 
    //游戏对象从岸上到船上的变化
    public void priS()
    {
        if(start_priests.Count != 0 && boatNum() != 0 && one.state == State.Start)
        {
            getOnTheBoat(start_priests.Pop());
        }
    }
    public void priE()
    {
        if(end_priests.Count != 0 && boatNum() != 0 && one.state == State.End)
        {
            getOnTheBoat(end_priests.Pop());
        }
    }
    public void delS()
    {
        if(start_devils.Count != 0 && boatNum() != 0 && one.state == State.Start)
        {
            getOnTheBoat(start_devils.Pop());
        }
    }
    public void delE()
    {
        if(end_devils.Count != 0 && boatNum() != 0 && one.state == State.End)
        {
            getOnTheBoat(end_devils.Pop());
        }
    }
 
    //重置游戏
    public void Reset()
    {
        boat_obj.transform.position = boatStartPos;
        one.state = State.Start;
 
        int num1 = end_devils.Count, num2 = end_priests.Count;
        for(int i = 0; i < num1; i++)
        {
            Debug.Log(i);
            start_devils.Push(end_devils.Pop());
        }
 
        for (int i = 0; i < num2; i++)
        {
            start_priests.Push(end_priests.Pop());
        }

        getOffTheBoat(0);
        getOffTheBoat(1);
    }
}
