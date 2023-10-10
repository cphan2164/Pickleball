using System.Xml;

namespace Pickleball;

public class Queue
{

    private const int avgGameLen = 20;
    private int numOfQueue;
    private List<Players> playerQueue;
    private int courts;
    private List<int[]> pastGames;
    public Queue(int courts)
    {
        this.courts = courts;
        numOfQueue = 0;
    }

    public void addPlayerQueue(Players player)
    {
        playerQueue.Add(player);
        numOfQueue++;
    }

    public int getNumQueue()
    {
        return numOfQueue;
    }

    public List<Players> getQueue()
    {
        return playerQueue;
    }

    public void setcourts(int courts)
    {
        this.courts = courts;
    }

    public void getNextGame()
    {
        if (playerQueue.Capacity < 4)
        {
         Console.WriteLine("Not enough players to play");
         return;
        }
        // Temp can't be sorted and keep the same order of queue. So you have to sort temp, but that means remake temp everytime
        int[] temp =
        {
            playerQueue[0].getidNum(), playerQueue[1].getidNum(), playerQueue[2].getidNum(), playerQueue[3].getidNum()
        };
        int[] temp2 = new int[4];
        Array.Copy(temp,0,temp2,0,4);
        Array.Sort(temp2);
        Players tempPlay;
        int game = checkGame(temp2);
        if (game == 1)
        {
            if (playerQueue.Capacity == 4)
            {
                game = 0;
            }
            else{
                temp[3] = playerQueue[4].getidNum();
                if (playerQueue.Capacity > 5)
                {
                    temp[2] = playerQueue[5].getidNum();
                }
                Array.Copy(temp,0,temp2,0,4);
                Array.Sort(temp2);
                game = checkGame(temp2);
                if (game == 0)
                {
                    tempPlay = playerQueue[3];
                    playerQueue[3] = playerQueue[4];
                    playerQueue[4] = tempPlay;
                    if (playerQueue.Capacity > 5)
                    {
                        tempPlay = playerQueue[5];
                        playerQueue[5] = playerQueue[2];
                        playerQueue[2] = tempPlay;
                    }
                }
                if (game == 1 && playerQueue.Capacity >= 7)
                {
                    temp[2] = playerQueue[6].getidNum();
                    Array.Copy(temp,0,temp2,0,4);
                    Array.Sort(temp2);
                    game = checkGame(temp2);
                    if (game == 0)
                    {
                        tempPlay = playerQueue[6];
                        playerQueue[6] = playerQueue[5];
                        playerQueue[5] = playerQueue[2];
                        playerQueue[2] = tempPlay;
                    }
                    if (game == 1 && playerQueue.Capacity >= 8)
                    {
                        temp[2] = playerQueue[7].getidNum();
                        Array.Copy(temp,0,temp2,0,4);
                        Array.Sort(temp2);
                        game = checkGame(temp2);
                        if (game == 0)
                        {
                            tempPlay = playerQueue[7];
                            playerQueue[7] = playerQueue[6];
                            playerQueue[6] = playerQueue[5];
                            playerQueue[5] = playerQueue[2];
                            playerQueue[2] = tempPlay;
                        }
                        if (game == 1)
                        {
                            temp[2] = playerQueue[2].getidNum();
                            temp[3] = playerQueue[3].getidNum();
                            Array.Copy(temp,0,temp2,0,4);
                            Array.Sort(temp2);

                        }

                    }
                }
                
            }
            
            
        }

        pastGames.Add(temp2);
        // Print game out cause it works
        Console.WriteLine("      *     ");
        Console.WriteLine("Players Playing Right Now:");
        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine(playerQueue[0].getName());
            playerQueue.RemoveAt(0);
        }
        Console.WriteLine("      *     ");

    }

    private int checkGame(int[] temp)
    {
        int gamesTog = 0;
        for(int i = 0; i<pastGames.Capacity; i++)
        {
            if (pastGames[i].SequenceEqual(temp))
            {
                gamesTog++;
                if (gamesTog > 1)
                {
                    return 1;
                }
            }
            
        }

        return 0;
    }

    public void resetGames()
    {
        pastGames.Clear();
    }
    
}