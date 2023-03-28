public class FileReader
{
    private string fileContents;

    public string ReadFromFile(string filePath)
    {
        Console.WriteLine("Dosyadan okundu.");
        return fileContents;
    }
}


public class FileWriter
{
    public void WriteToFile(string filePath, string contents)
    {
        Console.WriteLine("Dosyaya yazıldı.");
    }
}


public class FileProcessor
{
    private readonly FileReader _fileReader;
    private readonly FileWriter _fileWriter;

    public FileProcessor(FileReader fileReader, FileWriter fileWriter)
    {
        _fileReader = fileReader;
        _fileWriter = fileWriter;
    }

    public void CopyFileContents(string sourceFilePath, string destinationFilePath)
    {
        string fileContents = _fileReader.ReadFromFile(sourceFilePath);
        _fileWriter.WriteToFile(destinationFilePath, fileContents);
    }
}