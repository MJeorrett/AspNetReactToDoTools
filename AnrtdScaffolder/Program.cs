using System;
using System.Collections.Generic;
using System.IO;

namespace AnrtdScaffolder
{
    class Program
    {
        static void Main(string[] args)
        {
            const string entityName = "ToDoList";
            const string anrtdRepoRoot = @"C:\git\github\mjeorrett\AspNetReactToDo";

            var sourceFilePaths = new List<string>() {
                @".\AnrtdApi\Anrtd.Application\XXENTITY_NAMEXXs\Queries\GetById\GetXXENTITY_NAMEXXByIdQuery.cs",
                @".\AnrtdApi\Anrtd.Application\XXENTITY_NAMEXXs\Queries\GetById\XXENTITY_NAMEXXDetailsDto.cs",
                @".\AnrtdApi\Anrtd.Application\XXENTITY_NAMEXXs\Queries\GetPaginated\GetPaginatedXXENTITY_NAMEXXsQuery.cs",
                @".\AnrtdApi\Anrtd.Application\XXENTITY_NAMEXXs\Queries\GetPaginated\GetPaginatedXXENTITY_NAMEXXsQueryValidator.cs",
                @".\AnrtdApi\Anrtd.Application\XXENTITY_NAMEXXs\Queries\GetPaginated\XXENTITY_NAMEXXSummaryDto.cs",
                @".\AnrtdApi\Anrtd.Application\XXENTITY_NAMEXXs\Commands\Create\CreateXXENTITY_NAMEXXCommand.cs",
                @".\AnrtdApi\Anrtd.Application\XXENTITY_NAMEXXs\Commands\Create\CreateXXENTITY_NAMEXXCommandValidator.cs",
                @".\AnrtdApi\Anrtd.Application\XXENTITY_NAMEXXs\Commands\SoftDelete\SoftDeleteXXENTITY_NAMEXXCommand.cs",
                @".\AnrtdApi\Anrtd.Application\XXENTITY_NAMEXXs\Commands\Update\UpdateXXENTITY_NAMEXXCommand.cs",
                @".\AnrtdApi\Anrtd.Application\XXENTITY_NAMEXXs\Commands\Update\UpdateXXENTITY_NAMEXXCommandValidator.cs",
                @".\AnrtdApi\Anrtd.Api\Controllers\XXENTITY_NAMEXXsController.cs",
            };

            foreach (var sourceFilePath in sourceFilePaths)
            {
                ScaffoldSource(entityName, anrtdRepoRoot, sourceFilePath);
            }
        }

        private static void ScaffoldSource(string entityName, string anrtdRepoRoot, string sourceFilePath)
        {
            string lowerCaseEntityName = char.ToLower(entityName[0]) + entityName.Substring(1);

            var destinationFilePathTemplate = Path.Join(anrtdRepoRoot, sourceFilePath);
            var destinationFilePath = destinationFilePathTemplate.Replace("XXENTITY_NAMEXX", entityName);

            var source = File.ReadAllText(sourceFilePath)
                .Replace("XXENTITY_NAMEXX", entityName)
                .Replace("xXENTITY_NAMEXX", lowerCaseEntityName)
                .Replace("IPlaceholderApplicationDbContext", "IApplicationDbContext");

            var directoryToCreate = Path.GetDirectoryName(destinationFilePath);
            Console.WriteLine($"Creating directory '{directoryToCreate}'.");
            Directory.CreateDirectory(directoryToCreate);
            File.WriteAllTextAsync(destinationFilePath, source);
        }
    }
}
