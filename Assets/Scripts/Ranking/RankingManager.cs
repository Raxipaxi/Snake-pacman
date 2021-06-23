using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingManager : MonoBehaviour
{
    QueueTF queue = new QueueTF();
    public List<GameObject> rankingRowElements;
    public GameObject inputField;
    public string ingresoDelNickname;
    private MiniGameManager miniGameManager;
 
    void Start()
    {
        miniGameManager = gameObject.AddComponent<MiniGameManager>();

        queue.InitiaiizeQueue();
        var list = Database.current.GetAllRankings();
        foreach(var player in list)
        {
            queue.Enqueue(player);         
        }
        UpdateSceen();
    }

   
    public void StoreName()
    {
        ingresoDelNickname = inputField.GetComponent<Text>().text;
        Debug.Log(ingresoDelNickname);
    }

    public void AddPlayerOnRanking()
    {
        var player = new Player();
       
        player.Score = miniGameManager.TotalRecordLlegado;

        player.Nickname = ingresoDelNickname;
        if (player.Nickname != string.Empty)
        {
            Database.current.InsertRanking(player);
            player = Database.current.GetLatestRanking();
            queue.Enqueue(player);
            UpdateSceen();
        }
        player.Score = 0;
        // PrintQueue()
    }

    public void RemovePlayerFromRanking()
    {
        var player = queue.DequeueWithReturn();
        Database.current.DeleteRanking(player);
        UpdateSceen();
        //PrintQueue();
    }

    public void ResetRanking()
    {
        queue.InitiaiizeQueue();
        UpdateSceen();
        Database.current.DropTableRanking();
        Database.current.CreateTableRanking();

    }

    private void PrintQueue()
    {
        foreach( var player in queue.GetRanking() )
        {
            if(player != null)
            {
                Debug.Log(string.Format("nickname: {0} - level: {1} - score: {2}", player.Nickname, player.Level, player.Score));
            }
        }
    }

    private void UpdateSceen()
    {
        var ranking = queue.GetRanking();

        for(int i=0; i<5; i++)
        {
            rankingRowElements[i].GetComponent<RankingElement>().SetDefaultText();

            if(ranking[i] != null)
            {
                rankingRowElements[i].GetComponent<RankingElement>().SetInfo(
                    ranking[i].Nickname,
                    ranking[i].Level,
                    ranking[i].Score
                );
            }
        }
    }
}