using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace AsyncWord.DocumentManagement;

/// <summary>
/// Описание логики формирования документа Word
/// </summary>
public class WordDocument : IDocument
{
    private readonly string _name;
    private WordprocessingDocument _document;

    public WordDocument(string name)
    {
        _name = name;
    }
    
    /// <inheritdoc cref="IDocument.Create"/>
    public void Create()
    {
        _document = WordprocessingDocument.Create(_name, WordprocessingDocumentType.Document, false);
    }

    /// <inheritdoc cref="IDocument.Edit"/>
    public void Edit()
    {
        var mainPart = _document.AddMainDocumentPart();
        
        mainPart.Document = new Document();

        var body = mainPart.Document.AppendChild(new Body());
        var paragraph = body.AppendChild(new Paragraph());
        var run = paragraph.AppendChild(new Run());

        run.AppendChild(new Text("Hello, world!"));
    }

    /// <inheritdoc cref="IDocument.Save"/>
    public void Save()
    {
        _document.Save();
    }

    public void Dispose()
    {
        _document.Dispose();
        GC.SuppressFinalize(this);
    }
}