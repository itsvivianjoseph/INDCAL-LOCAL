// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
// using System.IO;
// using Logic;

// namespace ReadingDataFromCSV
// {
//     internal class Program
//     {
//         static void Main(string[] args)
//         {
//             string filePath = @"C:\Users\ViVian\Downloads\smilessss1 (1).csv";
//             StreamReader reader = null;
//             int j=-1;
//             List<WeightedGraph> inputobj = new List<WeightedGraph>();
//             if (File.Exists(filePath)){
//                 reader = new StreamReader(File.OpenRead(filePath));
//                 List<string> listA = new List<string>();
//                 while (!reader.EndOfStream){
//                     var line = reader.ReadLine();
//                     var values = line.Split(',');
//                     Console.WriteLine(values[0]);
                    
//                     j+=1;
//                     Console.WriteLine(j+"th time");
//                     inputobj.Add(new WeightedGraph());
//                     inputobj[j].initiateVertex(values[0]);
//                     inputobj[j].readSmiles(values[0]);
//                     inputobj[j].adjacencyMatrix(values[0]);
//                     // foreach (var item in values){
//                     // listA.Add(item);
//                     // }
//                     // foreach (var coloumn1 in listA){
//                     // Console.Write(coloumn1);
//                     // Console.WriteLine();
//                     // }
//                 }
//             } else {
//                 Console.WriteLine("File doesn't exist");
//             }
//             Console.ReadLine();
//         }
//     }
// }