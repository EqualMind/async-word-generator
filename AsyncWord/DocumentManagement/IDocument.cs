namespace AsyncWord.DocumentManagement;

/// <summary>
/// Общий интерфейс для реализации логики работы с документом
/// </summary>
/// <remarks>
/// По упрощенной логике, он всегда реализует следующие действия: создание, изменение, сохранение.
/// </remarks>
public interface IDocument: IDisposable
{
    /// <summary>
    /// Создание документа
    /// </summary>
    void Create();
    
    /// <summary>
    /// Изменение документа
    /// </summary>
    void Edit();
    
    /// <summary>
    /// Сохранение документа
    /// </summary>
    void Save();
}