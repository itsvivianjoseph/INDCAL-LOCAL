// // // // // class Program
// // // // //     {
// // // // //         static void Main(string[] args)
// // // // //         {
// // // // //             // Example adjacency matrix of a molecular graph
// // // // //             int[,] adjMatrix = new int[,]
// // // // //             {{0, 1, 0, 0, 0, 0, 0, 0, 0, 0},
// // // // //             {1, 0, 1, 0, 0, 0, 0, 0, 0, 0},
// // // // //             {0, 1, 0, 1, 1, 0, 0, 0, 0, 0},
// // // // //             {0, 0, 1, 0, 0, 0, 0, 0, 0, 0},
// // // // //             {0, 0, 1, 0, 0, 1, 0, 0, 0, 1},
// // // // //             {0, 0, 0, 0, 1, 0, 1, 0, 0, 0},
// // // // //             {0, 0, 0, 0, 0, 1, 0, 1, 0, 0},
// // // // //             {0, 0, 0, 0, 0, 0, 1, 0, 1, 0},
// // // // //             {0, 0, 0, 0, 0, 0, 0, 1, 0, 1},
// // // // //             {0, 0, 0, 0, 1, 0, 0, 0, 1, 0}};

// // // // //             // Get the number of vertices in the graph
// // // // //             int n = adjMatrix.GetLength(0);

// // // // //             // Calculate the Randić index
// // // // //             double randicIndex = 0;
// // // // //             for (int i = 0; i < n; i++)
// // // // //             {
// // // // //                 for (int j = i + 1; j < n; j++)
// // // // //                 {
// // // // //                     if (adjMatrix[i, j] == 1)
// // // // //                     {
// // // // //                         int deg_i = 0, deg_j = 0;
// // // // //                         for (int k = 0; k < n; k++)
// // // // //                         {
// // // // //                             if (adjMatrix[i, k] == 1) deg_i++;
// // // // //                             if (adjMatrix[j, k] == 1) deg_j++;
// // // // //                         }
// // // // //                         randicIndex += 1/Math.Sqrt(deg_i * deg_j);
// // // // //                     }
// // // // //                 }
// // // // //             }

// // // // //             Console.WriteLine("Randić index of the graph: " + randicIndex);
// // // // //         }
// // // // //     }



// // // // using System;

// // // // namespace RandicIndex
// // // // {
// // // //     class Program
// // // //     {
// // // //         static void Main(string[] args)
// // // //         {
// // // //             // Example adjacency matrix of a molecular graph
// // // //             int[,] adjMatrix = new int[,]
// // // //             {{0, 1, 0, 0, 0, 0, 0, 0, 0, 0},
// // // //             {1, 0, 1, 0, 0, 0, 0, 0, 0, 0},
// // // //             {0, 1, 0, 1, 1, 0, 0, 0, 0, 0},
// // // //             {0, 0, 1, 0, 0, 0, 0, 0, 0, 0},
// // // //             {0, 0, 1, 0, 0, 1, 0, 0, 0, 1},
// // // //             {0, 0, 0, 0, 1, 0, 1, 0, 0, 0},
// // // //             {0, 0, 0, 0, 0, 1, 0, 1, 0, 0},
// // // //             {0, 0, 0, 0, 0, 0, 1, 0, 1, 0},
// // // //             {0, 0, 0, 0, 0, 0, 0, 1, 0, 1},
// // // //             {0, 0, 0, 0, 1, 0, 0, 0, 1, 0}};

// // // //             // Get the number of vertices in the graph
// // // //             int n = adjMatrix.GetLength(0);

// // // //             // Calculate the Randić index for up to 6 bonds/connectivity
// // // //             for (int k = 0; k <= 6; k++)
// // // //             {
// // // //                 double randicIndex = 0;
// // // //                 for (int i = 0; i < n; i++)
// // // //                 {
// // // //                     for (int j = i + 1; j < n; j++)
// // // //                     {
// // // //                         for (int p = 1; p <= k; p++)
// // // //                         {
// // // //                             if (adjMatrix[i, j] == p)
// // // //                             {
// // // //                                 int deg_i = 0, deg_j = 0;
// // // //                                 for (int q = 0; q < n; q++)
// // // //                                 {
// // // //                                     if (adjMatrix[i, q] > 0 && adjMatrix[i, q] <= p) deg_i++;
// // // //                                     if (adjMatrix[j, q] > 0 && adjMatrix[j, q] <= p) deg_j++;
// // // //                                 }
// // // //                                 randicIndex += 1.0 / (Math.Sqrt(deg_i) * Math.Sqrt(deg_j));
// // // //                             }
// // // //                         }
// // // //                     }
// // // //                 }
// // // //                 Console.WriteLine("Randić index for " + k + " bonds/connectivity: " + randicIndex);
// // // //             }
// // // //         }
// // // //     }
// // // // }
// // // using System;

// // // public class MCIcalculator
// // // {
// // //     // Calculate MCI for a given adjacency matrix
// // //     public static double CalculateMCI(int[,] adjMatrix)
// // //     {
// // //         int numAtoms = adjMatrix.GetLength(0);
// // //         double mci = 0.0;
        
// // //         // Calculate degrees of each atom
// // //         int[] degrees = new int[numAtoms];
// // //         for (int i = 0; i < numAtoms; i++)
// // //         {
// // //             degrees[i] = 0;
// // //             for (int j = 0; j < numAtoms; j++)
// // //             {
// // //                 if (adjMatrix[i,j] == 1)
// // //                 {
// // //                     degrees[i]++;
// // //                 }
// // //             }
// // //         }
        
// // //         // Calculate MCI using the formula
// // //         for (int i = 0; i < numAtoms; i++)
// // //         {
// // //             for (int j = i+1; j < numAtoms; j++)
// // //             {
// // //                 for (int k = j+1; k < numAtoms; k++)
// // //                 {
// // //                     for (int l = k+1; l < numAtoms; l++)
// // //                     {
// // //                         for (int m = l+1; m < numAtoms; m++)
// // //                         {
// // //                             for (int n = m+1; n < numAtoms; n++)
// // //                             {
// // //                                 double prod = 1.0;
// // //                                 prod *= degrees[i] * degrees[j] * degrees[k] * degrees[l] * degrees[m] * degrees[n];
// // //                                 prod = 1.0 / Math.Sqrt(prod);
// // //                                 Console.WriteLine(mci);
// // //                                 mci += prod;
// // //                             }
// // //                         }
// // //                     }
// // //                 }
// // //             }
// // //         }
        
// // //         return mci;
// // //     }
// // // }

// // // // Example usage
// // // public class Program
// // // {
// // //     static void Main(string[] args)
// // //     {
// // //        int[,] adjMatrix = new int[,]
// // //             {{0, 1, 0, 0, 0, 0, 0, 0, 0, 0},
// // //             {1, 0, 1, 0, 0, 0, 0, 0, 0, 0},
// // //             {0, 1, 0, 1, 1, 0, 0, 0, 0, 0},
// // //             {0, 0, 1, 0, 0, 0, 0, 0, 0, 0},
// // //             {0, 0, 1, 0, 0, 1, 0, 0, 0, 1},
// // //             {0, 0, 0, 0, 1, 0, 1, 0, 0, 0},
// // //             {0, 0, 0, 0, 0, 1, 0, 1, 0, 0},
// // //             {0, 0, 0, 0, 0, 0, 1, 0, 1, 0},
// // //             {0, 0, 0, 0, 0, 0, 0, 1, 0, 1},
// // //             {0, 0, 0, 0, 1, 0, 0, 0, 1, 0}};
        
// // //         double mci = MCIcalculator.CalculateMCI(adjMatrix);
        
// // //         Console.WriteLine("MCI: " + mci);
// // //     }
// // // }

// // using System;

// // public class RandicIndexCalculator
// // {
// //     // Calculate Randic connectivity index for a given adjacency matrix
// //     public static double CalculateRandicIndex(int[,] adjMatrix, int connectivity)
// //     {
// //         int numAtoms = adjMatrix.GetLength(0);
// //         double randicIndex = 0.0;
        
// //         // Calculate degrees of each atom
// //         int[] degrees = new int[numAtoms];
// //         for (int i = 0; i < numAtoms; i++)
// //         {
// //             degrees[i] = 0;
// //             for (int j = 0; j < numAtoms; j++)
// //             {
// //                 if (adjMatrix[i,j] == 1)
// //                 {
// //                     degrees[i]++;
// //                 }
// //             }
// //         }
        
// //         // Calculate Randic index using the formula
// //         for (int i = 0; i < numAtoms; i++)
// //         {
// //             for (int j = i+1; j < numAtoms; j++)
// //             {
// //                 double prod = 1.0;
// //                 for (int k = 1; k <= connectivity; k++)
// //                 {
// //                     prod *= degrees[i] * degrees[j];
// //                 }
// //                 prod = 1/Math.Sqrt(prod);
// //                 randicIndex += prod;
// //             }
// //         }
        
// //         return randicIndex;
// //     }
// // }

// // // Example usage
// // public class Program
// // {
// //     static void Main(string[] args)
// //     {
// //         int[,] adjMatrix = new int[,]
// //             {{0, 1, 0, 0, 0, 0, 0, 0, 0, 0},
// //             {1, 0, 1, 0, 0, 0, 0, 0, 0, 0},
// //             {0, 1, 0, 1, 1, 0, 0, 0, 0, 0},
// //             {0, 0, 1, 0, 0, 0, 0, 0, 0, 0},
// //             {0, 0, 1, 0, 0, 1, 0, 0, 0, 1},
// //             {0, 0, 0, 0, 1, 0, 1, 0, 0, 0},
// //             {0, 0, 0, 0, 0, 1, 0, 1, 0, 0},
// //             {0, 0, 0, 0, 0, 0, 1, 0, 1, 0},
// //             {0, 0, 0, 0, 0, 0, 0, 1, 0, 1},
// //             {0, 0, 0, 0, 1, 0, 0, 0, 1, 0}};
        
// //         for (int i = 0; i <= 6; i++)
// //         {
// //             double randicIndex = RandicIndexCalculator.CalculateRandicIndex(adjMatrix, i);
// //             Console.WriteLine("Psi " + i + ": " + randicIndex);
// //         }
// //     }
// // }
// using System;

// public class DistanceMatrixGenerator
// {
//     // Generate distance matrix from a given adjacency matrix
//     public static int[,] GenerateDistanceMatrix(int[,] adjMatrix)
//     {
//         int numAtoms = adjMatrix.GetLength(0);
//         int[,] distMatrix = new int[numAtoms, numAtoms];
        
//         // Initialize distance matrix with distances from adjacency matrix
//         for (int i = 0; i < numAtoms; i++)
//         {
//             for (int j = 0; j < numAtoms; j++)
//             {
//                 if (adjMatrix[i,j] == 1)
//                 {
//                     distMatrix[i,j] = 1;
//                     distMatrix[j,i] = 1;
//                 }
//                 else if (i == j)
//                 {
//                     distMatrix[i,j] = 0;
//                 }
//                 else
//                 {
//                     distMatrix[i,j] = int.MaxValue;
//                 }
//             }
//         }
        
//         // Update distance matrix using Floyd-Warshall algorithm
//         for (int k = 0; k < numAtoms; k++)
//         {
//             for (int i = 0; i < numAtoms; i++)
//             {
//                 for (int j = 0; j < numAtoms; j++)
//                 {
//                     if (distMatrix[i,k] != int.MaxValue && distMatrix[k,j] != int.MaxValue &&
//                         distMatrix[i,k] + distMatrix[k,j] < distMatrix[i,j])
//                     {
//                         distMatrix[i,j] = distMatrix[i,k] + distMatrix[k,j];
//                     }
//                 }
//             }
//         }
        
//         return distMatrix;
//     }
// }

// // Example usage
// public class Program
// {
//     static void Main(string[] args)
//     {
//         int[,] adjMatrix = {
//             {0 , 1 , 0 , 0},
//              {1 , 0 , 1 , 0},
//              {0 , 1,  0 , 1},
//              { 0,  0,  1,  0}
//         };
        
//         int[,] distMatrix = DistanceMatrixGenerator.GenerateDistanceMatrix(adjMatrix);
        
//         // Print out distance matrix
//         for (int i = 0; i < distMatrix.GetLength(0); i++)
//         {
//             for (int j = 0; j < distMatrix.GetLength(1); j++)
//             {
//                 Console.Write(distMatrix[i,j] + " ");
//             }
//             Console.WriteLine();
//         }
//     }
// }
