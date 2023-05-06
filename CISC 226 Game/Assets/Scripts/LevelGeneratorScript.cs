using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.SceneManagement;  // for keybaord commands for testing, can remove after

public class LevelGeneratorScript : MonoBehaviour
{
    // depends on size of a chunk (each prefab)
    public float offset;

    public int levelLength;

    // allChunks contains all of the map chunk prefabs
    public GameObject[] allChunks;
    public GameObject beginChunk, endChunk;

    // Each element in chunkDir corresponds to an element/map chunk in allChunks
    public char[,] chunkDir;

    private int chunksGenerated;
    private char outDir;
    private Vector2 nextChunkPos;

    public GameObject whiteGuard, blueGuard, greenGuard;

    public GameObject patrolPoint;

    private Queue<GameObject> last5Generated;

    public GameObject goldScriptObject;
    private GoldScript goldScript;
    public GameObject monkey;
    private MonkeyScript monkeyScript;

    public float difficulty;

    public GameObject goldPack1;
    public GameObject goldPack2;
    public GameObject locker;

    // Start is called before the first frame update
    void Start()
    {
        chunkDir = new char[7, 2]
        {
            // Format: InDir, outDir
            // inDir is the direction the player would be travelling through when entering the chunk
            // outDir is the direction the player would be travelling when exiting the chunk

            {'N', 'N'},  // Corresponds to StraightNS
            {'W', 'W'},  // Corresponds to StraightEW
            {'E', 'E'},  // Corresponds to StraightEW
            {'W', 'N'},  // Corresponds to CornerNE
            {'E', 'N'},  // Corresponds to CornerNW
            {'N', 'E'},  // Corresponds to CornerSE
            {'N', 'W'}  // Corresponds to CornerSW
        };

        // Generate a level at the start of the scene
        generateLevel();

        //temporary, delete this:
        goldScript = goldScriptObject.GetComponent<GoldScript>();
        monkeyScript = monkey.GetComponent<MonkeyScript>();
    }

    // Temporary, just for testing
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            PlayerPrefs.SetFloat("Floor", 0);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            PlayerPrefs.SetFloat("Floor", 7);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            PlayerPrefs.SetFloat("Floor", 15);
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            goldScript.gold += 100;
        }
    }

    public void generateLevel()
    {
        difficulty = PlayerPrefs.GetFloat("Floor");
        levelLength = getLevelLength();

        last5Generated = new Queue<GameObject>();
        chunksGenerated = 0;
        outDir = 'N';
        nextChunkPos = new Vector2(0f, 0f);

        Debug.Assert(levelLength >= 5);
        generatefirst5();
        Debug.Assert(chunksGenerated == 5);

        int rndChunk;
        WhiteGuardScript whiteGuardCloneScript;
        BlueGuardScript blueGuardCloneScript;
        GreenGuardScript greenGuardCloneScript;
        GameObject patrolPointClone;

        float whiteSpawnRate = getWhiteSpawnRate();
        float blueSpawnRate = getBlueSpawnRate();
        float greenSpawnRate = getGreenSpawnRate();

        while (chunksGenerated < levelLength)
        {
            rndChunk = Random.Range(0, allChunks.Length);

            if (chunkDir[rndChunk, 0] == outDir)
            {
                GameObject currMapChunk = (GameObject)Instantiate(allChunks[rndChunk], nextChunkPos, Quaternion.identity);  // Quaternion.identity means use the prefab's rotation

                // Update last5Generated queue
                last5Generated.Enqueue(currMapChunk);
                GameObject fifthLastChunk = last5Generated.Dequeue();

                // Spawn guard
                if (Random.Range(0f, 1f) < greenSpawnRate)
                {
                    greenGuardCloneScript = (GreenGuardScript)Instantiate(greenGuard, nextChunkPos, Quaternion.identity).GetComponentInChildren<GreenGuardScript>();
                    patrolPointClone = (GameObject)Instantiate(patrolPoint, nextChunkPos, Quaternion.identity);

                    greenGuardCloneScript.patrolPos1 = patrolPointClone.transform;
                    greenGuardCloneScript.patrolPos2 = fifthLastChunk.transform;
                }
                else if (Random.Range(0f, 1f) < blueSpawnRate)
                {
                    blueGuardCloneScript = (BlueGuardScript)Instantiate(blueGuard, nextChunkPos, Quaternion.identity).GetComponentInChildren<BlueGuardScript>();
                    patrolPointClone = (GameObject)Instantiate(patrolPoint, nextChunkPos, Quaternion.identity);

                    blueGuardCloneScript.patrolPos1 = patrolPointClone.transform;
                    blueGuardCloneScript.patrolPos2 = fifthLastChunk.transform;
                }
                else if (Random.Range(0f, 1f) < whiteSpawnRate)
                {
                    whiteGuardCloneScript = (WhiteGuardScript)Instantiate(whiteGuard, nextChunkPos, Quaternion.identity).GetComponentInChildren<WhiteGuardScript>();
                    patrolPointClone = (GameObject)Instantiate(patrolPoint, nextChunkPos, Quaternion.identity);

                    whiteGuardCloneScript.patrolPos1 = patrolPointClone.transform;
                    whiteGuardCloneScript.patrolPos2 = fifthLastChunk.transform;
                }
                
                
                // spawn gold
                else if (Random.Range(0f, 1f) < 0.3)
                {
                    Instantiate(goldPack1, nextChunkPos, Quaternion.identity);
                }
                else if (Random.Range(0f, 1f) < 0.3)
                {
                    Instantiate(goldPack2, nextChunkPos, Quaternion.identity);
                }
                //Spawn lockers
                else if (Random.Range(0f, 1f) < 0.3)
                {
                    // spawn lockers
                }


                outDir = chunkDir[rndChunk, 1];
                chunksGenerated++;

                switch (chunkDir[rndChunk, 1])
                {
                    case 'N':
                        nextChunkPos = new Vector2(nextChunkPos.x, nextChunkPos.y + offset);
                        break;
                    case 'E':
                        nextChunkPos = new Vector2(nextChunkPos.x + offset, nextChunkPos.y);
                        break;
                    case 'W':
                        nextChunkPos = new Vector2(nextChunkPos.x - offset, nextChunkPos.y);
                        break;
                    case 'S':
                        // Should never happen
                        Debug.LogError("Error, path going down");
                        break;
                }
            }
        }

        endLevel();

        // Update Pathfinding grid
        AstarPath.active.Scan();
    }

    private int getLevelLength()
    {
        return Mathf.RoundToInt(Mathf.Pow(-0.8f, (difficulty - 21f)) + 150);
    }

    private float getWhiteSpawnRate()
    {
        return -1 * Mathf.Pow(0.89f, difficulty + 10f) + 0.5f;
    }

    private float getBlueSpawnRate()
    {
        return -1 * Mathf.Pow(0.93f, difficulty + 19f) + 0.33f;
    }

    private float getGreenSpawnRate()
    {
        return -1 * Mathf.Pow(0.9f, difficulty + 3f) + 0.4f;
    }

    private void generatefirst5()
    {
        Vector2 startPos = new Vector2(0f, -1 * offset);
        Instantiate(beginChunk, startPos, Quaternion.identity);

        int rndChunk;
        while (chunksGenerated < 5)
        {
            rndChunk = Random.Range(0, allChunks.Length);

            if (chunkDir[rndChunk, 0] == outDir)
            {
                GameObject currMapChunk = (GameObject)Instantiate(allChunks[rndChunk], nextChunkPos, Quaternion.identity);  // Quaternion.identity means use the prefab's rotation

                outDir = chunkDir[rndChunk, 1];
                chunksGenerated++;

                switch (chunkDir[rndChunk, 1])
                {
                    case 'N':
                        nextChunkPos = new Vector2(nextChunkPos.x, nextChunkPos.y + offset);
                        break;
                    case 'E':
                        nextChunkPos = new Vector2(nextChunkPos.x + offset, nextChunkPos.y);
                        break;
                    case 'W':
                        nextChunkPos = new Vector2(nextChunkPos.x - offset, nextChunkPos.y);
                        break;
                    case 'S':
                        // Should never happen
                        Debug.LogError("Error, path going down");
                        break;
                }

                last5Generated.Enqueue(currMapChunk);
            }
        }
    }

    private void endLevel()
    {
        switch (outDir)
        {
            case 'N':
                Instantiate(endChunk, nextChunkPos, Quaternion.identity);
                break;
            case 'E':
                Instantiate(allChunks[4], nextChunkPos, Quaternion.identity);
                Instantiate(endChunk, new Vector2(nextChunkPos.x, nextChunkPos.y + offset), Quaternion.identity);
                break;
            case 'W':
                Instantiate(allChunks[3], nextChunkPos, Quaternion.identity);
                Instantiate(endChunk, new Vector2(nextChunkPos.x, nextChunkPos.y + offset), Quaternion.identity);
                break;
        }
    }
}
