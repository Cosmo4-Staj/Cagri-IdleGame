using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public Text totalMoney;
    public Text stoneworkerMoney;
    public Text minerMoney;
    public Text powerMoney;

    public int currentMoney = 0;

    public Button stoneworkerButton;
    public Button minerButton;
    public Button powerButton;
    public Button superworkerButton;

    public int stoneworker;
    public int miner;
    public int power;
    // Start is called before the first frame update
    void Start()
    {
        stoneworkerButton.interactable = false;
        minerButton.interactable = false;
        powerButton.interactable = false;
        superworkerButton.interactable = false;

        miner = 5;
        stoneworker = 7;
        power = 15;
    }

    // Update is called once per frame
    void Update()
    {
        totalMoney.text = currentMoney.ToString();
        
    }

    public void AddMoney(int moneyToAdd)
    {
        currentMoney += moneyToAdd;
        CheckMoney();
    }
    public void StoneworkerCheck()
    {
        stoneworker=int.Parse(stoneworkerMoney.text);
        Check(stoneworker);
        stoneworker += 3;
        stoneworkerMoney.text = stoneworker.ToString();
        CheckMoney();
    }
    public void MinerCheck()
    {
        miner=int.Parse(minerMoney.text);
        Check(miner);
        miner += 3;
        minerMoney.text = miner.ToString();
        CheckMoney();
    }
    public void PowerCheck()
    {
        power=int.Parse(powerMoney.text);
        Check(power);
        power += 3;
        powerMoney.text = power.ToString();
        CheckMoney();
    }
    public void Check(int cash)
    {
        if (currentMoney - cash < 0)
        {
            Debug.Log("Not enough money");
        }
        else
        {
            currentMoney -= cash;
            if (currentMoney - cash < 0)
            {
                stoneworkerButton.interactable = false;
                minerButton.interactable = false;
                powerButton.interactable = false;
            }
        }
    }

    void CheckMoney()
    {
        if (currentMoney >= stoneworker)
        {
            stoneworkerButton.interactable = true;
        }
        else if (currentMoney < stoneworker)
        {
            stoneworkerButton.interactable = false;
        }
        if (currentMoney >= miner)
        { 
            minerButton.interactable = true;
        }
        else if (currentMoney < miner)
        {
            minerButton.interactable = false;
        }
        if (currentMoney >= power)
        {
            powerButton.interactable = true;
        }
        else if (currentMoney < power)
        {
            powerButton.interactable = false;
        }

        
    }
}
