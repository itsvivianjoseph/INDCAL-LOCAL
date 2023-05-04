using Logic;
class inputClass
{
    static void Main(string[] args)
    {
        List<WeightedGraph> inputobj = new List<WeightedGraph>();
        int option ;
        int j=-1;
        string inputSmiles = "";
        do{
        Console.WriteLine("enter the option : \n1)input smiles notation\n2)print adjacency matrix\n3)print distance matrix\n4)print implicit hydrogens\n5)print zagreb index\n6)print connectivity index\n7)is the matrix symmetric");
        option = Convert.ToInt32(Console.ReadLine());
        switch (option) 
        {
            case 1:
                Console.WriteLine("ENTER THE INPUT SMILES NOTATION : ");
                inputSmiles = Console.ReadLine();
                Validation validate = new Validation();
                if(!string.IsNullOrEmpty(inputSmiles) && validate.isValid(inputSmiles))
                {   
                    j+=1;
                    inputobj.Add(new WeightedGraph());
                    inputobj[j].initiateVertex(inputSmiles);
                    inputobj[j].readSmiles(inputSmiles);
                }
                else Console.WriteLine("ENTER A PROPER INPUT");
                Console.WriteLine();
                break;
            case 2:
                Console.WriteLine("ADJACENCY MATRIX : ");
                int[,] adjacencyMatrix = inputobj[j].adjacencyMatrix(inputSmiles);
                for(int i=0;i<adjacencyMatrix.GetLength(0);i++)
                {
                    for(int k=0;k<adjacencyMatrix.GetLength(0);k++)
                    {
                        Console.Write(adjacencyMatrix[i,k]+" ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                break;
            case 3:
                Console.WriteLine("DISTANCE MATRIX : ");
                inputobj[j].GenerateDistanceMatrix(inputobj[j].adjacencyMatrix(inputSmiles));
                Console.WriteLine();
                break;
            case 4:
                Console.WriteLine("IMPLICIT HYDROGEN COUNT : ");
                inputobj[j].implicitHydrogenIndex(inputSmiles);
                Console.WriteLine();
                break;
            case 5:
                Console.WriteLine("ZAGREB INDEX : ");
                inputobj[j].zagrebIndex(inputobj[j].adjacencyMatrix(inputSmiles));
                Console.WriteLine();
                break;
            case 6:
                Console.WriteLine("CONNECTIVITY INDEX : ");
                inputobj[j].connectivityIndex(inputobj[j].adjacencyMatrix(inputSmiles));
                Console.WriteLine();
                break;
            case 7:
                inputobj[j].isSymmetric(inputobj[j].adjacencyMatrix(inputSmiles));
                Console.WriteLine();
                break;
            default:
                Console.WriteLine("INVALID OPTION");
                Console.WriteLine();
                break;
        }
        Console.WriteLine("DO YOU WANT TO CONTINUE (1/0) :");
        option = Convert.ToInt32(Console.ReadLine());
        }while(option>0);
    }
}