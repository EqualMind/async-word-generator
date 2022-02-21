using AsyncWord.DocumentManagement;

namespace AsyncWord;

public static class Program
{
    public static void Main(string[] args)
    {
        using var document = new WordDocument("HelloWorld_Document.docx");
        var coordinator = new DocumentsCoordinator(document);

        Task.WaitAll(coordinator.PrepareTasks());
    }
}