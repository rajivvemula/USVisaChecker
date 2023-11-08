using System.IO;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow.Infrastructure;

namespace BiBerkLOB.Source.Helpers;

public class DataFileSaver
{
    public static readonly string SAVE_DATA_DIR = Path.Combine(Directory.GetCurrentDirectory(), "SavedItems");

    private static SemaphoreSlim _fileLock = new(1, 1);

    public void SaveDataFile<TDataSource>(string fileName, TDataSource dataSource) where TDataSource : IDataSource
    {
        _fileLock.Wait();
        if (!Directory.Exists(SAVE_DATA_DIR))
        {
            Directory.CreateDirectory(SAVE_DATA_DIR);
        }

        var dataFile = Path.Combine(SAVE_DATA_DIR, $"SavedData-{fileName}.txt");
        File.AppendAllText(dataFile, dataSource.ToDataString() + '\n');

        _fileLock.Release();
    }
}

public interface IDataSource
{
    string ToDataString();
}