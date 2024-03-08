using System.Diagnostics.CodeAnalysis;
using System.Text;
using Masa.Blazor.Pro.Components.Models;
using SQLite;

namespace Masa.Blazor.Pro.Components;

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

    public ProDatabase()
    {
        DatabasePath = DatabaseFilename;
    }

    public ProDatabase(string dir)
    {
        DatabasePath = Path.Combine(dir, DatabaseFilename);
    }

    public string DatabasePath { get; private set; }

    private SQLiteAsyncConnection? Database { get; set; }

    [MemberNotNull(nameof(Database))]
    async Task InitAsync()
    {
        if (Database is not null)
        {
            return;
        }

        Database = new SQLiteAsyncConnection(DatabasePath, Flags);
        await Database.CreateTableAsync<TodoTask>();
        await Database.CreateTableAsync<TodoTag>();
    }

    #region Todo task

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
    
    public async Task DeleteTaskAsync(TodoTask task)
    {
        await InitAsync();
        await Database.DeleteAsync(task);
    }

    public async Task<List<TodoTask>> GetTasksAsync(
        int page,
        int pageSize,
        DateTime dateTime = default,
        int tag = 0,
        TodoTaskPriority? priority = null)
    {
        await InitAsync();

        var sqlBuilder = new StringBuilder();
        sqlBuilder.Append("SELECT * FROM [TodoTask]");

        var hasWhere = false;

        if (dateTime != default)
        {
            hasWhere = true;

            var tick = dateTime.AddDays(1).Ticks;
            sqlBuilder.Append(" WHERE [DueAt] < ").Append(tick);
        }

        if (tag != 0)
        {
            sqlBuilder.Append(hasWhere ? " AND" : " WHERE");
            sqlBuilder.Append(" [Tags] LIKE '%").Append(tag).Append(";%'");
        }

        if (priority is not null)
        {
            sqlBuilder.Append(hasWhere ? " AND" : " WHERE");
            sqlBuilder.Append(" [Priority] = ").Append((int)priority);
        }

        sqlBuilder.Append(" ORDER BY [DueAt] DESC");
        sqlBuilder.Append(" LIMIT ").Append(pageSize).Append(" OFFSET ").Append((page - 1) * pageSize);

        return await Database.QueryAsync<TodoTask>(sqlBuilder.ToString());
    }

    #endregion

    #region Todo tag

    public async Task<int> CreateTagAsync(TodoTag tag)
    {
        await InitAsync();

        return await this.Database.InsertAsync(tag);
    }

    public async Task<List<TodoTag>> GetTagsAsync()
    {
        await InitAsync();

        return await Database.Table<TodoTag>().ToListAsync();
    }
    
    public async Task UpdateTagAsync(TodoTag tag)
    {
        await InitAsync();
        await Database.UpdateAsync(tag);
    }
    
    public async Task DeleteTagAsync(TodoTag tag)
    {
        await InitAsync();
        await Database.DeleteAsync(tag);
    }

    #endregion
}