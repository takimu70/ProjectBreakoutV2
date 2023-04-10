using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{

    [SerializeField] private MonitorController monitor;

    [SerializeField] private List<MyCodeBlock> codeBlocks = new List<MyCodeBlock>();
    [SerializeField] private MyCodeBlock initCodeBlock;

    public string backupCodeBlock;

    private void Start()
    {
        backupCodeBlock = initCodeBlock.codeBlock;
    }

    public void AddCodeBlocksToMonitor()
    {
        monitor.computer = this;
        monitor.initialCodeBlock = initCodeBlock;
        monitor.validCodeBlocks.Clear();

        foreach(MyCodeBlock codeBlock in codeBlocks)
        {
            monitor.validCodeBlocks.Add(codeBlock);
            monitor.StartProgram();
        }
    }


}
