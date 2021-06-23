using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Database : MonoBehaviour
{
    static public Database current;

    private string path;
    private IDbConnection connection;

    public void Awake()
    {
        if (current != null) Destroy(this.gameObject);
        current = this;

        path = $"URI=file:{Application.dataPath}/Ranking2021.s3db";

        //DropTableRanking();
        CreateTableRanking();
    }

    #region DATABASE_COMUNICATION

    private void StablishConnection()
    {
        connection = new SqliteConnection(path);
    }

    private void SetQueries(string query)
    {
        try
        {
            StablishConnection();
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = query;
            command.ExecuteReader();

            command.Dispose();
            command = null;
        }
        catch (System.Exception e)
        {
            Debug.LogError(e.Message);
            throw;
        }
        finally
        {
            connection.Close();
            connection = null;
        }
    }

    private List<string> GetQueries(string query, int atributesCount)
    {
        var list = new List<string>();

        try
        {
            StablishConnection();
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = query;
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                string tupla = string.Empty;

                for (int i = 0; i < atributesCount; i++)
                {
                    tupla += $"{reader.GetValue(i).ToString()}/";
                }

                list.Add(tupla);
            }

            command.Dispose();
            command = null;
        }
        catch (System.Exception e)
        {
            Debug.LogError(e.Message);
            throw;
        }
        finally
        {
            connection.Close();
            connection = null;
        }

        return list;
    }

    #endregion

    #region SET_TYPE_QUERIES

    public void CreateTableRanking()
    {
        string query = "CREATE TABLE IF NOT EXISTS Ranking (" +
            "Id INTEGER PRIMARY KEY AUTOINCREMENT," +
            "Name VARCHAR(75) NOT NULL," +
            "Level INTEGER NOT NULL," +
            "Score INTEGER NOT NULL)";
        SetQueries(query);
    }

    public void DropTableRanking()
    {
        string query = "DROP TABLE IF EXISTS Ranking";
        SetQueries(query);
    }

    public void InsertRanking(Player player)
    {
        string query = "INSERT INTO Ranking (Name, Level, Score) " +
                        $"VALUES('{player.Nickname}', {player.Level}, {player.Score})";
        SetQueries(query);
    }

    public void DeleteRanking(Player player)
    {
        string query = $"DELETE FROM Ranking WHERE ID = {player.Id}";
        SetQueries(query);
    }

    #endregion

    #region GET_TYPE_QUERIES

    public List<Player> GetAllRankings()
    {
        var playerList = new List<Player>();
        var query = "SELECT Id, Name, Level, Score FROM Ranking ";
        var list = GetQueries(query, 4);

        foreach (var tupla in list)
        {
            var values = tupla.Split('/');

            var player = new Player() { 
                Nickname = values[1],
                Level = int.Parse(values[2]),
                Score = int.Parse(values[3])
            };
            
            player.Id = int.Parse(values[0]);
            playerList.Add(player);
        }

        return playerList;
    }

    public Player GetRankingById(int id)
    {
        var playerList = new List<Player>();
        Player player = null;

        var query = $"SELECT Id, Name, Level, Score FROM Ranking WHERE Id = {id}";
        var list = GetQueries(query, 4);

        foreach (var tupla in list)
        {
            var values = tupla.Split('/');

            player = new Player()
            {
                Nickname = values[1],
                Level = int.Parse(values[2]),
                Score = int.Parse(values[3])
            };

            player.Id = int.Parse(values[0]);
        }

        return player;
    }

    public Player GetLatestRanking()
    {
        var playerList = new List<Player>();
        Player player = null;

        var query = $"SELECT Id, Name, Level, Score FROM Ranking ORDER BY Id DESC LIMIT 1;";
        var list = GetQueries(query, 4);

        foreach (var tupla in list)
        {
            var values = tupla.Split('/');

            player = new Player()
            {
                Nickname = values[1],
                Level = int.Parse(values[2]),
                Score = int.Parse(values[3])
            };

            player.Id = int.Parse(values[0]);
        }

        return player;
    }

    #endregion
}
