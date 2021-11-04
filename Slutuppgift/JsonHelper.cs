using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutuppgift
{
    static class JsonHelper
    {
        public static void SerializeCostumes(List<Costume> costume)
        {
            var jsonString = JsonConvert.SerializeObject(costume);
            string filePath = @"C:\Code Skola\Slutuppgift\Slutuppgift\Costume.json";
            if (File.Exists(filePath) == false)
            {
                File.WriteAllText(filePath, jsonString);
            }
            else
            {
                File.Delete(filePath);
                File.WriteAllText(filePath, jsonString);
            }
        }
        public static void SerializeMembers(List<Member> members)
        {
            var jsonString = JsonConvert.SerializeObject(members);
            string filePath = @"C:\Code Skola\Slutuppgift\Slutuppgift\Member.json";
            if (File.Exists(filePath) == false)
            {
                File.WriteAllText(filePath, jsonString);
            }
            else
            {
                File.Delete(filePath);
                File.WriteAllText(filePath, jsonString);
            }
        }
        public static void DeserializeCostumes(Costume costume)
        {
            string filePath = @"C:\Code Skola\Slutuppgift\Slutuppgift\Costume.json";
            if (File.Exists(filePath) == false)
            {
                costume.StarterCostumes();
            }
            else
            {
                string jsonString = File.ReadAllText(filePath);
                costume.Costumes = JsonConvert.DeserializeObject<List<Costume>>(jsonString);
            }
        }
        public static void DeserializeMembers(User user)
        {
            string filePath = @"C:\Code Skola\Slutuppgift\Slutuppgift\Member.json";
            if (File.Exists(filePath) == false)
            {
                SerializeMembers(user.Members);
            }
            else
            {
                string jsonString = File.ReadAllText(filePath);
                user.Members = JsonConvert.DeserializeObject<List<Member>>(jsonString);
            }
        }
    }
}
