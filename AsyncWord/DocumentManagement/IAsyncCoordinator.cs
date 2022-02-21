namespace AsyncWord.DocumentManagement;

/// <summary>
/// Координатор асинхронных задач
/// </summary>
/// <remarks>
/// Служит для настройки очереди выполнения параллельных асинхронных задач
/// </remarks>
public interface IAsyncCoordinator
{
    /// <summary>
    /// Возвращает набор задач для асинхронного выполнения
    /// </summary>
    Task[] PrepareTasks();
}