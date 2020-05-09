using System.IO;
using UnityEngine;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

public class MonsterFactory : MonoBehaviour
{
    string json;
    string path = "Prototype/Monsters.json";
    JArray monsters;

    Dictionary<string, Monster> monsterDic = new Dictionary<string, Monster>();

    private void Start()
    {
        path = Application.dataPath + "/" + path;

        json = File.ReadAllText(path);

        monsters = JArray.Parse(json);

        print(json);
        print(monsters);

        foreach(JObject jo in monsters)
        {
            JObject Prototype = null;
            JToken token;
            if(jo.TryGetValue("Prototype", out token))
            {
                foreach(JObject o in monsters)
                {
                    if((string)o.GetValue("Name") == (string)token)
                    {
                        Prototype = o;
                        break;
                    }
                }
            }

            monsterDic.Add((string)jo.GetValue("Name"), new Monster(jo, Prototype));
        }

        foreach(string key in monsterDic.Keys)
        {
            print(key);
            print(monsterDic[key].Info());
        }
    }

}
