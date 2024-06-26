/*
 * CSE 212 Lesson 6C
 *
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 *
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 *
 * Each row represents the player's stats for a single season with a single team.
 */


using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        var players = new Dictionary<string, int>();

        // this file was not located where it was looking so i had to modify this to get rid of the file not found exception.  This works on my machine this way.  It was looking inside the bin/debug folder
        using var reader = new TextFieldParser("../../../basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // ignore header row
        while (!reader.EndOfData) {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            var points = int.Parse(fields[8]);
            //check to see if player is in our map / dictionary already
            if(players.ContainsKey(playerId))
            {
                // add points to that player
                players[playerId] += points;
            }
            else
            {
                // player doesnt exist in map / dictionary
                players.Add(playerId, points);
            }
        }

        // store dictionary into an array
        // var highestScorersFirst = players.ToArray();

        //sort highestScorersFirst to make sure the highest scorers are actually first
        // Array.Sort(highestScorersFirst, (player1, player2) => player1.Value.CompareTo(player2.Value));
        // Array.Reverse(highestScorersFirst);
        // if you uncomment the above and comment the below you will get the actual requirements
        // I like the below better
        var highestScorersFirst = players.OrderByDescending(x => x.Value).ToArray();

        // output the top 10 players
        for(int i = 0; i < 10; i++)
        {
            Console.WriteLine(highestScorersFirst[i]);
        }
    }
}
