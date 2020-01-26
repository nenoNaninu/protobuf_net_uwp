using GrpcGreeter;
using ProtoBuf;
using System.IO;
using UnityEngine;

public class SiriarizeTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var person = new Person
        {
            Id = 12345,
            Name = "しゃな～～～～～～～～～～",
            Address = new Address
            {
                Line1 = "たまし！",
                Line2 = "すわすわ！"
            }
        };

        var ms = new MemoryStream(256 * 1024);
        Serializer.Serialize(ms, person);
        ms.Position = 0;

        //var bytes = ms.ToArray();
        //Debug.Log(bytes.Length);

        var p2 = Serializer.Deserialize<Person>(ms);

        Debug.Log(p2.Name);
        Debug.Log(p2.Address.Line1);

        Debug.Log("===============");


        var r = new HelloReply();
        r.Message = "いやっほーーーーーーーーー照葉たそーーーー！！";
        
        ms.Position = 0;
        ms.SetLength(0);

        Serializer.Serialize(ms, r);

        Debug.Log(ms.ToArray().Length);

        ms.Position = 0;
        var r2 = Serializer.Deserialize<HelloReply>(ms);
        Debug.Log(r2.Message);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
