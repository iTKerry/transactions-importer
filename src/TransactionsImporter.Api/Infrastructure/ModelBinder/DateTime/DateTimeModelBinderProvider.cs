using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TransactionsImporter.Api.Infrastructure.ModelBinder.DateTime
{
    public class DateTimeModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            return IsDateTime(context.Metadata.ModelType)
                ? new DateTimeModelBinder()
                : null;
        }

        private static bool IsDateTime(Type modelType) =>
            modelType == typeof(System.DateTime) || modelType == typeof(System.DateTime?);
    }
}
