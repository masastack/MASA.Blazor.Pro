using System.Diagnostics.CodeAnalysis;
using Masa.Blazor.ProApp.Rcl.Models;
using SQLite;

namespace Masa.Blazor.ProApp.Rcl.Data;

public class ProDatabase
{
    public const string DatabaseFilename = "proapp.db";

    public const SQLiteOpenFlags Flags =
        // open the database in read/write mode
        SQLiteOpenFlags.ReadWrite |
        // create the database if it doesn't exist
        SQLiteOpenFlags.Create |
        // enable multi-threaded database access
        SQLiteOpenFlags.SharedCache;

    // public static string DatabasePath =>
    //     Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);

    private SQLiteAsyncConnection? Database { get; set; }

    [MemberNotNull(nameof(Database))]
    async Task InitAsync()
    {
        if (Database is not null)
        {
            return;
        }

        Database = new SQLiteAsyncConnection(DatabaseFilename, Flags);
        await Database.CreateTableAsync<TodoTask>();
    }

    public async Task<int> CreateTaskAsync(TodoTask task)
    {
        await InitAsync();
        return await Database.InsertAsync(task);
    }

    public async Task UpdateTaskAsync(TodoTask task)
    {
        await InitAsync();
        await Database.UpdateAsync(task);
    }

    public async Task<List<TodoTask>> GetTasksAsync(int page, int pageSize, DateTime dateTime = default)
    {
        await InitAsync();

        var table = Database.Table<TodoTask>();

        if (dateTime != default)
        {
            table = table.Where(u => u.DueAt.Date == dateTime.Date);
        }

        return await table
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
}