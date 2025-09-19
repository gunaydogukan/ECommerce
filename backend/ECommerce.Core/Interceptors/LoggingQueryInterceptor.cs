using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

namespace ECommerce.Core.Interceptors;

public class LoggingQueryInterceptor : DbCommandInterceptor
{
    public override InterceptionResult<DbDataReader> ReaderExecuting(
    DbCommand command,
    CommandEventData eventData,
    InterceptionResult<DbDataReader> result)
    {
        Console.WriteLine($"[QUERY] {command.CommandText}");
        return base.ReaderExecuting(command, eventData, result);
    }

    public override async ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<DbDataReader> result,
        CancellationToken cancellationToken = default)
    {
        Console.WriteLine($"[QUERY-ASYNC] {command.CommandText}");
        return await base.ReaderExecutingAsync(command, eventData, result, cancellationToken);
    }

    public override InterceptionResult<int> NonQueryExecuting(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<int> result)
    {
        Console.WriteLine($"[NON-QUERY] {command.CommandText}");
        return base.NonQueryExecuting(command, eventData, result);
    }

    public override async ValueTask<InterceptionResult<int>> NonQueryExecutingAsync(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        Console.WriteLine($"[NON-QUERY-ASYNC] {command.CommandText}");
        return await base.NonQueryExecutingAsync(command, eventData, result, cancellationToken);
    }

    public override InterceptionResult<object> ScalarExecuting(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<object> result)
    {
        Console.WriteLine($"[SCALAR] {command.CommandText}");
        return base.ScalarExecuting(command, eventData, result);
    }

    public override async ValueTask<InterceptionResult<object>> ScalarExecutingAsync(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<object> result,
        CancellationToken cancellationToken = default)
    {
        Console.WriteLine($"[SCALAR-ASYNC] {command.CommandText}");
        return await base.ScalarExecutingAsync(command, eventData, result, cancellationToken);
    }
}