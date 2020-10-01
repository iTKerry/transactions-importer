﻿using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using TransactionsImporter.Application.Abstractions;
using TransactionsImporter.Application.Readers.CsvReader;
using TransactionsImporter.Application.Readers.XmlReader;

namespace TransactionsImporter.Application.Readers
{
    public class TransactionsReader : ITransactionsReader
    {
        public List<FileTransactionDto> Read(IFormFile file)
        {
            var fileType = Path.GetExtension(file.FileName);
            return fileType switch
            {
                _ when string.IsNullOrEmpty(fileType) => 
                    throw new ArgumentNullException(nameof(fileType)),
                
                ".csv" =>  new TransactionsCsvReader().ReadFile(file),

                ".xml" => new TransactionsXmlReader().ReadFile(file),

                _ => throw new InvalidOperationException()
            };
        }
    }
}