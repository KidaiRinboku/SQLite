using UnityEngine;
using SQLite;
using System.IO;

public class DatabaseManager : MonoBehaviour
{
    private SQLiteConnection db;

    void Start()
    {
        // データベースファイルへのパス
        //var dbPath = Path.Combine(Application.persistentDataPath, "game.db");
        var dbPath = Path.Combine("game.db");
        var db = new SQLiteConnection(dbPath);
        db.Execute("PRAGMA foreign_keys = ON");

        // テーブルの作成
        db.CreateTable<Item>();

        // データの挿入
        db.Insert(new Item {Name = "Dummy Item1" });
        db.Insert(new Item {Name = "Dummy Item2" });
        db.Insert(new Item {Name = "Dummy Item111" });
        // データの読み取りと表示
        var items = db.Table<Item>().ToList();
        items.ForEach(item => Debug.Log($"Item: {item.Id}, {item.Name}"));
        
        // テーブル削除
       // db.DropTable<Item>();

        db.Close();

    }

    // void OnDestroy()
    // {

    //     if (db != null)
    //     {
            
    //     }
    // }
}

public class Item
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
}
