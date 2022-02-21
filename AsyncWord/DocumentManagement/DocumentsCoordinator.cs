namespace AsyncWord.DocumentManagement;

/// <summary>
/// Координатор асинхронных задач по формированию нового документа
/// </summary>
public class DocumentsCoordinator : IAsyncCoordinator
{
    private int _currentTask;
    private readonly object _locker = new();
    private readonly List<Action> _actions = new();
    
    public DocumentsCoordinator(IDocument document)
    {
        _actions.Add(document.Create);
        _actions.Add(document.Edit);
        _actions.Add(document.Save);
    }

    /// <summary>
    /// Возвращает набор шагов для асинхронного создания документа
    /// </summary>
    public Task[] PrepareTasks()
    {
        var tasks = new Task[_actions.Count];

        for (var i = 0; i < _actions.Count; i++)
            tasks[i] = ExecuteTask();

        return tasks;
    }

    /// <summary>
    /// Реализует асинхронный механизм очереди выполнения шагов по созданию документа
    /// </summary>
    /// <seealso cref="IDocument"/>
    private Task ExecuteTask()
    {
        lock (_locker)
        {
            _actions[_currentTask]();
            _currentTask++;
        }
        
        return Task.CompletedTask;
    }
}