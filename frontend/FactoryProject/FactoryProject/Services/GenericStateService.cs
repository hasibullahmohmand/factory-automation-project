namespace FactoryProject.Services;

public class GenericStateService<T>
{
    public string SuccessMessage { get; set; } = string.Empty;
    public string ErrorMessage { get; set; } = string.Empty;
    private List<T> _models = [];
    public event Action? OnBooksChanged;
    public List<T> Models
    {
        get => _models;
        set
        {
            _models = value;
            OnBooksChanged?.Invoke();
        }
    }
    public void SetBooks(List<T> models)
    {
        Models = models;
    }
    public void AddBook(T model)
    {
        //book.Id = _books.Count > 0 ? _books.Max(b => b.Id) + 1 : 1; // Assign a new ID
        _models.Add(model);
        var msg = $"An new item is successfully added.";
        SetSuccessMessage(msg);
        OnBooksChanged?.Invoke();
    }
    public void Remove(T model)
    {
       
        if (model == null) return;
        _models.Remove(model);
        var msg = $"An item is successfully deleted.";
        SetSuccessMessage(msg);
        OnBooksChanged?.Invoke();
    }
    public void Update(T model, int index)
    {
        if (index != -1)
        {
            _models[index] = model;
            var msg = $"An item is successfully deleted.";
            SetSuccessMessage(msg);
            OnBooksChanged?.Invoke();
        }
    }
    
    private void SetSuccessMessage(string message)
    {
        SuccessMessage = message;
        Task.Run(async () =>
        {
            await Task.Delay(5000);//5 seconds delay
            Reset();
        });
    }
    private void Reset()
    {
        SuccessMessage = string.Empty;
    }
}