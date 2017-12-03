using System;
using System.Collections.Generic;
using System.Linq;

namespace ProblemSets {
    public static class Day2 {

        public static class FirstProblem
        {
            //Correct: 51139

            public static double Run()
            {

                double answer = 0;

                var spreadsheet = ReadFileToSpreadsheet(@"../../DataFiles/Day2_P1.txt");

                for (var i = 0; i < spreadsheet.Count; i++)
                {
                    //row by row
                    var min = spreadsheet[i].Min();
                    var max = spreadsheet[i].Max();
                    
                    answer += max - min;
                }

                return answer;
            }
        }

        public static class SecondProblem
        {
            //Correct: 272

            public static double Run()
            {
                double answer = 0;

                var spreadsheet = ReadFileToSpreadsheet(@"../../DataFiles/Day2_P1.txt");

                for ( var i = 0; i < spreadsheet.Count; i++ ) {
                    for (int j = 0; j < spreadsheet[i].Count; j++){
                        for (int k = 0; k < spreadsheet[i].Count; k++){

                            if(k == j) continue;

                            if (spreadsheet[i][j] % spreadsheet[i][k] != 0) continue;

                            answer += spreadsheet[i][j] / spreadsheet[i][k];
                            break;
                        }
                    }
                }
                return answer;
            }
        }
        

        private static List<List<double>> ReadFileToSpreadsheet(string fileLocation)
        {
            string line;
            var table = new List<List<double>>();

            // Read the file and display it line by line.  
            var file = new System.IO.StreamReader(fileLocation);

            while ( (line = file.ReadLine()) != null )
            {
                var rows = new List<double>();

                var t = line.Split('\t');

                rows.AddRange(t.Select(t1 => Convert.ToDouble(t1)));

                table.Add(rows);
            }

            file.Close();

            return table;
        }
    }
}
