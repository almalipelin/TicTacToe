using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public int turn = 0;//0=X sýrasý, 1=O sýrasý
    public int moveCount = 0;//Beraberlik kontrolü için
    public TextMeshProUGUI[] buttonlist;//9 kutunun içindeki yazýlar
    public TextMeshProUGUI infoText;//"Sýra: X'te" yazýsý
    public GameObject restartButton;//Oyun bitince çýkacak buton
    public bool isGameActive = true;//Oyun devam ediyor mu?
    
    //Butonlara týkladýðýnda bu çalýþacak
    public void ClickButton(int index)
    {
        //Oyun bittiyse veya kutu doluysa dur
        if(!isGameActive || buttonlist[index].text != "")
            return;

        //Sýra kimdeyse onun harfini yaz
        if(turn == 0)
        {
            buttonlist[index].text = "X";
            infoText.text = "Sýra: X";
            turn = 1;
        }
        else
        {
            buttonlist[index].text = "O";
            infoText.text= "Sýra: O";
            turn = 0;
        }

        moveCount++;//Hamle sayýsýný artýr
        CheckWinner();//Biri kazandý mý kontrol et
    }

    void CheckWinner()
    {
        //Kazanma ihtimalleri(Yatay,Dikey,Çapraz kombinasyonlarý)
        int[][] winConditions = new int[][]
        {
            new int[] {0,1,2},new int[] {3,4,5},new int[] {6,7,8},//Yatay
            new int[] {0,3,6},new int[] {1,4,7},new int[] {2,5,8},//Dikey
            new int[] {0,4,8},new int[] {2,4,6}//Çapraz
        };

        foreach(var condition in winConditions)
        {
            //Eðer 3 kutu da aynýysa ve boþ deðilse
            if (buttonlist[condition[0]].text == buttonlist[condition[1]].text && buttonlist[condition[1]].text == buttonlist[condition[2]].text &&
                buttonlist[condition[0]].text != "")
            {
                GameOver(buttonlist[condition[0]].text + " KAZANDI!");
                return;
            }
        }

        //9 hamle oldu ve kazanan yoksa
        if(moveCount >= 9)
        {
            GameOver("BERABERE!");
        }
    }

    void GameOver(string message)
    {
        isGameActive = false;
        infoText.text = message;
        restartButton.SetActive(true);//Restart butonunu aç
    }

    //Restart butonuna baðlanacak fonksiyon
    public void RestartGame() 
    {
        turn = 0;
        moveCount = 0;
        isGameActive = true;
        infoText.text = "Sýra: X";//Butonu gizle

        foreach(var btn in buttonlist)
        {
            btn.text = "";
        }
    }
}
