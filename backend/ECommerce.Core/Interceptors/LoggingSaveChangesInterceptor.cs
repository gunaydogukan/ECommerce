using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ECommerce.Core.Interceptors
{
    public class LoggingSaveChangesInterceptor : SaveChangesInterceptor
    {
        public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
        {
            Console.WriteLine($"SaveChanges: {result} kayıt işlendi.");
            return result;
        }

        public override ValueTask<int> SavedChangesAsync(
            SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"SaveChangesAsync: {result} kayıt işlendi.");
            return new ValueTask<int>(result);
        }
    }
}